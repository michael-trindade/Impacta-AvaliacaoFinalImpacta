namespace ControleFuncionario.Models
{
    public class ValeRefeicao
    {
        public int ValeRefeicaoId { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int Qtde { get; set; }
        public double Valor { get; set; }        
    }
}
