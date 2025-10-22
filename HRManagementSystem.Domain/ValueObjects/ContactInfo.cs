using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Domain.ValueObjects
{
    public class ContactInfo
    {
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string? EmergencyContactName { get; private set; }
        public string? EmergencyContactPhone { get; private set; }

        private ContactInfo() { }

        public ContactInfo(string email, string phoneNumber, string? emergencyContactName = null, string? emergencyContactPhone = null)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.", nameof(email));
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number is required.", nameof(phoneNumber));

            Email = email;
            PhoneNumber = phoneNumber;
            EmergencyContactName = emergencyContactName;
            EmergencyContactPhone = emergencyContactPhone;
        }
    }
}
