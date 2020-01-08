using System.ComponentModel.DataAnnotations;
namespace Model.User
{
    
    public class BizInfo
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public System.DateTime InputTime { get; set; }
        public string UnifiedCode { get; set; }
    }
}
