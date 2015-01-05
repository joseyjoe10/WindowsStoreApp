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
using Windows.Media;
using Windows.UI.Popups;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MobileAppIrish
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game1 : Page
    {
       
        public string CountyPick;

        int score = 0;
        int lives = 3;
        List<string> names = new List<string> { "Aontroim","Ard Mhacha","Ceatharlach","An Cabhán","An Clár","Corcaigh","Doire","Dún na nGall","An Dún","Áth Cliath","Fear Manach","Gaillimh","Ciarraí","Cill Dara","Cill Chainnigh","Laois","Liatroim","Luimneach","An Longfort","Lú",
                                "Maigh Eo","An Mhí","Muineachán","Uíbh Fhailí","Ros Comáin","Sligeach","Tiobraid Árann","Tír Eoghain","Port Láirge","An Iarmhí","Loch Garman","Cill Mhantáin" };

        private DispatcherTimer timer;
        private int i, j, min,RealTime;
        

       

        public Game1()
        {
            this.InitializeComponent();

            timer = new DispatcherTimer();

            timer.Tick += timer_Tick;

            Init();
        }

        //================= TIMER ==============================================

        public void Init()
        {
            j = i = 1;
            timer.Interval = TimeSpan.FromSeconds(i);
        }

        void timer_Tick(object sender, object e)
        {

            TimerTextBlock.Text = "        " + min.ToString() + ":" + i.ToString();
            i = i + j;

            if (i == 60)
            {
                min += 1;
                i = 0;
            }

            // int timeLeftMin;
            // if (min == 1)
            // {
            //   timeLeftMin = 30 - min;
            //   TimeLeft.Text = "            Time Left Until End of Half " + timeLeftMin + " Mins";

            //}

        }


        //=======================    EXIT BUTTON DIALOG BOX     ===========================================================
        private  async void Button_Click(object sender, RoutedEventArgs e)
        {

            var messageDialog = new MessageDialog("Are you sure you want to exit?");
            messageDialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand("No", new UICommandInvokedHandler(this.CommandInvokedHandler3)));
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.DefaultCommandIndex = 1;
            await messageDialog.ShowAsync();

           
        }

        //========================= RESTART METHOD THAT GIVES YOU CHOICE TO RESTART OR CLOSE ==================================

        public async void Restart()
        {
            if (names.Count == 0)
            {
                timer.Stop();
                var messageDialog = new MessageDialog("Well Done! Time : " + min + " Min  and " + (i -1) + " Seconds" );
                messageDialog.Commands.Add(new UICommand("Restart", new UICommandInvokedHandler(this.CommandInvokedHandler2)));
                messageDialog.Commands.Add(new UICommand("Close", new UICommandInvokedHandler(this.CommandInvokedHandler)));
                messageDialog.Commands.Add(new UICommand("Submit Score", new UICommandInvokedHandler(this.FinishCommand)));
                messageDialog.DefaultCommandIndex = 0;
                messageDialog.DefaultCommandIndex = 1;
                await messageDialog.ShowAsync();

            }
            else
            {
                timer.Stop();
                var messageDialog = new MessageDialog("GAME OVER!");
                messageDialog.Commands.Add(new UICommand("Restart", new UICommandInvokedHandler(this.CommandInvokedHandler2)));
                messageDialog.Commands.Add(new UICommand("Close", new UICommandInvokedHandler(this.CommandInvokedHandler)));
                messageDialog.DefaultCommandIndex = 0;
                messageDialog.DefaultCommandIndex = 1;
                await messageDialog.ShowAsync();

            }


        }

        private void CommandInvokedHandler(IUICommand command)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void CommandInvokedHandler2(IUICommand command)
        {
            this.Frame.Navigate(typeof(Game1));
        }

        private void CommandInvokedHandler3(IUICommand command)
        {
            this.CancelDirectManipulations();
           
        }

        private void CommandInvokedHandler4(IUICommand command)
        {
            var messageDialog = new MessageDialog("An  : " + min + " Min  and " + (i - 1) + " Seconds "+ RealTime);
            messageDialog.Commands.Add(new UICommand("Restart", new UICommandInvokedHandler(this.CommandInvokedHandler2)));

        }

        

        
    //============================= START BUTTON METHOD ======================================================
       

        public void BtnStart_Click(object sender, RoutedEventArgs e)
        {

            if (names.Count == 32)  
            {


                BtnAntrim.IsEnabled = true;
                BtnArmagh.IsEnabled = true;
                BtnCarlow.IsEnabled = true;
                BtnCavan.IsEnabled = true;
                BtnClare.IsEnabled = true;
                BtnCork.IsEnabled = true;
                BtnDerry.IsEnabled = true;
                BtnDonegal.IsEnabled = true;
                BtnDown.IsEnabled = true;
                BtnDublin.IsEnabled = true;
                BtnFermanagh.IsEnabled = true;
                BtnGalway.IsEnabled = true;
                BtnKerry.IsEnabled = true;
                BtnKildare.IsEnabled = true;
                BtnKillkenny.IsEnabled = true;
                BtnLaois.IsEnabled = true;
                BtnLetrim.IsEnabled = true;
                BtnLimerick.IsEnabled = true;
                BtnLongford.IsEnabled = true;
                BtnLouth.IsEnabled = true;
                BtnMayo.IsEnabled = true;
                BtnMeath.IsEnabled = true;
                BtnMonaghan.IsEnabled = true;
                BtnOffaly.IsEnabled = true;
                btnRoscommon.IsEnabled = true;
                BtnSligo.IsEnabled = true;
                BtnTipp.IsEnabled = true;
                BtnTyrone.IsEnabled = true;
                BtnWaterford.IsEnabled = true;
                BtnWestMeath.IsEnabled = true;
                BtnWexford.IsEnabled = true;
                BtnWicklow.IsEnabled = true;

                i = 0;
                min = 0;
                timer.Start();
            }
                


                

            

            if(names.Count == 0)
            {
                Quest.Text = "Finished";
                BtnStart.IsEnabled = false;
                tada.Play();
                Restart();
                RealTime = min * 60 + i - 1;

                realTime.Text = RealTime.ToString();

            }
            else
            {
                Random random = new Random();


                correct.Play();
                int index = random.Next(names.Count);
                var name = names[index];
                names.RemoveAt(index);
                Quest.Text = name.ToString();

                BtnStart.IsEnabled = false;
                

            }

        }

        public void livesLeft()
        {
            if(txtLivesLeft.Text == "2")
            {
                live3.Opacity = 0;
            }
            if(txtLivesLeft.Text == "1")
            {
                live2.Opacity = 0;
            }

        }

       //=================== CORRECT AND INCORRECT METHODS ================================== 

        public void Correct(object sender, RoutedEventArgs e)
        {
            txtTimer.Text = "Correct."; //CORRECT
            
            BtnStart.IsEnabled = true;
            
            BtnStart_Click(sender, e);

            score = score + 1;
            txtScoreUp.Text = score.ToString();

        }

        


        public  void  Wrong()
        {
            if(txtLivesLeft.Text == "1" )
            {
                lives = lives - 1;
                txtLivesLeft.Text = lives.ToString();
                //dead.Play();
                Quest.Text = "Game Over!"; //GAME OVER
                Restart();
                
            }
            else
            {
                
                txtTimer.Text = "Wrong."; //INCORRECT
                wrong.Play();
                lives = lives - 1;
                txtLivesLeft.Text = lives.ToString();
                livesLeft();

                

            }
            

        }

        


        //================================== COUNTIES ON CLICK METHODS =====================================


        private void BtnDonegal_Click(object sender, RoutedEventArgs e)
        {

            if (Quest.Text == "Dún na nGall")
            {

                BtnDonegal.IsEnabled = false;

                Correct(sender, e);
            }
            else
            {
                Wrong();

            }
        }


        private void BtnDerry_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Doire")
            {
                Correct(sender, e);
                BtnDerry.IsEnabled = false;
            }
            else
            {
                Wrong();
            }

        }

        private void BtnAntrim_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Aontroim")
            {
                BtnAntrim.IsEnabled = false;
                Correct(sender, e);
            }
            else
            {
                Wrong();
            }
        }

       

        private void BtnTyrone_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Tír Eoghain")
            {
                BtnTyrone.IsEnabled = false;
                Correct(sender, e);
            }
            else
            {
                Wrong();
            }
        }

        

        public void BtnWexford_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Loch Garman")
            {
                BtnWexford.IsEnabled = false;
                Correct(sender, e);
            }
            else
            {
                Wrong();
            }
            
        }

        private void BtnWicklow_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Cill Mhantáin")
            {
                BtnWicklow.IsEnabled = false;
                Correct(sender, e);
                
            }
            else
            {
                Wrong();
            }

        }

        private void BtnCork_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Corcaigh")
            {
                BtnCork.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }

        }

        private void BtnKerry_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Ciarraí")
            {
                BtnKerry.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }
        }

        private void BtnWaterford_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Port Láirge")
            {
                BtnWaterford.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }
        }

        private void BtnTipp_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Tiobraid Árann")
            {
                BtnTipp.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }
        }

        private void BtnKillkenny_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Cill Chainnigh")
            {
                BtnKillkenny.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }
        }

        private void BtnCarlow_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Ceatharlach")
            {
                BtnCarlow.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }
        }

        private void BtnKildare_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Cill Dara")
            {
                BtnKildare.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }
        }

        private void BtnLaois_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Laois")
            {
                BtnLaois.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }
        }

        private void BtnClare_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "An Clár")
            {
                BtnClare.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }
        }

        private void BtnLimerick_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Luimneach")
            {
                BtnLimerick.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }

        }

        private void BtnDublin_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Áth Cliath")
            {
                BtnDublin.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }
        }

        private void BtnOffaly_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Uíbh Fhailí")
            {
                BtnOffaly.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }
        }

        private void BtnGalway_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Gaillimh")
            {
                BtnGalway.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }
        }

        private void BtnMayo_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Maigh Eo")
            {
                BtnMayo.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }
        }

        private void btnRoscommon_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Ros Comáin")
            {
                btnRoscommon.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }
        }

        private void BtnWestMeath_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "An Iarmhí")
            {
                BtnWestMeath.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }
        }

        private void BtnMeath_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "An Mhí")
            {
                BtnMeath.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
            }
        }

        private void BtnLouth_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Lú")
            {
                BtnLouth.IsEnabled = false;
                Correct(sender, e);
            }
            else
            {
                Wrong();
            }
        }

        private void BtnSligo_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Sligeach")
            {
                BtnSligo.IsEnabled = false;
                Correct(sender, e);
            }
            else
            {
                Wrong();
            }
        }

        private void BtnLetrim_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Liatroim")
            {
                BtnLetrim.IsEnabled = false;
                Correct(sender, e);
            }
            else
            {
                Wrong();
            }
        }

        private void BtnCavan_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "An Cabhán")
            {
                BtnCavan.IsEnabled = false;
                Correct(sender, e);
            }
            else
            {
                Wrong();
            }
        }

        private void BtnDown_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "An Dún")
            {
                BtnDown.IsEnabled = false;
                Correct(sender, e);
            }
            else
            {
                Wrong();
            }
        }

        private void BtnMonaghan_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Muineachán")
            {
                BtnMonaghan.IsEnabled = false;
                Correct(sender, e);

            }
            else
            {
                Wrong();
                
               
            }
        }

        private void BtnFermanagh_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Fear Manach")
            {
                BtnFermanagh.IsEnabled = false;
                Correct(sender, e);
            }
            else
            {
                Wrong();
            }
        }

        private void BtnArmagh_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "Ard Mhacha")
            {
                BtnArmagh.IsEnabled = false;
                Correct(sender, e);
            }
            else
            {
                Wrong();
            }
        }

        private void BtnLongford_Click(object sender, RoutedEventArgs e)
        {
            if (Quest.Text == "An Longfort")
            {
                BtnLongford.IsEnabled = false;
                
                Correct(sender, e);
            }
            else
            {
                Wrong();
               
            }

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var messageDialog = new MessageDialog("Try and find the location of every county in ireland. You only have 3 lives so be careful!!");
            messageDialog.Commands.Add(new UICommand("ceart go leor/Ok", new UICommandInvokedHandler(this.CommandInvokedHandler3)));
            messageDialog.DefaultCommandIndex = 0;
            await messageDialog.ShowAsync();

        }

        private void BtnTimer_Click(object sender, RoutedEventArgs e)
        {
            i = 0;
            min = 0;
            timer.Start();
            
        }






        public class AnotherPagePayload
        {
            public string parameter1 { get; set; }
            public string parameter2 { get; set; }
            public string parameter3 { get; set; }
          

        }

        void FinishCommand(IUICommand command)
        {
            //finish command
            i = i - 1;

            AnotherPagePayload payload = new AnotherPagePayload();
            payload.parameter1 = min.ToString();
            payload.parameter2 = i.ToString();
            payload.parameter3 = realTime.Text;
         
            Frame.Navigate(typeof(Submit), payload);


        }
        

        










       
    }
}
