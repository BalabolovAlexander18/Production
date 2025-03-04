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
    
    public partial class Продукция
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Продукция()
        {
            this.Заявки = new HashSet<Заявки>();
            this.ИсторияИзмМинСтоимПродук = new HashSet<ИсторияИзмМинСтоимПродук>();
        }
    
        public int id { get; set; }
        public string Артикул { get; set; }
        public string Наименование { get; set; }
        public string ТипПродукта { get; set; }
        public string Описание { get; set; }
        public byte[] Изображение { get; set; }
        public Nullable<int> КолВо { get; set; }
        public Nullable<decimal> МинСтоимость { get; set; }
        public string РазмУпаковки { get; set; }
        public Nullable<int> ВесБезУпаковки { get; set; }
        public Nullable<int> ВесСУпаковкой { get; set; }
        public string СертифКачества { get; set; }
        public Nullable<int> НомерСтандарта { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заявки> Заявки { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ИсторияИзмМинСтоимПродук> ИсторияИзмМинСтоимПродук { get; set; }
    }
}
