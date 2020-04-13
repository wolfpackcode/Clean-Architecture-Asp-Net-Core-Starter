using Clean_Architecture_Asp_Net_Core_Starter.Application.Common.Mappings;
using Clean_Architecture_Asp_Net_Core_Starter.Domain.Entities;

namespace Clean_Architecture_Asp_Net_Core_Starter.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
