using System;
using System.Security.Cryptography;
using System.Text;

namespace TestJwt
{
    class Program
    {
        static void Main(string[] args)
        {
            string aa = "1234567";
            string bb = Encode32(aa);
            Console.WriteLine(bb);
            Console.ReadLine();
        }

        public static string Encode32(string inputValue)
        {
            using (var md5 = MD5.Create()) {
                byte[] result = md5.ComputeHash(Encoding.UTF8.GetBytes(inputValue));
                StringBuilder sb = new StringBuilder();                
                foreach (byte bItem in result)
                    sb.Append(bItem.ToString("X2"));
                return sb.ToString();
            }
        }
        static readonly char[] charList = {'0','1','2','3','4','5','6','7','8','9',
                                'A','B','C','D','E','F','G','H','I','J','K','L','M',
                                'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
                                'a','b','c','d','e','f','g','h','i','j','k','l','m',
                                'n','o','p','q','r','s','t','u','v','w','x','y','z'};
        public static String getRandStringEx(int length)
        {

            char[] rev = new char[length];
            Random f = new Random();
            for (int i = 0; i < length; i++) {
                rev[i] = charList[Math.Abs(f.Next(127-i%8)) % length];
            }
            return new String(rev);
        }
    }
}
