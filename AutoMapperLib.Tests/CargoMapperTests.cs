using System;
using AutoMapper;
using AutoMapperLib.Cargo;
using AutoMapperLib.Mapping;
using NUnit.Framework;

namespace AutoMapperLib.Tests
{
	[TestFixture]
	public class CargoMapperTests
	{
		[SetUp]
		public void SetUp()
		{
			AutoMapperConfiguration.Configure();
		}
		[Test]
		public void FromCargoToCargoViewModel()
		{
			DateTime arrivalDeadline = DateTime.Now.AddDays(3);
			//Arrange 
			Cargo.Cargo cargo = new Cargo.Cargo("ABC123",
				new RouteSpecification(new Location.Location("CNHGH", "Hangzhou"), new Location.Location("FIHEL", "Helsinki"), arrivalDeadline));
			//Act
			CargoViewModel actual = Mapper.Map<Cargo.Cargo, CargoViewModel>(cargo);
			//Assert
			CargoViewModel expected = new CargoViewModel {
				TrackingId = "ABC123",
				RouteSpecificationArrivalDeadline  = arrivalDeadline,
				RouteSpecificationDestinationUnLocode = "FIHEL",
				RouteSpecificationOriginUnLocode = "CNHGH"

			};
			Assert.That(actual, Is.EqualTo(expected));
			Mapper.AssertConfigurationIsValid("CssProfile");
		}


		[Test]
		public void FromCargoViewModelToCargo()
		{
			//Arrange
			DateTime arrivalDeadline = DateTime.Now.AddDays(3);
			CargoViewModel cargoViewModel = new CargoViewModel {
				TrackingId = "ABC123",
				RouteSpecificationArrivalDeadline = arrivalDeadline,
				RouteSpecificationDestinationUnLocode = "FIHEL",
				RouteSpecificationOriginUnLocode = "CNHGH"

			};
			//Act
			Cargo.Cargo actual = Mapper.Map<CargoViewModel,Cargo.Cargo>(cargoViewModel);
			//Assert
			Cargo.Cargo cargo = new Cargo.Cargo("ABC123",
		new RouteSpecification(new Location.Location("CNHGH", "CNHGH"), new Location.Location("FIHEL", "CNHGH"), arrivalDeadline));
			Assert.That(actual, Is.EqualTo(cargo));
			Mapper.AssertConfigurationIsValid("CssProfile");
			



		}
	}
}