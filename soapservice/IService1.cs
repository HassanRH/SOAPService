using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace soapservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        IEnumerable<datasensor> GetAllInfo(); //IEnumerabl 

        [OperationContract]
        IEnumerable<datasensor> GetDoorInfoByNumber(string serach);

        [OperationContract]
        void AddInfo(datasensor datasensor);


        [OperationContract]
        void InsertData(int door, int ingoing, int outgoing);

        [OperationContract]
        List<datasensor> GetAllInfoDB();

    }
}
