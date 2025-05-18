using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApplication.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace GymApplication.Data
    {
        public class PersonalInformationRecord
        {
            [Key]
            public int Id { get; set; }
            public int PersonalInformationId { get; set; }

            // Foreign Keys
            public int AgeGroupId { get; set; }
            public int BodyTypeId { get; set; }
            public int BodyGoalId { get; set; }
            public int TargetBodyId { get; set; }

            public int StepDietId { get; set; }
            public int StepWaterId { get; set; }
            public int StepWorkoutId { get; set; }
            public int AdditionalGoalId { get; set; }
            public int WorkoutFrequencyId { get; set; }

            // Navigation Properties
            [ForeignKey("AgeGroupId")]
            public AgeGroup? AgeGroup { get; set; }

            [ForeignKey("BodyTypeId")]
            public BodyType? BodyType { get; set; }

            [ForeignKey("BodyGoalId")]
            public BodyGoal? BodyGoal { get; set; }

            [ForeignKey("TargetBodyId")]
            public TargetBody? TargetBody { get; set; }

            [ForeignKey("StepDietId")]
            public StepDiet? StepDiet { get; set; }

            [ForeignKey("StepWaterId")]
            public StepWater? StepWater { get; set; }

            [ForeignKey("StepWorkoutId")]
            public StepWorkout? StepWorkout { get; set; }

            [ForeignKey("AdditionalGoalId")]
            public AdditionalGoal? AdditionalGoal { get; set; }

            [ForeignKey("WorkoutFrequencyId")]
            public WorkoutFrequency? WorkoutFrequency { get; set; }

            [ForeignKey("PersonalInformationId")]
            public PersonalInformation? PersonalInformation { get; set; }

            // Personal Information
            [Required]
            [Column(TypeName = "decimal(18,2)")]
            public decimal Height { get; set; }

            [Required]
            [Column(TypeName = "decimal(18,2)")]
            public decimal Weight { get; set; }
        }



        public class PersonalInformationProblemAreas
        {
            [Key]
            public int Id { get; set; }

            // Foreign Keys
            public int PersonalInformationId { get; set; }
            public int ProblemAreaId { get; set; }

            // Navigation Properties
            [ForeignKey("PersonalInformationId")]
            public PersonalInformationRecord? PersonalInformation { get; set; }

            [ForeignKey("ProblemAreaId")]
            public ProblemArea? ProblemArea { get; set; }
        }
    }
}
