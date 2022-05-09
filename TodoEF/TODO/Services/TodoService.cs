using TODO.Dto;
using TODO.Repositories;

namespace TODO.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService( ITodoRepository todoRepository )
        {
            _todoRepository = todoRepository;
        }

        public TodoDto? CompleteTodo( int todoId )
        {
            TodoDto? todo = _todoRepository.Get( todoId );

            if ( todo == null )
            {
                return null;
            }
            todo.IsDone = true;
            _todoRepository.Update( todo );

            return todo;
        }

        public TodoDto? CreateTodo( TodoDto todo )
        {
            int todoId = _todoRepository.Create( todo );
            return GetTodo( todoId );
        }

        public void DeleteTodo( int todoId )
        {
            _todoRepository.Delete( new TodoDto { Id = todoId } );
        }

        public TodoDto? GetTodo( int todoId )
        {
            TodoDto? todo = _todoRepository.Get( todoId );
            if ( todo == null )
            {
                return null;
            }

            return todo;
        }

        public List<TodoDto> GetTodos()
        {
            return _todoRepository.GetTodos();
        }
    }
}
