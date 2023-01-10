namespace BusinessLogic.Enums;

public enum AccountRole
{
    /* 0 x 0 0
    /      ^ ^
    /      | AllowEmployeeStatus
    /      |
    /      AllowDirectorStatus
    */

    // 0x00
    User = 0,

    // 0x01
    Employee = 1,

    // 0x10
    Director = 2,

    // 0x11
    Admin = 3,
}