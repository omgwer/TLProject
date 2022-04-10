using System.Data;
using System.Data.SqlClient;
using SQLProgram.Container;
using SQLProgram.Repository;

namespace SQLProgram;

class Program
{
    private const string _connectionString =
        @"Data Source=ALEXANDR\SQLEXPRESS;Initial Catalog=UniversitySql;Pooling=true;Integrated Security=SSPI";

    public static void Main(string[] args)
    {
        //new Test().GetStudentsCountInGroup(2,3);
        var newStudent = new Student();
        newStudent.FirstName = "vasya";
        newStudent.LastName = "pupkin";
        //    new StudentRowRepository(_connectionString).AddStudent(newStudent);
      //  var test = new StudentRowRepository( _connectionString ).GetById( 1);
        var listTest = new StudentRowRepository( _connectionString ).GetAllStudents();
    }

    public class Test
    {
        public void GetStudentsCountInGroup(int groupId, int studentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand сommand = connection.CreateCommand())
                {
                    сommand.CommandText = @"insert into [StudentInGroup]
                                ([StudentId], [GroupId])
                                values 
                                (@studentId, @groupId)";
                    
                    сommand.Parameters.Add( "@studentId", SqlDbType.NVarChar ).Value = studentId;
                    сommand.Parameters.Add( "@groupId", SqlDbType.NVarChar ).Value = groupId;
                    сommand.ExecuteNonQuery();
                }
            }
        }
    }
}