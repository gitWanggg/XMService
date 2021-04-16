using System;
using System.Collections.Generic;
using System.Text;
using X.SDKApp;

namespace X.AppSvr
{
   public class PreToken: Token, ISecretInfo
    {
        public int ID { get; set; }
       
        public string SecretPre { get; set; }


        public string SecretCurrent => this.Secret;

        public string SecretPrevious => this.SecretPre;
    }
}
