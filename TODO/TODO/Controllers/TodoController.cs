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
    [Route( "get-all" )]  
    public IActionResult GetAllTodos()
    {
        List<TodoDto> todos = _todoService.GetTodos();

        if ( todos.Count == 0 )
        {
            return NotFound();
        }
        else
        {
            return Ok( todos );
        }
    }

    [HttpGet]
    [Route( "{todoId}" )]  // параметр метода в запросе
    public IActionResult GetTodo( int todoId )
    {
        TodoDto? todo = _todoService.GetTodo( todoId );

        if ( todo == null )
        {
            return NotFound();
        }
        else
        {
            return Ok( todo );
        }       
    }

    [HttpPost]
    [Route( "create" )]
    public IActionResult CreateTodo( [FromBody] TodoDto todo )
    {
        TodoDto? createdTodo = _todoService.CreateTodo( todo );
        if ( createdTodo == null )
        {
            return NotFound();
        }
        return Ok( createdTodo );
    }

    [HttpDelete]
    [Route( "delete" )]
    public IActionResult DeleteTodo( int todoId )
    {
        _todoService.DeleteTodo( todoId );
        return Ok();
    }

    [HttpPut]
    [Route( "{todoId}/complete" )]
    public IActionResult CompleteTodo( int todoId )
    {
        TodoDto? comletedTodo = _todoService.CompleteTodo( todoId );
        if ( comletedTodo == null )
        {
            return NotFound();
        }
        return Ok( comletedTodo );
    }
}