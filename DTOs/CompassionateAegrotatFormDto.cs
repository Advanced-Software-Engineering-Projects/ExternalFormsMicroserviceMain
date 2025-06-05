using System;
using System.Collections.Generic;

namespace ExternalFormsMicroservice.DTOs
{
    public class MissedExamDto
    {
        public string CourseCode { get; set; }
        public DateTime? ExamDate { get; set; }
        public string ExamStartTime { get; set; }
        public string ApplyingFor { get; set; }
    }

    public class CompassionateAegrotatFormDto
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Campus { get; set; }
        public string Telephone { get; set; }
        public string PostalAddress { get; set; }
        public string Semester { get; set; }
        public int? Year { get; set; }
        public List<MissedExamDto> MissedExams { get; set; }
        public string Reason { get; set; }
        public string SupportingDocumentsFileName { get; set; }
        public string SupportingDocumentsFileBase64 { get; set; }
        public string ApplicantSignatureBase64 { get; set; }
        public DateTime? Date { get; set; }
    }
}
