#runtime File holds the algorithyms for the main game: TradeME

#imports
from tkinter import *
import graphicsLib as GUI
import config

#variables
"""
turnCount = SF.turn
pCash = SF.pCash
"""
#xRes, yRes = GUI.winRes(config.windowRes)

win = Tk() #window gen
root = Frame(win, width=200, height=200)

#runtime
def help(event):
    pass
def options(event):
    pass
def gameplay(event):
    pass
def menu():
    #functions
    def load(event):
        pass

    #GUI
    home = root
    #buttons
    button_1 = Button(home, text="New Game", command=gameplay)
    button_1.bind("<Button-1>", gameplay)
    button_2 = Button(home, text="Load Game", command=load)
    button_2.bind("<Button-1>", load)
    button_3 = Button(home, text="Options", command=options)
    button_3.bind("<Button-1>", options)
    button_4 = Button(home, text="Help", command=help)
    button_4.bind("<Button-1>", help)
    #packing
    button_1.pack()
    button_2.pack()
    button_3.pack()
    button_4.pack()

    win.mainloop()



menu()
