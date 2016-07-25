using System;
using Microsoft.Reporting.WebForms;

namespace NorthwindMvc5.Extensions
{
    public static class ReportingServices
    {
        public static Byte[] Export(this LocalReport localReport, String dataSetName, Object model, String reportType, out String mimeType, out String fileNameExtension, DeviceInfoParameters deviceInfoParameters)
        {
            localReport.DataSources.Add(new ReportDataSource(dataSetName, model));

            var encoding = String.Empty;

            var deviceInfo = deviceInfoParameters.ToString();

            var warnings = default(Warning[]);
            var streams = default(String[]);

            return localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
        }

        public static Byte[] Export(this LocalReport localReport, String dataSetName, Object model, String reportType, out String mimeType, out String fileNameExtension)
        {
            return Export(localReport, dataSetName, model, reportType, out mimeType, out fileNameExtension, new DeviceInfoParameters());
        }
    }
}
