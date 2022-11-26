using System;
using System.Collections.Generic;

namespace ApiRetailXYZ.Data.Models;

public partial class Encuesta
{
    public Guid Id { get; set; }

    public Guid SucursalId { get; set; }

    public Guid EncuestadoId { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Encuestado Encuestado { get; set; } = null!;

    public virtual ICollection<Respuestas> Respuesta { get; } = new List<Respuestas>();

    public virtual Sucursal Sucursal { get; set; } = null!;
}
