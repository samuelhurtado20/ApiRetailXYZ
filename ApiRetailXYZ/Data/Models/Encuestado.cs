using ApiRetailXYZ.Data.Models;
using System;
using System.Collections.Generic;

namespace ApiRetailXYZ;

public partial class Encuestado
{
    public Guid Id { get; set; }

    public int Cedula { get; set; }

    public string NombreApellido { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public short Edad { get; set; }

    public virtual ICollection<Encuesta> Encuesta { get; } = new List<Encuesta>();
}
