using System;
using System.Collections.Generic;
using System.Text;

namespace Odontology.Helpers
{
    using Xamarin.Forms;
    using Interfaces;
    using Resources;

    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept
        {
            get { return Resource.Accept; }
        }
        public static string TurnOnInternet
        {
            get { return Resource.TurOnInternet; }
        }
        public static string Error
        {
            get { return Resource.Error; }
        }

        public static string Patients
        {
            get { return Resource.Patients; }
        }
        public static string AddPatient
        {
            get { return Resource.AddPatient; }
        }
        public static string firstNamePlaceholder
        {
            get { return Resource.firstNamePlaceholder; }
        }
        public static string lastnamelastnamePlaceholder
        {
            get { return Resource.lastnamePlaceholder; }
        }
        public static string lastname
        {
            get { return Resource.lastname; }
        }
    
    }


}