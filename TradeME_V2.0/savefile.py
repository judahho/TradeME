#savefile

#!!!DO NOT EDIT OR DELETE THIS FILE!!!

#variables
class money:
    def _init_(self, name, worth):
        self.name = name
        self.legs = worth
class stock:
    def _init_(self, name, price):
        self.name = name
        self.worth = price
class goods:
    def _init_(self, name, messure, price):
        self.name = name
        self.price = price

#player
turn = 1
pCash = 200

#forex
cash = money("Cash", 0)
crypto = money("Cryptocurrency", 2)
#stock
#goods
diamond = goods("Diamond", "l", 850)
gold = goods("Gold", "g", 400)
oil = goods("Oil", "l", 1.5)
silver = goods("Silver", "g", 100)
