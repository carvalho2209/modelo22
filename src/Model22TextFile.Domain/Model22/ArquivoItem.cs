using Model22TextFile.Domain.File;

namespace Model22TextFile.Domain.Model22
{
    public class ArquivoItem : Arquivo
    {
        public ArquivoItem(IStoreModel22 parametro)
            : base("ArquivoItem", "I")
        {
            Registros.Add(new RegistroItem(parametro));
        }
    }
}
