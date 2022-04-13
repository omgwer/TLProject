using System.Data;
using System.Data.SqlClient;
using SQLProgram.Container;

namespace SQLProgram.Repository
{
    public class StudentRowRepository
    {
        private readonly string _connectionString;

        public StudentRowRepository( string _connectionString )
        {
            this._connectionString = _connectionString;
        }

        public void AddStudent( Student student )
        {
            using ( var connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( var command = connection.CreateCommand() )
                {
                    command.CommandText =
                        @"insert into [Student]
                            values
                        (@FirstName, @LastName)";
                    command.Parameters.Add( "@FirstName", SqlDbType.NVarChar ).Value = student.FirstName;
                    command.Parameters.Add( "@LastName", SqlDbType.NVarChar ).Value = student.LastName;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteById( int id )
        {
            using ( var connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();

                using ( var command = connection.CreateCommand() )
                {
                    command.CommandText =
                        @"delete from [Student]
                        where [Id] = @id";
                    command.Parameters.Add( "@id", SqlDbType.Int ).Value = id;

                    command.ExecuteNonQuery();
                }
            }
        }

        public Student? GetById( int id )
        {
            Student? student = default;

            using ( var connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();

                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText =
                        $@"select * from [Student]
                        where [id] = @id";

                    command.Parameters.Add( "@id", SqlDbType.Int ).Value = id;

                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        if ( reader.Read() )
                        {
                            student = new Student();
                            var properties = typeof( Student ).GetProperties();
                            foreach ( var prop in properties )
                            {
                                prop.SetValue( student, reader[ prop.Name ] );
                            }

                        }
                    }
                }

            }
            return student;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> studentsList = new List<Student>();

            using ( var connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();

                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = $@"select * from [Student]";

                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            var student = new Student();
                            var properties = typeof( Student ).GetProperties();

                            foreach ( var prop in properties )
                            {
                                prop.SetValue( student, reader[ prop.Name ] );
                            }

                            studentsList.Add( student );

                        }
                    }
                }
            }
            return studentsList;
        }
    }
}
