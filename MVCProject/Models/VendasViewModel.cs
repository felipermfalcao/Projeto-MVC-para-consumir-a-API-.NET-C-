using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class VendasViewModel
    {
        public int Id { get; set; } = 0;
        public Decimal Valor { get; set; } = 0;

        public DateTime Data { get; set; }
        public int VendedorId { get; set; } = 0;
    }
}
