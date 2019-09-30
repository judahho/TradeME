#runtime File holds the algorithyms for the main game: TradeME

#imports
import stockExchang as SE
import forex as FX
import goods as GD
import logs
import config
import savefile as SF
import savegame
import saveconfig

#variables
turnCount = SF.turn
playing = True
pCash = SF.pCash

#functions
def HELP():
    #info
    print("Sorry, no info yet.")
    #end function
    input()
    return

#runtime
while playing == True:
    input("Press 'Enter' to start turn" + turnCount + "\n")
    def gameplay():
        return
    turnCount += 1
