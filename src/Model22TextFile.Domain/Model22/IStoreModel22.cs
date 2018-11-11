using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model22TextFile.Domain.Model22
{
    public interface IStoreModel22
    {
        int EstabelecimentoId { get; set; }
        DateTime DataInicio { get; set; }
        DateTime DataFim { get; set; }

        bool Retificacao { get; set; }

        List<MovimentoModel22> Movimentos { get; set; }

        void LoadMoviment();

        string GetStringRetificacao();
    }
}
