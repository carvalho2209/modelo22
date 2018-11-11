using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Model22TextFile.Domain.Extensions;

namespace Model22TextFile.Domain.File
{
    public abstract class Registro : IRegistro
    {
        public IList<ICampo> Campos { get; set; }
        public IList<IRegistro> Registros { get; set; }
        public int Count { get; set; }

        protected Registro()
        {
            Registros = new List<IRegistro>();
            Campos = new List<ICampo>();
        }

        public virtual void AppendLine(StringBuilder stringBuilder)
        {
            try
            {
                if (stringBuilder.Length > 0) 
                    stringBuilder.Append(Environment.NewLine);
                    
                foreach (var campo in Campos)
                    ApendField(stringBuilder, campo);

                Count++;
            }
            catch (Exception exception)
            {
                throw new Exception("Erro ao processar registro.", exception);
            }
        }

        protected void AddRecords(IList<IRegistro> registros)
        {
            if (registros.IsEmpty())
                return;

            foreach (var registro in registros)
                AddRecord(registro);
        }

        protected virtual void ApendField(StringBuilder stringBuilder, ICampo campo)
        {
            stringBuilder.Append(campo);
        }

        public Dictionary<string, long> GetCountSum()
        {
            var dic = new Dictionary<string, long>();

            if (Count == 0)
                return dic;

            if (!Registros.IsEmpty())
            {
                foreach (var dicChieldrem in Registros.SelectMany(registro => registro.GetCountSum()))
                    dic.Add(dicChieldrem.Key, dicChieldrem.Value);
            }

            return dic;
        }

        public abstract void Append(StringBuilder stringBuilder);

        protected T AddRecord<T>(T registro) where T : IRegistro
        {
            Registros.Add(registro);
            return registro;
        }

        protected T AddField<T>(T field) where T : ICampo
        {
            Campos.Add(field);
            return field;
        }

    }
}
