namespace OutcomeReport.QRService
{
    using System.Threading.Tasks;
    using OutcomeReports.Domain.ViewModels;

    public interface IQrScanningService
    {
        Task<LineViewModel> ScanAsync();
    }
}
