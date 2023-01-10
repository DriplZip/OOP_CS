using BusinessLogic.Dto;
using BusinessLogic.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Constants;
using Presentation.Models;

namespace Presentation.Controllers;

[ApiController]
[Authorize(Policy = PolicyName.DirectorPolicy)]
[Route("api/[controller]")]
public class RecordController : ControllerBase
{
    private readonly IRecordService _service;

    public RecordController(IRecordService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async Task<ActionResult<RecordDto>> Create([FromBody] CreateRecordModel model)
    {
        RecordDto record = await _service.Create(model.employeeId);

        return Ok(record);
    }

    [HttpPut("add-message-to-record")]
    public async Task<ActionResult> AddNewMessageInRecord([FromQuery] Guid recordId, [FromQuery] Guid messageId)
    {
        await _service.AddNewMessageInRecord(recordId, messageId);

        return Ok();
    }

    [HttpGet("get-by-id")]
    public async Task<ActionResult<RecordDto>> FindRecord(Guid id)
    {
        RecordDto record = await _service.FindRecord(id);

        return record;
    }

    [HttpDelete("delete")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _service.Delete(id);

        return Ok();
    }
}