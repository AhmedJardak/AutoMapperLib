using System;
using System.Text.RegularExpressions;

namespace AutoMapperLib.Location
{
	public class Location
	{
		public Location() { }

		public Location(string unLocode)
		{
			_name = unLocode;
			_unLocode = unLocode;
		}
		public Location(string unLocode, string name)
		{
			if (name == null) throw new ArgumentNullException("name");
			if (unLocode == null) throw new ArgumentNullException("unLocode");
			if (!IsValidUnLoCode(unLocode)) throw new ArgumentException("this is not a valid UN/LOCODE (does not match pattern)");
			_unLocode = unLocode;
			_name = name;
		}

		#region Base Class Member Overrides

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Location) obj);
		}

		public override int GetHashCode()
		{
			return (_unLocode != null ? _unLocode.GetHashCode() : 0);
		}

		#endregion

		public virtual string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public virtual string UnLocode
		{
			get { return _unLocode; }
			set { _unLocode = value; }
		}

		private bool IsValidUnLoCode(string unLocode)
		{
			return new Regex("[a-zA-Z]{2}[a-zA-Z2-9]{3}").Match(unLocode).Success;
		}

		protected bool Equals(Location other)
		{
			return string.Equals(_unLocode, other._unLocode);
		}

		private string _name;
		private string _unLocode;
	}
}
