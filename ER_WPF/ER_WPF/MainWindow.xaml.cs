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
using ER_WPF.Models;

namespace ER_WPF;


public partial class MainWindow : Window
{
    private PokemonDataContext dbContext;
    public MainWindow()
    {
        InitializeComponent();
        dbContext = new PokemonDataContext();
    }
    private void Window_loaded(object sender,RoutedEventArgs e)
    {
        LoadPokemons();
    }
    private void LoadPokemons()
    {
        var pokemons = dbContext.Pokemons.ToList();
        PokemonsListBox.ItemsSource = pokemons;
    }
}