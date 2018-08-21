namespace WebThunder.t2.DataModels
{
    public interface ICalendar
    {
        int calendarID { get; set; }
        string displayName { get; set; }
        short? timeZoneCode { get; set; }
        bool? allowTimeZoneOverrides { get; set; }
    }
}