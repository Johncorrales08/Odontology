

namespace Odontology.ViewModels
{
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MainViewModel
    {
        #region Properties
        public PatientViewModel Patient { get; set; }

        public AddPatientViewModel AddPatient { get; set; }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            this.Patient = new PatientViewModel();
        }
        #endregion
    public ICommand AddPatientCommand
        {
            get
            {
                return new RelayCommand(GoToAddPatient);
            }
        }

        private async void GoToAddPatient()
        {
            this.AddPatient = new AddPatientViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new PatientPage());
        }
    }
}
