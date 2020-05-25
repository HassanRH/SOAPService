using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.ModelBinding;

namespace soapservice
{
    [DataContract]
    public class datasensor
    {
        [DataMember]
        public int DoorNumber { get; set; }
        [DataMember]
        public int OutGoing { get; set; }
        [DataMember]
        public int InGoing { get; set; }

    }
}