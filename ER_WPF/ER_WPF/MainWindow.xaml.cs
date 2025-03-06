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
}