from django.urls import path
from . import views

urlpatterns = [
    path('', views.home, name='home'),  # Главная страница
    path('products/', views.product_list, name='product_list'),  # Список товаров
    path('cart/', views.cart, name='cart'),  # Страница корзины
    path('login/', views.login_view, name='login'),  # Страница входа
    path('logout/', views.logout_view, name='logout'),  # Выход пользователя
    path('register/', views.register, name='register'),  # Регистрация пользователя
    path('add_to_cart/', views.add_to_cart, name='add_to_cart'),  # Добавление товара в корзину
   path('cart/remove/<int:item_id>/', views.remove_from_cart, name='remove_from_cart'),
path('checkout/', views.checkout, name='checkout'),
    path('update-cart-quantity/', views.update_cart_quantity, name='update_cart_quantity'),
    path('checkout/', views.checkout, name='checkout'),
    path('order-confirmation/', views.order_confirmation, name='order_confirmation'),
    path('add-review/<int:product_id>/', views.add_review, name='add_review'),
 path('product-reviews/<int:product_id>/', views.product_reviews, name='product_reviews'),
path('update-cart-quantity/', views.update_cart_quantity, name='update_cart_quantity'),
path('product/<int:product_id>/', views.product_detail, name='product_detail'),


]
