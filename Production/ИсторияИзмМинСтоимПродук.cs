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
    
    public partial class ИсторияИзмМинСтоимПродук
    {
        public int id { get; set; }
        public Nullable<int> id_продукции { get; set; }
        public Nullable<System.DateTime> Дата { get; set; }
        public Nullable<decimal> СтараяЦена { get; set; }
        public Nullable<decimal> НоваяЦена { get; set; }
    
        public virtual Продукция Продукция { get; set; }
    }
}
