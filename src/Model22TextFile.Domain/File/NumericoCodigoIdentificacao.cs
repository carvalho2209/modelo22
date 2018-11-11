using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model22TextFile.Domain.Extensions;

namespace Model22TextFile.Domain.File
{
    public class NumericoCodigoIdentificacao : Campo
    {
        public NumericoCodigoIdentificacao(string mame, short lentgh, bool isMandatory = true)
        {
            Name = mame;
            IsMandatory = isMandatory;
            Length = lentgh;
        }

        public override string ToString()
        {
            //if (IsMandatory && Value == null)
            //    log.WarnFormatIfEnabled("Campo [{0}] é obrigatório e foi informado um nulo como valor.", Name);

            if (Value == null)
                Value = "0";

            //TODO: Testar isso aqui
            if (Value.GetType().BaseType == typeof(Enum))
                Value = Value.To<short>();

            var newValue = Value.ToString().RemoveCharacter(@"-.,/\(){}[]”-%$&-.;: ", "");            

            return newValue.MaxLength(Length).PadLeft(Length, '0');
        }
    }
}
