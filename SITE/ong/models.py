from django.db import models
from autoslug import AutoSlugField

# Create your models here.
class Ong(models.Model):
    name = models.CharField(verbose_name=u"Nome", max_length=100, null=False, blank=False, help_text=u"Nome da Ong")
    fantasia = models.CharField(verbose_name=u"Nome Fantasia", max_length=100, null=False, blank=False, help_text=u"Nome Fantasia da Ong")
    email = models.EmailField(verbose_name=u"E-mail")
    telephone = models.CharField(verbose_name=u"Telefone", max_length=20)
    street = models.CharField(verbose_name=u"Logradouro", max_length=150)
    number = models.CharField(verbose_name=u"Número", max_length=20)
    complement = models.CharField(verbose_name=u"Complemento", max_length=250, blank=True)
    district = models.CharField(verbose_name=u"Bairro", max_length=150)
    city = models.CharField(verbose_name=u"Cidade", max_length=150)
    state = models.CharField(verbose_name=u"Estado", max_length=2)
    zipCode = models.CharField(verbose_name=u"CEP", max_length=10)
    slug = AutoSlugField(populate_from=u"name")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    def __str__(self):
        return self.name