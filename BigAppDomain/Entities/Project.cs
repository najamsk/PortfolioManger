using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigApp.Domain.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool isFeatured { get; set; }
        public bool isDisabled { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
