using System;
using System.Collections.Generic;
using System.Text;

namespace X.AppSvr
{
    class AppSecretSvr
    {
        public int ID { get; set; }
        public string Secret { get; set; }
        public string SecretPre { get; set; }      
        public System.DateTime TimeOutTime { get; set; }
    }
}
