from bs4 import BeautifulSoup
import urllib.request

print('Starting')
httprequest = urllib.request.urlopen('http://sourcesofinsight.com/inspirational-quotes/')
html = BeautifulSoup(httprequest.read())


for header in html.find_all('h2'):
    print(header.text)
#for x in html.find_all('p'):
#    if chr(8212) in x.text :
#         print(x)

print('Ending')
