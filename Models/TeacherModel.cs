using System.ComponentModel.DataAnnotations;

namespace Campus_Management_System.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "Please enter Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter Dept")]
        public string Semester { get; set; }
        public string Experience { get; set; }

        [Required(ErrorMessage = "please enter salary")]
        [Range(5000, 50000, ErrorMessage = "Value should be between 5k to 50k")]
        public int Salary { get; set; }
    }
}
