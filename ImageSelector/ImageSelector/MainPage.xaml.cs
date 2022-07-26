using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImageSelector
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            //check if picking pictures is supported
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Pick Photo", "Picture picking is not supported", "Ok");
                return;
            }
            //To reduce picture size. Default is a very large picture
            var MediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            //Pick photo from gallery
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(MediaOptions);
            if (selectedImageFile == null)
            {
                await DisplayAlert("Pick Photo", "The picture you chose is null, please pick another", "Ok");
            }
            SelectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
        }
    }
}
