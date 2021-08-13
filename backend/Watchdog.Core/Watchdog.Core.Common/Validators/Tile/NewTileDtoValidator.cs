using FluentValidation;
using Watchdog.Core.Common.DTO.Tile;
using Watchdog.Core.Common.Enums.Tiles;

namespace Watchdog.Core.Common.Validators.Tile
{

    public class NewTileDtoValidator : AbstractValidator<NewTileDto>
    {
        public NewTileDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .Matches(@"^[a-zA-Z0-9-_. ]*$");

            RuleFor(dto => dto.DashboardId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(dto => dto.CreatedBy)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(dto => dto.Settings)
                .NotEmpty();

            RuleFor(dto => dto.Type)
                .IsInEnum();
            
            RuleFor(dto => dto.Category)
                .IsInEnum();
        }
    }
}