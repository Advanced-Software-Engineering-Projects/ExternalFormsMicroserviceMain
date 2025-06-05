using System;

namespace ExternalFormsMicroservice.DTOs
{
    public class ReconsiderationFormDto
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string PostalAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Sponsorship { get; set; }
        public string CourseCode { get; set; }
        public string CourseLecturer { get; set; }
        public string CourseTitle { get; set; }
        public string ReceiptNo { get; set; }
        public string PaymentConfirmationFileName { get; set; }
        public string PaymentConfirmationFileBase64 { get; set; }
    }
}
