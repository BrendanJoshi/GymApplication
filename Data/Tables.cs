using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApplication.Data
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
    
        public string Name { get; set; }
        public string Address { get; set; }
    } 
	public class Gender
    {
        [Key]
        public int Id { get; set; }
    
        public string Name { get; set; }
   
    }

	public class PersonalInformation
	{
		[Key]
		public int Id { get; set; }
		public int GenderId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MobileNumber { get; set; }
		
		public string Email { get; set; }
		public string ProfilePicture { get; set; }
		[ForeignKey("GenderId")]
		public Gender Gender { get; set; }
        public ICollection<Workout> Workouts { get; set; }

    }
	public class HealthHistory
	{
		[Key]
		public int Id { get; set; }
		public int PersonalInformationId { get; set; }
		public string Name { get; set; }
		
		public string Allergies { get; set; }
	
		public string Injuries { get; set; }
		public string Surgeries { get; set; }
		public string ChornicIllness { get; set; }
		public string AnyOtherConditions { get; set; }
        [ForeignKey("PersonalInformationId")]
        public PersonalInformation PersonalInformation { get; set; }

    }
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int PersonalInformationId { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformation PersonalInformation { get; set; }
    }
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public int CaloriesBurnedPerMin { get; set; }

    }
    public class WorkoutExercise
    {
        public int WorkoutId { get; set; }

        public int ExerciseId { get; set; }
        public int DurationInMinutes { get; set; }
        [ForeignKey("WorkoutId")]
        public Workout Workout { get; set; } 
        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; }


    }
    public class Diet
    {
        public int Id { get; set; }
        public string Meal { get; set; } 
        public int Calories { get; set; }
        public DateTime Date { get; set; }
        public int PersonalInformationId { get; set; }
        [ForeignKey("PersonalInformationId")]
        public PersonalInformation PersonalInformation { get; set; }
    }
    public class Goal
    {
        public int Id { get; set; }
        public string GoalType { get; set; } 
        public double TargetWeight { get; set; }
        public DateTime TargetDate { get; set; }
        public int PersonalInformationId { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformation PersonalInformation { get; set; }
    }
    public class Progress
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public int CaloriesBurned { get; set; }
        public int PersonalInformationId { get;  set; }
        [ForeignKey("PersonalInformationId")]
        public PersonalInformation PersonalInformation { get; set; }
    }
}
