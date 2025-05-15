using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizUser : bizObject<bizUser>
    {
        private int _userid;
        private string _firstname = "";
        private string _lastname = "";
        private string _username = "";

        public int UserId
        {
            get { return _userid; }
            set
            {
                if (_userid != value)
                {
                    _userid = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string FirstName
        {
            get { return _firstname; }
            set
            {
                if (_firstname != value)
                {
                    _firstname = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string LastName
        {
            get { return _lastname; }
            set
            {
                if (_lastname != value)
                {
                    _lastname = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string UserName
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    InvokePropertyChanged();
                }
            }
        }

    }
}
