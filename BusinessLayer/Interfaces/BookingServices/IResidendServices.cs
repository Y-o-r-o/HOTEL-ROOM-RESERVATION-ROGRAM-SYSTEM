using BusinessLayer.DTOs.BookingDTOs;

namespace BusinessLayer.Interfaces.BookingServices;

public interface IResidentServices
{
    Task<int> CreateResident(CreateResidentDTO resident);
    Task EditResident(int residentId, EditResidentDTO resident);
    Task DeleteResidentById(int residentId);
    Task<ResidentDTO> GetResidentById(int residentId);
}