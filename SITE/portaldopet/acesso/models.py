from django.db import models

# Create your models here.
class Acesso(models.Model):
    SEXO = (
        ('M', 'Masculino'),
        ('F', 'Feminino'),
    )
    ESTADO_CIVIL = (
        ('1', 'Casado'),
        ('2', 'Solteiro'),
        ('3', 'Divorciado'),
        ('4', 'Viúvo'),
    )
    nome = models.CharField(max_length=255)
    email = models.EmailField(max_length=255, unique=True)
    senha = models.CharField(max_length=255)
    nascimento = models.DateField()
    sexo = models.CharField(max_length=1, choices=SEXO)
    estado_civil = models.CharField(max_length=1, choices=ESTADO_CIVIL)

    def __str__(self) -> str:
        return self.nome

class Telefone(models.Model):
    TIPO_TELEFONE = (
        ('F', 'Fixo'),
        ('C', 'Celular'),
    )
    acesso = models.ForeignKey(Acesso, on_delete=models.CASCADE)
    tipo = models.CharField(max_length=1, choices=TIPO_TELEFONE)
    ddd = models.CharField(max_length=2)
    numero = models.CharField(max_length=10)

class Documento(models.Model):
    TIPO_DOCUMENTO = (
        ('R', 'RG'),
        ('C', 'CPF'),
    )
    acesso = models.ForeignKey(Acesso, on_delete=models.CASCADE)
    tipo = models.CharField(max_length=1, choices=TIPO_DOCUMENTO)
    numero = models.CharField(max_length=14)

class Endereco(models.Model):
    TIPO_ENDERECO = (
        ('R', 'Residencial'),
        ('C', 'Comercial'),
    )
    tipo = models.CharField(max_length=1, choices=TIPO_ENDERECO)
    acesso = models.ForeignKey(Acesso, on_delete=models.CASCADE)