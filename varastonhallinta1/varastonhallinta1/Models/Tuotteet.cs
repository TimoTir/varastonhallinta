//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace varastonhallinta1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tuotteet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tuotteet()
        {
            this.Tilaukset = new HashSet<Tilaukset>();
            this.VarastoSaldot = new HashSet<VarastoSaldot>();
        }
    
        public int TuoteID { get; set; }
        public string TuoteMerkki { get; set; }
        public string TuoteMalli { get; set; }
        public string Sarjanumero { get; set; }
        public string Määrä { get; set; }
        public Nullable<int> ToimittajaID { get; set; }
        public System.DateTime VastanottoPvm { get; set; }
        public Nullable<int> LuokitteluID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tilaukset> Tilaukset { get; set; }
        public virtual Toimittajat Toimittajat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VarastoSaldot> VarastoSaldot { get; set; }
        public virtual TuoteLuokittelu TuoteLuokittelu { get; set; }
    }
}
