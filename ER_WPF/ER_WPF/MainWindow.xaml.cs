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
using System.Runtime.InteropServices.Swift;
using Microsoft.VisualBasic.FileIO;

namespace ER_WPF;


public partial class MainWindow : Window
{
    private readonly PokemonDataContext context;
    private readonly SearchQueryEngine _searchQueryEngine;
    private readonly PokemonBriefDetails _pokemonBriefDetails;
    private readonly PokemonFullDetails pokemonFullDetails;
    private bool removeEnabled = false;

    public MainWindow()
    {
        InitializeComponent();

        context = new PokemonDataContext();
        _searchQueryEngine = new SearchQueryEngine(this, context);
        //_searchQueryEngine.Init();

        Type1ComboBox.SelectedIndex = 0;
        Type2ComboBox.SelectedIndex = 0;
        GenerationComboBox.SelectedIndex = 0;
        AppearanceColorComboBox.SelectedIndex = 0;
        AppearanceShapeComboBox.SelectedIndex = 0;
        GenerationComboBox.SelectedIndex = 0;
        IsLegendaryComboBox.SelectedIndex = 0;

        _searchQueryEngine.Update();
        //this.UpdateGrid();
    }

    public void UpdateGrid()
    {
        int columns = (int)(DataStackPanel.ActualWidth / 150);
        int rows = columns == 0 ? 0 : (int)Math.Ceiling(_searchQueryEngine.DisplayResults.Count / (double)columns);

        DataStackPanel.Children.Clear();
        for (int i = 0; i < rows; i++)
        {
            StackPanel row = new StackPanel();
            row.Orientation = Orientation.Horizontal;
            row.HorizontalAlignment = HorizontalAlignment.Left;
            row.Height = 150;
            DataStackPanel.Children.Add(row);

            for (int j = 0; j < columns; j++)
            {
                int index = i * columns + j;
                if (index >= _searchQueryEngine.DisplayResults.Count) continue;
                StackPanel panel = GeneratePokemonStackPanel(_searchQueryEngine.DisplayResults[index]);
                row.Children.Add(panel);
            }
        }
        this.UpdateLayout();
        //PokemonDataGrid.ItemsSource = this._searchQueryEngine.DisplayResults;
    }
    public StackPanel GeneratePokemonStackPanel(PokemonBriefDetails pokemon)
    {
        StackPanel panel = new StackPanel();
        panel.Width = 150;
        panel.Height = 180;
        panel.Orientation = Orientation.Vertical;
        panel.VerticalAlignment = VerticalAlignment.Top;
        panel.Margin = new Thickness(5, 5, 5, 5);

        Image image = new Image();
        image.Tag = pokemon.ID;
        image.Source = pokemon.Sprite;
        image.Width = 100;
        image.Height = 100;
        image.Stretch = Stretch.Uniform;
        panel.Children.Add(image);
        image.MouseDown += PokemonClicked;

        TextBox name = new TextBox();
        name.Text = pokemon.Name;
        name.Tag = pokemon.ID;
        name.HorizontalAlignment = HorizontalAlignment.Center;
        name.TextAlignment = TextAlignment.Center;
        name.Width = 150;
        name.Height = 23;
        name.FontSize = 18;
        //name.IsReadOnly = true;
        name.BorderThickness = new Thickness(0);
        name.Background = System.Windows.Media.Brushes.Transparent;
        name.TextChanged += PokemonNameChanged;
        panel.Children.Add(name);

        StackPanel typePanel = new StackPanel();
        typePanel.Orientation = Orientation.Horizontal;
        typePanel.Height = 18;
        panel.Children.Add(typePanel);

        TextBox type1 = new TextBox();
        type1.Text = pokemon.Type1;
        type1.TextAlignment = TextAlignment.Center;
        type1.Width = 75;
        type1.Height = 18;
        type1.FontSize = 12;
        type1.IsReadOnly = true;
        type1.BorderThickness = new Thickness(0);
        type1.Background = new SolidColorBrush(pokemon.Type1Fill);
        type1.Foreground = new SolidColorBrush(pokemon.Type1Border);
        typePanel.Children.Add(type1);

        TextBox type2 = new TextBox();
        type2.Text = pokemon.Type2;
        type2.TextAlignment = TextAlignment.Center;
        type2.Width = 75;
        type2.Height = 18;
        type2.FontSize = 12;
        type2.IsReadOnly = true;
        type2.BorderThickness = new Thickness(0);
        type2.Background = new SolidColorBrush(pokemon.Type2Fill);
        type2.Foreground = new SolidColorBrush(pokemon.Type2Border);
        typePanel.Children.Add(type2);

        return panel;
    }

    private void RemoveButton_Click(object sender, RoutedEventArgs e)
    {
        removeEnabled = !removeEnabled;
        ((Button)sender).Background = removeEnabled ? System.Windows.Media.Brushes.Red : System.Windows.Media.Brushes.Gray;
    }

    private void Name_TextChanged(object sender, TextChangedEventArgs e)
    {
        this._searchQueryEngine.Name = ((TextBox)sender).Text;
    }

