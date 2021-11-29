from django.shortcuts import render
from django.http import Http404, HttpResponse
from django.shortcuts import redirect
from .models import Pet, Specie, Breed, Color, Coat

# Create your views here.
def animal_index(request):
	try:
		pets = Pet.objects.filter(available=True).order_by('-created_at').all()
	except:
		pets = []

	return render(request, 'animal/index.html', { 'pets': pets })

def animal_detail(request, pk):
	try:
		pet = Pet.objects.get(id=pk)
	except:
		return redirect('/animais')

	return render(request, 'animal/detail.html', { 'pet': pet })