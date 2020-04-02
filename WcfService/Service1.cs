using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class Service1 : IService1
    {
        public string AgeByYearofBirth(int year)
        {
            string output = string.Empty;
            for (int i = 0; i < 4000; i++)
            {
                output += String.Format(@" ""{0}"",""28"",""2017-12-04 13:59:36"",""2017-12-04 13:59:36"",""victor"",""victor"",""0"",""201.210.228.185"",""{1}"",""""{2}", "Susan" + i,204+i, Environment.NewLine);
               
            }
            return output;
            
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
