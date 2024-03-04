using System;
using System.Collections.Generic;

namespace YourProjectName.Models
{
    public class Entity
    {
        public string Id { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Date> Dates { get; set; }
        public string Gender { get; set; }
        public List<Name> Names { get; set; }
    }
}