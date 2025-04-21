using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniMate2.Migrations
{
    /// <inheritdoc />
    public partial class addRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3643a046-459f-46a6-838d-738dc4cbf277", "8f692274-5fec-4b59-90e3-dedf6eeed96f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Faculty", "FirstName", "Gender", "IsDrinking", "IsSmoking", "LastName", "LockoutEnabled", "LockoutEnd", "LookingFor", "NormalizedEmail", "NormalizedUserName", "Orientation", "PasswordHash", "PersonalityType", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "University", "UserId", "UserName", "ZodiakSign" },
                values: new object[,]
                {
                    { "1233ba35-6311-48e1-9645-351abd152bdb", 0, "Enjoys cooking and traveling.", new DateTime(1988, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), "e6d9c540-8242-4dfc-97f7-e3918b77a9c8", "bob.smith@example.com", false, "Business", "Bob", 0, 0, 0, "Smith", false, null, 0, "BOB.SMITH@EXAMPLE.COM", "BOB.SMITH@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEFityDIiCTU/wNnilnY+F45x5YUcOayZOK9Nz0RlvGJh8NFsfdL1nsub0WJVuSHBSg==", null, null, false, "2139ba3a-9228-4921-9085-e6897e535cd6", false, "State University", null, "bob.smith@example.com", null },
                    { "35ff0e5f-3fd9-4977-98a0-4fbc716f8313", 0, "Passionate about graphic design and photography.", new DateTime(1992, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), "e3034297-1f72-45fe-a1e0-1ed28aaadcc8", "carol.davis@example.com", false, "Design", "Carol", 0, 1, 2, "Davis", false, null, 3, "CAROL.DAVIS@EXAMPLE.COM", "CAROL.DAVIS@EXAMPLE.COM", 3, "AQAAAAIAAYagAAAAECAOWAAPDtjGl/EXb7dqI0/mf35BnRRo2Am7asCJx29XNxRp/YkrW43K/8/wnRJCWQ==", null, null, false, "dbd28950-fe1c-46a4-86f2-98dedde86eff", false, "Arts College", null, "carol.davis@example.com", null },
                    { "3bbc34e7-c6c8-44f8-89c4-a3bf868ab947", 0, "Bio5", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "38c36644-5f05-4f35-a645-81ac9bab7b3e", "user1@example.com", false, "Faculty2", "FirstName2", 2, 0, 1, "LastName2", false, null, 0, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEKenkP84n8FLHhy39oFvyVzKjPd0RSI5aYABqyGavhVqSOWfGQxLW7CnnOGRMutclw==", null, null, false, "7a067d8c-bc4d-43d6-80c0-8fe20b3cc14f", false, "University1", null, "user1@example.com", null },
                    { "7c85ea6a-1ed9-4437-b735-8551cbae6034", 0, "Bio2", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "248f3cac-c84f-4b0f-a449-be5df5ea68b4", "user2@example.com", false, "Faculty2", "FirstName2", 0, 0, 1, "LastName2", false, null, 0, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEPPOyIRaLnKuXbXP0+GKASrE9LgecUjDKh8jXkczM29+J9Cioj1PtyZYiiHf4THMxg==", null, null, false, "49c00609-c87b-4891-8d9d-1899db1f98e3", false, "University2", null, "user2@example.com", null },
                    { "e53fb681-c573-4108-84bb-389803cce4b4", 0, "Avid cyclist and technology enthusiast.", new DateTime(1990, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "73a1f1b9-39ae-43b3-926e-39c8b4f3c24f", "david.miller@example.com", false, "Mechanical", "David", 0, 0, 1, "Miller", false, null, 2, "DAVID.MILLER@EXAMPLE.COM", "DAVID.MILLER@EXAMPLE.COM", 1, "AQAAAAIAAYagAAAAEP+xlJtHQEsYoN1vu8V8Jzvj7h75+AmA+r6YDsUuHCqiQLNNNvArviz7q10cHOP+sA==", null, null, false, "d6c15cc9-cf33-4b65-b058-74e207354a18", false, "Engineering Institute", null, "david.miller@example.com", null },
                    { "f4441b9d-7694-41d0-b0d7-501763861744", 0, "Loves hiking and outdoor adventures.", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), "7c18af45-5d5f-4a88-a49c-677dc3771689", "alice.johnson@example.com", false, "Engineering", "Alice", 1, 2, 1, "Johnson", false, null, 1, "ALICE.JOHNSON@EXAMPLE.COM", "ALICE.JOHNSON@EXAMPLE.COM", 2, "AQAAAAIAAYagAAAAEJN0BzpLbCIr+xIIEHongs9SZSRymfjYeGMMWtRyMXEP1R475SiucvLmx9ecz5OC+Q==", null, null, false, "dd26650b-cd51-442e-8ad5-013d14b7d77b", false, "Tech University", null, "alice.johnson@example.com", null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("74fcfc6e-9ba5-4369-88b8-106cf564d62e"), "Workshop on emerging technologies.", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Tech Institute", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Workshop" },
                    { new Guid("bc1ff33a-c3e2-431e-8987-5dab9101ff83"), "Annual technology conference.", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Convention Center", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Tech Conference" },
                    { new Guid("fc334df7-46ad-47ba-9f53-f854d7e122a5"), "A meetup for community members.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), "City Park", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Community Meetup" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3643a046-459f-46a6-838d-738dc4cbf277", "3bbc34e7-c6c8-44f8-89c4-a3bf868ab947" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3643a046-459f-46a6-838d-738dc4cbf277", "3bbc34e7-c6c8-44f8-89c4-a3bf868ab947" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1233ba35-6311-48e1-9645-351abd152bdb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35ff0e5f-3fd9-4977-98a0-4fbc716f8313");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c85ea6a-1ed9-4437-b735-8551cbae6034");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e53fb681-c573-4108-84bb-389803cce4b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f4441b9d-7694-41d0-b0d7-501763861744");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("74fcfc6e-9ba5-4369-88b8-106cf564d62e"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("bc1ff33a-c3e2-431e-8987-5dab9101ff83"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("fc334df7-46ad-47ba-9f53-f854d7e122a5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3643a046-459f-46a6-838d-738dc4cbf277");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3bbc34e7-c6c8-44f8-89c4-a3bf868ab947");

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
    }
}
