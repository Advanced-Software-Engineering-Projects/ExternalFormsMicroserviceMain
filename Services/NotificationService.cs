namespace ExternalFormsMicroserviceMain.Services
{
    public class NotificationService
    {
        public async Task SendNotificationAsync(string studentId, string message)
        {
            // Simulate sending notification (e.g., push notification)
            await Task.Delay(100);
            Console.WriteLine($"Notification sent to student {studentId}: {message}");
        }

        public async Task SendEmailAsync(string studentId, string message)
        {
            // Simulate sending email
            await Task.Delay(100);
            Console.WriteLine($"Email sent to student {studentId}: {message}");

        }
    }
}
