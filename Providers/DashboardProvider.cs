using GymApplication.Data;
using GymApplication.Data.GymApplication.Data;
using GymApplication.Interface;
using GymApplication.Models;
using GymApplication.Services;
using GymApplication.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Security.Claims;
using static GymApplication.Models.BodyTypeViewModel;

namespace GymApplication.Providers
{
    public class DashboardProvider : IDashboard
    {
        private readonly GymContext _context;
        private readonly IUtility _utility;
        private readonly ILogger<FitnessPlusProvider> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContext;
        private readonly string _userId = null;
        // Constructor with dependency injection
        public DashboardProvider(
     GymContext context,
     IUtility utility,
     ILogger<FitnessPlusProvider> logger,
     UserManager<ApplicationUser> userManager,
     SignInManager<ApplicationUser> signInManager,
     IHttpContextAccessor httpContext)
        {
            _context = context;
            _utility = utility;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContext = httpContext;
            _userId = httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public Task<List<AgeGroupViewModel>> GetAllAgeGroups()
        {
            throw new NotImplementedException();
        }

        //public async Task<DashboardViewModel> GetAllDashboardData()
        //{
        //    var model = new  DashboardViewModel();
        //    int totaluser = await _context.PersonalInformation.CountAsync();
        //    var male=await _context.PersonalInformation.Where(x=>x.GenderId==1).CountAsync();
        //    var female=await _context.PersonalInformation.Where(x=>x.GenderId==2).CountAsync();
        //    var Others=await _context.PersonalInformation.Where(x=>x.GenderId==3).CountAsync();
        //    var AgeGroup=await _context.PersonalInformationRecord.Select(x=>x.AgeGroupId).CountAsync();
        //    model.list.Add(new DashboardNewViewModel()
        //    {
        //        TotalUser = totaluser,
        //        Male= male,
        //        Female= female,
        //        Others= Others,
        //        AgeGroup= AgeGroup
        //    });
        //    return model;
        //}

        public Task<List<HealthLogViewModel>> GetLogsByPersonalInfoIdAsync(int personalInfoId)
        {
            throw new NotImplementedException();
        }

        //New
        public async Task<List<HealthLogViewModel>> GetLogsForLast7DaysAsync(int personalInfoId)
        {

            var user = _httpContext.HttpContext != null && _httpContext.HttpContext.User.IsInRole(UserRoles.User) ? _userId : null;
            var fromDate = DateTime.Now.AddDays(-7);
            var logs = await _context.HealthLog
                .Where(x => x.PersonalInformationId == personalInfoId && (user == null || x.CreatedBy == user) && x.Date >= fromDate)
                .OrderByDescending(x => x.Date)
                .ToListAsync();

            return logs.Select(x => new HealthLogViewModel
            {
                Id = x.Id,
                PersonalInformationId = x.PersonalInformationId,
                Date = x.Date,
                ExerciseName = x.ExerciseName,
                DurationMinutes = x.DurationMinutes,
                CaloriesBurned = x.CaloriesBurned,
                SetsOrReps = x.SetsOrReps,
                StepTaken = x.StepTaken,
                PersonalRatings = x.PersonalRatings,
                Calories = x.Calories,
                ProteinGrams = x.ProteinGrams,
                CarbGrams = x.CarbGrams,
                FatGrams = x.FatGrams,
                WaterIntake = x.WaterIntake,                
                Supplements = x.Supplements,
                WeightKg = x.WeightKg,
                WaistCm = x.WaistCm,
                ChestCm = x.ChestCm,
                HipCm = x.HipCm,
                BMI = x.BMI,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
                DeletedBy = x.DeletedBy,
                DeletedDate = x.DeletedDate,
                // PersonalInformationName can be handled via join or navigation
            }).ToList();
        }

        public async Task<List<HealthLogViewModel>> GetLogsForLastMonthAsync(int personalInfoId)
        {

            var user = _httpContext.HttpContext != null && _httpContext.HttpContext.User.IsInRole(UserRoles.User) ? _userId : null;

            var fromDate = DateTime.Now.AddMonths(-1);
            var logs = await _context.HealthLog
                .Where(x => x.PersonalInformationId == personalInfoId && (user == null || x.CreatedBy == user) && x.Date >= fromDate)
                .OrderByDescending(x => x.Date)
                .ToListAsync();

            return logs.Select(x => new HealthLogViewModel
            {
                Id = x.Id,
                PersonalInformationId = x.PersonalInformationId,
                Date = x.Date,
                ExerciseName = x.ExerciseName,
                DurationMinutes = x.DurationMinutes,
                CaloriesBurned = x.CaloriesBurned,
                SetsOrReps = x.SetsOrReps,
                StepTaken = x.StepTaken,
                PersonalRatings = x.PersonalRatings,
                Calories = x.Calories,
                ProteinGrams = x.ProteinGrams,
                CarbGrams = x.CarbGrams,
                FatGrams = x.FatGrams,
                WaterIntake = x.WaterIntake,       
                Supplements = x.Supplements,
                WeightKg = x.WeightKg,
                WaistCm = x.WaistCm,
                ChestCm = x.ChestCm,
                HipCm = x.HipCm,
                BMI = x.BMI,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
                DeletedBy = x.DeletedBy,
                DeletedDate = x.DeletedDate,
                PersonalInformationName = null // or fetch separately if needed
            }).ToList();
        }

    }
}
