// public TimeSpan(int hours, int minutes, int seconds);
// public TimeSpan(int days, int hours, int minutes, int seconds);
// public TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds);
// public TimeSpan(long ticks);  // Each tick = 100 ns
TimeSpan interval = new TimeSpan(1, 2, 30, 45); // 1 day, 2 hours, 30 minutes, 45 seconds
Console.WriteLine(interval); // 02:30:00
Console.WriteLine(TimeSpan.FromHours(2.5)); // 02:30:00
Console.WriteLine(TimeSpan.FromMinutes(90)); // 01:30:00

Console.WriteLine();
DateTime start = new DateTime(2023, 12, 3, 0, 0, 0);
DateTime end = new DateTime(2025, 3, 4, 0, 0, 0);
TimeSpan duration = end - start;
Console.WriteLine(start);
Console.WriteLine(end);
Console.WriteLine(duration.TotalDays); // 1.0

Console.WriteLine();
TimeSpan span1 = TimeSpan.FromHours(2);
TimeSpan span2 = TimeSpan.FromMinutes(30);
TimeSpan result = span1 - span2;  // 02:30:00
Console.WriteLine(result);
TimeSpan nearlyTenDays = TimeSpan.FromDays(10) - TimeSpan.FromSeconds(3600);
Console.WriteLine(nearlyTenDays.Days);  // 9
Console.WriteLine(nearlyTenDays.Hours); // 23
Console.WriteLine(nearlyTenDays.Minutes); // 59
Console.WriteLine(nearlyTenDays.TotalHours);  // 239.999

Console.WriteLine();
DateTime dt1 = new DateTime(2021, 12, 15, 8, 30, 0, DateTimeKind.Unspecified);
DateTimeOffset dt2 = new DateTimeOffset(2021, 12, 15, 8, 30, 0, TimeSpan.FromHours(-5));
Console.WriteLine(dt1);  // 12/15/2021 8:30:00 AM
Console.WriteLine(dt2);  // 12/15/2021 8:30:00 AM -05:00

Console.WriteLine();
DateTime dt3 = new DateTime(2021, 1, 1); // January 1, 2021, at midnight
DateTime dt4 = new DateTime(2021, 1, 1, 12, 30, 0); // January 1, 2021, at 12:30 PM
DateTime dt5 = dt3.AddDays(10); // Adds 10 days
Console.WriteLine(dt3); // 1/11/2021 12:00:00 AM\
Console.WriteLine(dt5);
DateTime now = DateTime.Now;
Console.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss")); // 2021-12-15 08:30:00

Console.WriteLine();
DateTimeOffset dto = new DateTimeOffset(2021, 12, 15, 8, 30, 0, TimeSpan.FromHours(-5));
Console.WriteLine(dto);  // 12/15/2021 8:30:00 AM -05:00

Console.WriteLine();
Console.WriteLine(DateTime.Now);         // 12/15/2021 8:30:00 AM
Console.WriteLine(DateTimeOffset.Now);   // 12/15/2021 8:30:00 AM -05:00

Console.WriteLine();
DateOnly date = new DateOnly(2021, 12, 15);
Console.WriteLine(date);  // 12/15/2021
TimeOnly time = new TimeOnly(8, 30);
Console.WriteLine(time);  // 08:30:00