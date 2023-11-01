using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab4;

public partial class PharmacyContext : DbContext
{
    public PharmacyContext()
    {
    }

    public PharmacyContext(DbContextOptions<PharmacyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<Outgoing> Outgoings { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }
}
