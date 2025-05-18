

using System.ComponentModel.DataAnnotations;
namespace GymApplication.Models
{
    public class PersonalInformationViewModel
    {
        public int Id { get; set; }

        // Gender Information
        public int GenderId { get; set; }
        public string GenderName { get; set; }

        // Personal Details
       // [Required(ErrorMessage = "First name is required.")]
        //[RegularExpression(@"^\S.*$", ErrorMessage = "First name should not start with a space.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
       // [Required(ErrorMessage = "Last name is required.")]
        //[RegularExpression(@"^\S.*$", ErrorMessage = "Last name should not start with a space.")]
        public string LastName { get; set; }

        [Display(Name = "Mobile Number")]
        //[Required(ErrorMessage = "Mobile number is required.")]
        //[RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must contain exactly 10 digits.")]
        public string MobileNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
    //    [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        // Profile Picture
        public string ProfilePicture { get; set; }

        [Display(Name = "Profile Picture")]
        public IFormFile ProfilePictureImg { get; set; }

        // Health & Fitness Information
        public int AgeGroupId { get; set; }
        public int BodyTypeId { get; set; }
        public int BodyGoalId { get; set; }
        public int TargetBodyId { get; set; }
        public int StepDietId { get; set; }
        public int StepWaterId { get; set; }
        public int StepWorkoutId { get; set; }
        public int AdditionalGoalId { get; set; }
        public int WorkoutFrequencyId { get; set; }

        // Physical Attributes
       // [Required(ErrorMessage = "Height is required.")]
        //[Range(80, 300, ErrorMessage = "Height must be between 80 and 300 cm.")]
        public decimal Height { get; set; }

 //       [Required(ErrorMessage = "Weight is required.")]
   //     [Range(25, 500, ErrorMessage = "Weight must be between 0 and 500 kg.")]
        public decimal Weight { get; set; }
        //Display
        public string AgeGroupName { get; set; }
        public string BodyTypeName { get; set; }
        public string BodyGoalName { get; set; }
        public string TargetBodyName { get; set; }
        public string StepDietName { get; set; }
        public string StepWaterName { get; set; }
        public string StepWorkoutName { get; set; }
        public string AdditionalGoalName { get; set; }
        public string WorkoutFrequencyName { get; set; }

        //Security

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password must be between {2} and {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string UserRole { get; set; }
        public string UserRoleId { get; set; }

        public List<AgeGroupViewModel> AgeGroupList { get; set; } = new List<AgeGroupViewModel>();
        public List<BodyTypeViewModel> BodyTypeList { get; set; } = new List<BodyTypeViewModel>();
        public List<BodyGoalViewModel> BodyGoalList { get; set; } = new List<BodyGoalViewModel>();
        public List<TargetBodyViewModel> TargetBodyList { get; set; } = new List<TargetBodyViewModel>();
        public List<ProblemAreaViewModel> ProblemAreaList { get; set; } = new List<ProblemAreaViewModel>();
        public List<StepDietViewModel> StepDietList { get; set; } = new List<StepDietViewModel>();
        public List<StepWaterViewModel> StepWaterList { get; set; } = new List<StepWaterViewModel>();
        public List<StepWorkoutViewModel> StepWorkoutList { get; set; } = new List<StepWorkoutViewModel>();
        public List<AdditionalGoalViewModel> AdditionalGoalList { get; set; } = new List<AdditionalGoalViewModel>();
        public List<WorkoutFrequencyViewModel> WorkoutFrequencyList { get; set; } = new List<WorkoutFrequencyViewModel>();
    }


    public class PersonalInformationProblemAreasViewModel
    {
        public int Id { get; set; }

        [Required]
        public int PersonalInformationId { get; set; }

        [Required]
        public int ProblemAreaId { get; set; }

        // Display Names
        public string PersonalInformationName { get; set; }
        public string ProblemAreaName { get; set; }
    }
}
