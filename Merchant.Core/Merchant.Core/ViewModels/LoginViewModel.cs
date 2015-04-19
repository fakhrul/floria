using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Merchant.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private string _userName;
        private string _password;
        private readonly IDataService _dataService;
        private MvxCommand _loginCommand;


        public LoginViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public MvxCommand LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new MvxCommand(ExecuteLoginCommand)); }
        }

        private void ExecuteLoginCommand()
        {
            ShowViewModel<MainViewModel>();
        }
    }
}
