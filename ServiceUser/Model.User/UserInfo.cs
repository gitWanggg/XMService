using System.ComponentModel.DataAnnotations;
namespace Model.User
{
   
    public class UserInfo
    {
        [Key]
        public string ID { get; set; }      
        public System.DateTime InputTime { get; set; }
        public string NickName { get; set; }
    }
}
