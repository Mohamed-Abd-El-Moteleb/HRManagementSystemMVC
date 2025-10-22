using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Domain.ValueObjects
{
    public class NationalIdentity
    {
        public string NationalId { get; private set; }

        private NationalIdentity() { }

        public NationalIdentity(string nationalId)
        {
            if (string.IsNullOrWhiteSpace(nationalId))
                throw new ArgumentException("National ID is required.");

            if (nationalId.Length != 14)
                throw new ArgumentException("National ID must be 14 digits.");

            NationalId = nationalId;
        }

        public override string ToString() => NationalId;
    }
}
