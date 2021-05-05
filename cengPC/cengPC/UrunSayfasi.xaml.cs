using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cengPC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UrunSayfasi : ContentPage
    {

        public static List<int> siralar = new List<int>();
        public static int holder;

        public UrunSayfasi(ImageButton source, int index)
        {
            ImageButton imageToShow = source;
            InitializeComponent();
            SLinContent.Children.Add(imageToShow);
            holder = index;
        }

        private void SepeteEkle_Clicked(object sender, EventArgs e)
        {
            siralar.Add(holder);
        }

        private void SepetClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new basketPage());
        }

    }

    public class Datas{
        ImageSource source { get; set; }
        string urunAdi { get; set; }
        string fiyat { get; set; }

        public void AddInfos(ImageSource kaynakDosya, string urunIsmi, string urunFiyati) {
            this.source = kaynakDosya;
            this.urunAdi = urunIsmi;
            this.fiyat = urunFiyati;
        }
        public void setSource(ImageSource imgSource) {
            source = imgSource;
        }
        public ImageSource getSource() {
            return source;
        }
    }
}