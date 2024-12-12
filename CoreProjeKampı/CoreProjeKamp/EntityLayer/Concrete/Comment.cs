using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string UserName { get; set; }
        public string CommentMail { get; set; }
        public string CommentContent { get; set; }
        public int BlogRating { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }
        //bir bloga ait bir yorum yapılabilir
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
