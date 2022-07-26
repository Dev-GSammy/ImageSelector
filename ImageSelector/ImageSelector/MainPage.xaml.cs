using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Permissions;

namespace ImageSelector
{
    /// <summary>
    /// Coder: Samuel T. Fatunmbi (Dev_GSammy)
    /// In case, God forbid, I don't later understand the code I myself wrote in times to come, this code does the sole work
    /// of picking an image from gallery. I should, if I have the time, create other tabs that do the same for single video
    /// pictures and videos, and also for taking real time pictures and images. 
    /// After getting the data needed, we upload it to the cloud with and return a stream of bits (url) representing the data received 
    /// it could be typed into a browser and a download link will appear to download the image.
    /// </summary>
    
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
