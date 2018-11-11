using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model22TextFile.Domain.Model22
{
    public class MovimentoModel22
    {
        // Registro Dados Cadastrais ( Cliente )
        public string ClienteCpfCnpj { get; set; }
        public string ClienteIe { get; set; }
        public string ClienteCodigo { get; set; }
        public string ClienteRazaoSocial { get; set; }
        public string ClienteLogradouro { get; set; }
        public string ClienteEnderecoNumero { get; set; }
        public string ClienteCep { get; set; }
        public string ClienteBairro { get; set; }
        public string ClienteMunicipio { get; set; }
        public string ClienteUf { get; set; }
        public string ClienteTelefone { get; set; }
        public string CodigoIdentificacaoConsumidor { get; set; }
        public string UfTerminalTelefonico { get; set; }

        // RegistroMestre
        public DateTime DataEmissao { get; set; }
        public string Serie { get; set; }
        public string Modelo { get; set; }
        public int NumeroNf { get; set; }
        public string CodigoAutenticacaoDocumento { get; set; }
        public string Situacao { get; set; }
        public int NumLinhaItem { get; set; }
        public string NumeroTerminalTelefonico { get; set; }

        // Registro Item
        public string Cfop { get; set; }
        public string Item { get; set; }
        public string CodigoServicoFornecimento { get; set; }
        public string DescricaoServicoFornecimento { get; set; }
        public int CodigoClasseItem { get; set; }
        public string Unidade { get; set; }
        public decimal QtdadeContratada { get; set; }
        public decimal QtdadePrestada { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorAcrescimo { get; set; }
        public decimal ValorBaseIcms { get; set; }
        public decimal ValorIcms { get; set; }
        public decimal ValorIcmsIsento { get; set; }
        public decimal ValorIcmsOutros { get; set; }
        public decimal AliqIcms { get; set; }

        public int ClasseConsumoTipoAssinante { get; set; }
        public int FaseTipoUtilizacao { get; set; }
        public int GrupoTensao { get; set; }

        // Registro Informacao Controle ( Estabelecimento )
        public string EstabelecimentoCpfCnpj { get; set; }
        public string EstabelecimentoIe { get; set; }
        public string EstabelecimentoRazaoSocial { get; set; }
        public string EstabelecimentoEndereco { get; set; }
        public string EstabelecimentoCep { get; set; }
        public string EstabelecimentoBairro { get; set; }
        public string EstabelecimentoMunicipio { get; set; }
        public string EstabelecimentoUf { get; set; }
        public string Responsavel { get; set; }
        public string ResponsavelCargo { get; set; }
        public string ResponsavelTelefone { get; set; }
        public string ResponsavelEmail { get; set; }

    }
}
