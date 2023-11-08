using System;
using System.Collections.Generic;

namespace Lab4;

public partial class Outgoing
{
    public int Id { get; set; }

    public int MedicineId { get; set; }

    public DateTime ImplementationDate { get; set; }

    public int Count { get; set; }

    public decimal SellingPrice { get; set; }

    public virtual Medicine Medicine { get; set; } = null!;
}
