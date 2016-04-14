from django.shortcuts import render

from django.core import serializers
from  django.http import HttpResponse
from wordproject.models import WordRecord


def word_json(request):
    words = WordRecord.objects.all()
    data = serializers.serialize("json", words)
    return HttpResponse(data, content_type='application/json')
