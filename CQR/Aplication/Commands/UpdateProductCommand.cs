using MediatR;

namespace CQR.Aplication.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuantityPerUnit { get; set; }
        public string Description { get; set; }
        public decimal UnitePrice { get; set; }
    }
}
