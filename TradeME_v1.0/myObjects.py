#OBJECTS
import savefile

class mygoods:
    def __init__(self, Mgold, Msilver, Mfood, Moil):
        self.Mgold = savefile.Mgold
        self.Msilver = savefile.Msilver
        self.Mfood = savefile.Mfood
        self.Moil = savefile.Moil

class mystocks:
    def __init__(self, Mbsk, Mntsk, Molsk):
        self.Mbsk = savefile.Mbsk
        self.Mntsk = savefile.Mntsk
        self.Molsk = savefile.Molsk

class myassets:
    def __init__(self, homes):
        self.homes = 0