using app.web.core;

namespace app.web.application.catalogbrowsing
{
    public interface IGetAReportUsingARequest<ReportModel>
    {
        ReportModel get_report(IProvideDetailsAboutARequest request);
    }
}