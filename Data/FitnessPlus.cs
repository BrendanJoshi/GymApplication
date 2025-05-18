using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApplication.Data
{
    public class AgeGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; } // Renamed from ImagePath
    }

    public class BodyType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }

    public class BodyGoal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }

    public class TargetBody
    {
        [Key]
        public int Id { get; set; }
        public int BodyGoalId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("BodyGoalId")]
        public BodyGoal BodyGoal { get; set; } // Made nullable in case it's optional
    }

    public class ProblemArea
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

    }

    public class StepDiet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }

    public class StepWater
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }

    public class StepWorkout
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }

    public class AdditionalGoal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }

    public class WorkoutFrequency
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }

    //Admin POV
    public class RecommendDietAndExercisePlan
    {
        public int Id { get; set; }
        public int PersonalInformationId { get; set; }
        //Diet
        public string DietName { get; set; }
        public string DietPlan { get; set; }
        public string Duration { get; set; }
        //Exercise 

        public string ExerciseName { get; set; }
        public string ExercisePlan { get; set; }
        public string ExeDuration { get; set; }
        [ForeignKey("PersonalInformationId")]
        public PersonalInformation? PersonalInformation { get; set; }
    }

    //UserPov
    public class HealthLog
    {
        [Key]
        public int Id { get; set; }

        public int PersonalInformationId { get; set; }

        public DateTime Date { get; set; }



        // 🏋️‍♂️ Physical Activity
        public string? ExerciseName { get; set; }
        public int? DurationMinutes { get; set; }
        public float? CaloriesBurned { get; set; }
        public string SetsOrReps { get; set; }
        public string StepTaken { get; set; }
        public string PersonalRatings { get; set; }
        // Nutrition & Hydration
        public float? Calories { get; set; }
        public float? ProteinGrams { get; set; }
        public float? CarbGrams { get; set; }
        public float? FatGrams { get; set; }
        public float? WaterIntake { get; set; }
        public bool? JunkConsumed { get; set; }
        public bool? AlcoholConsumed { get; set; }
        public string Supplements { get; set; }



        // Body Measurement
        public float? WeightKg { get; set; }
        public float? WaistCm { get; set; }
        public float? ChestCm { get; set; }
        public float? HipCm { get; set; }
        public float? BMI { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        [ForeignKey("PersonalInformationId")]
        public PersonalInformation? PersonalInformation { get; set; }
    }


}
