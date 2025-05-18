using GymApplication.Models;

namespace GymApplication.Interface
{
    public interface IDashboard
    {
        //Task<DashboardViewModel> GetAllDashboardData();
   
        Task<List<HealthLogViewModel>> GetLogsByPersonalInfoIdAsync(int personalInfoId);
        Task<List<HealthLogViewModel>> GetLogsForLast7DaysAsync(int personalInfoId);
        Task<List<HealthLogViewModel>> GetLogsForLastMonthAsync(int personalInfoId);
    }

}
