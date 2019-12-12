using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.SP.IDBuilder
{
    public class IDCounter
    {
        [Key]
        public int ID { get; set; }
        public int Count1 { get; set; }
        public int Count2 { get; set; }
        public int Count3 { get; set; }
        public int Count4 { get; set; }
        public int Count5 { get; set; }
        public int Count6 { get; set; }
        public int Count7 { get; set; }
    }
}
