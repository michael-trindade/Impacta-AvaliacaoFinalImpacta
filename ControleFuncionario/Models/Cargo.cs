namespace ControleFuncionario.Models
{
    public class Cargo
    {
        public int CargoId { get; set; }

        public string CargoDescricao { get; set; }

        public double Salario { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
