using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model22TextFile.Domain.Extensions;

namespace Model22TextFile.Domain.File
{
    public class Alpha : Campo
    {
        public Alpha(string mame, short lentgh = 255, bool isfixed = false, bool isMandatory = false, string value = null)
        {
            Name = mame;
            Length = lentgh;
            IsFixed = isfixed;
            IsMandatory = isMandatory;
            Value = value;
        }

        public override string ToString()
        {
            if (Value == null)
                Value = string.Empty;

            var charectesNaoImprimiveis = new List<char>();

            foreach (var i in Enumerable.Range(0, 30))
                charectesNaoImprimiveis.Add(Convert.ToChar(i));

            charectesNaoImprimiveis.Add('|');

            var newValue = Value.ToString().RemoveCharacter(new string(charectesNaoImprimiveis.ToArray()), "");

            return newValue.MaxLength(Length).PadRight(Length, ' ');
        }
    }
}
