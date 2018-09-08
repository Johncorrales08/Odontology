using System;
using System.Collections.Generic;
using System.Text;

namespace Odontology.ViewModels

{
    using System;
    using System.Linq;
    using System.Windows.Input;
    using Odontology.Models;
    using Services;
    using Xamarin.Forms;

    public class PatientViewModel : BaseViewModel
    {
        #region Attributes
        private MediaFile file;

        private ImageSource imageSource;

        private ApiService apiService;

        private bool isRunning;

        private bool isEnabled;
        #endregion

        #region Properties
        public int PatientId { get; set; }

        public int PatientId { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Address { get; set; }


        public string Phone { get; set; }


        public DateTime PatientSince { get; set; }


        public string TreatmentDescription { get; set; }


        public string ImagePath { get; set; }


        public bool HasAllergies { get; set; }


        public bool IsRunning
        {
            get { return this.isRunning; }
            set { this.SetValue(ref this.isRunning, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }

        public ImageSource ImageSource
        {
            get { return this.imageSource; }
            set { this.SetValue(ref this.imageSource, value); }
        }
        #endregion

        #region Constructors
        public PatientViewModel()
        {
            this.apiService = new ApiService();
            this.IsEnabled = true;
            this.ImageSource = "noproduct";
        }
        #endregion

        #region Commands
       /* public ICommand ChangeImageCommand
        {
            get
            {
                return new RelayCommand(ChangeImage);
            }
        }*/

        /*private async void ChangeImage()
        {
            await CrossMedia.Current.Initialize();

            var source = await Application.Current.MainPage.DisplayActionSheet(
                Languages.ImageSource,
                Languages.Cancel,
                null,
                Languages.FromGallery,
                Languages.NewPicture);

            if (source == Languages.Cancel)
            {
                this.file = null;
                return;
            }

            if (source == Languages.NewPicture)
            {
                this.file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "test.jpg",
                        PhotoSize = PhotoSize.Small,
                    }
                );
            }
            else
            {
                this.file = await CrossMedia.Current.PickPhotoAsync();
            }

            if (this.file != null)
            {
                this.ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = this.file.GetStream();
                    return stream;
                });
            }
        }


        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(Save);
            }
        }

        private async void Save()
        {
            if (string.IsNullOrEmpty(this.Description))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.DescriptionError,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(this.Price))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PriceError,
                    Languages.Accept);
                return;
            }

            var price = decimal.Parse(this.Price);
            if (price < 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PriceError,
                    Languages.Accept);
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    connection.Message,
                    Languages.Accept);
                return;
            }

            byte[] imageArray = null;
            if (this.file != null)
            {
                imageArray = FilesHelper.ReadFully(this.file.GetStream());
            }*/

            var Patient = new Patient
            {
                PatientId = ,
                FirstName = this.FirstName,
                LastName = this.Remarks,
                Address = imageArray,
                Phone=this.
            };

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlProductsController"].ToString();
            var response = await this.apiService.Post(url, prefix, controller, product);

            if (!response.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    response.Message,
                    Languages.Accept);
                return;
            }

            var newProduct = (Product)response.Result;
            var productsViewModel = ProductsViewModel.GetInstance();
            productsViewModel.MyProducts.Add(newProduct);
            productsViewModel.RefreshList();

            this.IsRunning = false;
            this.IsEnabled = true;
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion
    }
}

