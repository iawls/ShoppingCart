using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ShoppingCart
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        App.database db = new App.database();

        public MainPage()
        {
            this.InitializeComponent();
            var query = db.data.Table<Item>();

            foreach (var item in query)
            {
                ShoppingList.Items.Add(item);
            }
        }

        
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            string item = ListBox.Text;
            Item item_ = new Item() { name = ListBox.Text };
            ListBox.Text = "";
            bool duplicateItem = false;

            foreach (Item tmp in ShoppingList.Items)
            {
                if(tmp.name == item)
                {
                    duplicateItem = true;
                }
            }

            if (!duplicateItem)
            {
                ShoppingList.Items.Add(item_);
                Item entry = new Item() { name = item };
                db.data.Insert(entry);
            }
        }


        public class Item
        {
            [PrimaryKey]
            public string name { get; set; }
            public Item()
            {
            }
        }


        private void ShoppingList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {

            ShoppingList.Items.Clear();
            db.data.DropTable<Item>();
            db.data.CreateTable<Item>();

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Item tmp = (Item)btn.DataContext; //Get the item that sent the press
            ShoppingList.Items.Remove((Item)btn.DataContext);
            db.data.Delete(tmp);
        }

        private void Navigate_to_Recipes_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RecipesPage));
        }
    }
}
