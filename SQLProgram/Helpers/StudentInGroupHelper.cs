using System.Text.RegularExpressions;
using SQLProgram.Container;
using SQLProgram.Repositories;

namespace SQLProgram.Helpers
{
    public class StudentInGroupHelper : StudentInGroupRepository
    {
        private readonly string _connectionString;
        public StudentInGroupHelper(string _connectionString) : base(_connectionString)
        {
            this._connectionString = _connectionString;
        }

        public void AddStudentIntoGroup()
        {            
            Console.WriteLine( "Input student id:" );
            int studentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine( "Input group id:" );
            int groupId = Convert.ToInt32(Console.ReadLine());
            base.AddStudentIntoGroup( studentId, groupId );
            Console.WriteLine( "Success." );
        }

        public void GetStudentListByGroupId()
        {
            Console.WriteLine( "Input group id:" );
            int groupId = Convert.ToInt32( Console.ReadLine() );
            var studentList = base.GetStudentListByGroupId( groupId );

            foreach ( var student in studentList )
            {
                Console.WriteLine( student.FirstName + " " + student.LastName);
            }

            Console.WriteLine( "Success" );
        }
    }
}
