using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRent.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Insert_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1️⃣ Вставляем пользователей
            string user1Id = Guid.NewGuid().ToString();
            string user2Id = Guid.NewGuid().ToString();

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount", "DisplayName" },
                values: new object[,]
                {
                    { user1Id, "user1", "USER1", "user1@example.com", "USER1@EXAMPLE.COM", true, "AQAAAAEAACcQAAAAEJw1A==", Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), null, false, false, false, 0, "User One" },
                    { user2Id, "user2", "USER2", "user2@example.com", "USER2@EXAMPLE.COM", true, "AQAAAAEAACcQAAAAEJw2B==", Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), null, false, false, false, 0, "User Two" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Model", "Year", "PricePerDay", "PhotoUrl", "Status" },
                values: new object[,]
                {
                   { 1L, "Toyota", "Camry", 2022, 50.00m, "https://bin.ua/uploads/posts/2023-11/1700063410_2.jpg", 0 },
                   { 2L, "BMW", "X5", 2021, 120.00m, "https://stimg.cardekho.com/images/carexteriorimages/930x620/BMW/X5-2023/10452/1688992642182/front-left-side-47.jpg?impolicy=resize&imwidth=420", 0 },
                   { 3L, "Mercedes", "E-Class", 2023, 150.00m, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSvKP8ZSPRO6SdJYMb09iY7qQ3Lgz7G8MMXWA&s", 0 }
                });

            migrationBuilder.InsertData(
               table: "Bookings",
               columns: new[] { "Id", "StartDate", "EndDate", "Status", "CarId", "UserId" },
               values: new object[,]
               {
               { 1L, DateTime.SpecifyKind(new DateTime(2024, 7, 1), DateTimeKind.Utc),
                  DateTime.SpecifyKind(new DateTime(2024, 7, 5), DateTimeKind.Utc), 0, 1L,  user1Id},

               { 2L, DateTime.SpecifyKind(new DateTime(2024, 7, 10), DateTimeKind.Utc),
                  DateTime.SpecifyKind(new DateTime(2024, 7, 15), DateTimeKind.Utc), 0, 2L, user2Id }
               });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "Method", "Date", "BookingId" },
                values: new object[,]
                {
                { 1L, 250.00m, 0, DateTime.SpecifyKind(new DateTime(2024, 7, 1), DateTimeKind.Utc), 1L },
                   { 2L, 600.00m, 1, DateTime.SpecifyKind(new DateTime(2024, 7, 10), DateTimeKind.Utc), 2L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Payments");
            migrationBuilder.Sql("DELETE FROM Bookings");
            migrationBuilder.Sql("DELETE FROM Cars");
            migrationBuilder.Sql("DELETE FROM Users");
        }
    }
}