    private void Type1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBoxItem selectedItem = (ComboBoxItem)((ComboBox)sender).SelectedItem;
        string str = selectedItem.Content.ToString();
        if (str.Equals("Any")) this._searchQueryEngine.Type1 = null;
        else this._searchQueryEngine.Type1 = str.ToLower();
    }

    private void Type2_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBoxItem selectedItem = (ComboBoxItem)((ComboBox)sender).SelectedItem;
        string str = selectedItem.Content.ToString();
        if (str.Equals("Any")) this._searchQueryEngine.Type2 = null;
        else this._searchQueryEngine.Type2 = str.ToLower();
    }

    private void Generation_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBoxItem selectedItem = (ComboBoxItem)((ComboBox)sender).SelectedItem;
        string str = selectedItem.Content.ToString();
        if (str.Equals("Any")) this._searchQueryEngine.Generation = null;
        else this._searchQueryEngine.Generation = int.Parse(str);
    }

    private void KnowsMove_TextChanged(object sender, TextChangedEventArgs e)
    {
        this._searchQueryEngine.KnowsMove = ((TextBox)sender).Text;
    }

    private void Ability_TextChanged(object sender, TextChangedEventArgs e)
    {
        this._searchQueryEngine.Ability = ((TextBox)sender).Text;
    }

    private void LegendaryStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBoxItem selectedItem = (ComboBoxItem)((ComboBox)sender).SelectedItem;
        string text = selectedItem.Content.ToString();
        if (text.Equals("Legendary")) this._searchQueryEngine.LegendaryStatus = SearchQueryEngine.LegendaryStatuses.Legendary;
        else if (text.Equals("Mythical")) this._searchQueryEngine.LegendaryStatus = SearchQueryEngine.LegendaryStatuses.Mythical;
        else if (text.Equals("None")) this._searchQueryEngine.LegendaryStatus = SearchQueryEngine.LegendaryStatuses.None;
        else this._searchQueryEngine.LegendaryStatus = null;
    }

    private void Appearance_Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBoxItem selectedItem = (ComboBoxItem)((ComboBox)sender).SelectedItem;
        string str = selectedItem.Tag.ToString();
        if (str.Equals("Any")) this._searchQueryEngine.Appearance_Color = null;
        else this._searchQueryEngine.Appearance_Color = str;
    }

    private void Appearance_Shape_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBoxItem selectedItem = (ComboBoxItem)((ComboBox)sender).SelectedItem;
        string str = selectedItem.Tag.ToString();
        if (str.Equals("Any")) this._searchQueryEngine.Appearance_Shape = null;
        else this._searchQueryEngine.Appearance_Shape = str;
    }

    private void Appearance_Height_Min_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Appearance_Height_Min = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Appearance_Height_Min = null;
        }
    }

    private void Appearance_Height_Max_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Appearance_Height_Max = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Appearance_Height_Max = null;
        }
    }

    private void Appearance_Weight_Min_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Appearance_Weight_Min = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Appearance_Weight_Min = null;
        }
    }

    private void Appearance_Weight_Max_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Appearance_Weight_Max = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Appearance_Weight_Max = null;
        }
    }

    private void Stat_HP_Min_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Stat_HP_Min = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Stat_HP_Min = null;
        }
    }

    private void Stat_HP_Max_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Stat_HP_Max = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Stat_HP_Max = null;
        }
    }

    private void Stat_Attack_Min_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Stat_Attack_Min = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Stat_Attack_Min = null;
        }
    }

    private void Stat_Attack_Max_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Stat_Attack_Max = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Stat_Attack_Max = null;
        }
    }

    private void Stat_Defense_Min_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Stat_Defense_Min = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Stat_Defense_Min = null;
        }
    }

    private void Stat_Defense_Max_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Stat_Defense_Max = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Stat_Defense_Max = null;
        }
    }

    private void Stat_SpAtt_Min_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Stat_SpAtt_Min = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Stat_SpAtt_Min = null;
        }
    }

    private void Stat_SpAtt_Max_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Stat_SpAtt_Max = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Stat_SpAtt_Max = null;
        }
    }

    private void Stat_SpDef_Min_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Stat_SpDef_Min = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Stat_SpDef_Min = null;
        }
    }

    private void Stat_SpDef_Max_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Stat_SpDef_Max = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Stat_SpDef_Max = null;
        }
    }

    private void Stat_Speed_Min_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Stat_Speed_Min = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Stat_Speed_Min = null;
        }
    }

    private void Stat_Speed_Max_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((TextBox)sender).Text;
        try
        {
            this._searchQueryEngine.Stat_Speed_Max = int.Parse(text);
        }
        catch
        {
            this._searchQueryEngine.Stat_Speed_Max = null;
        }
    }
    private void PokemonClicked(object sender, RoutedEventArgs e)
    {
        //TODO
    }
    private void PokemonNameChanged(object sender, RoutedEventArgs e)
    {
        //TODO
    }
}