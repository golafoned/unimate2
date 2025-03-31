using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniMate2.Migrations
{
    /// <inheritdoc />
    public partial class addLikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0ea31df6-8460-43fa-b8fe-62a6b3c20063");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "369b2388-e3ef-4015-abd2-b8e5cf8726b0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a9736d4-19d2-47db-8d6f-dcd08e9c6671");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f2525cc-8294-484b-ab62-911f603920bd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a665e196-0050-48d1-8b6d-97af5679d69b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "db0f9d3e-b5c9-4ca4-966e-19db4dffacc8");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("37dc6fd4-2691-4dd1-af98-267cdb5ab8c2"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("b0e47d00-5bc2-46ef-82d4-a183489bd76f"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("fa2c2e66-199e-4054-a472-3c84d27a22e4"));

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LikerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LikedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LikedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_LikedId",
                        column: x => x.LikedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_LikerId",
                        column: x => x.LikerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Faculty", "FirstName", "Gender", "IsDrinking", "IsSmoking", "LastName", "LockoutEnabled", "LockoutEnd", "LookingFor", "NormalizedEmail", "NormalizedUserName", "Orientation", "PasswordHash", "PersonalityType", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "University", "UserId", "UserName", "ZodiakSign" },
                values: new object[,]
                {
                    { "1f6e77ab-3b24-4b05-a535-4cc3903f2868", 0, "Bio2", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7da57283-d791-46db-9167-4c2d43d701c3", "user2@example.com", false, "Faculty2", "FirstName2", 0, 0, 1, "LastName2", false, null, 0, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEGRF3XM/vLqyrlsYvmuCvEnNzTo79urJ+gUQk+w8IPVj5rN8J9Wq2KpsQxp013tlbw==", null, null, false, "b00a6fc2-b766-4b62-bde0-8816ab36b447", false, "University2", null, "user2@example.com", null },
                    { "2278c833-cb5c-4001-b008-592c2c08a6b9", 0, "Avid cyclist and technology enthusiast.", new DateTime(1990, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "66c2b86b-d53f-4225-baaf-5bfa9a6b66a7", "david.miller@example.com", false, "Mechanical", "David", 0, 0, 1, "Miller", false, null, 2, "DAVID.MILLER@EXAMPLE.COM", "DAVID.MILLER@EXAMPLE.COM", 1, "AQAAAAIAAYagAAAAEFzdWzdfmNp5Ag+9zb+z8ZK5s1W5s/aaM3F7keRlRclJsRfzxvJqfkjW+TZVHXcC1w==", null, null, false, "1f129cf8-5efa-44fe-9c9a-fde0f3fa4dbf", false, "Engineering Institute", null, "david.miller@example.com", null },
                    { "bde63123-6dc3-477c-9a2e-fea370fdb360", 0, "", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "729e04c6-25b0-4adc-abda-96f7c0d5e4e2", null, false, "Faculty2", "FirstName2", 2, 0, 1, "LastName2", false, null, 0, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEIxiMld/b7MRcrYPfaKjKNTtGuKj0IgOSM2J2HkXs2c00n/dNM2uGCnlvBPpLjs74g==", null, null, false, "f8867c43-15e1-4ba7-a922-a4b64f3f55d0", false, "University1", null, null, null },
                    { "d40df357-a2f7-499b-8550-f21b8450d9c3", 0, "Enjoys cooking and traveling.", new DateTime(1988, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "900a7263-ce2b-4087-af9a-2e520abef7a9", "bob.smith@example.com", false, "Business", "Bob", 0, 0, 0, "Smith", false, null, 0, "BOB.SMITH@EXAMPLE.COM", "BOB.SMITH@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEEF9bwQy+GK4yBBOnmT/GW4zUw4l/NIdn16TwNtCYcVI9rx0PysalAwymmqzfhB8Eg==", null, null, false, "b94861ea-2690-4b30-ab74-6ea209d51a47", false, "State University", null, "bob.smith@example.com", null },
                    { "ea829773-499c-4863-9ef9-b73d55761570", 0, "Passionate about graphic design and photography.", new DateTime(1992, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "3ead80cc-0943-41d5-bca7-cf3ff597ef85", "carol.davis@example.com", false, "Design", "Carol", 0, 1, 2, "Davis", false, null, 3, "CAROL.DAVIS@EXAMPLE.COM", "CAROL.DAVIS@EXAMPLE.COM", 3, "AQAAAAIAAYagAAAAEKB2cREu5wcnn2G6pvstiQgGf2vvL5px0cmokCbMPbuUzkv35Hc5kMhYsI2XCMAo6A==", null, null, false, "0e2cd9b9-ddbf-44d4-aa7d-3ec2af818734", false, "Arts College", null, "carol.davis@example.com", null },
                    { "edaa6fae-2f9a-47a0-9c2b-fff1eac59699", 0, "Loves hiking and outdoor adventures.", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "22b2e94e-ba95-43ec-851e-47b8738f5987", "alice.johnson@example.com", false, "Engineering", "Alice", 1, 2, 1, "Johnson", false, null, 1, "ALICE.JOHNSON@EXAMPLE.COM", "ALICE.JOHNSON@EXAMPLE.COM", 2, "AQAAAAIAAYagAAAAEDuY1zuCF8tttAqoZZFyr6O+iO75/MzUxiEzS5T7BfiAqlhRAXU1ilf/4BzgW1FEGw==", null, null, false, "16b34bf1-0d2e-426b-bffa-c9182659abbf", false, "Tech University", null, "alice.johnson@example.com", null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("736f630e-d460-43af-96d6-9a086c44f20e"), "Workshop on emerging technologies.", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Institute", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Workshop" },
                    { new Guid("c487b371-c092-4c77-a51d-46f8d39cc43a"), "A meetup for community members.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Park", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Community Meetup" },
                    { new Guid("db9c44f7-deb3-4dd0-b9b3-fe70e755b870"), "Annual technology conference.", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Convention Center", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Conference" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikedId",
                table: "Likes",
                column: "LikedId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikerId",
                table: "Likes",
                column: "LikerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f6e77ab-3b24-4b05-a535-4cc3903f2868");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2278c833-cb5c-4001-b008-592c2c08a6b9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bde63123-6dc3-477c-9a2e-fea370fdb360");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d40df357-a2f7-499b-8550-f21b8450d9c3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea829773-499c-4863-9ef9-b73d55761570");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edaa6fae-2f9a-47a0-9c2b-fff1eac59699");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("736f630e-d460-43af-96d6-9a086c44f20e"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("c487b371-c092-4c77-a51d-46f8d39cc43a"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("db9c44f7-deb3-4dd0-b9b3-fe70e755b870"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Faculty", "FirstName", "Gender", "IsDrinking", "IsSmoking", "LastName", "LockoutEnabled", "LockoutEnd", "LookingFor", "NormalizedEmail", "NormalizedUserName", "Orientation", "PasswordHash", "PersonalityType", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "University", "UserId", "UserName", "ZodiakSign" },
                values: new object[,]
                {
                    { "0ea31df6-8460-43fa-b8fe-62a6b3c20063", 0, "Loves hiking and outdoor adventures.", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "876164e0-c75c-463c-a38f-cdf1ce069d85", "alice.johnson@example.com", false, "Engineering", "Alice", 1, 2, 1, "Johnson", false, null, 1, "ALICE.JOHNSON@EXAMPLE.COM", "ALICE.JOHNSON@EXAMPLE.COM", 2, "AQAAAAIAAYagAAAAEFMFAwbJ93XEh+u7Cd6rpMetxh/7SwTMZGMZrmdGCMkFXr6t0GwKBnYgdG6mF4TZxg==", null, null, false, "122ad0a7-3ade-415f-a30a-229853daa14d", false, "Tech University", null, "alice.johnson@example.com", null },
                    { "369b2388-e3ef-4015-abd2-b8e5cf8726b0", 0, "", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0f7d04ae-6d54-4960-bc42-b99cca258328", null, false, "Faculty2", "FirstName2", 2, 0, 1, "LastName2", false, null, 0, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEJ1Eg4Jvt2I2Y8CpTyQQ0YLiAjpnaIezahdRxMjspD60AnNI8YOJ8Gw9PDYkYBQb4w==", null, null, false, "bdc4c895-fc5b-4a39-b05d-b574c49b38f1", false, "University1", null, null, null },
                    { "4a9736d4-19d2-47db-8d6f-dcd08e9c6671", 0, "Enjoys cooking and traveling.", new DateTime(1988, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "393b317e-8273-49c7-a5f8-dcb0b3d34a83", "bob.smith@example.com", false, "Business", "Bob", 0, 0, 0, "Smith", false, null, 0, "BOB.SMITH@EXAMPLE.COM", "BOB.SMITH@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEF8f73Wu/oX+2lMyeYu3uK/wKPK2/9vcsLOKL73xHuZF2a6+P1E/LAJjJ5TjeWvcjw==", null, null, false, "abd45bf4-e3fb-473a-9701-bbea21f9d8b7", false, "State University", null, "bob.smith@example.com", null },
                    { "6f2525cc-8294-484b-ab62-911f603920bd", 0, "Avid cyclist and technology enthusiast.", new DateTime(1990, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "a01a423b-abfa-49bb-aaa9-cc2352e14a02", "david.miller@example.com", false, "Mechanical", "David", 0, 0, 1, "Miller", false, null, 2, "DAVID.MILLER@EXAMPLE.COM", "DAVID.MILLER@EXAMPLE.COM", 1, "AQAAAAIAAYagAAAAEFEOSYVK/aMSYzYpIWy/vXIBoJlMxEBD85wN2SELYWJkJ1/nmKwZoQvHntCRs/zM5g==", null, null, false, "79bfb2d1-bd87-4912-9e96-9c3d2999c71e", false, "Engineering Institute", null, "david.miller@example.com", null },
                    { "a665e196-0050-48d1-8b6d-97af5679d69b", 0, "Bio2", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "871b7620-f7cf-47e8-9611-6dc3632ff319", "user2@example.com", false, "Faculty2", "FirstName2", 0, 0, 1, "LastName2", false, null, 0, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEPmW7LdNUfCe8Rgay6jrxATjNqkbW3sJP062n6YMMl8vgyAtsNBu6oS779mfRix00A==", null, null, false, "e0d857b8-1581-4ca3-bb15-6c24b9a6a212", false, "University2", null, "user2@example.com", null },
                    { "db0f9d3e-b5c9-4ca4-966e-19db4dffacc8", 0, "Passionate about graphic design and photography.", new DateTime(1992, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "8d845a1c-f3f5-4bea-9778-38da1cab59c2", "carol.davis@example.com", false, "Design", "Carol", 0, 1, 2, "Davis", false, null, 3, "CAROL.DAVIS@EXAMPLE.COM", "CAROL.DAVIS@EXAMPLE.COM", 3, "AQAAAAIAAYagAAAAEFYRvvkB7DMEbgFcmuxWvOE9wpG+SbQiPfQB4xGcvBITmSmbsb4C6zAfLxlDC+lWsw==", null, null, false, "919f8425-9f36-4baf-965b-ac59317d2b7b", false, "Arts College", null, "carol.davis@example.com", null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("37dc6fd4-2691-4dd1-af98-267cdb5ab8c2"), "A meetup for community members.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Park", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Community Meetup" },
                    { new Guid("b0e47d00-5bc2-46ef-82d4-a183489bd76f"), "Workshop on emerging technologies.", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Institute", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Workshop" },
                    { new Guid("fa2c2e66-199e-4054-a472-3c84d27a22e4"), "Annual technology conference.", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Convention Center", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Conference" }
                });
        }
    }
}
