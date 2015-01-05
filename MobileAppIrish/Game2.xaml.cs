using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MobileAppIrish
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game2 : Page
    {

       

        public Game2()
        {
            this.InitializeComponent();
            RefreshStats();
        }

       
        private MobileServiceCollection<Info, Info> items;
        private IMobileServiceTable<Info> info =
            App.IrishScoreClient.GetTable<Info>();
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        
        private async void RefreshStats()
        {

            Exception exception = null;
            try
            {


                items = await info.OrderBy(todoItem => todoItem.Text6).ToCollectionAsync();

                //ListItems.ItemsSource = items.OrderByDescending(Info => Info.Text6);
               // items = await info.ToCollectionAsync();
                ListItems.ItemsSource = items;


            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception != null)
            {
                await new MessageDialog(exception.Message, "No Internet Connection!").ShowAsync();
            }
            //// TODO #1: Mark this method as "async" and uncomment the following statment 
            //// that defines a simple query for all items.  

            //// TODO #2: More advanced query that filters out completed items.  
            //items = await todoTable 
            //   .Where(todoItem => todoItem.Complete == false) 
            //   .ToCollectionAsync(); 


        }

        private async void UpdateCheckedTodoItem(Info item)
        {
            //// This code takes a freshly completed TodoItem and updates the database. When the MobileService  
            //// responds, the item is removed from the list. 
            //// TODO: Mark this method as "async" and uncomment the following statement 
            await info.UpdateAsync(item);
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RefreshStats();
        }

        private void ListItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Info stat1 = e.AddedItems[0] as Info;
            localSettings.Values["firstname"] = stat1.Text1;
            localSettings.Values["surname"] = stat1.Text2;
            localSettings.Values["location"] = stat1.Text3;
            localSettings.Values["mins"] = stat1.Text4;
            localSettings.Values["seconds"] = stat1.Text5;
            localSettings.Values["realtime"] = stat1.Text6;
            
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        
       
        



        

            
                

                        
                    
            

                       

            
                
                



            
        
    }
}
