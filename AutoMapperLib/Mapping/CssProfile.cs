using AutoMapper;
using AutoMapperLib.Cargo;

namespace AutoMapperLib.Mapping
{
	public class CssProfile : Profile
	{

		protected override void Configure()
		{
			Mapper.CreateMap<Cargo.Cargo, CargoViewModel>().ReverseMap();
			Mapper.CreateMap<string, Location.Location>().ConvertUsing<LocationTypeConverter>();
			Mapper.CreateMap<CargoViewModel, RouteSpecification>()
				.ForCtorParam("origin", expression => expression.MapFrom(model => model.RouteSpecificationOriginUnLocode))
				.ForCtorParam("destination", expression => expression.MapFrom(model => model.RouteSpecificationDestinationUnLocode))
				.ForCtorParam("arrivalDeadline", expression => expression.MapFrom(model => model.RouteSpecificationArrivalDeadline));
		}
	}
}