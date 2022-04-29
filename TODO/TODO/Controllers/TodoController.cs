using Microsoft.AspNetCore.Mvc;
using TODO.Dto;

namespace TODO.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class TodoController : ControllerBase
{
    private static TodoDto TodoElement = new TodoDto() { Id = 1, Title = "Test", IsDone = true };
        
    [HttpGet]
    [Route( "{todoId}" )]  // параметр метода в запросе
    public IActionResult GetTodo( int todoId )
    {
        if ( todoId == 1 )
        {
            return Ok( $"TodoId: {todoId}" );
        } else
        {
            return NotFound();
        }
        
    }

    [HttpPost]
    [Route( "create" )]
    public IActionResult CreateTodo( [FromBody] TodoDto todo )
    {
        return Ok( $"Id : {todo.Id}, Title : {todo.Title}, IsDone : {todo.IsDone}" );
    }

    [HttpDelete]
    [Route( "delete" )]
    public IActionResult DeleteTodo( int todoId )
    {
        return Ok( $"Todo with id: {todoId} deleted" );
    }

    // [HttpPut]
    // [Route("{todoId}")]
    // public IActionResult UpdateTodo([FromBody] TodoDto todo)
    // {
    //     try
    //     {
    //         return Ok($"Todo with id: {todo.Id} update");
    //     }
    //     catch
    //     {
    //         
    //     }
    // }
}