using System.Collections.Generic;

namespace GymApplication.Models
{
    //public class DashboardViewModel
    //{
    //    public DashboardViewModel()
    //    {
    //        list = new List<DashboardNewViewModel>();
    //    }
    //    public List<DashboardNewViewModel> list { get; set; }
    //    public HealthDashboardViewModel health { get; set; }
    //}
    //public class DashboardViewModel
    //{
    //    public List<DashboardNewViewModel> List { get; set; } = new();
    //}

    public class PieChartViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalCount { get; set; }

    }
  


    public class UserActivityViewModel
    {
        public string Name { get; set; }
        public int CaloriesBurned { get; set; }
        public int StepTaken { get; set; }
        public int Weight { get; set; }

    }



    public class WeeklyProgressViewModel
    {
        public int WeekNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float TotalCaloriesBurned { get; set; }
        public int TotalStepsTaken { get; set; }
        public double AverageWeight { get; set; }
        public float? AverageBMI { get; set; }
        public float? TotalWaterIntake { get; set; }
        // Other necessary fields from your Fitness Log Model
    }

    public class HealthDashboardViewModel
    {
        public int PersonalInformationId { get; set; }

        public List<HealthLogViewModel> Last7DaysLogs { get; set; } = new();
        public List<HealthLogViewModel> LastMonthLogs { get; set; } = new();
    }


    public class AdminDashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int MaleCount { get; set; }
        public int FemaleCount { get; set; }
        public int OtherCount { get; set; }

        public List<BodyTypeStats> BodyTypeStats { get; set; }
        public List<AgeGroupStats> AgeGroupStats { get; set; }
        public List<BodyGoalStats> BodyGoalStats { get; set; }
       
    }


    public class AgeGroupStats
    {
        public int AgeGroupId { get; set; }
        public int Count { get; set; }
    }

    public class BodyGoalStats
    {
        public int BodyGoalId { get; set; }
        public int Count { get; set; }
    }

    public class BodyTypeStats
    {
        public int BodyTypeId { get; set; }
        public int Count { get; set; }
    }

}
