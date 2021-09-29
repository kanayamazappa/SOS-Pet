namespace DomainSOSPet.Entities
{
    public class Doacao : DoacaoBASE
    {
        public int IdDoacao { get; set; }
        public Usuario Usuario { get; set; }
        public int DataCadastro { get; set; }
    }
}