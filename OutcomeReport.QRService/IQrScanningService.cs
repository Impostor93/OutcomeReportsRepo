namespace OutcomeReport.QRService
{
    using System.Threading.Tasks;

    public interface IQrScanningService
    {
        Task<string> ScanAsync();
    }
}
