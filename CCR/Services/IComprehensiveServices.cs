using CCR.Models;

namespace CCR.Services
{
    public interface IComprehensiveServices
    {
        IEnumerable<ComprehensiveView> ExtractComprehensive(IFormFile file);
    }
}