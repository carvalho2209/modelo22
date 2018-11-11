using Model22TextFile.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model22TextFile.Domain.Model22
{
    public class StoreModel22 : IStoreModel22
    {
        private readonly IMovimentoRepositorio _movimentoRepositorio;

        public int EstabelecimentoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Retificacao { get; set; }

        public List<MovimentoModel22> Movimentos { get; set; }

        public StoreModel22()
        {
            if (_movimentoRepositorio == null)
                _movimentoRepositorio = new MovimentoRepositorio();
        }

        public void LoadMoviment()
        {
            if (Movimentos == null)
            {
                UtilXpo.WriteLog("Movimentos == null");
                Movimentos = new List<MovimentoModel22>();
            }

            UtilXpo.WriteLog("Store Model22 , Antes de Chamar GetAll, LoadMoviment()");

            var movimentos = _movimentoRepositorio.GetAll(EstabelecimentoId, DataInicio, DataFim);

            UtilXpo.WriteLog("Store Model22 , Depois de Chamar GetAll, LoadMoviment()");
            
            if (movimentos.Any())
                Movimentos.AddRange(movimentos);
        }

        public string GetStringRetificacao()
        {
            return Retificacao ? "S" : "N";
        }
    }
}
