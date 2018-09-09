using System;
using System.Collections.Generic;
using System.Text;

namespace Odontology.ViewModels
{
   
    using System.Windows.Input;
   
    using Views;
    using Xamarin.Forms;
    using ViewModels;

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

        
    }
}
