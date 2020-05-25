using Microsoft.VisualStudio.TestTools.UnitTesting;
using soapservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soapservice.Tests
{
    [TestClass()]
    public class Service1Tests
    {
        [TestMethod()]
        public void GetAllInfoTest_ersamme()

            //tester listen
        {
            //arrange 
            Service1 minService1 = new Service1(); //service henter en liste
            //act
            var minliste = minService1.GetAllInfo();
            //Assert
            Assert.AreSame(minliste, minService1.GetAllInfo());

        }

        [TestMethod()]
        public void GetAllInfoTest_datai()

            //tester listen
        {
            //arrange 
            Service1 minService1 = new Service1(); //service henter en liste
            //act
            var minliste = minService1.GetAllInfo();
            //Assert
            Assert.IsNotNull(minliste);

            //tester om den ikke er null, om den overhoved eksstere listen.
        }
    }
}