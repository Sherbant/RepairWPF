using System;
using System.Collections.Generic;

namespace RepairWPF.Models;

public partial class Request
{
    public int Id { get; set; }

    public DateOnly StartDate { get; set; }

    public string HomeTechType { get; set; } = null!;

    public string HomeTechModel { get; set; } = null!;

    public string? ProblemDescription { get; set; }

    public int StatusId { get; set; }

    public int? ClientId { get; set; }

    public int? MasterId { get; set; }

    public DateOnly? CompletionDate { get; set; }

    public string? RepairParts { get; set; }

    public virtual User? Client { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? Master { get; set; }

    public virtual Status Status { get; set; } = null!;
}
