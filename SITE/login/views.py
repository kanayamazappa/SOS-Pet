import json
from django.shortcuts import render
from django.http import Http404, HttpResponse
from django.shortcuts import redirect
from django.core.mail import send_mail
from cryptography.fernet import Fernet
from datetime import datetime, timedelta
from .models import Login, Document, Telephone, Address
from animal.models import Pet, Specie, Breed, Color, Coat, Interest

# Create your views here.
key = 'zxroME6Q35lvbcOvOqpD8pu1B6d0ZTpbW2mmFt5FwNM='

def login_index(request):
	return render(request, 'login/index.html', { })

def login_esqueci(request):
	return render(request, 'login/esqueci-senha.html', { })

def login_esqueci_ajax(request):
	if request.is_ajax() and request.POST:
		email = request.POST.get('email')

		login = Login.objects.get(email=email)
		data = {'success': False}
		if login != None:
			message = "Olá %s, sua senha é: %s" % (login.name, login.password)
			send_mail("SOS Pet - Recuperação de senha", message, "SOS Pet<site@kanayama.app.br>", [login.email])
			data = {'success': True, 'email': login.email}

		return HttpResponse(json.dumps(data), content_type='application/json')

def login_cadastro(request):
	return render(request, 'login/cadastro.html', { })

def login_cadastro_ajax(request):
	if request.is_ajax() and request.POST:
		name = request.POST.get('name')
		email = request.POST.get('email')
		password = request.POST.get('password')
		confirm = request.POST.get('confirm')
		cpf = request.POST.get('cpf')
		phone = request.POST.get('phone')
		zipCode = request.POST.get('zipCode')
		street = request.POST.get('street')
		number = request.POST.get('number')
		complement = request.POST.get('complement')
		district = request.POST.get('district')
		city = request.POST.get('city')
		state = request.POST.get('state')

		if password != confirm:
			return HttpResponse(json.dumps({'success': False, 'message': 'Sua senha e a confirmação não coincidem!'}), content_type='application/json')

		if Login.objects.filter(email=email, active=True).count() > 0:
			return HttpResponse(json.dumps({'success': False, 'message': 'Já existe um cadastro com este e-mail!'}), content_type='application/json')

		# Removendo cadastro com mesmo e-mail inativos
		try:
			Login.objects.filter(email=email, active=False).delete()
		except:
			pass

		login = Login(
			name=name,
			email=email,
			password=password,
			active=False
		)
		login.save()
		data = {'success': False, 'message': 'Não foi possível realizar seu cadastro!'}
		if login != None:
			document = Document(login=login, type='C', document=cpf)
			document.save()

			phone = Telephone(login=login, type='R', phone=phone)
			phone.save()

			address = Address(login=login, type='R', street=street, number=number, complement=complement, district=district, city=city, state=state, zipCode=zipCode)
			address.save()

			request.session['login'] = login.id

			date_key = datetime.timestamp(datetime.now() + timedelta(hours=1))

			key_active = encrypt('%s|@|%d' % (date_key, login.id))

			message = 'Olá %s, para ativar sua conta clique <a href="http://kanayama.app.br/login/ativar?key=%s">aqui</a>' % (login.name, key_active)

			send_mail("SOS Pet - Ativação de conta", message, "SOS Pet<site@kanayama.app.br>", [login.email])

			message = 'Cadastro realizado com sucesso!\n Enviamos o link de ativação da conta no e-mail: %s' % login.email

			data = {'success': True, 'message': message}

		return HttpResponse(json.dumps(data), content_type='application/json')

def login_editar(request):
	if not check_login(request):
		return redirect('/login')

	login = Login.objects.get(id=request.session.get('login', 0))
	cpf = ''
	document = Document.objects.filter(login__id=request.session.get('login', 0)).first()
	if document != None:
		cpf = document.document

	phone = ''
	telephone = Telephone.objects.filter(login__id=request.session.get('login', 0)).first()
	if telephone != None:
		phone = telephone.phone

	address = Address.objects.filter(login__id=request.session.get('login', 0)).first()

	return render(request, 'login/editar.html', { 'login': login, 'cpf': cpf, 'phone': phone, 'address': address })

