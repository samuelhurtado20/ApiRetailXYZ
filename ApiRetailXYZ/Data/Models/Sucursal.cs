using System;
using System.Collections.Generic;

namespace ApiRetailXYZ.Data.Models;

public partial class Sucursal
{
    public Guid Id { get; set; }

    public string Sucursal1 { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Provincia { get; set; } = null!;

    public virtual ICollection<Encuesta> Encuesta { get; } = new List<Encuesta>();
}
