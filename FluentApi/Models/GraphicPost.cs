using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Models
{
    public class GraphicPost
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "عکس پست")]
        [Required(ErrorMessage = "لطفا یک عکس برای پست جدید وارد کنید")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا یک عکس برای پست جدید وارد کنید")]
        [DataType(DataType.Text)]
        [MaxLength(200)]
        public string Header { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا یک توضیح مختصر در مورد کار بفرمایید")]
        [DataType(DataType.Text)]
        public string Text { get; set; }

        [Display(Name = "هزینه سفارش")]
        [Required(ErrorMessage = "لطفا محدوده هزینه طراحی کار را بفرمایید")]
        [DataType(DataType.Currency)]
        public long Price { get; set; }

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

        //many to many Relatioship
        public virtual ICollection<GraphicPostCategory> PostCategories { get; set; }

        //One to many RelationShip Images to GraphicPost
        public List<Images> Images { get; set; }
    }
}
