using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Model22TextFile.Domain.Extensions;

namespace Model22TextFile.Domain.File
{
    public class Numerico : Campo
    {
        public Numerico(string mame, short lentgh = 1, bool isMandatory = true, bool isFixed = true, short scale = 0)
        {
            Name = mame;
            Length = lentgh;
            IsMandatory = isMandatory;
            IsFixed = isFixed;
            Scale = scale;
        }

        public override string ToString()
        {
            try
            {
                if (Value == null)
                    Value = 0;

                if (Scale > 0)
                {
                    var decimalValue = Value.To<decimal>();
                    return decimalValue
                        .ParseToString(Scale, "pt-BR")
                        .RemoveCharacter(",","")
                        .PadLeft(Length, '0');
                }

                return Convert.ToInt64(Value)
                    .ToString(CultureInfo.InvariantCulture)
                    .PadLeft(Length, '0');
            }
            catch (Exception exception)
            {
                throw new FormatException(string.Format("Erro no campo {0}", Name), exception);
            }
        }


    }
}
