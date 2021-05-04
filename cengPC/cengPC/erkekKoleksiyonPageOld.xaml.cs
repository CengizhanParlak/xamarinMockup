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
    /*[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class erkekKoleksiyonPageOld : ContentPage
    {
        public erkekKoleksiyonPageOld()
        {
            InitializeComponent();
        }

        // asset'te bulunan embedded image'ı alma kodu. Source yazan yer fotoğrafın kaynağını belirtiyor.
        // işlem sonunda embeddedImage = source'dan gelen fotoğraf
        Image embeddedImage = new Image
        {
            Source = ImageSource.FromResource("cengPC.Resources.assets.beyaztshirt.jpg", typeof(erkekKoleksiyonPage).GetTypeInfo().Assembly)
        };
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
    }*/
}