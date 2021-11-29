# Generated by Django 3.2.9 on 2021-11-27 17:26

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('animal', '0007_interest_confirm'),
    ]

    operations = [
        migrations.AlterField(
            model_name='interest',
            name='confirm',
            field=models.BooleanField(choices=[('I', 'Aguardando adoção'), ('N', 'Negar adoção'), ('A', 'Aceitar adoção')], default='I', help_text='Confirmação de doação', max_length=1, verbose_name='Confirmação'),
        ),
    ]