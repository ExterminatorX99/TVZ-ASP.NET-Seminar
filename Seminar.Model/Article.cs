using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Seminar.Model
{
    public class Article
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Summary { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public ArticleType Type { get; set; }
        
        [Required]
        public ArticleStatus Status { get; set; }

        public DateTime PublishDateTime { get; set; }

        [Display(Name = "Writer")]
        [ForeignKey(nameof(Writer))]
        [Required]
        public int WriterID { get; set; }

        [Display(Name = "Category")]
        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryID { get; set; }

        public virtual Writer Writer { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public string ContentTruncated => Content.Truncate(64);
    }

    public static class ArticleExtensions
    {
        /// <summary>
        ///     Includes
        ///     <see cref="Article.Writer" />
        ///     <see cref="Article.Category" />
        /// </summary>
        /// <param name="articles"></param>
        /// <returns></returns>
        public static IIncludableQueryable<Article, object> IncludeAll(this DbSet<Article> articles)
        {
            return articles
                .Include(a => a.Writer)
                .Include(a => a.Category);
        }
    }

    public enum ArticleType
    {
        News,
        Review
    }

    public enum ArticleStatus
    {
        Published,
        Reviewed,
        AwaitingReview,
        InWriting,
        Planned,
        Cancelled
    }
}
