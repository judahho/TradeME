#graphics library

def winRes(setting):
    if setting == 1:
        xRes = 1260
        yRes = 750
    elif setting == 2:
        xRes = 1920
        yRes = 1080
    else:
        xRes = 1260
        yRes = 750

    return xRes and yRes
    