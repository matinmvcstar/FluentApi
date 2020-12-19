using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Models
{
    public class CoLogo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "لوگو شرکت")]
        [Required(ErrorMessage = "لطفا لوگو شرکا را وارد کنید")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [Display(Name = "نام شرکت")]
        [Required(ErrorMessage = "لطفا نام شرکت را وارد کنید")]
        [DataType(DataType.Text)]
        [MaxLength(75)]
        public string Company { get; set; }

        [Display(Name = "آدرس شرکت")]
        [Required(ErrorMessage = "لطفا آدرس شرکت را وارد کنید")]
        [DataType(DataType.Text)]
        [MaxLength(450)]
        public string Address { get; set; }

        [Display(Name = "آدرس شرکت")]
        [Required(ErrorMessage = "لطفا تلفن شرکت را وارد کنید")]
        [DataType(DataType.Text)]
        [MaxLength(10)]
        public string Tell { get; set; }
    }
}
