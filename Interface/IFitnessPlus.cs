using GymApplication.Models;
using static GymApplication.Models.BodyTypeViewModel;

namespace GymApplication.Interface
{
    public interface IFitnessPlus
    {
        #region AgeGroup
        Task<List<AgeGroupViewModel>> GetAllAgeGroups();
        Task<AgeGroupViewModel?> GetAgeGroupById(int id);
        Task<bool> CreateOrUpdateAgeGroup(AgeGroupViewModel model);
        #endregion
        #region BodyType
        Task<List<BodyTypeViewModel>> GetAllBodyTypes();
        Task<BodyTypeViewModel?> GetBodyTypeById(int id);
        Task<bool> CreateOrUpdateBodyType(BodyTypeViewModel model);
        #endregion
        #region BodyGoal
        Task<List<BodyGoalViewModel>> GetAllBodyGoals();
        Task<BodyGoalViewModel?> GetBodyGoalById(int id);
        Task<bool> CreateOrUpdateBodyGoal(BodyGoalViewModel model);
        #endregion
        #region WorkoutFrequency
        Task<List<WorkoutFrequencyViewModel>> GetAllWorkoutFrequencies();
        Task<WorkoutFrequencyViewModel?> GetWorkoutFrequencyById(int id);
        Task<bool> CreateOrUpdateWorkoutFrequency(WorkoutFrequencyViewModel model);
        #endregion
        #region TargetBody
        Task<List<TargetBodyViewModel>> GetAllTargetBodies();
        Task<TargetBodyViewModel?> GetTargetBodyById(int id);
        Task<bool> CreateOrUpdateTargetBody(TargetBodyViewModel model);
        #endregion
        #region ProblemArea
        Task<List<ProblemAreaViewModel>> GetAllProblemAreas();
        Task<ProblemAreaViewModel?> GetProblemAreaById(int id);
        Task<bool> CreateOrUpdateProblemArea(ProblemAreaViewModel model);
        #endregion
        #region StepDiet
        Task<List<StepDietViewModel>> GetAllStepDiets();
        Task<StepDietViewModel?> GetStepDietById(int id);
        Task<bool> CreateOrUpdateStepDiet(StepDietViewModel model);
        #endregion
        #region StepWater
        Task<List<StepWaterViewModel>> GetAllStepWaters();
        Task<StepWaterViewModel?> GetStepWaterById(int id);
        Task<bool> CreateOrUpdateStepWater(StepWaterViewModel model);
        #endregion
        #region StepWorkout
        Task<List<StepWorkoutViewModel>> GetAllStepWorkouts();
        Task<StepWorkoutViewModel?> GetStepWorkoutById(int id);
        Task<bool> CreateOrUpdateStepWorkout(StepWorkoutViewModel model);
        #endregion
        #region AdditionalGoal
        Task<List<AdditionalGoalViewModel>> GetAllAdditionalGoals();
        Task<AdditionalGoalViewModel?> GetAdditionalGoalById(int id);
        Task<bool> CreateOrUpdateAdditionalGoal(AdditionalGoalViewModel model);
        #endregion
        //New
        #region Main
        Task<List<PersonalInformationViewModel>> GetAllPersonalInformationRecords();
        Task<PersonalInformationViewModel> GetPersonalInformationById(int id);
        Task<PersonalInformationViewModel> GetDietPlanById(int id);
        Task<bool> UpdatePersonalInformation(PersonalInformationViewModel model);
        #endregion

        #region RecomendExercise
        Task<List<RecommendDietAndExercisePlanViewModel>> GetAllRecommendPlans();
        Task<RecommendDietAndExercisePlanViewModel?> GetRecommendPlanById(int id);
        Task<bool> CreateOrUpdateRecommendPlan(RecommendDietAndExercisePlanViewModel model);
        #endregion
        #region FitnessLog
        Task<List<HealthLogViewModel>> GetAllUserFitnessLogs();
        Task<HealthLogViewModel?> GetFitnessLogById(int id);
        Task<bool> CreateFitnessLog(HealthLogViewModel model);
        List<WeeklyProgressViewModel> GetWeeklyProgressLogs();
        #endregion
    }
}


