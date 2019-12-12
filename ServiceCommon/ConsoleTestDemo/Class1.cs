using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestDemo
{
    public class Class1
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string this[string key]
        {
            get {
                return key;
            }
        }
    }
}
