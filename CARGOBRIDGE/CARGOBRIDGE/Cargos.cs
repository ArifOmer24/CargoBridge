//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CARGOBRIDGE
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cargos
    {
        public int CargoId { get; set; }
        public int CompanyId { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public string OrderTotal { get; set; }
        public string DeliveryName { get; set; }
        public string CargoPrice { get; set; }
        public string TrackingNo { get; set; }
        public string InvoiceNo { get; set; }
        public string DeliveryStatus { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    
        public virtual Companies Companies { get; set; }
    }
}
