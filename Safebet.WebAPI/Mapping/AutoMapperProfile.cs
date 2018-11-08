using System.Linq;
using AutoMapper;
using Safebet.WebAPI.Models;
using Safebet.WebAPI.Resources;

namespace Safebet.WebAPI.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Match, CardMatchResource>();
            CreateMap<Match, DetailsMatchResource>();
        }
    }
}