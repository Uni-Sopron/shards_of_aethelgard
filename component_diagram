## Komponens diagram: A szoftver fizikai architektúrája

Az alábbi komponens diagram a játék fizikai felépítését és a technológiai rétegek közötti kapcsolatot ábrázolja, bemutatva a Windows Forms felületek, a GameManager vezérlő, az Entity Framework Core és az SQLite adatbázis együttműködését.

```mermaid
graph TD
    subgraph Felhasználói Felület (Presentation Layer)
        MF[MenuForm.cs<br/>Főmenü]
        HF[HarcForm.cs<br/>Harctér és Hub]
        PF[PuzzleForm.cs<br/>Rejtvény ablak]
        SF[StoryForm.cs<br/>Történet popup]
    end

    subgraph Alkalmazás Logika (Business Logic Layer)
        GM[GameManager.cs<br/>Központi Vezérlő]
    end

    subgraph Adatmodell és Perzisztencia (Data Layer)
        Models[Modellek osztályai<br/>Character, Player, Enemy, Puzzle]
        EF[AppDbContext.cs<br/>EF Core Context]
    end

    subgraph Infrastruktúra és Tárolás (Storage)
        DB[(SQLite Adatbázis<br/>aethelgard_game.db)]
    end

    %% Interakciók és függőségek
    MF -->|Inicializál és indít| GM
    HF -->|Harci kör / fázisváltás| GM
    PF -->|Válasz kiértékelés| GM
    
    GM -->|Menedzseli és frissíti| Models
    GM -->|Mentési parancsot ad| EF
    
    EF -->|Mentés / Betöltés / ORM| DB
