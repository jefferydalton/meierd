import unittest
import extract
import itertools

class testExtract(unittest.TestCase):
    def testregular(self):
        self.assertNotEqual(len(list(itertools.takewhile(lambda x: x.category == "Achievement",
                                                 extract.pullquotes('http://sourcesofinsight.com/inspirational-quotes/')
                                                         ))),
                            0)

    def testthrowsexceptionbecauseblank(self):
        with self.assertRaises(Exception):
            extract.pullquotes('')


    def testthrowsexceptionbecausenone(self):
        with self.assertRaises(Exception):
            extract.pullquotes(None)

