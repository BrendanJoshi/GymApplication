using GymApplication.Data;
using GymApplication.Data.GymApplication.Data;
using GymApplication.Email;
using GymApplication.Interface;
using GymApplication.Models;
using GymApplication.Services;
using GymApplication.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Globalization;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using static GymApplication.Models.BodyTypeViewModel;

namespace GymApplication.Providers
{
    public class FitnessPlusProvider : IFitnessPlus
    {
        private readonly GymContext _context;
        private readonly IUtility _utility;
        private readonly ILogger<FitnessPlusProvider> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContext;
        private readonly string _userId = null;
        private readonly IEmailService _mailService;
        // Constructor with dependency injection
        public FitnessPlusProvider(
     GymContext context,
     IUtility utility,
     ILogger<FitnessPlusProvider> logger,
     UserManager<ApplicationUser> userManager,
     SignInManager<ApplicationUser> signInManager,
     IHttpContextAccessor httpContext,
     IEmailService mailService)
        {
            _context = context;
            _utility = utility;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContext = httpContext;
            _userId = httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _mailService = mailService;
        }

        #region AgeGroup
        public async Task<List<AgeGroupViewModel>> GetAllAgeGroups()
        {
            return await _context.AgeGroup
                .Select(x => new AgeGroupViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).ToListAsync() ?? new List<AgeGroupViewModel>();
        }

        public async Task<AgeGroupViewModel?> GetAgeGroupById(int id)
        {
            return await _context.AgeGroup
                .Where(x => x.Id == id)
                .Select(x => new AgeGroupViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).FirstOrDefaultAsync() ?? new AgeGroupViewModel();
        }

