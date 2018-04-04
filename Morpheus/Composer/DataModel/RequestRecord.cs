using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Entity Framework
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Composer.DataModel
{
    public class RequestRecord : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string RequestUrl { get; set; }
        public string Source { get; set; }
        public string DataContent { get; set; }
        public string Format { get; set; }
    }
}
