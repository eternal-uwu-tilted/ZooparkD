//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zoopark
{
    using System;
    using System.Collections.Generic;
    
    public partial class TicketT
    {
        public int IDTicket { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public Nullable<int> IDInfo { get; set; }
    
        public virtual Inform Inform { get; set; }
    }
}