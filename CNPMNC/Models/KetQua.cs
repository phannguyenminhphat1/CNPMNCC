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
    
    public partial class KetQua
    {
        public string MaTaiKhoan { get; set; }
        public int MaDeThi { get; set; }
        public int MaCauHoi { get; set; }
        public string DapAn { get; set; }
        public Nullable<byte> DaXoa { get; set; }
    
        public virtual CauHoi CauHoi { get; set; }
        public virtual DeThi DeThi { get; set; }
        public virtual HocSinh HocSinh { get; set; }
    }
}