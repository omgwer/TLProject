using SQLProgram.Helpers;

namespace SQLProgram;

class Program
{
    private const string _connectionString =
        @"Data Source=ALEXANDR\SQLEXPRESS;Initial Catalog=UniversitySql;Pooling=true;Integrated Security=SSPI";

    public static void Main( string[] args )
    {
        var studentHelper = new StudentHelper( _connectionString );
        var groupHelper = new StudentGroupHelper( _connectionString );
        var studentInGroupHelper = new StudentInGroupHelper( _connectionString );

        while ( true )
        {
            Console.WriteLine( "Command list: " );
            Console.WriteLine( "\t1 - Add student" );
            Console.WriteLine( "\t2 - Add group" );
            Console.WriteLine( "\t3 - Add student with group" );
            Console.WriteLine( "\t4 - Print students list" );
            Console.WriteLine( "\t5 - Print students group" );
            Console.WriteLine( "\t6 - Print students by group id" );
            Console.WriteLine( "\t0 - Exit" );
            Console.WriteLine( "Input number for run this command" );

            int command = -1;

            try
            {
                command = Convert.ToInt32( Console.ReadLine() );
            }
            catch ( Exception ex )
            {
                Console.WriteLine( "Input number!" );
            }

            if ( command < 0 | command > 6 )
            {
                Console.WriteLine( "This command not find" );
                continue;
            }

            if ( command == 0 )
            {
                break;
            }

            switch ( command )
            {
                case 1: studentHelper.AddStudent(); break;
                case 2: groupHelper.AddGroup(); break;
                case 3: studentInGroupHelper.AddStudentIntoGroup(); break;
                case 4: studentHelper.GetAllStudents(); break;
                case 5: groupHelper.GetAllGroups(); break;
                case 6: studentInGroupHelper.GetStudentListByGroupId(); break;
            }
        }
    }

}