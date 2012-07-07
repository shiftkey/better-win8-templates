using System;
using GridAppWithoutTheNoise.Common;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace GridAppWithoutTheNoise.DataModel
{
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class SampleDataCommon : BindableBase
    {
        static readonly Uri BaseUri = new Uri("ms-appx:///");

        protected SampleDataCommon(String uniqueId, String title, String subtitle, String imagePath, String description)
        {
            this.uniqueId = uniqueId;
            this.title = title;
            this.subtitle = subtitle;
            this.description = description;
            this.imagePath = imagePath;
        }

        string uniqueId = string.Empty;
        public string UniqueId
        {
            get { return uniqueId; }
            set { SetProperty(ref uniqueId, value); }
        }

        private string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string subtitle = string.Empty;
        public string Subtitle
        {
            get { return subtitle; }
            set { SetProperty(ref subtitle, value); }
        }

        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        private ImageSource image;
        private String imagePath;
        public ImageSource Image
        {
            get
            {
                if (image == null && imagePath != null)
                {
                    image = new BitmapImage(new Uri(BaseUri, imagePath));
                }
                return image;
            }

            set
            {
                imagePath = null;
                SetProperty(ref image, value);
            }
        }

        public void SetImage(String path)
        {
            image = null;
            imagePath = path;
            OnPropertyChanged("Image");
        }
    }
}