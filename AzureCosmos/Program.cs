using AzureCosmos.AzureMongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCosmos
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonRepository mongoPersonRepo = new PersonRepository();
            //mongoPersonRepo.CreatePerson(new Model.Person { Name = "Ram", Surname = "Kayal", Age = 29 });

            //var result = mongoPersonRepo.GetAllPerson("Persons");

            //mongoPersonRepo.UpdatePerson(new Model.Person { Age = 35, Name = "Sourav", Surname = "Kumar" });

            mongoPersonRepo.DeletePerson(new Model.Person { Name = "Ram" });
        }
    }
}
