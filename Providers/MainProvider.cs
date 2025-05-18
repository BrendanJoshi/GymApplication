//using GymApplication.Data;
//using GymApplication.Models;
//using Microsoft.EntityFrameworkCore;
//using GymApplication.Interface;
//using GymApplication.Utilities;

//namespace GymApplication.Providers
//{

//    public class MainProvider : IMain
//    {
//        private readonly GymContext _context;
//        private readonly IUtility _utility;
//        public MainProvider(GymContext context, IUtility utility)
//        {
//            _context = context;
//            _utility = utility;
//        }
//        public Task<List<PersonalInformationViewModel>> AllPersonalInformation()
//        {
//            return _context.PersonalInformation
//                .Select(x => new PersonalInformationViewModel()
//                {
//                    Id = x.Id,
//                    FirstName = x.FirstName,
//                    LastName = x.LastName,                    
//                    GenderId = x.GenderId,
//                    GenderName = x.Gender.Name,
//                    Email = x.Email,
//                    MobileNumber = x.MobileNumber,
//                }).ToListAsync();

//        }
//        public async Task<PersonalInformationViewModel> GetPersonalInformation(int id)
//        {
//            var data = await _context.PersonalInformation.Where(x => x.Id == id).Select(x => new PersonalInformationViewModel()
//            {
//                Id = x.Id,
//                FirstName = x.FirstName,
//                LastName = x.LastName,
//                GenderId = x.GenderId,
//                Email = x.Email,
//                MobileNumber = x.MobileNumber,
//                ProfilePicture = x.ProfilePicture,
//                GenderName = x.Gender.Name,
//            }).FirstOrDefaultAsync();
//            return data ?? new PersonalInformationViewModel();

//        }
//        public async Task<bool> CreatePersonalInformation(PersonalInformationViewModel model)
//        {


//            try
//            {
//                if (model.Id > 0)
//                {
//                    var per = await _context.PersonalInformation.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
//                    if (per != null)
//                    {

//                        per.FirstName = model.FirstName;
//                        per.LastName = model.LastName;
//                        per.GenderId = model.GenderId;
//                        per.Email = model.Email;
//                        per.MobileNumber = model.MobileNumber;
//                        per.ProfilePicture = model.ProfilePicture;

//                        _context.Entry(per).State = EntityState.Modified;
//                    }
//                }
//                else
//                {
//                    var img = await _utility.UploadImgReturnPathAndName("ProfilePictures", model.ProfilePictureImg, "Profile");

//                    var add = new PersonalInformation()
//                    {
//                        Id = model.Id,
//                        FirstName = model.FirstName,
//                        LastName = model.LastName,
//                        GenderId = model.GenderId,
//                        Email = model.Email,
//                        MobileNumber = model.MobileNumber,
//                        ProfilePicture = img.FilePath,
//                    };
//                    await _context.PersonalInformation.AddAsync(add);
//                    await _context.SaveChangesAsync();
//                }

//                await _context.SaveChangesAsync();
//                return true;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        //#region healthHistory
//        //public async Task<List<HealthHistoryViewModel>> GetAllHealthHistory()
//        //{
//        //    return await _context.HealthHistory
//        //        .Select(x => new HealthHistoryViewModel()
//        //        {
//        //            Id = x.Id,
//        //            PersonalInformationId = x.PersonalInformationId,
//        //            Name = x.Name,
//        //            Allergies = x.Allergies,
//        //            Injuries = x.Injuries,
//        //            Surgeries = x.Surgeries,
//        //            ChronicIllness = x.ChornicIllness,
//        //            AnyOtherConditions = x.AnyOtherConditions
//        //        }).ToListAsync();
//        //}

//        //public async Task<HealthHistoryViewModel> GetHealthHistoryById(int id)
//        //{
//        //    var data = await _context.HealthHistory.Where(x => x.Id == id)
//        //        .Select(x => new HealthHistoryViewModel()
//        //        {
//        //            Id = x.Id,
//        //            PersonalInformationId = x.PersonalInformationId,
//        //            Name = x.Name,
//        //            Allergies = x.Allergies,
//        //            Injuries = x.Injuries,
//        //            Surgeries = x.Surgeries,
//        //            ChronicIllness = x.ChornicIllness,
//        //            AnyOtherConditions = x.AnyOtherConditions
//        //        }).FirstOrDefaultAsync();
//        //    return data ?? new HealthHistoryViewModel();
//        //}

