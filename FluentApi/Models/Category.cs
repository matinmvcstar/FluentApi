using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام گروه")]
        [MaxLength(50)]
        [Required(ErrorMessage = "لطفا گروه جدید برای بخش گرافیک را وارد کنید")]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }

        //many to many Relatioship
        public virtual ICollection<GraphicPostCategory> PostCategories { get; set; }
    }
}
