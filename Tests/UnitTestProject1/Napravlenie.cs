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
    
    public partial class Napravlenie
    {
        public Napravlenie()
        {
            this.Merop_TipMerop_Napravl = new HashSet<Merop_TipMerop_Napravl>();
            this.Polzovateli = new HashSet<Polzovateli>();
        }
    
        public int Id_napravlenie { get; set; }
        public string Nazvanie { get; set; }
    
        public virtual ICollection<Merop_TipMerop_Napravl> Merop_TipMerop_Napravl { get; set; }
        public virtual ICollection<Polzovateli> Polzovateli { get; set; }
    }
}