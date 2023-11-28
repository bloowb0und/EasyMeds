using EasyMeds.WebAPI.Core.Contexts;
using EasyMeds.WebAPI.Core.DTOs.Medicine;
using EasyMeds.WebAPI.Core.Entities;
using EasyMeds.WebAPI.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EasyMeds.WebAPI.Services.Implementations;

public class MedicineService(EasyMedsDbContext context) : IMedicineService
{
    public async Task<List<MedicineDto>> GetMedicinesAsync()
    {
        return await context.Medicines.Select(m => new MedicineDto
        {
            MedicineId = m.Id,
            Name = m.Name,
            Description = m.Description,
            SideEffects = m.SideEffects,
            Interactions = m.Interactions
        }).ToListAsync();
    }

    public async Task<MedicineDto?> GetMedicineByIdAsync(int medicineId)
    {
        return await context.Medicines.Where(m => m.Id == medicineId)
            .Select(m => new MedicineDto
            {
                MedicineId = m.Id,
                Name = m.Name,
                Description = m.Description,
                SideEffects = m.SideEffects,
                Interactions = m.Interactions
            })
            .FirstOrDefaultAsync();
    }

    public async Task<int> AddMedicineAsync(MedicineCreateDto medicineCreateDto)
    {
        var medicine = new Medicine
        {
            Name = medicineCreateDto.Name,
            Description = medicineCreateDto.Description,
            SideEffects = medicineCreateDto.SideEffects,
            Interactions = medicineCreateDto.Interactions
        };
        
        await context.Medicines.AddAsync(medicine);
        await context.SaveChangesAsync();
        return medicine.Id;
    }

    public async Task<bool> UpdateMedicineAsync(int medicineId, MedicineUpdateDto updatedMedicine)
    {
        var existingMedicine = await context.Medicines.FindAsync(medicineId);

        if (existingMedicine == null)
            return false;

        existingMedicine.Name = updatedMedicine.Name;
        existingMedicine.Description = updatedMedicine.Description;
        existingMedicine.SideEffects = updatedMedicine.SideEffects;
        existingMedicine.Interactions = updatedMedicine.Interactions;

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteMedicineAsync(int medicineId)
    {
        var medicine = await context.Medicines.FindAsync(medicineId);

        if (medicine == null)
            return false;

        context.Medicines.Remove(medicine);
        await context.SaveChangesAsync();
        return true;
    }
}
