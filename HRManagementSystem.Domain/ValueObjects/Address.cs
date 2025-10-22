using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Domain.ValueObjects
{
    public class Address
    {
        public string City { get; private set; }
        public string Street { get; private set; }
        public string BuildingNumber { get; private set; }

        private Address() { } 

        public Address(string city, string street, string buildingNumber)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City is required.", nameof(city));

            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street is required.", nameof(street));

            if (string.IsNullOrWhiteSpace(buildingNumber))
                throw new ArgumentException("Building number is required.", nameof(buildingNumber));

            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }

        public override string ToString() => $"{Street}, {BuildingNumber}, {City}";
    }
}
