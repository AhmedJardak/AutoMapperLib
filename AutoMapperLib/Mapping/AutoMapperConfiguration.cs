using System;
using System.Linq;
using AutoMapper;

namespace AutoMapperLib.Mapping
{
	public class AutoMapperConfiguration
	{
		public static void Configure()
		{
			Mapper.Initialize(configuration =>
			configuration.AddProfile<CssProfile>());
		}
	}
}