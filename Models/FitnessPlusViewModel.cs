using System.ComponentModel.DataAnnotations;

namespace GymApplication.Models
{
    public class AgeGroupViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public IFormFile Image { get; set; }
    }

    public class BodyTypeViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }


        public string ImageUrl { get; set; }

        public IFormFile Image { get; set; }
    }
    public class BodyGoalViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }

    public class TargetBodyViewModel
    {
        public int Id { get; set; }

        [Required]
        public int BodyGoalId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }

        // Navigation Property
        public string BodyGoalName { get; set; }
    }

    public class ProblemAreaViewModel
    {
        public int Id { get; set; }

        [Required]
        public int TargetBodyId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }

        // Navigation Property
        public string TargetBodyName { get; set; }
    }

    public class StepDietViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }

    public class StepWaterViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }

    public class StepWorkoutViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }

    public class AdditionalGoalViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }

    public class WorkoutFrequencyViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }


    //New


    public class RecommendDietAndExercisePlanViewModel
    {

        public int Id { get; set; }
        public int PersonalInformationId { get; set; }

        // Diet Fields
        [Required(ErrorMessage = "Diet Name is required.")]
        [RegularExpression(@"^(?!\s).+", ErrorMessage = "Diet Name cannot start with a space.")]
        public string DietName { get; set; }

        [Required(ErrorMessage = "Diet Plan is required.")]

        public string DietPlan { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        [RegularExpression(@"^(?!\s).+", ErrorMessage = "Duration cannot start with a space.")]
        public string Duration { get; set; }

        // Exercise Fields
        [Required(ErrorMessage = "Exercise Name is required.")]
        [RegularExpression(@"^(?!\s).+", ErrorMessage = "Exercise Name cannot start with a space.")]
        public string ExerciseName { get; set; }

        [Required(ErrorMessage = "Exercise Plan is required.")]

        public string ExercisePlan { get; set; }

        [Required(ErrorMessage = "Exercise Duration is required.")]
        [RegularExpression(@"^(?!\s).+", ErrorMessage = "Exercise Duration cannot start with a space.")]
        public string ExeDuration { get; set; }
        public string Name { get; set; }

    }
    public class HealthLogViewModel
    {
        public int Id { get; set; }

        public int PersonalInformationId { get; set; }

        [Required(ErrorMessage = "Please select a date.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        // 🏋️‍♂️ Physical Activity

        [Display(Name = "Exercise Type")]
        public string? ExerciseName { get; set; }

        [Range(0, 500, ErrorMessage = "Duration must be between 0 and 500 minutes.")]
        [Display(Name = "Duration (minutes)")]
        public int? DurationMinutes { get; set; }

        [Range(0, 10000, ErrorMessage = "Calories burned should be reasonable.")]
        [Display(Name = "Calories Burned")]
        public float? CaloriesBurned { get; set; }

        [Display(Name = "Sets/Reps")]
        public string? SetsOrReps { get; set; }

        [Display(Name = "Steps Taken")]
        public string? StepTaken { get; set; }

        [Display(Name = "Workout Rating (1–10)")]
        public string? PersonalRatings { get; set; }

        // 🥗 Nutrition & Hydration

        [Range(0, 10000)]
        [Display(Name = "Calories Consumed")]
        public float? Calories { get; set; }

        [Range(0, 500)]
        [Display(Name = "Protein (g)")]
        public float? ProteinGrams { get; set; }

        [Range(0, 500)]
        [Display(Name = "Carbs (g)")]
        public float? CarbGrams { get; set; }

        [Range(0, 500)]
        [Display(Name = "Fats (g)")]
        public float? FatGrams { get; set; }

        [Range(0, 10)]
        [Display(Name = "Water Intake (Liters)")]
        public float? WaterIntake { get; set; }

        [Display(Name = "Junk Food Consumed?")]
        public bool JunkConsumed { get; set; }

        [Display(Name = "Alcohol Consumed?")]
        public bool AlcoholConsumed { get; set; }

        [Display(Name = "Supplements")]
        public string? Supplements { get; set; }

        // 📏 Body Measurements

        [Range(0, 500)]
        [Display(Name = "Weight (kg)")]
        public float? WeightKg { get; set; }

        [Range(0, 300)]
        [Display(Name = "Waist (cm)")]
        public float? WaistCm { get; set; }

        [Range(0, 300)]
        [Display(Name = "Chest (cm)")]
        public float? ChestCm { get; set; }

        [Range(0, 300)]
        [Display(Name = "Hip (cm)")]
        public float? HipCm { get; set; }

        [Display(Name = "BMI")]
        public float? BMI { get; set; }

        // 📅 Audit Fields

        public string? CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        [Display(Name = "Updated Date")]
        [DataType(DataType.Date)]
        public DateTime? UpdatedDate { get; set; }

        public string? DeletedBy { get; set; }

        [Display(Name = "Deleted Date")]
        [DataType(DataType.Date)]
        public DateTime? DeletedDate { get; set; }

        
        public string? PersonalInformationName { get; set; }
    }
   

}
