using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage ="This field is required")]
        public string FullName { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Mobile { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Address { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Email { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public DateTime JoinDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public decimal Salary { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public int QualificationId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
