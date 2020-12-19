using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "عکس پست")]
        [Required(ErrorMessage = "لطفا یک عکس برای پست جدید وارد کنید")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [Display(Name = "عکس پست")]
        [Required(ErrorMessage = "لطفا عکس دوم را برای پست جدید وارد کنید")]
        [DataType(DataType.ImageUrl)]
        public string Image2 { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا یک عکس برای پست جدید وارد کنید")]
        [DataType(DataType.Text)]
        [MaxLength(200)]
        public string Header { get; set; }

        [Display(Name = "توضیحات بخش اول")]
        [Required(ErrorMessage = "لطفا یک توضیح مختصر در مورد خبر بفرمایید")]
        [DataType(DataType.Text)]
        public string Text { get; set; }

        [Display(Name = "توضیحات بخش دوم")]
        [Required(ErrorMessage = "لطفا یک توضیح مختصر برای بخش دوم در مورد خبر بفرمایید")]
        [DataType(DataType.Text)]
        public string Text2 { get; set; }

        [Display(Name = "توضیحات بخش سوم")]
        [Required(ErrorMessage = "لطفا یک توضیح مختصر برای بخش دوم در مورد خبر بفرمایید")]
        [DataType(DataType.Text)]
        public string Text3 { get; set; }

        [Display(Name = "تاریخ درج مطلب")]
        [DataType(DataType.Date)]
        public DateTime CreateSlide { get; set; }

        [Display(Name = "نمایش/عدم نمایش")]
        public bool Active { get; set; }


        //one to many relationship
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        public Customer Customer { get; set; }
        //

        [NotMapped]
        [Display(Name = "توضیحات کامل")]
        public string FullText
        {
            get
            {
                return $"{Text} {Text2} {Text3}";
            }
        }

        //one to one relationship
        [ForeignKey("NCategory")]
        public int NCategoryId { get; set; }

        public NCategory NCategory { get; set; }
    }
}
