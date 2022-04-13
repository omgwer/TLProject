using SQLProgram.Repositories;

namespace SQLProgram.Helpers
{
    public class StudentGroupHelper : GroupRowRepository
    {
        private readonly string _connectionString;
        public StudentGroupHelper( string _connectionString ) : base( _connectionString )
        {
            this._connectionString = _connectionString;
        }

        public void AddGroup()
        {
            Console.WriteLine( "Input student group name:" );
            var groupName = Console.ReadLine();
            base.AddGroup( groupName );
            Console.WriteLine( "Success." );
        }

        public void GetAllGroups()
        {
            var groups = base.GetAllGroups();
            foreach ( var group in groups ) 
            {
                Console.WriteLine( group.Id + " : " + group.Name );
            }
        }
    }
}
