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
            this.Content = this.BuildView();
        }

        // asset'te bulunan embedded image'ı alma kodu. Source yazan yer fotoğrafın kaynağını belirtiyor.
        // işlem sonunda embeddedImage = source'dan gelen fotoğraf
        Image embeddedImage = new Image
        {
            Source = ImageSource.FromResource("cengPC.Resources.assets.beyaztshirt.jpg", typeof(erkekKoleksiyonPage).GetTypeInfo().Assembly)
        };

        private Layout BuildView()
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
            Grid grid = CreateGrids(ImagesInFolder, ImagePaths);


            //buraya filtrele, sırala seçenekleri ve kaç ürün gösterildiği bilgisi eklenecek.
                StackLayout stackHeaderInv = new StackLayout()
                {
                    Padding = new Thickness(0, 10),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.Red,
                };
            //filtre - end




            /*ImageButton btnComplete = new ImageButton() { Source = "_beyaztshirt",
                BackgroundColor = Color.White,
                BorderColor = Color.White,
                BorderWidth = 0,
                HeightRequest = 250,
                WidthRequest = 250,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            btnComplete.Clicked += ImageClicked;

            //stackHeaderInv.Children.Add(CustomControl);

            StackLayout stackAll = new StackLayout()
            {
                Padding = 0,
                Spacing = 0,
                Children =
                { stackHeaderInv, btnComplete }
            };
            scrollViewArea.Content = stackAll;*/
            
            scrollViewArea.Content = grid;
            return scrollViewArea;
        }


        public Grid CreateGrids(int imageCount, List<String> ImagePaths){
            int TotalRow = imageCount / 2; //5 image varsa 5/2 = 2 + 1 = 3'ten 3 tane satır oluştururuz.
            String UrunPath;
            Grid g = new Grid();
            g.ColumnDefinitions.Add(new ColumnDefinition());
            g.ColumnDefinitions.Add(new ColumnDefinition());
            /*g.RowDefinitions.Add(new RowDefinition()); //önceden satır sayısı belirlemek için bu şekilde yazıyor
            g.RowDefinitions.Add(new RowDefinition());
            g.RowDefinitions.Add(new RowDefinition());*/

            for (int rowIndex = 0; rowIndex < TotalRow; rowIndex++)
            {
                g.RowDefinitions.Add(new RowDefinition());
                for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                {
                    UrunPath = ImagePaths.ElementAt(rowIndex * 2 + columnIndex);
                    ImageButton UrunButonu = new ImageButton()
                    {
                        Source = UrunPath,
                        BackgroundColor = Color.White,
                        BorderColor = Color.White,
                        BorderWidth = 0,
                        HeightRequest = 250,
                        WidthRequest = 250,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                    };
                    UrunButonu.Clicked += ImageClicked;
                    g.Children.Add(UrunButonu, columnIndex, rowIndex);
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
                    g.Children.Add(UrunLabeli, columnIndex, rowIndex);
                    g.Children.Add(UrunFiyati, columnIndex, rowIndex);
                }
            }
            return g;
        }

        private void ImageClicked(object sender, EventArgs e)
        {
            Console.WriteLine("yeni sezon->erkek->fotoğraf tıklandı");
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