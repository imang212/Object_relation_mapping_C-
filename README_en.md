## Object-Relational Mapping, Entity Framework
![image](https://github.com/user-attachments/assets/918339ab-c143-4f31-b718-c8f21b5ddb94)

### Requirements
- Windows OS with PostgreSQL 17.4 installed
- Visual Studio with .NET support
- .NET 9.0
- Python 3.11+ (for the database installation script)
- pgAdmin 4

### Database Installation Script
A script using ORM in Python to create a PostgreSQL database.

1. Run the Pokémon database installation script using `script.bat`, which executes a Python script in the command line to initialize, create, install, and start the database.  
   ![image](https://github.com/user-attachments/assets/08bcaf06-604c-4c96-a7a3-9b784b91ab85)

2. If PostgreSQL is not installed, use the following command:
   ```
   postgre install 
   ```
   ![image](https://github.com/user-attachments/assets/8e8c917b-a4b3-4a4e-be3b-77618d5b2ff9)

   Or, if you have PostgreSQL version 17.4 installed, set the path to the existing installation:
   ```
   postgre path set <path to PostgreSQL> 
   ``` 
3. Start the database server:
   ``` 
   postgre start
   ```
   ![image](https://github.com/user-attachments/assets/f097fa33-2c87-4ace-87f1-c8ce78e50d34)

4. If issues occur when running `postgre start`, try reinstalling:
   ```
   postgre database reinstall
   ``` 
   ![image](https://github.com/user-attachments/assets/badc3ccf-2e45-41aa-913f-9fac5e0231f4)

   This will automatically download the databases and start the server.

To display available commands:
   ```
   postgre help
   ```

⚠ **Warning!** - If another PostgreSQL server is already running on port 5432, this one will not start. You need to change the port or remove the existing server.  
The command line must remain open, or the server will shut down.

---

### Creating Foreign Keys in the Database
Connect to the PostgreSQL database and execute the following SQL commands:
```SQL
-- pokemon table
ALTER TABLE pokemon
ADD CONSTRAINT fk_pokemon_species
FOREIGN KEY (species) REFERENCES pokemon_species(id);

ALTER TABLE pokemon
ADD CONSTRAINT fk_pokemon_primary_ability
FOREIGN KEY (primary_ability) REFERENCES ability(id) NOT VALID;

ALTER TABLE pokemon
ADD CONSTRAINT fk_pokemon_secondary_ability
FOREIGN KEY (secondary_ability) REFERENCES ability(id) NOT VALID;

ALTER TABLE pokemon
ADD CONSTRAINT fk_pokemon_hidden_ability
FOREIGN KEY (hidden_ability) REFERENCES ability(id) NOT VALID;
```

---

### Database Model:

![postgres - public](https://github.com/user-attachments/assets/5e480fbb-a9b4-448a-a6de-60d3647827e9)

The database consists of six tables: `Ability`, `Move`, `Pokemon`, `Pokemon_Move`, `Pokemon_Species`, and `Ability_Chain`. It contains 11 relationships between tables.

---

### Creating a Project in Visual Studio
1. Create a new WPF project (Windows Presentation Foundation) in Visual Studio.
2. Install the required packages using the .NET console:
   ```
   Install-Package Microsoft.EntityFrameworkCore
   Install-Package Microsoft.EntityFrameworkCore.SqlServer
   Install-Package Microsoft.EntityFrameworkCore.Tools
   Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
   ```

---

### Connecting to the Database
Create a new folder `Data` in your project and add a context class `PokemonDataContext.cs`, which manages database communication.

`PokemonDataContext.cs`
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

---

### Application Section
**Bonus task** for fast learners.

Create a Pokémon application with search functionality.

**Tasks:**
- Use a method to find a Pokémon by ID and display its name and image in the application.
- Implement filtering methods to work within the database search.

---

To build the project:
```
dotnet build
```

To run the project after a successful build:
```
dotnet run

