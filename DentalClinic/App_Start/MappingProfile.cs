using AutoMapper;
using DentalClinic.DTOS;
using DentalClinic.Models;

namespace DentalClinic
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Procedure, ProcedureDto>();
            CreateMap<ProcedureDto, Procedure>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorDto, Doctor>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            CreateMap<Nurse,NurseDto>();
            CreateMap<NurseDto, Nurse>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            CreateMap<Appointment, AppointmentDto>();
            CreateMap<AppointmentDto, Appointment>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}

