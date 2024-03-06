using FluentValidation;
using PruebaTecnica.Models;

namespace PruebaTecnica.Validators
{
    public class ProductValidators : AbstractValidator<Product>
    {
        public ProductValidators()
        {
            RuleFor(p => p.Nombre).NotEmpty().WithMessage("El Nombre del producto es requerido.");
            RuleFor(p => p.Precio).NotEmpty().WithMessage("El Precio del producto es requerido.");
            RuleFor(p => p.Stock).NotEmpty().WithMessage("El Stock del producto es requerido.");
            

            RuleFor(p => p.Precio).GreaterThan(0).WithMessage("El precio del producto debe ser mayor que cero.");
            RuleFor(p => p.Stock).GreaterThanOrEqualTo(0).WithMessage("El stock del producto no puede ser negativo.");
            RuleFor(p => p.FechaRegistro).NotEmpty().WithMessage("La fecha de registro del producto es requerida.");
        }
    }
}
