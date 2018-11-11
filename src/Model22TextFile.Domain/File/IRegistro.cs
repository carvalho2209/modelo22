using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model22TextFile.Domain.File
{
    public interface IRegistro
    {
        IList<ICampo> Campos { get; set; }
        IList<IRegistro> Registros { get; set; }
        int Count { get; set; }

        Dictionary<string, long> GetCountSum();
        void Append(StringBuilder stringBuilder);
        void AppendLine(StringBuilder stringBuilder);
    }
}
