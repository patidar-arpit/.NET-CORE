using System.ComponentModel.DataAnnotations;

namespace EmployeeDAL.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name {  get; set; }

        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

    }
}
