using System;
using System.Windows.Input;

namespace Odontology.ViewModels
{
    internal class RelayCommand : ICommand
    {
        private Action goToAddPatient;

        public RelayCommand(Action goToAddPatient)
        {
            this.goToAddPatient = goToAddPatient;
        }
    }
}