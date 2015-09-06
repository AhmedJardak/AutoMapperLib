using AutoMapper;

namespace AutoMapperLib.Mapping
{
	public class LocationTypeConverter : ITypeConverter<string, Location.Location>
	{
		public Location.Location Convert(ResolutionContext context)
		{
			return new Location.Location(context.SourceValue.ToString());
		}
	}
}