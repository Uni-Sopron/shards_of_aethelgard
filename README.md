```mermaid
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
    JátékVége --> [*] : Ablak bezárása```

Főmenüből történő kilépés:\n
Esemény: "Új játék" gomb megnyomása.\n
Feltétel: Név és Kaszt sikeresen kiválasztva.\n
Cél: Pihenő Fázis.\n
A Játékmenet Ciklusa (A Core Loop):\n
Esemény: "Következő" gomb megnyomása a Pihenő fázisban.\n
Feltétel: A háttérben futó véletlenszám-generátor eredménye (80% / 20%).\n
Cél: Harc Fázis VAGY Rejtvény Fázis.\n
Visszatérés a Pihenő Fázisba:\n
Esemény (Harcból): Támadás gomb megnyomása.\n
Feltétel: Az ellenség HP-ja kisebb vagy egyenlő mint 0.\n
Esemény (Rejtvényből): "Megoldás" gomb megnyomása.\n
Feltétel: A bemenet érvényes szám (formátum ellenőrzés sikeres).\n
Halál (Game Over):\n
Esemény: Az ellenség automatikus visszatámadása a kör végén.\n
Feltétel: A játékos HP-ja kisebb vagy egyenlő mint 0.\n
Cél: Játék Vége állapot (ahonnan csak új játék indításával vagy betöltéssel lehet folytatni).
