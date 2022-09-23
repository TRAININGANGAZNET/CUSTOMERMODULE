using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerModule.Model
{
    public class Request
    {
        public class CreateCustomer
        { 
            public string Name { get; set; }
            public string Address { get; set; }
            public string EmailId { get; set; }
            public int Number { get; set; }
            public string PropertyType { get; set; }
            public float Budget { get; set; }
            public string Locality { get; set; }
            //public List<Requirement> requirement { get; set; }

        }

        //public class Requirement
        //{
        //    public string PropertyType { get; set; }
        //    public float Budget { get; set; }
        //    public string Locality { get; set; }
        //}

        public class GetcustDetails
        {
            public int CustomerId { get; set; }
        }
    }
}