//        //public async Task<bool> CreateHealthHistory(HealthHistoryViewModel model)
//        //{
//        //    try
//        //    {
//        //        if (model.Id > 0)
//        //        {
//        //            var existingRecord = await _context.HealthHistory.FirstOrDefaultAsync(x => x.Id == model.Id);
//        //            if (existingRecord != null)
//        //            {
//        //                existingRecord.Name = model.Name;
//        //                existingRecord.Allergies = model.Allergies;
//        //                existingRecord.Injuries = model.Injuries;
//        //                existingRecord.Surgeries = model.Surgeries;
//        //                existingRecord.ChornicIllness = model.ChronicIllness;
//        //                existingRecord.AnyOtherConditions = model.AnyOtherConditions;

//        //                _context.Entry(existingRecord).State = EntityState.Modified;
//        //            }
//        //        }
//        //        else
//        //        {
//        //            var newRecord = new HealthHistory()
//        //            {
//        //                PersonalInformationId = model.PersonalInformationId,
//        //                Name = model.Name,
//        //                Allergies = model.Allergies,
//        //                Injuries = model.Injuries,
//        //                Surgeries = model.Surgeries,
//        //                ChornicIllness = model.ChronicIllness,
//        //                AnyOtherConditions = model.AnyOtherConditions
//        //            };
//        //            await _context.HealthHistory.AddAsync(newRecord);
//        //        }

//        //        await _context.SaveChangesAsync();
//        //        return true;
//        //    }
//        //    catch (Exception)
//        //    {
//        //        return false;
//        //    }
//        //}
//        //#endregion

//        //#region GetAllWorkouts
//        //public async Task<List<WorkoutViewModel>> GetAllWorkouts()
//        //{
//        //    return await _context.Workouts
//        //        .Select(x => new WorkoutViewModel()
//        //        {
//        //            Id = x.Id,
//        //            Name = x.Name,
//        //            Date = x.Date,
//        //            PersonalInformationId = x.PersonalInformationId
//        //        }).ToListAsync();
//        //}

//        //public async Task<WorkoutViewModel> GetWorkoutById(int id)
//        //{
//        //    var data = await _context.Workouts.Where(x => x.Id == id)
//        //        .Select(x => new WorkoutViewModel()
//        //        {
//        //            Id = x.Id,
//        //            Name = x.Name,
//        //            Date = x.Date,
//        //            PersonalInformationId = x.PersonalInformationId
//        //        }).FirstOrDefaultAsync();
//        //    return data ?? new WorkoutViewModel();
//        //}

//        //public async Task<bool> CreateWorkout(WorkoutViewModel model)
//        //{
//        //    try
//        //    {
//        //        if (model.Id > 0)
//        //        {
//        //            var existingRecord = await _context.Workouts.FirstOrDefaultAsync(x => x.Id == model.Id);
//        //            if (existingRecord != null)
//        //            {
//        //                existingRecord.Name = model.Name;
//        //                existingRecord.Date = model.Date;
//        //                existingRecord.PersonalInformationId = model.PersonalInformationId;
//        //                _context.Entry(existingRecord).State = EntityState.Modified;
//        //            }
//        //        }
//        //        else
//        //        {
//        //            var newRecord = new Workout()
//        //            {
//        //                Name = model.Name,
//        //                Date = model.Date,
//        //                PersonalInformationId = model.PersonalInformationId
//        //            };
//        //            await _context.Workouts.AddAsync(newRecord);
//        //        }

//        //        await _context.SaveChangesAsync();
//        //        return true;
//        //    }
//        //    catch (Exception)
//        //    {
//        //        return false;
//        //    }
//        //}
//        //#endregion
//        //#region Excercise
//        //public async Task<List<ExerciseViewModel>> GetAllExercises()
//        //{
//        //    return await _context.Exercises
//        //        .Select(x => new ExerciseViewModel()
//        //        {
//        //            Id = x.Id,
//        //            Name = x.Name,
//        //            Description = x.Description,
//        //            CaloriesBurnedPerMin = x.CaloriesBurnedPerMin
//        //        }).ToListAsync();
//        //}

