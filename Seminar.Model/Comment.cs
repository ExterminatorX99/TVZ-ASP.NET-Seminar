using System.ComponentModel.DataAnnotations.Schema;

namespace Seminar.Model
{
    public class Comment
    {
        public int ID { get; set; }

        public string Author { get; set; }

        public string Text { get; set; }

        [ForeignKey(nameof(Article))]
        public int ArticleID { get; set; }

        public virtual Article Article { get; set; }
    }
}
