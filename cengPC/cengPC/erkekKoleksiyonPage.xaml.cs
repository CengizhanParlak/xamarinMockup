using System;
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
        public erkekKoleksiyonPage()
        {
            InitializeComponent();
            scrollViewArea.Content = this.BuildView();
        }

        // asset'te bulunan embedded image'ı alma kodu. Source yazan yer fotoğrafın kaynağını belirtiyor.
        // işlem sonunda embeddedImage = source'dan gelen fotoğraf
        Image embeddedImage = new Image
        {
            Source = ImageSource.FromResource("cengPC.Resources.assets.beyaztshirt.jpg", typeof(erkekKoleksiyonPage).GetTypeInfo().Assembly)
        };

        private StackLayout BuildView()
        {
            int ImagesInFolder;
            List<String> ImagePaths = new List<String>();
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
            //< Frame >
            //                < StackLayout >
            //                    < ImageButton  Source = "{local:ImageResource cengPC.Resources.assets.beyaztshirt.jpg}" Grid.Row = "0" Grid.Column = "0"
            //                 BackgroundColor = "White" BorderColor = "White" BorderWidth = "0"
            //                 HeightRequest = "250" HorizontalOptions = "Center" VerticalOptions = "Center" />

            //                        < Label Text = "Açık Kahverengi Standart.." ></ Label >

            //                         < Label Text = "999,95 TL" ></ Label >

            //                      </ StackLayout >

            //                  </ Frame >
            for (int rowIndex = 0; rowIndex < TotalRow; rowIndex++)
            {
                g.RowDefinitions.Add(new RowDefinition());//yeni satır ekliyoruz
                for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                {
                    frameInGrid = new Frame();
                    stackLayoutInFrame = new StackLayout();
                    UrunPath = ImagePaths.ElementAt(rowIndex * 2 + columnIndex);


                    //Image button yaratıyoruz
                    ImageButton UrunButton = new ImageButton()
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


        private void UrunButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UrunSayfasi());
        }
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