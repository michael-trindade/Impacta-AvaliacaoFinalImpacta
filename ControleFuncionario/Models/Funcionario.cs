namespace ControleFuncionario.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }

        public int LotacaoId { get; set; }
        public Lotacao Lotacao { get; set; }

        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        public ICollection<ValeRefeicao> ValeRefeicao { get; set; }
        public ICollection<ValeTransporte> ValeTransporte { get; set; }
        public ICollection<Frequencia> Frequencia { get; set; }
    }
}
