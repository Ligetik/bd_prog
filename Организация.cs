//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bd
{
    using System;
    using System.Collections.Generic;
    
    public partial class Организация
    {
        public int Id_Организация { get; set; }
        public string Название_организации { get; set; }
        public Nullable<int> id_Налоги { get; set; }
        public Nullable<int> id_СЗВ_М { get; set; }
        public Nullable<int> id_ФСС { get; set; }
        public Nullable<int> id_ЕНВД { get; set; }
        public Nullable<int> id_НДС { get; set; }
        public Nullable<int> id_Прибыль { get; set; }
        public Nullable<int> id_РСВ { get; set; }
        public Nullable<int> id_НДФЛ { get; set; }
        public string Заметка { get; set; }
    }
}