def login_editar_ajax(request):
	if not check_login(request):
		return redirect('/login')

	if request.is_ajax() and request.POST:
		try:
			name = request.POST.get('name')
			email = request.POST.get('email')
			password = request.POST.get('password')
			confirm = request.POST.get('confirm')
			cpf = request.POST.get('cpf')
			phone = request.POST.get('phone')
			zipCode = request.POST.get('zipCode')
			street = request.POST.get('street')
			number = request.POST.get('number')
			complement = request.POST.get('complement')
			district = request.POST.get('district')
			city = request.POST.get('city')
			state = request.POST.get('state')

			if password != confirm:
				return HttpResponse(json.dumps({'success': False, 'message': 'Sua senha e a confirmação não coincidem!'}), content_type='application/json')

			login = Login.objects.get(id=request.session.get('login', 0))
			login.name = name
			login.email = email
			login.password = password
			login.save()

			document = Document.objects.filter(login__id=request.session.get('login', 0)).first()
			if document != None:
				document.document = cpf
			else:
				document = Document(login=login, type='C', document=cpf)
			document.save()

			telephone = Telephone.objects.filter(login__id=request.session.get('login', 0)).first()
			if telephone != None:
				telephone.phone = phone
			else:
				telephone = Telephone(login=login, type='R', phone=phone)
			telephone.save()

			address = Address.objects.filter(login__id=request.session.get('login', 0)).first()
			if address != None:
				address.zipCode = zipCode
				address.street = street
				address.number = number
				address.complement = complement
				address.district = district
				address.city = city
				address.state = state
			else:
				address = Address(login=login, type='R', street=street, number=number, complement=complement, district=district, city=city, state=state, zipCode=zipCode)
			address.save()

			message = 'Perfil alterado com sucesso!'
			data = {'success': True, 'message': message}
		except:
			message = 'Não foi possível alterar seu perfil!'
			data = {'success': True, 'message': message}

	return HttpResponse(json.dumps(data), content_type='application/json')

def login_active(request):
	key_active = str(decrypt(request.GET.get('key')))
	date_key = ''
	date_now = datetime.now()
	login_id = 0
	success = False
	if key_active.find('|@|'):
		timestamp = float(key_active.split('|@|')[0])
		date_key = datetime.fromtimestamp(timestamp)
		login_id = int(key_active.split('|@|')[1])

		if date_now <= date_key:
			login = Login.objects.get(id=login_id)
			login.active = True
			login.save()
			message = "Cadastro ativado com sucesso!"
			success = True
		else:
			date_key = datetime.timestamp(datetime.now() + timedelta(hours=1))
			key_active = encrypt('%s|@|%d' % (date_key, login.id))
			message = 'Olá %s, para ativar sua conta clique <a href="http://kanayama.app.br/login/ativar?key=%s">aqui</a>' % (login.name, key_active)
			send_mail("SOS Pet - Ativação de conta", message, "SOS Pet<site@kanayama.app.br>", [login.email])
			message = "Seu link esta expirado, foi enviado um novo e-mail!"
	else:
		message = "Falha ao ativar o cadastro, token não reconhecido!"

	return render(request, 'login/ativar.html', { 'success': success, 'message': message })

def login_logout(request):
	try:
		del request.session['login']
	except:
		pass
	return redirect('/login')

def login_ajax(request):
	if request.is_ajax() and request.POST:
		email = request.POST.get('email')
		password = request.POST.get('password')

		data = {'success': False, 'message': 'Login e/ou senha incorrétos!'}
		try:
			login = Login.objects.get(email=email, password=password)

			if not login.active:
				data = {'success': False, 'message': 'Login inátivo, acesse seu e-mail e clique no link para ativar seu cadastro!'}
				return HttpResponse(json.dumps(data), content_type='application/json')

			data = {'success': True}
			request.session['login'] = login.id
			return HttpResponse(json.dumps(data), content_type='application/json')
		except:
			return HttpResponse(json.dumps(data), content_type='application/json')
	else:
		raise Http404

def login_area(request):
	if not check_login(request):
		return redirect('/login')
	return render(request, 'login/area.html', {})

