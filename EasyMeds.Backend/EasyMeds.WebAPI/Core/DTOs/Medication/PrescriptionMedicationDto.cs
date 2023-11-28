using EasyMeds.WebAPI.Core.DTOs.Medicine;

namespace EasyMeds.WebAPI.Core.DTOs.Medication;

public record PrescriptionMedicationDto
{
    public MedicineDto Medicine { get; set; }
    public int Frequency { get; set; }
    public DateTime? StartTimeUTC { get; set; }
    public DateTime? EndTimeUTC { get; set; }
}