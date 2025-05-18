using GymApplication.Data;
using GymApplication.Interface;
using GymApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static GymApplication.Models.BodyTypeViewModel;

namespace GymApplication.Controllers
{
    public class FitnessPlusController : Controller
    {
        private readonly IFitnessPlus main;

        public FitnessPlusController(IFitnessPlus mainProvider)
        {
            main = mainProvider;
        }

        #region AgeGroup
        public async Task<IActionResult> AgeGroups()
        {
            return View(await main.GetAllAgeGroups());
        }

        public async Task<IActionResult> CreateAgeGroup(int id)
        {
            return View(await main.GetAgeGroupById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAgeGroup([FromForm] AgeGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await main.CreateOrUpdateAgeGroup(model))
                {
                    return RedirectToAction("AgeGroups");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> AgeGroupDetails(int id)
        {
            return View(await main.GetAgeGroupById(id));
        }
        #endregion
        #region BodyType
        public async Task<IActionResult> BodyTypes()
        {
            return View(await main.GetAllBodyTypes());
        }

        public async Task<IActionResult> CreateBodyType(int id)
        {
            return View(await main.GetBodyTypeById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBodyType([FromForm] BodyTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await main.CreateOrUpdateBodyType(model))
                {
                    return RedirectToAction("BodyTypes");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> BodyTypeDetails(int id)
        {
            return View(await main.GetBodyTypeById(id));
        }
        #endregion
        #region BodyGoal
        public async Task<IActionResult> BodyGoals()
        {
            return View(await main.GetAllBodyGoals());
        }

        public async Task<IActionResult> CreateBodyGoal(int id)
        {
            return View(await main.GetBodyGoalById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBodyGoal([FromForm] BodyGoalViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await main.CreateOrUpdateBodyGoal(model))
                {
                    return RedirectToAction("BodyGoals");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> BodyGoalDetails(int id)
        {
            return View(await main.GetBodyGoalById(id));
        }
        #endregion
        #region TargetBody
        public async Task<IActionResult> TargetBodies()
        {
            return View(await main.GetAllTargetBodies());
        }

        public async Task<IActionResult> CreateTargetBody(int id)
        {
            return View(await main.GetTargetBodyById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTargetBody([FromForm] TargetBodyViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await main.CreateOrUpdateTargetBody(model))
                {
                    return RedirectToAction("TargetBodies");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> TargetBodyDetails(int id)
        {
            return View(await main.GetTargetBodyById(id));
        }
        #endregion
        #region ProblemArea
        public async Task<IActionResult> ProblemAreas()
        {
            return View(await main.GetAllProblemAreas());
        }

        public async Task<IActionResult> CreateProblemArea(int id)
        {
            return View(await main.GetProblemAreaById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProblemArea([FromForm] ProblemAreaViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await main.CreateOrUpdateProblemArea(model))
                {
                    return RedirectToAction("ProblemAreas");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ProblemAreaDetails(int id)
        {
            return View(await main.GetProblemAreaById(id));
        }
        #endregion
        #region StepDiet
        public async Task<IActionResult> StepDiets()
        {
            return View(await main.GetAllStepDiets());
        }

        public async Task<IActionResult> CreateStepDiet(int id)
        {
            return View(await main.GetStepDietById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStepDiet([FromForm] StepDietViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await main.CreateOrUpdateStepDiet(model))
                {
                    return RedirectToAction("StepDiets");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> StepDietDetails(int id)
        {
            return View(await main.GetStepDietById(id));
        }
        #endregion
        #region StepWater
        public async Task<IActionResult> StepWaters()
        {
            return View(await main.GetAllStepWaters());
        }

        public async Task<IActionResult> CreateStepWater(int id)
        {
            return View(await main.GetStepWaterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStepWater([FromForm] StepWaterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await main.CreateOrUpdateStepWater(model))
                {
                    return RedirectToAction("StepWaters");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> StepWaterDetails(int id)
        {
            return View(await main.GetStepWaterById(id));
        }
        #endregion
        #region StepWorkout
        public async Task<IActionResult> StepWorkouts()
        {
            return View(await main.GetAllStepWorkouts());
        }

        public async Task<IActionResult> CreateStepWorkout(int id)
        {
            return View(await main.GetStepWorkoutById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStepWorkout([FromForm] StepWorkoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await main.CreateOrUpdateStepWorkout(model))
                {
                    return RedirectToAction("StepWorkouts");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> StepWorkoutDetails(int id)
        {
            return View(await main.GetStepWorkoutById(id));
        }
        #endregion
        #region StepWorkoutFrequency
        public async Task<IActionResult> StepWorkoutsFrequency()
        {
            return View(await main.GetAllWorkoutFrequencies());
        }

        public async Task<IActionResult> CreateStepWorkoutsFrequency(int id)
        {
            return View(await main.GetWorkoutFrequencyById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStepWorkoutsFrequency([FromForm] WorkoutFrequencyViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await main.CreateOrUpdateWorkoutFrequency(model))
                {
                    return RedirectToAction("StepWorkoutsFrequency");
                }
            }
            return View(model);
        }

        #endregion
        #region AdditionalGoal
        public async Task<IActionResult> AdditionalGoals()
        {
            return View(await main.GetAllAdditionalGoals());
        }

        public async Task<IActionResult> CreateAdditionalGoal(int id)
        {
            return View(await main.GetAdditionalGoalById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdditionalGoal([FromForm] AdditionalGoalViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await main.CreateOrUpdateAdditionalGoal(model))
                {
                    return RedirectToAction("AdditionalGoals");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> AdditionalGoalDetails(int id)
        {
            return View(await main.GetAdditionalGoalById(id));
        }
        #endregion
        #region PersonalInformation


        public async Task<IActionResult> PersonalInformationList()
        {
            var data = await main.GetAllPersonalInformationRecords();
            return View(data);
        }

        [AllowAnonymous]
        public async Task<IActionResult> PersonalInformationDetails(int pid)
        {
            return View(await main.GetDietPlanById(pid));

        }
        public async Task<IActionResult> PersonAllDetails(int id)
        {
            return View(await main.GetPersonalInformationById(id));

        }
        public async Task<IActionResult> PersonInfo(int id)
        {
            return View(await main.GetPersonalInformationById(id));

        }

        [AllowAnonymous]
        public async Task<IActionResult> PersonalInformation(int id)
        {
            var data = await main.GetPersonalInformationById(id);
            return View(data);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PersonalInformation([FromForm] PersonalInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await main.UpdatePersonalInformation(model))
                {
                    int id = model.Id;

                    // Redirect to PersonalInformationDetails with the captured `id`
                    return RedirectToAction("PersonalInformationDetails", new { id = id });
                    //return RedirectToAction("BodyGoals");
                }
            }
            return View(model);
        }

        #endregion
        #region RecommendedPlan
        public async Task<IActionResult> RecommendedPlanList()
        {
            return View(await main.GetAllRecommendPlans());
        }

        public async Task<IActionResult> CreateRecommendedPlan(int id)
        {
            return View(await main.GetRecommendPlanById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecommendedPlan(RecommendDietAndExercisePlanViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await main.CreateOrUpdateRecommendPlan(model))
                {
                    return RedirectToAction("RecommendedPlanList");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> RecommendedPlanDetails(int id)
        {
            return View(await main.GetRecommendPlanById(id));
        }
        #endregion


        //#region UserFitnessLog
        //public async Task<IActionResult> FitnessLog()
        //{
        //    return View(await main.GetAllUserFitnessLogs());
        //}

        //public async Task<IActionResult> CreateFitnessLog(int id)
        //{
        //    return View(await main.GetFitnessLogById(id));
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateFitnessLog(UserFitnessLogViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (await main.CreateFitnessLog(model))
        //        {
        //            return RedirectToAction("FitnessLog");
        //        }
        //    }
        //    return View(model);
        //}

        //public async Task<IActionResult> UserFitnessDetails(int id)
        //{
        //    return View(await main.GetFitnessLogById(id));
        //}
        //#endregion
        #region Controller Actions
        public async Task<IActionResult> FitnessLog()
        {
            return View(await main.GetAllUserFitnessLogs());
        }

        public async Task<IActionResult> CreateFitnessLog(int id)
        {
            return View(await main.GetFitnessLogById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFitnessLog(HealthLogViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await main.CreateFitnessLog(model))
                {
                    return RedirectToAction("FitnessLog");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> UserFitnessDetails(int id)
        {
            return View(await main.GetFitnessLogById(id));
        }
        public async Task<IActionResult> Statistics(int id)
        {
            return View(await main.GetFitnessLogById(id));
        }
        #endregion

        public IActionResult ViewStatistics()
        {
            
            var weeklyProgress = main.GetWeeklyProgressLogs();

            return View(weeklyProgress);
        }
    }




}

