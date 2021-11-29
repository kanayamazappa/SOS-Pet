from django.conf.urls import url
from . import views

app_name = 'animal'

# urlpatterns a lista de roteamentos de URLs para funções/Views
urlpatterns = [
    url(r'^$', views.animal_index, name='animal_index'),
    url(r'^(?P<pk>\d+)$', views.animal_detail, name='animal_detail'),
]