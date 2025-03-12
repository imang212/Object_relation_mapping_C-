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
3. **Open NuGet Package Manager:**
   - Right-click the project in **Solution Explorer** and select **Manage NuGet Packages**.
   - **Browse:** Switch to the **Browse** tab.
   - Open the .NET console and install the latest package versions.

4. **Creating Model Classes:**
   Models can also be generated automatically using the `Microsoft.EntityFrameworkCore.Models` package in the .NET terminal, but here, we create them manually for better clarity.

   Since the tables are already created in the database, the models should match the existing database structure. Ensure that the defined `DbSet<>` names match the table names in the database.

   Example model classes:

   `ability.cs`
   ```C#
   using System.ComponentModel.DataAnnotations;

   namespace ER_WPF.Models;

   public partial class ability
   {
       [Key]
       public int id { get; set; }
       public string? name { get; set; }
       public string? effect { get; set; }
       public string? short_effect { get; set; }
       public string? description { get; set; }
       public int? generation { get; set; }
   }
   move.cs

C#
using System.ComponentModel.DataAnnotations;

namespace ER_WPF.Models;

public partial class move
{
    [Key]
    public int id { get; set; }
    public string? name { get; set; }
    public int? accuracy { get; set; }
    public string? damage_class { get; set; }
    public int? effect_chance { get; set; }
    public int? generation { get; set; }
    public string? ailment { get; set; }
    public int? ailment_chance { get; set; }
    public int? crit_rate { get; set; }
    public int? drain { get; set; }
    public int? flinch_chance { get; set; }
    public int? healing { get; set; }
    public int? max_hits { get; set; }
    public int? min_turns { get; set; }
    public int? stat_chance { get; set; }
    public int? power { get; set; }
    public int? pp { get; set; }
    public int? priority { get; set; }
    public string? target { get; set; }
    public string? type { get; set; }
    public string? description { get; set; }
}

pokemon.cs
C#
using System.ComponentModel.DataAnnotations;

namespace ER_WPF.Models;

public partial class pokemon
{
    [Key]
    public int? id { get; set; }
    public int? base_experience { get; set; }
    public int? height { get; set; }
    public int? weight { get; set; }
    public int? order { get; set; }
    public int? primary_ability { get; set; }
    public int? secondary_ability { get; set; }
    public int? hidden_ability { get; set; }
    public int? species { get; set; }
    public int? hp { get; set; }
    public int? hp_effort { get; set; }
    public int? attack { get; set; }
    public int? attack_effort { get; set; }
    public int? defense { get; set; }
    public int? defense_effort { get; set; }
    public int? special_attack { get; set; }
    public int? special_attack_effort { get; set; }
    public int? special_defense { get; set; }
    public int? special_defense_effort { get; set; }
    public int? speed { get; set; }
    public int? speed_effort { get; set; }
    public string? sprite_front_default { get; set; }
    public string? sprite_front_female { get; set; }
    public string? sprite_front_shiny_female { get; set; }
    public string? sprite_front_shiny { get; set; }
    public string? sprite_back_default { get; set; }
    public string? sprite_back_female { get; set; }
    public string? sprite_back_shiny_female { get; set; }
    public string? sprite_back_shiny { get; set; }
    public string? cry { get; set; }
    public string? cry_legacy { get; set; }
    public string? name { get; set; }
    public string? primary_type { get; set; }
    public string? secondary_type { get; set; }
}


pokemon_species.cs
C#
using System.ComponentModel.DataAnnotations;

namespace ER_WPF.Models
{
    class pokemon_species
    {
        [Key]
        public int? id { get; set; }
        public int? base_happiness { get; set; }
        public int? capture_rate { get; set; }
        public int? gender_rate { get; set; }
        public int? hatch_counter { get; set; }
        public int? order { get; set; }
        public int? generation { get; set; }
        public int? national_pokedex_number { get; set; }
        public bool? is_baby { get; set; }
        public bool? is_legendary { get; set; }
        public bool? is_mythical { get; set; }
        public string? color { get; set; }
        public string? growth_rate { get; set; }
        public string? habitat { get; set; }
        public string? shape { get; set; }
        public string? genera { get; set; }
        public string? name { get; set; }
        public string? egg_group { get; set; }
        public string? varieties { get; set; }
        public string? description { get; set; }

    }
}


pokemon_move.cs
C#
using System.ComponentModel.DataAnnotations;

namespace ER_WPF.Models
{
    class pokemon_move
    {
        [Key]
        public int? pokemon { get; set; }
        public int? move { get; set; }
        public int? level_learned_at { get; set; }
        public string? learn_method { get; set; }
    }
}


evolution_chain.cs
C#
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ER_WPF.Models
{
    class evolution_chain
    {
        [Key]
        public int id { get; set; }
        [Column("\"from\"")]
        public int? from { get; set; }
        [Column("\"to\"")]
        public int? to { get; set; }
        public int? gender { get; set; }
        public int? min_beauty { get; set; }
        public int? min_happiness { get; set; }
        public int? min_level { get; set; }
        public string? trade_species { get; set; }
        public int? relative_physical_stats { get; set; }
        public string? item { get; set; }
        public string? held_item { get; set; }
        public string? known_move { get; set; }
        public string? known_move_type { get; set; }
        public string? trigger { get; set; }
        public string? party_species { get; set; }
        public string? party_type { get; set; }
        public string? time_of_day { get; set; }
        public bool? needs_overworld_rain { get; set; }
        public bool? turn_upside_down { get; set; }

    }}
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

