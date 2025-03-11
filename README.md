## Objektově relační mapování, Entity framework
![image](https://github.com/user-attachments/assets/d145dc37-47f0-41f3-b267-b19d5cf1391b)
### Požadavky
- windows OS s nainstalovaným PostgreSQL 17.4
- Visual Studio s podporou .NET
- .NET 9.0
- Python 3.11+ (pro skript instalace databáze)
  
### Skript na instalaci databáze
Script používající ORM v pythonu pro vytvoření databáze PostgreSQL.

1. Spustíme instalační skript databáze Pokémonů pomocí script.bat, kde se spustí python script v příkazoví řádce pro inicializaci, vytvoření, instalaci a špustění databáze. 
![image](https://github.com/user-attachments/assets/08bcaf06-604c-4c96-a7a3-9b784b91ab85)

2. Pokud není PostgreSQL nainstalováno, tak použijte následující příkaz.
```
postgre install 
```
Nebo pokud máme nainstalovanou verzi postgresu 17.4, nastavte cestu k existující instalaci.
```
postgre path set <cesta k postgre> 
``` 
3. Spusťte databázový server.
``` 
postgre start
```
![image](https://github.com/user-attachments/assets/f097fa33-2c87-4ace-87f1-c8ce78e50d34)

4. Pokud nastanou problémy u postgre start, zkuste přeinstalaci.
```
postgre database reinstall
``` 
![image](https://github.com/user-attachments/assets/badc3ccf-2e45-41aa-913f-9fac5e0231f4)
Stáhnou se rovnou databáze a spustí se i server.

V případě můžeme pro výpis možných příkazů.
```
postgre help
```
!Pozor! - Pokud již běží jiný PostgreSQL server na portu 5432, tak nepůjde spustit. Je třeba změnit port nebo smazat server.
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
1. Vytvořte nový WPF projekt (Windows Presentation Foundation) ve visual studiu, který bude fungovat pomocí dotnet 9.0.
2. Nainstalujte potřebné balíčky
Pomocí dotnet konzole.:
```
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
```
Otevřeme NuGet Package Manager: 

Klikněte pravým tlačítkem na projekt v Solution Exploreru a vyberte Manage NuGet Packages.
Procházet: Přepněte na záložku Browse.
Otevřeme dotnet konzoli a nainstalujte potřebné balíčky nejnovější verze:

3. Vytvoření modelových tříd.:
Nasměrujeme se do složky projektu.
```
cd C:\Users\imang\OneDrive\Dokumenty\GitHub\Object_relation_mapping_C-\ER_WPF\ER_WPF
```
Vytvoříme modelové třídy podle databáze.:
```
dotnet ef dbcontext scaffold "Host=localhost;Database=postgres;Username=postgres;Password=" Npgsql.EntityFrameworkCore.PostgreSQL -o Models -f
```
Databáze už by měla být načtená podle modelů.
Modely se mohou k existujícím tabulkám v vytvořit ručně, jé nutné se ujistit, aby se nám shodovali názvy definovaných DbSetů s názvy tabulek v db. 

4. Připojení k databázi
 
Vytvořte kontextovou třídu PokemonDataKontext.cs, která se stará o komunikaci s databází.
```C#
using Microsoft.EntityFrameworkCore;
using ER_WPF.Models;

namespace ER_WPF.Data
{
    class PokemonDataContext : DbContext
    {
        public DbSet<ability> ability { get; set; }
        public DbSet<move> move { get; set; }
        public DbSet<pokemon> pokemon { get; set; }
        public DbSet<pokemon_species> pokemon_species { get; set; }
        public DbSet<pokemon_move> pokemon_move { get; set; }
        public DbSet<evolution_chain> evolution_chain { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=");
        }
    }
}

```

5. Vytvoření query souboru. Entity Frameworku, kde se budou provádět CRUD operace na databázi přímo pomocí objektů v C#. 

Migrace se zde nemusí uskutečňovat, jelikož databáze už je předvytvořená pomocí python scriptu. Například pokud změním nebo vytvořím modely tříd, tak se vytvoří nový soubor s SQL změnami a vytvoří tabulky v db, které odpovídají určitým modelům tříd. Zmiňuji to, protože je to také běžná součást EF.

6. Po úspěšném sestavení (dotnet build)
```
dotnet build
dotnet run
```

### Aplikační část
Nejaká služba, která nám bude vracet data z databáze array, atd. 
- Najděte Pokémona podle ID a vypište jeho jméno do konzole.
- Upravte existujícího Pokémona a změnu uložte do databáze.
- Odstraňte Pokémona z databáze a zobrazte potvrzení o odstranění.

Aplikace s pokémony a možnost vyhledávání, prohlížení pokémonů v aplikaci.
Úkoly:
- Najděte Pokémona podle ID a vypište jeho jméno v aplikaci.
