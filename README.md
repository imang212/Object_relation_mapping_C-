## Objektově relační mapování, Entity framework
![image](https://github.com/user-attachments/assets/918339ab-c143-4f31-b718-c8f21b5ddb94)

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
![image](https://github.com/user-attachments/assets/8e8c917b-a4b3-4a4e-be3b-77618d5b2ff9)

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
1. Vytvořte nový WPF projekt (Windows Presentation Foundation) ve visual studiu.
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

Modely se dají i vytvořit automaticky pomocí balíčku Microsoft.EntityFrameworkCore.Models v dotnet terminálu, ale my je vytvoříme ručně pro lepší přehlednost.

Tabulky už jsou v databázi vytvořené. Modely se mohou k existujícím tabulkám v vytvořit ručně, kdy vytvoříme složku Models a v ní namodelujeme třídy jednotlivých tabulek, ale nutné se ujistit, aby se nám shodovali názvy definovaných DbSetů s názvy tabulek v db.

ability.cs
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

```
move.cs

```C#
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
```
pokemon.cs
```C#
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
```

pokemon_species.cs
```C#
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
```

pokemon_move.cs
```C#
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
```

evolution_chain.cs
```C#
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

    }
}
```
4. Připojení k databázi
 
V projektu vytvořte novou složku Data a v ní vytvořte kontextovou třídu PokemonDataContext.cs, která se stará o komunikaci s databází.

PokemonDataContext.cs
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
Migrace se zde nemusí uskutečňovat, jelikož databáze už je předvytvořená pomocí python scriptu. Například pokud změním nebo vytvořím modely tříd, tak se vytvoří nový soubor s SQL změnami a vytvoří tabulky v db, které odpovídají určitým modelům tříd. Zmiňuji to, protože je to také běžná součást EF.


5. Vytvořte složku s názvem Query a v ní query soubor. Entity Frameworku, kde se budou provádět CRUD operace na databázi přímo pomocí objektů v C#.

PokemonBriefDetails.cs
```C#
using ER_WPF.Data;
using ER_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Swift;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ER_WPF.Query
{
    class PokemonBriefDetails
    {
        private Models.pokemon pokemon;
        private string spriteUrl;
        private BitmapImage sprite;
        private string type1;
        private string type2;

        public Models.pokemon Pokemon { get => pokemon; }
        public BitmapImage Sprite { get => sprite; }
        public string Type1 { get => type1; }
        public string Type2 { get => type2; }

        private PokemonDataContext _context;

        public PokemonBriefDetails(PokemonDataContext _context, Models.pokemon pokemon)
        { 
            this._context = _context;
            this.pokemon = pokemon;
            this.type1 = pokemon.primary_type;
            this.type2 = pokemon.secondary_type;
            this.spriteUrl = spriteUrl;
            this.sprite = loadImage(this.spriteUrl);
        }

        private BitmapImage loadImage(string url)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(url);
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();

            return bitmapImage;
        }
    }
}
```

PokemonFullDetails.cs
```C#
using ER_WPF.Data;
using ER_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ER_WPF.Query
{
    class PokemonFullDetails
    {
        private Models.pokemon pokemon;
        private List<Models.move> moves;
        private Models.pokemon_species species;
        private EvolutionTreeNode evolutionTree;
        private List<Models.ability> abilities;
        private string spriteUrl;
        private BitmapImage sprite;

        Models.pokemon Pokemon { get => this.pokemon; }
        public List<Models.move> Moves { get => this.moves; }
        public Models.pokemon_species Species { get => this.species; }
        public EvolutionTreeNode EvolutionTree { get => this.evolutionTree; }
        public List<Models.ability> Abilities { get => this.abilities; }
        public BitmapImage Sprite { get => sprite; }

        private PokemonDataContext _context;
        public PokemonFullDetails(PokemonDataContext _context, int? id) {
            this._context = _context;
            Update(id);
        }

        void Update(int? id)
        {
            this.pokemon = this._context.pokemon.FirstOrDefault(p => p.id == id);
            if (this.pokemon == null)
            {
                this.moves = null;
                this.species = null;
                this.evolutionTree = null;
                this.abilities = null;
                return;
            }

            this.moves = this._context.move.Where(m => _context.pokemon_move.Any(pm => pm.pokemon == id)).ToList();
            this.species = this._context.pokemon_species.FirstOrDefault(s => s.id == this.Pokemon.species);
            this.evolutionTree = EvolutionTreeNode.Create(this._context, this.Pokemon);
            this.abilities = this._context.ability.Where(
                a => a.id == this.Pokemon.primary_ability ||
                a.id == this.Pokemon.secondary_ability ||
                a.id == this.Pokemon.hidden_ability
            ).ToList();

            this.spriteUrl = spriteUrl;
            this.sprite = loadImage(this.spriteUrl);
        }

        private BitmapImage loadImage(string url)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(url);
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();

            return bitmapImage;
        }

        public class EvolutionTreeNode
        {
            public readonly List<EvolutionTreeNode> children;
            public readonly Models.pokemon pokemon;
            public readonly Models.evolution_chain evolutionChain;

            private EvolutionTreeNode(Models.pokemon pokemon, Models.evolution_chain evolutionChain) {
                children = new List<EvolutionTreeNode>();
                pokemon = pokemon;
                this.evolutionChain = evolutionChain;
            }

            public static EvolutionTreeNode Create(PokemonDataContext _context, Models.pokemon pkmn)
            {
                if (pkmn == null) return null;
                EvolutionTreeNode node = new EvolutionTreeNode(pkmn, null);
                List<Models.pokemon> pokemon = _context.pokemon.Where(p =>
                    _context.evolution_chain.Where(ec => ec.from == pkmn.id).Any(ec => ec.to == p.id)
                ).ToList();
                foreach (Models.pokemon p in pokemon)
                {
                    node.children.Add(EvolutionTreeNode.Create(_context, p));
                }
                return node;
            }
        }
    }
}
```

Úkol: 
Vytvořte si soubor SearchQueryEngine.cs, který bude sloužit pro filtrování pokémonů na základě různých vlastností. Používá Entity Framework k provádění dotazů na databázi pokémonů.

- Bude obsahovat parametry pro vyhledávání Pokémonů – název, typy, schopnosti, statistiky (HP, útok, obrana...), generaci, legendární status, vzhled (barva, tvar, výška, váha) a pohyby.

Řetězce - name, type1, type2, knowsmove, ability, appearance_color, appearance_shape;

Integery - generation, appearance_height_min, appearance_height_max, appearance_weight_min, appearance_weight_max;

Integery ukazující max a min statistiky - _stat_hp_min, _stat_attack_min, _stat_defense_min, _stat_spatt_min, _stat_spdef_min, _stat_speed_min, _stat_hp_max, _stat_attack_max, _stat_defense_max, _stat_spatt_max, _stat_spdef_max, _stat_speed_max;

Legendary status -  LegendaryStatuses _legendarystatus; V tom budou možnosti (None, Legendary a Mythical)

- Každá změna parametru spustí metodu UpdateQuery(), která aktualizuje výsledky vyhledávání.

- Používá IQueryable<T> k efektivnímu filtrování – dotazy se staví dynamicky podle zadaných filtrů.

- Po každé změně se aktualizuje pokemonResults – obsahuje seznam Pokémonů splňujících podmínky.

SearchQueryEngine.cs
```C#
using Vyhledavac_pokemonu.Data;

