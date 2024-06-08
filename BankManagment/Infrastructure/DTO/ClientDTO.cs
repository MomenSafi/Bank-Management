using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string FullName { get; set; } = null!;
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]

        public string Mobile { get; set; } = null!;
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]

        public DateTime? DateOfBirth { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]

        public string? Address { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage ="This field is required")]
        public DateTime RegisterDate { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage ="This field is required")]
        public string NationalId { get; set; } = null!;
        public int? NationalityId { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage ="This field is required")]
        public string? PassportNumber { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage ="This field is required")]
        public string Email { get; set; } = null!;
    }
}
