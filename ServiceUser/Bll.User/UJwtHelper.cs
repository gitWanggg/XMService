using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.User
{
    static class UJwtHelper
    {
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
                rev[i] = charList[Math.Abs(f.Next(127 - i % 8)) % length];
            }
            return new String(rev);
        }
    }
}
