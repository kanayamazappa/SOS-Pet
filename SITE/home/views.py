import json
from django.shortcuts import render
from django.http import HttpResponse
from django.core.mail import send_mail
from banner.models import Banner
from .models import QuemSomos, Contact, Recipient

# Create your views here.
def home_index(request):
    try:
        banners = Banner.objects.order_by('sort_order')[:3]
    except:
        banners = []

    return render(request, 'home/index.html', { 'banners': banners })

def quemsomos_index(request):
    return render(request, 'home/quem-somos.html', { 'QuemSomos': QuemSomos.objects.get(id=1)})

def contato_index(request):
    return render(request, 'home/contato.html', { })

def contato_ajax(request):
    if request.is_ajax() and request.POST:
        name = request.POST.get('name')
        email = request.POST.get('email')
        subject = request.POST.get('subject')
        message = request.POST.get('message')

        data = {'success': False, 'message': 'Falha ao enviar o contato!'}
        try:
            contact = Contact(name=name, email=email, subject=subject, message=message)
            contact.save()

            recipients = []

            for item in Recipient.objects.all():
                recipients.append(item.email)

            message = """<table border="1">
                <tr><th align="left">Nome</th><td>{{name}}</td></tr>
                <tr><th align="left">E-mail</th><td>{{email}}</td></tr>
                <tr><th align="left">Assunto</th><td>{{subject}}</td></tr>
                <tr><th align="left">Mensagem</th><td>{{message}}</td></tr>
            </table>""".replace("{{name}}", name).replace("{{email}}", email).replace("{{subject}}", subject).replace("{{message}}", message)

            from_email = "SOS Pet<%s>" % email

            send_mail("SOS Pet - Contato", message, from_email, recipients, html_message=message)

            data = {'success': True, 'message': 'Contato enviado com sucesso'}
            return HttpResponse(json.dumps(data), content_type='application/json')
        except:
            return HttpResponse(json.dumps(data), content_type='application/json')
    else:
        raise Http404