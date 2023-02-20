using System;
using System.Collections.Generic;

namespace _20._101_Kargin_authorization.Model.Database;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }
}
