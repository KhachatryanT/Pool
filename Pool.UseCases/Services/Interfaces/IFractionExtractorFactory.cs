using Pool.Entities.Enums;
using Pool.UseCases.Services.FractionExtractors;

namespace Pool.UseCases.Services.Interfaces;

public interface IFractionExtractorFactory
{
	IFractionExtractor CreateExtractor(FractionType fractionType);
}