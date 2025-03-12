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

-- pokemon_move table
ALTER TABLE pokemon_move
ADD CONSTRAINT fk_pokemon_move_pokemon
FOREIGN KEY (pokemon) REFERENCES pokemon(id);

ALTER TABLE pokemon_move
ADD CONSTRAINT fk_pokemon_move_move
FOREIGN KEY (move) REFERENCES move(id) NOT VALID;

-- evolution_chain table
ALTER TABLE evolution_chain
ADD CONSTRAINT fk_evolution_chain_from
FOREIGN KEY ("""from""") REFERENCES pokemon(id);

ALTER TABLE evolution_chain
ADD CONSTRAINT fk_evolution_chain_to
FOREIGN KEY ("""to""") REFERENCES pokemon(id);

ALTER TABLE evolution_chain 
ALTER COLUMN trade_species TYPE INTEGER USING trade_species::INTEGER;

ALTER TABLE evolution_chain
ADD CONSTRAINT fk_evolution_chain_trade_species
FOREIGN KEY (trade_species) REFERENCES pokemon(id) NOT VALID;

ALTER TABLE evolution_chain 
ALTER COLUMN party_species TYPE INTEGER USING party_species::INTEGER;

ALTER TABLE evolution_chain
ADD CONSTRAINT fk_evolution_chain_party_species
FOREIGN KEY (party_species) REFERENCES pokemon(id) NOT VALID;

ALTER TABLE evolution_chain 
ALTER COLUMN known_move TYPE INTEGER USING known_move::INTEGER;

ALTER TABLE evolution_chain
ADD CONSTRAINT fk_evolution_chain_known_move
FOREIGN KEY (known_move) REFERENCES move(id) NOT VALID;

```

---

### Database Model:

![postgres - public](https://github.com/user-attachments/assets/5e480fbb-a9b4-448a-a6de-60d3647827e9)

The database consists of six tables: `Ability`, `Move`, `Pokemon`, `Pokemon_Move`, `Pokemon_Species`, and `Ability_Chain`. It contains 11 relationships between tables.

---
### Database Operations  
#### ORM Description  
![alt text](https://miro.medium.com/v2/resize:fit:4800/format:webp/1*vK7NzagpDws_lSJYeKV8Yw.png)  

Here is an example of how ORM works. The mapping logic within Entity Framework accesses the database while also communicating with memory, where individual objects are created.  

![alt text](https://www.tutorialspoint.com/entity_framework/images/conceptual_model.jpg)  

This image provides a more detailed description of what Entity Framework does and how it interacts with various components. It contains the conceptual model of the database, along with sub-operations such as querying, updating the database, or tracking changes. The conceptual model interacts with other operations, which in turn communicate with the application logic, and the application logic then interfaces with the user interface.

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

