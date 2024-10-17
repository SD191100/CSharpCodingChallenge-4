using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ContactInfo { get; set; }
        public Policy Policy { get; set; }

        public Client() { }

        public Client(int clientId, string clientName, string contactInfo, Policy policy)
        {
            this.ClientId = clientId;
            this.ClientName = clientName;
            this.ContactInfo = contactInfo;
            this.Policy = policy;
        }

        public override string ToString()
        {
            return $"ClientId: {ClientId}, ClientName: {ClientName}, ContactInfo: {ContactInfo}";
        }
    }
}
