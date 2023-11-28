using EasyMeds.WebAPI.Core.DTOs.Medication;

namespace EasyMeds.WebAPI.Core.DTOs.Prescription;

public record PrescriptionDto
{
    public int Id { get; set; }
    public DateTime? DatePrescribedUTC { get; set; }
    public int UserId { get; set; }
    public int? DoctorId { get; set; }
    public int Dosage { get; set; }
    public int Duration { get; set; }
    public List<PrescriptionMedicationDto> Medications { get; set; }
}