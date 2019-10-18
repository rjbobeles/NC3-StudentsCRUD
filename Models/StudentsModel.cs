using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace studentsCRUD.StudentsModel
{
    public class Student 
    {
        [Key]
        public int StudentID {get; set;}
    
        [Required(ErrorMessage = "This field is required")]
        [Range(10000000, 99999999, ErrorMessage = "Invalid ID Number")]
        [Display(Name = "ID Number")]
        public int IDNumber {get; set;}

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(256)]
        [Display(Name = "First Name")]
        public string Firstname {get; set;}

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(256)]
        [Display(Name = "Last Name")]
        public string Lastname {get; set;}

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(256)]
        [Display(Name = "Middle Name")]
        public string MiddleName {get; set;}

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(256)]
        public string Email {get; set;}

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(256)]
        public string Course {get; set;}
        
        //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\\
        public virtual StudentInfo StudentInfo {get; set;}
    }

    public class StudentInfo
    {
        [ForeignKey("Student")]
        public int StudentInfoID { get; set; }

        public virtual Student Student {get; set;}

        //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\\
        [MaxLength(256)]
        public string Address {get; set;}

        [MaxLength(256)]
        public string City {get; set;}

        [Display(Name = "Zip Code")]
        public int? Zip {get; set;}

        [MaxLength(256)]
        public string Country {get; set;}

        [MaxLength(256)]
        [Display(Name = "Phone Number")]
        public string Phone {get; set;}
    }

    public class StudentClasses
    {
        public Student stud {get; set;}
        public StudentInfo studInfo {get; set;}
    }
}