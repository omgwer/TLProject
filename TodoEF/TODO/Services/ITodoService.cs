using TODO.Dto;

namespace TODO.Services
{
    public interface ITodoService
    {
        List<TodoDto> GetTodos();
        TodoDto? GetTodo( int todoId );
        TodoDto? CompleteTodo( int todoId );
        TodoDto? CreateTodo( TodoDto todo );
        void DeleteTodo( int todoId );
    }
}