namespace Vyhledavac_pokemonu.Query
{
    class SearchQueryEngine
    {
        public enum LegendaryStatuses
        {
            None, Legendary, Mythical
        }
        private string? _name, _type1, _type2, _knowsmove, _ability, _appearance_color, _appearance_shape;
        private int? _generation, _appearance_height_min, _appearance_height_max, _appearance_weight_min, _appearance_weight_max;
        private int? _stat_hp_min, _stat_attack_min, _stat_defense_min, _stat_spatt_min, _stat_spdef_min, _stat_speed_min;
        private int? _stat_hp_max, _stat_attack_max, _stat_defense_max, _stat_spatt_max, _stat_spdef_max, _stat_speed_max;
        private LegendaryStatuses? _legendarystatus;

        private PokemonDataContext _context;
        private List<Models.pokemon> pokemonResults;

        public SearchQueryEngine(PokemonDataContext _context)
        {
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
            this.pokemonResults = new List<Models.pokemon>();
            this.UpdateQuery();
        }
        public List<Models.pokemon> Results
        {
            get
            {
                return this.pokemonResults;
            }
        }
        public List<Models.pokemon> GetAllPokemons()
        {
            return _context.pokemon.ToList();
        }

        public string? Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    UpdateQuery();
                }
            }
        }
        //úkol - stejně dodělat pro ostatní názvy v tabulce
        public string? Type1
        {
            get => _type1;
            set
            {
                if (_type1 != value)
                {
                    _type1 = value;
                    UpdateQuery();
                }
            }
        }
        public string? Type2
        {
            get => _type2;
            set
            {
                if (_type2 != value)
                {
                    _type2 = value;
                    UpdateQuery();
                }
            }
        }
        
       
        public string? Ability
        {
            get => _ability;
            set
            {
                if (_ability != value)
                {
                    _ability = value;
                    UpdateQuery();
                }
            }
        }
        
        public int? Appearance_Height_Min
        {
            get => _appearance_height_min;
            set
            {
                if (_appearance_height_min != value)
                {
                    _appearance_height_min = value;
                    UpdateQuery();
                }
            }
        }
        public int? Appearance_Height_Max
        {
            get => _appearance_height_max;
            set
            {
                if (_appearance_height_max != value)
                {
                    _appearance_height_max = value;
                    UpdateQuery();
                }
            }
        }
        


        private void UpdateQuery()
        {
            IQueryable<Models.pokemon> pokemonQuery = this._context.pokemon;

            //Ability
            if (this.Ability != null && this.Ability.Length > 0)
            {
                pokemonQuery = pokemonQuery.Where(p =>
                  _context.ability
                  .Where(a => a.name == this.Ability)
                  .Any(a => a.id == p.primary_ability || a.id == p.secondary_ability || a.id == p.hidden_ability)
                );
            }
            //Move - úkol


            //Type
            bool type1exists = this.Type1 != null && this.Type1.Length > 0;
            bool type2exists = this.Type2 != null && this.Type2.Length > 0;
            if (type1exists && type2exists && this.Type1 != this.Type2)
            {
                pokemonQuery = pokemonQuery.Where(p => (p.primary_type == this.Type1 && p.secondary_type == this.Type2 || p.secondary_type == this.Type1 && p.primary_type == this.Type2));
            }
            else if (this.Type1 != null && this.Type1.Length > 0)
            {
                pokemonQuery = pokemonQuery.Where(p => p.primary_type == this.Type1 || p.secondary_type == this.Type1);
            }
            else if (this.Type2 != null && this.Type2.Length > 0)
            {
                pokemonQuery = pokemonQuery.Where(p => p.primary_type == this.Type2 || p.secondary_type == this.Type2);
            }

            //Generation

            //Legendary Status

            //Apearance - Color

            //Apearance - Shape

            //Apearance - Height 
            if (this.Appearance_Height_Min != null) pokemonQuery = pokemonQuery.Where(p => p.height >= this.Appearance_Height_Min);
            if (this.Appearance_Height_Max != null) pokemonQuery = pokemonQuery.Where(p => p.height <= this.Appearance_Height_Max);
            
            //Apearance - HP - filtruje pokemony podle minimalní a maximální hodnoty hp

            //Apearance - Weight

            //Apearance - Attack

            //Apearance - Defense

            //Apearance - Special Attack

            //Apearance - Special Defense

            //Apearance - Speed

            this.pokemonResults = pokemonQuery.ToList();
        }
    }
}
```
Úkol:
Udělej následující metody 
- Najděte Pokémona podle ID v databázi.
- Upravte existujícího Pokémona a změnu uložte do databáze.
- Odstraňte Pokémona z databáze a zobrazte potvrzení o odstranění.
 
Vytvoření aplikace okna.:

App.xaml.cs
```C#
public partial class App : Application
{
  //necháme prázdný
}
```
Nastavení designu hlavního okna.

MainWindow.xaml
```C#
<Window x:Class="ER_WPF.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Pokemon List" Height="720" Width="1000"
        WindowStartupLocation="CenterScreen">
    <Grid>
        <DataGrid x:Name="PokemonDataGrid" AutoGenerateColumns="False" Margin="22,20,0,0" SelectionChanged="PokemonDataGrid_SelectionChanged" HorizontalAlignment="Left" VerticalAlignment="Top" Height="630" Width="720" IsReadOnly="True" HeadersVisibility="None" GridLinesVisibility="None">
            <DataGrid.Columns>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Vertical" HorizontalAlignment="Center" VerticalAlignment="Center">
                                <Image Source="{Binding Sprite}" Width="100" Height="100" Margin="5"/>
                                <TextBlock Text="{Binding name}" VerticalAlignment="Center" HorizontalAlignment="Center" Margin="5"/>
                            </StackPanel>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
        <StackPanel Grid.Column="1" Margin="720,0,0,0">
            <Button x:Name="SearchButton" Content="SEARCH" Margin="40,20,0,0" Click="SearchButton_Click" FontWeight="Bold" IsCancel="True" Width="197" Height="30" HorizontalAlignment="Left"/>
            <Label Content="NAME:" HorizontalAlignment="Left" Margin="40,0,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14"/>
            <TextBox x:Name="NameTextBox" TextWrapping="Wrap" Text="" Margin="40,0,0,0" FontSize="18" HorizontalAlignment="Left" Width="197" Height="25" TextChanged="Name_TextChanged"/>
            <Label Content="TYPE:" HorizontalAlignment="Left" Width="70" Margin="40,0,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14"/>
            <Grid Margin="0,0,0,10">
                <ComboBox HorizontalAlignment="Left" Margin="45,0,0,0" VerticalAlignment="Top" Width="80" SelectionChanged="Type1_SelectionChanged"/>
                <ComboBox  Margin="158,0,0,0" Width="80" HorizontalAlignment="Left" VerticalAlignment="Top" SelectionChanged="Type2_SelectionChanged"/>
            </Grid>
            <Grid Margin="0,-2,0,0">
                <Label Grid.Column="0" Content="GENERATION:" HorizontalAlignment="Left" Margin="40,-4,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14" Width="118"/>
                <ComboBox HorizontalAlignment="Left" Margin="158,0,0,4" Width="80" SelectionChanged="Generation_SelectionChanged" RenderTransformOrigin="0.309,0.685"/>
            </Grid>
            <Label Content="KNOWS MOVE:" HorizontalAlignment="Left" Margin="40,0,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14" Width="118"/>
            <TextBox x:Name="KnowsMove_TextBox" TextWrapping="Wrap" Text="" Margin="40,0,0,0" FontSize="18" HorizontalAlignment="Left" Width="197" TextChanged="KnowsMove_TextChanged" Height="20"/>
            <Label Content="ABILITY:" HorizontalAlignment="Left" Margin="40,0,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14" Width="118"/>
            <TextBox x:Name="Ability_TextBox" TextWrapping="Wrap" Text="" Margin="40,0,0,0" FontSize="18" HorizontalAlignment="Left" Width="197" TextChanged="Ability_TextChanged" Height="21"/>
            <Label Content="LEGENDARY:" HorizontalAlignment="Left" Margin="40,0,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14" Width="118" RenderTransformOrigin="0.451,0.784"/>
            <ComboBox HorizontalAlignment="Left" Margin="40,0,0,0" VerticalAlignment="Top" Width="197" SelectionChanged="LegendaryStatus_SelectionChanged"/>
            <Label Content="APPEARANCE:" HorizontalAlignment="Left" Margin="40,0,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14" RenderTransformOrigin="1.031,-0.779" Width="118"/>
            <Grid Margin="0,0,0,0">
                <Label Content="COLOR:" HorizontalAlignment="Left" Margin="60,-3,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14" RenderTransformOrigin="0.474,-1.683"/>
                <ComboBox HorizontalAlignment="Left" Margin="130,0,0,0" VerticalAlignment="Top" Width="105" SelectionChanged="Appearance_Color_SelectionChanged"/>
            </Grid>
            <Grid Margin="0,0,0,0">
                <Label Content="SHAPE:" HorizontalAlignment="Left" Margin="60,-3,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14" Width="118"/>
                <ComboBox HorizontalAlignment="Left" Margin="130,0,0,0" VerticalAlignment="Top" Width="105" SelectionChanged="Appearance_Shape_SelectionChanged"/>
            </Grid>
            <StackPanel Orientation="Horizontal" Margin="0,-4,0,0">
                <Label Content="HEIGHT:" Margin="60,0,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14" Width="70"/>
                <TextBox x:Name="NumberOnly_PreviewTextInput" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_Height_Min_TextChanged"/>
                <Label Content="-" Margin="0,0,0,0" VerticalAlignment="Top" FontSize="14" Width="13"/>
                <TextBox x:Name="NumberOnly_PreviewTextInput2" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_Height_Max_TextChanged"/>
            </StackPanel>
            <StackPanel Orientation="Horizontal" Margin="0,-3,0,0">
                <Label Content="WEIGHT:" Margin="60,0,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14" Width="70"/>
                <TextBox  x:Name="NumberOnly_PreviewTextInput3" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_Height_Max_TextChanged"/>
                <Label Content="-" Margin="0,0,0,0" VerticalAlignment="Top" FontSize="14" Width="13"/>
                <TextBox  x:Name="NumberOnly_PreviewTextInput4" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_Height_Max_TextChanged"/>
            </StackPanel>
            <Label Content="STATS:" HorizontalAlignment="Left" Margin="40,-3,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14" RenderTransformOrigin="1.031,-0.779" Width="118"/>
            <StackPanel Orientation="Horizontal" Margin="0,-4,0,0">
                <Label Content="HP" Margin="60,0,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14" Width="70"/>
                <TextBox  x:Name="NumberOnly_PreviewTextInput5" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_HP_Min_TextChanged"/>
                <Label Content="-" Margin="0,0,0,0" VerticalAlignment="Top" FontSize="14" Width="13"/>
                <TextBox x:Name="NumberOnly_PreviewTextInput6" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_HP_Max_TextChanged"/>
            </StackPanel>
            <StackPanel Orientation="Horizontal" Margin="0,-4,0,0">
                <Label Content="ATTACK:" Margin="60,0,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14" Width="70"/>
                <TextBox x:Name="NumberOnly_PreviewTextInput7" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_Attack_Min_TextChanged"/>
                <Label Content="-" Margin="0,0,0,0" VerticalAlignment="Top" FontSize="14" Width="13"/>
                <TextBox x:Name="NumberOnly_PreviewTextInput8" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_Attack_Max_TextChanged"/>
            </StackPanel>
            <StackPanel Orientation="Horizontal" Margin="0,-4,0,0">
                <Label Content="DEFENSE:" Margin="60,0,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="13" Width="70"/>
                <TextBox x:Name="NumberOnly_PreviewTextInput9" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_Defense_Min_TextChanged"/>
                <Label Content="-" Margin="0,0,0,0" VerticalAlignment="Top" FontSize="14" Width="13"/>
                <TextBox x:Name="NumberOnly_PreviewTextInput10" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_Defense_Max_TextChanged"/>
            </StackPanel>
            <StackPanel Orientation="Horizontal" Margin="0,-4,0,0">
                <Label Content="SP.ATT.:" Margin="60,0,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14" Width="70"/>
                <TextBox x:Name="NumberOnly_PreviewTextInput11" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_SpAtt_Min_TextChanged"/>
                <Label Content="-" Margin="0,0,0,0" VerticalAlignment="Top" FontSize="14" Width="13"/>
                <TextBox x:Name="NumberOnly_PreviewTextInput12" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_SpAtt_Max_TextChanged"/>
            </StackPanel>
            <StackPanel Orientation="Horizontal" Margin="0,-4,0,0">
                <Label Content="SP.DEF.:" Margin="60,0,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14" Width="70"/>
                <TextBox x:Name="NumberOnly_PreviewTextInput13" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_SpDef_Min_TextChanged"/>
                <Label Content="-" Margin="0,0,0,0" VerticalAlignment="Top" FontSize="14" Width="13"/>
                <TextBox x:Name="NumberOnly_PreviewTextInput14" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_SpDef_Max_TextChanged"/>
            </StackPanel>
            <StackPanel Orientation="Horizontal" Margin="0,-4,0,0">
                <Label Content="SPEED:" Margin="60,0,0,0" VerticalAlignment="Top" FontWeight="Bold" FontSize="14" Width="70"/>
                <TextBox x:Name="NumberOnly_PreviewTextInput15" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_Speed_Min_TextChanged"/>
                <Label Content="-" Margin="0,0,0,0" VerticalAlignment="Top" FontSize="14" Width="13"/>
                <TextBox x:Name="NumberOnly_PreviewTextInput16" Margin="0,4,0,0" VerticalAlignment="Top" Width="46" Height="21" TextChanged="Appearance_Speed_Max_TextChanged"/>
            </StackPanel>
        </StackPanel>
    </Grid>
