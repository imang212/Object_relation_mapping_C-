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
using ER_WPF.Query;

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
        var pokemons = _context.pokemon
            .Select(p => new { p.name })
            .ToList();
        PokemonDataGrid.ItemsSource = pokemons;
    }
    
    private void SearchButton_Click(object sender, RoutedEventArgs e)
    {
        //string searchTerm = NameTextBox.Text;
        //
        //var searchResults = _context.pokemon
        //    .Where(p => p.name.Contains(searchTerm))
        //    .Select(p => new PokemonFullDetails(_context, p.id)) 
        //    .ToList();
        //
        //PokemonDataGrid.ItemsSource = searchResults;
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

    private void Appearance_Height_Min_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Appearance_Height_Max_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Appearance_HP_Min_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Appearance_HP_Max_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Appearance_Attack_Min_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Appearance_Attack_Max_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Appearance_Defense_Min_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Appearance_Defense_Max_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Appearance_SpAtt_Min_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Appearance_SpAtt_Max_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Appearance_SpDef_Min_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Appearance_SpDef_Max_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Appearance_Speed_Min_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Appearance_Speed_Max_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}