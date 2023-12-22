using Newtonsoft.Json;

namespace EasyMeds.IoT;

public record PrescriptedMedicineDto
{
    [JsonProperty("prescriptionId")]
    public int PrescriptionId { get; init; }

    [JsonProperty("medicationId")]
    public int MedicationId { get; init; }

    [JsonProperty("dosage")]
    public int Dosage { get; init; }

    [JsonProperty("frequency")]
    public int Frequency { get; init; }

    [JsonProperty("duration")]
    public int Duration { get; init; }

    [JsonProperty("datePrescribedUTC")]
    public DateTime DatePrescribedUTC { get; init; }
}

public record PrescriptedMedicineDtoList(PrescriptedMedicineDto[] PrescriptedMedicineDtos);