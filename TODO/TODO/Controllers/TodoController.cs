using Microsoft.AspNetCore.Mvc;
using TODO.Dto;
using TODO.Services;

namespace TODO.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController( ITodoService todoService )
    {
        _todoService = todoService;
    }

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
        TodoDto? createdTodo = _todoService.CreateTodo( todo );
        if (createdTodo == null)
        {
            return NotFound();
        }
        return Ok( createdTodo );
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