

namespace Odontology.ViewModels
{
    using System.Windows.Input;
    using Galasoft.MvvmLight.Command;   
    using Views;
    using Xamarin.Forms;
    using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;

    public class MainViewModel
    {
        #region Properties
        public PatientViewModel Patient { get; set; }

        
        #endregion

        #region Constructors
        public MainViewModel()
        {
            this.Patient = new PatientViewModel();
        }
        #endregion
        public ICommand AddPatientComand
        {
            get
            {
                return new RelayCommand(GoToAddPatient);
            }
        }

        private async void GoToAddPatient()
        {
           await Application.Curren.Mainpage.Navigation.PushAsync(new AddPatientPage());
        }
    }
}
