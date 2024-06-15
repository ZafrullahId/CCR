using CCR.Models;
using IronXL;

namespace CCR.Services
{
    public class ComprehensiveServices : IComprehensiveServices
    {
        public IEnumerable<ComprehensiveView> ExtractComprehensive(IFormFile file)
        {
            WorkBook workBook = WorkBook.Load(file.OpenReadStream());
            WorkSheet workSheet = workBook.DefaultWorkSheet;
            var comps = new List<ComprehensiveView>();
            for (int i = 12; i < workSheet.RowCount; i++)
            {
                Cell cellB = workSheet[$"B{i}"].First();
                Cell cellN = workSheet[$"N{i}"].First();
                if(string.IsNullOrEmpty(cellB.StringValue))
                    break;
                comps.Add(new ComprehensiveView
                {
                    SettlementNarration = cellB.StringValue,
                    Amount = cellN.DecimalValue,
                });
            }
            return comps;
        }
    }
}
