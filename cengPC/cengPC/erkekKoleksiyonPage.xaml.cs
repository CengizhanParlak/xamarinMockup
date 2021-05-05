﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cengPC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class erkekKoleksiyonPage : ContentPage
    {
        List<String> ImagePaths = new List<String>();

        public erkekKoleksiyonPage()
        {
            InitializeComponent();
            scrollViewArea.Content = this.BuildView();
        }


        private StackLayout BuildView()
        {
            int ImagesInFolder;
            ImagePaths.Add("_beyaztshirt");
            ImagePaths.Add("_gomlek");
            ImagePaths.Add("_kaban");
            ImagePaths.Add("_koyuyesiltshirt");
            ImagePaths.Add("_mavitshirt");
            ImagePaths.Add("_turuncutshirt");
            ImagePaths.Add("_yesiltshirt");
            if (ImagePaths.Count % 2 != 0) {
                ImagePaths.Add(ImagePaths.ElementAt(0)); //tek sayıda fotoğraf varsa grid'lere fotoğraf eklerken son gridde sorun çıkmasın diye eklendi.
            }

            ImagesInFolder = ImagePaths.Count();
            urunSayisi.Text = ImagesInFolder.ToString() + " adet ürün gösteriliyor";

            StackLayout stackLayoutInScrollView= CreateGrids(ImagesInFolder, ImagePaths);

            return stackLayoutInScrollView;
        }


        public StackLayout CreateGrids(int imageCount, List<String> ImagePaths){
            StackLayout sl = new StackLayout();
            Grid g = new Grid();            //grid oluşturuldu. 2 sütun ve X sayıda satırdan oluşacak.
            g.ColumnDefinitions.Add(new ColumnDefinition());
            g.ColumnDefinitions.Add(new ColumnDefinition());

            int TotalRow = imageCount / 2; //5 image varsa 5/2 = 2 + 1 = 3'ten 3 tane satır oluştururuz.
            String UrunPath;


            Frame frameInGrid;
            StackLayout stackLayoutInFrame;

            for (int rowIndex = 0; rowIndex < TotalRow; rowIndex++)
            {
                g.RowDefinitions.Add(new RowDefinition());//yeni satır ekliyoruz
                for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                {
                    frameInGrid = new Frame();
                    stackLayoutInFrame = new StackLayout();
                    UrunPath = ImagePaths.ElementAt(rowIndex * 2 + columnIndex);


                    //Image button yaratıyoruz
                    myImageButton UrunButton = new myImageButton() //ImageButton'a çevirince her şey düzgün çalışıyor
                    {
                        Source = UrunPath,
                        BackgroundColor = Color.Transparent,
                        HeightRequest = 300,
                        Margin = new Thickness(-10, -20, -10, 0),
                        Aspect = Aspect.AspectFill,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                    };

                    UrunButton.Clicked += UrunButton_Clicked;

                    Label UrunLabeli = new Label {
                        Text = UrunPath.Substring(1),
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,

                    };
                    Label UrunFiyati = new Label
                    {
                        Text = "159,99",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                    };
                    Console.WriteLine("aga source u şu:" + UrunButton.Source);
                    stackLayoutInFrame.Children.Add(UrunButton);
                    stackLayoutInFrame.Children.Add(UrunLabeli);
                    stackLayoutInFrame.Children.Add(UrunFiyati);
                    frameInGrid.Content = stackLayoutInFrame;
                    g.Children.Add(frameInGrid, columnIndex, rowIndex);
                }
            }
            sl.Children.Add(g);
            return sl;
        }


        private async void UrunButton_Clicked(object sender, EventArgs e)
        {
            myImageButton imgButton = sender as myImageButton;
            await Navigation.PushAsync(new UrunSayfasi(imgButton.Source));
        }



    }

    internal class myImageButton : ImageButton
    {
        public new string Source { get; set; }
        public new Color BackgroundColor { get; set; }
        public new int HeightRequest { get; set; }
        public new Thickness Margin { get; set; }
        public new Aspect Aspect { get; set; }
        public new LayoutOptions HorizontalOptions { get; set; }
        public LayoutOptions VerticalOptions { get; set; }
    }
    


    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {

        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}