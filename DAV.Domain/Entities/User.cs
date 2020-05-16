using DAV.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAV.Domain.Entities
{
    public class User : IEntity, IEntityLookup
    {
        public int? Id { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool? IsActive { get; set; } = true;
        public object LookupId => Id;

        public object LookupValue => username;
    }
}
