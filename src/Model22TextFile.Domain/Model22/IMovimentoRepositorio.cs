using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model22TextFile.Domain.Model22
{
    public interface IMovimentoRepositorio
    {
        List<MovimentoModel22> GetAll(int pEstabelecimentoId, DateTime pDataInicio, DateTime pDataFim);
    }
}
