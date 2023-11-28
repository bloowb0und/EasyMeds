namespace EasyMeds.WebAPI.Core.DTOs.Doctor;

public record UpdateDoctorDto(string Email, string Password, string Name, string Specialty);