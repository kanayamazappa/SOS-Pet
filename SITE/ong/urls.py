from django.conf.urls import url
from . import views

app_name = 'ong'

# urlpatterns a lista de roteamentos de URLs para funções/Views
urlpatterns = [
    url(r'^$', views.ong_index, name='ong_index'),
    url(r'^(?P<pk>\d+)$', views.ong_detail, name='ong_detail'),
]