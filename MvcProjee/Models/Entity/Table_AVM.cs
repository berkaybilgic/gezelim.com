//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcProjee.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Table_AVM
    {
        public int AvmID { get; set; }
        public string AvmAdı { get; set; }
        public string AvmKonumu { get; set; }
        public string Avmİl { get; set; }
        public string Avmİlce { get; set; }
        public Nullable<int> Kategori_ID { get; set; }
    
        public virtual Table_Kategori Table_Kategori { get; set; }
    }
}