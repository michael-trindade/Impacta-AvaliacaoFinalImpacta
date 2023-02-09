namespace ControleFuncionario.Models
{
    public class Empresa
    {
        public int EmpresaId { get; set; }
        public string Cnpj { get; set; }
        public string NomeEmpresa { get; set; }

        public ICollection<ValeRefeicao> ValeRefeicao { get; set; }
        public ICollection<ValeTransporte> ValeTransporte { get; set; }
    }
}
