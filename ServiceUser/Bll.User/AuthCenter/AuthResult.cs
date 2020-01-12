using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.User.AuthCenter
{
    public class AuthResult
    {
        public int Code { get; set; }

        public string UserID { get; set; }

        public string ErrorMsg { get; set; }
    }
}
