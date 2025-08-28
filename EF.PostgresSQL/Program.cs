using EF.PostgresSQL;
using EF.PostgresSQL.Entity;
using Microsoft.EntityFrameworkCore;

// My backend server is at timezone UTC+7, and my PostgresSQL server is at UTC-4
// Default is timestamp without timezone.
//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

using var dbContext = new PostgresDbContext();

//List<Record> newRecords = [];

//for (int i = 0; i < 10; i++)
//{
//    var record = new Record
//    {
//        Id = Guid.NewGuid().ToString(), 
//        CreatedDate = DateTime.Now.AddMinutes(i),
//        CreatedDateTz = DateTime.UtcNow.AddMinutes(i),
//    };

//    newRecords.Add(record);
//}

//await dbContext.Records.AddRangeAsync(newRecords);
//await dbContext.SaveChangesAsync();

const int MINS = 30;
//var allRecords = await dbContext.Records.ToListAsync();
// There are totally 12 records in table Record. All of them were created more than MINS at the time I run this app 2025-08-23 11:00:44
//id                                    created_date               created_date_tz
//2a91b68f-24f2-4f83-a3e3-14e875f6c784	2025-08-22 23:39:09.6701	2025-08-22 12:39:09.688524-04
//3e3e31e5-f974-4dcc-aa53-15a2844fdbad	2025-08-23 10:07:50.769932	2025-08-22 23:07:50.77298-04
//230e1ed9-e3bb-4e85-a183-bb1bcb86fedc	2025-08-23 10:11:29.288314	2025-08-22 23:11:29.289921-04
//7843a45f-2dac-4650-80cc-18eac408c040	2025-08-23 10:12:01.409556	2025-08-22 23:12:01.411125-04
//0a50dab0-2a90-4c88-8e19-94cea1e2674e	2025-08-23 10:13:22.515008	2025-08-22 23:13:22.516546-04
//205963b4-625d-4c65-8241-1a84941694bc	2025-08-23 10:15:50.206427	2025-08-22 23:15:50.207895-04
//9c05bcb5-406e-4f83-aa5c-8de5a102f90d	2025-08-23 10:31:27.154734	2025-08-22 16:31:27.155983-04
//de1b1dd8-4c19-40e2-9fb7-f040ad9b9a09	2025-08-23 10:34:22.416328	2025-08-22 16:34:22.417575-04
//d3b5353f-2699-463d-8d37-ed30430d8305	2025-08-23 10:37:48.144316	2025-08-22 23:37:48.145577-04
//63e3a213-3e88-4433-b2d9-58fa4d82bbfd	2025-08-23 10:46:13.287792	2025-08-22 16:46:13.289486-04
//898dcfe3-a6bd-441d-b4d2-a19d8a3c1d47	2025-08-23 10:49:10.698488	2025-08-22 16:49:10.700023-04
//b6075468-1165-48f6-802b-727bcb7c7f78	2025-08-23 10:55:44.325222	2025-08-22 16:55:44.327164-04
var query = dbContext.Records.Where(r => (DateTime.Now - r.CreatedDate).TotalMinutes > MINS);
Console.WriteLine(query.ToQueryString());
//SELECT r.id, r.created_date, r.created_date_tz
//FROM record AS r
//WHERE date_part('epoch', now() - r.created_date) / 60.0 > 5.0
// I executed this generated sql query in my database, it returned only 1 record
List<Record> records = await query.ToListAsync(); // But this line returned 12 records.

//var querytz = dbContext.Records.Where(r => (DateTime.UtcNow - r.CreatedDateTz).TotalMinutes > MINS);
//Console.WriteLine(querytz.ToQueryString());
//var recordtzs = await querytz.ToListAsync();

//var a = (DateTime.UtcNow - DateTime.Now).TotalMinutes;
//var b = (DateTime.UtcNow.AddHours(7) - DateTime.Now).TotalMinutes;
//var c = (DateTime.UtcNow.ToLocalTime() - DateTime.Now).TotalMinutes;

Console.WriteLine("Done.");
Console.ReadLine();