//        //public async Task<ExerciseViewModel> GetExerciseById(int id)
//        //{
//        //    var data = await _context.Exercises.Where(x => x.Id == id)
//        //        .Select(x => new ExerciseViewModel()
//        //        {
//        //            Id = x.Id,
//        //            Name = x.Name,
//        //            Description = x.Description,
//        //            CaloriesBurnedPerMin = x.CaloriesBurnedPerMin
//        //        }).FirstOrDefaultAsync();
//        //    return data ?? new ExerciseViewModel();
//        //}

//        //public async Task<bool> CreateExercise(ExerciseViewModel model)
//        //{
//        //    try
//        //    {
//        //        if (model.Id > 0)
//        //        {
//        //            var existingRecord = await _context.Exercises.FirstOrDefaultAsync(x => x.Id == model.Id);
//        //            if (existingRecord != null)
//        //            {
//        //                existingRecord.Name = model.Name;
//        //                existingRecord.Description = model.Description;
//        //                existingRecord.CaloriesBurnedPerMin = model.CaloriesBurnedPerMin;
//        //                _context.Entry(existingRecord).State = EntityState.Modified;
//        //            }
//        //        }
//        //        else
//        //        {
//        //            var newRecord = new Exercise()
//        //            {
//        //                Name = model.Name,
//        //                Description = model.Description,
//        //                CaloriesBurnedPerMin = model.CaloriesBurnedPerMin
//        //            };
//        //            await _context.Exercises.AddAsync(newRecord);
//        //        }

//        //        await _context.SaveChangesAsync();
//        //        return true;
//        //    }
//        //    catch (Exception)
//        //    {
//        //        return false;
//        //    }
//        //}
//        //#endregion
//        //#region Diet
//        //public async Task<List<DietViewModel>> GetAllDiets()
//        //{
//        //    return await _context.Diets
//        //        .Select(x => new DietViewModel()
//        //        {
//        //            Id = x.Id,
//        //            Meal = x.Meal,
//        //            Calories = x.Calories,
//        //            Date = x.Date,
//        //            PersonalInformationId = x.PersonalInformationId
//        //        }).ToListAsync();
//        //}

//        //public async Task<DietViewModel> GetDietById(int id)
//        //{
//        //    var data = await _context.Diets.Where(x => x.Id == id)
//        //        .Select(x => new DietViewModel()
//        //        {
//        //            Id = x.Id,
//        //            Meal = x.Meal,
//        //            Calories = x.Calories,
//        //            Date = x.Date,
//        //            PersonalInformationId = x.PersonalInformationId
//        //        }).FirstOrDefaultAsync();
//        //    return data ?? new DietViewModel();
//        //}

//        //public async Task<bool> CreateDiet(DietViewModel model)
//        //{
//        //    try
//        //    {
//        //        if (model.Id > 0)
//        //        {
//        //            var existingRecord = await _context.Diets.FirstOrDefaultAsync(x => x.Id == model.Id);
//        //            if (existingRecord != null)
//        //            {
//        //                existingRecord.Meal = model.Meal;
//        //                existingRecord.Calories = model.Calories;
//        //                existingRecord.Date = model.Date;
//        //                existingRecord.PersonalInformationId = model.PersonalInformationId;
//        //                _context.Entry(existingRecord).State = EntityState.Modified;
//        //            }
//        //        }
//        //        else
//        //        {
//        //            var newRecord = new Diet()
//        //            {
//        //                Meal = model.Meal,
//        //                Calories = model.Calories,
//        //                Date = model.Date,
//        //                PersonalInformationId = model.PersonalInformationId
//        //            };
//        //            await _context.Diets.AddAsync(newRecord);
//        //        }

//        //        await _context.SaveChangesAsync();
//        //        return true;
//        //    }
//        //    catch (Exception)
//        //    {
//        //        return false;
//        //    }
//        //}
//        //#endregion
//        //#region Goal
//        //public async Task<List<GoalViewModel>> GetAllGoals()
//        //{
//        //    return await _context.Goals
//        //        .Select(x => new GoalViewModel()
//        //        {
//        //            Id = x.Id,
//        //            GoalType = x.GoalType,
//        //            TargetWeight = x.TargetWeight,
//        //            TargetDate = x.TargetDate,
//        //            PersonalInformationId = x.PersonalInformationId
//        //        }).ToListAsync();
//        //}

