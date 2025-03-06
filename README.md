## Objektově relační mapování, Entity framework
### Skript na instalaci databáze
Skript na instalaci a načtení databáze pokémonů. - Python, operace v cmd

Otevřeme bat soubor script.bat, kde se spustí python script v příkazoví řádce.
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
!Pozor! - pokud máme již vytvořený nějaký postgre server na port 5432, tak nepůjde spustit. To se dá vyřešit smazáním serveru nebo změnou portu.

Příkazový řádek se nesmí vypínat, jinak se vypne i server.
### Operace s databází
Nejdřív si vytvoříme ve visual studiu projekt typu WPF (window presentation form).

![alt text](https://miro.medium.com/v2/resize:fit:4800/format:webp/1*vK7NzagpDws_lSJYeKV8Yw.png)
![alt text](https://www.tutorialspoint.com/entity_framework/images/conceptual_model.jpg)

Otevřeme NuGet Package Manager: Klikněte pravým tlačítkem na projekt v Solution Exploreru a vyberte Manage NuGet Packages.
Procházet: Přepněte na záložku Browse.
Vyhledejte Entity Framework: Zadejte Microsoft.EntityFrameworkCore do vyhledávacího pole.
Nainstalujte potřebné balíčky nejnovější verze:
```
Install-Package Microsoft.EntityFrameworkCore 
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
```
1. Soubor/y, kde budou udělané modely tříd s názvy entit té databáze.. (Vytvoření modelové třídy)
2. Připojení k serveru DBMS, jakoby context třída, která dědí DbContext a je tam set těch dat z databáze. (uzivatel=postgre,heslo=admin)
3. Soubor, kde se budou dělat CRUD operace. Insert, Update, Delete, User, Query - C#
4. Můžou se povolit migrace pro změny v databázi pro CRUD operace (vytvoření databáze, atd...)

### Aplikační část
5. Nejaká služba, která nám bude vracet data z databáze array, atd. (to už bude součástí aplikace)
6. Aplikace s pokémony a možnost vyhledávání, prohlížení pokémonů v aplikaci.
