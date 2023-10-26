using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Models

{
    public class Contact
    {

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "First Name is a Required field.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last Name is a Required field.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Full Name is a Required field.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Address is a Required field.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is a Required field.")]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$", ErrorMessage = "Email is required and must be properly formatted.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is a Required field.")]
        [RegularExpression("((?:\\+|00)[17](?: |\\-)?|(?:\\+|00)[1-9]\\d{0,2}(?: |\\-)?|(?:\\+|00)1\\-\\d{3}(?: |\\-)?)?(0\\d|\\([0-9]{3}\\)|[1-9]{0,3})(?:((?: |\\-)[0-9]{2}){4}|((?:[0-9]{2}){4})|((?: |\\-)[0-9]{3}(?: |\\-)[0-9]{4})|([0-9]{7}))", ErrorMessage = "Phone is required and must be properly formatted.")]
        public string MobilePhoneNumber { get; set; }

        public int UserId { get; set; }

    }
}
