using System;
using System.Collections.Generic;
using System.Text;

namespace Model.User
{
    public class JwtSecret
    {
        public int ID { get; set; }

        public string SecretPre { get; set; }

        public string SecretCurrent { get; set; }

        public DateTime RefreshTime { get; set; }

    }
}
