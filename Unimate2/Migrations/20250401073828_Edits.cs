using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniMate2.Migrations
{
    /// <inheritdoc />
    public partial class Edits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserImages_AspNetUsers_UserId",
                table: "UserImages");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "126b2f83-82af-4a08-bd15-8d0e9551000d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68a477ff-4c53-4de1-acb4-803951c0e14d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b82260db-dcd3-4805-a099-3ce685920dc3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d598f1c3-e051-46dd-8443-bc8b34699907");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e266d85e-8640-45e3-960f-b2682250d3df");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f55d784b-a001-4d6b-9691-6869f3a484b1");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("1c659281-80a5-4790-b898-a5a0f16c79e9"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("bf74ba1f-d5cf-44e3-9e72-d3ac718a41cc"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("d75f24f3-3eef-43bf-bb9f-f3b1adfac114"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Faculty", "FirstName", "Gender", "IsDrinking", "IsSmoking", "LastName", "LockoutEnabled", "LockoutEnd", "LookingFor", "NormalizedEmail", "NormalizedUserName", "Orientation", "PasswordHash", "PersonalityType", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "University", "UserId", "UserName", "ZodiakSign" },
                values: new object[,]
                {
                    { "2cbf5993-2253-4227-b91b-2f035281375f", 0, "Avid cyclist and technology enthusiast.", new DateTime(1990, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "220af7bd-fc1b-45fa-af8b-bb11eb603265", "david.miller@example.com", false, "Mechanical", "David", 0, 0, 1, "Miller", false, null, 2, "DAVID.MILLER@EXAMPLE.COM", "DAVID.MILLER@EXAMPLE.COM", 1, "AQAAAAIAAYagAAAAEDjMhzgnBF15tSlcVO4Rskrn3zdL5sVsY0+vQOIAuAvvUPIuaV+i+Kt9t5drgf+SzQ==", null, null, false, "84bd3147-cb5d-4e9f-993f-0bb991517bc7", false, "Engineering Institute", null, "david.miller@example.com", null },
                    { "37668a89-b38c-4217-ab76-fd55df18d17f", 0, "Passionate about graphic design and photography.", new DateTime(1992, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "edd104cd-37d2-4d6f-b39b-eb9f5b8c2778", "carol.davis@example.com", false, "Design", "Carol", 0, 1, 2, "Davis", false, null, 3, "CAROL.DAVIS@EXAMPLE.COM", "CAROL.DAVIS@EXAMPLE.COM", 3, "AQAAAAIAAYagAAAAEO7aNrU/vaE2RMKaH1XdAb8NEfXqWTsFGqOYTdrQ85DjHT6Yl+pAA7oEuaefzpLJLQ==", null, null, false, "010708a7-26b1-4dbd-89d5-ac49affff836", false, "Arts College", null, "carol.davis@example.com", null },
                    { "3cdac76f-c5ad-443b-b266-7b27afd47796", 0, "", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6dd00fdc-2645-42ac-ba64-322b227f43bd", null, false, "Faculty2", "FirstName2", 2, 0, 1, "LastName2", false, null, 0, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEMoviDU4aT7tK2xugvvNEMXqKM+B9EJtV7P/dSWRo3T/y7gdH70kx6UVpS1kIYfxLA==", null, null, false, "1dd8615c-13f8-45e0-a2bf-628f738dd0eb", false, "University1", null, null, null },
                    { "6c278009-5a16-4bf2-a242-7c9d5edf42f2", 0, "Loves hiking and outdoor adventures.", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "9ca63fc0-8147-4d5c-aaaf-b7d2d1223a8a", "alice.johnson@example.com", false, "Engineering", "Alice", 1, 2, 1, "Johnson", false, null, 1, "ALICE.JOHNSON@EXAMPLE.COM", "ALICE.JOHNSON@EXAMPLE.COM", 2, "AQAAAAIAAYagAAAAEJQXeeqNfrGNkLGM3hzvXENFRTILkVo279Y7vTVPxkBxAcd8QPxoK6yuvUwqK5lRRg==", null, null, false, "d96a039b-fd7d-4e49-a415-e46413ae7c60", false, "Tech University", null, "alice.johnson@example.com", null },
                    { "a95c15fd-bf13-420d-9a94-b566feaa0c6e", 0, "Bio2", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d4e63810-6915-4818-a09c-fd40252213d1", "user2@example.com", false, "Faculty2", "FirstName2", 0, 0, 1, "LastName2", false, null, 0, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEP2RQADFPL3SzEKsxjEjkHYRLkudu3NyBGJs98jyO4czecsGkkUdBBlx58Vl8Wa7qA==", null, null, false, "7a238b58-9973-4526-9d17-ee4da07daae1", false, "University2", null, "user2@example.com", null },
                    { "ba0424d4-0b98-478c-8414-b996cb52d11d", 0, "Enjoys cooking and traveling.", new DateTime(1988, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "e48f4aad-75b5-4bff-92e9-e995159b470b", "bob.smith@example.com", false, "Business", "Bob", 0, 0, 0, "Smith", false, null, 0, "BOB.SMITH@EXAMPLE.COM", "BOB.SMITH@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEITWPXbXtDDQY4vki0TTu7VbdDpx4LHhpmcfWk/rCgTAxZ4b7+iCUHuWRwWJDlPySA==", null, null, false, "dd7740af-28f3-456f-9a42-978aa4f69294", false, "State University", null, "bob.smith@example.com", null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("4ef5ca2d-ab96-46a2-a358-19622ba4fd99"), "Workshop on emerging technologies.", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Institute", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Workshop" },
                    { new Guid("5c4dc5fd-1e55-454a-9559-d5ea9067a625"), "Annual technology conference.", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Convention Center", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Conference" },
                    { new Guid("88628905-e52f-4a4c-a9a9-10cf4989a6aa"), "A meetup for community members.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Park", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Community Meetup" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserImages_AspNetUsers_UserId",
                table: "UserImages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserImages_AspNetUsers_UserId",
                table: "UserImages");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2cbf5993-2253-4227-b91b-2f035281375f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "37668a89-b38c-4217-ab76-fd55df18d17f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cdac76f-c5ad-443b-b266-7b27afd47796");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c278009-5a16-4bf2-a242-7c9d5edf42f2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a95c15fd-bf13-420d-9a94-b566feaa0c6e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba0424d4-0b98-478c-8414-b996cb52d11d");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("4ef5ca2d-ab96-46a2-a358-19622ba4fd99"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("5c4dc5fd-1e55-454a-9559-d5ea9067a625"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("88628905-e52f-4a4c-a9a9-10cf4989a6aa"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Faculty", "FirstName", "Gender", "IsDrinking", "IsSmoking", "LastName", "LockoutEnabled", "LockoutEnd", "LookingFor", "NormalizedEmail", "NormalizedUserName", "Orientation", "PasswordHash", "PersonalityType", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "University", "UserId", "UserName", "ZodiakSign" },
                values: new object[,]
                {
                    { "126b2f83-82af-4a08-bd15-8d0e9551000d", 0, "Loves hiking and outdoor adventures.", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "d9163b4d-749b-4840-86de-6bba77133cf2", "alice.johnson@example.com", false, "Engineering", "Alice", 1, 2, 1, "Johnson", false, null, 1, "ALICE.JOHNSON@EXAMPLE.COM", "ALICE.JOHNSON@EXAMPLE.COM", 2, "AQAAAAIAAYagAAAAEH4lvSo99OOEPsK2ez5Xaospl866mgIg7zQD6TuxBYobCvtlC4czCWmSAxRpIjo+AQ==", null, null, false, "0b91ddb6-827d-4953-85c1-3baa481a85cf", false, "Tech University", null, "alice.johnson@example.com", null },
                    { "68a477ff-4c53-4de1-acb4-803951c0e14d", 0, "Enjoys cooking and traveling.", new DateTime(1988, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "1d22c4eb-3d35-44da-bd95-92a226b83109", "bob.smith@example.com", false, "Business", "Bob", 0, 0, 0, "Smith", false, null, 0, "BOB.SMITH@EXAMPLE.COM", "BOB.SMITH@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAELhJBAQMa2jGjPpubC0pKYLDskG8CKRsoAMUltjmk0NpBg9EzmZDYZWeyxIzAZ2FLQ==", null, null, false, "d568cdbb-4808-4db4-aa50-ece6cb57a495", false, "State University", null, "bob.smith@example.com", null },
                    { "b82260db-dcd3-4805-a099-3ce685920dc3", 0, "Bio2", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7c567244-5cdb-4fa6-bdcd-d02ff4c8ad48", "user2@example.com", false, "Faculty2", "FirstName2", 0, 0, 1, "LastName2", false, null, 0, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEF1bfVrdoNfqX7Upm5PWkRN11/kJg03S+bBHPQewWpTFtgTWf20teKFSENSppjbNlQ==", null, null, false, "878e0ded-e505-44c5-8574-a0677b866dd2", false, "University2", null, "user2@example.com", null },
                    { "d598f1c3-e051-46dd-8443-bc8b34699907", 0, "Avid cyclist and technology enthusiast.", new DateTime(1990, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "b2ef04b0-24e0-4512-9343-bf0d7b581a63", "david.miller@example.com", false, "Mechanical", "David", 0, 0, 1, "Miller", false, null, 2, "DAVID.MILLER@EXAMPLE.COM", "DAVID.MILLER@EXAMPLE.COM", 1, "AQAAAAIAAYagAAAAEM63abZj6l+4+uuNMRcE7zahB3GvYZBvqPeRLTSis10ezWhZFJDBbNJzP6hEU2C9TA==", null, null, false, "a1f90b9a-0e1b-4500-b921-0917c021df6e", false, "Engineering Institute", null, "david.miller@example.com", null },
                    { "e266d85e-8640-45e3-960f-b2682250d3df", 0, "Passionate about graphic design and photography.", new DateTime(1992, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "4b4db4bf-94b4-45ac-965f-eb914f0644a9", "carol.davis@example.com", false, "Design", "Carol", 0, 1, 2, "Davis", false, null, 3, "CAROL.DAVIS@EXAMPLE.COM", "CAROL.DAVIS@EXAMPLE.COM", 3, "AQAAAAIAAYagAAAAEK2audBko0/FFvdvF+R7n10jkVpwDEYh7L2Q83BgEdtoqfzjmegudK7h+JOOZsYntA==", null, null, false, "fe89c641-ce89-4c5a-a3b9-ff10ea4ec9ed", false, "Arts College", null, "carol.davis@example.com", null },
                    { "f55d784b-a001-4d6b-9691-6869f3a484b1", 0, "", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0f1f51ee-de07-47bb-ab7d-ae6446d5a7bc", null, false, "Faculty2", "FirstName2", 2, 0, 1, "LastName2", false, null, 0, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEMQH2+1EKMaU/C+DZa6gH69NdjGizJ+eoBOPjOz2dZqzlOuqL16rjbxlE6P6InXQzQ==", null, null, false, "4a16ad80-148d-49fa-8a94-9cdd5f7562da", false, "University1", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("1c659281-80a5-4790-b898-a5a0f16c79e9"), "A meetup for community members.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Park", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Community Meetup" },
                    { new Guid("bf74ba1f-d5cf-44e3-9e72-d3ac718a41cc"), "Workshop on emerging technologies.", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Institute", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Workshop" },
                    { new Guid("d75f24f3-3eef-43bf-bb9f-f3b1adfac114"), "Annual technology conference.", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Convention Center", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Conference" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserImages_AspNetUsers_UserId",
                table: "UserImages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
