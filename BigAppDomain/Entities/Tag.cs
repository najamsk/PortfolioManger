using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigApp.Domain.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
