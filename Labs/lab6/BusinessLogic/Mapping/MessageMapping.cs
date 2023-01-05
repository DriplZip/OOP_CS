using BusinessLogic.Dto;

namespace BusinessLogic.Mapping;

public static class MessageMapping
{
    public static MessageDto AsDto(this MessageDto message)
        => new MessageDto(message.employee, message.comment, message.id, message.creationTime, message.messageStatus);
}