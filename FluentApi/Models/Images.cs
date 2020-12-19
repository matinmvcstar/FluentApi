using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Models
{
    public class Images
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "عکس پست")]
        [Required(ErrorMessage = "لطفا یک عکس برای پست جدید وارد کنید")]
        [DataType(DataType.ImageUrl)]
        public string ImagePost { get; set; }

        [Display(Name = "نام عکس")]
        [Required(ErrorMessage = "لطفا یک توضیح مختصر در مورد کار بفرمایید")]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string Text { get; set; }

        //One to Many Relatioship Images >> Graphic Post
        [ForeignKey("GraphicPost")]
        public int GraphicPostId { get; set; }

        public GraphicPost GraphicPost { get; set; }
    }
}
