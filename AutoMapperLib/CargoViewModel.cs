using System;

namespace AutoMapperLib
{
	public struct CargoViewModel
	{
		public string TrackingId { get; set; }
		public DateTime RouteSpecificationArrivalDeadline { get; set; }
		public string RouteSpecificationDestinationUnLocode { get; set; }
		public string RouteSpecificationOriginUnLocode { get; set; }
	}
}