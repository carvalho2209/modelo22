using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model22TextFile.Domain.File
{
    public interface IBlocoArquivo
    {
        void AppendBlock(StringBuilder stringBuilder);
    }    
}
