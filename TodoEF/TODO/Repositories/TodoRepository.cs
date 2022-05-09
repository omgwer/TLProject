using TODO.Infrastructure;
using TODO.Dto;

namespace TODO.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _dbContext;

        public TodoRepository( TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TodoDto CreateTodo( TodoDto todo)
        {
            var entity = _dbContext.Set<TodoDto>().Add( todo );
            return entity.Entity;
        }

        public void DeleteTodo( TodoDto todo )
        {
            _dbContext.Set<TodoDto>().Remove( todo );
        }

        public TodoDto? GetTodo( int id )
        {
            return _dbContext.Set<TodoDto>().FirstOrDefault( x => x.Id == id );
        }

        public List<TodoDto> GetTodos()
        {
            return _dbContext.Set<TodoDto>().ToList();
        }

        public int UpdateTodo( TodoDto todo )
        {
            var entity = _dbContext.Update( todo );
            return entity.Entity.Id;
        }
    }
}
