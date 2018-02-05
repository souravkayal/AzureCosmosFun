using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCosmos.Model
{
    public class Person
    {
        
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Person()
        {
            this._id = ObjectId.GenerateNewId();
        }
    }
}
