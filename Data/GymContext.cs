
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

//namespace GymApplication.Data
//{
//    public class GymContext : IdentityDbContext<ApplicationUser>
//    {
//        public GymContext(DbContextOptions<GymContext> options) : base(options)
//        {
//        }

//        public DbSet<Project> Projects { get; set; }
//        public DbSet<Gender> Gender { get; set; }
//        public DbSet<PersonalInformation> PersonalInformation { get; set; }

//        //public DbSet<HealthHistory> HealthHistory { get; set; }
//        //public DbSet<Workout> Workouts { get; set; }
//        //public DbSet<Exercise> Exercises { get; set; }
//        //public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
//        //public DbSet<Diet> Diets { get; set; }
//        //public DbSet<Progress> ProgressRecords { get; set; }
//        //public DbSet<Goal> Goals { get; set; }
//        //public DbSet<Progress> Progress { get; set; }
//        //New
//        public DbSet<AgeGroup> AgeGroup { get; set; }
//        public DbSet<BodyType> BodyType { get; set; }
//        public DbSet<BodyGoal> BodyGoal { get; set; }
//        public DbSet<TargetBody> TargetBody { get; set; }
//        public DbSet<ProblemArea> ProblemArea { get; set; }
//        public DbSet<StepDiet> StepDiet { get; set; }
//        public DbSet<StepWater> StepWater { get; set; }
//        public DbSet<StepWorkout> StepWorkout { get; set; }
//        public DbSet<AdditionalGoal> AdditionalGoal { get; set; }
//        public DbSet<WorkoutFrequency> WorkoutFrequency { get; set; }
//        public DbSet<PersonalInformationRecord> PersonalInformationRecord { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            // Define a composite primary key for the WorkoutExercise entity
//            modelBuilder.Entity<WorkoutExercise>()
//                .HasKey(we => new { we.WorkoutId, we.ExerciseId });
//            modelBuilder.Entity<PersonalInformationRecord>()
//                .HasOne(pir => pir.TargetBody)
//                .WithMany()
//                .HasForeignKey(pir => pir.TargetBodyId)
//                .OnDelete(DeleteBehavior.Restrict); // This prevents cascading deletes

//        }

//    }
//}
using GymApplication.Data.GymApplication.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymApplication.Data
{
    public class GymContext : IdentityDbContext<ApplicationUser>
    {
        public GymContext(DbContextOptions<GymContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<PersonalInformation> PersonalInformation { get; set; }

        // New
        public DbSet<AgeGroup> AgeGroup { get; set; }
        public DbSet<BodyType> BodyType { get; set; }
        public DbSet<BodyGoal> BodyGoal { get; set; }
        public DbSet<TargetBody> TargetBody { get; set; }
        public DbSet<ProblemArea> ProblemArea { get; set; }
        public DbSet<StepDiet> StepDiet { get; set; }
        public DbSet<StepWater> StepWater { get; set; }
        public DbSet<StepWorkout> StepWorkout { get; set; }
        public DbSet<AdditionalGoal> AdditionalGoal { get; set; }
        public DbSet<WorkoutFrequency> WorkoutFrequency { get; set; }
        public DbSet<PersonalInformationRecord> PersonalInformationRecord { get; set; }
        public DbSet<RecommendDietAndExercisePlan> RecommendDietAndExercisePlan { get; set; }
        public DbSet<HealthLog> HealthLog { get; set; }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define a composite primary key for the WorkoutExercise entity
            modelBuilder.Entity<WorkoutExercise>()
                .HasKey(we => new { we.WorkoutId, we.ExerciseId });

            // Apply non-cascading deletes to prevent cycles or multiple cascade paths
            modelBuilder.Entity<PersonalInformationRecord>()
                .HasOne(pir => pir.AdditionalGoal)
                .WithMany()
                .HasForeignKey(pir => pir.AdditionalGoalId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<PersonalInformationRecord>()
                .HasOne(pir => pir.AgeGroup)
                .WithMany()
                .HasForeignKey(pir => pir.AgeGroupId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<PersonalInformationRecord>()
                .HasOne(pir => pir.BodyGoal)
                .WithMany()
                .HasForeignKey(pir => pir.BodyGoalId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<PersonalInformationRecord>()
                .HasOne(pir => pir.BodyType)
                .WithMany()
                .HasForeignKey(pir => pir.BodyTypeId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<PersonalInformationRecord>()
                .HasOne(pir => pir.PersonalInformation)
                .WithMany()
                .HasForeignKey(pir => pir.PersonalInformationId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<PersonalInformationRecord>()
                .HasOne(pir => pir.StepDiet)
                .WithMany()
                .HasForeignKey(pir => pir.StepDietId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<PersonalInformationRecord>()
                .HasOne(pir => pir.StepWater)
                .WithMany()
                .HasForeignKey(pir => pir.StepWaterId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<PersonalInformationRecord>()
                .HasOne(pir => pir.StepWorkout)
                .WithMany()
                .HasForeignKey(pir => pir.StepWorkoutId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<PersonalInformationRecord>()
                .HasOne(pir => pir.TargetBody)
                .WithMany()
                .HasForeignKey(pir => pir.TargetBodyId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<PersonalInformationRecord>()
                .HasOne(pir => pir.WorkoutFrequency)
                .WithMany()
                .HasForeignKey(pir => pir.WorkoutFrequencyId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
