using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Model22TextFile.Domain.File
{
    public class Arquivo : IArquivo
    {
        public IList<IRegistro> Registros { get; set; }

        public string NewLine { get { return Environment.NewLine; } }
        public string FileNamePrefix { get; private set; }
        public string Ext { get; set; }
        public string TipoArquivo { get; set; }

        public static readonly string SpedEncoding = "iso-8859-1";

        public Arquivo(string preffix, string tipoArquivo)
        {
            FileNamePrefix = preffix;
            Registros = new List<IRegistro>();
            TipoArquivo = tipoArquivo;
        }

        public Arquivo()
        {
            // TODO: Complete member initialization
        }

        public virtual string CreateFile(string pPath, string pFileName)
        {
            var stringBuilder = GetContent();
            var fileName = Path.Combine(pPath, pFileName);

            System.IO.File.WriteAllText(fileName, stringBuilder.ToString(),
                //Encoding.ASCII);
                Encoding.GetEncoding(SpedEncoding));

            return fileName;
        }

        public string GetFileName(string pPath)
        {
            var fileName = FileNamePrefix;

            //if (AddStampDate)
            //    fileName = string.Format("{0}_{1}_{2}",
            //        fileName, cnpj.NoSimbols(), DateTime.Now.ToString("yyyyMMdd_HHmmss"));

            return Path.Combine(pPath,
                string.Format("{0}.{1}", fileName, Ext));
        }

        public StringBuilder GetContent()
        {
            var sb = new StringBuilder();

            foreach (var registro in Registros)
                registro.Append(sb);

            //Final do arquivo deve ser uma linha em branco
            sb.AppendLine();
            //sb.Append(NewLine);

            return sb;
        }

        protected T AddRegistro<T>(T registro) where T : IRegistro
        {
            Registros.Add(registro);
            return registro;
        }
       
    }
}
