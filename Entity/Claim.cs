using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string ClaimNumber { get; set; }
        public DateTime DateFiled { get; set; }
        public decimal ClaimAmount { get; set; }
        public string Status { get; set; }
        public Policy Policy { get; set; }
        public Client Client { get; set; }

        public Claim() { }

        public Claim(int claimId, string claimNumber, DateTime dateFiled, decimal claimAmount, string status, Policy policy, Client client)
        {
            this.ClaimId = claimId;
            this.ClaimNumber = claimNumber;
            this.DateFiled = dateFiled;
            this.ClaimAmount = claimAmount;
            this.Status = status;
            this.Policy = policy;
            this.Client = client;
        }

        public override string ToString()
        {
            return $"ClaimId: {ClaimId}, ClaimNumber: {ClaimNumber}, ClaimAmount: {ClaimAmount}, Status: {Status}";
        }
    }
}
