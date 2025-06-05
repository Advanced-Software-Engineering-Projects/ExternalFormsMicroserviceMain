using ExternalFormsMicroservice.DTOs;
using ExternalFormsMicroserviceMain.Models;
using System.Text.Json;

namespace ExternalFormsMicroserviceMain.Services
{
    public class FormApplicationService
    {
        private readonly string _dataFile = "formApplications.json";
        private readonly NotificationService _notificationService;

        public FormApplicationService(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        private async Task<List<FormApplication>> LoadApplicationsAsync()
        {
            if (!File.Exists(_dataFile))
            {
                return new List<FormApplication>();
            }
            var json = await File.ReadAllTextAsync(_dataFile);
            return JsonSerializer.Deserialize<List<FormApplication>>(json) ?? new List<FormApplication>();
        }

        private async Task SaveApplicationsAsync(List<FormApplication> applications)
        {
            var json = JsonSerializer.Serialize(applications, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_dataFile, json);
        }

        public async Task<List<FormApplicationDto>> GetAllApplicationsAsync()
        {
            var applications = await LoadApplicationsAsync();
            return applications.Select(a => new FormApplicationDto
            {
                ApplicationId = a.ApplicationId,
                StudentId = a.StudentId,
                FormType = a.FormType,
                Status = a.Status,
                SubmissionDate = a.SubmissionDate,
                IsQualified = a.IsQualified
            }).ToList();
        }

        public async Task<FormApplicationDto> ApplyForFormAsync(string studentId, string formType)
        {
            var applications = await LoadApplicationsAsync();

            var newApplication = new FormApplication
            {
                ApplicationId = Guid.NewGuid().ToString(),
                StudentId = studentId,
                FormType = formType,
                Status = "Pending",
                SubmissionDate = DateTime.UtcNow,
                IsQualified = CheckQualification(studentId, formType)
            };

            applications.Add(newApplication);
            await SaveApplicationsAsync(applications);

            if (newApplication.IsQualified)
            {
                await _notificationService.SendNotificationAsync(studentId, $"Your application for {formType} has been approved.");
                await _notificationService.SendEmailAsync(studentId, $"Your application for {formType} has been approved.");
            }
            else
            {
                await _notificationService.SendNotificationAsync(studentId, $"Your application for {formType} is pending review.");
            }

            return new FormApplicationDto
            {
                ApplicationId = newApplication.ApplicationId,
                StudentId = newApplication.StudentId,
                FormType = newApplication.FormType,
                Status = newApplication.Status,
                SubmissionDate = newApplication.SubmissionDate,
                IsQualified = newApplication.IsQualified
            };
        }

        private bool CheckQualification(string studentId, string formType)
        {
            // Simplified qualification logic for demonstration
            // In real scenario, check student's academic records, fees, etc.
            if (formType == "Graduation")
            {
                // Assume student qualifies if studentId ends with an even digit
                return int.TryParse(studentId[^1..], out int lastDigit) && lastDigit % 2 == 0;
            }
            else if (formType == "Compassionate" || formType == "Aegrotat" || formType == "Re-sit")
            {
                // Assume all compassionate/Aegrotat/Re-sit applications require review (not qualified automatically)
                return false;
            }
            return false;
        }

        public async Task<string> ApplyReconsiderationFormAsync(ReconsiderationFormDto form)
        {
            var applications = await LoadApplicationsAsync();

            var newApplication = new FormApplication
            {
                ApplicationId = Guid.NewGuid().ToString(),
                StudentId = form.StudentId,
                FormType = "Reconsideration",
                Status = "Pending",
                SubmissionDate = DateTime.UtcNow,
                IsQualified = false
            };

            applications.Add(newApplication);
            await SaveApplicationsAsync(applications);

            await _notificationService.SendNotificationAsync(form.StudentId, "Your reconsideration form has been submitted.");
            await _notificationService.SendEmailAsync(form.StudentId, "Your reconsideration form has been submitted.");

            return newApplication.ApplicationId;
        }

        public async Task<string> ApplyCompassionateAegrotatFormAsync(CompassionateAegrotatFormDto form)
        {
            var applications = await LoadApplicationsAsync();

            var newApplication = new FormApplication
            {
                ApplicationId = Guid.NewGuid().ToString(),
                StudentId = form.StudentId,
                FormType = "CompassionateAegrotat",
                Status = "Pending",
                SubmissionDate = DateTime.UtcNow,
                IsQualified = false
            };

            applications.Add(newApplication);
            await SaveApplicationsAsync(applications);

            await _notificationService.SendNotificationAsync(form.StudentId, "Your compassionate/aegrotat form has been submitted.");
            await _notificationService.SendEmailAsync(form.StudentId, "Your compassionate/aegrotat form has been submitted.");

            return newApplication.ApplicationId;
        }

        public async Task<string> ApplyCompletionProgrammeFormAsync(CompletionProgrammeFormDto form)
        {
            var applications = await LoadApplicationsAsync();

            var newApplication = new FormApplication
            {
                ApplicationId = Guid.NewGuid().ToString(),
                StudentId = form.StudentId,
                FormType = "CompletionProgramme",
                Status = "Pending",
                SubmissionDate = DateTime.UtcNow,
                IsQualified = false
            };

            applications.Add(newApplication);
            await SaveApplicationsAsync(applications);

            await _notificationService.SendNotificationAsync(form.StudentId, "Your completion programme form has been submitted.");
            await _notificationService.SendEmailAsync(form.StudentId, "Your completion programme form has been submitted.");

            return newApplication.ApplicationId;
        }
    }
}
