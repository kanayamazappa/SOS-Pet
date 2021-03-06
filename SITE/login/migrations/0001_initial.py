# Generated by Django 3.2.9 on 2021-11-03 18:57

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Login',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=150, verbose_name='Nome')),
                ('email', models.EmailField(max_length=254, verbose_name='E-mail')),
                ('password', models.CharField(max_length=1024, verbose_name='Senha')),
                ('created_at', models.DateTimeField(auto_now_add=True)),
                ('updated_at', models.DateTimeField(auto_now=True)),
            ],
            options={
                'verbose_name': 'Usuário',
                'verbose_name_plural': 'Usuários',
            },
        ),
        migrations.CreateModel(
            name='Telephone',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('type', models.CharField(choices=[('C', 'Comercial'), ('R', 'Residencial')], max_length=1, verbose_name='Tipo do Telefone')),
                ('phone', models.CharField(max_length=20, verbose_name='Número')),
                ('created_at', models.DateTimeField(auto_now_add=True)),
                ('updated_at', models.DateTimeField(auto_now=True)),
                ('login', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='login.login')),
            ],
        ),
        migrations.CreateModel(
            name='Document',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('type', models.CharField(choices=[('C', 'CPF'), ('R', 'RG')], max_length=1, verbose_name='Tipo do Documento')),
                ('document', models.CharField(max_length=20, verbose_name='Número')),
                ('created_at', models.DateTimeField(auto_now_add=True)),
                ('updated_at', models.DateTimeField(auto_now=True)),
                ('login', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='login.login')),
            ],
        ),
        migrations.CreateModel(
            name='Address',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('type', models.CharField(choices=[('C', 'Comercial'), ('R', 'Residencial')], max_length=1, verbose_name='Tipo do Endereço')),
                ('street', models.CharField(max_length=150, verbose_name='Logradouro')),
                ('number', models.CharField(max_length=20, verbose_name='Número')),
                ('complement', models.CharField(blank=True, max_length=250, verbose_name='Complemento')),
                ('district', models.CharField(max_length=150, verbose_name='Bairro')),
                ('city', models.CharField(max_length=150, verbose_name='Cidade')),
                ('state', models.CharField(max_length=2, verbose_name='Estado')),
                ('zipCode', models.CharField(max_length=10, verbose_name='CEP')),
                ('created_at', models.DateTimeField(auto_now_add=True)),
                ('updated_at', models.DateTimeField(auto_now=True)),
                ('login', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='login.login')),
            ],
        ),
    ]
