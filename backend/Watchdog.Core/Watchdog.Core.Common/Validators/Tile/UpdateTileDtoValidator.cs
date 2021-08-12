using FluentValidation;
using Watchdog.Core.Common.DTO.Tile;

namespace Watchdog.Core.Common.Validators.Tile
{
    public class UpdateTileDtoValidator : AbstractValidator<UpdateTileDto>
    {
        public UpdateTileDtoValidator()
        {
            RuleFor(dto => dto.Id)
                .NotEmpty()
                .GreaterThan(0);
            
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .Matches(@"^[a-zA-Z0-9-_. ]*$");
            
            RuleFor(dto => dto.Settings)
                .NotEmpty();
        }
    }
}