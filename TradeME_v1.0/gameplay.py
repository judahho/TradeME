#imports
import random
import os
import goods
import stocks
import myObjects

def ingame():
    while True:
        #random price picks
        gold = random.randint(int(goods.gold.priceRange))
        silver = random.randint(int(goods.silver.priceRange))
        oil = random.randint(int(goods.oil.priceRange))
        food = random.randint(int(goods.food.priceRange))
        bsk = random.randint(int(stocks.bsk.priceRange))
        ntsk = random.randint(int(stocks.ntsk.priceRange))
        olsk = random.randint(int(stocks.olsk.priceRange))

        #new info
        print("\nCash: $" + str(cash))
        print("Prices:")
        print("  Gold:   $" + str(gold) + " | 70/300")
        print("  Silver: $" + str(silver) + " | 60/170")
        print("  Oil:    $" + str(oil) + " | 20/30")
        print("  Food:   $" + str(food) + " | 2/12")
        print("  BSK:    $" + str(bsk) + " | 5/8")
        print("  NTSK:   $" + str(ntsk) + " | 1/4")
        print("  OLSK:   $" + str(olsk) + " | 5/9")
        print("Your Assets:")
        print("  Gold:     " + str(Mgold) + "g")
        print("  Silver:   " + str(myObjects.mygoods.Msilver) + "g")
        print("  Oil:      " + str(myObjects.mygoods.Moil) + "L")
        print("  Food:     " + str(myObjects.mygoods.Mfood) + "kg")
        print("  BSK:      " + str(myObjects.mystocks.Mbsk))
        print("  NTSK:     " + str(myObjects.mystocks.Mntsk))
        print("  OLSK:     " + str(myObjects.mystocks.Molsk))

        #actions
        inst = input("What would you like to do: ")
        if inst == "buy":
            try:
                inst2 = input("What would you like to buy: ")
                if inst2 == "gold":
                    inst3 = float(input("How many grams: "))
                    if (gold * int(inst3)) <= cash:
                        myObjects.mygoods.myObjects.mygoods.myObjects.mygoods.Mgold += int(inst3)
                        cash -= (gold * int(inst3))
                        gold += (random.randint(5, 20))
                        del inst3
                        del inst2
                        del inst
                    else:
                        input("That is too much gold for your money.")
                        del inst3
                        del inst2
                        del inst
                elif inst2 == "silver":
                    inst3 = float(input("How many grams: "))
                    if (silver * int(inst3)) <= cash:
                        myObjects.mygoods.Msilver += int(inst3)
                        cash -= (silver * int(inst3))
                        del inst3
                        del inst2
                        del inst
                    else:
                        input("That is too much silver for your money.")
                        del inst3
                        del inst2
                        del inst
                elif inst2 == "food":
                    inst3 = float(input("How many kg(s): "))
                    if (food * int(inst3)) <= cash:
                        myObjects.mygoods.Mfood += int(inst3)
                        cash -= (food * int(inst3))
                        del inst3
                        del inst2
                        del inst
                    else:
                        input("That is too much food for your money: ")
                        del inst3
                        del inst2
                        del inst
                elif inst2 == "oil":
                    inst3 = input("How many liter(s): ")
                    if (oil * int(inst3)) <= cash:
                        myObjects.mygoods.Moil += int(inst3)
                        cash -= (oil * int(inst3))
                        del inst3
                        del inst2
                        del inst
                    else:
                        input("That is too much oil for your money.")
                        del inst3
                        del inst2
                        del inst
                elif inst2 == "bsk":
                    inst3 = input("How many stocks: ")
                    if (bsk * int(inst3)) <= cash:
                        myObjects.mystocks.Mbsk += int(inst3)
                        cash -= (bsk * int(inst3))
                        del inst3
                        del inst2
                        del inst
                    else:
                        input("those are to many for your money.")
                        del inst3
                        del inst2
                        del inst
                elif inst2 == "ntsk":
                    inst3 = input("How many stocks: ")
                    if (ntsk * int(inst3)) <= cash:
                        myObjects.mystocks.Mntsk += int(inst3)
                        cash -= (ntsk * int(inst3))
                        del inst3
                        del inst2
                        del inst
                    else:
                        input("those are to many for your money.")
                        del inst3
                        del inst2
                        del inst
                elif inst2 == "olsk":
                    inst3 = input("How many stocks: ")
                    if (olsk * int(inst3)) <= cash:
                        myObjects.mystocks.Molsk += int(inst3)
                        cash -= (olsk * int(inst3))
                        del inst3
                        del inst2
                        del inst
                    else:
                        input("those are to many for your money.")
                        del inst3
                        del inst2
                        del inst
            except:
                input("\nPROBLEM OCCORED...\n")
        elif inst == "sell":
            try:
                inst2 = input("What Would you like to sell: ")
                if inst2 == "gold" and myObjects.mygoods.Mgold >= 1:
                    inst3 = input("How much gold: ")
                    if int(inst3) <= myObjects.mygoods.Mgold:
                        myObjects.mygoods.Mgold -= int(inst3)
                        cash += (gold * int(inst3))
                    else:
                        input("That is more gold than you have.")
                elif inst2 == "silver" and myObjects.mygoods.Msilver >= 1:
                    inst3 = input("How much silver: ")
                    if int(inst3) <= myObjects.mygoods.Msilver:
                        myObjects.mygoods.Msilver -= int(inst3)
                        cash += (silver * int(inst3))
                    else:
                        input("That is more silver than you have.")
                elif inst2 == "food" and myObjects.mygoods.Mfood >= 1:
                    inst3 = input("How much food: ")
                    if int(inst3) <= myObjects.mygoods.Mfood:
                        myObjects.mygoods.Mfood -= int(inst3)
                        cash += (food * int(inst3))
                    else:
                        input("That is more food than you have.")
                elif inst2 == "oil" and myObjects.mygoods.Moil >= 1:
                    inst3 = input("How much oil: ")
                    if int(inst3) <= myObjects.mygoods.Moil:
                        myObjects.mygoods.Moil -= int(inst3)
                        cash += (oil * int(inst3))
                    else:
                        input("That is more oil than you have.")
                elif inst2 == "bsk" and myObjects.mystocks.Mbsk >= 1:
                    inst3 = input("How many stocks: ")
                    if int(inst3) <= myObjects.mystocks.Mbsk:
                        myObjects.mystocks.Mbsk -= int(inst3)
                        cash += (bsk * int(inst3))
                    else:
                        input("Those are more stocks than you have.")
                elif inst2 == "ntsk" and myObjects.mystocks.Mntsk >= 1:
                    inst3 = input("How many stocks: ")
                    if int(inst3) <= myObjects.mystocks.Mntsk:
                        myObjects.mystocks.Mntsk -= int(inst3)
                        cash += (ntsk * int(inst3))
                    else:
                        input("Those are more stocks than you have.")
                elif inst2 == "olsk" and myObjects.mystocks.Molsk >= 1:
                    inst3 = input("How many stocks: ")
                    if int(inst3) <= myObjects.mystocks.Molsk:
                        myObjects.mystocks.Molsk -= int(inst3)
                        cash += (olsk * int(inst3))
                    else:
                        input("Those are more stocks than you have.")
                else:
                    input("You dont have any of that.")
            except:
                pass
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
                input("Round passed...")
            except:
                pass
        elif inst == "quit":
            break
        else:
            print("That is an invalid Action.")
            del inst
            input()

ingame()
