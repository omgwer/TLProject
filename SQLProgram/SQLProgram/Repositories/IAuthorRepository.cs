using SQLProgram.Models;

namespace SQLProgram.Repositories
{
    interface IAuthorRepository
    {
        void Add( Author author );
        void DeleteById( int id );
        Author GetById( int id );
        List<Author> GetAll();
        void Update( Author author );
    }
}