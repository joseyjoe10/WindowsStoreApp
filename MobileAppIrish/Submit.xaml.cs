using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
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
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MobileAppIrish
{

   

       public class Info
    {
        

         public string Id { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string Text1 { get; set; }

        [JsonProperty(PropertyName = "surname")]
        public string Text2 { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Text3 { get; set; }

        [JsonProperty(PropertyName = "mins")]
        public string Text4 { get; set; }

        [JsonProperty(PropertyName = "seconds")]
        public string Text5 { get; set; }

        [JsonProperty(PropertyName = "realTime")]
        public string Text6 { get; set; }



    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Submit : Page
    {



       

        public Submit()
        {
            this.InitializeComponent();

              //MinConv();
            FirstName.Text = "";
            Surname.Text = "";
            Location.Text = "";

            
        }

        

        private IMobileServiceTable<Info> info =
            App.IrishScoreClient.GetTable<Info>();
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        string firstName, surname;
        string items;
        //int MinToSeconds = 60;
        //int MinConersion;
        
        
        List<Info> stats;
        private async void RefreshStats()
        {
            // TODO #1: Mark this method as "async" and uncomment the following statment 
            // that defines a simple query for all items.  
            firstName = localSettings.Values["firstName"].ToString();
            surname = localSettings.Values["surname"].ToString();
            stats = await info
                 .Where(Stats => (Stats.Text1 == firstName) && (Stats.Text2 == surname)).ToListAsync();

            //&& Stats.Text2 == awayTeam

            // TODO #2: More advanced query that filters out completed items.  



           // FirstName.Text = stats[0].Text1.ToString();
            //Surname.Text = stats[0].homePoints.ToString();




        }




        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //RefreshStats();
            // //LblTeam1Name.Text = e.Parameter.ToString();
            // //LblTeam2Name.Text = e.Parameter.ToString();

            MobileAppIrish.Game1.AnotherPagePayload passedParameter = e.Parameter as MobileAppIrish.Game1.AnotherPagePayload;
            //JoeSweeney.PrevStats.AnotherPagePayload passedParameter1 = e.Parameter as JoeSweeney.PrevStats.AnotherPagePayload;
            string parameter1 = passedParameter.parameter1;
            string parameter2 = passedParameter.parameter2;
            string parameter3 = passedParameter.parameter3;
         
            // string parameter50 = passedParameter1.parameter50;
            // string parameter51 = passedParameter1.parameter51;


            //// homeTeam = parameter50;
            // //awayTeam = parameter51;


            Min.Text = parameter1.ToString();
            Seconds.Text = parameter2.ToString();
            RealTime.Text = parameter3.ToString();
          



        }

        private async void InsertStats(Info ScoreIrish)
        {
            // TODO: Delete or comment the following statement; Mobile Services auto-generates the ID. 
            //       You can also leave this line if you want to generate your own unique id values.
            //todoItem.Id = Guid.NewGuid().ToString();
            Exception exception = null;
            try
            {
                await info.InsertAsync(ScoreIrish);

            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception != null)
            {
                await new MessageDialog(exception.Message, "No Internet Connection!").ShowAsync();
            }





            //// This code inserts a new TodoItem into the database. When the operation completes 
            //// and Mobile Services has assigned an Id, the item is added to the CollectionView 
            //// TODO: Mark this method as "async" and uncomment the following statement. 
            // await todoTable.InsertAsync(todoItem); 

            //items.Add(todoItem);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var playerScore = new Info
            {
                

                Text1 = FirstName.Text,
                Text2 = Surname.Text,
                Text3 = Location.Text,
                Text4 = Min.Text,
                Text5 = Seconds.Text,
                Text6 = RealTime.Text,

               
              
            };

            InsertStats(playerScore);
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ScoreTime_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }

        //private void MinConv()
        //{

           // int x = Int32.Parse(Min.Text);
           // int y = Int32.Parse(Seconds.Text);

           // MinConersion = x * 60 + y;
           // ScoreTime.Text = MinConersion.ToString();

        //}

        private void Min_SelectionChanged(object sender, RoutedEventArgs e)
        {

           
        }

    }
}
