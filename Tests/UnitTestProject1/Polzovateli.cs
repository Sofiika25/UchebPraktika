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
    
    public partial class Polzovateli
    {
        public Polzovateli()
        {
            this.Activnost_Merop = new HashSet<Activnost_Merop>();
            this.Merop_Uchastnik = new HashSet<Merop_Uchastnik>();
            this.Merop_Zhuri = new HashSet<Merop_Zhuri>();
        }
    
        public int Id_polzovatelya { get; set; }
        public string FIO { get; set; }
        public string Pochta { get; set; }
        public System.DateTime Data_rozhdeniya { get; set; }
        public string Telephone { get; set; }
        public string Parol { get; set; }
        public string Pol { get; set; }
    
        public virtual ICollection<Activnost_Merop> Activnost_Merop { get; set; }
        public virtual ICollection<Merop_Uchastnik> Merop_Uchastnik { get; set; }
        public virtual ICollection<Merop_Zhuri> Merop_Zhuri { get; set; }
        public virtual Napravlenie Napravlenie { get; set; }
        public virtual Roli Roli { get; set; }
    }
}