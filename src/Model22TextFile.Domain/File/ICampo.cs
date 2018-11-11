using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model22TextFile.Domain.File
{
    public interface ICampo
    {
        string Name { get; set; }
        short Length { get; set; }
        short Scale { get; set; }
        bool IsFixed { get; set; }
        bool IsMandatory { get; set; }
        object Value { get; set; }
    }
}
