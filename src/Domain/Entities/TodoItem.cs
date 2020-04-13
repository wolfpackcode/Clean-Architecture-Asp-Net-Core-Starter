using Clean_Architecture_Asp_Net_Core_Starter.Domain.Common;
using Clean_Architecture_Asp_Net_Core_Starter.Domain.Enums;
using System;

namespace Clean_Architecture_Asp_Net_Core_Starter.Domain.Entities
{
    public class TodoItem : AuditableEntity
    {
        public int Id { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public bool Done { get; set; }

        public DateTime? Reminder { get; set; }

        public PriorityLevel Priority { get; set; }


        public TodoList List { get; set; }
    }
}
