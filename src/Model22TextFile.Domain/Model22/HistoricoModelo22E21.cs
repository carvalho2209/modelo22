using System;

namespace Model22TextFile.Domain.Model22
{
    public class HistoricoModelo22E21
    {
        public string NomeDoArquioMestre { get; set; }
        
        public string HashDoArquivoMestere { get; set; }
        
        public string NomeDoArquivoItem { get; set; }

        public string HashDoArquivoItem { get; set; }

        public string NomeDoArquivoDados { get; set; }

        public string HashDoArquivoDados { get; set; }

        public int QtdRegistroMestre { get; set; }

        public decimal ValorTotal { get; set; }
        
        public decimal ValorDesconto { get; set; }

        public decimal ValorAcrescimo { get; set; }

        public decimal ValorBaseIcms { get; set; }

        public decimal ValorBaseIsentas { get; set; }

        public decimal ValorOutros { get; set; }

        public DateTime ReferenciaInicial { get; set; }

        public DateTime ReferenciaFinal { get; set; }
        public decimal ValorIcms { get; set; }
        public int CodigoDaFilial { get; set; }
    }
}