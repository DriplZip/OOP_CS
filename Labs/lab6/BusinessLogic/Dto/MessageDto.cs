using DataAccess.Enums;
using DataAccess.Models;

namespace BusinessLogic.Dto;

public record MessageDto(Guid employeeId, string messageText, string comment, Guid messageId, DateTime creationTime, MessageStatus messageStatus);