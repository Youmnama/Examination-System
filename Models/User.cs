﻿using System;
using System.Collections.Generic;

namespace Examination_System.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserPass { get; set; } = null!;

    public int UserAge { get; set; }

    public string? UserPhone { get; set; }

    public string? UserAddress { get; set; }

    public virtual Instructor? Instructor { get; set; }

    public virtual Student? Student { get; set; }
}