        public async Task<bool> CreateOrUpdateAgeGroup(AgeGroupViewModel model)
        {
            var img = await _utility.UploadImgReturnPathAndName("AgeGroup", model.Image, "AgeGroup");
            try
            {
                var existingRecord = await _context.AgeGroup.FindAsync(model.Id);

                if (existingRecord != null)
                {
                    existingRecord.Name = model.Name;
                    existingRecord.ImageUrl = img.FilePath;
                }
                else
                {

                    var newRecord = new AgeGroup()
                    {
                        Name = model.Name,
                        ImageUrl = img.FilePath,
                    };
                    await _context.AgeGroup.AddAsync(newRecord);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CreateOrUpdateAgeGroup: {ex.Message}");
                return false;
            }
        }
        #endregion

        #region BodyType
        public async Task<List<BodyTypeViewModel>> GetAllBodyTypes()
        {
            return await _context.BodyType
                .Select(x => new BodyTypeViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).ToListAsync() ?? new List<BodyTypeViewModel>();
        }

        public async Task<BodyTypeViewModel?> GetBodyTypeById(int id)
        {
            return await _context.BodyType
                .Where(x => x.Id == id)
                .Select(x => new BodyTypeViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).FirstOrDefaultAsync() ?? new BodyTypeViewModel();
        }

        public async Task<bool> CreateOrUpdateBodyType(BodyTypeViewModel model)
        {
            var img = await _utility.UploadImgReturnPathAndName("BodyType", model.Image, "BodyType");
            try
            {
                var existingRecord = await _context.BodyType.FindAsync(model.Id);

                if (existingRecord != null)
                {
                    existingRecord.Name = model.Name;
                    existingRecord.ImageUrl = img.FilePath;
                }
                else
                {
                    var newRecord = new BodyType()
                    {
                        Name = model.Name,
                        ImageUrl = img.FilePath,
                    };
                    await _context.BodyType.AddAsync(newRecord);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CreateOrUpdateBodyType: {ex.Message}");
                return false;
            }
        }
        #endregion
        #region BodyGoal
        public async Task<List<BodyGoalViewModel>> GetAllBodyGoals()
        {
            return await _context.BodyGoal
                .Select(x => new BodyGoalViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).ToListAsync() ?? new List<BodyGoalViewModel>();
        }

        public async Task<BodyGoalViewModel?> GetBodyGoalById(int id)
        {
            return await _context.BodyGoal
                .Where(x => x.Id == id)
                .Select(x => new BodyGoalViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).FirstOrDefaultAsync() ?? new BodyGoalViewModel();
        }

        public async Task<bool> CreateOrUpdateBodyGoal(BodyGoalViewModel model)
        {
            var img = await _utility.UploadImgReturnPathAndName("BodyGoal", model.Image, "BodyGoal");
            try
            {
                var existingRecord = await _context.BodyGoal.FindAsync(model.Id);

                if (existingRecord != null)
                {
                    existingRecord.Name = model.Name;
                    existingRecord.ImageUrl = img.FilePath;
                }
                else
                {
                    var newRecord = new BodyGoal()
                    {
                        Name = model.Name,
                        ImageUrl = img.FilePath,
                    };
                    await _context.BodyGoal.AddAsync(newRecord);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CreateOrUpdateBodyGoal: {ex.Message}");
                return false;
            }
        }
        #endregion
        #region WorkoutFrequency
        public async Task<List<WorkoutFrequencyViewModel>> GetAllWorkoutFrequencies()
        {
            return await _context.WorkoutFrequency
                .Select(x => new WorkoutFrequencyViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).ToListAsync() ?? new List<WorkoutFrequencyViewModel>();
        }

        public async Task<WorkoutFrequencyViewModel?> GetWorkoutFrequencyById(int id)
        {
            return await _context.WorkoutFrequency
                .Where(x => x.Id == id)
                .Select(x => new WorkoutFrequencyViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).FirstOrDefaultAsync() ?? new WorkoutFrequencyViewModel();
        }

        public async Task<bool> CreateOrUpdateWorkoutFrequency(WorkoutFrequencyViewModel model)
        {
            var img = await _utility.UploadImgReturnPathAndName("WorkoutFrequency", model.Image, "WorkoutFrequency");
            try
            {
                var existingRecord = await _context.WorkoutFrequency.FindAsync(model.Id);

                if (existingRecord != null)
                {
                    existingRecord.Name = model.Name;
                    existingRecord.ImageUrl = img.FilePath;
                }
                else
                {
                    var newRecord = new WorkoutFrequency()
                    {
                        Name = model.Name,
                        ImageUrl = img.FilePath
                    };
                    await _context.WorkoutFrequency.AddAsync(newRecord);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CreateOrUpdateWorkoutFrequency: {ex.Message}");
                return false;
            }
        }
        #endregion
        #region TargetBody
        public async Task<List<TargetBodyViewModel>> GetAllTargetBodies()
        {
            return await _context.TargetBody
                .Select(x => new TargetBodyViewModel()
                {
                    Id = x.Id,
                    BodyGoalId = x.BodyGoalId,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    BodyGoalName = x.BodyGoal.Name
                }).ToListAsync() ?? new List<TargetBodyViewModel>();
        }

        public async Task<TargetBodyViewModel> GetTargetBodyById(int id)
        {
            return await _context.TargetBody
                .Where(x => x.Id == id)
                .Select(x => new TargetBodyViewModel()
                {
                    Id = x.Id,
                    BodyGoalId = x.BodyGoalId,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    BodyGoalName = x.BodyGoal.Name
                }).FirstOrDefaultAsync() ?? new TargetBodyViewModel();
        }

        public async Task<bool> CreateOrUpdateTargetBody(TargetBodyViewModel model)
        {
            var img = await _utility.UploadImgReturnPathAndName("TargetBody", model.Image, "TargetBody");
            try
            {
                var existingRecord = await _context.TargetBody.FindAsync(model.Id);

                if (existingRecord != null)
                {
                    existingRecord.Name = model.Name;
                    existingRecord.ImageUrl = img.FilePath;
                    existingRecord.BodyGoalId = model.BodyGoalId;
                }
                else
                {
                    var newRecord = new TargetBody()
                    {
                        Name = model.Name,
                        ImageUrl = img.FilePath,
                        BodyGoalId = model.BodyGoalId
                    };
                    await _context.TargetBody.AddAsync(newRecord);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
        #endregion
        #region ProblemArea
        public async Task<List<ProblemAreaViewModel>> GetAllProblemAreas()
        {
            return await _context.ProblemArea
                .Select(x => new ProblemAreaViewModel()
                {
                    Id = x.Id,

                    Name = x.Name,
                    ImageUrl = x.ImageUrl,

                }).ToListAsync() ?? new List<ProblemAreaViewModel>();
        }

        public async Task<ProblemAreaViewModel?> GetProblemAreaById(int id)
        {
            return await _context.ProblemArea
                .Where(x => x.Id == id)
                .Select(x => new ProblemAreaViewModel()
                {
                    Id = x.Id,

                    Name = x.Name,
                    ImageUrl = x.ImageUrl,

                }).FirstOrDefaultAsync() ?? new ProblemAreaViewModel();
        }

        public async Task<bool> CreateOrUpdateProblemArea(ProblemAreaViewModel model)
        {
            var img = await _utility.UploadImgReturnPathAndName("ProblemArea", model.Image, "ProblemArea");
            try
            {
                var existingRecord = await _context.ProblemArea.FindAsync(model.Id);

                if (existingRecord != null)
                {
                    existingRecord.Name = model.Name;
                    existingRecord.ImageUrl = img.FilePath;

                }
                else
                {
                    var newRecord = new ProblemArea()
                    {
                        Name = model.Name,
                        ImageUrl = img.FilePath,

                    };
                    await _context.ProblemArea.AddAsync(newRecord);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
        #endregion
        #region StepDiet
        public async Task<List<StepDietViewModel>> GetAllStepDiets()
        {
            return await _context.StepDiet
                .Select(x => new StepDietViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).ToListAsync() ?? new List<StepDietViewModel>();
        }

        public async Task<StepDietViewModel?> GetStepDietById(int id)
        {
            return await _context.StepDiet
                .Where(x => x.Id == id)
                .Select(x => new StepDietViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).FirstOrDefaultAsync() ?? new StepDietViewModel();
        }

        public async Task<bool> CreateOrUpdateStepDiet(StepDietViewModel model)
        {

            var img = await _utility.UploadImgReturnPathAndName("StepDiet", model.Image, "StepDiet");
            try
            {
                var existingRecord = await _context.StepDiet.FindAsync(model.Id);

                if (existingRecord != null)
                {
                    existingRecord.Name = model.Name;
                    existingRecord.ImageUrl = img.FilePath;
                }
                else
                {
                    var newRecord = new StepDiet()
                    {
                        Name = model.Name,
                        ImageUrl = img.FilePath
                    };
                    await _context.StepDiet.AddAsync(newRecord);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
        #endregion
        #region StepWater
        public async Task<List<StepWaterViewModel>> GetAllStepWaters()
        {
            return await _context.StepWater
                .Select(x => new StepWaterViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).ToListAsync() ?? new List<StepWaterViewModel>();
        }

        public async Task<StepWaterViewModel?> GetStepWaterById(int id)
        {
            return await _context.StepWater
                .Where(x => x.Id == id)
                .Select(x => new StepWaterViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).FirstOrDefaultAsync() ?? new StepWaterViewModel();
        }

        public async Task<bool> CreateOrUpdateStepWater(StepWaterViewModel model)
        {
            var img = await _utility.UploadImgReturnPathAndName("StepWater", model.Image, "StepWater");
            try
            {
                var existingRecord = await _context.StepWater.FindAsync(model.Id);

                if (existingRecord != null)
                {
                    existingRecord.Name = model.Name;
                    existingRecord.ImageUrl = img.FilePath;
                }
                else
                {
                    var newRecord = new StepWater()
                    {
                        Name = model.Name,
                        ImageUrl = img.FilePath
                    };
                    await _context.StepWater.AddAsync(newRecord);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
        #endregion
        #region StepWorkout
        public async Task<List<StepWorkoutViewModel>> GetAllStepWorkouts()
        {
            return await _context.StepWorkout
                .Select(x => new StepWorkoutViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).ToListAsync() ?? new List<StepWorkoutViewModel>();
        }

        public async Task<StepWorkoutViewModel?> GetStepWorkoutById(int id)
        {
            return await _context.StepWorkout
                .Where(x => x.Id == id)
                .Select(x => new StepWorkoutViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).FirstOrDefaultAsync() ?? new StepWorkoutViewModel();
        }

        public async Task<bool> CreateOrUpdateStepWorkout(StepWorkoutViewModel model)
        {
            var img = await _utility.UploadImgReturnPathAndName("StepWorkout", model.Image, "StepWorkout");
            try
            {
                var existingRecord = await _context.StepWorkout.FindAsync(model.Id);

                if (existingRecord != null)
                {
                    existingRecord.Name = model.Name;
                    existingRecord.ImageUrl = img.FilePath;
                }
                else
                {
                    var newRecord = new StepWorkout()
                    {
                        Name = model.Name,
                        ImageUrl = img.FilePath
                    };
                    await _context.StepWorkout.AddAsync(newRecord);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
        #endregion
        #region AdditionalGoal
        public async Task<List<AdditionalGoalViewModel>> GetAllAdditionalGoals()
        {
            return await _context.AdditionalGoal
                .Select(x => new AdditionalGoalViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).ToListAsync() ?? new List<AdditionalGoalViewModel>();
        }

        public async Task<AdditionalGoalViewModel?> GetAdditionalGoalById(int id)
        {
            return await _context.AdditionalGoal
                .Where(x => x.Id == id)
                .Select(x => new AdditionalGoalViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).FirstOrDefaultAsync() ?? new AdditionalGoalViewModel();
        }

        public async Task<bool> CreateOrUpdateAdditionalGoal(AdditionalGoalViewModel model)
        {
            var img = await _utility.UploadImgReturnPathAndName("AdditionalGoal", model.Image, "AdditionalGoal");
            try
            {
                var existingRecord = await _context.AdditionalGoal.FindAsync(model.Id);

                if (existingRecord != null)
                {
                    existingRecord.Name = model.Name;
                    existingRecord.ImageUrl = img.FilePath;
                }
                else
                {
                    var newRecord = new AdditionalGoal()
                    {
                        Name = model.Name,
                        ImageUrl = img.FilePath
                    };
                    await _context.AdditionalGoal.AddAsync(newRecord);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
        #endregion
        #region PersonalInformation
        public async Task<List<PersonalInformationViewModel>> GetAllPersonalInformationRecords()
        {
            var user = _httpContext.HttpContext != null && _httpContext.HttpContext.User.IsInRole(UserRoles.User) ? _userId : null;
            int? personalid = 0;

            if (user != null)
            {
                personalid = await _context.Users
                            .Where(u => u.Id == user)
                            .Select(u => u.PersonalInformationId)
                            .FirstOrDefaultAsync();
            }
            var data = await (from per in _context.PersonalInformation
                              join details in _context.PersonalInformationRecord on per.Id
                              equals details.PersonalInformationId into perinfo
                              from detail in perinfo.DefaultIfEmpty()
                              select new PersonalInformationViewModel
                              {
                                  Id = per.Id,
                                  FirstName = per.FirstName,
                                  LastName = per.LastName,
                                  MobileNumber = per.MobileNumber,
                                  Email = per.Email,
                                  ProfilePicture = per.ProfilePicture,
                                  GenderId = per.GenderId,
                                  GenderName = per.Gender != null ? per.Gender.Name : string.Empty,

                                  // Health & Fitness Information
                                  AgeGroupId = detail != null ? detail.AgeGroupId : 0,
                                  BodyTypeId = detail != null ? detail.BodyTypeId : 0,
                                  BodyGoalId = detail != null ? detail.BodyGoalId : 0,
                                  TargetBodyId = detail != null ? detail.TargetBodyId : 0,
                                  StepDietId = detail != null ? detail.StepDietId : 0,
                                  StepWaterId = detail != null ? detail.StepWaterId : 0,
                                  StepWorkoutId = detail != null ? detail.StepWorkoutId : 0,
                                  AdditionalGoalId = detail != null ? detail.AdditionalGoalId : 0,
                                  WorkoutFrequencyId = detail != null ? detail.WorkoutFrequencyId : 0,

                                  // Name Properties
                                  AgeGroupName = detail != null && detail.AgeGroup != null ? detail.AgeGroup.Name : string.Empty,
                                  BodyTypeName = detail != null && detail.BodyType != null ? detail.BodyType.Name : string.Empty,
                                  BodyGoalName = detail != null && detail.BodyGoal != null ? detail.BodyGoal.Name : string.Empty,
                                  TargetBodyName = detail != null && detail.TargetBody != null ? detail.TargetBody.Name : string.Empty,
                                  StepDietName = detail != null && detail.StepDiet != null ? detail.StepDiet.Name : string.Empty,
                                  StepWaterName = detail != null && detail.StepWater != null ? detail.StepWater.Name : string.Empty,
                                  StepWorkoutName = detail != null && detail.StepWorkout != null ? detail.StepWorkout.Name : string.Empty,
                                  AdditionalGoalName = detail != null && detail.AdditionalGoal != null ? detail.AdditionalGoal.Name : string.Empty,
                                  WorkoutFrequencyName = detail != null && detail.WorkoutFrequency != null ? detail.WorkoutFrequency.Name : string.Empty,

                                  // Physical Attributes
                                  Height = detail != null ? detail.Height : 0,
                                  Weight = detail != null ? detail.Weight : 0
                              }).Where(x => x.Id == personalid || user == null).ToListAsync() ?? new List<PersonalInformationViewModel>();
            return data;
        }

        public async Task<PersonalInformationViewModel> GetDietPlanById(int pid)
        {
            var data = await _context.PersonalInformationRecord
                .Where(x => x.PersonalInformationId == pid)
                .Select(x => new PersonalInformationViewModel()
                {
                    AgeGroupId = x.AgeGroupId,
                    BodyGoalId = x.BodyGoalId,
                    BodyTypeId = x.BodyTypeId,
                    StepDietId = x.StepDietId,
                    StepWaterId = x.StepWaterId,
                    StepWorkoutId = x.StepWorkoutId,
                    TargetBodyId = x.TargetBodyId,
                    AdditionalGoalId = x.AdditionalGoalId,
                    WorkoutFrequencyId = x.WorkoutFrequencyId,
                }).FirstOrDefaultAsync();
            return data ?? new PersonalInformationViewModel();
        }
        public async Task<PersonalInformationViewModel> GetPersonalInformationById(int id)
        {
            PersonalInformationViewModel model = new PersonalInformationViewModel();
            model.AgeGroupList = await _context.AgeGroup.Select(ag => new AgeGroupViewModel
            {
                Id = ag.Id,
                ImageUrl = ag.ImageUrl,
                Name = ag.Name,
            }).ToListAsync();
            model.BodyTypeList = await _context.BodyType.Select(ag => new BodyTypeViewModel
            {
                Id = ag.Id,
                ImageUrl = ag.ImageUrl,
                Name = ag.Name,
            }).ToListAsync();
            model.BodyGoalList = await _context.BodyGoal.Select(ag => new BodyGoalViewModel
            {
                Id = ag.Id,
                ImageUrl = ag.ImageUrl,
                Name = ag.Name,
            }).ToListAsync();
            model.TargetBodyList = await _context.TargetBody.Select(ag => new TargetBodyViewModel
            {
                Id = ag.Id,
                ImageUrl = ag.ImageUrl,
                Name = ag.Name,
                BodyGoalId = ag.BodyGoalId,
                BodyGoalName = ag.BodyGoal.Name,
            }).ToListAsync();
            model.ProblemAreaList = await _context.ProblemArea.Select(ag => new ProblemAreaViewModel
            {
                Id = ag.Id,
                ImageUrl = ag.ImageUrl,
                Name = ag.Name,
            }).ToListAsync();
            model.StepDietList = await _context.StepDiet.Select(ag => new StepDietViewModel
            {
                Id = ag.Id,
                ImageUrl = ag.ImageUrl,
                Name = ag.Name,
            }).ToListAsync();
            model.StepWaterList = await _context.StepWater.Select(ag => new StepWaterViewModel
            {
                Id = ag.Id,
                ImageUrl = ag.ImageUrl,
                Name = ag.Name,
            }).ToListAsync();
            model.StepWorkoutList = await _context.StepWorkout.Select(ag => new StepWorkoutViewModel
            {
                Id = ag.Id,
                ImageUrl = ag.ImageUrl,
                Name = ag.Name,
            }).ToListAsync();
            model.AdditionalGoalList = await _context.AdditionalGoal.Select(ag => new AdditionalGoalViewModel
            {
                Id = ag.Id,
                ImageUrl = ag.ImageUrl,
                Name = ag.Name,
            }).ToListAsync();
            model.WorkoutFrequencyList = await _context.WorkoutFrequency.Select(ag => new WorkoutFrequencyViewModel
            {
                Id = ag.Id,
                ImageUrl = ag.ImageUrl,
                Name = ag.Name,
            }).ToListAsync();

            var UserRole = _context.Roles.FirstOrDefault(a => a.Name == "User")?.ToString();
            var UserRoleId = _context.Roles.Where(a => a.Name == "User").Select(a => a.Id).FirstOrDefault()?.ToString();
            if (id > 0)
            {
                var data = await (from per in _context.PersonalInformation
                                  join details in _context.PersonalInformationRecord on per.Id
                                  equals details.PersonalInformationId into perinfo
                                  from detail in perinfo.DefaultIfEmpty()
                                  where per.Id == id
                                  select new PersonalInformationViewModel
                                  {
                                      Id = per.Id,
                                      FirstName = per.FirstName,
                                      LastName = per.LastName,
                                      MobileNumber = per.MobileNumber,
                                      Email = per.Email,
                                      ProfilePicture = per.ProfilePicture,
                                      GenderId = per.GenderId,
                                      GenderName = per.Gender != null ? per.Gender.Name : string.Empty,

                                      // Health & Fitness Information
                                      AgeGroupId = detail != null ? detail.AgeGroupId : 0,
                                      BodyTypeId = detail != null ? detail.BodyTypeId : 0,
                                      BodyGoalId = detail != null ? detail.BodyGoalId : 0,
                                      TargetBodyId = detail != null ? detail.TargetBodyId : 0,
                                      StepDietId = detail != null ? detail.StepDietId : 0,
                                      StepWaterId = detail != null ? detail.StepWaterId : 0,
                                      StepWorkoutId = detail != null ? detail.StepWorkoutId : 0,
                                      AdditionalGoalId = detail != null ? detail.AdditionalGoalId : 0,
                                      WorkoutFrequencyId = detail != null ? detail.WorkoutFrequencyId : 0,

                                      // Name Properties
                                      AgeGroupName = detail != null && detail.AgeGroup != null ? detail.AgeGroup.Name : string.Empty,
                                      BodyTypeName = detail != null && detail.BodyType != null ? detail.BodyType.Name : string.Empty,
                                      BodyGoalName = detail != null && detail.BodyGoal != null ? detail.BodyGoal.Name : string.Empty,
                                      TargetBodyName = detail != null && detail.TargetBody != null ? detail.TargetBody.Name : string.Empty,
                                      StepDietName = detail != null && detail.StepDiet != null ? detail.StepDiet.Name : string.Empty,
                                      StepWaterName = detail != null && detail.StepWater != null ? detail.StepWater.Name : string.Empty,
                                      StepWorkoutName = detail != null && detail.StepWorkout != null ? detail.StepWorkout.Name : string.Empty,
                                      AdditionalGoalName = detail != null && detail.AdditionalGoal != null ? detail.AdditionalGoal.Name : string.Empty,
                                      WorkoutFrequencyName = detail != null && detail.WorkoutFrequency != null ? detail.WorkoutFrequency.Name : string.Empty,

                                      // Physical Attributes
                                      Height = detail != null ? detail.Height : 0,
                                      Weight = detail != null ? detail.Weight : 0
                                  }).FirstOrDefaultAsync();

                data.UserRole = UserRole;
                data.UserRoleId = UserRoleId;
                return data ?? new PersonalInformationViewModel();
            }
            return model;
        }

        //public async Task<bool> UpdatePersonalInformation(PersonalInformationViewModel model)
        //{
        //    var profile = await _utility.UploadImgReturnPathAndName("Profile", model.ProfilePictureImg,"User-Profile");

        //    try
        //    {
        //        if (model.Id > 0) // Update scenario
        //        {
        //            var personalInfo = await _context.PersonalInformation.FindAsync(model.Id);
        //            if (personalInfo == null)
        //                return false;

        //            personalInfo.FirstName = model.FirstName;
        //            personalInfo.LastName = model.LastName;
        //            personalInfo.MobileNumber = model.MobileNumber;
        //            personalInfo.Email = model.Email;
        //            personalInfo.GenderId = model.GenderId;
        //            personalInfo.ProfilePicture = profile.FilePath;

        //            _context.PersonalInformation.Update(personalInfo);

        //            var personalRecord = await _context.PersonalInformationRecord
        //                .FirstOrDefaultAsync(x => x.PersonalInformationId == model.Id);

        //            if (personalRecord != null)
        //            {
        //                personalRecord.Height = model.Height;
        //                personalRecord.Weight = model.Weight;
        //                personalRecord.AgeGroupId = model.AgeGroupId;
        //                personalRecord.BodyTypeId = model.BodyTypeId;
        //                personalRecord.BodyGoalId = model.BodyGoalId;
        //                personalRecord.TargetBodyId = model.TargetBodyId;
        //                personalRecord.StepDietId = model.StepDietId;
        //                personalRecord.StepWaterId = model.StepWaterId;
        //                personalRecord.StepWorkoutId = model.StepWorkoutId;
        //                personalRecord.AdditionalGoalId = model.AdditionalGoalId;
        //                personalRecord.WorkoutFrequencyId = model.WorkoutFrequencyId;

        //                _context.PersonalInformationRecord.Update(personalRecord);
        //            }
        //        }
        //        else // Create scenario
        //        {
        //            var personalInfo = new PersonalInformation
        //            {
        //                FirstName = model.FirstName,
        //                LastName = model.LastName,
        //                MobileNumber = model.MobileNumber,
        //                Email = model.Email,
        //                GenderId = model.GenderId,
        //                ProfilePicture = profile.FilePath
        //            };

        //            await _context.PersonalInformation.AddAsync(personalInfo);
        //            await _context.SaveChangesAsync(); // Save first to get ID

        //            var personalRecord = new PersonalInformationRecord
        //            {
        //                PersonalInformationId = personalInfo.Id,
        //                Height = model.Height,
        //                Weight = model.Weight,
        //                AgeGroupId = model.AgeGroupId,
        //                BodyTypeId = model.BodyTypeId,
        //                BodyGoalId = model.BodyGoalId,
        //                TargetBodyId = model.TargetBodyId,
        //                StepDietId = model.StepDietId,
        //                StepWaterId = model.StepWaterId,
        //                StepWorkoutId = model.StepWorkoutId,
        //                AdditionalGoalId = model.AdditionalGoalId,
        //                WorkoutFrequencyId = model.WorkoutFrequencyId
        //            };

        //            await _context.PersonalInformationRecord.AddAsync(personalRecord);

        //            // Check if user already exists
        //            var existingUser = await _context.Users
        //                .FirstOrDefaultAsync(x => x.UserName == personalInfo.Email ||
        //                                          x.FullName == personalInfo.FirstName + " " + personalInfo.LastName);

        //            if (existingUser == null)
        //            {
        //                var user = new ApplicationUser
        //                {
        //                    FullName = personalInfo.FirstName + " " + personalInfo.LastName,
        //                    UserName = personalInfo.Email,
        //                    Email = personalInfo.Email,
        //                    EmailConfirmed = true

        //                };

        //                var result = await _userManager.CreateAsync(user, model.Password);
        //                if (!result.Succeeded)
        //                {
        //                    // Rollback in case of user creation failure
        //                    _context.PersonalInformation.Remove(personalInfo);
        //                    _context.PersonalInformationRecord.Remove(personalRecord);
        //                    await _context.SaveChangesAsync();
        //                    return false;
        //                }

        //                await _userManager.AddToRoleAsync(user, "User");
        //            }
        //            else
        //            {
        //                return false; // User already exists
        //            }
        //        }

        //        await _context.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error in UpdatePersonalInformation: {ex.Message}");
        //        return false;
        //    }
        //}
        public async Task<bool> UpdatePersonalInformation(PersonalInformationViewModel model)
        {
            var profile = await _utility.UploadImgReturnPathAndName("Profile", model.ProfilePictureImg, "User-Profile");
            var strategy = _context.Database.CreateExecutionStrategy();
            {
                return await strategy.ExecuteAsync(async () =>
                {
                    using (var transaction = await _context.Database.BeginTransactionAsync())
                    {

                        try
                        {
                            if (model.Id > 0) // Update scenario
                            {
                                var personalInfo = await _context.PersonalInformation.FindAsync(model.Id);
                                if (personalInfo == null)
                                    return false;

                                // Update basic user details
                                personalInfo.FirstName = model.FirstName;
                                personalInfo.LastName = model.LastName;
                                personalInfo.MobileNumber = model.MobileNumber;
                                personalInfo.Email = model.Email;
                                personalInfo.GenderId = model.GenderId;
                                personalInfo.ProfilePicture = profile.FilePath;

                                _context.PersonalInformation.Update(personalInfo);

                                // Fetch or create personal record for additional details
                                var personalRecord = await _context.PersonalInformationRecord
                                    .FirstOrDefaultAsync(x => x.PersonalInformationId == model.Id);

                                if (personalRecord != null)
                                {
                                    // Update existing record
                                    personalRecord.Height = model.Height;
                                    personalRecord.Weight = model.Weight;
                                    personalRecord.AgeGroupId = model.AgeGroupId;
                                    personalRecord.BodyTypeId = model.BodyTypeId;
                                    personalRecord.BodyGoalId = model.BodyGoalId;
                                    personalRecord.TargetBodyId = model.TargetBodyId;
                                    personalRecord.StepDietId = model.StepDietId;
                                    personalRecord.StepWaterId = model.StepWaterId;
                                    personalRecord.StepWorkoutId = model.StepWorkoutId;
                                    // Save the additional goals as comma-separated string (assuming model.AdditionalGoalIds is a string)
                                    //personalRecord.AdditionalGoalIds = model.AdditionalGoalIds;
                                    personalRecord.WorkoutFrequencyId = model.WorkoutFrequencyId;

                                    _context.PersonalInformationRecord.Update(personalRecord);
                                    await transaction.CommitAsync();
                                }
                                else
                                {
                                    // Create a new record if it doesn't exist
                                    personalRecord = new PersonalInformationRecord
                                    {
                                        PersonalInformationId = personalInfo.Id,
                                        Height = model.Height,
                                        Weight = model.Weight,
                                        AgeGroupId = model.AgeGroupId,
                                        BodyTypeId = model.BodyTypeId,
                                        BodyGoalId = model.BodyGoalId,
                                        TargetBodyId = model.TargetBodyId,
                                        StepDietId = model.StepDietId,
                                        StepWaterId = model.StepWaterId,
                                        StepWorkoutId = model.StepWorkoutId,
                                        AdditionalGoalId = model.AdditionalGoalId,
                                        WorkoutFrequencyId = model.WorkoutFrequencyId
                                    };

                                    await _context.PersonalInformationRecord.AddAsync(personalRecord);
                                }
                            }
                            else
                            {
                                var personalInfo = new PersonalInformation
                                {
                                    FirstName = model.FirstName,
                                    LastName = model.LastName,
                                    MobileNumber = model.MobileNumber,
                                    Email = model.Email,
                                    GenderId = model.GenderId,
                                    ProfilePicture = profile.FilePath
                                };

                                await _context.PersonalInformation.AddAsync(personalInfo);
                                await _context.SaveChangesAsync();

                                var personalRecord = new PersonalInformationRecord
                                {
                                    PersonalInformationId = personalInfo.Id,
                                    Height = model.Height,
                                    Weight = model.Weight,
                                    AgeGroupId = model.AgeGroupId,
                                    BodyTypeId = model.BodyTypeId,
                                    BodyGoalId = model.BodyGoalId,
                                    TargetBodyId = model.TargetBodyId,
                                    StepDietId = model.StepDietId,
                                    StepWaterId = model.StepWaterId,
                                    StepWorkoutId = model.StepWorkoutId,
                                    AdditionalGoalId = model.AdditionalGoalId,
                                    WorkoutFrequencyId = model.WorkoutFrequencyId
                                };

                                await _context.PersonalInformationRecord.AddAsync(personalRecord);


                                var existingUser = await _context.Users
                                    .FirstOrDefaultAsync(x => x.UserName == personalInfo.Email ||
                                                              x.FullName == personalInfo.FirstName + " " + personalInfo.LastName);

                                if (existingUser == null)
                                {
                                    var user = new ApplicationUser
                                    {
                                        FullName = personalInfo.FirstName + " " + personalInfo.LastName,
                                        UserName = personalInfo.Email,
                                        Email = personalInfo.Email,
                                        EmailConfirmed = true,
                                        PersonalInformationId = personalInfo.Id,
                                    };

                                    var result = await _userManager.CreateAsync(user, model.Password);
                                    if (!result.Succeeded)
                                    {
                                        // Rollback in case of user creation failure
                                        _context.PersonalInformation.Remove(personalInfo);
                                        _context.PersonalInformationRecord.Remove(personalRecord);
                                        await _context.SaveChangesAsync();
                                        return false;
                                    }
                                    else
                                    {
                                        await _userManager.AddToRoleAsync(user, "User");
                                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));


                                        await _mailService.SendEmailAsync(new MailRequest
                                        {
                                            ToEmail = user.Email,
                                            Subject = "Fitness Plus Application – Automated Message (Do Not Reply)",
                                            Body = $"Please confirm your account by" +
                                            $" <a href='{HtmlEncoder.Default.Encode(code)}'>" +
                                            $"clicking here</a>."
                                        });
                                    }


                                }
                                else
                                {
                                    return false;
                                }
                            }

                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            _logger.LogError($"Error in UpdatePersonalInformation: {ex.Message}");
                            return false;
                        }
                    }
                });
            }
        }


        #endregion
        #region RecommendDietAndExercisePlan

        // Returns all RecommendDietAndExercisePlan records as view models.
        public async Task<List<RecommendDietAndExercisePlanViewModel>> GetAllRecommendPlans()
        {
            var user = _httpContext.HttpContext != null && _httpContext.HttpContext.User.IsInRole(UserRoles.User) ? _userId : null;
            int? personalid = 0;

            if (user != null)
            {
                personalid = await _context.Users
                            .Where(u => u.Id == user)
                            .Select(u => u.PersonalInformationId)
                            .FirstOrDefaultAsync();
            }
            return await _context.RecommendDietAndExercisePlan
                .Select(x => new RecommendDietAndExercisePlanViewModel
                {
                    Id = x.Id,
                    PersonalInformationId = x.PersonalInformationId,
                    DietName = x.DietName,
                    DietPlan = x.DietPlan,
                    Duration = x.Duration,
                    ExerciseName = x.ExerciseName,
                    ExercisePlan = x.ExercisePlan,
                    ExeDuration = x.ExeDuration,
                    Name = x.PersonalInformation.FirstName + " " + x.PersonalInformation.LastName,
                }).Where(x => x.PersonalInformationId == personalid || user == null).ToListAsync() ?? new List<RecommendDietAndExercisePlanViewModel>();
        }

        // Returns a single RecommendDietAndExercisePlan view model by PersonalInformationId.
        public async Task<RecommendDietAndExercisePlanViewModel?> GetRecommendPlanById(int id)
        {
            return await _context.RecommendDietAndExercisePlan.Where(x => x.Id == id)
                .Select(x => new RecommendDietAndExercisePlanViewModel
                {
                    Id = x.Id,
                    PersonalInformationId = x.PersonalInformationId,
                    DietName = x.DietName,
                    DietPlan = x.DietPlan,
                    Duration = x.Duration,
                    ExerciseName = x.ExerciseName,
                    ExercisePlan = x.ExercisePlan,
                    ExeDuration = x.ExeDuration,
                    Name = x.PersonalInformation.FirstName + " " + x.PersonalInformation.LastName,
                }).FirstOrDefaultAsync() ?? new RecommendDietAndExercisePlanViewModel();
        }

        // Creates a new record or updates an existing record based on PersonalInformationId.
        public async Task<bool> CreateOrUpdateRecommendPlan(RecommendDietAndExercisePlanViewModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    // Check for an existing record using PersonalInformationId as the lookup key.
                    var existingRecord = await _context.RecommendDietAndExercisePlan
                        .FirstOrDefaultAsync(x => x.PersonalInformationId == model.PersonalInformationId);

                    if (existingRecord != null)
                    {
                        // Update the existing record.
                        existingRecord.DietName = model.DietName;
                        existingRecord.DietPlan = model.DietPlan;
                        existingRecord.Duration = model.Duration;
                        existingRecord.ExerciseName = model.ExerciseName;
                        existingRecord.ExercisePlan = model.ExercisePlan;
                        existingRecord.ExeDuration = model.ExeDuration;
                    }
                }
                else
                {
                    // Create a new record.
                    var newRecord = new RecommendDietAndExercisePlan
                    {
                        PersonalInformationId = model.PersonalInformationId,
                        DietName = model.DietName,
                        DietPlan = model.DietPlan,
                        Duration = model.Duration,
                        ExerciseName = model.ExerciseName,
                        ExercisePlan = model.ExercisePlan,
                        ExeDuration = model.ExeDuration
                    };

                    await _context.RecommendDietAndExercisePlan.AddAsync(newRecord);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CreateOrUpdateRecommendPlan: {ex.Message}");
                return false;
            }
        }

        #endregion
        #region UserFitnessLog

        public async Task<List<HealthLogViewModel>> GetAllUserFitnessLogs()
        {
            try
            {
                var logs = await (
                    from health in _context.HealthLog
                    join personal in _context.PersonalInformation
                         on health.PersonalInformationId equals personal.Id
                    select new HealthLogViewModel
                    {
                        Id = health.Id,
                        PersonalInformationId = health.PersonalInformationId,
                        Date = health.Date,

                        // Workout
                        ExerciseName = health.ExerciseName,
                        DurationMinutes = health.DurationMinutes,
                        CaloriesBurned = health.CaloriesBurned,

                        // Nutrition

                        Calories = health.Calories,
                        ProteinGrams = health.ProteinGrams,
                        CarbGrams = health.CarbGrams,
                        FatGrams = health.FatGrams,

                        // Measurements
                        WeightKg = health.WeightKg,
                        WaistCm = health.WaistCm,
                        ChestCm = health.ChestCm,
                        HipCm = health.HipCm,
                        BMI = health.BMI,

                        // Name
                        PersonalInformationName = personal.FirstName + " " + personal.LastName
                    }
                ).ToListAsync();

                // Return the list of logs, or an empty list if no records are found
                return logs ?? new List<HealthLogViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllUserFitnessLogs: {ex.Message}");
                return new List<HealthLogViewModel>(); // Return empty list if an error occurs
            }
        }

        public async Task<HealthLogViewModel?> GetFitnessLogById(int id)
        {
            var user = _httpContext.HttpContext != null && _httpContext.HttpContext.User.IsInRole(UserRoles.User) ? _userId : null;

            return await (
                from health in _context.HealthLog
                join personal in _context.PersonalInformation
                     on health.PersonalInformationId equals personal.Id
                where health.PersonalInformationId == id && (user == null || health.CreatedBy == user)
                select new HealthLogViewModel
                {
                    Id = health.Id,
                    PersonalInformationId = health.PersonalInformationId,
                    Date = health.Date,

                    // Physical Activity
                    ExerciseName = health.ExerciseName,
                    DurationMinutes = health.DurationMinutes,
                    CaloriesBurned = health.CaloriesBurned,
                    SetsOrReps = health.SetsOrReps,
                    StepTaken = health.StepTaken,
                    PersonalRatings = health.PersonalRatings,

                    // Nutrition
                    Calories = health.Calories,
                    ProteinGrams = health.ProteinGrams,
                    CarbGrams = health.CarbGrams,
                    FatGrams = health.FatGrams,
                    WaterIntake = health.WaterIntake,
                    JunkConsumed = health.JunkConsumed ?? false,
                    AlcoholConsumed = health.AlcoholConsumed ?? false,
                    Supplements = health.Supplements,

                    // Measurements
                    WeightKg = health.WeightKg,
                    WaistCm = health.WaistCm,
                    ChestCm = health.ChestCm,
                    HipCm = health.HipCm,
                    BMI = health.BMI,

                    // Audit
                    CreatedBy = health.CreatedBy,
                    CreatedDate = health.CreatedDate,
                    UpdatedBy = health.UpdatedBy,
                    UpdatedDate = health.UpdatedDate,
                    DeletedBy = health.DeletedBy,
                    DeletedDate = health.DeletedDate,

                    // Joined name
                    PersonalInformationName = personal.FirstName + " " + personal.LastName
                }
            ).FirstOrDefaultAsync() ?? new HealthLogViewModel();
        }

        public async Task<bool> CreateFitnessLog(HealthLogViewModel model)
        {
            // Get the current user ID (if they're authenticated and in the 'User' role)
            var user = _httpContext.HttpContext != null && _httpContext.HttpContext.User.IsInRole(UserRoles.User) ? _userId : null;

            // Retrieve the user's personal information ID if the user is authenticated
            int? personalId = 0;
            if (user != null)
            {
                personalId = await _context.Users
                            .Where(u => u.Id == user)
                            .Select(u => u.PersonalInformationId)
                            .FirstOrDefaultAsync();
            }

            try
            {
                // Check if a fitness log for the user and date already exists
                var log = await _context.HealthLog
                    .FirstOrDefaultAsync(x => x.PersonalInformationId == model.PersonalInformationId &&
                                              x.Date.Date == model.Date.Date);

                if (log != null)
                {
                    // If the log exists, update it
                    log.ExerciseName = model.ExerciseName;
                    log.DurationMinutes = model.DurationMinutes;
                    log.CaloriesBurned = model.CaloriesBurned;


                    log.Calories = model.Calories;
                    log.ProteinGrams = model.ProteinGrams;
                    log.CarbGrams = model.CarbGrams;
                    log.FatGrams = model.FatGrams;


                    log.WeightKg = model.WeightKg;
                    log.WaistCm = model.WaistCm;
                    log.ChestCm = model.ChestCm;
                    log.HipCm = model.HipCm;
                    log.BMI = model.BMI;

                    log.UpdatedBy = _userId;
                    log.UpdatedDate = DateTime.UtcNow;  // Use UTC time for consistency
                }
                else
                {
                    // If no log exists, create a new one
                    log = new HealthLog
                    {
                        PersonalInformationId = personalId ?? 0, // Ensure it's not null
                        Date = model.Date,

                        ExerciseName = model.ExerciseName,
                        DurationMinutes = model.DurationMinutes,
                        CaloriesBurned = model.CaloriesBurned,


                        Calories = model.Calories,
                        ProteinGrams = model.ProteinGrams,
                        CarbGrams = model.CarbGrams,
                        FatGrams = model.FatGrams,


                        WeightKg = model.WeightKg,
                        WaistCm = model.WaistCm,
                        ChestCm = model.ChestCm,
                        HipCm = model.HipCm,
                        BMI = model.BMI,
                        JunkConsumed = model.JunkConsumed,
                        AlcoholConsumed = model.AlcoholConsumed,
                        PersonalRatings = model.PersonalRatings,
                        WaterIntake = model.WaterIntake,
                        Supplements = model.Supplements,
                        SetsOrReps = model.SetsOrReps,

                        CreatedBy = _userId,
                        CreatedDate = DateTime.UtcNow  // Use UTC time for consistency
                    };

                    await _context.HealthLog.AddAsync(log);  // Add the new log entry
                }

                // Save the changes to the database
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CreateFitnessLog: {ex.Message}");
                return false;  // Return false if an error occurs
            }
        }

        #endregion

        #region week
        public List<WeeklyProgressViewModel> GetWeeklyProgressLogs()
        {
            // Fetch fitness logs from your database
            var fitnessLogs = _context.HealthLog.ToList();

            // Group logs by week, using Monday as the start of the week
            var weeklyProgress = fitnessLogs
                .GroupBy(log => new
                {
                    WeekStart = GetStartOfWeek(log.Date),
                    WeekEnd = GetStartOfWeek(log.Date).AddDays(7) // The end date is 6 days after the start
                })
                .Select(group => new WeeklyProgressViewModel
                {
                    StartDate = group.Key.WeekStart,
                    EndDate = group.Key.WeekEnd,

                    // Calculate the totals
                    TotalCaloriesBurned = group.Sum(log => log.CaloriesBurned) ?? 0,
                    TotalStepsTaken = group.Sum(log =>
                        int.TryParse(log.StepTaken, out int steps) ? steps : 0), // Parse StepTaken string to integer safely
                    AverageWeight = group.Average(log => log.WeightKg) ?? 0,
                    AverageBMI = group.Average(log => log.BMI),
                    TotalWaterIntake = group.Sum(log => log.WaterIntake)
                })
                .OrderByDescending(x => x.StartDate) // Order by the most recent weeks
                .ToList();

            return weeklyProgress ?? new List<WeeklyProgressViewModel>();
        }


        private DateTime GetStartOfWeek(DateTime date)
        {
            var dayOfWeek = (int)date.DayOfWeek;
            var difference = dayOfWeek == 1 ? -7 : 1 - dayOfWeek;
            return date.AddDays(difference).Date;
        }

        #endregion

    }
}
