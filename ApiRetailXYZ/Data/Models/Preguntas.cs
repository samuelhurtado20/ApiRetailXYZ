using System;
using System.Collections.Generic;

namespace ApiRetailXYZ.Data.Models;

public partial class Preguntas
{
    public Guid Id { get; set; }

    public short Numero { get; set; }

    public string Pregunta { get; set; } = null!;

    public string Escala { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public virtual ICollection<Respuestas> Respuesta { get; } = new List<Respuestas>();
}
