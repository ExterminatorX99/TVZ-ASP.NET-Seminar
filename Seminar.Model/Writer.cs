using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [MaxLength(256)]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(City))]
        public int CityID { get; set; }

        public City City { get; set; }

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

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
