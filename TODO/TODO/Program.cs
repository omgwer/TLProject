

using TODO.Repositories;
using TODO.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.IncludeFields = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Тут добавить сервис IToDoService в DI
builder.Services.AddScoped<ITodoRepository, TodoRowSqlRepository>( x => new TodoRowSqlRepository( builder.Configuration.GetConnectionString( "DefaultConnection" ) ) );
builder.Services.AddScoped<ITodoService, TodoService>();

var app = builder.Build();

//Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();