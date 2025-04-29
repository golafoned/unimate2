using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniMate2.Migrations
{
    /// <inheritdoc />
    public partial class addAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c98621f-e043-4e4e-bffd-0d91e0090d6c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ba0c487-9ace-4102-ac21-f85790e68f45");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9192be78-7215-4056-b066-81b6f4ca9954");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b526283-cdfd-403d-987a-9c4863840496");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c78d924d-1ac6-4035-a0f0-c9b28748d3e4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ee5799e2-bd53-4ed9-ab64-2680f9e5d4b0");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("20d6aa2c-c561-4a0c-aa64-1665977e6a71"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("571cdb08-0e0b-4977-a557-cb56ee37da3b"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("9f125b0f-e2ee-44ca-a51b-dc2336c37244"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "896aa0ff-5969-451e-ba49-6c1a75623df8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Faculty", "FirstName", "Gender", "IsDrinking", "IsSmoking", "LastName", "LockoutEnabled", "LockoutEnd", "LookingFor", "NormalizedEmail", "NormalizedUserName", "Orientation", "PasswordHash", "PersonalityType", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "University", "UserId", "UserName", "ZodiakSign" },
                values: new object[,]
                {
                    { "34a23577-1451-4379-bcbe-7e7cdc867f5c", 0, "Bio5", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "4cea2dd1-336e-40a9-b2af-bbc123b40b5a", "user1@example.com", false, "Faculty2", "FirstName2", 2, 0, 1, "LastName2", false, null, 0, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEIs9y3Guj1kmJSJzbfHqheJGaFg38EHUw4ESRHLM6xhMdfQ/gtvbcbKGxjVDTwV41g==", null, null, false, "9b588cf2-7be6-4266-abbd-ba3093a7dc8d", false, "University1", null, "user1@example.com", null },
                    { "739c1a99-2559-44df-b737-346b40336fc2", 0, "Avid cyclist and technology enthusiast.", new DateTime(1990, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "4e5323a0-abc5-47c0-a5d5-fd47b095db95", "david.miller@example.com", false, "Mechanical", "David", 0, 0, 1, "Miller", false, null, 2, "DAVID.MILLER@EXAMPLE.COM", "DAVID.MILLER@EXAMPLE.COM", 1, "AQAAAAIAAYagAAAAEJ9DYQ3sKOewjDuVEBqXUhlw0rIZCyQyQG/eH7JPEn8Wb6yPs+DaHVG9/IOYoLCKlw==", null, null, false, "198403ae-5dc4-432a-8d63-bb855154d3bb", false, "Engineering Institute", null, "david.miller@example.com", null },
                    { "7f505ef5-8da2-4141-99a1-a0e3757ee080", 0, "Enjoys cooking and traveling.", new DateTime(1988, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), "f465f900-c733-4bdc-8cad-1599ba940c04", "bob.smith@example.com", false, "Business", "Bob", 0, 0, 0, "Smith", false, null, 0, "BOB.SMITH@EXAMPLE.COM", "BOB.SMITH@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEFTy0Sj5awkT89mwkIsaGPPVM2YOQf58flkUQ6Uq8O++qkIAX02j3gBrMH2Grb3vHg==", null, null, false, "e848a3c0-3c5d-4cf0-b850-56bbec8d4cd9", false, "State University", null, "bob.smith@example.com", null },
                    { "cea3b9d0-ee7b-4d54-802a-631f75fdf584", 0, "Bio2", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "6a2fd103-a2d3-4d37-9d82-c33de5a14a61", "user2@example.com", false, "Faculty2", "FirstName2", 0, 0, 1, "LastName2", false, null, 0, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEAANU7e53ipGP/4KggD9WksoB5U9QlkPSurvEeRu98NZlPuz+hXMyiLEXEBKhPV4pw==", null, null, false, "e28765af-51a3-4404-9d27-6908b5e7bade", false, "University2", null, "user2@example.com", null },
                    { "da88ed8e-610f-45e2-9bf4-2c8ffe6fd5b4", 0, "Passionate about graphic design and photography.", new DateTime(1992, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), "7359bfa6-758e-4b33-bf88-ce5ed0c5fe52", "carol.davis@example.com", false, "Design", "Carol", 0, 1, 2, "Davis", false, null, 3, "CAROL.DAVIS@EXAMPLE.COM", "CAROL.DAVIS@EXAMPLE.COM", 3, "AQAAAAIAAYagAAAAEATvegudjrRnGJVHHgjx3N/foL+UZYWsE3wScEcBxrWgeQIn9u4zG05pPn3mco8pYg==", null, null, false, "f3d23d23-048c-4b34-8724-09f90abcab80", false, "Arts College", null, "carol.davis@example.com", null },
                    { "ea424249-d2aa-4e94-916a-5c5d08cbcfcf", 0, "Loves hiking and outdoor adventures.", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), "a42780a1-80a0-4a53-931f-12c76df5a927", "alice.johnson@example.com", false, "Engineering", "Alice", 1, 2, 1, "Johnson", false, null, 1, "ALICE.JOHNSON@EXAMPLE.COM", "ALICE.JOHNSON@EXAMPLE.COM", 2, "AQAAAAIAAYagAAAAELn6codOPLjFs7SVazxwCWHoHViBs2YLyLhvDd2S09LMxMPBuOH3Jy9NOxVRSlcLkg==", null, null, false, "d3d4a7e4-987e-41b0-929d-1444b2645e98", false, "Tech University", null, "alice.johnson@example.com", null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("584ae5fb-7357-44cb-9d68-444a3de138fa"), "A meetup for community members.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), "City Park", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Community Meetup" },
                    { new Guid("74252ff3-c1d6-4b37-a22b-55f756715f43"), "Workshop on emerging technologies.", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Tech Institute", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Workshop" },
                    { new Guid("7f5af397-68a3-4e31-94d0-357870460758"), "Annual technology conference.", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Convention Center", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Tech Conference" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "34a23577-1451-4379-bcbe-7e7cdc867f5c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "34a23577-1451-4379-bcbe-7e7cdc867f5c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "739c1a99-2559-44df-b737-346b40336fc2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f505ef5-8da2-4141-99a1-a0e3757ee080");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cea3b9d0-ee7b-4d54-802a-631f75fdf584");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da88ed8e-610f-45e2-9bf4-2c8ffe6fd5b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea424249-d2aa-4e94-916a-5c5d08cbcfcf");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("584ae5fb-7357-44cb-9d68-444a3de138fa"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("74252ff3-c1d6-4b37-a22b-55f756715f43"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("7f5af397-68a3-4e31-94d0-357870460758"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34a23577-1451-4379-bcbe-7e7cdc867f5c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Faculty", "FirstName", "Gender", "IsDrinking", "IsSmoking", "LastName", "LockoutEnabled", "LockoutEnd", "LookingFor", "NormalizedEmail", "NormalizedUserName", "Orientation", "PasswordHash", "PersonalityType", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "University", "UserId", "UserName", "ZodiakSign" },
                values: new object[,]
                {
                    { "0c98621f-e043-4e4e-bffd-0d91e0090d6c", 0, "Passionate about graphic design and photography.", new DateTime(1992, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), "eb5cf0bf-600b-4328-a39d-b0b2e7712823", "carol.davis@example.com", false, "Design", "Carol", 0, 1, 2, "Davis", false, null, 3, "CAROL.DAVIS@EXAMPLE.COM", "CAROL.DAVIS@EXAMPLE.COM", 3, "AQAAAAIAAYagAAAAEG/iis5Tzn7YljTtYyhweAjFqs5OAU2s/XkKfyYhKimnEKtC06KzyhHxdbZkh5o/wQ==", null, null, false, "400fb1a6-cd60-4e2a-afa2-2645903053a9", false, "Arts College", null, "carol.davis@example.com", null },
                    { "2ba0c487-9ace-4102-ac21-f85790e68f45", 0, "Loves hiking and outdoor adventures.", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), "ae5eac14-e84f-4e51-8580-657a2de0d063", "alice.johnson@example.com", false, "Engineering", "Alice", 1, 2, 1, "Johnson", false, null, 1, "ALICE.JOHNSON@EXAMPLE.COM", "ALICE.JOHNSON@EXAMPLE.COM", 2, "AQAAAAIAAYagAAAAEKLdoWT8e8M6AX2ReUW+NbCA9zBurRhKwwHQxzRyRwx645YG2sXVaQceLXL7UcDmMQ==", null, null, false, "5e24108f-8204-4a08-8c09-9c23d994e497", false, "Tech University", null, "alice.johnson@example.com", null },
                    { "9192be78-7215-4056-b066-81b6f4ca9954", 0, "Enjoys cooking and traveling.", new DateTime(1988, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), "bc97cd1c-7c2f-4c18-b359-0b571711c1c8", "bob.smith@example.com", false, "Business", "Bob", 0, 0, 0, "Smith", false, null, 0, "BOB.SMITH@EXAMPLE.COM", "BOB.SMITH@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEDvdTrfEUDGmi4YjE+tHlGgSM3kDiTj1ikZlbsKfyEEgKGgpx6WSCy3o+e2J+7P5Tg==", null, null, false, "9b4316d6-b18b-4f45-a38f-01cd9f64a8cc", false, "State University", null, "bob.smith@example.com", null },
                    { "9b526283-cdfd-403d-987a-9c4863840496", 0, "Bio2", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "928cdf76-8433-4ae7-b984-9a29a5e9f994", "user2@example.com", false, "Faculty2", "FirstName2", 0, 0, 1, "LastName2", false, null, 0, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEPLZx42RMKMrwOfGW5cvNmw3FV2TfEfS+244pazERe39a5DN6WPbFvvPYyScJTL3HQ==", null, null, false, "f319ab67-ca79-4bcc-b343-83e240c93c25", false, "University2", null, "user2@example.com", null },
                    { "c78d924d-1ac6-4035-a0f0-c9b28748d3e4", 0, "Bio5", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "7cde079d-ed3e-48ee-b479-810be985eab9", "user1@example.com", false, "Faculty2", "FirstName2", 2, 0, 1, "LastName2", false, null, 0, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAELAe/kGqzsk9UmCh8JBBBv+I1YIK4IOF408383XmDYNcbIaL/tF4nBP7Va1thdzqPA==", null, null, false, "34b4e743-4ee0-46e0-9374-4f9ca5d52b0a", false, "University1", null, "user1@example.com", null },
                    { "ee5799e2-bd53-4ed9-ab64-2680f9e5d4b0", 0, "Avid cyclist and technology enthusiast.", new DateTime(1990, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "cf24f454-0d21-40dd-be25-8b469120f6c5", "david.miller@example.com", false, "Mechanical", "David", 0, 0, 1, "Miller", false, null, 2, "DAVID.MILLER@EXAMPLE.COM", "DAVID.MILLER@EXAMPLE.COM", 1, "AQAAAAIAAYagAAAAEO2UEatq4Lb3bCJGUJUegmzlEpyOWsAH1B5Y30QPUJbh8Vy/y4m2U0/i3UE8/gbNLQ==", null, null, false, "1423bb49-a6c1-4e7d-aa33-a5cb8113e744", false, "Engineering Institute", null, "david.miller@example.com", null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("20d6aa2c-c561-4a0c-aa64-1665977e6a71"), "Annual technology conference.", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Convention Center", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Tech Conference" },
                    { new Guid("571cdb08-0e0b-4977-a557-cb56ee37da3b"), "Workshop on emerging technologies.", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Tech Institute", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Workshop" },
                    { new Guid("9f125b0f-e2ee-44ca-a51b-dc2336c37244"), "A meetup for community members.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), "City Park", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Community Meetup" }
                });
        }
    }
}
