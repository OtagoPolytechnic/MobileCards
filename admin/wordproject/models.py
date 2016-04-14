from django.db import models


class WordRecord(models.Model):
    englishWord = models.CharField(max_length=100)
    maoriWord = models.CharField(max_length=100)
    description = models.TextField(null=True, blank=True, max_length=200)
    dateCreated = models.DateTimeField(auto_now_add=True)
    dateUpdated = models.DateTimeField(auto_now=True)
    publish = models.BooleanField(default=False)
