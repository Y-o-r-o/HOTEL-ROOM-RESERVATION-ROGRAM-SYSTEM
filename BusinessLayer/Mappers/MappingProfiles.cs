using AutoMapper;
using BusinessLayer.DTOs.BookingDTOs;
using BusinessLayer.Enums;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Databases.Entities.BookingEntities;

namespace BusinessLayer.Mappers;

internal sealed class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //Entity -> DTO
        //Incoming models

        //BookingAPI
        CreateMap<Reservation, CreateReservationDTO>();
        CreateMap<Reservation, EditReservationDTO>();
        CreateMap<Reservation, ReservationDTO>();
        CreateMap<Product, ClientSideProductDTO>();
        CreateMap<Resident, ResidentDTO>();
        CreateMap<Resident, CreateResidentDTO>();
        CreateMap<Resident, EditResidentDTO>();
        CreateMap<Room, RoomDTO>();
        CreateMap<Room, CreateRoomDTO>();
        CreateMap<Room, EditRoomDTO>();


        //DTO -> Entity
        //Outcoming models

        //BookingAPI
        CreateMap<CreateProductDTO, Product>();
        CreateMap<CreateResidentDTO, Resident>();
        CreateMap<EditResidentDTO, Resident>();
        CreateMap<ResidentDTO, Resident>();
        CreateMap<CreateReservationDTO, Reservation>();
        CreateMap<EditReservationDTO, Reservation>();
        CreateMap<ReservationDTO, Reservation>();
        CreateMap<ResidentDTO, Resident>();
        CreateMap<RoomDTO, Room>();
        CreateMap<CreateRoomDTO, Room>();
        CreateMap<EditRoomDTO, Room>();

        //DTO -> DTO
        //BookingAPI

        CreateMap<CreateReservationDTO, ReservationDTO>();
        CreateMap<EditReservationDTO, ReservationDTO>();

        //Primitive to Objects

        CreateMap<string, Image>()
            .ConstructUsing(str => new Image() { Path = str });
    }
}