using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Models
{
    public class NCategory
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام گروه خبر")]
        [MaxLength(50)]
        [Required(ErrorMessage = "لطفا گروه جدید برای بخش خبر را وارد کنید")]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }

        //one to one
        public News News { get; set; }
        //
    }
}
