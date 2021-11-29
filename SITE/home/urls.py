from django.conf.urls import url
from . import views

app_name = 'home'

# urlpatterns a lista de roteamentos de URLs para funções/Views
urlpatterns = [
    # GET /
    url(r'^$', views.home_index, name='home_index'),
    url(r'^quem-somos$', views.quemsomos_index, name='quemsomos_index'),
    url(r'^contato$', views.contato_index, name='contato_index'),
    url(r'^contato/ajax$', views.contato_ajax, name='contato_ajax'),
]