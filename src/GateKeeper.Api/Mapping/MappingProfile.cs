

using AutoMapper;
using AutoMapper.Configuration;
using GateKeeper.Api.ViewModels;
using GateKeeper.Domain.Entities;

namespace GateKeeper.Api.Mapping
{
    public class MappingProfile : MapperConfigurationExpression
    {
        public MappingProfile()
        {
            CreateMap<Resident, ResidentViewModel>().ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}