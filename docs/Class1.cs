using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Stan0.Test
{
    public class Class1
    {
        public static string FormatUrl(string TmplUrl, Dictionary<string, string> QueryString)
        {
            try {

                MatchCollection Matchs = Regex.Matches(TmplUrl, @"\{\s*([\s\S]+?)\}", RegexOptions.IgnoreCase);
                List<string> pars = new List<string>();
                foreach (Match item in Matchs) {
                    string key = item.Groups[1].Value.Trim().Trim('\t').Trim(' ');
                    string repString = item.Groups[0].Value;
                    if (QueryString.ContainsKey(key)) {
                        TmplUrl = TmplUrl.Replace(item.Value, "{" + pars.Count + "}");
                        pars.Add(System.Web.HttpUtility.UrlEncode(QueryString[key]));
                    }
                }
                return string.Format(TmplUrl, pars.ToArray());
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
