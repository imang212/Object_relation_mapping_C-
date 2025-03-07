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
    private void SearchButton_Click_1(object sender, RoutedEventArgs e)
    {
        string searchTerm = SearchTextBox.Text;

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

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged3(object sender, SelectionChangedEventArgs e)
    {

    }

    private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
    {

    }

    private void TextBox_TextChanged3(object sender, TextChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged4(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChange5(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged6(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged7(object sender, SelectionChangedEventArgs e)
    {

    }
    private void ComboBox_SelectionChanged8(object sender, SelectionChangedEventArgs e)
    {

    }
    private void ComboBox_SelectionChanged9(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged10(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged_HP_1(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged_HP_2(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged_ATTACK_1(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged_ATTACK_2(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged_DEFENSE_1(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged_DEFENSE_2(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged_SPATT_1(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged_SPATT_2(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged_SPDEF_1(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged_SPDEF_2(object sender, SelectionChangedEventArgs e)
    {

    }
}