using System;

namespace Tane.Model.Abstract
{
    interface IAuditable
    {

        string MetaKeyword { get; set; }
        string MetaDescription { get; set; }
        DateTime? CreateDate { get; set; }
        string CreateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        string UpdateBy { get; set; }
        bool Status { get; set; }
    }
}
