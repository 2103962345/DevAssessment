using DevAssessment.DependencyService;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DevAssessment.ViewModel
{
    public class DSPageViewModel : BindableBase
    {
        private readonly ITextToSpeechService _textToSpeech;

        private readonly IDeviceOrientationService _deviceOrientation;

        private readonly IPhotoPickerService _photoPicker;

        public DSPageViewModel(ITextToSpeechService textToSpeech, IDeviceOrientationService deviceOrientation, IPhotoPickerService photoPicker)
        {
            _textToSpeech = textToSpeech;
            _deviceOrientation = deviceOrientation;
            _photoPicker = photoPicker;

            OnSpeakCommandClicked = new DelegateCommand(Speak);
            OnOrientationCommandClicked = new DelegateCommand(GetOrientation);
            OnPhotoPickerCommandClicked = new DelegateCommand(PickPhoto);
        }


        public DelegateCommand OnSpeakCommandClicked { get; set; }
        public DelegateCommand OnOrientationCommandClicked { get; set; }
        public DelegateCommand OnPhotoPickerCommandClicked { get; set; }

        private string _textToSay;
        public string TextToSay
        {
            get { return _textToSay; }
            set { SetProperty(ref _textToSay, value); }
        }

        private string _showOrientation;
        public string ShowOrientation
        {
            get { return _showOrientation; }
            set { SetProperty(ref _showOrientation, value); }
        }

        private ImageSource _image;
        public ImageSource Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }



        private void Speak()
        {
             _textToSpeech.SpeakAsync(TextToSay);
        }

        private void GetOrientation()
        {
            var orientation = _deviceOrientation.GetOrientation();
            ShowOrientation = orientation.ToString();
        }

        private async void PickPhoto()
        {
            var imageStream = await _photoPicker.GetImageStreamAsync();
            if(imageStream != null)
            {
                Image = ImageSource.FromStream(() => imageStream);
            }
        }
    }
}