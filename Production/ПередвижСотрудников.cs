//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Production
{
    using System;
    using System.Collections.Generic;
    
    public partial class ПередвижСотрудников
    {
        public int id { get; set; }
        public int id_сотрудника { get; set; }
        public Nullable<System.DateTime> ДатаИВремя { get; set; }
        public Nullable<int> NFSДверь { get; set; }
    
        public virtual Сотрудники Сотрудники { get; set; }
    }
}
