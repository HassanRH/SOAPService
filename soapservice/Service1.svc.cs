using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace soapservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private readonly string GetConnectionString =
            "@Server=tcp:hassan-server.database.windows.net,1433;Initial Catalog=SchoolDB;Persist Security Info=False;User ID={hassanrh};Password={Hemmeligt2303};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static List<datasensor> dataliste { get; } =
            new List<datasensor>
            {

                //de er statisc fordi den ligger alokeret i rammen(høre til sig selv og ikke objektet)
                new datasensor() {DoorNumber = 1, OutGoing = 2, InGoing = 2},
                new datasensor() {DoorNumber = 2, OutGoing = 3, InGoing = 3},
                new datasensor() {DoorNumber = 3, OutGoing = 4, InGoing = 4},
                new datasensor() {DoorNumber = 4, OutGoing = 5, InGoing = 5},
                new datasensor() {DoorNumber = 5, OutGoing = 6, InGoing = 6},
                new datasensor() {DoorNumber = 1, OutGoing = 7, InGoing = 7},
                new datasensor() {DoorNumber = 1, OutGoing = 8, InGoing = 8}
            };



        public IEnumerable<datasensor> GetAllInfo()
        {
            return dataliste;
        }

        public IEnumerable<datasensor> GetDoorInfoByNumber(string serach)
        {
            int _minint = Int32.Parse(serach);

            return dataliste.FindAll(x => x.DoorNumber == _minint);
        }

        public void AddInfo(datasensor datasensor)
        {
            dataliste.Add(datasensor);
        }

        public void InsertData(int door, int ingoing, int outgoing)
        {
            const string datasensor =
                "insert into datasensor (DoorNumber, InGoing, OutGoing, values (@DoorNumber, @InGoing, @OutGoing,)";

            using (var DBconnection = new SqlConnection(GetConnectionString))
            {
                DBconnection.Open();

                using (var addstuCommand = new SqlCommand(datasensor, DBconnection))
                {
                    addstuCommand.Parameters.AddWithValue("@DoorNumber", door);
                    addstuCommand.Parameters.AddWithValue("@InGoing", ingoing);
                    addstuCommand.Parameters.AddWithValue("@OutGoing", outgoing);
                    addstuCommand.ExecuteNonQuery();

                }
            }
        }

        public List<datasensor> GetAllInfoDB()
        {
            const string sqlstring = "select * from datasensor order by Id";


            using (var dbConnection = new SqlConnection(GetConnectionString))
            {

                dbConnection.Open();

                using (var selecSqlCommand = new SqlCommand(sqlstring, dbConnection))
                {

                    using (var reader = selecSqlCommand.ExecuteReader())
                    {

                        var dataliste = new List<datasensor>();

                        while (reader.Read())
                        {

                            var _data = Readdata(reader);
                            dataliste.Add(_data);
                        }

                        return dataliste;
                    }
                }
            }
        }

        //vores læse metode vi kan bruge sammen med reader - den sætter bare læste værdier ind på nyt obj
        private static datasensor Readdata(IDataRecord reader)
        {
            var Id = reader.GetInt32(0);
            var DoorNumber = reader.GetInt32(1);
            var InGoing = reader.GetInt32(2);
            var OutGoing = reader.GetInt32(3);

            var i = new datasensor { DoorNumber = DoorNumber, OutGoing = OutGoing,InGoing = InGoing};

            return i;
        }
    }
}
