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
        public UrunSayfasi(ImageButton imgBtn)
        {
            InitializeComponent();
            ImageButton selectedImgBtn = imgBtn;
            SLinContent.Children.Add(selectedImgBtn);
        }

    }
}