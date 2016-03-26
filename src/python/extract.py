from bs4 import BeautifulSoup
import urllib.request
import re
import sqlite3

def initializeQuotesDb(dbCursor):
    dbCursor.executescript('''
        create table if not exists quotes (
            id integer not null primary key autoincrement unique,
            category text not null,
            quote text not null,
            author text not null,
            unique (category, quote, author))''')

def getQuotes(pTags):
    quotes = []
    quote = ''
    author = ''
    for x in pTags:
        matchObj = re.match('(.+)\s—\s(.+)', x.text)
        if matchObj:
            quotes.append((matchObj.group(1),matchObj.group(2)))
            continue

        matchObj = re.match('^—\s(.+)', x.text)
        if matchObj: 
            quotes.append((quote,matchObj.group(1)))
            quote = ''
            continue

        quote = x.text

    return quotes

def getSiblingPTags(section):
    p_tags = []
    for x in section.next_siblings :
        if x.name == 'h2': break
        if x.name == 'p': p_tags.append(x)
    return p_tags

def getPage(url):
    httprequest = urllib.request.urlopen(url)
    html = BeautifulSoup(httprequest.read())
    httprequest.close()
    return html

def writeQuote(category, quote, author, dbcursor):
    dbcursor.execute('''insert or ignore into quotes (category, quote, author)
                        values (?, ?, ?)''', (category, quote, author))

def getUrl(url):
    fname = input('Enter Sources of Insight Quote Url: ')
    if (len(fname) < 1) : fname = url
    return fname

print('Starting')
dbConnection = sqlite3.connect('quotes.sqlite')
dbCursor = dbConnection.cursor()
initializeQuotesDb(dbCursor)


url = getUrl('http://sourcesofinsight.com/inspirational-quotes/')
page = getPage(url)

for section in page.find_all('h2'):
    siblingPTags = getSiblingPTags(section)
    quotes = getQuotes(siblingPTags)
    print(section.text,'Quotes Count',len(quotes))
    for (quote, author) in quotes:
        writeQuote(section.text, quote, author, dbCursor)
    dbConnection.commit()


dbConnection.close()
print('Ending')
