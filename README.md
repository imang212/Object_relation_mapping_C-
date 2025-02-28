## Objektově relační mapování, Entity framework
### Skript na instalaci databáze
Skript na instalaci a načtení databáze pokémonů. - Python, operace v cmd
### Operace s databází
Nejdřív si vytvoříme ve visual studiu projekt typu WPF (window presentation form).

Otevřeme NuGet Package Manager: Klikněte pravým tlačítkem na projekt v Solution Exploreru a vyberte Manage NuGet Packages.
Procházet: Přepněte na záložku Browse.
Vyhledejte Entity Framework: Zadejte Microsoft.EntityFrameworkCore do vyhledávacího pole.
Nainstalujte: Nainstalujte nejnovější verzi Microsoft.EntityFrameworkCore a Microsoft.EntityFrameworkCore.SqlServer.

1. Soubor/y, kde budou udělané modely tříd s názvy entit té databáze.. (Vytvoření modelové třídy)
2. Připojení k serveru DBMS, jakoby context třída, která dědí DbContext a je tam set těch dat z databáze. (uzivatel=postgre,heslo=admin)
3. Soubor, kde se budou dělat CRUD operace. Insert, Update, Delete, User, Query - C#
4. Můžou se povolit migrace pro změny v databázi pro CRUD operace (vytvoření databáze, atd...)

### Aplikační část
5. Nejaká služba, která nám bude vracet data z databáze array, atd. (to už bude součástí aplikace)
6. Aplikace s pokémony a možnost vyhledávání, prohlížení pokémonů v aplikaci.