def login_animais(request):
	if not check_login(request):
		return redirect('/login?redirect=/login/animais')

	#try:
	login=get_logged_user(request)
	pets = []
	for pet in Pet.objects.filter(login=login).order_by('-created_at').all():
		interest = pet.interest_set.filter(confirm='I').count()
		adoption = pet.interest_set.filter(confirm='A').count()
		pets.append({
			'pet': pet,
			'interest': interest,
			'adoption': adoption
		})
	#except:
		#pets = []

	return render(request, 'login/animais.html', { 'pets': pets })

def login_animais_edit(request, pk):
	if not check_login(request):
		return redirect('/login?redirect=/login/animais/editar/%d' % pk)

	try:
		login=get_logged_user(request)
		pet = Pet.objects.get(login=login, id=pk)
	except:
		return redirect('/login/animais')
	return render(request, 'login/animais-editar.html', { 
		'pet': pet, 
		'species': Specie.objects.all(), 
		'breeds': Breed.objects.all(), 
		'colors': Color.objects.all(), 
		'coats': Coat.objects.all()
		})

def login_animais_edit_ajax(request, pk):
	if request.method == 'POST':
		try:
			name = request.POST.get('name')
			genre = request.POST.get('genre')
			microship = request.POST.get('microship')
			age = request.POST.get('age')
			weight = request.POST.get('weight')
			height = request.POST.get('height')
			specie = request.POST.get('specie')
			breed = request.POST.get('breed')
			castrated = request.POST.get('castrated')
			color = request.POST.get('color')
			coat = request.POST.get('coat')
			personality = request.POST.get('personality')
			vaccination = request.POST.get('vaccination', 'False')
			available = request.POST.get('available', 'False')
			photo = request.FILES.get('photo', None)

			login=get_logged_user(request)
			pet = Pet.objects.get(login=login, id=pk)
			pet.name = name
			pet.genre = genre
			pet.microship = microship
			pet.age = age
			pet.weight = weight
			pet.height = height
			pet.specie = Specie.objects.get(id=specie)
			pet.breed = Breed.objects.get(id=breed)
			pet.castrated = castrated
			pet.color = Color.objects.get(id=color)
			pet.coat = Coat.objects.get(id=coat)
			pet.personality = personality

			if vaccination == 'True':
				pet.vaccination = True

			if available == 'True':
				pet.available = available

			if (photo != None):
				pet.photo = photo

			pet.save()

			return HttpResponse(json.dumps({'success': True, 'message': 'Animal alterado com sucesso!'}), content_type='application/json')
		except:
		 	return HttpResponse(json.dumps({'success': False, 'message': 'Não foi possível alterar o animal!'}), content_type='application/json')

def login_animais_register(request):
	if not check_login(request):
		return redirect('/login?redirect=/login/animais/cadastrar')

	try:
		login=get_logged_user(request)
	except:
		return redirect('/login/animais')
	return render(request, 'login/animais-cadastrar.html', { 
		'species': Specie.objects.all(), 
		'breeds': Breed.objects.all(), 
		'colors': Color.objects.all(), 
		'coats': Coat.objects.all()
		})

def login_animais_register_ajax(request):
	if request.method == 'POST':
		try:
			name = request.POST.get('name')
			genre = request.POST.get('genre')
			microship = request.POST.get('microship')
			age = request.POST.get('age')
			weight = request.POST.get('weight')
			height = request.POST.get('height')
			specie = request.POST.get('specie')
			breed = request.POST.get('breed')
			castrated = request.POST.get('castrated', 'False')
			color = request.POST.get('color')
			coat = request.POST.get('coat')
			personality = request.POST.get('personality')
			vaccination = request.POST.get('vaccination', 'False')
			available = request.POST.get('available', 'False')
			photo = request.FILES.get('photo', None)

			login=get_logged_user(request)
			pet = Pet(
				login = login, 
				name = name,
				genre = genre,
				microship = microship,
				age = age,
				weight = weight,
				height = height,
				specie = Specie.objects.get(id=specie),
				breed = Breed.objects.get(id=breed),
				castrated = castrated,
				color = Color.objects.get(id=color),
				coat = Coat.objects.get(id=coat),
				personality = personality,
			)
			

			if vaccination == 'True':
				pet.vaccination = True

			if available == 'True':
				pet.available = available

			if (photo != None):
				pet.photo = photo

			pet.save()

			return HttpResponse(json.dumps({'success': True, 'message': 'Animal cadastrado com sucesso!'}), content_type='application/json')
		except:
		 	return HttpResponse(json.dumps({'success': False, 'message': 'Não foi possível cadastrar o animal!'}), content_type='application/json')

