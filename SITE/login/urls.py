from django.conf.urls import url
from . import views

app_name = 'login'

# urlpatterns a lista de roteamentos de URLs para funções/Views
urlpatterns = [
    url(r'^$', views.login_index, name='login_index'),
    url(r'^logout$', views.login_logout, name='login_logout'),
    url(r'^esqueci-senha$', views.login_esqueci, name='login_esqueci'),
    url(r'^esqueci-senha/ajax$', views.login_esqueci_ajax, name='login_esqueci_ajax'),
    url(r'^cadastro$', views.login_cadastro, name='login_cadastro'),
    url(r'^cadastro/ajax$', views.login_cadastro_ajax, name='login_cadastro_ajax'),
    url(r'^ativar$', views.login_active, name='login_active'),
    url(r'^ajax$', views.login_ajax, name='login_ajax'),
    url(r'^area$', views.login_area, name='login_area'),
    url(r'^perfil$', views.login_editar, name='login_editar'),
    url(r'^perfil/ajax$', views.login_editar_ajax, name='login_editar_ajax'),
    url(r'^animais$', views.login_animais, name='login_animais'),
    url(r'^animais/(?P<pk>\d+)$', views.login_animais_edit, name='login_animais_edit'),
    url(r'^animais/ajax/(?P<pk>\d+)$', views.login_animais_edit_ajax, name='login_animais_edit_ajax'),
    url(r'^animais/cadastrar$', views.login_animais_register, name='login_animais_register'),
    url(r'^animais/cadastrar/ajax$', views.login_animais_register_ajax, name='login_animais_register_ajax'),
    url(r'^animais/interesse/(?P<pk>\d+)$', views.login_animais_interest, name='login_animais_interest'),
    url(r'^animais/interesse/ajax/(?P<pk>\d+)$', views.login_animais_interest_ajax, name='login_animais_interest_ajax'),
    url(r'^animais/pedidos-adocao/(?P<pk>\d+)$', views.login_animais_order_adoption, name='login_animais_order_adoption'),
    url(r'^animais/pedidos-adocao/ajax/(?P<pk>\d+)$', views.login_animais_order_adoption_ajax, name='login_animais_order_adoption_ajax'),
]