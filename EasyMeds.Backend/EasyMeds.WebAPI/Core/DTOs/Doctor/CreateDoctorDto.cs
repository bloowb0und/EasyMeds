namespace EasyMeds.WebAPI.Core.DTOs.Doctor;

public record CreateDoctorDto(string Email, string Password, string Name, string Specialty);