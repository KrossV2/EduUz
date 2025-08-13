using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Common;

[ApiController]
[Route("api/notifications")]
[Authorize]
public class NotificationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/notifications
    [HttpGet]
    public async Task<IActionResult> GetNotifications([FromQuery] bool? unreadOnly, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetUserNotificationsQuery and Handler
        // var query = new GetUserNotificationsQuery(userId, unreadOnly, page, pageSize);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetUserNotificationsQuery handler needed" });
    }

    // PUT /api/notifications/{id}/read
    [HttpPut("{id}/read")]
    public async Task<IActionResult> MarkAsRead(int id)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create MarkNotificationAsReadCommand and Handler
        // var command = new MarkNotificationAsReadCommand(id, userId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "MarkNotificationAsReadCommand handler needed" });
    }

    // GET /api/notifications/unread
    [HttpGet("unread")]
    public async Task<IActionResult> GetUnreadNotifications()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetUnreadNotificationsQuery and Handler
        // var query = new GetUnreadNotificationsQuery(userId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetUnreadNotificationsQuery handler needed" });
    }

    // PUT /api/notifications/mark-all-read
    [HttpPut("mark-all-read")]
    public async Task<IActionResult> MarkAllAsRead()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create MarkAllNotificationsAsReadCommand and Handler
        // var command = new MarkAllNotificationsAsReadCommand(userId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "MarkAllNotificationsAsReadCommand handler needed" });
    }

    // GET /api/notifications/count
    [HttpGet("count")]
    public async Task<IActionResult> GetNotificationCount()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetNotificationCountQuery and Handler
        // var query = new GetNotificationCountQuery(userId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetNotificationCountQuery handler needed" });
    }
}