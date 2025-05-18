using System.ComponentModel.DataAnnotations;

namespace GymApplication.Models
{
    //public class PersonalInfromationViewModel
    //{
    //    public int Id { get; set; }

    //    public int GenderId { get; set; }


    //    [Required(ErrorMessage = "FirstName is required.")]
    //    [RegularExpression(@"^\S.*$", ErrorMessage = "FirstName should not start with a space.")]
    //    public string FirstName { get; set; }
    //    [Display(Name = ("Last Name"))]
    //    [Required(ErrorMessage = "LastName is required.")]
    //    [RegularExpression(@"^\S.*$", ErrorMessage = "LastName should not start with a space.")]

    //    public string LastName { get; set; }
    //    [Display(Name = ("Mobile Number"))]
    //    [Required(ErrorMessage = "Mobile Number is required.")]
    //    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must contain exactly 10 digits.")]
    //    public string MobileNumber { get; set; }

    //    [Required]
    //    [Display(Name = ("Email"))]
    //    public string Email { get; set; }

    //    public string ProfilePicture { get; set; }
    //    [Display(Name = ("Profile Picture"))]
    //    public IFormFile ProfilePictureImg { get; set; }
    //    public string GenderName { get; set; }
    //}
 
       

    public class GenderViewModel
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
    }

    //public class HealthHistoryViewModel
    //{
    //    public int Id { get; set; }
    //    public int PersonalInformationId { get; set; }
    //    [Required] public string Name { get; set; }
    //    public string Allergies { get; set; }
    //    public string Injuries { get; set; }
    //    public string Surgeries { get; set; }
    //    public string ChronicIllness { get; set; }
    //    public string AnyOtherConditions { get; set; }
    //}

    //public class WorkoutViewModel
    //{
    //    public int Id { get; set; }
    //    [Required] public string Name { get; set; }
    //    public DateTime Date { get; set; }
    //    public int PersonalInformationId { get; set; }
    //}

    //public class ExerciseViewModel
    //{
    //    public int Id { get; set; }
    //    [Required]
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public int CaloriesBurnedPerMin { get; set; }
    //}

    //public class DietViewModel
    //{
    //    public int Id { get; set; }
    //    [Required] public string Meal { get; set; }
    //    public int Calories { get; set; }
    //    public DateTime Date { get; set; }
    //    public int PersonalInformationId { get; set; }
    //}

    //public class GoalViewModel
    //{
    //    public int Id { get; set; }
    //    [Required] public string GoalType { get; set; }
    //    public double TargetWeight { get; set; }
    //    public DateTime TargetDate { get; set; }
    //    public int PersonalInformationId { get; set; }
    //}

    //public class ProgressViewModel
    //{
    //    public int Id { get; set; }
    //    public DateTime Date { get; set; }
    //    public double Weight { get; set; }
    //    public int CaloriesBurned { get; set; }
    //    public int PersonalInformationId { get; set; }
    //}
}

