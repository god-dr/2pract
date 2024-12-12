from django.shortcuts import render, redirect, get_object_or_404
from django.contrib.auth import login, authenticate, logout
from django.contrib.auth.forms import UserCreationForm
from django.contrib.auth.decorators import login_required
from django.http import JsonResponse
from .models import Product, CartItem, Category, Review  # Импорт моделей
from django.db.models import Q
from .models import Order, OrderItem, CartItem
from .models import Product, ProductImage


# Главная страница с поиском, фильтрацией и отзывами
def home(request):
    query = request.GET.get('q')  # Получаем параметр поиска из GET-запроса
    category_id = request.GET.get('category')  # Получаем параметр фильтра по категории

    # Начинаем с общего списка товаров
    products = Product.objects.all()

    # Применяем поиск по названию
    if query:
        products = products.filter(name__icontains=query)

    # Применяем фильтр по категории
    if category_id:
        products = products.filter(category_id=category_id)

    # Получаем список всех категорий для фильтрации
    categories = Category.objects.all()

    return render(request, 'boots_store/home.html', {
        'products': products,
        'categories': categories,
        'query': query,
        'selected_category': category_id,
    })


# Список товаров (опционально)
def product_list(request):
    products = Product.objects.all()
    return render(request, 'boots_store/product_list.html', {'products': products})


# Страница корзины
@login_required
def cart(request):
    cart_items = CartItem.objects.filter(user=request.user)
    total_price = sum(item.product.price * item.quantity for item in cart_items)
    return render(request, 'boots_store/cart.html', {'cart_items': cart_items, 'total_price': total_price})


# Вход пользователя
def login_view(request):
    if request.method == 'POST':
        username = request.POST['username']
        password = request.POST['password']
        user = authenticate(request, username=username, password=password)
        if user is not None:
            login(request, user)
            return redirect('home')
        else:
            return render(request, 'boots_store/login.html', {'error': 'Неверные данные'})
    return render(request, 'boots_store/login.html')


# Выход пользователя
def logout_view(request):
    logout(request)
    return redirect('home')


# Регистрация нового пользователя
def register(request):
    if request.method == 'POST':
        form = UserCreationForm(request.POST)
        if form.is_valid():
            user = form.save()
            login(request, user)
            return redirect('home')
    else:
        form = UserCreationForm()
    return render(request, 'boots_store/register.html', {'form': form})


# Добавление товара в корзину с использованием AJAX
@login_required
def add_to_cart(request):
    if request.method == 'POST':
        product_id = request.POST.get('product_id')
        quantity = int(request.POST.get('quantity', 1))
        product = get_object_or_404(Product, id=product_id)

        # Добавление или обновление товара в корзине
        cart_item, created = CartItem.objects.get_or_create(
            user=request.user,
            product=product,
        )
        cart_item.quantity += quantity
        cart_item.save()

        # Возвращаем JSON-ответ
        return JsonResponse({
            "message": "Товар добавлен в корзину!",
            "product_name": product.name,
            "quantity": cart_item.quantity,
        })
    return JsonResponse({"error": "Недопустимый запрос."}, status=400)


@login_required
def remove_from_cart(request, item_id):
    cart_item = get_object_or_404(CartItem, id=item_id, user=request.user)
    cart_item.delete()
    return redirect('cart')


@login_required
def checkout(request):
    if request.method == 'POST':
        payment_method = request.POST.get('payment_method')
        address = request.POST.get('address')
        phone = request.POST.get('phone')

        cart_items = CartItem.objects.filter(user=request.user)
        total_price = sum(item.quantity * item.product.price for item in cart_items)

        # Создаем заказ
        order = Order.objects.create(
            user=request.user,
            total_price=total_price,
            payment_method=payment_method,
            address=address,
            phone=phone,
        )

        # Перемещаем товары из корзины в заказ
        for item in cart_items:
            OrderItem.objects.create(
                order=order,
                product=item.product,
                quantity=item.quantity,
                price=item.product.price,
            )
        cart_items.delete()

        if payment_method == 'bank_transfer':
            return render(request, 'boots_store/bank_transfer.html', {'order': order})
        elif payment_method == 'cash_on_delivery':
            return render(request, 'boots_store/order_confirmation.html', {'order': order})

    return render(request, 'boots_store/checkout.html')


@login_required
def order_confirmation(request):
    return render(request, 'boots_store/order_confirmation.html')


# Добавление отзыва
@login_required
def add_review(request, product_id):
    if request.method == "POST":
        product = get_object_or_404(Product, id=product_id)
        content = request.POST.get("review_content")
        Review.objects.create(product=product, user=request.user, content=content)
        return redirect('product_detail', product_id=product.id)


# Страница отзывов
def product_reviews(request, product_id):
    product = get_object_or_404(Product, id=product_id)
    reviews = product.reviews.all()
    return render(request, 'boots_store/product_reviews.html', {'product': product, 'reviews': reviews})


def update_cart_quantity(request):
    if request.method == 'POST':
        product_id = request.POST.get('product_id')
        quantity = request.POST.get('quantity')
        if product_id and quantity:
            try:
                cart_item = get_object_or_404(CartItem, product_id=product_id, user=request.user)
                cart_item.quantity = int(quantity)
                cart_item.save()
                return JsonResponse({'status': 'success', 'quantity': cart_item.quantity})
            except CartItem.DoesNotExist:
                return JsonResponse({'status': 'error', 'message': 'Товар не найден в корзине.'})
    return JsonResponse({'status': 'error', 'message': 'Недопустимый метод.'})



def product_detail(request, product_id):
    product = get_object_or_404(Product, id=product_id)
    additional_images = product.images.all()  # Получить дополнительные изображения
    return render(request, 'boots_store/product_detail.html', {
        'product': product,
        'additional_images': additional_images,
    })