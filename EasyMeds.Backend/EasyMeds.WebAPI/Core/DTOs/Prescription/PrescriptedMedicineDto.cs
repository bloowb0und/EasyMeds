namespace EasyMeds.WebAPI.Core.DTOs.Medicine;

public record PrescriptedMedicineDto(int PrescriptionId, int MedicationId, int Dosage, int Frequency, int Duration, DateTime DatePrescribedUTC);