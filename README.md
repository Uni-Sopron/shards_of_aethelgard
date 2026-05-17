stateDiagram-v2
    [*] --> Főmenü : Program indítása
    
    Főmenü --> TörténetOlvasása : "Történet" gomb
    TörténetOlvasása --> Főmenü : "Vissza" gomb
    
    Főmenü --> PihenőFázis : "Új Játék" / "Betöltés"
    Főmenü --> [*] : "Kilépés" gomb
    
    state "Fő Játékmenet (Hub)" as Játékmenet {
        [*] --> PihenőFázis
        
        PihenőFázis --> HarcFázis : "Következő" gomb (80% esély)
        PihenőFázis --> RejtvényFázis : "Következő" gomb (20% esély)
        
        HarcFázis --> PihenőFázis : Ellenség életereje elfogy
        RejtvényFázis --> PihenőFázis : "Megoldás" beküldése
        
        PihenőFázis --> PihenőFázis : "Mentés" (Adatbázis frissül)
    }
    
    HarcFázis --> JátékVége : Játékos életereje elfogy
    JátékVége --> [*] : Ablak bezárása

Főmenüből történő kilépés:
Esemény: "Új játék" gomb megnyomása.
Feltétel: Név és Kaszt sikeresen kiválasztva.
Cél: Pihenő Fázis.
A Játékmenet Ciklusa (A Core Loop):
Esemény: "Következő" gomb megnyomása a Pihenő fázisban.
Feltétel: A háttérben futó véletlenszám-generátor eredménye (80% / 20%).
Cél: Harc Fázis VAGY Rejtvény Fázis.
Visszatérés a Pihenő Fázisba:
Esemény (Harcból): Támadás gomb megnyomása.
Feltétel: Az ellenség HP-ja kisebb vagy egyenlő mint 0.
Esemény (Rejtvényből): "Megoldás" gomb megnyomása.
Feltétel: A bemenet érvényes szám (formátum ellenőrzés sikeres).
Halál (Game Over):
Esemény: Az ellenség automatikus visszatámadása a kör végén.
Feltétel: A játékos HP-ja kisebb vagy egyenlő mint 0.
Cél: Játék Vége állapot (ahonnan csak új játék indításával vagy betöltéssel lehet folytatni).
