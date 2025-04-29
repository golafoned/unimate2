using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniMate2.Migrations
{
    /// <inheritdoc />
    public partial class AddIsShadowbannedToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsShadowbanned",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e0489ec7-4adb-4b22-b50a-3bc629ec8846", "55abcbbc-443d-409b-96a0-1b84910294f5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Faculty", "FirstName", "Gender", "IsDrinking", "IsShadowbanned", "IsSmoking", "LastName", "LockoutEnabled", "LockoutEnd", "LookingFor", "NormalizedEmail", "NormalizedUserName", "Orientation", "PasswordHash", "PersonalityType", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "University", "UserId", "UserName", "ZodiakSign" },
                values: new object[,]
                {
                    { "04f63598-5718-41e4-843f-d4be70f3e194", 0, "Passionate about graphic design and photography.", new DateTime(1992, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), "d87d55a7-5dda-4775-b309-573f558540e4", "carol.davis@example.com", false, "Design", "Carol", 0, 1, false, 2, "Davis", false, null, 3, "CAROL.DAVIS@EXAMPLE.COM", "CAROL.DAVIS@EXAMPLE.COM", 3, "AQAAAAIAAYagAAAAEIxiqJMjyEwUnDMGRkKxVf+k+lrqZ9lUhK+TQmochXMI1wRWUGvw2m/yYzzh1PqE+w==", null, null, false, "a4023b00-3786-4330-a47b-9f1966b9c18e", false, "Arts College", null, "carol.davis@example.com", null },
                    { "0f0e0049-831f-4aa2-b2bf-90c210cfe42c", 0, "Bio5", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "167d90a5-71b1-4e9e-87ad-019d9b7ef0dd", "user1@example.com", false, "Faculty2", "FirstName2", 2, 0, false, 1, "LastName2", false, null, 0, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEPKRwWYDQVCl7sQwKxmv83huGfpkyiuTAVV+u649xxiIdQAixXqw40lI0/VroZ0/Mg==", null, null, false, "1e1b5aac-7ea4-4792-b195-f6cb43679e79", false, "University1", null, "user1@example.com", null },
                    { "2e6882ac-baee-40e6-8711-808330b91e1d", 0, "Loves hiking and outdoor adventures.", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), "d367bcbd-5bb9-4a72-9f89-7de495debe95", "alice.johnson@example.com", false, "Engineering", "Alice", 1, 2, false, 1, "Johnson", false, null, 1, "ALICE.JOHNSON@EXAMPLE.COM", "ALICE.JOHNSON@EXAMPLE.COM", 2, "AQAAAAIAAYagAAAAENQwHH3EGjfIxui77klKtZzwHoUeGQAT1ke/lhmDyo8BYGVzPJRw/ElbMq3feFGJ6w==", null, null, false, "af903b98-03db-4914-84e7-966bf86cacc5", false, "Tech University", null, "alice.johnson@example.com", null },
                    { "ad45938c-188c-4450-8e7e-b2abb4877746", 0, "Bio2", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "f242a97d-4a7d-4a26-aeeb-f2f92a715e02", "user2@example.com", false, "Faculty2", "FirstName2", 0, 0, false, 1, "LastName2", false, null, 0, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEO0NLtnQH3SmqnqflOOG/cXgzSh1VPR4yO5l5TqeZWAs10YzDAtwY4oYj9bNzthbqA==", null, null, false, "41614a11-7cdb-484a-8f6a-8f311076d9e7", false, "University2", null, "user2@example.com", null },
                    { "de76f82c-6176-4350-8ffb-90f30d9eec4d", 0, "Enjoys cooking and traveling.", new DateTime(1988, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), "295ec6be-2ee4-45e1-863b-46f5423cd9a9", "bob.smith@example.com", false, "Business", "Bob", 0, 0, false, 0, "Smith", false, null, 0, "BOB.SMITH@EXAMPLE.COM", "BOB.SMITH@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAECkLiwJlmH1f5w6xTOGrbG+UUWE0E917HVexGXL7gKLGPIWdZe0dMo+HZQm24tQG/A==", null, null, false, "0b57ea12-477e-46f3-9292-147854dd1ada", false, "State University", null, "bob.smith@example.com", null },
                    { "f86e7a0f-7c26-4ce0-8559-c0b8a105b981", 0, "Avid cyclist and technology enthusiast.", new DateTime(1990, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "d81e719a-50ef-4783-b4a5-da001839efa0", "david.miller@example.com", false, "Mechanical", "David", 0, 0, false, 1, "Miller", false, null, 2, "DAVID.MILLER@EXAMPLE.COM", "DAVID.MILLER@EXAMPLE.COM", 1, "AQAAAAIAAYagAAAAEDq18/F8CmHKVpSvmdVPeVOrgUfbeM7h2c5Sfj2x5yDcja21xXEwsXYQSPhh8vST8w==", null, null, false, "6145216d-b00a-45fc-994e-e6ae23aa2b07", false, "Engineering Institute", null, "david.miller@example.com", null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("295b8aa6-eaf3-4b6b-925a-d68cd1492a80"), "Workshop on emerging technologies.", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Tech Institute", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Workshop" },
                    { new Guid("8b1f2cbd-4b8e-499b-95ea-28806fcfa1ee"), "Annual technology conference.", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Convention Center", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Tech Conference" },
                    { new Guid("ff1698c3-7c23-4f50-b998-e0364940f295"), "A meetup for community members.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), "City Park", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Community Meetup" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e0489ec7-4adb-4b22-b50a-3bc629ec8846", "0f0e0049-831f-4aa2-b2bf-90c210cfe42c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e0489ec7-4adb-4b22-b50a-3bc629ec8846", "0f0e0049-831f-4aa2-b2bf-90c210cfe42c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04f63598-5718-41e4-843f-d4be70f3e194");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e6882ac-baee-40e6-8711-808330b91e1d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ad45938c-188c-4450-8e7e-b2abb4877746");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "de76f82c-6176-4350-8ffb-90f30d9eec4d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f86e7a0f-7c26-4ce0-8559-c0b8a105b981");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("295b8aa6-eaf3-4b6b-925a-d68cd1492a80"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("8b1f2cbd-4b8e-499b-95ea-28806fcfa1ee"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ff1698c3-7c23-4f50-b998-e0364940f295"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0489ec7-4adb-4b22-b50a-3bc629ec8846");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f0e0049-831f-4aa2-b2bf-90c210cfe42c");

            migrationBuilder.DropColumn(
                name: "IsShadowbanned",
                table: "AspNetUsers");

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
    }
}
