using System.Globalization;
using Model22TextFile.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevExpress.Xpo;


namespace Model22TextFile.Domain.Model22
{
    public class MovimentoRepositorio : IMovimentoRepositorio
    {
        public List<MovimentoModel22> GetAll(int pEstabelecimentoId, DateTime pDataInicio, DateTime pDataFim)
        {
            var movimentos = new List<MovimentoModel22>();

            UtilXpo.WriteLog("GetAll, antes query vwMega.");
            
            var vwMega = new XPQuery<ViewMegaNotaModel22>(Session.DefaultSession)
                .Where(v => v.FIL_IN_CODIGO == pEstabelecimentoId && v.NOT_DT_EMISSAO >= pDataInicio && v.NOT_DT_EMISSAO <= pDataFim)
                .OrderBy(v => v.NOT_IN_NUMERO)
                .ToList();

            if (!vwMega.Any())
                throw new Exception("Nao existe movimento com os parâmetros informados. Verifique.");

            foreach (var linha in vwMega)
                movimentos.Add(GetMovimento(linha));

            return movimentos;
        }

        private MovimentoModel22 GetMovimento(ViewMegaNotaModel22 linha)
        {
            var movimento = new MovimentoModel22();

            movimento.EstabelecimentoCpfCnpj = linha.ORG_CNPJ;
            movimento.EstabelecimentoIe = linha.ORG_IE;
            movimento.EstabelecimentoRazaoSocial = linha.ORG_NOME;
            movimento.EstabelecimentoCep = linha.ORG_CEP;
            movimento.EstabelecimentoBairro = linha.ORG_BAIRRO;
            movimento.EstabelecimentoMunicipio = linha.ORG_MUNICIPIO;
            movimento.EstabelecimentoUf = linha.ORG_UF;
            movimento.EstabelecimentoEndereco = linha.ORG_LOGRADOURO;

            movimento.AliqIcms = linha.ITN_RE_ALIQICMS;
            movimento.ClienteBairro = linha.CLI_BAIRRO;
            movimento.ResponsavelCargo = linha.RESPONSAVEL_CARGO;
            movimento.ClienteCep = linha.CLI_CEP;
            movimento.Cfop = linha.CFOP_ST_EXTENSO;
            movimento.CodigoAutenticacaoDocumento = linha.HASHCODE;
            movimento.CodigoClasseItem = linha.CODIGO_CLASSIFICACAO_ITEM;
            movimento.ClienteCodigo = linha.AGN_IN_CODIGO.ToString(CultureInfo.InvariantCulture);
            movimento.ClienteRazaoSocial = linha.AGN_ST_NOME;
            movimento.CodigoIdentificacaoConsumidor = string.Empty;
            
            movimento.ClienteCpfCnpj = linha.CPF_CNPJ;
            movimento.ResponsavelEmail = string.Empty;

            int numeroCliente = 0;
            if (int.TryParse(linha.CLI_NUMERO, out numeroCliente))
                movimento.ClienteEnderecoNumero = Convert.ToInt32(linha.CLI_NUMERO).ToString();
            else
                movimento.ClienteEnderecoNumero = "0";

            if (!string.IsNullOrEmpty(linha.CLI_IE))
                movimento.ClienteIe = linha.CLI_IE.ToUpper();
            else
                movimento.ClienteIe = string.Empty;

            movimento.ClienteLogradouro = linha.CLI_LOGRADOURO;
            movimento.DataEmissao = linha.NOT_DT_EMISSAO;

            movimento.Item = "1";
            movimento.CodigoServicoFornecimento = linha.PRO_IN_CODIGO.ToString();
            movimento.DescricaoServicoFornecimento = linha.ITN_ST_DESCRICAO;

            movimento.NumeroTerminalTelefonico = string.Empty;
            movimento.NumLinhaItem = 1;
            movimento.QtdadeContratada = 1;
            movimento.QtdadePrestada = 1;
            movimento.NumeroNf = linha.NOT_IN_NUMERO;
            movimento.Modelo = linha.MODELO;
            movimento.Serie = linha.SER_ST_CODIGO;
            movimento.Situacao = linha.SITUACAO;
            movimento.ClienteTelefone = string.Empty;
            movimento.DescricaoServicoFornecimento = linha.ITN_ST_DESCRICAO;

            movimento.ClienteUf = linha.CLI_UF;
            movimento.ClienteMunicipio = linha.CLI_MUNICIPIO;
            movimento.UfTerminalTelefonico = string.Empty;
            movimento.Unidade = string.Empty;
            movimento.ValorAcrescimo = decimal.Zero;
            movimento.ValorBaseIcms = linha.NOT_RE_BASEICMS;
            movimento.ValorDesconto = decimal.Zero;
            movimento.ValorIcms = linha.NOT_RE_VALORICMS;
            movimento.ValorIcmsIsento = linha.NOT_RE_VALORTOTAL;
            movimento.ValorIcmsOutros = decimal.Zero;
            movimento.ValorTotal = linha.NOT_RE_VALORTOTAL;

            movimento.ClasseConsumoTipoAssinante = linha.CLASSE_CONSUMO;
            movimento.FaseTipoUtilizacao = linha.FASE_TIPO_UTILIZACAO;
            movimento.GrupoTensao = linha.GRUPO_TENSAO;

            movimento.Responsavel = linha.RESPONSAVEL_NOME;
            movimento.ResponsavelCargo = linha.RESPONSAVEL_CARGO;
            movimento.ResponsavelEmail = linha.RESPONSAVEL_EMAIL;
            movimento.ResponsavelTelefone = linha.RESPONSAVEL_TELEFONE;

            return movimento;
        }

        private void CheckIfExistsMoviment(DataTable movimento)
        {
            if (movimento == null || movimento.Rows.Count == 0)
                throw new Exception("Nao existe movimento com os parâmetros informados. Verifique.");
        }


    }
}
