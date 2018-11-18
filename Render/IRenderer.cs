using fraction_calculator_dotnet.Entity;

namespace fraction_calculator_dotnet.Render
{
    public interface IRenderer
    {
        Fraction Render(Fraction fraction);
    }
}
