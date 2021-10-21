using System.Collections.Generic;

namespace Application.Interfaces.Adapters.Tools
{
    public interface IWhatsApp
    {
        bool Notificar(string nome, string telefone, List<string> parametros);
    }
}
