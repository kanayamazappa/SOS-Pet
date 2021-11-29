from django.shortcuts import render
from django.http import Http404, HttpResponse
from django.shortcuts import redirect
from .models import Ong

# Create your views here.
def ong_index(request):
	try:
		ongs = Ong.objects.order_by('-created_at').all()
	except:
		ongs = []

	return render(request, 'ong/index.html', { 'ongs': ongs })

def ong_detail(request, pk):
	try:
		ong = Ong.objects.get(id=pk)
	except:
		return redirect('/ongs')

	return render(request, 'ong/detail.html', { 'ong': ong })