using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Cadastro.Digital.Worker.Auditoria.Models;

public record AuditoriaModel(Auditoria auditoria)
{
    public Auditoria Auditoria { get; set; } = auditoria;
}