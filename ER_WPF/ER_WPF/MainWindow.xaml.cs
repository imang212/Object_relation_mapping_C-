using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Linq;
using System.Windows;
using ER_WPF.Data;

namespace ER_WPF;


public partial class MainWindow : Window
{
    private readonly PokemonDataContext _context;

    public MainWindow()
    {
        InitializeComponent();
        _context = new PokemonDataContext();
        LoadData();
    }

    private void LoadData()
    {
        var abilities = _context.ability.ToList();
        var moves = _context.move.ToList();
        var pokemons = _context.pokemon.ToList();
        var pokemon_species= _context.pokemon_species.ToList();
        var pokemon_moves = _context.pokemon_move.ToList();
        var evolution_chains = _context.evolution_chain.ToList();

        PokemonDataGrid.ItemsSource = abilities;
    }
    private void SearchButton_Click(object sender, RoutedEventArgs e)
    {
        string searchTerm = NameTextBox.Text;

        var searchResults = _context.pokemon
            .Where(p => p.name.Contains(searchTerm))
            .ToList();

        PokemonDataGrid.ItemsSource = searchResults;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }

    private void PokemonDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Name_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Type1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Type2_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Generation_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void KnowsMove_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Ability_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void LegendaryStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Appearance_Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Appearance_Shape_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Appearance_Height_Min_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }
    private void Appearance_Height_Max_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }
    private void Appearance_Weight_Min_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Appearance_Weight_Max_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Stats_HP_Min_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Stats_HP_Max_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Stats_Attack_Min_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Stats_Attack_Max_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Stats_Defense_Min_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Stats_Defense_Max_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Stats_SpAtt_Min_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Stats_SpAtt_Max_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Stats_SpDef_Min_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Stats_SpDef_Max_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Stats_Speed_Min_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Stats_Speed_Max_TextChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}