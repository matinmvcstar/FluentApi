using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Models
{
    public class FileUp
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "آدرس فایل")]
        [Required(ErrorMessage = "لطفا فایل خود را وارد کنید")]
        [DataType(DataType.Url)]
        public string UrlFile { get; set; }

        [Display(Name = "نام فایل")]
        [Required(ErrorMessage = "لطفا یک نام برای فایل جدید وارد کنید")]
        [DataType(DataType.Text)]
        [MaxLength(75)]
        public string NameFile { get; set; }
    }
}
