using EduUz.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            // TODO: Create LoginCommand and Handler
            // var command = new LoginCommand(request.EmailOrUsername, request.Password);
            // var response = await _mediator.Send(command);
            
            var response = new LoginResponse
            {
                AccessToken = "sample_token",
                RefreshToken = "sample_refresh_token",
                ExpiresAt = DateTime.UtcNow.AddHours(1),
                User = new UserDto { Id = 1, FirstName = "Test", LastName = "User", Email = request.EmailOrUsername, Role = "Admin" }
            };
            return Ok(response);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            // TODO: Create LogoutCommand and Handler
            // var command = new LogoutCommand(userId);
            // var result = await _mediator.Send(command);
            
            return Ok(new { message = "Logged out successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        try
        {
            // TODO: Create RefreshTokenCommand and Handler
            // var command = new RefreshTokenCommand(request.RefreshToken);
            // var response = await _mediator.Send(command);
            
            var response = new LoginResponse
            {
                AccessToken = "new_token",
                RefreshToken = "new_refresh_token",
                ExpiresAt = DateTime.UtcNow.AddHours(1)
            };
            return Ok(response);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
    {
        try
        {
            // TODO: Create ForgotPasswordCommand and Handler
            // var command = new ForgotPasswordCommand(request.Email);
            // var result = await _mediator.Send(command);
            
            return Ok(new { message = "Password reset email sent if account exists" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        try
        {
            // TODO: Create ResetPasswordCommand and Handler
            // var command = new ResetPasswordCommand(request.Token, request.Email, request.NewPassword);
            // var result = await _mediator.Send(command);
            
            return Ok(new { message = "Password reset successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("change-password")]
    [Authorize]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            // TODO: Create ChangePasswordCommand and Handler
            // var command = new ChangePasswordCommand(userId, request.CurrentPassword, request.NewPassword);
            // var result = await _mediator.Send(command);
            
            return Ok(new { message = "Password changed successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}