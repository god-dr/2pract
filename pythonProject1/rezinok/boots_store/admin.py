from django.contrib import admin
from .models import Category, Product, CartItem ,ProductImage # Импорт только существующих моделей
from .models import Review

# Регистрация моделей для отображения в админке
admin.site.register(Category)
admin.site.register(Product)
admin.site.register(CartItem)
admin.site.register(Review)
admin.site.register(ProductImage)
