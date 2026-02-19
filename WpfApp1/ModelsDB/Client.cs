using System;
using System.Collections.Generic;

namespace WpfApp1.ModelsDB;

public partial class Client
{
    public byte Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }
}
