using System.Diagnostics;
using System.Security.Claims;
using GymApplication.Data;
using GymApplication.Interface;
using GymApplication.Models;
using GymApplication.Providers;
using GymApplication.Services;
using GymApplication.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUtility _utility;
        private readonly IDashboard _dashboard;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContext;
        private readonly string _userId = null;
        private readonly GymContext _context;
        public HomeController(ILogger<HomeController> logger, IUtility utility, 
            IDashboard dashboard,
     UserManager<ApplicationUser> userManager,
     SignInManager<ApplicationUser> signInManager,
     IHttpContextAccessor httpContext, GymContext context)
        {
            _context = context;
            _logger = logger;
            _utility = utility;
            _dashboard = dashboard;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContext = httpContext;
            _userId = httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        [Authorize]
        //public async Task <IActionResult> Index()
        //{
           // return View(await _dashboard.GetAllDashboardData());
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [AllowAnonymous]
        public IActionResult LandingPage()
        {
            return View();
        }


        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var userId = _httpContext.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    if (string.IsNullOrEmpty(userId))
        //        return Unauthorized();

        //    // Get PersonalInformationId using UserId_
        //    var personalInfoId = await _utility.GetPersonalInformationIdByUserIdAsync(userId);

        //    if (personalInfoId == null)
        //        return NotFound("PersonalInformationId not found for the current user.");

        //    var last7DaysLogs = await _dashboard.GetLogsForLast7DaysAsync(personalInfoId.Value);
        //    var lastMonthLogs = await _dashboard.GetLogsForLastMonthAsync(personalInfoId.Value);

        //    var model = new HealthDashboardViewModel
        //    {
        //        PersonalInformationId = personalInfoId.Value,
        //        Last7DaysLogs = last7DaysLogs,
        //        LastMonthLogs = lastMonthLogs
        //    };

        //    return View(model);
        //}

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = _httpContext.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            // Get the user from UserManager
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound("User not found");

            // Check if the user is in the Admin role
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Admin"))
            {
                // If the user is an Admin, redirect to AdminDashboard
                return RedirectToAction("NewAdminDashboard", "Home");
            }

            // Otherwise, redirect to User Dashboard (Index)
            var personalInfoId = await _utility.GetPersonalInformationIdByUserIdAsync(userId);

            if (personalInfoId == null)
                return NotFound("PersonalInformationId not found for the current user.");

            var last7DaysLogs = await _dashboard.GetLogsForLast7DaysAsync(personalInfoId.Value);
            var lastMonthLogs = await _dashboard.GetLogsForLastMonthAsync(personalInfoId.Value);

            var model = new HealthDashboardViewModel
            {
                PersonalInformationId = personalInfoId.Value,
                Last7DaysLogs = last7DaysLogs,
                LastMonthLogs = lastMonthLogs
            };

            return View(model);
        }







        //public async Task<IActionResult> Dashboard()
        //{
        //    var model = new HealthDashboardViewModel();
        //    int totaluser = await _context.PersonalInformation.CountAsync();
        //    var male = await _context.PersonalInformation.Where(x => x.GenderId == 1).CountAsync();
        //    var female = await _context.PersonalInformation.Where(x => x.GenderId == 2).CountAsync();
        //    var others = await _context.PersonalInformation.Where(x => x.GenderId == 3).CountAsync();
        //    var ageGroupCount = await _context.PersonalInformationRecord
        //                                      .Select(x => x.AgeGroupId).Distinct().CountAsync();

        //    var recordData = await _context.PersonalInformationRecord.ToListAsync();

        //    var ageGroupStats = recordData
        //        .GroupBy(r => r.AgeGroupId.ToString())
        //        .ToDictionary(g => $"Age Group {g.Key}", g => g.Count());

        //    var bodyGoalStats = recordData
        //        .GroupBy(r => r.BodyGoalId.ToString())
        //        .ToDictionary(g => $"Goal {g.Key}", g => g.Count());

        //    model.List.Add(new DashboardNewViewModel
        //    {
        //        TotalUser = totaluser,
        //        Male = male,
        //        Female = female,
        //        Others = others,
        //        AgeGroup = ageGroupCount,
        //        AgeGroupDistribution = ageGroupStats,
        //        BodyGoalDistribution = bodyGoalStats
        //    });

        //    return View(model);
        //}


        //Admin

       
        public async Task<IActionResult> AdminDashboard()
        {
            var totalUserCount = await _context.PersonalInformation.CountAsync();
            var maleCount = await _context.PersonalInformation.Where(x => x.GenderId == 1).CountAsync();
            var femaleCount = await _context.PersonalInformation.Where(x => x.GenderId == 2).CountAsync();
            var otherCount = await _context.PersonalInformation.Where(x => x.GenderId == 3).CountAsync();

            // Aggregating data from PersonalInformationRecord
            var ageGroupCount = await _context.PersonalInformationRecord
                .GroupBy(x => x.AgeGroupId)
                .Select(group => new AgeGroupStats
                {
                    AgeGroupId = group.Key,
                    Count = group.Count()
                }).ToListAsync();

            var bodyGoalCount = await _context.PersonalInformationRecord
                .GroupBy(x => x.BodyGoalId)
                .Select(group => new BodyGoalStats
                {
                    BodyGoalId = group.Key,
                    Count = group.Count()
                }).ToListAsync();

            var bodyTypeCount = await _context.PersonalInformationRecord
                .GroupBy(x => x.BodyTypeId)
                .Select(group => new BodyTypeStats
                {
                    BodyTypeId = group.Key,
                    Count = group.Count()
                }).ToListAsync();

           

          

            // Prepare model for Admin Dashboard
            var adminDashboardModel = new AdminDashboardViewModel
            {
                TotalUsers = totalUserCount,
                MaleCount = maleCount,
                FemaleCount = femaleCount,
                OtherCount = otherCount,
                AgeGroupStats = ageGroupCount,
                BodyGoalStats = bodyGoalCount,
                BodyTypeStats = bodyTypeCount,
              
            };

            return View(adminDashboardModel);
        }
        public async Task<IActionResult> NewAdminDashboard()
        {
            var totalUserCount = await _context.PersonalInformation.CountAsync();
            var maleCount = await _context.PersonalInformation.Where(x => x.GenderId == 1).CountAsync();
            var femaleCount = await _context.PersonalInformation.Where(x => x.GenderId == 2).CountAsync();
            var otherCount = await _context.PersonalInformation.Where(x => x.GenderId == 3).CountAsync();

            // Aggregating data from PersonalInformationRecord
            var ageGroupCount = await _context.PersonalInformationRecord
                .GroupBy(x => x.AgeGroupId)
                .Select(group => new AgeGroupStats
                {
                    AgeGroupId = group.Key,
                    Count = group.Count()
                }).ToListAsync();

            var bodyGoalCount = await _context.PersonalInformationRecord
                .GroupBy(x => x.BodyGoalId)
                .Select(group => new BodyGoalStats
                {
                    BodyGoalId = group.Key,
                    Count = group.Count()
                }).ToListAsync();

            var bodyTypeCount = await _context.PersonalInformationRecord
                .GroupBy(x => x.BodyTypeId)
                .Select(group => new BodyTypeStats
                {
                    BodyTypeId = group.Key,
                    Count = group.Count()
                }).ToListAsync();

           

          

            // Prepare model for Admin Dashboard
            var adminDashboardModel = new AdminDashboardViewModel
            {
                TotalUsers = totalUserCount,
                MaleCount = maleCount,
                FemaleCount = femaleCount,
                OtherCount = otherCount,
                AgeGroupStats = ageGroupCount,
                BodyGoalStats = bodyGoalCount,
                BodyTypeStats = bodyTypeCount,
              
            };

            return View(adminDashboardModel);
        }



    }
}
