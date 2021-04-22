﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using cengPC;

namespace cengPC
{

    public partial class MainPage : ContentPage
    {
        public static bool girildiMi;
        
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
        async void ImageButton_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new SearchPage());
            
        }

        async void ImageButton_Clicked_1(object sender, EventArgs e)//private void ti. 21.39da async'e değiştirdim
        {
            await Navigation.PushAsync(new basketPage());
        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
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

        private void ImageButton_Clicked_4(object sender, EventArgs e)
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
        
        private void ImageButton_Clicked_5(object sender, EventArgs e)
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

        private void ImageButton_Clicked_6(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MorePage());
        }


        //erkek sayfasi koleksiyon butonu clicked işlemi
        private void erkekKoleksiyon(object sender, EventArgs e)
        {
            Navigation.PushAsync(new erkekKoleksiyonPage());
        }

        private void ImageButton_Clicked_7(object sender, EventArgs e)
        {
            Navigation.PushAsync(new erkekKoleksiyonPage());
        }
    }
}
