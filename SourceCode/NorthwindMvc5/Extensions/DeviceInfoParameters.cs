using System;
using System.Text;

namespace NorthwindMvc5.Extensions
{
    public class DeviceInfoParameters
    {
        public DeviceInfoParameters()
        {
            PageWidth = "14in";
        }

        public String ReportType { get; set; }

        public String PageWidth { get; set; }

        public String PageHeight { get; set; }

        public override String ToString()
        {
            var output = new StringBuilder();

            output.AppendLine("<DeviceInfo>");

            output.AppendFormat("<OutputFormat>{0}</OutputFormat>", ReportType);
            output.AppendLine();
            
            output.AppendFormat("<PageWidth>{0}</PageWidth>", PageWidth);
            output.AppendLine();
            
            output.AppendFormat("<PageHeight>{0}</PageHeight>", PageHeight);
            output.AppendLine();

            output.AppendLine("<MarginTop>0.5in</MarginTop>");
            output.AppendLine("<MarginLeft>1in</MarginLeft>");
            output.AppendLine("<MarginRight>1in</MarginRight>");
            output.AppendLine("<MarginBottom>0.5in</MarginBottom>");

            output.AppendLine("</DeviceInfo>");

            return output.ToString();
        }
    }
}
