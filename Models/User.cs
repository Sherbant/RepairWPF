using System;
using System.Collections.Generic;

namespace RepairWPF.Models;

public partial class User
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Request> RequestClients { get; set; } = new List<Request>();

    public virtual ICollection<Request> RequestMasters { get; set; } = new List<Request>();
}
