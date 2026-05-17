
```mermaid
sequenceDiagram
    autonumber
    actor Felhasználó
    participant Form as HarcForm (Nézet)
    participant GM as GameManager (Vezérlő)
    participant Player as Player (Modell)
    participant Enemy as Enemy (Modell)

    Felhasználó->>Form: Kattintás a "Támadás" gombon
    activate Form
    
    Form->>GM: PlayCombatRound()
    activate GM
    
    %% Játékos támadása
    GM->>Player: AutoAttack(TestEnemy)
    activate Player
    Player->>Enemy: Health -= Sebzés
    Player-->>GM: Játékos sebzésnapló (string)
    deactivate Player

    %% Ellenőrzés, hogy a szörny meghalt-e
    alt Ellenség HP <= 0 (Meghalt)
        GM->>Player: GainXP(Tapasztalati pont)
        GM-->>Form: Győzelmi napló (string)
    else Ellenség túlélte
        %% Ellenség visszatámad
        GM->>Enemy: AutoAttack(CurrentPlayer)
        activate Enemy
        Enemy->>Player: Health -= Sebzés
        Enemy-->>GM: Ellentámadás napló (string)
        deactivate Enemy
        GM-->>Form: Teljes harci napló (string)
    end
    deactivate GM

    %% Felület frissítése
    Form->>Form: rtbLog.Text bővítése a naplóval
    Form->>Form: UpdateStatus() (HP és Mana UI frissítése)
    
    %% UI gombok állapotának kezelése a kör végén
    alt Ellenség IsDead() == true
        Form->>Form: Támadás letiltása, "Következő" aktív
    else Player IsDead() == true
        Form->>Form: Támadás letiltása, Game Over kiírása
    end
    
    deactivate Form```

