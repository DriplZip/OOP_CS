using DataAccess.Enums;
using DataAccess.Models;

namespace BusinessLogic.Dto;

public record MessageDto(Employee employee, string comment, Guid id, DateTime creationTime, MessageStatus messageStatus);