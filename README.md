## Objektově relační mapování, Entity framework
![image](https://github.com/user-attachments/assets/d145dc37-47f0-41f3-b267-b19d5cf1391b)
### Skript na instalaci databáze
Skript na instalaci a načtení databáze pokémonů. - Python, operace v cmd

Otevřeme bat soubor script.bat, kde se spustí samostatně vytvořený python script v příkazoví řádce.
![image](https://github.com/user-attachments/assets/08bcaf06-604c-4c96-a7a3-9b784b91ab85)

Pokud nemáme nainstalovaný postgre, tak zadáme následující příkaz.
```
postgre install 
```
Nebo pokud máme nainstalovanou verzi postgresu 17.4, tak stačí, když nastavíme jenom cestu.
```
postgre path set (cesta do složky postgres) 
``` 
Spustíme server.
``` 
postgre start
```
Pokud nebude fungovat postgre start, tak zadejte tento příkaz na přeinstalaci a automatické spuštění db.
```
postgre database reinstall
``` 
![image](https://github.com/user-attachments/assets/badc3ccf-2e45-41aa-913f-9fac5e0231f4)
Stáhnou se rovnou databáze a spustí se i server.

V případě můžeme pro výpis možných příkazů.
```
postgre help
```
!Pozor! - pokud máme již vytvořený nějaký postgre server na port 5432, tak nepůjde spustit. To se dá vyřešit smazáním serveru nebo změnou portu.

Příkazový řádek se nesmí vypínat, jinak se vypne i server.

#### Model databáze.:

![database_model](https://github.com/user-attachments/assets/1687c886-5546-42ae-9f09-16571a06b1a7)
Databáze se skládá ze 6 tabulek. Ability, move, pokemon, pokemon_move, pokemon_species a ability_chain.

### Operace s databází
#### Popis ORM
![alt text](https://miro.medium.com/v2/resize:fit:4800/format:webp/1*vK7NzagpDws_lSJYeKV8Yw.png)

Zde je příklad toho, jak funguje ORM. Mapping logic, který obsahuje entity framework přistupuje k databázi a zároveň i komunikuje s pamětí, kde jsou vytvořeny jednotlivé objekty.


![alt text](https://www.tutorialspoint.com/entity_framework/images/conceptual_model.jpg)

V tomto obrázku je detainější popis toho, co vlastně dělá entity framework a s čím vším komunikuje. Nachází se v něm konceptuální model db a potom ještě podoperace jako jsou query, aktualizace do db nebo zaznamenávání změn v db. Konceptuální model s dalšími operacemi komunikuje s logikou aplikace a logika aplikace pak s uživatelskym rozhraním.

#### Vytvoření projektu ve visual studiu
Nejdřív si vytvoříme ve visual studiu projekt typu WPF (window presentation form).

Otevřeme NuGet Package Manager: Klikněte pravým tlačítkem na projekt v Solution Exploreru a vyberte Manage NuGet Packages.
Procházet: Přepněte na záložku Browse.

Otevřeme dotnet konzoli a nainstalujte potřebné balíčky nejnovější verze:
Nasměrujeme se do složky projektu a zadáme.:
```
cd C:\Users\imang\OneDrive\Dokumenty\GitHub\Object_relation_mapping_C-\ER_WPF\ER_WPF
```
Nejdřív.:
```
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
```
Potom.:
```
dotnet build
```

1. Soubor/y, kde budou udělané modely tříd s názvy entit té databáze.. (Vytvoření modelové třídy)

Pro vytvoření modelů modelů v dotnet konzoli můžem zadat.:
```
dotnet ef dbcontext scaffold "Host=localhost;Database=postgres;Username=postgres;Password=" Npgsql.EntityFrameworkCore.PostgreSQL -o Models -f
```
Databáze už by měla být načtená podle modelů.

2. Připojení k serveru DBMS, jakoby context třída, která dědí DbContext a je tam set těch dat z databáze. (nazev_sereveru=localhost,nazev_databaze=postgre,uzivatel=postgre,heslo="")

3. Vytvoření query souboru, kde se budou dělat CRUD operace. Insert, Update, Delete, User, Query - C#

Migrace se zde nemusí uskutečňovat, jelikož databáze už je předvytvořená pomocí python scriptu.

### Aplikační část
5. Nejaká služba, která nám bude vracet data z databáze array, atd. (to už bude součástí aplikace)
6. Aplikace s pokémony a možnost vyhledávání, prohlížení pokémonů v aplikaci.
