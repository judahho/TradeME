#runtime file

#imports
import random

import classes as CL
import savefile as SF
import savegame

#variables
pCash = CL.forex("Cash", 1, 0)
turn = 1

#functions
def newGame():
    pass
    #pCash = CL.forex("Cash", 1, 0)
    #turn = 1

#runtime
def gameplay():
    while True:
        input("Press 'Enter' to start turn" + turn + "\n")
        print(pCash)

gameplay()

input("\nComplete...\n")