using EasyMeds.WebAPI.Core.DTOs.Medication;
using EasyMeds.WebAPI.Core.DTOs.Medicine;

namespace EasyMeds.WebAPI.Core.DTOs.Prescription;

public record PrescriptionCreateDto
{
    public int Dosage { get; set; }
    public int Duration { get; set; }
    public List<AddPrescriptionMedicineDto> Medicines { get; set; }
}