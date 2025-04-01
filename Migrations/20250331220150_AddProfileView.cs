using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniMate2.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ProfileViews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ViewerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ViewedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ViewedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileViews", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Faculty", "FirstName", "Gender", "IsDrinking", "IsSmoking", "LastName", "LockoutEnabled", "LockoutEnd", "LookingFor", "NormalizedEmail", "NormalizedUserName", "Orientation", "PasswordHash", "PersonalityType", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "University", "UserId", "UserName", "ZodiakSign" },
                values: new object[,]
                {
                    { "1925a6d5-5189-423d-a4b9-cbf7e4fe021f", 0, "Passionate about graphic design and photography.", new DateTime(1992, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "e9d5eba1-cc1e-4452-902d-11ff8d87d322", "carol.davis@example.com", false, "Design", "Carol", 0, 1, 2, "Davis", false, null, 3, "CAROL.DAVIS@EXAMPLE.COM", "CAROL.DAVIS@EXAMPLE.COM", 3, "AQAAAAIAAYagAAAAEG9ouCCiPi5JAdMJffef7oVu16qpRjHBv1nPgysw5oifczOCiyqZsjswwt4Aw83Teg==", null, null, false, "8f6ee1af-b29c-4c13-b989-2a7ad78624e1", false, "Arts College", null, "carol.davis@example.com", null },
                    { "2daf219c-d869-4569-989f-81f3ba3f820a", 0, "Loves hiking and outdoor adventures.", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "4b1c68bd-b3ad-4499-8123-b0275117ea91", "alice.johnson@example.com", false, "Engineering", "Alice", 1, 2, 1, "Johnson", false, null, 1, "ALICE.JOHNSON@EXAMPLE.COM", "ALICE.JOHNSON@EXAMPLE.COM", 2, "AQAAAAIAAYagAAAAECJeKbsaT+JsG/+5IlR2yigpK8Te89tq1sSxE3219Fst8ydNuGDOA5dqymfZBKo7IA==", null, null, false, "f6944ee8-7160-4b2c-b46f-eae577a03c4c", false, "Tech University", null, "alice.johnson@example.com", null },
                    { "3443dab2-5339-4397-9458-b2b877fa04d2", 0, "Bio2", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2ddb3276-8126-409f-9167-b472475f62d0", "user2@example.com", false, "Faculty2", "FirstName2", 0, 0, 1, "LastName2", false, null, 0, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEBAPHLxXlSR2i31risigyQf7Z0xbGHR53qVQuBGnQWgkTlER4vlz0s+kN70q4V1ohw==", null, null, false, "3f5d50b6-6f7d-447c-a271-7f5ef2c22472", false, "University2", null, "user2@example.com", null },
                    { "8c8ca963-9c66-40a7-af50-6789834358bb", 0, "Enjoys cooking and traveling.", new DateTime(1988, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ab497c93-8ab5-4d63-b6c7-ffeef845200e", "bob.smith@example.com", false, "Business", "Bob", 0, 0, 0, "Smith", false, null, 0, "BOB.SMITH@EXAMPLE.COM", "BOB.SMITH@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEOhCqDY4GsS6lz6TQBPnFqGsYtEzpmZL90UoEXA3VFKaneC7n08UPnIj0/VRiHwKhw==", null, null, false, "81c260c0-0c7c-4876-b130-617c6e1fe467", false, "State University", null, "bob.smith@example.com", null },
                    { "baca204a-57a6-4000-873f-dc871d44fa67", 0, "", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "81644473-574c-4d09-a322-41a7b57e7840", null, false, "Faculty2", "FirstName2", 2, 0, 1, "LastName2", false, null, 0, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEOt8yPqSnYE+gZL4fcQZj1ilU23uIqwZldz4yBSMvGE9nOJ1XlC1n1EVHCYxj6KfgQ==", null, null, false, "94d2a48a-f75f-41e7-8ac2-cc37dad6d68c", false, "University1", null, null, null },
                    { "eafbfbd3-2730-4f41-b2ed-012981fff1c5", 0, "Avid cyclist and technology enthusiast.", new DateTime(1990, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "2938230b-c431-4a9f-b211-9e8bdc874e95", "david.miller@example.com", false, "Mechanical", "David", 0, 0, 1, "Miller", false, null, 2, "DAVID.MILLER@EXAMPLE.COM", "DAVID.MILLER@EXAMPLE.COM", 1, "AQAAAAIAAYagAAAAEFDEV5G4SlFxuMq8z5WzBM3IszP5uwXaO/bL1ENPNW7oID5yBEJ6BISbDUxCY4t5kw==", null, null, false, "eecb6b1b-7e8e-451d-92a8-b94adc7f04db", false, "Engineering Institute", null, "david.miller@example.com", null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("079d03e0-1a45-4e74-bb49-2a835689bcdd"), "A meetup for community members.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Park", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Community Meetup" },
                    { new Guid("916bff14-17c3-4695-aa15-5999cae412e6"), "Annual technology conference.", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Convention Center", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Conference" },
                    { new Guid("bb1a9c36-2e1a-46c5-a9f2-ca25be14b9df"), "Workshop on emerging technologies.", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Institute", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Workshop" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileViews");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1925a6d5-5189-423d-a4b9-cbf7e4fe021f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2daf219c-d869-4569-989f-81f3ba3f820a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3443dab2-5339-4397-9458-b2b877fa04d2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c8ca963-9c66-40a7-af50-6789834358bb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "baca204a-57a6-4000-873f-dc871d44fa67");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eafbfbd3-2730-4f41-b2ed-012981fff1c5");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("079d03e0-1a45-4e74-bb49-2a835689bcdd"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("916bff14-17c3-4695-aa15-5999cae412e6"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("bb1a9c36-2e1a-46c5-a9f2-ca25be14b9df"));

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
        }
    }
}
