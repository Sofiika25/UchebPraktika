//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnitTestProject1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Meropriyatiya
    {
        public Meropriyatiya()
        {
            this.Activnost_Merop = new HashSet<Activnost_Merop>();
            this.Merop_Zhuri = new HashSet<Merop_Zhuri>();
            this.Goroda = new HashSet<Goroda>();
        }
    
        public int Id_meropriyatiya { get; set; }
        public string Nazvanie { get; set; }
        public System.DateTime Data_nachala { get; set; }
        public int Prodolzhidelnoct { get; set; }
    
        public virtual ICollection<Activnost_Merop> Activnost_Merop { get; set; }
        public virtual Merop_TipMerop_Napravl Merop_TipMerop_Napravl { get; set; }
        public virtual Merop_Uchastnik Merop_Uchastnik { get; set; }
        public virtual ICollection<Merop_Zhuri> Merop_Zhuri { get; set; }
        public virtual ICollection<Goroda> Goroda { get; set; }
    }
}
