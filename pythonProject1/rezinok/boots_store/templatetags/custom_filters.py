from django import template

register = template.Library()

@register.filter
def multiply(value, arg):
    """Возвращает произведение value и arg."""
    try:
        return float(value) * float(arg)
    except (ValueError, TypeError):
        return 0