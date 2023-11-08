using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4;

public partial class Medicine
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;

    public string ActiveSubstance { get; set; } = null!;

    public int ProducerId { get; set; }

    public string UnitOfMeasurement { get; set; } = null!;

    public int Count { get; set; }

    public string StorageLocation { get; set; } = null!;

    public virtual ICollection<Outgoing> Outgoings { get; set; } = new List<Outgoing>();

    public virtual Producer Producer { get; set; } = null!;

}
