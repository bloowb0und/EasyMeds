using EasyMeds.WebAPI.Core.DTOs.Medicine;
using EasyMeds.WebAPI.Core.Entities;

namespace EasyMeds.WebAPI.Services.Abstractions;

public interface IMedicineService
{
    Task<List<MedicineDto>> GetMedicinesAsync();
    Task<MedicineDto?> GetMedicineByIdAsync(int medicineId);
    Task<int> AddMedicineAsync(MedicineCreateDto medicineCreateDto);
    Task<bool> UpdateMedicineAsync(int medicineId, MedicineUpdateDto updatedMedicine);
    Task<bool> DeleteMedicineAsync(int medicineId);
}