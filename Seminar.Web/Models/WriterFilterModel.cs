using Seminar.Model;

namespace Seminar.Web.Models
{
    public class WriterFilterModel
    {
        public string FullName { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string CityName { get; set; }
    }
}
