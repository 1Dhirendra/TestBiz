using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Biz2Credit_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get filepath from app settings
            var textFile = ConfigurationManager.AppSettings[Constants.FilePath];

            //Read file and store data in customer collection
            List<Customer> customerList = new List<Customer>();
            using (StreamReader file = new StreamReader(textFile))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                    Customer customer = json_serializer.Deserialize<Customer>(ln);
                    customerList.Add(customer);
                }
                file.Close();
            }


            //Filter data and sort by user_id
            var customersKmsGraterThanHund = customerList.Where(x => x.distance_in_kms_from_dublin < 100).OrderBy(x => x.user_id);

            //Write data onto console
            Console.WriteLine("Customers having distance from Dublin less than 100kms");
            Console.WriteLine("------------------------------------------------------");
            foreach(var customer in customersKmsGraterThanHund)
            {
                Console.WriteLine($"UserId:  {customer.user_id},  Name:    {customer.name},   Distance(Kms):    {(int)customer.distance_in_kms_from_dublin}");
            }
            Console.ReadLine();
        }
    }
}