//        //public async Task<GoalViewModel> GetGoalById(int id)
//        //{
//        //    var data = await _context.Goals.Where(x => x.Id == id)
//        //        .Select(x => new GoalViewModel()
//        //        {
//        //            Id = x.Id,
//        //            GoalType = x.GoalType,
//        //            TargetWeight = x.TargetWeight,
//        //            TargetDate = x.TargetDate,
//        //            PersonalInformationId = x.PersonalInformationId
//        //        }).FirstOrDefaultAsync();
//        //    return data ?? new GoalViewModel();
//        //}

//        //public async Task<bool> CreateGoal(GoalViewModel model)
//        //{
//        //    try
//        //    {
//        //        if (model.Id > 0)
//        //        {
//        //            var existingRecord = await _context.Goals.FirstOrDefaultAsync(x => x.Id == model.Id);
//        //            if (existingRecord != null)
//        //            {
//        //                existingRecord.GoalType = model.GoalType;
//        //                existingRecord.TargetWeight = model.TargetWeight;
//        //                existingRecord.TargetDate = model.TargetDate;
//        //                existingRecord.PersonalInformationId = model.PersonalInformationId;
//        //                _context.Entry(existingRecord).State = EntityState.Modified;
//        //            }
//        //        }
//        //        else
//        //        {
//        //            var newRecord = new Goal()
//        //            {
//        //                GoalType = model.GoalType,
//        //                TargetWeight = model.TargetWeight,
//        //                TargetDate = model.TargetDate,
//        //                PersonalInformationId = model.PersonalInformationId
//        //            };
//        //            await _context.Goals.AddAsync(newRecord);
//        //        }

//        //        await _context.SaveChangesAsync();
//        //        return true;
//        //    }
//        //    catch (Exception)
//        //    {
//        //        return false;
//        //    }
//        //}
//        //#endregion
//        //#region Progress
//        //public async Task<List<ProgressViewModel>> GetAllProgressRecords()
//        //{
//        //    return await _context.Progress
//        //        .Select(x => new ProgressViewModel()
//        //        {
//        //            Id = x.Id,
//        //            Date = x.Date,
//        //            Weight = x.Weight,
//        //            CaloriesBurned = x.CaloriesBurned,
//        //            PersonalInformationId = x.PersonalInformationId
//        //        }).ToListAsync();
//        //}

//        //public async Task<ProgressViewModel> GetProgressById(int id)
//        //{
//        //    var data = await _context.Progress.Where(x => x.Id == id)
//        //        .Select(x => new ProgressViewModel()
//        //        {
//        //            Id = x.Id,
//        //            Date = x.Date,
//        //            Weight = x.Weight,
//        //            CaloriesBurned = x.CaloriesBurned,
//        //            PersonalInformationId = x.PersonalInformationId
//        //        }).FirstOrDefaultAsync();
//        //    return data ?? new ProgressViewModel();
//        //}

//        //public async Task<bool> CreateProgress(ProgressViewModel model)
//        //{
//        //    try
//        //    {
//        //        if (model.Id > 0)
//        //        {
//        //            var existingRecord = await _context.Progress.FirstOrDefaultAsync(x => x.Id == model.Id);
//        //            if (existingRecord != null)
//        //            {
//        //                existingRecord.Date = model.Date;
//        //                existingRecord.Weight = model.Weight;
//        //                existingRecord.CaloriesBurned = model.CaloriesBurned;
//        //                existingRecord.PersonalInformationId = model.PersonalInformationId;
//        //                _context.Entry(existingRecord).State = EntityState.Modified;
//        //            }
//        //        }
//        //        else
//        //        {
//        //            var newRecord = new Progress()
//        //            {
//        //                Date = model.Date,
//        //                Weight = model.Weight,
//        //                CaloriesBurned = model.CaloriesBurned,
//        //                PersonalInformationId = model.PersonalInformationId
//        //            };
//        //            await _context.Progress.AddAsync(newRecord);
//        //        }

//        //        await _context.SaveChangesAsync();
//        //        return true;
//        //    }
//        //    catch (Exception)
//        //    {
//        //        return false;
//        //    }
//        //}
//        //#endregion
//    }
//}

