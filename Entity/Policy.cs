using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        public decimal CoverageAmount { get; set; }

        public Policy() { }

        public Policy(int policyId, string policyName, decimal coverageAmount)
        {
            this.PolicyId = policyId;
            this.PolicyName = policyName;
            this.CoverageAmount = coverageAmount;
        }

        public override string ToString()
        {
            return $"PolicyId: {PolicyId}, PolicyName: {PolicyName}, CoverageAmount: {CoverageAmount}";
        }
    }
}
