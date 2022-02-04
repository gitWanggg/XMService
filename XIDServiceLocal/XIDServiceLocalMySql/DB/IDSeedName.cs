using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XIDServiceLocalMySql
{
   [Table("idseedname")]
    public class IDSeedName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //设置自增
        public int ID { get; set; }
       
        public string Name { get; set; }

        public int TotalCount { get; set; }
        public int DayCount { get; set; }
        public System.DateTime SeedDay { get; set; }
        public System.DateTime RefreshTime { get; set; }

    }
}
