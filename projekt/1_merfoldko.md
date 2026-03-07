1. Megvalósíthatósági elemzés (Feasibility Study)

Humán erőforrások: egy tervező/fejlesztő (kb. 30 óra), egy tesztelő (5 óra)
Hardver erőforrások: egy fejlesztői és egy tesztelői számítógép (közepes hardverigény)
Szoftver erőforrások: fejlesztőkörnyezet (Visual Studio), verziókövető (Github)
Üzemeltetés: a telepítést/átadást követően további üzemeltetést nem kell biztosítani
Karbantartás: felhasználói visszajelzések alapján fejlesztés
Megvalósítás időtartama: várhatóan 35 emberóra

2. Követelmény feltárás és elemzés

Funkcionális követelmények

Játékot megelőzően:

    új játék indítása a játékos nevének és kasztjának megadásával

    korábbi játékállás betöltése vagy kilépés az alkalmazásból

Játék közben:

    az aktuális karakteradatok (HP, XP, szint) és a küldetés állapotának megjelenítése

    harc esetén a támadási mód kiválasztása, vagy automatikus harc indítása

    fejtörő esetén numerikus válasz megadása

    a játék (vagy a harc) végének felismerése, XP jóváírása és esetleges szintlépés kezelése

Nem funkcionális követelmények

Termék követelmények:

    Hatékonyság: jelentéktelen terhelés a processzor és a memória részére, hálózatot nem igényel. Gyors (1 másodperc alatti) válaszidő minden bevitelre

    Megbízhatóság: szabványos használat esetén nem fordul elő hibajelenség. Hibás emberi bevitel (pl. betűk megadása a fejtörőnél) esetén a program hibaüzenetet ad, és a bevitel megismétlését kéri az összeomlás helyett

    Hordozhatóság: a legtöbb személyi számítógépen biztosított a használat

    Felhasználhatóság: intuitív felhasználói felület, a funkciók használata külön segédlet vagy leírás nélkül is elsajátítható

Menedzselési követelmények:

    Környezeti: nem működik együtt semmilyen külső szoftverrel vagy szolgáltatással, az adatokat lokális adatbázisban tárolja

    Fejlesztési: objektumorientált paradigma alkalmazása, megfelelő fejlesztőkörnyezet használatával

3. Felhasználói történetek

AS A, játékos
I WANT TO, támadási módot választani a harc során
SO THAT, legyőzzem az ellenfelet és XP-t szerezzek
GIVEN, én következem a harci körben
WHEN, rákattintok a ""Támadás 1/2"" támadási gombra
THEN, a program kiszámítja a sebzést, levonja az ellenfél életerejéből, és az ellenfél következik

AS A,játékos
I WANT TO, megadni a választ a rúna-fejtörőre
SO THAT, kinyíljon a kapu és folytathassam a küldetést

1. GIVEN, a fejtörő képernyőn vagyok, és a válasz beviteli mező aktív
   WHEN, helyesen beírom a pontos számértéket
   THEN, a rendszer maximális XP-vel jutalmaz, és a következő küldetésre lép
2. GIVEN, a fejtörő képernyőn vagyok, és a válasz beviteli mező aktív
   WHEN, számok helyett véletlenszerű betűket vagy speciális karaktereket írok be
   THEN, a program hibaüzenetet ad (""Csak számot adhatsz meg!""), és újra bekéri az értéket anélkül, hogy hibás válaszként értékelné a próbálkozást
3. GIVEN, a fejtörő képernyőn vagyok, és a válasz beviteli mező aktív
   WHEN, 5%-os hibahatáron belül válaszolok,
   THEN, a rendszer a pontos választól való eltéréstől függően ad XP-t, és a következő küldetésre lép
