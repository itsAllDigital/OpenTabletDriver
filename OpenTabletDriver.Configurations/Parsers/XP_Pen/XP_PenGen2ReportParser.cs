using OpenTabletDriver.Tablet;

namespace OpenTabletDriver.Configurations.Parsers.XP_Pen
{
    public class XP_PenGen2ReportParser : IReportParser<IDeviceReport>
    {
        public IDeviceReport Parse(byte[] report)
        {
            if (report[1] == 0xC0)
                return new OutOfRangeReport(report);
            if ((report[1] & 0xF0) == 0xA0)
                return new XP_PenTabletGen2Report(report);
            // Detect XP-Pen Artist 15.6 Pro (2nd Gen) aux buttons
            if (report[0] == 0x02 && report[1] == 0xF0)
                return new XP_PenAuxReport(report);
            return new DeviceReport(report);
        }
    }
}
