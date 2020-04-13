using Clean_Architecture_Asp_Net_Core_Starter.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace Clean_Architecture_Asp_Net_Core_Starter.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
