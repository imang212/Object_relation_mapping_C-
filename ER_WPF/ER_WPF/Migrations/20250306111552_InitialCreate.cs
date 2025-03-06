using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ER_WPF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ability",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    effect = table.Column<string>(type: "text", nullable: false),
                    short_effect = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    generation = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ability", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Evolution_chain",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    from = table.Column<int>(type: "integer", nullable: false),
                    to = table.Column<int>(type: "integer", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    min_beauty = table.Column<int>(type: "integer", nullable: false),
                    min_happiness = table.Column<int>(type: "integer", nullable: false),
                    min_level = table.Column<int>(type: "integer", nullable: false),
                    trade_species = table.Column<string>(type: "text", nullable: false),
                    relative_physical_stats = table.Column<int>(type: "integer", nullable: false),
                    item = table.Column<string>(type: "text", nullable: false),
                    held_item = table.Column<string>(type: "text", nullable: false),
                    known_move = table.Column<string>(type: "text", nullable: false),
                    known_move_type = table.Column<string>(type: "text", nullable: false),
                    trigger = table.Column<string>(type: "text", nullable: false),
                    party_species = table.Column<string>(type: "text", nullable: false),
                    party_type = table.Column<string>(type: "text", nullable: false),
                    time_of_day = table.Column<string>(type: "text", nullable: false),
                    needs_overworld_rain = table.Column<bool>(type: "boolean", nullable: false),
                    turn_upside_down = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evolution_chain", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Move",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    accuracy = table.Column<int>(type: "integer", nullable: false),
                    damage_class = table.Column<string>(type: "text", nullable: false),
                    effect_chance = table.Column<int>(type: "integer", nullable: false),
                    generation = table.Column<int>(type: "integer", nullable: false),
                    ailment = table.Column<string>(type: "text", nullable: false),
                    ailment_chance = table.Column<string>(type: "text", nullable: false),
                    crit_rate = table.Column<int>(type: "integer", nullable: false),
                    drain = table.Column<int>(type: "integer", nullable: false),
                    flinch_chance = table.Column<int>(type: "integer", nullable: false),
                    healing = table.Column<int>(type: "integer", nullable: false),
                    max_hits = table.Column<int>(type: "integer", nullable: false),
                    min_turns = table.Column<int>(type: "integer", nullable: false),
                    stat_chance = table.Column<int>(type: "integer", nullable: false),
                    power = table.Column<int>(type: "integer", nullable: false),
                    pp = table.Column<int>(type: "integer", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    target = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Move", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    base_experience = table.Column<int>(type: "integer", nullable: false),
                    height = table.Column<int>(type: "integer", nullable: false),
                    weight = table.Column<int>(type: "integer", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    primary_ability = table.Column<int>(type: "integer", nullable: false),
                    secondary_ability = table.Column<int>(type: "integer", nullable: false),
                    hidden_ability = table.Column<int>(type: "integer", nullable: false),
                    species = table.Column<int>(type: "integer", nullable: false),
                    hp = table.Column<int>(type: "integer", nullable: false),
                    hp_effort = table.Column<int>(type: "integer", nullable: false),
                    attack = table.Column<int>(type: "integer", nullable: false),
                    attack_effort = table.Column<int>(type: "integer", nullable: false),
                    defense = table.Column<int>(type: "integer", nullable: false),
                    defense_effort = table.Column<int>(type: "integer", nullable: false),
                    special_attack = table.Column<int>(type: "integer", nullable: false),
                    special_attack_effort = table.Column<int>(type: "integer", nullable: false),
                    special_defense = table.Column<int>(type: "integer", nullable: false),
                    special_defense_effort = table.Column<int>(type: "integer", nullable: false),
                    speed = table.Column<int>(type: "integer", nullable: false),
                    speed_effort = table.Column<int>(type: "integer", nullable: false),
                    sprite_front_default = table.Column<string>(type: "text", nullable: false),
                    sprite_front_female = table.Column<string>(type: "text", nullable: false),
                    sprite_front_shiny_female = table.Column<string>(type: "text", nullable: false),
                    sprite_front_shiny = table.Column<string>(type: "text", nullable: false),
                    sprite_back_default = table.Column<string>(type: "text", nullable: false),
                    sprite_back_female = table.Column<string>(type: "text", nullable: false),
                    sprite_back_shiny_female = table.Column<string>(type: "text", nullable: false),
                    sprite_back_shiny = table.Column<string>(type: "text", nullable: false),
                    cry = table.Column<string>(type: "text", nullable: false),
                    cry_legacy = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    primary_type = table.Column<string>(type: "text", nullable: false),
                    secondary_type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon_move",
                columns: table => new
                {
                    pokemon = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    move = table.Column<int>(type: "integer", nullable: false),
                    level_learned_at = table.Column<int>(type: "integer", nullable: false),
                    learn_method = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon_move", x => x.pokemon);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon_species",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    base_happiness = table.Column<int>(type: "integer", nullable: false),
                    capture_rate = table.Column<int>(type: "integer", nullable: false),
                    gender_rate = table.Column<int>(type: "integer", nullable: false),
                    hatch_counter = table.Column<int>(type: "integer", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    generation = table.Column<int>(type: "integer", nullable: false),
                    national_pokedex_number = table.Column<int>(type: "integer", nullable: false),
                    is_baby = table.Column<bool>(type: "boolean", nullable: false),
                    is_legendary = table.Column<bool>(type: "boolean", nullable: false),
                    is_mythical = table.Column<bool>(type: "boolean", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    growth_rate = table.Column<string>(type: "text", nullable: false),
                    habitat = table.Column<string>(type: "text", nullable: false),
                    shape = table.Column<string>(type: "text", nullable: false),
                    genera = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    egg_group = table.Column<string>(type: "text", nullable: false),
                    varieties = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon_species", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ability");

            migrationBuilder.DropTable(
                name: "Evolution_chain");

            migrationBuilder.DropTable(
                name: "Move");

            migrationBuilder.DropTable(
                name: "Pokemon");

            migrationBuilder.DropTable(
                name: "Pokemon_move");

            migrationBuilder.DropTable(
                name: "Pokemon_species");
        }
    }
}
