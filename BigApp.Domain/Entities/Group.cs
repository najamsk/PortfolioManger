using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Services.Common;

namespace BigApp.Domain.Entities
{
    [DataServiceKey("GroupId")]
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