def login_animais_interest(request, pk):
	if not check_login(request):
		return redirect('/login?redirect=/login/animais/interesse/%s' % pk)

	try:
		pet = Pet.objects.get(id=pk)
	except:
		return redirect('/login/area')

	return render(request, 'login/animais-interesse.html', { 'pet': pet })

def login_animais_interest_ajax(request, pk):
	try:
		if request.is_ajax() and request.POST:
			interest_send = request.POST.get('interest', "false")

			if interest_send == "true":
				pet = Pet.objects.get(id=pk)
				interested=get_logged_user(request)
				owner = pet.login

				if Interest.objects.filter(login = interested, pet = pet).count() > 0:
					return HttpResponse(json.dumps({'success': False, 'message': 'Você já declarou interesse pelo animal.', 'interest_send': interest_send}), content_type='application/json')

				interest = Interest(
					login = interested,
					pet = pet,
					confirm = False
				)

				interest.save()

				message = """
					<p>Olá {{owner_name}}, o {{interested_name}} está interessado no seu animal {{pet_name}}</p>
					<p><a href="http://www.kanayama.app.br/login/animais/adocao/{{interest_id}}">Clique aqui</a> para ver mais detalhes</p>
				""".replace("{{owner_name}}", owner.name).replace("{{interested_name}}", interested.name).replace("{{pet_name}}", pet.name).replace("{{interest_id}}", str(interest.id))

				from_email = "%s<%s>" % (interested.name, interested.email)

				send_mail("SOS Pet - Recuperação de senha", message, from_email, [owner.email], html_message=message)

				return HttpResponse(json.dumps({'success': True, 'message': 'Solicitação de interesse enviada com sucesso!'}), content_type='application/json')
			else:
				return HttpResponse(json.dumps({'success': False, 'message': 'Não foi possível enviar sua solicitação de enteresse.', 'interest_send': interest_send}), content_type='application/json')
	except:
		raise Http404

def login_animais_order_adoption(request, pk):
	try:
		pet = Pet.objects.get(id=pk)
		interests = Interest.objects.filter(pet__id=pk, confirm='I').all()
	except:
		pet = None
		interests = []

	return render(request, 'login/animais-pedidos-adocao.html', { 'interests': interests, 'pet': pet })

def login_animais_order_adoption_ajax(request, pk):
	#try:
	if request.is_ajax() and request.POST:
		confirm = request.POST.get('confirm', "I")

		interest = Interest.objects.get(id=pk)
		interest.confirm = confirm
		interest.save()

		if confirm == 'A':
			pet = interest.pet
			pet.available = False
			pet.save()
			return HttpResponse(json.dumps({'success': True, 'message': 'Solicitação de adoção aceita!'}), content_type='application/json')
		elif confirm == 'N':
			return HttpResponse(json.dumps({'success': True, 'message': 'Solicitação de adoção negada!'}), content_type='application/json')
		else:
			return HttpResponse(json.dumps({'success': False, 'message': 'Solicitação de adoção continua aguardando sua ação!'}), content_type='application/json')
	else:
		return HttpResponse(json.dumps({'success': False, 'message': 'Não foi possível finalizar a solicitação de doação.'}), content_type='application/json')
	#except:
	#	return HttpResponse(json.dumps({'success': False, 'message': 'Não foi possível finalizar a solicitação de doação.'}), content_type='application/json')


def check_login(request):
	if request.session.get('login', 0) == 0:
		return False
	else:
		return True

def get_logged_user(request):
	try:
		if (check_login(request)):
			id = request.session.get('login', 0)
			return Login.objects.get(id=id)
		else:
			return None
	except:
		return None

def encrypt(text):
	cipher_suite = Fernet(key)
	return cipher_suite.encrypt(text.encode()).decode()

def decrypt(text):
	cipher_suite = Fernet(key)
	return cipher_suite.decrypt(text.encode()).decode()
