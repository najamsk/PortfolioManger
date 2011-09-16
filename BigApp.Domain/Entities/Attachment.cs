using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Services.Common;

namespace BigApp.Domain.Entities
{
    [DataServiceKey("Id")]
    public class Attachment
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
