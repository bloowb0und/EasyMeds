using EasyMeds.WebAPI.Core.DTOs.Doctor;
using EasyMeds.WebAPI.Core.DTOs.Prescription;
using EasyMeds.WebAPI.Core.Entities;

namespace EasyMeds.WebAPI.Services.Abstractions;

public interface IDoctorService
{
    Task<IEnumerable<Doctor>> GetDoctorsAsync();
    Task<Doctor?> GetDoctorAsync(int id);
    Task CreateDoctorAsync(CreateDoctorDto doctor);
    Task UpdateDoctorAsync(int id, UpdateDoctorDto doctor);
    Task<Doctor?> LogInAsync(string email, string password);
    Task<bool> SignUpAsync(DoctorSignUpDto doctorSignUpDto);
}