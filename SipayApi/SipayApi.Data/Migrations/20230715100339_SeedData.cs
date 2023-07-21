using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SipayApi.Data.Migrations
{
    public partial class SeedData : Migration
    {
    
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO dbo.\"Customer\"(\r\n\t\"FirstName\", \"LastName\", \"CustomerNumber\", \"Address\", \"IsActive\", \"InsertDate\", \"InsertUser\")\r\n\tVALUES ('Denny 1', 'Sellen', 100001, 'Istanbul', true, '2023-02-02', 'SystemAdmin');\r\n    \r\n    ");
            migrationBuilder.Sql("INSERT INTO dbo.\"Customer\"(\r\n\t\"FirstName\", \"LastName\", \"CustomerNumber\", \"Address\", \"IsActive\", \"InsertDate\", \"InsertUser\")\r\n\tVALUES ('Denny 2', 'Sellen', 100002, 'Istanbul', true, '2023-02-02', 'SystemAdmin');\r\n    \r\n    ");
            migrationBuilder.Sql("INSERT INTO dbo.\"Customer\"(\r\n\t\"FirstName\", \"LastName\", \"CustomerNumber\", \"Address\", \"IsActive\", \"InsertDate\", \"InsertUser\")\r\n\tVALUES ('Denny 3', 'Sellen', 100003, 'Istanbul', true, '2023-02-02', 'SystemAdmin');\r\n    \r\n    ");
            migrationBuilder.Sql("INSERT INTO dbo.\"Customer\"(\r\n\t\"FirstName\", \"LastName\", \"CustomerNumber\", \"Address\", \"IsActive\", \"InsertDate\", \"InsertUser\")\r\n\tVALUES ('Denny 4', 'Sellen', 100004, 'Istanbul', true, '2023-02-02', 'SystemAdmin');\r\n    \r\n    ");
            migrationBuilder.Sql("INSERT INTO dbo.\"Customer\"(\r\n\t\"FirstName\", \"LastName\", \"CustomerNumber\", \"Address\", \"IsActive\", \"InsertDate\", \"InsertUser\")\r\n\tVALUES ('Denny 5', 'Sellen', 100005, 'Istanbul', true, '2023-02-02', 'SystemAdmin');\r\n    \r\n    ");
            migrationBuilder.Sql("INSERT INTO dbo.\"Customer\"(\r\n\t\"FirstName\", \"LastName\", \"CustomerNumber\", \"Address\", \"IsActive\", \"InsertDate\", \"InsertUser\")\r\n\tVALUES ('Denny 6', 'Sellen', 100006, 'Istanbul', true, '2023-02-02', 'SystemAdmin');\r\n    \r\n    ");

            migrationBuilder.Sql("INSERT INTO dbo.\"Account\"(\r\n\t\"CustomerNumber\", \"Balance\", \"Name\", \"OpenDate\", \"CurrencyCode\", \"AccountNumber\", \"IsActive\", \"InsertDate\", \"InsertUser\")\r\n\tVALUES (100001, 0, 'Denny 1', '2023-04-04', 'TRY', 500001, true, '2023-07-07', 'SystemAdmin');\r\n    \r\n    ");
            migrationBuilder.Sql("INSERT INTO dbo.\"Account\"(\r\n\t\"CustomerNumber\", \"Balance\", \"Name\", \"OpenDate\", \"CurrencyCode\", \"AccountNumber\", \"IsActive\", \"InsertDate\", \"InsertUser\")\r\n\tVALUES (100002, 0, 'Denny 2', '2023-04-04', 'TRY', 500002, true, '2023-07-07', 'SystemAdmin');\r\n    \r\n    ");
            migrationBuilder.Sql("INSERT INTO dbo.\"Account\"(\r\n\t\"CustomerNumber\", \"Balance\", \"Name\", \"OpenDate\", \"CurrencyCode\", \"AccountNumber\", \"IsActive\", \"InsertDate\", \"InsertUser\")\r\n\tVALUES (100003, 0, 'Denny 3', '2023-04-04', 'TRY', 500003, true, '2023-07-07', 'SystemAdmin');\r\n    \r\n    ");
            migrationBuilder.Sql("INSERT INTO dbo.\"Account\"(\r\n\t\"CustomerNumber\", \"Balance\", \"Name\", \"OpenDate\", \"CurrencyCode\", \"AccountNumber\", \"IsActive\", \"InsertDate\", \"InsertUser\")\r\n\tVALUES (100004, 0, 'Denny 4', '2023-04-04', 'TRY', 500004, true, '2023-07-07', 'SystemAdmin');\r\n    \r\n    ");
            migrationBuilder.Sql("INSERT INTO dbo.\"Account\"(\r\n\t\"CustomerNumber\", \"Balance\", \"Name\", \"OpenDate\", \"CurrencyCode\", \"AccountNumber\", \"IsActive\", \"InsertDate\", \"InsertUser\")\r\n\tVALUES (100005, 0, 'Denny 5', '2023-04-04', 'TRY', 500005, true, '2023-07-07', 'SystemAdmin');\r\n    \r\n    ");
            migrationBuilder.Sql("INSERT INTO dbo.\"Account\"(\r\n\t\"CustomerNumber\", \"Balance\", \"Name\", \"OpenDate\", \"CurrencyCode\", \"AccountNumber\", \"IsActive\", \"InsertDate\", \"InsertUser\")\r\n\tVALUES (100006, 0, 'Denny 6', '2023-04-04', 'TRY', 500006, true, '2023-07-07', 'SystemAdmin');\r\n    \r\n    ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
