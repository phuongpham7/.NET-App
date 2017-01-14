using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductInterfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWCFProductService" in both code and config file together.
    [ServiceContract]
    public interface IWCFProductService
    {
        [OperationContract]
        List<string> ListProducts();

        [OperationContract]
        ProductData GetProduct(string productNumber);
    }
}
