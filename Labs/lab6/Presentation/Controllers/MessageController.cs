using BusinessLogic.Dto;
using BusinessLogic.Services;
using DataAccess.Enums;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Constants;
using Presentation.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageService _service;

    public MessageController(IMessageService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async Task<ActionResult<MessageDto>> Create([FromBody] CreateMessageModel model)
    {
        MessageDto message = await _service.Create(model.text, model.employeeId);

        return Ok(message);
    }

    [Authorize(Policy = PolicyName.EmployeePolicy)]
    [HttpPut("update-status")]
    public async Task<ActionResult> UpdateMessageStatus([FromQuery] Guid id, [FromQuery] MessageStatus status)
    {
        await _service.UpdateMessageStatus(id, status);

        return Ok();
    }

    [Authorize(Policy = PolicyName.EmployeePolicy)]
    [HttpPut("update-comment")]
    public async Task<ActionResult> SetMessageComment([FromQuery] Guid id, [FromQuery] string comment)
    {
        await _service.SetMessageComment(id, comment);

        return Ok();
    }

    [Authorize(Policy = PolicyName.EmployeePolicy)]
    [HttpGet("get-by-id")]
    public async Task<ActionResult<MessageDto>> GetMessageById([FromQuery] Guid id)
    {
        MessageDto message = await _service.GetMessageById(id);

        return message;
    }

    [Authorize(Policy = PolicyName.EmployeePolicy)]
    [HttpGet("get-by-employee")]
    public async Task<ActionResult<List<MessageDto>>> GetMessagesByEmployee([FromQuery] Guid employeeId)
    {
        List<MessageDto> messages = await _service.GetMessagesByEmployee(employeeId);

        return messages;
    }

    [Authorize(Policy = PolicyName.EmployeePolicy)]
    [HttpGet("get-not-viewed")]
    public async Task<ActionResult<List<MessageDto>>> GetNotViewedMessages()
    {
        List<MessageDto> messages = await _service.GetNotViewedMessages();

        return messages;
    }

    [Authorize(Policy = PolicyName.DirectorPolicy)]
    [HttpDelete("delete")]
    public async Task<ActionResult> Delete([FromQuery] Guid id)
    {
        await _service.Delete(id);

        return Ok();
    }
}