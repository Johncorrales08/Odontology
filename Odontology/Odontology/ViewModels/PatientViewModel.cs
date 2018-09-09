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
    using Helpers;
    using System.Collections.ObjectModel;

    public class PatientViewModel : BaseViewModel
    { 

    #region attributes
    private ApiService apiService;
    private bool isRefreshing;
    private ObservableCollection<Patient> patient;
    #endregion

    #region properties
    public ObservableCollection<Patient> Patient
    {
        get { return this.patient; }
        set { this.SetValue(ref this.patient, value); }
    }

    public bool IsRefreshing
    {
        get { return this.isRefreshing; }
        set { this.SetValue(ref this.isRefreshing, value); }
    }
    #endregion


    #region constructor
    public PatientViewModel()
    {
        this.apiService = new ApiService();
        this.LoadPatient();
    }


    #endregion

    #region Methods
    private async void LoadPatient()
    {
        this.IsRefreshing = true;

        var connection = await this.apiService.CheckConnection();
        if (!connection.IsSuccess)
        {
            this.IsRefreshing = false;
            await Application.Current.MainPage.DisplayAlert(Languages.Error, connection.Message, Languages.Accept);
            return;
        }

        var url = Application.Current.Resources["UrlAPI"].ToString();
        var prefix = Application.Current.Resources["UrlPrefix"].ToString();
        var controller = Application.Current.Resources["UrlPatientController"].ToString();
        var response = await this.apiService.GetList<Patient>(url, prefix, controller);
        if (!response.IsSuccess)
        {
            this.IsRefreshing = false;
            await Application.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
            return;
        }

        var list = (List<Patient>)response.Result;
        this.Patient = new ObservableCollection<Patient>(list);
        this.IsRefreshing = false;


    }

    #endregion

}
}