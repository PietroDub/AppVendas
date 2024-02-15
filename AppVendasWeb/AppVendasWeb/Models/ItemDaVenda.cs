namespace AppVendasWeb.Models
{
    public class ItemDaVenda
    {
        public Guid ItemDaVendaId { get; set; }
        public Guid ProudutoId { get; set; }
        public Produto? Prodto { get; set; }
        public Guid VendaId { get; set; }
        public Venda? Venda { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}


