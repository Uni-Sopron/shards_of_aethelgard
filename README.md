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
