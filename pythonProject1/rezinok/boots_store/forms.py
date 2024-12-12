from django import forms
from .models import Review

class ReviewForm(forms.ModelForm):
    class Meta:
        model = Review
        fields = ['content']
        widgets = {
            'content': forms.Textarea(attrs={
                'class': 'form-control',
                'placeholder': 'Оставьте свой отзыв...',
                'rows': 4
            }),
        }
        labels = {
            'content': 'Ваш отзыв',
        }
