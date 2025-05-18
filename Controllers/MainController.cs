//using GymApplication.Interface;
//using GymApplication.Models;
//using GymApplication.Utilities;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace GymApplication.Controllers
//{
//    [Authorize]

//    public class MainController : Controller
//    {
//        private readonly IMain main = null;
//        private readonly IUtility _utility;

//        public MainController(IMain _main, IUtility utility)
//        {
//            main = _main;
//            _utility = utility;

//        }
//        #region PersonalInformation
//        public async Task<IActionResult> PersonalInformation()
//        {
//            return View(await main.AllPersonalInformation());
//        }

//        public async Task<IActionResult> CreatePersonalInformation(int id)
//        {
//            return View(await main.GetPersonalInformation(id));
//        }
//        [HttpPost]
//        public async Task<IActionResult> CreatePersonalInformation([FromForm] PersonalInformationViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                if (await main.CreatePersonalInformation(model))
//                {

//                    return RedirectToAction("PersonalInformation");
//                }
//            }
//            return View(model);
//        }
//        public async Task<IActionResult> PersonalInformationDetails(int id)
//        {
//            return View(await main.GetPersonalInformation(id));
//        }
//        #endregion
//        //#region health
//        //public async Task<IActionResult> HealthHistory()
//        //{
//        //    return View(await main.GetAllHealthHistory());
//        //}

//        //public async Task<IActionResult> CreateHealthHistory(int id)
//        //{
//        //    return View(await main.GetHealthHistoryById(id));
//        //}

//        //[HttpPost]
//        //public async Task<IActionResult> CreateHealthHistory([FromForm] HealthHistoryViewModel model)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        if (await main.CreateHealthHistory(model))
//        //        {
//        //            return RedirectToAction("HealthHistory");
//        //        }
//        //    }
//        //    return View(model);
//        //}

//        //public async Task<IActionResult> HealthHistoryDetails(int id)
//        //{
//        //    return View(await main.GetHealthHistoryById(id));
//        //}
//        //#endregion

//        //#region Workout

//        //public async Task<IActionResult> Workouts()
//        //{
//        //    return View(await main.GetAllWorkouts());
//        //}

//        //public async Task<IActionResult> CreateWorkout(int id)
//        //{
//        //    return View(await main.GetWorkoutById(id));
//        //}

//        //[HttpPost]
//        //public async Task<IActionResult> CreateWorkout([FromForm] WorkoutViewModel model)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        if (await main.CreateWorkout(model))
//        //        {
//        //            return RedirectToAction("Workouts");
//        //        }
//        //    }
//        //    return View(model);
//        //}

//        //public async Task<IActionResult> WorkoutDetails(int id)
//        //{
//        //    return View(await main.GetWorkoutById(id));
//        //}

//        //#endregion

//        //#region Exercise

//        //public async Task<IActionResult> Exercises()
//        //{
//        //    return View(await main.GetAllExercises());
//        //}

//        //public async Task<IActionResult> CreateExercise(int id)
//        //{
//        //    return View(await main.GetExerciseById(id));
//        //}

//        //[HttpPost]
//        //public async Task<IActionResult> CreateExercise([FromForm] ExerciseViewModel model)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        if (await main.CreateExercise(model))
//        //        {
//        //            return RedirectToAction("Exercises");
//        //        }
//        //    }
//        //    return View(model);
//        //}

//        //public async Task<IActionResult> ExerciseDetails(int id)
//        //{
//        //    return View(await main.GetExerciseById(id));
//        //}

//        //#endregion

//        //#region Diet

//        //public async Task<IActionResult> Diets()
//        //{
//        //    return View(await main.GetAllDiets());
//        //}

//        //public async Task<IActionResult> CreateDiet(int id)
//        //{
//        //    return View(await main.GetDietById(id));
//        //}

//        //[HttpPost]
//        //public async Task<IActionResult> CreateDiet([FromForm] DietViewModel model)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        if (await main.CreateDiet(model))
//        //        {
//        //            return RedirectToAction("Diets");
//        //        }
//        //    }
//        //    return View(model);
//        //}

//        //public async Task<IActionResult> DietDetails(int id)
//        //{
//        //    return View(await main.GetDietById(id));
//        //}
//        //#endregion

//        //#region Goal

//        //public async Task<IActionResult> Goals()
//        //{
//        //    return View(await main.GetAllGoals());
//        //}

//        //public async Task<IActionResult> CreateGoal(int id)
//        //{
//        //    return View(await main.GetGoalById(id));
//        //}

//        //[HttpPost]
//        //public async Task<IActionResult> CreateGoal([FromForm] GoalViewModel model)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        if (await main.CreateGoal(model))
//        //        {
//        //            return RedirectToAction("Goals");
//        //        }
//        //    }
//        //    return View(model);
//        //}

//        //public async Task<IActionResult> GoalDetails(int id)
//        //{
//        //    return View(await main.GetGoalById(id));
//        //}
//        //#endregion

//        //#region Progress

//        //public async Task<IActionResult> ProgressRecords()
//        //{
//        //    return View(await main.GetAllProgressRecords());
//        //}

//        //public async Task<IActionResult> CreateProgress(int id)
//        //{
//        //    return View(await main.GetProgressById(id));
//        //}

//        //[HttpPost]
//        //public async Task<IActionResult> CreateProgress([FromForm] ProgressViewModel model)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        if (await main.CreateProgress(model))
//        //        {
//        //            return RedirectToAction("ProgressRecords");
//        //        }
//        //    }
//        //    return View(model);
//        //}

//        //public async Task<IActionResult> ProgressDetails(int id)
//        //{
//        //    return View(await main.GetProgressById(id));
//        //}

//        //#endregion

//    }

//}







