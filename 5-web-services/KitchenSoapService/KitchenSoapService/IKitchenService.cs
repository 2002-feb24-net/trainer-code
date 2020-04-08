using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KitchenSoapService
{
    // by default, WCF will not "see" anything to make it part of the WSDL and the SOAP service.
    // we change that with attributes
    //  - [ServiceContract] - goes on an interface, marks it as describing a SOAP service.
    //  - [OperationContract] - goes on interface methods, marks them as describing one operation on that service.
    //  - [DataContract] - goes on classes that you are going to send/receive over SOAP.
    //  - [DataMember] - goes on members of DataContract classes that should be serialized/deserialized
    //  - [FaultContract] - goes on operations to define what faults can come from that operation.

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IKitchenService" in both code and config file together.
    [ServiceContract]
    public interface IKitchenService
    {
        [OperationContract(Name = "LookInsideFridge")]
        List<FridgeItem> OpenFridge();

        [OperationContract]
        bool CleanFridge();

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        FridgeItem TakeOutLeftovers();
    }
}
