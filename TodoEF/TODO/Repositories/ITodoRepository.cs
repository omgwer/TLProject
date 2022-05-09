using TODO.Dto;

namespace TODO.Repositories
{
    public interface ITodoRepository
    {
        List<TodoDto> GetTodos();
        TodoDto? GetTodo(int id);
        TodoDto CreateTodo( TodoDto todoDto );
        void DeleteTodo( TodoDto todoDto );
        int UpdateTodo( TodoDto todoDto );
    }
}
