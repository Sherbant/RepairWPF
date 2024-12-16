using System;
using System.Collections.Generic;

namespace RepairWPF.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string Message { get; set; } = null!;

    public int MasterId { get; set; }

    public int RequestId { get; set; }

    public virtual User Master { get; set; } = null!;

    public virtual Request Request { get; set; } = null!;
}
