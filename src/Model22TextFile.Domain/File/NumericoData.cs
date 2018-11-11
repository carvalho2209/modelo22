using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model22TextFile.Domain.Extensions;

namespace Model22TextFile.Domain.File
{
    public class NumericoData : Campo
    {
        public NumericoData(string mame, bool isMandatory = true)
        {
            Name = mame;
            IsMandatory = isMandatory;
        }

        public override string ToString()
        {
            //if (Value == null && IsMandatory)
            //_log.WarnIfEnabled("Campo de data está marcado como obrigatório mas foi informado como nulo");

            return Value == null ? "00000000" : Value.To<DateTime>().ToString("yyyyMMdd");
        }
    }
}
