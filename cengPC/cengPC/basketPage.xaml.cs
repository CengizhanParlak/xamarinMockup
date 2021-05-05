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
            List<string> urunKonumlari = new List<string>();

            if (UrunSayfasi.siralar.Count > 0)
            {
                for (int i = 0; i < UrunSayfasi.siralar.Count; i++)
                {
                    urunKonumlari.Add(erkekKoleksiyonPage.ImagePaths.ElementAt(UrunSayfasi.siralar.ElementAt(i)));
                    Image newImage = new Image {
                        Source = urunKonumlari.ElementAt(i),
                    };
                urunlerLayout.Children.Add(newImage);
                }
                
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

    }
}