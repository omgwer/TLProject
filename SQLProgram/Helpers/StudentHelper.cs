using SQLProgram.Container;
using SQLProgram.Repository;

namespace SQLProgram.Helpers
{
    public class StudentHelper : StudentRowRepository
    {
        private readonly string _connectionString;
        public StudentHelper( string _connectionString ) : base( _connectionString )
        {
            this._connectionString = _connectionString;
        }

        public void AddStudent()
        {
            var newStudent = new Student();
            Console.WriteLine( "Input student first name:" );
            newStudent.FirstName = Console.ReadLine();
            Console.WriteLine( "Input student last name:" );
            newStudent.LastName = Console.ReadLine();
            base.AddStudent( newStudent );
            Console.WriteLine( "Success." );
        }

        public void GetAllStudents()
        {
            var students = base.GetAllStudents();
            students.ForEach( student => Console.WriteLine( student.FirstName + " " + student.LastName ) );
        }
    }
}
