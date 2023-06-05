using AutoMapper;
using BusinessLayer.DTOs.BookingDTOs;
using BusinessLayer.Interfaces.BookingServices;
using Core;
using RepositoryLayer.Databases.Entities.BookingEntities;
using RepositoryLayer.Interfaces;
using System.Net;

namespace BusinessLayer.BusinessServices.BookingServices;

internal sealed class ResidentServices : IResidentServices
{
    private readonly IResidentRepository _residentRepository;
    private readonly IMapper _mapper;

    public ResidentServices(IResidentRepository residentRepository, IMapper mapper)
    {
        _residentRepository = residentRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateResident(CreateResidentDTO resident)
    {
        return await _residentRepository.CreateResidentAsync(_mapper.Map<Resident>(resident));
    }

    public async Task DeleteResidentById(int residentId)
    {
        var residentEntity = await _residentRepository.GetResidentByIdAsync(residentId) ??
            throw new HttpResponseException(HttpStatusCode.NotFound, $"Resident doesn't exist with the id: {residentId}.");

        await _residentRepository.RemoveResidentAsync(residentEntity);
    }

    public async Task EditResident(int residentId, EditResidentDTO resident)
    {
        var residentToEdit = await _residentRepository.GetResidentByIdAsync(residentId) ??
            throw new HttpResponseException(HttpStatusCode.NotFound, $"Resident not found with this id: {residentId}.");

        var editedResident =  _mapper.Map(resident, residentToEdit);

        await _residentRepository.EditResidentAsync(editedResident);
    }

    public async Task<ResidentDTO> GetResidentById(int residentId)
    {
        var residentEntity = await _residentRepository.GetResidentByIdAsync(residentId) ??
            throw new HttpResponseException(HttpStatusCode.NotFound, $"Resident not found with this id: {residentId}.");

        return _mapper.Map<ResidentDTO>(residentEntity);
    }
}