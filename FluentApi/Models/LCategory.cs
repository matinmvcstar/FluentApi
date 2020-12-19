using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Models
{
    public class LCategory
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام گروه آموزشی")]
        [MaxLength(50)]
        [Required(ErrorMessage = "لطفا گروه جدید برای بخش آموزش را وارد کنید")]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }

        //many to many Relatioship
        public List<LearnPost> LearnPosts { get; set; }
    }
}
