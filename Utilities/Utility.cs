using GymApplication.Data;
using GymApplication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GymApplication.Utilities
{
	public class Utility:IUtility
	{
		private readonly ILogger _logger;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly GymContext _context;
		public Utility (GymContext context,IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
            _webHostEnvironment = webHostEnvironment;
		}
     
        public async Task<SelectList> GetGenderList()
        {
            return new SelectList(await _context.Gender.ToListAsync(), "Id", "Name");
        }
        public async Task<SelectList> GetPersonalInformation()
        {
            var aa = "";
            var data = await _context.PersonalInformation.Select(x => new { x.Id, aa = x.FirstName + " " + x.LastName }).ToListAsync();
            return new SelectList(data,"Id","aa" );
        }
        public async Task<FileUploadViewModel> UploadImgReturnPathAndName(string folderName, IFormFile file, string name)
        {
            try
            {
                var model = new FileUploadViewModel();
                string defaultFolder = "Gallery";
                if (file == null) return model;
                name = string.IsNullOrEmpty(name) ? "Gym" : name;
                var fileExt = Path.GetExtension(file.FileName).Substring(1);
                folderName = string.IsNullOrEmpty(folderName) ? defaultFolder : folderName;
                folderName = folderName.Equals(defaultFolder) ? $"{defaultFolder}/AppImage/" : $"{defaultFolder}/{folderName}/";
                model.FileName = name + "_" + Guid.NewGuid().ToString() + "." + fileExt;
                var returnPath = folderName + model.FileName;

                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderName);
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);// if Path not present than create

                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, returnPath);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                model.FilePath = "/" + returnPath;
                return model;
            }
            catch (Exception ex)
            {
                return new FileUploadViewModel();
            }
        }
        public async Task<SelectList> GetTargetBodies()
        {
            return new SelectList(await _context.TargetBody.ToListAsync(), "Id", "Name");
        }  
        public async Task<SelectList> GetBodyGoals()
        {
            return new SelectList(await _context.BodyGoal.ToListAsync(), "Id", "Name");
        }

        public async Task<SelectList> GetDuration()
        {
            List<SelectListItem> data = new List<SelectListItem>();
            data.Add(new SelectListItem() { Text = "Daily", Value = "Daily" });
            data.Add(new SelectListItem() { Text = "Weekly", Value = "Weekly" });
            data.Add(new SelectListItem() { Text = "Every 10 days", Value = "Every 10 days" });
            data.Add(new SelectListItem() { Text = "Every 15 days", Value = "Every 15 days" });
            data.Add(new SelectListItem() { Text = "Monthly", Value = "Monthly" });

            return new SelectList(data, "Value", "Text");
        }
        public async Task<SelectList> ExerciseType()
        {
            List<SelectListItem> data = new List<SelectListItem>();
            data.Add(new SelectListItem() { Text = "Cardio", Value = "Cardio" });
            data.Add(new SelectListItem() { Text = "Strength", Value = "Strength" });
            data.Add(new SelectListItem() { Text = "Yoga", Value = "Yoga" });
            data.Add(new SelectListItem() { Text = "HIIT", Value = "HIIT" });
           

            return new SelectList(data, "Value", "Text");
        }
        public async Task<int?> GetPersonalInformationIdByUserIdAsync(string userId)
        {
            // Fetch user from the Users table (AspNetUsers in IdentityDbContext)
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);  // Ensure you're querying by the UserId (IdentityId)

            // Return the PersonalInformationId if found, otherwise null
            return user?.PersonalInformationId;
        }

    }
}
