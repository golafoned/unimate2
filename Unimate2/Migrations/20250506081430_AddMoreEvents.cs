using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Unimate2.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "744c2bf2-b115-4119-bbda-88c83472baa2", "dc647b87-999f-42ce-a7aa-7de4b535e137" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06754d4b-c490-4f86-90c5-ee8b0d7afb14");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a16468a-e854-4b18-bc2e-370ee63d7b69");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6faed1c6-ddf0-4935-a0ee-69bba14ac866");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81f9e3a8-b73c-4354-80af-a58dffb856d8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a533b3e-50a5-45b9-aad4-b1a14e1bd531");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("225abbaf-b65d-449c-8eba-f4a7aa1a3deb"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("315df11c-8e17-4f19-991f-dfdc2bcb40a5"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("d02c43fb-b132-4911-b55b-9ffe0c73d768"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "744c2bf2-b115-4119-bbda-88c83472baa2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc647b87-999f-42ce-a7aa-7de4b535e137");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a939576c-57c2-4a3f-a25b-6a7065e30fd5", "cd554e0c-5170-40aa-9105-e95fb9f6efd2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Faculty", "FirstName", "Gender", "IsBanned", "IsDrinking", "IsSmoking", "LastName", "LockoutEnabled", "LockoutEnd", "LookingFor", "NormalizedEmail", "NormalizedUserName", "Orientation", "PasswordHash", "PersonalityType", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "University", "UserId", "UserName", "ZodiakSign" },
                values: new object[,]
                {
                    { "0c9d64db-3ecd-4c11-8466-93fd6c235c62", 0, "Passionate about graphic design and photography.", new DateTime(1992, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), "25c74c10-ca0c-4625-9fdf-dd0a5c41e244", "carol.davis@example.com", false, "Design", "Carol", 0, false, 1, 2, "Davis", false, null, 3, "CAROL.DAVIS@EXAMPLE.COM", "CAROL.DAVIS@EXAMPLE.COM", 3, "AQAAAAIAAYagAAAAEANFxWZi2JrIs0LFvHA+HEHZoWmVOBCdZSCkMxnnGDSTtDVfT+FgzhzyGpTxIAyQrQ==", null, null, false, "0f00c373-890f-4dc3-a778-0ddfdd6c9eeb", false, "Arts College", null, "carol.davis@example.com", null },
                    { "430b0cb6-715d-497e-ab44-5548680c8dc3", 0, "Avid cyclist and technology enthusiast.", new DateTime(1990, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "e7294757-f815-4681-8fbd-1acb66ecd1d9", "david.miller@example.com", false, "Mechanical", "David", 0, false, 0, 1, "Miller", false, null, 2, "DAVID.MILLER@EXAMPLE.COM", "DAVID.MILLER@EXAMPLE.COM", 1, "AQAAAAIAAYagAAAAEDMTNN3hRcg5oWCYPAS1R5LfHBnXgf2uNIFfgemyEFaMkdQhb8JvV8ygLvSGAhozPw==", null, null, false, "2b0deb7c-b230-4507-9657-823f1af5e0d0", false, "Engineering Institute", null, "david.miller@example.com", null },
                    { "97703bed-6f6b-4b44-b33b-fa832e93710a", 0, "Bio5", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b202a8f7-aed5-43be-8c9a-22a84920d453", "user1@example.com", false, "Faculty2", "FirstName2", 2, false, 0, 1, "LastName2", false, null, 0, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEMXczcJgxZ/lzNplUGcVraE3ZarLvyBMGOSKrnLrKLGACl4qPN4d8C9KrwA1gk6dTA==", null, null, false, "10dbb750-6b1a-4b89-85e4-73e7a2f339c0", false, "University1", null, "user1@example.com", null },
                    { "c7ef2683-a079-4683-80dd-b0ac2ec865b4", 0, "Loves hiking and outdoor adventures.", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), "057906af-4858-4239-87c9-929108da33c2", "alice.johnson@example.com", false, "Engineering", "Alice", 1, false, 2, 1, "Johnson", false, null, 1, "ALICE.JOHNSON@EXAMPLE.COM", "ALICE.JOHNSON@EXAMPLE.COM", 2, "AQAAAAIAAYagAAAAEH0fmw9E0q5PRzTr/G1eBz84na1//OhoNs4zqJbzu187mJun4aCKFXmJ9MxydckRPg==", null, null, false, "2563f19b-a726-4c6e-b01a-9d14f480d4ee", false, "Tech University", null, "alice.johnson@example.com", null },
                    { "d5a757eb-6762-453e-8e70-7105fb391a47", 0, "Bio2", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "e0245756-e487-42d7-bc17-3ae50b1551b2", "user2@example.com", false, "Faculty2", "FirstName2", 0, false, 0, 1, "LastName2", false, null, 0, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEG/u3Kr1g5tE7hTeMS5gpp+2iwoSOfILIcmoSw5hvua1qelxngiVFxv23SqHrPG0hg==", null, null, false, "32c41b42-21ad-4367-b4a9-cad3ac77971f", false, "University2", null, "user2@example.com", null },
                    { "d666ed38-4c45-423e-826a-0d18dc7bbb2f", 0, "Enjoys cooking and traveling.", new DateTime(1988, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), "c8bbf2dd-efdf-455e-93c9-2a13d8d575bb", "bob.smith@example.com", false, "Business", "Bob", 0, false, 0, 0, "Smith", false, null, 0, "BOB.SMITH@EXAMPLE.COM", "BOB.SMITH@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEP2M60TgFrd8vpDcAyJUU+EtGqZr9No/PgfTLPl2oVFa4eYHUTEwsAM8yAKqHCuatw==", null, null, false, "45cd4b42-b798-4683-813b-8f587aae915e", false, "State University", null, "bob.smith@example.com", null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("06fc6ae4-5bd7-4863-8cc0-7e7c8fda52e3"), "Annual book fair with author signings.", new DateTime(2024, 3, 10, 17, 0, 0, 0, DateTimeKind.Utc), "Central Library", new DateTime(2024, 3, 8, 10, 0, 0, 0, DateTimeKind.Utc), "Book Fair" },
                    { new Guid("43126093-48db-4c6d-bd7d-c273da094c8e"), "A meetup for community members.", new DateTime(2023, 10, 15, 17, 0, 0, 0, DateTimeKind.Utc), "City Park", new DateTime(2023, 10, 15, 14, 0, 0, 0, DateTimeKind.Utc), "Community Meetup" },
                    { new Guid("48b7b215-294a-47dd-b8d1-990958b3fddc"), "24-hour coding competition for students.", new DateTime(2024, 8, 4, 10, 0, 0, 0, DateTimeKind.Utc), "University Campus - CS Building", new DateTime(2024, 8, 3, 10, 0, 0, 0, DateTimeKind.Utc), "University Hackathon" },
                    { new Guid("4c372d14-741a-4ac7-bd64-a82c47d44021"), "Workshop on emerging AI technologies.", new DateTime(2023, 12, 10, 16, 0, 0, 0, DateTimeKind.Utc), "Tech Institute", new DateTime(2023, 12, 10, 10, 0, 0, 0, DateTimeKind.Utc), "Workshop on AI" },
                    { new Guid("63dc621f-5577-47e8-9644-530d4f8f093c"), "Independent film festival showcasing new talents.", new DateTime(2024, 6, 23, 23, 0, 0, 0, DateTimeKind.Utc), "Indie Cinema", new DateTime(2024, 6, 20, 17, 0, 0, 0, DateTimeKind.Utc), "Film Festival" },
                    { new Guid("7b076798-db07-42a4-87fe-6484570f3091"), "Gathering of diverse food trucks.", new DateTime(2024, 7, 14, 20, 0, 0, 0, DateTimeKind.Utc), "Downtown Square", new DateTime(2024, 7, 14, 12, 0, 0, 0, DateTimeKind.Utc), "Food Truck Rally" },
                    { new Guid("95265ce9-aa7e-464b-831e-901ddb94a2cf"), "Entrepreneurs pitch their ideas to investors.", new DateTime(2024, 4, 12, 22, 0, 0, 0, DateTimeKind.Utc), "Innovation Hub", new DateTime(2024, 4, 12, 19, 0, 0, 0, DateTimeKind.Utc), "Startup Pitch Night" },
                    { new Guid("ae0b8507-6189-4b95-8a0d-bacef465754c"), "Annual technology conference.", new DateTime(2023, 11, 22, 18, 0, 0, 0, DateTimeKind.Utc), "Convention Center", new DateTime(2023, 11, 20, 9, 0, 0, 0, DateTimeKind.Utc), "Tech Conference" },
                    { new Guid("b3f69f87-8e1a-4a67-b9ac-7caf684daaa8"), "5K charity run for a local cause.", new DateTime(2024, 5, 5, 12, 0, 0, 0, DateTimeKind.Utc), "Riverside Park", new DateTime(2024, 5, 5, 9, 0, 0, 0, DateTimeKind.Utc), "Charity Run" },
                    { new Guid("c23e18d5-fb16-4ad9-b58d-6d162e3b988c"), "Exhibition of local artists.", new DateTime(2024, 1, 7, 19, 0, 0, 0, DateTimeKind.Utc), "Art Gallery", new DateTime(2024, 1, 5, 11, 0, 0, 0, DateTimeKind.Utc), "Art Exhibition" },
                    { new Guid("c315ced8-3611-423c-b92d-52a8f86bed71"), "Weekend music festival with various bands.", new DateTime(2024, 2, 18, 23, 0, 0, 0, DateTimeKind.Utc), "Open Air Arena", new DateTime(2024, 2, 16, 18, 0, 0, 0, DateTimeKind.Utc), "Music Festival" },
                    { new Guid("d8b97be6-8fa0-42f2-9a92-03adc2e69958"), "Annual gathering for university alumni.", new DateTime(2024, 9, 21, 21, 0, 0, 0, DateTimeKind.Utc), "University Grand Hall", new DateTime(2024, 9, 21, 15, 0, 0, 0, DateTimeKind.Utc), "Alumni Homecoming" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a939576c-57c2-4a3f-a25b-6a7065e30fd5", "97703bed-6f6b-4b44-b33b-fa832e93710a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a939576c-57c2-4a3f-a25b-6a7065e30fd5", "97703bed-6f6b-4b44-b33b-fa832e93710a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c9d64db-3ecd-4c11-8466-93fd6c235c62");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430b0cb6-715d-497e-ab44-5548680c8dc3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7ef2683-a079-4683-80dd-b0ac2ec865b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a757eb-6762-453e-8e70-7105fb391a47");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d666ed38-4c45-423e-826a-0d18dc7bbb2f");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("06fc6ae4-5bd7-4863-8cc0-7e7c8fda52e3"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("43126093-48db-4c6d-bd7d-c273da094c8e"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("48b7b215-294a-47dd-b8d1-990958b3fddc"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("4c372d14-741a-4ac7-bd64-a82c47d44021"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("63dc621f-5577-47e8-9644-530d4f8f093c"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("7b076798-db07-42a4-87fe-6484570f3091"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("95265ce9-aa7e-464b-831e-901ddb94a2cf"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ae0b8507-6189-4b95-8a0d-bacef465754c"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("b3f69f87-8e1a-4a67-b9ac-7caf684daaa8"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("c23e18d5-fb16-4ad9-b58d-6d162e3b988c"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("c315ced8-3611-423c-b92d-52a8f86bed71"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("d8b97be6-8fa0-42f2-9a92-03adc2e69958"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a939576c-57c2-4a3f-a25b-6a7065e30fd5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97703bed-6f6b-4b44-b33b-fa832e93710a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "744c2bf2-b115-4119-bbda-88c83472baa2", "5698b40d-6aa2-4e70-ba6f-fba48c451a01", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Faculty", "FirstName", "Gender", "IsBanned", "IsDrinking", "IsSmoking", "LastName", "LockoutEnabled", "LockoutEnd", "LookingFor", "NormalizedEmail", "NormalizedUserName", "Orientation", "PasswordHash", "PersonalityType", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "University", "UserId", "UserName", "ZodiakSign" },
                values: new object[,]
                {
                    { "06754d4b-c490-4f86-90c5-ee8b0d7afb14", 0, "Enjoys cooking and traveling.", new DateTime(1988, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), "05257860-2011-4665-883a-b3dc63126277", "bob.smith@example.com", false, "Business", "Bob", 0, false, 0, 0, "Smith", false, null, 0, "BOB.SMITH@EXAMPLE.COM", "BOB.SMITH@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEJ+W6twiSxPXbHRE92rjRMJBfDPrU9Oi2R4u0KeR/4z1GlziBWFb4RXFlXMvavFfyQ==", null, null, false, "70c2b0cf-7985-4d43-9423-24869e491c64", false, "State University", null, "bob.smith@example.com", null },
                    { "3a16468a-e854-4b18-bc2e-370ee63d7b69", 0, "Bio2", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "0d346bc2-9f25-4526-b0b0-b35c7d34bac6", "user2@example.com", false, "Faculty2", "FirstName2", 0, false, 0, 1, "LastName2", false, null, 0, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEEH7E4QuZWHu65vCQzanMLwKQDG92E/duU4US0QNtMz2gM00/q0no8W9deBbx2eiGA==", null, null, false, "bf2c7473-99ec-4e84-9fd8-9861cbcd48cc", false, "University2", null, "user2@example.com", null },
                    { "6faed1c6-ddf0-4935-a0ee-69bba14ac866", 0, "Avid cyclist and technology enthusiast.", new DateTime(1990, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "a02a1bca-f07e-4466-b66d-64748311eb81", "david.miller@example.com", false, "Mechanical", "David", 0, false, 0, 1, "Miller", false, null, 2, "DAVID.MILLER@EXAMPLE.COM", "DAVID.MILLER@EXAMPLE.COM", 1, "AQAAAAIAAYagAAAAEJT5tMDNjW6i1uq/Ox1Oc/kULcudQKM6ifQhkI3XXiltn40tH512CSvo4xXLynHM0g==", null, null, false, "c8643f05-4055-437b-b51e-c501cb1c7ad6", false, "Engineering Institute", null, "david.miller@example.com", null },
                    { "81f9e3a8-b73c-4354-80af-a58dffb856d8", 0, "Loves hiking and outdoor adventures.", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), "903ebe95-b644-450f-9643-2f35371cdb68", "alice.johnson@example.com", false, "Engineering", "Alice", 1, false, 2, 1, "Johnson", false, null, 1, "ALICE.JOHNSON@EXAMPLE.COM", "ALICE.JOHNSON@EXAMPLE.COM", 2, "AQAAAAIAAYagAAAAEAkG6+S9vmbJweRFCPhQRYZ3Sp3ASHDGquwdI9vqG8YwKK9yQF+72/qiaCuXLGNOng==", null, null, false, "b1a36fa4-dbf0-4f74-9cc2-ec2ccdfdb711", false, "Tech University", null, "alice.johnson@example.com", null },
                    { "8a533b3e-50a5-45b9-aad4-b1a14e1bd531", 0, "Passionate about graphic design and photography.", new DateTime(1992, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), "e447feac-cf2f-4154-a697-4e4641d5ca2d", "carol.davis@example.com", false, "Design", "Carol", 0, false, 1, 2, "Davis", false, null, 3, "CAROL.DAVIS@EXAMPLE.COM", "CAROL.DAVIS@EXAMPLE.COM", 3, "AQAAAAIAAYagAAAAEP9tSaXISQRSG67nU/u2Zp2RVeglF4C7xXobG8DhER+8KeL0CJX8cO9vT7d1Bzd3dg==", null, null, false, "a4bf3440-9b29-4c12-95db-ca5c1add5462", false, "Arts College", null, "carol.davis@example.com", null },
                    { "dc647b87-999f-42ce-a7aa-7de4b535e137", 0, "Bio5", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "8ecdb065-fa3b-4d12-97a6-a4794e8dc429", "user1@example.com", false, "Faculty2", "FirstName2", 2, false, 0, 1, "LastName2", false, null, 0, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEFTV/fyVQc49i6Rf/7ZMrS+jhWkokhCDDK/zhMOtvxZJ54RkK1yF0oChQ0p38njUMQ==", null, null, false, "ceb8685d-82e6-428a-a12d-6fda6c883619", false, "University1", null, "user1@example.com", null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("225abbaf-b65d-449c-8eba-f4a7aa1a3deb"), "Annual technology conference.", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Convention Center", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Tech Conference" },
                    { new Guid("315df11c-8e17-4f19-991f-dfdc2bcb40a5"), "Workshop on emerging technologies.", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Tech Institute", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Workshop" },
                    { new Guid("d02c43fb-b132-4911-b55b-9ffe0c73d768"), "A meetup for community members.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), "City Park", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Community Meetup" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "744c2bf2-b115-4119-bbda-88c83472baa2", "dc647b87-999f-42ce-a7aa-7de4b535e137" });
        }
    }
}
