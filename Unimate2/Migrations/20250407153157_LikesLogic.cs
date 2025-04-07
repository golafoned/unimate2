using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniMate2.Migrations
{
    /// <inheritdoc />
    public partial class LikesLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_LikedId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_LikerId",
                table: "Likes");

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

            migrationBuilder.AlterColumn<string>(
                name: "LikerId",
                table: "Likes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LikedId",
                table: "Likes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LikedAt",
                table: "Likes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "FriendRequests",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserDislikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DislikingUserId = table.Column<string>(type: "text", nullable: false),
                    DislikedUserId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDislikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDislikes_AspNetUsers_DislikedUserId",
                        column: x => x.DislikedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDislikes_AspNetUsers_DislikingUserId",
                        column: x => x.DislikingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserDislikes_DislikedUserId",
                table: "UserDislikes",
                column: "DislikedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDislikes_DislikingUserId",
                table: "UserDislikes",
                column: "DislikingUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_LikedId",
                table: "Likes",
                column: "LikedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_LikerId",
                table: "Likes",
                column: "LikerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_LikedId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_LikerId",
                table: "Likes");

            migrationBuilder.DropTable(
                name: "UserDislikes");

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

            migrationBuilder.AlterColumn<string>(
                name: "LikerId",
                table: "Likes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LikedId",
                table: "Likes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LikedAt",
                table: "Likes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestDate",
                table: "FriendRequests",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Events",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Events",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

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
                name: "FK_Likes_AspNetUsers_LikedId",
                table: "Likes",
                column: "LikedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_LikerId",
                table: "Likes",
                column: "LikerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
