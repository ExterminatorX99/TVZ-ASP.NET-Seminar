using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seminar.Model
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        // Category can have multiple Articles
        public virtual ICollection<Article> Articles { get; set; }
    }
}
