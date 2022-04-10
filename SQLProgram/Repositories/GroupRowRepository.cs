using System.Data;
using System.Data.SqlClient;
using SQLProgram.Container;

namespace SQLProgram.Repositories
{
    public class GroupRowRepository
    {
        private readonly string _connectionString;

        public GroupRowRepository( string _connectionString )
        {
            this._connectionString = _connectionString;
        }


        public void AddGroup( string groupName )
        {
            using ( var connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( var command = connection.CreateCommand() )
                {
                    command.CommandText =
                        @"insert into [StudentGroup]
                            values
                        (@GroupName)";
                    command.Parameters.Add( "@GroupName", SqlDbType.NVarChar ).Value = groupName;
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
                        @"delete from [StudentGroup]
                        where [Id] = @id";
                    command.Parameters.Add( "@id", SqlDbType.Int ).Value = id;

                    command.ExecuteNonQuery();
                }
            }
        }

        public Group? GetById( int id )
        {
            Group? group = default;

            using ( var connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();

                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText =
                        $@"select * from [StudentGroup]
                        where [id] = @id";

                    command.Parameters.Add( "@id", SqlDbType.Int ).Value = id;

                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        if ( reader.Read() )
                        {
                            group = new Group();
                            var properties = typeof( Group ).GetProperties();
                            foreach ( var prop in properties )
                            {
                                prop.SetValue( group, reader[ prop.Name ] );
                            }

                        }
                    }
                }

            }
            return group;
        }

        public List<Group> GetAllGroups()
        {
            List<Group> groupList = new List<Group>();

            using ( var connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();

                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = $@"select * from [StudentGroup]";

                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            var group = new Group();
                            var properties = typeof( Group ).GetProperties();

                            foreach ( var prop in properties )
                            {
                                prop.SetValue( group, reader[ prop.Name ] );
                            }

                            groupList.Add( group );
                        }
                    }
                }
            }
            return groupList;
        }
    }
}
