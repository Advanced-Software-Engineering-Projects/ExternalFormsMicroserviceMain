using System;

namespace ExternalFormsMicroservice.DTOs
{
    public class FormApplicationDto
    {
        public string ApplicationId { get; set; }
        public string StudentId { get; set; }
        public string FormType { get; set; }
        public string Status { get; set; }
        public DateTime SubmissionDate { get; set; }
        public bool IsQualified { get; set; }
    }
}
