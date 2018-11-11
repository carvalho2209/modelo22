using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model22TextFile.Domain.Extensions;

namespace Model22TextFile.Domain.File
{
    public class NumericoDataAnoMes : Campo
    {
        public NumericoDataAnoMes(string mame, bool isMandatory = true)
        {
            Name = mame;
            IsMandatory = isMandatory;
        }

        public override string ToString()
        {
            if (Value == null)
                return "0000";

            return Value.To<DateTime>().ToString("yyMM");
        }
    }
}
