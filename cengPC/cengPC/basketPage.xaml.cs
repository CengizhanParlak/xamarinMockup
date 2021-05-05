using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections;
using System.IO;

namespace cengPC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class basketPage : ContentPage
    {
        public basketPage()
        {                
            InitializeComponent();

            if (UrunSayfasi.siralar.Count > 0)
            {
                SVinBasket.Content = renderUrunler();
                
            }
            
            else {
                Label emptyLabel = new Label { 
                    Text = "Sepetinizde Ürün Bulunamadı",
                    TextColor = Color.Brown,
                    FontSize = 20,
                    FontAttributes = FontAttributes.Bold,
                };
                BoxView boxView = new BoxView { 
                    BackgroundColor = Color.Gray,
                    HeightRequest = 1,
                };
                StackLayout SLinEmptyBasket = new StackLayout {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    BackgroundColor = Color.White,
                    Margin = new Thickness(10, 0, 10, 0),
                    Children = { emptyLabel, boxView }
                };
                SVinBasket.Content = SLinEmptyBasket;
            }
        }

        private StackLayout renderUrunler()
        {
            StackLayout SLinSV = new StackLayout { //1
                Orientation = StackOrientation.Vertical,
            };

            List<int> urunlerinSayisi = new List<int>();//burası dinamik olarak gelecek
            int sepettekiUrunSayisi = UrunSayfasi.siralar.Count;
            int whichRow = 0;
            List<string> urunKonumlari = new List<string>();
            string urunsayisiLabeli = "Ürün {" + sepettekiUrunSayisi + "}";

            Label topLabel = new Label {
                Text = urunsayisiLabeli,
                FontSize = 16,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
            };
            SLinSV.Children.Add(topLabel);

            Grid gridSepet = new Grid();
            gridSepet.ColumnDefinitions.Add(new ColumnDefinition());
            Frame frameInGrid = new Frame
            {
                Margin = new Thickness(10),
                BorderColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
            };

            for (int i = 0; i < sepettekiUrunSayisi; i++)
            {
                gridSepet.RowDefinitions.Add(new RowDefinition());
                whichRow = i;

                StackLayout SLTop = new StackLayout();//2
                StackLayout SLTop2 = new StackLayout { Orientation= StackOrientation.Horizontal, };//3
                StackLayout SLTop3 = new StackLayout { Orientation = StackOrientation.Vertical, 
                    Margin=new Thickness(5,0,0,0), 
                };//4
                StackLayout SLTop4 = new StackLayout {Orientation = StackOrientation.Horizontal,
                    WidthRequest = 200,};//5
                StackLayout SLTop5 = new StackLayout { Orientation = StackOrientation.Vertical, };//6
                StackLayout SLTop6 = new StackLayout { Orientation = StackOrientation.Horizontal, };//7
                StackLayout SLTop7 = new StackLayout { Orientation = StackOrientation.Horizontal, };//7

                urunKonumlari.Add(erkekKoleksiyonPage.ImagePaths.ElementAt(UrunSayfasi.siralar.ElementAt(i)));
                string source = urunKonumlari.ElementAt(i);
                
                ImageButton imgBtnTop = new ImageButton {
                    Source = source,
                    BackgroundColor = Color.White,
                    BorderColor = Color.LightGray,
                    BorderWidth = 1,
                    HeightRequest = 230,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Start,
                };

                SLTop2.Children.Add(imgBtnTop);

                string indirimliFiyat = "79,99 TL";
                Label fiyatBilgisi = new Label {
                    Text = indirimliFiyat,
                    FontSize = 20,
                    TextColor = Color.FromHex("#b70333"),
                    FontAttributes = FontAttributes.Bold,
                };

                ImageButton sepettenCikar = new ImageButton
                {
                    Source = "close",
                    BackgroundColor = Color.Transparent,
                    HeightRequest = 20,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                };
                sepettenCikar.Clicked += sepettenCikar_Clicked;

                SLTop4.Children.Add(fiyatBilgisi);
                SLTop4.Children.Add(sepettenCikar);

                string indirimsizFiyat = "130,99 TL";
                Label indirimsizFiyatBilgisi = new Label
                {
                    Text = indirimsizFiyat,
                    FontSize = 20,
                    TextColor = Color.Gray,
                    HorizontalOptions = LayoutOptions.Fill,
                    WidthRequest = 100,
                    TextDecorations = TextDecorations.Strikethrough,
                    FontAttributes = FontAttributes.Bold,
                };

                string urunAdi = "Kuşe Kahverengi Kaban";
                Label urunAdiLabeli= new Label
                {
                    Text = urunAdi,
                    FontSize = 18,
                    TextColor = Color.Black,
                };
                Button kargoBedavaYazisi = new Button
                {
                    BackgroundColor = Color.Transparent,
                    WidthRequest = 140,
                    HeightRequest = 40,
                    Margin = new Thickness(0, 10, 0, 0),
                    BorderColor = Color.FromHex("#b70333"),
                    BorderWidth = 3,
                    TextColor = Color.FromHex("#b70333"),
                    Text = "Kargo Bedava",
                    FontSize = 16,
                    CornerRadius = 50,
                    HorizontalOptions = LayoutOptions.Start,
                };

                string urunBedeni = "Beden: M";
                Label urunBedeniLabeli= new Label
                {
                    Text = urunBedeni,
                    FontSize = 16,
                    TextColor = Color.Black,
                };

                SLTop5.Children.Add(indirimsizFiyatBilgisi);
                SLTop5.Children.Add(urunAdiLabeli);
                SLTop5.Children.Add(kargoBedavaYazisi);
                SLTop5.Children.Add(urunBedeniLabeli);

                ImageButton imgBtnEksi = new ImageButton
                {
                    Source = "remove",
                    BackgroundColor = Color.Transparent,
                    WidthRequest = 25,
                    Margin = new Thickness(0, 10, 0 ,0),
                };

                string suAnkiUrununSayisi = "Adet (1)";
                Label urunSayisiLabeli = new Label
                {
                    Text = suAnkiUrununSayisi,
                    FontSize = 16,
                    TextColor = Color.Black,
                    Margin = new Thickness(5,7,0,0),
                    VerticalOptions = LayoutOptions.Center,
                };

                ImageButton imgBtnArti = new ImageButton
                {
                    Source = "plus",
                    WidthRequest = 22,
                    BackgroundColor = Color.Transparent,
                    Margin = new Thickness(7, 4, 0, 0),
                };

                SLTop6.Children.Add(imgBtnEksi);
                SLTop6.Children.Add(urunSayisiLabeli);
                SLTop6.Children.Add(imgBtnArti);

                ImageButton hediyeButonu = new ImageButton
                {
                    Source = "giftBox",
                    WidthRequest = 25,
                    BackgroundColor = Color.Transparent,
                    HorizontalOptions = LayoutOptions.Start,
                    Margin = new Thickness(0,7, 0 ,0 ),
                };

                Label hediyePaketiLabeli = new Label
                {
                    Text = "Hediye Paketi",
                    FontSize = 17,
                    TextColor = Color.Black,
                    VerticalOptions = LayoutOptions.End,
                };

                SLTop7.Children.Add(hediyeButonu);
                SLTop7.Children.Add(hediyePaketiLabeli);

                SLTop3.Children.Add(SLTop4);
                SLTop3.Children.Add(SLTop5);
                SLTop3.Children.Add(SLTop6);
                SLTop2.Children.Add(SLTop3);
                SLTop.Children.Add(SLTop2);
                SLTop.Children.Add(SLTop7);

                frameInGrid.Content = SLTop;
                gridSepet.Children.Add(frameInGrid, 0, i);
            }

            gridSepet.RowDefinitions.Add(new RowDefinition());
            StackLayout fiyatSLTop = new StackLayout { Orientation = StackOrientation.Vertical, };
            StackLayout fiyatSLChild1 = new StackLayout { Orientation = StackOrientation.Horizontal, };
            StackLayout fiyatSLChild2 = new StackLayout { Orientation = StackOrientation.Horizontal, };
            StackLayout fiyatSLChild3 = new StackLayout { Orientation = StackOrientation.Horizontal, };
            StackLayout fiyatSLChild4 = new StackLayout { Orientation = StackOrientation.Horizontal, };

            Label siparisOzetiLabeli = new Label {
                Text = "Sipariş Özeti",
                TextColor = Color.FromHex("#b70333"),
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
            };
            fiyatSLTop.Children.Add(siparisOzetiLabeli);


            //fiyat bilgilerinin olduğu frame oluşturma
            //kdv toplamı - start
            Label ilkSatir1 = new Label
            {
                Text = "KDV Dahil Toplam",
                FontSize = 16,
                TextColor = Color.Black,
            };
            
            string toplamFiyat = "225,95";
            Label ilkSatir2 = new Label
            {
                Text = toplamFiyat,
                FontSize = 16,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };
            fiyatSLChild1.Children.Add(ilkSatir1);
            fiyatSLChild1.Children.Add(ilkSatir2);
            fiyatSLTop.Children.Add(fiyatSLChild1);
            //kdv toplamı - end


            //ürün indirim toplamı - start
            Label ikinciSatir1 = new Label
            {
                Text = "Ürün İndirim Toplamı",
                FontSize = 16,
                TextColor = Color.Black,
            };

            string toplamIndirim= "225,95";
            Label ikinciSatir2 = new Label
            {
                Text = toplamIndirim,
                FontSize = 16,
                TextColor = Color.FromHex("#b70333"),
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };
            fiyatSLChild2.Children.Add(ikinciSatir1);
            fiyatSLChild2.Children.Add(ikinciSatir2);
            fiyatSLTop.Children.Add(fiyatSLChild2);
            //ürün indirim toplamı - start

            //kampanya indirimi - start
            Label ucuncuSatir1 = new Label
            {
                Text = "Kampanya İndirimi",
                FontSize = 16,
                TextColor = Color.Black,
            };

            string kampanyaIndirimi = "225,95";
            Label ucuncuSatir2 = new Label
            {
                Text = kampanyaIndirimi,
                FontSize = 16,
                TextColor = Color.FromHex("#b70333"),
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };
            fiyatSLChild3.Children.Add(ucuncuSatir1);
            fiyatSLChild3.Children.Add(ucuncuSatir2);
            fiyatSLTop.Children.Add(fiyatSLChild3);
            //kampanya indirimi - start


            //kdv dahil toplam - start
            Label dorduncuSatir1 = new Label
            {
                Text = "Ödenecek Tutar",
                FontSize = 16,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
            };

            string odenecekTutar = "225,95";
            Label dorduncuSatir2 = new Label
            {
                Text = odenecekTutar,
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };
            fiyatSLChild4.Children.Add(dorduncuSatir1);
            fiyatSLChild4.Children.Add(dorduncuSatir2);
            //kdv dahil toplam - end

            fiyatSLTop.Children.Add(fiyatSLChild4);
            frameInGrid.Content = fiyatSLTop;
            gridSepet.Children.Add(frameInGrid, 0, whichRow + 1);//gride ekledik

            StackLayout indirimKuponuSL= new StackLayout();
            gridSepet.RowDefinitions.Add(new RowDefinition());
            Button indirimKuponuBtn = new Button
            {
                Text = "İndirim Kuponum Var",
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(-200, 0 , 0 , 0),
                WidthRequest = 350,
                FontSize = 18,
                TextColor = Color.FromHex("#b70333"),
            };
            indirimKuponuSL.Children.Add(indirimKuponuBtn);
            frameInGrid.Content = indirimKuponuSL;
            gridSepet.Children.Add(frameInGrid, 0, whichRow + 2);

            Button alisverisiTamamla = new Button {
                Text = "ALIŞVERİŞİ TAMAMLA",
                FontSize = 22,
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.FromHex("#b70333"),
                TextColor = Color.White,
            };

            SLinSV.Children.Add(gridSepet);
            MainStackLayout.Children.Add(alisverisiTamamla);
            return SLinSV;
        }

        private async void sepettenCikar_Clicked(object sender, EventArgs e)
        {
            //TODO: pop are you sure section
        }
    }
}