using System;
using System.Collections.Generic;

namespace ApiRetailXYZ.Data.Models;

public partial class Respuestas
{
    public Guid Id { get; set; }

    public Guid EncuestaId { get; set; }

    public Guid PreguntaId { get; set; }

    public string Respuesta { get; set; } = null!;

    public virtual Encuesta Encuesta { get; set; } = null!;

    public virtual Preguntas Pregunta { get; set; } = null!;
}
