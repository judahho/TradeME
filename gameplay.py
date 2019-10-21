#imports
import random
import os
import savefile

def ingame():
    #player assets
    cash = savefile.cash
    Mgold = savefile.Mgold
    Msilver = savefile.Msilver
    Moil = savefile.Moil
    Mfood = savefile.Mfood
    Mbsk = savefile.Mbsk
    Mntsk = savefile.Mntsk
    Molsk = savefile.Molsk
    
    while True:
        #random price picks
        gold = random.randint(70, 300)
        silver = random.randint(60, 170)
        oil = random.randint(20, 30)
        food = random.randint(2, 12)
        bsk = random.randint(5, 8)
        ntsk = random.randint(1, 4)
        olsk = random.randint(5, 9)

        #new turn info
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
        print("  Silver:   " + str(Msilver) + "g")
        print("  Oil:      " + str(Moil) + "L")
        print("  Food:     " + str(Mfood) + "kg")
        print("  BSK:      " + str(Mbsk))
        print("  NTSK:     " + str(Mntsk))
        print("  OLSK:     " + str(Molsk))

        #actions
        inst = input("What would you like to do: ")
        if inst == "buy":
            try:
                inst2 = input("What would you like to buy: ")
                if inst2 == "gold":
                    inst3 = float(input("How many grams: "))
                    if (gold * int(inst3)) <= cash:
                        Mgold += int(inst3)
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
                        Msilver += int(inst3)
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
                        Mfood += int(inst3)
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
                        Moil += int(inst3)
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
                        Mbsk += int(inst3)
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
                        Mntsk += int(inst3)
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
                        Molsk += int(inst3)
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
                if inst2 == "gold" and Mgold >= 1:
                    inst3 = input("How much gold: ")
                    if int(inst3) <= Mgold:
                        Mgold -= int(inst3)
                        cash += (gold * int(inst3))
                    else:
                        input("That is more gold than you have.")
                elif inst2 == "silver" and Msilver >= 1:
                    inst3 = input("How much silver: ")
                    if int(inst3) <= Msilver:
                        Msilver -= int(inst3)
                        cash += (silver * int(inst3))
                    else:
                        input("That is more silver than you have.")
                elif inst2 == "food" and Mfood >= 1:
                    inst3 = input("How much food: ")
                    if int(inst3) <= Mfood:
                        Mfood -= int(inst3)
                        cash += (food * int(inst3))
                    else:
                        input("That is more food than you have.")
                elif inst2 == "oil" and Moil >= 1:
                    inst3 = input("How much oil: ")
                    if int(inst3) <= Moil:
                        Moil -= int(inst3)
                        cash += (oil * int(inst3))
                    else:
                        input("That is more oil than you have.")
                elif inst2 == "bsk" and Mbsk >= 1:
                    inst3 = input("How many stocks: ")
                    if int(inst3) <= Mbsk:
                        Mbsk -= int(inst3)
                        cash += (bsk * int(inst3))
                    else:
                        input("Those are more stocks than you have.")
                elif inst2 == "ntsk" and Mntsk >= 1:
                    inst3 = input("How many stocks: ")
                    if int(inst3) <= Mntsk:
                        Mntsk -= int(inst3)
                        cash += (ntsk * int(inst3))
                    else:
                        input("Those are more stocks than you have.")
                elif inst2 == "olsk" and Molsk >= 1:
                    inst3 = input("How many stocks: ")
                    if int(inst3) <= Molsk:
                        Molsk -= int(inst3)
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
