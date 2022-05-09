using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TODO.Dto;
using TODO.Infrastructure;
using TODO.Repositories;

namespace TODO.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class TodoController : ControllerBase
{
    private readonly ITodoRepository _todoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TodoController( ITodoRepository todoRepository, IUnitOfWork unitOfWork )
    {
        _todoRepository = todoRepository;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [Route( "get-all" )]
    public IActionResult GetAllTodos()
    {
        List<TodoDto> todos = _todoRepository.GetTodos();
        
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
        TodoDto? todo = _todoRepository.GetTodo( todoId );

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
        var createdTodo = _todoRepository.CreateTodo( todo );
        if ( createdTodo == null )
        {
            return NotFound();
        }

        _unitOfWork.Commit();

        return Ok( createdTodo );
    }

    [HttpDelete]
    [Route( "{todoId}/delete" )]
    public IActionResult DeleteTodo( int todoId )
    {
        var entity = _todoRepository.GetTodo( todoId );

        if (entity == null)
        {
            return BadRequest();
        }

        _todoRepository.DeleteTodo( entity );
        _unitOfWork.Commit();
        
        return Ok();
    }

    [HttpPut]
    [Route( "{todoId}/complete" )]
    public IActionResult CompleteTodo( int todoId )
    {
        var completedTodo = _todoRepository.GetTodo( todoId );

        if ( completedTodo == null )
        {
            return BadRequest();
        }

        completedTodo.IsDone = true;

        _todoRepository.UpdateTodo( completedTodo );
        _unitOfWork.Commit();

        return Ok();
    }
}