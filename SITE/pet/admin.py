from django.contrib import admin
from . import models

# Register your models here.
@admin.register(models.Specie)
class SpecieAdmin(admin.ModelAdmin):
    model = models.Specie
    list_display = ['name']
    list_display_links = ['name',]

@admin.register(models.Breed)
class BreedAdmin(admin.ModelAdmin):
    model = models.Breed
    list_display = ['name', 'specie']
    list_display_links = ['name',]

@admin.register(models.Color)
class ColorAdmin(admin.ModelAdmin):
    model = models.Color
    list_display = ['name']
    list_display_links = ['name',]

@admin.register(models.Coat)
class CoatAdmin(admin.ModelAdmin):
    model = models.Coat
    list_display = ['name']
    list_display_links = ['name',]

@admin.register(models.Pet)
class PetAdmin(admin.ModelAdmin):
    model = models.Pet
    list_display = ['name', 'specie', 'breed']
    list_display_links = ['name',]