using System.ComponentModel.DataAnnotations;
namespace Model.User
{
    public class AuthPwd
    {
        [Key]
        public string ID { get; set; }
        public string Account { get; set; }
        public string PwdMD5 { get; set; }
        public System.DateTime InputTime { get; set; }
        public System.DateTime EditTime { get; set; }
        public int EditCount { get; set; }
    }
}
