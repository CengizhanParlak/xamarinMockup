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
        static Datas bilgiler = new Datas();
        List<String> imagePathsHere = MainPage.imagePaths;
        

        public UrunSayfasi(ImageSource source)
        {
            //gelen bilgiler burada lokal olarak tanımlanacak. sepete ekle tuşuna basıldığında
            InitializeComponent();
            bilgiler.setSource(source);
        }

        private void SepeteEkle_Clicked(object sender, EventArgs e)
        {
            imagePathsHere.Add(bilgiler.getSource().ToString());
        }

        private void SepetClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new basketPage(imagePathsHere));
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