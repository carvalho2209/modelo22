using Model22TextFile.Domain.File;

namespace Model22TextFile.Domain.Model22
{
    public class ArquivoMestre : Arquivo
    {
        public ArquivoMestre(IStoreModel22 parametro)
            : base("ArquivoMestre", "M")
        {
            Registros.Add(new RegistroMestre(parametro));
        }
    }
}
