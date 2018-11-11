using System;
using System.Collections.Generic;
using System.Linq;
using Model22TextFile.Domain.File;
using Model22TextFile.Infra;

namespace Model22TextFile.Domain.Model22
{
    public class ArquivoModel22 : Arquivo
    {
        private readonly IStoreModel22 _parametro;
        private List<IArquivo> _arquivos;

        private static string _nomeArquivoMestre;
        private static string _nomeArquivoItem;
        private static string _nomeArquivoCadastro;

        private static string _fullPath;

        public ArquivoModel22(IStoreModel22 parametro, string fullPath)
            : base("Modelo22", string.Empty)
        {
            _parametro = parametro;
            _fullPath = fullPath;

            if (_parametro == null)
                throw new Exception("Parâmetro não pode ser nulo.");

            AddFiles();
        }

        private void AddFiles()
        {
            if (_arquivos == null)
                _arquivos = new List<IArquivo>();

            var arquivoMestre = new ArquivoMestre(_parametro);
            _nomeArquivoMestre = GetFileName(arquivoMestre);
            _arquivos.Add(arquivoMestre);

            var arquivoItem = new ArquivoItem(_parametro);
            _nomeArquivoItem = GetFileName(arquivoItem);
            _arquivos.Add(arquivoItem);

            var arquivoCadastro = new ArquivoDadosCadastrais(_parametro);
            _nomeArquivoCadastro = GetFileName(arquivoCadastro);
            _arquivos.Add(arquivoCadastro);
            _arquivos.Add(new ArquivoInformacaoControle(_parametro, new  HashDosArquivos(), _fullPath));

        }

        public void CreateFiles()
        {
            foreach (var arquivo in _arquivos)
                arquivo.CreateFile(_fullPath, GetFileName(arquivo));
        }

        public static string GetFileNameArquivoMestre()
        {
            return _nomeArquivoMestre;
        }

        public static string GetFileNameArquivoItem()
        {
            return _nomeArquivoItem;
        }

        public static string GetFileNameArquivoDadosCadastrais()
        {
            return _nomeArquivoCadastro;        
        }
        
        private string GetFileName(IArquivo arquivo)
        {
            /* UFSSSAAMMSTT.VVV
            * UF - uf do emitente dos docs fiscais
            * SSS - serie dos docs fiscais
            * AA - ano do periodo de apuracao dos docs fiscais
            * MM - mes do periodo de apuracao dos docs fiscais
            * ST - indica se o arquivo é normal (N) ou substituto (S)
            * T - Tipo, inicial do tipo do arquivo, podendo assumir :
            *   'M' - Mestre do Documnto Fiscal
            *   'I' - Item de Documnto Fiscal
            *   'D' - Dados cadastrais do destinatario do documento fiscal
            *   'C' - Controle e identificacao
            *   'VVV' - numero sequenciadl do volume, limitado a 100 mil em cada arquivo, iniciando de 001. 
            *          (em nosso caso sera sempre 001)
             *          */

            if (!_parametro.Movimentos.Any())
                throw new Exception("Nenhum movimento para gerar o nome do arquivo.");

            var movimento = _parametro.Movimentos.First();

            var uf = movimento.ClienteUf;
            var serie = movimento.Serie.PadLeft(3, ' ');
            var ano = movimento.DataEmissao.ToString("yy");
            var mes = movimento.DataEmissao.ToString("MM");
            var tipoArquivo = "N";
            var tipoInicialArquivo = arquivo.TipoArquivo;
            var volume = "001";

            var fileName = string.Format("{0}{1}{2}{3}{4}{5}.{6}",
                uf, serie, ano, mes, tipoArquivo, tipoInicialArquivo, volume);

            UtilXpo.WriteLog("GetNomeArquivo: " + fileName);

            return fileName;
        }
    }
}

