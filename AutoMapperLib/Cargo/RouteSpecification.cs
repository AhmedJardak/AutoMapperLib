using System;

namespace AutoMapperLib.Cargo
{
	public class RouteSpecification
	{
		public RouteSpecification() { }

		public RouteSpecification(Location.Location origin, Location.Location destination, DateTime arrivalDeadline)
		{
			if (origin == null) throw new ArgumentNullException("origin");
			if (destination == null) throw new ArgumentNullException("destination");
			if (arrivalDeadline < DateTime.Now.AddDays(2)) throw new ArgumentException("arrivalDeadline should be greater than actual date by two days");
			if (origin.Equals(destination)) throw new ArgumentException("Origin and destination can't be the same: " + origin.Name);
			_origin = origin;
			_destination = destination;
			_arrivalDeadline = arrivalDeadline;
		}

		public DateTime ArrivalDeadline
		{
			get { return _arrivalDeadline; }
			set { _arrivalDeadline = value; }
		}

		public Location.Location Destination
		{
			get { return _destination; }
			set { _destination = value; }
		}

		public Location.Location Origin
		{
			get { return _origin; }
			set { _origin = value; }
		}

		private DateTime _arrivalDeadline;
		private Location.Location _destination;
		private Location.Location _origin;
	}
}
