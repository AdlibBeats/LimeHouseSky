using LimeHouseSky.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimeHouseSky.Models.Account
{
    public class AccountModel : BaseModel
    {
        private string _status;
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }

        private string _aboutYourself;
        public string AboutYourself
        {
            get => _aboutYourself;
            set => Set(ref _aboutYourself, value);
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => Set(ref _firstName, value);
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => Set(ref _lastName, value);
        }

        private string _gender;
        public string Gender
        {
            get => _gender;
            set => Set(ref _gender, value);
        }

        private int _age;
        public int Age
        {
            get => _age;
            set => Set(ref _age, value);
        }

        private string _city;
        public string City
        {
            get => _city;
            set => Set(ref _city, value);
        }
    }
}
