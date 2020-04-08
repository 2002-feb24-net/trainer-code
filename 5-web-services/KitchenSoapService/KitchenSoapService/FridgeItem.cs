using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KitchenSoapService
{
    [DataContract]
    public class FridgeItem
    {
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember(Name = "ExpirationDate")]
        public DateTime Expiration { get; set; }
    }
}
