using DAV.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAV.Domain.Entities
{
    public class Image : IEntity, IEntityLookup
    {
        public int? Id { get; set; }
        public string name { get; set; }
        public string details { get; set; }
        public string folder { get; set; }
        public int userId { get; set; }
        public object LookupId => Id;

        public object LookupValue => name;

        public bool? IsActive { get; set; } = true;
        public IEnumerable<User> Users { get; set; } = new List<User>();
    }
}