</Window>
```

Cs soubor hlavního okna pro nastavování funkcí

MainWindow.xaml.cs
```C#
using System.Windows.Controls;
using ER_WPF.Data;
using ER_WPF.Query;

namespace ER_WPF;


public partial class MainWindow : Window
{
    private readonly SearchQueryEngine _searchQueryEngine;
    private readonly PokemonBriefDetails _pokemonBriefDetails;
    private readonly PokemonFullDetails pokemonFullDetails;

    public MainWindow()
    {
        InitializeComponent();
        _searchQueryEngine = new SearchQueryEngine(new PokemonDataContext());
        LoadData();
    }

    private void LoadData()
    {
        var pokemons = _searchQueryEngine.GetAllPokemons()
          .Select(p => new { p.name }) 
          .ToList();

        PokemonDataGrid.ItemsSource = pokemons;
    }
    
    private void SearchButton_Click(object sender, RoutedEventArgs e)
    {
        //dodělat
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //dodělat
    }

    private void PokemonDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //dodělat
    }

    private void Name_TextChanged(object sender, TextChangedEventArgs e)
    {
    
        //dodělat
    }

    private void Type1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //dodělat
    }

    private void Type2_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //dodělat
    }

    private void Generation_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //dodělat
    }

    private void KnowsMove_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }

    private void Ability_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }

    private void LegendaryStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_Shape_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_Height_Min_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_Height_Max_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_HP_Min_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_HP_Max_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_Attack_Min_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_Attack_Max_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_Defense_Min_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_Defense_Max_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_SpAtt_Min_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_SpAtt_Max_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_SpDef_Min_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_SpDef_Max_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_Speed_Min_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }

    private void Appearance_Speed_Max_TextChanged(object sender, TextChangedEventArgs e)
    {
        //dodělat
    }
}
```


Sestavení projektu.
```
dotnet build
```

6. Po úspěšném sestavení (dotnet build)
```
dotnet run
```

### Aplikační část
Bonus úkol pro ty, co jsou rychlý.

Aplikace s pokémony a možnost vyhledávání, prohlížení pokémonů v aplikaci.
Úkoly:
- Pomocí metody najděte Pokémona podle ID vypište jeho jméno a obrázkem v aplikaci.
- Implementujte filtrační metody, aby fungovali také při vyhledávání v db.
