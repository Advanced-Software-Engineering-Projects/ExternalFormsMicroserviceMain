using System;

namespace ExternalFormsMicroservice.DTOs
{
    public class CompletionProgrammeFormDto
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PostalAddress { get; set; }
        public string Programme { get; set; }
        public bool DeclarationAgreed { get; set; }
        public string ApplicantSignatureBase64 { get; set; }
        public DateTime? Date { get; set; }
    }
}
