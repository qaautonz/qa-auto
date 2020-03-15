using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QaAutoTests.DataStructures;

namespace QaAutoTests.DataObjects
{
    public class BillingOrder
    {
    

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public State State { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int ItemNumber { get; set; }
        public string Comment { get; set; }
       
    };
    }
