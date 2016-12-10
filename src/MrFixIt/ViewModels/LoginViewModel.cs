using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrFixIt.ViewModels
{
    //login view form that is Not being built in DB as a new table (through migration)
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
