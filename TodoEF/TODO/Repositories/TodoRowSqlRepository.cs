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
            using ( var connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( var command = connection.CreateCommand() )
                {
                    command.CommandText = @"DELETE FROM [dbo].[Todo] WHERE [Id] = @id";
                    command.Parameters.Add( "@id", SqlDbType.Int ).Value = todoDto.Id;

                    command.ExecuteNonQuery();
                }
            }
        }

        public TodoDto? Get( int id )
        {
            using ( var connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = @"SELECT [Id], [Title], [IsDone] FROM [dbo].[Todo] WHERE [Id] = @id";
                    command.Parameters.Add( "@id", SqlDbType.Int ).Value = id;

                    using ( var reader = command.ExecuteReader() )
                    {
                        if ( reader.Read() )
                        {
                            return new TodoDto
                            {
                                Id = Convert.ToInt32( reader[ nameof( TodoDto.Id ) ] ),
                                Title = Convert.ToString( reader[ nameof( TodoDto.Title ) ] ),
                                IsDone = Convert.ToBoolean( reader[ nameof( TodoDto.IsDone ) ] )
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
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

                    using ( var reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            todoList.Add( new TodoDto
                            {
                                Id = Convert.ToInt32( reader[ nameof( TodoDto.Id ) ] ),
                                Title = Convert.ToString( reader[ nameof( TodoDto.Title ) ] ),
                                IsDone = Convert.ToBoolean( reader[ nameof( TodoDto.IsDone ) ] )
                            } );
                        }
                    }
                }
            }
            return todoList;
        }

        public int Update( TodoDto todoDto )
        {
            using ( var connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( var command = connection.CreateCommand() )
                {
                    command.CommandText = @"UPDATE [dbo].[Todo] SET [Title] = @title, [IsDone] = @isDone WHERE [Id] = @id";
                    command.Parameters.Add( "@id", SqlDbType.Int ).Value = todoDto.Id;
                    command.Parameters.Add( "@title", SqlDbType.NVarChar ).Value = todoDto.Title;
                    command.Parameters.Add( "@isDone", SqlDbType.Bit ).Value = todoDto.IsDone;

                    command.ExecuteNonQuery();
                    return todoDto.Id;
                }
            }
        }        
    }
}
