using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Seminar.Model
{
    public class Writer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(City))]
        [Required]
        public int CityID { get; set; }

        public virtual City City { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public virtual ICollection<Article> Articles { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Work experience must be between 0 and 100.")]
        public int? WorkingExperience { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
    }

    public static class WriterExtensions
    {
        /// <summary>
        ///     Includes
        ///     <see cref="Article.Writer" />
        ///     <see cref="Article.Category" />
        ///     <see cref="Article.HeaderImage" />
        /// </summary>
        /// <param name="writers"></param>
        /// <returns></returns>
        public static IIncludableQueryable<Writer, object> IncludeAll(this DbSet<Writer> writers)
        {
            return writers
                .Include(w => w.City);
        }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
