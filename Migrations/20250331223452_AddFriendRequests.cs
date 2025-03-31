using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniMate2.Migrations
{
    /// <inheritdoc />
    public partial class AddFriendRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_AspNetUsers_ReceiverId",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_AspNetUsers_SenderId",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_ReceiverId",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_SenderId",
                table: "FriendRequests");

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

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "FriendRequests");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "FriendRequests",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "FriendRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RecipientId",
                table: "FriendRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequesterId",
                table: "FriendRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Faculty", "FirstName", "Gender", "IsDrinking", "IsSmoking", "LastName", "LockoutEnabled", "LockoutEnd", "LookingFor", "NormalizedEmail", "NormalizedUserName", "Orientation", "PasswordHash", "PersonalityType", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "University", "UserId", "UserName", "ZodiakSign" },
                values: new object[,]
                {
                    { "046f2f26-8971-43f6-8e29-46f27f279d9d", 0, "Bio2", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2e50604e-3a1f-44a3-a5f3-eaac788f0a30", "user2@example.com", false, "Faculty2", "FirstName2", 0, 0, 1, "LastName2", false, null, 0, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEIhuSJVCAfiqyEVaUP+oUD1IiVrsZ/bvgXtxodMwp0wSzTXYtAWrkqgEv2twCZwrvQ==", null, null, false, "17952ee0-d3f4-41e4-b3a3-efacdf3b594f", false, "University2", null, "user2@example.com", null },
                    { "11d4feae-223f-47be-b2fe-2595798bc6cb", 0, "Enjoys cooking and traveling.", new DateTime(1988, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "3d69a508-5c1c-4fea-8ad7-a16fb6718b47", "bob.smith@example.com", false, "Business", "Bob", 0, 0, 0, "Smith", false, null, 0, "BOB.SMITH@EXAMPLE.COM", "BOB.SMITH@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEPk6O1+T0yt1OPJRP0gngr24szmRJ4rZQ3dde9WreYjHhytPxiJO9J0uRx5n+xO91A==", null, null, false, "8f86e93e-cb91-4b1e-aa5e-8748a3d32d18", false, "State University", null, "bob.smith@example.com", null },
                    { "249792f9-b392-4e93-a121-d386631b3bdb", 0, "", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8a15657f-021d-4751-8f03-7c4951cd9c70", null, false, "Faculty2", "FirstName2", 2, 0, 1, "LastName2", false, null, 0, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEEqEfoCY2QBqMTIzZtUtNTIUtPBkyLRBffmRLUQCr64yb7A9T1VVoB+534mFrsQvCw==", null, null, false, "8595bad7-5bcb-4599-a542-be74ec164869", false, "University1", null, null, null },
                    { "2bb5cfdf-a81c-4326-bcc4-63812b20241a", 0, "Loves hiking and outdoor adventures.", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ee4a1459-df88-4be6-8504-7bc3918c7324", "alice.johnson@example.com", false, "Engineering", "Alice", 1, 2, 1, "Johnson", false, null, 1, "ALICE.JOHNSON@EXAMPLE.COM", "ALICE.JOHNSON@EXAMPLE.COM", 2, "AQAAAAIAAYagAAAAEN0oPLfwsGp26LHFMkKgvfrfCF8MWhaBMGoPW7xuTNkRWiIyZ6H2CGImlb/4kSYL7A==", null, null, false, "bba5229a-581a-45c5-afc5-9b1d67c8b3fc", false, "Tech University", null, "alice.johnson@example.com", null },
                    { "51b3c444-aa72-4356-9b08-c500ad16b165", 0, "Passionate about graphic design and photography.", new DateTime(1992, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "7f54cc5c-47d0-48a0-b4fb-5da009ac6483", "carol.davis@example.com", false, "Design", "Carol", 0, 1, 2, "Davis", false, null, 3, "CAROL.DAVIS@EXAMPLE.COM", "CAROL.DAVIS@EXAMPLE.COM", 3, "AQAAAAIAAYagAAAAEBil/lMCxwC7XiDuDtn5yUEx2SfxXvMbN8wlRVem3ab2yjnl9qWXQEfVz16eXKImKQ==", null, null, false, "51460f29-86f6-466e-852b-ae92f5c6f0f3", false, "Arts College", null, "carol.davis@example.com", null },
                    { "ca667905-520a-4cbd-b94a-527b1ca668a9", 0, "Avid cyclist and technology enthusiast.", new DateTime(1990, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "c467c49b-3e43-497f-9b15-858d1802af2f", "david.miller@example.com", false, "Mechanical", "David", 0, 0, 1, "Miller", false, null, 2, "DAVID.MILLER@EXAMPLE.COM", "DAVID.MILLER@EXAMPLE.COM", 1, "AQAAAAIAAYagAAAAEIoggzUNzGMpzpk9pp2m9E8dKWyiNh30RcOYvZwPsmSruS5DjRz0fMj5tcDnaiD2BA==", null, null, false, "565e6dfc-e520-47ec-b33f-bc765e9f8523", false, "Engineering Institute", null, "david.miller@example.com", null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("5af2f0e8-35fe-4392-b2e9-de5d821640fd"), "A meetup for community members.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Park", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Community Meetup" },
                    { new Guid("6bae456c-8219-4fbf-b795-a4d27a13999b"), "Workshop on emerging technologies.", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Institute", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Workshop" },
                    { new Guid("c89e0bca-363c-4161-83da-3fd2967ce7a6"), "Annual technology conference.", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Convention Center", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Conference" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_RecipientId",
                table: "FriendRequests",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_RequesterId",
                table: "FriendRequests",
                column: "RequesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_AspNetUsers_RecipientId",
                table: "FriendRequests",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_AspNetUsers_RequesterId",
                table: "FriendRequests",
                column: "RequesterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_AspNetUsers_RecipientId",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_AspNetUsers_RequesterId",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_RecipientId",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_RequesterId",
                table: "FriendRequests");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "046f2f26-8971-43f6-8e29-46f27f279d9d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11d4feae-223f-47be-b2fe-2595798bc6cb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "249792f9-b392-4e93-a121-d386631b3bdb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2bb5cfdf-a81c-4326-bcc4-63812b20241a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51b3c444-aa72-4356-9b08-c500ad16b165");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca667905-520a-4cbd-b94a-527b1ca668a9");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("5af2f0e8-35fe-4392-b2e9-de5d821640fd"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("6bae456c-8219-4fbf-b795-a4d27a13999b"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("c89e0bca-363c-4161-83da-3fd2967ce7a6"));

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "RequesterId",
                table: "FriendRequests");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "FriendRequests",
                newName: "RequestDate");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "FriendRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "FriendRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "FriendRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_FriendRequests_ReceiverId",
                table: "FriendRequests",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_SenderId",
                table: "FriendRequests",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_AspNetUsers_ReceiverId",
                table: "FriendRequests",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_AspNetUsers_SenderId",
                table: "FriendRequests",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
