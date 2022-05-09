using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TODO.Dto;
namespace TODO.Infrastructure
{
    public class TodoConfiguration : IEntityTypeConfiguration<TodoDto>
    {
        public void Configure( EntityTypeBuilder<TodoDto> builder )
        {
            builder.HasKey( t => t.Id );
            builder.Property( t => t.Title ).HasMaxLength( 200 ).IsRequired();
            builder.Property( t => t.IsDone ).HasDefaultValue( false );
        }
    }
}
