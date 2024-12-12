using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key] 
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogDate { get; set; }
        public bool BlogStatus{ get; set; }
        //bir blog bir kategoriye bağlı olmak zorunda
        public int CategoryId { get; set; }//buranın category sınıfındaki CategoryId ile aynı olmak zorunda
        public Category Category { get; set; }
        //Bir bloga birden fazla yorum yapılabilir
        public List<Comment>Comments { get; set; }
        //bir blog bir yazara aittir
        public int? WriterId { get; set; }
        public Writer Writer { get; set; }
    }
}
