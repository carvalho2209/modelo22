using Model22TextFile.Domain.File;

namespace Model22TextFile.Domain.Model22
{
    public class ArquivoDadosCadastrais : Arquivo
    {
        public ArquivoDadosCadastrais(IStoreModel22 parametro)
            : base("ArquivoDadosCadastrais", "D")
        {
            Registros.Add(new RegistroDadosCadastrais(parametro));
        }
    }
}
