//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.SP.IDBuilder
{
    
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class IDSeedName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //设置自增
        public int ID { get; set; }
        public string AppID { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 持久化类型，0内存型，1硬盘型
        /// </summary>
        public int DurableTye { get; set; }
    }
}