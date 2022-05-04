using TODO.Dto;

namespace TODO.Repositories
{
    public interface ITodoRepository
    {
        List<TodoDto> GetTodos();
        TodoDto? Get(int id);
        int Create( TodoDto todoDto );
        void Delete( TodoDto todoDto );
        int Update( TodoDto todoDto );
    }
}
