using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tane.Model.Abstract
{
    public abstract class Auditable:IAuditable
    {
        [MaxLength(250)]
        public string MetaKeyword { get; set; }
        [MaxLength(250)]
        public string MetaDescription { get; set; }
        public DateTime? CreateDate { get; set; }
        [MaxLength(50)]
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(50)]
        public string UpdateBy { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
