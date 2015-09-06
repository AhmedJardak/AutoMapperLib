using System;

namespace AutoMapperLib.Cargo
{
	public class Cargo
	{
		private RouteSpecification _routeSpecification;
		private string _trackingId;

		public Cargo(string trackingId, RouteSpecification routeSpecification)
		{
			if (trackingId == null) throw new ArgumentNullException("trackingId");
			if (routeSpecification == null) throw new ArgumentNullException("routeSpecification");
			_routeSpecification = routeSpecification;
			_trackingId = trackingId;
		}

		public Cargo() { }

		#region Base Class Member Overrides

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Cargo) obj);
		}

		public override int GetHashCode()
		{
			return (TrackingId != null ? TrackingId.GetHashCode() : 0);
		}

		#endregion

		public virtual RouteSpecification RouteSpecification
		{
			get { return _routeSpecification; }
			//set { _routeSpecification = value; }
		}

		public virtual string TrackingId
		{
			get { return _trackingId; }
		//	set { _trackingId = value; }
		}

		protected bool Equals(Cargo other)
		{
			return string.Equals(TrackingId, other.TrackingId);
		}
	}
}
