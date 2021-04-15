using System;
using System.Collections.Generic;
using System.Text;

namespace X.SDKApp
{

    public class UrlBuilder
    {
        /// <summary>
        /// x_appid={0}&x_ts={1}&t_data={2}&t_sign={3}
        /// </summary>
        StringBuilder URL;

        public UrlBuilder()
        {
            URL = new StringBuilder();
        }

        public override string ToString()
        {
            return URL.ToString();
        }
        
    }
}
