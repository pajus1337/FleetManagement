using FleetManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.App.Concrete
{
    public class ListService
    {
        public void Method()
        {

            List<Vehicle> vehicles = new List<Vehicle>();
            string path = @"D:\Temp\Vehicles.csv";

            using StreamWriter sw = File.AppendText(path);
            sw.WriteLine("10,TE-ST 10,1");

            // 1st way to write into File , replacing top lane ( care ) 
            //using FileStream fs = File.OpenWrite(path);
            //using StreamWriter sw = new StreamWriter(fs);

            //sw.WriteLine("10,TE-ST 10,1");


            // 1 Way to read from file 
            //var lines = File.ReadLines(path);

            // 2 Way 
            // A way to read-write file into byte-array, then encode it into string ( learn more to make a obj from data ) 
            //using FileStream fs = File.Open(@"D:\Temp\Vehicles.csv", FileMode.Open, FileAccess.Read);
            //byte[] buf = new byte[1024];
            //int c;
            //while((c = fs.Read(buf, 0, buf.Length)) > 0)
            //{
            //    string text = Encoding.UTF8.GetString(buf, 0, c);
            //}


        }
    }
}
   

