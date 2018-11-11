using Model22TextFile.Domain.Model22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model22TextFile.Domain.Extensions
{
    public static class MovimentoExtentions
    {
        public static IEnumerable<IGrouping<object, MovimentoModel22>> GetMovimentoAgrupadoDadosCadastrais(
            this IEnumerable<MovimentoModel22> movimentos) 
        {
            return movimentos
                  .GroupBy(m => new
                        {
                            m.ClienteCpfCnpj,
                            m.ClienteIe,
                            m.ClienteRazaoSocial,
                            m.ClienteLogradouro,
                            m.ClienteEnderecoNumero,
                            m.ClienteCep,
                            m.ClienteBairro,
                            m.ClienteMunicipio,
                            m.ClienteUf,
                            m.ClienteTelefone,
                            m.DataEmissao,
                            m.ClienteCodigo,
                            m.Modelo,
                            m.Serie,
                            m.NumeroNf,
                            m.Situacao,
                            m.ClasseConsumoTipoAssinante,
                            m.FaseTipoUtilizacao,
                            m.GrupoTensao
                        })
                   .ToList();
        }

        public static IEnumerable<IGrouping<object, MovimentoModel22>> GetMovimentoAgrupadoItem(
           this IEnumerable<MovimentoModel22> movimentos)
        {
            return movimentos
                 .GroupBy(m => new
                            {
                                m.ClienteCpfCnpj,
                                m.ClienteUf,
                                m.DataEmissao,
                                m.ClienteCodigo,
                                m.Modelo,
                                m.Serie,
                                m.NumeroNf,
                                m.Situacao,
                                m.Cfop,
                                m.Item,
                                m.Unidade,
                                m.ClasseConsumoTipoAssinante,
                                m.FaseTipoUtilizacao,
                                m.GrupoTensao,
                                m.DescricaoServicoFornecimento,
                                m.CodigoClasseItem
                            })
                   .ToList();
        }
    }
}
