using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Models
{
    public class GraphicPostCategory
    {
        //many to many Relatioship
        [ForeignKey("GraphicPost")]
        public int GraphicPostId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public GraphicPost GraphicPost { get; set; }

        public Category Category { get; set; }
        //End many to many Relatioship

    }
}
