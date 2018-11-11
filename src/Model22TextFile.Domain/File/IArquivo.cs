using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model22TextFile.Domain.File
{
    public interface IArquivo
    {
        string NewLine { get; }
        string FileNamePrefix { get; }
        IList<IRegistro> Registros { get; set; }
        string TipoArquivo { get; set; }

        string CreateFile(string pPath, string pFileName);
        StringBuilder GetContent();
    }
}
