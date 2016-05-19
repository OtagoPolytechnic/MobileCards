"""wordapp URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/1.9/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  url(r'^$', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  url(r'^$', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.conf.urls import url, include
    2. Add a URL to urlpatterns:  url(r'^blog/', include('blog.urls'))
"""
from django.conf.urls import url, include
from django.contrib import admin
from wordproject import views
from rest_framework import routers, serializers, viewsets

#Serializers define the API representation
class UserSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = admin
        fields = ('englishWord', 'maoriWord', 'dateCreated', 'dateUpdated', 'publish')

#Viewsets define the view behaviour
class UserViewSet(viewsets.ModelViewSet):
    serializer_class = UserSerializer


#Routers provide an wasy way of automatically determining the URL conf.
router = routers.DefaultRouter()
router.register(r'admin', UserViewSet)

#Wire up our API using automatic URL routing
#Additionally, we can include login URLs for the browsable API
urlpatterns = [
    url(r'^', include(router.urls)),
    url(r'^admin/', admin.site.urls, include('rest_framework.urls', namespace='rest_framework')),
    url(r'^json/', views.word_json),
]
