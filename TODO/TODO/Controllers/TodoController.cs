using Microsoft.AspNetCore.Mvc;
using TODO.Dto;

namespace TODO.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    [HttpGet]
    [Route(" {todoId}")]
    public IActionResult GetTodo(int todoId)
    {
        return Ok( $"TodoId: {todoId}" );
    }

    [HttpPost]
    [Route("create")]
    public IActionResult CreateTodo([FromBody] TodoDto todo)
    {
        return Ok( $"Id : {todo.Id}, Title : {todo.Title}, IsDone : {todo.IsDone}" );
    }

    [HttpDelete]
    [Route("delete")]
    public IActionResult DeleteTodo(int todoId)
    {
        return Ok( $"Todo with id: {todoId} deleted" );
    }

    [HttpPut]
    [Route("{todoId}")]
    public IActionResult UpdateTodo([FromBody] TodoDto todo)
    {
        try
        {
            return Ok($"Todo with id: {todo.Id} update");
        }
        catch
        {
            
        }
    }
}