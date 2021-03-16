using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MerchantCommon.Server.WxService.Core
{
    class FormatPlaceholder : ITmplFormat
    {
        public string Format(string TmplString, Dictionary<string, string> DevValues)
        {
            if (string.IsNullOrEmpty(TmplString))
                return "";
            TmplString = TmplString.Replace("\\n", "\n");
            MatchCollection Matchs = Regex.Matches(TmplString, @"\{\{\s*=([\s\S]+?)\}\}", RegexOptions.IgnoreCase);
            foreach (Match item in Matchs) {
                string key = item.Groups[1].Value.Trim().Trim('\t').Trim(' ');
                string repString = item.Groups[0].Value;
                if (DevValues != null && DevValues.Keys.Contains(key))
                    TmplString = TmplString.Replace(repString, DevValues[key]);

            }
            return TmplString;
        }
    }
}
