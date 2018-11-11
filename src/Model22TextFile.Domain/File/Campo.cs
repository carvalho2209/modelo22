using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model22TextFile.Domain.File
{
    public class Campo : ICampo
    {
        public string Name { get; set; }
        public short Length { get; set; }
        public short Scale { get; set; }
        public bool IsFixed { get; set; }
        public bool IsMandatory { get; set; }
        public object Value { get; set; }
    }
}
