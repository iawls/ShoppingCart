using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ShoppingCart
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RecipesPage : Page
    {
        public RecipesPage()
        {
            this.InitializeComponent();
        }

        public class Recipe
        {
            List<MainPage.Item> ingredients;
            public Recipe(List<MainPage.Item> ingredients_)
            {
                ingredients = ingredients_;
            }
        }
        private void Navigate_to_List_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void AddRecipeClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateRecipePage));

        }
    }
}
