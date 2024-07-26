namespace Reminder;

public class ReminderOptions
{
    public required BrokerOptions BrokerOptions { get; set; }

    public required MongoDbSetting MongoDbSettings { get; set; }

}
public sealed class BrokerOptions
{
    public const string SectionName = "BrokerOptions";

    public required string Host { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class MongoDbSetting
{
    public string Host { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;
}
