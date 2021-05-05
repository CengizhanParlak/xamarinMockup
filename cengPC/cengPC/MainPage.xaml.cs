using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using cengPC;

namespace cengPC
{

    public partial class MainPage : ContentPage
    {
        public static bool girildiMi;
        public static List<string> imagePaths = new List<string>();
        
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = this;

            var metrics = DeviceDisplay.MainDisplayInfo;
            double densityOfScreen = metrics.Density;
            double widthOfScreen = metrics.Width/densityOfScreen;
            double heightOfScreen = metrics.Height/densityOfScreen;
            double ContentArea = heightOfScreen - 55;//doğru alıyoruz ama xaml'da bunu kullanmayı bulamadım. binding falan denedim ama ı ıh
            InitializeComponent();
        }
        async void SearchBtnClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new SearchPage());
            
        }

        async void BasketBtnClicked (object sender, EventArgs e)//private void ti. 21.39da async'e değiştirdim
        {
            await Navigation.PushAsync(new basketPage());
        }

        private void HesabimBtnClicked(object sender, EventArgs e)
        {
            if (MainPage.girildiMi) 
            {
                Navigation.PushAsync(new AccountPage());
                
            }
            else
            {
                Navigation.PushAsync(new LogInPage());
            }

        }

        private void ImageButton_Clicked_3(object sender, EventArgs e)
        {

        }

        private void TakipBtnClicked(object sender, EventArgs e)
        {
            if (MainPage.girildiMi)
            {
                Navigation.PushAsync(new TakipPage());

            }
            else
            {
                Navigation.PushAsync(new NoLogTakipPage());
            }
        }
        
        private void FavoriBtnClicked(object sender, EventArgs e)
        {
            if (MainPage.girildiMi)
            {
                Navigation.PushAsync(new FavPage());

            }
            else
            {
                Navigation.PushAsync(new LogInPage());
            }

        }

        private void MoreBtnClicked (object sender, EventArgs e)
        {
            Navigation.PushAsync(new MorePage());
        }

        private void ErkekYSClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new erkekKoleksiyonPage());
        }

        private void TshirtYSClicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new tshirtKoleksiyonPage());
        }

        private void CeketYSClicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new ceketKoleksiyonPage());
        }
        



    }
}
