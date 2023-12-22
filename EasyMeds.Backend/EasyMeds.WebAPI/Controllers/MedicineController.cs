﻿using System.Security.Claims;
using EasyMeds.WebAPI.Core.Attributes;
using EasyMeds.WebAPI.Core.DTOs.Medicine;
using EasyMeds.WebAPI.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyMeds.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[DoctorRoleInterceptor]
[Authorize]
public class MedicineController(IMedicineService medicineService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<MedicineDto>>> GetMedicines()
    {
        var medicines = await medicineService.GetMedicinesAsync();
        return Ok(medicines);
    }

    [HttpGet("{medicineId:int}")]
    public async Task<ActionResult<MedicineDto>> GetMedicineById(int medicineId)
    {
        var medicine = await medicineService.GetMedicineByIdAsync(medicineId);

        if (medicine == null)
            return NotFound();

        return Ok(medicine);
    }

    [HttpPost]
    public async Task<ActionResult<int>> AddMedicine([FromBody] MedicineCreateDto medicine)
    {
        var addedMedicineId = await medicineService.AddMedicineAsync(medicine);
        return Ok(addedMedicineId);
    }

    [HttpPut("{medicineId:int}")]
    public async Task<ActionResult<bool>> UpdateMedicine(int medicineId, [FromBody] MedicineUpdateDto updatedMedicine)
    {
        var result = await medicineService.UpdateMedicineAsync(medicineId, updatedMedicine);

        if (!result)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{medicineId:int}")]
    public async Task<ActionResult<bool>> DeleteMedicine(int medicineId)
    {
        var result = await medicineService.DeleteMedicineAsync(medicineId);

        if (!result)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("/takeMedicines")]
    public async Task<ActionResult<List<PrescriptedMedicineDto>>> RetrieveUserMedicine(int userId)
    {
        List<PrescriptedMedicineDto> result;

        try
        {
            result = await medicineService.GetPrescriptedMedicines(userId);
        }
        catch (ArgumentException)
        {
            // error in case of bad input
            return BadRequest("Bad input");
        }
        catch (FieldAccessException)
        {
            // error in case of no medications left to take today
            return BadRequest("No medications left to take today");
        }
        catch (Exception)
        {
            // error in case of unexpected error
            return Problem("Unexpected error happened.");
        }

        if (result.Count < 1)
        {
           // not found in case if no medications to take were found
            return NotFound("No prescribed medications were found. ");
        }
        
        return Ok(result);
    }
}
