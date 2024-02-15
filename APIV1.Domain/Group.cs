using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIV1.Domain
{
    [Table("group")]
    public class Group
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Active { get; set; }

        [Column("created_at")]
        public DateTime Created_at { get; set; }

        [Column("updated_at")]
        public DateTime Updated_at { get; set; }

        public int? Order { get; set; }
    }
}
