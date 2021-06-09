using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seminar.Model
{
    public class City
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Writer> Writers { get; set; }
    }
}
