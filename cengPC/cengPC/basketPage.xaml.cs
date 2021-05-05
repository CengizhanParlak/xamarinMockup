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
        public ArrayList urunlerDizisi = new ArrayList();

        public basketPage(List<String> dosyaKonumlari)
        {                
            InitializeComponent();
            
            if (dosyaKonumlari.Count > 0)
            {
                FileImageSource objFileImageSource = dosyaKonumlari.ElementAt(0);
                Console.WriteLine("___________-elementat0: " + dosyaKonumlari.ElementAt(0));
                Console.WriteLine("___________objFileImageSource: " + objFileImageSource);
                //strFileName.Substring(6);

                Image newImage = new Image();
                try
                {
                    newImage.Source = objFileImageSource;
                }
                catch (Exception e) {
                    Console.WriteLine("errroroororororo");
                }
                urunlerLayout.Children.Add(newImage);
            }
            
            if (dosyaKonumlari.Count < 1) {
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

    }
}