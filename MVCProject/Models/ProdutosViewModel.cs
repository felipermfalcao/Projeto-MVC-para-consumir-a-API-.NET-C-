namespace MVCProject.Models
{
    public class ProdutosViewModel
    {
        public int Id { get; set; } = 0;
        public string Nome { get; set; } = string.Empty;
        public Decimal Valor { get; set; } = 0;
        public int Quantidade { get; set; } = 0;
    }
}
