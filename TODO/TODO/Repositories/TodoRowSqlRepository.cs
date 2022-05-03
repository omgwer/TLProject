using TODO.Dto;
using System.Data.SqlClient;
using System.Data;

namespace TODO.Repositories
{
    public class TodoRowSqlRepository : ITodoRepository
    {
        private readonly string _connectionString;

        public TodoRowSqlRepository( string connectionString )
        {
            _connectionString = connectionString;
        }

        public int Create( TodoDto todo)
        {
            using ( var connections = new SqlConnection( _connectionString ) )
            {
                connections.Open();

                using ( var command = connections.CreateCommand() )
                {
                    command.CommandText =
                        @"INSERT INTO [dbo].[Todo] ([Title], [IsDone]) VALUES (@title, @isDone); 
                            SELECT SCOPE_IDENTITY();";
                    command.Parameters.Add( "@title", SqlDbType.NVarChar ).Value = todo.Title; 
                    command.Parameters.Add( "@isDone", SqlDbType.Bit ).Value = todo.IsDone;
                    
                    return Convert.ToInt32( command.ExecuteScalar() );
                }
            }
        }

        public void Delete( TodoDto todoDto )
        {
            throw new NotImplementedException();
        }

        public TodoDto? Get( int id )
        {
            throw new NotImplementedException();
        }

        public List<TodoDto> GetTodos()
        {
            List<TodoDto> todoList = new List<TodoDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT [ID], [Title], [IsDone] FROM [dbo].[Todo]";
                }
            }

            return todoList;
        }

        public void Update( TodoDto todoDto )
        {
            throw new NotImplementedException();
        }
    }
}
