from django.db import models
from django.contrib.auth.models import User  # Импорт модели User


# Модель для категорий товаров
class Category(models.Model):
    name = models.CharField(max_length=200)

    def __str__(self):
        return self.name


# Модель для продуктов
class Product(models.Model):
    name = models.CharField(max_length=200)
    description = models.TextField()
    price = models.DecimalField(max_digits=10, decimal_places=2)
    image = models.ImageField(upload_to='products/')  # Главное изображение
    category = models.ForeignKey(Category, on_delete=models.CASCADE, related_name='products')

    def __str__(self):
        return self.name


# Модель для дополнительных изображений продукта
class ProductImage(models.Model):
    product = models.ForeignKey(Product, on_delete=models.CASCADE, related_name='images')
    image = models.ImageField(upload_to='products/additional/')

    def __str__(self):
        return f"Доп. изображение для {self.product.name}"


# Модель для элемента корзины (CartItem)
class CartItem(models.Model):
    user = models.ForeignKey(User, on_delete=models.CASCADE)  # Связь с пользователем
    product = models.ForeignKey(Product, on_delete=models.CASCADE)  # Связь с продуктом
    quantity = models.PositiveIntegerField(default=1)

    def __str__(self):
        return f"{self.product.name} x {self.quantity}"


# Модель для заказа
class Order(models.Model):
    PAYMENT_METHOD_CHOICES = [
        ('bank_transfer', 'Банковский перевод'),
        ('cash_on_delivery', 'Наложенный платеж'),
    ]

    user = models.ForeignKey(User, on_delete=models.CASCADE)
    created_at = models.DateTimeField(auto_now_add=True)
    total_price = models.DecimalField(max_digits=10, decimal_places=2)
    is_paid = models.BooleanField(default=False)
    payment_method = models.CharField(max_length=20, choices=PAYMENT_METHOD_CHOICES)
    address = models.TextField(blank=True, null=True)
    phone = models.CharField(max_length=15, blank=True, null=True)

    def __str__(self):
        return f"Order {self.id} by {self.user.username}"


# Модель для элементов заказа
class OrderItem(models.Model):
    order = models.ForeignKey(Order, on_delete=models.CASCADE, related_name='items')
    product = models.ForeignKey(Product, on_delete=models.CASCADE)
    quantity = models.PositiveIntegerField()
    price = models.DecimalField(max_digits=10, decimal_places=2)

    def __str__(self):
        return f"{self.product.name} x {self.quantity}"


# Модель для отзывов
class Review(models.Model):
    user = models.ForeignKey(User, on_delete=models.CASCADE)  # Пользователь, оставивший отзыв
    product = models.ForeignKey(Product, on_delete=models.CASCADE,
                                related_name='reviews')  # Продукт, к которому относится отзыв
    content = models.TextField()  # Текст отзыва
    created_at = models.DateTimeField(auto_now_add=True)  # Время создания отзыва

    def __str__(self):
        return f"Review by {self.user.username} on {self.product.name}"
