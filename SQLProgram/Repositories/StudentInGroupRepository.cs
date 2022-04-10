using System.Data;
using System.Data.SqlClient;
using SQLProgram.Container;

namespace SQLProgram.Repositories
{
    public class StudentInGroupRepository
    {
        private readonly string _connectionString;
        public StudentInGroupRepository( string connectionString )
        {
            _connectionString = connectionString;
        }
        public void AddStudentIntoGroup( int studentId, int groupId )
        {
            using ( var connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand сommand = connection.CreateCommand() )
                {
                    сommand.CommandText =
                        @"insert into [StudentInGroup]
                        ([StudentId], [GroupId])
                    values
                        (@studentId, @groupId)";

                    сommand.Parameters.Add( "@studentId", SqlDbType.NVarChar ).Value = studentId;
                    сommand.Parameters.Add( "@groupId", SqlDbType.NVarChar ).Value = groupId;

                    сommand.ExecuteNonQuery();
                }
            }
        }

        public List<Student> GetStudentListByGroupId( int groupId )
        {
            var student = new List<Student>();

            using ( var connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand сommand = connection.CreateCommand() )
                {
                    сommand.CommandText =
                        @"select distinct [FirstName], [LastName] from Student
                        join StudentInGroup on StudentInGroup.StudentId = Student.Id
                        join StudentGroup on StudentGroup.Id = StudentInGroup.GroupId
                        where StudentGroup.Id = @groupId";

                    сommand.Parameters.Add( "@groupId", SqlDbType.NVarChar ).Value = groupId;

                    using ( SqlDataReader reader = сommand.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            student.Add( new Student()
                            {
                                FirstName = Convert.ToString( reader[ "FirstName" ] ),
                                LastName = Convert.ToString( reader[ "LastName" ] )
                            } );
                        }
                    }
                }
            }
            return student;
        }

    }
}
