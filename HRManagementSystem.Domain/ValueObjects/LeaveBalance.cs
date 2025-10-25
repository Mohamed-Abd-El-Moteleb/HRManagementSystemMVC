using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Domain.ValueObjects
{
    public class LeaveBalance
    {
        public int AnnualLeave { get; private set; }
        public int SickLeave { get; private set; }

        private LeaveBalance() { }

        public LeaveBalance(int annualLeave, int sickLeave)
        {
            if (annualLeave < 0 || sickLeave < 0)
                throw new ArgumentException("Leave days cannot be negative.");

            AnnualLeave = annualLeave;
            SickLeave = sickLeave;
        }

        public void UseAnnualLeave(int days)
        {
            if (days <= 0)
                throw new ArgumentException("Days must be positive.");
            if (days > AnnualLeave)
                throw new InvalidOperationException("Not enough annual leave balance.");

            AnnualLeave -= days;
        }

        public void UseSickLeave(int days)
        {
            if (days <= 0)
                throw new ArgumentException("Days must be positive.");
            if (days > SickLeave)
                throw new InvalidOperationException("Not enough sick leave balance.");

            SickLeave -= days;
        }

        public void AddAnnualLeave(int days) => AnnualLeave += days;
        public void AddSickLeave(int days) => SickLeave += days;
    }
}
