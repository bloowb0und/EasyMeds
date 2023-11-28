using EasyMeds.WebAPI.Core.DTOs.Medication;
using EasyMeds.WebAPI.Core.DTOs.Medicine;

namespace EasyMeds.WebAPI.Core.DTOs.Prescription;

public record PrescriptionUpdateDto
{
    public int Dosage { get; set; }
    public int Duration { get; set; }
}