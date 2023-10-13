using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AccountService
    {
        private readonly DataAccessLayer.AccountRepo _accountRepo;

        public AccountService()
        {
            _accountRepo = new DataAccessLayer.AccountRepo();
        }

        public DataSet AuthenticateUser(string UserName,string Password)
        {
            return _accountRepo.AuthenticateUser(UserName,Password);
        }
    }
}
