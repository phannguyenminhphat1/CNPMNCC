//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNPMNC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DapAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DapAn()
        {
            this.CauHois = new HashSet<CauHoi>();
        }
    
        public int MaDapAn { get; set; }
        public string DapAnDung { get; set; }
        public Nullable<byte> DaXoa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CauHoi> CauHois { get; set; }
    }
}
