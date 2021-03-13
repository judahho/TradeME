#imports
import random
import os
import savefile

# classes
class Asset:
    # class properties
    tag = "tag"
    price = 0
    low = 1
    high = 10
    amount = 0

    def __init__(self, tag, low=1, high=10):
        self.tag = tag
        self.low = low
        self.high = high
        self.Tick()

    def Tick(self):
        self.price = random.randint(self.low, self.high)

class Game:
    turn = 1
    t = 0
    assets = []
    cash = 100

    def __init__(self):
        self.errorAsset = Asset("error") # if this asset is returned, an asset was not found

    def Buy(self):
        # step 1
        self.msg2 = str(input("What would you like to buy: "))
        self.target = self.GetAsset(self.msg2)
        if self.target == self.errorAsset:
            input("This asset does not exist.")
            return
        # step 2
        self.msg3 = int(input("How many units: "))
        if (self.target.price * self.msg3) <= self.cash:
            # buy
            self.cash -= self.target.price * self.msg3
            self.target.amount += self.msg3
            input("Trade successful!")
            return
        else:
            input("You do not have enough money for that many")
            return

    def GetAsset(self, a):
        for x in self.assets:
            if x.tag == a:
                return x
        return self.errorAsset

    def Sell(self):
        # step 1
        self.msg2 = str(input("What would you like to sell: "))
        self.target = self.GetAsset(self.msg2)
        if self.target == self.errorAsset:
            input("This asset does not exist.")
            return
        if self.target.amount <= 0:
            input("You do not have any of that asset")
            return
        # step 2
        self.msg3 = int(input("How many units: "))
        if self.target.amount >= self.msg3:
            # sell
            self.cash += self.target.price * self.msg3
            self.target.amount -= self.msg3
            input("Trade successful!")
            return
        else:
            input("You do not have that many units")
            return
         
    def Tick(self):
        print("\nTurn: " + str(self.turn))
        print("PRICES")
        for x in self.assets:
            x.Tick()
            print(str(x.tag) + ": $" + str(x.price) + " | " + str(x.amount) + " | " + str(x.low) + "/" + str(x.high))
        return

# Instantiate game
run = Game()
run.assets.append(Asset("gold", 70, 300))
run.assets.append(Asset("silver", 60, 170))
run.assets.append(Asset("oil", 20, 30))
run.assets.append(Asset("food", 2, 12))
run.assets.append(Asset("bsk", 5, 8))
run.assets.append(Asset("ntsk", 1, 4))
run.assets.append(Asset("olsk", 5, 9))

while True:
    if run.turn > run.t:
        run.Tick()
        run.t = run.turn
    
    print("\nCash: " + str(run.cash))

    #actions
    inst = input("What would you like to do: ")
    if inst == "buy":
        run.Buy()
    elif inst == "sell":
        run.Sell()
    elif inst == "save":
        try:
            file = open("savefile.py", "w")
            file.write("cash = " + str(cash) + "\n#assets\nMgold = " + str(Mgold) + "\nMsilver = " + str(Msilver) + "\nMfood = " + str(Mfood) + "\nMoil = " + str(Moil) + "\nMbsk = " + str(Mbsk) + "\nMntsk = " + str(Mntsk) + "\nMolsk = " + str(Molsk))
            file.close()
            input("[SUCCES]Saved")
        except:
            print("[Failed] An error occored")
            raise
    elif inst == "pass":
        try:
            run.turn += 1
            input("Round passed...")
        except:
            pass
    elif inst == "quit":
        break
    else:
        print("That is an invalid Action.")
        del inst
        input()
