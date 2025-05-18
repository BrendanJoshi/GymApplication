using GymApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymApplication.Utilities
{
	public interface IUtility
	{
      
		Task<FileUploadViewModel> UploadImgReturnPathAndName(string folderName, IFormFile img,string name);
		Task<SelectList> GetGenderList();
		Task<SelectList> GetPersonalInformation();
        Task<SelectList> GetTargetBodies();
        Task<SelectList> GetBodyGoals();
        Task<SelectList> GetDuration();
        Task<SelectList> ExerciseType();
        Task<int?> GetPersonalInformationIdByUserIdAsync(string userId);

    }
}
