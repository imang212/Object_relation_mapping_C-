## Objektově relační mapován, Entity framework
### Skript na instalaci databáze
Skript na instalaci a načtení databáze pokémonů. - Python, operace v cmd
### Operace s databází
Insert, Update, Delete, User, Query - C#
1. Soubor/y, kde budou udělané modely tříd s názvy entit té databáze..
2. Připojení k serveru DBMS, jakoby context třída, která dědí DbContext a je tam set těch dat z databáze. 
3. Soubor, kde se budou dělat CRUD operace.
4. Můžou se povolit migrace pro změny v databázi pro CRUD operace (vytvoření databáze, atd...)

### Aplikační část
5. Nejaká služba, která nám bude vracet data z databáze array, atd. (to už bude součástí aplikace)
