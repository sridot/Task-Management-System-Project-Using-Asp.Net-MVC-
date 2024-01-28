using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagementSystem.Models;
using TaskManagementSystem.ViewModel;
using TaskManagementSystem.DLL;

namespace TaskManagementSystem.BLL
{
    public class AccountServices
    {
        private readonly AccountRepository accountRepository;
        public AccountServices()
        {
            accountRepository = new AccountRepository();
        }

        // Registration
        public bool Register(RegisterViewModel viewModel)
        {
            Users user = new Users() { Username = viewModel.Username, Password = viewModel.Password, RoleId = viewModel.RoleId };
            int i = accountRepository.CreateAccount(user);
            if (i > 0)
                return true;
            return false;
        }


        // Login
        public bool Login(LoginViewModel viewModel)
        {
            Users user = new Users() { Username = viewModel.Username, Password = viewModel.Password};
            return accountRepository.VerifyAccount(user);
        }
        
    }
}