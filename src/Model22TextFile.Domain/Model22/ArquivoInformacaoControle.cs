using Model22TextFile.Domain.File;

namespace Model22TextFile.Domain.Model22
{
    public class ArquivoInformacaoControle : Arquivo
    {
        public ArquivoInformacaoControle(IStoreModel22 parametro, IHashDosArquivos hashDosArquivos, string fullPath)
            : base("ArquivoInformacaoControle", "C")
        {
            Registros.Add(new RegistroInformacaoControle(parametro, hashDosArquivos, fullPath));
        }
    }
}
