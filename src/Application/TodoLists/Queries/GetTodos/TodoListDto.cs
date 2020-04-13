using Clean_Architecture_Asp_Net_Core_Starter.Application.Common.Mappings;
using Clean_Architecture_Asp_Net_Core_Starter.Domain.Entities;
using System.Collections.Generic;

namespace Clean_Architecture_Asp_Net_Core_Starter.Application.TodoLists.Queries.GetTodos
{
    public class TodoListDto : IMapFrom<TodoList>
{
    public TodoListDto()
    {
        Items = new List<TodoItemDto>();
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public IList<TodoItemDto> Items { get; set; }
}
}
