//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace enesatac_site.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comments
    {
        public int Comment_Id { get; set; }
        public string Comment_Username { get; set; }
        public string Comment_Content { get; set; }
        public Nullable<System.DateTime> Comment_Date { get; set; }
        public int Comment_Article_İd { get; set; }
        public bool Comment_Is_Active { get; set; }
        public string Comment_Email { get; set; }
        public string Comment_Website { get; set; }
    
        public virtual Articles Articles { get; set; }
    }
}
