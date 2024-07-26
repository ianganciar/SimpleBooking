using AutoMapper;
using B.SimpleBooking.Application.UseCases.Professionals.CreateProfessional;
using B.SimpleBooking.Application.UseCases.Professionals.UpdateProfessional;
using D.SimpleBooking.Domain.Entities;

namespace B.SimpleBooking.Application.Services.Automapper;
public class AutomapperConfigurations : Profile
{
    public AutomapperConfigurations()
    {
        InputModelToEntity();
    }

    private void InputModelToEntity()
    {
        CreateMap<CreateProfessionalCommand, Professional>();
        CreateMap<UpdateProfessionalCommand, Professional>()
            .ForMember(dest => dest.Phone, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); ;
    }


}


