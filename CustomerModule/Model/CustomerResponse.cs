using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerModule.Model
{
    public class CustomerResponse
    {
        
            public string Name { get; set; }
            public string Address { get; set; }
            public string EmailId { get; set; }
            public int Number { get; set; }
            public string PropertyType { get; set; }
            public float Budget { get; set; }
            public string Locality { get; set; }
            public string Responses { get; set; }

        //public List<RequirementResponse> requirementResponse { get; set; }


        //public class RequirementResponse
        //{
        //    public string PropertyType { get; set; }
        //    public float Budget { get; set; }
        //    public string Locality { get; set; } 
        //}
    }

    public class UserregistrationResponse
    {
        public string Responses { get; set; }
        public string id { get; set; }
    }
}
