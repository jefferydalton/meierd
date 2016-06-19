from bs4 import BeautifulSoup
import urllib.request
import re
import itertools
import more_itertools

class Quote:
    def __init__(self, category, quote, author):
        self._category = category
        self._quote = quote
        self._author = author

    @property
    def category(self):
        return self._category

    @property
    def quote(self):
        return self._quote

    @property
    def author(self):
        return self._author

def _filtertags(pagetags):
    y = []
    for x in pagetags.h2.next_siblings:
        if x.name == "h2" or x.name == "p":
            y.append(x)

    return y

def _mapquotes(pagetags):
    items = []
    category = ""
    pagetagitr = more_itertools.peekable(pagetags)
    for tag in pagetagitr:
        if tag.name == "h2":
            category = tag.text
            continue

        if tag.name == "p" and pagetagitr.peek(tag).name == "p":
            matchresult = re.match('(“.+”)\s(—|–)\s(.+)', tag.text + " " + pagetagitr.peek(tag).text)
            if matchresult:
                items.append(Quote(category, matchresult.group(1), matchresult.group(3)))
                next(pagetagitr)
                continue

    return items

def pullquotes(siteurl):
    if siteurl in (None, ''):
        raise Exception("siteUrl must contain a valid value")

    with urllib.request.urlopen(siteurl) as httpRequest:
        page = BeautifulSoup(httpRequest.read(), "html.parser")

    return _mapquotes(_filtertags(page))

