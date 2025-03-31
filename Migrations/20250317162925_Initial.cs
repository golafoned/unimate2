using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniMate2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Faculty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Orientation = table.Column<int>(type: "int", nullable: true),
                    IsSmoking = table.Column<int>(type: "int", nullable: true),
                    IsDrinking = table.Column<int>(type: "int", nullable: true),
                    LookingFor = table.Column<int>(type: "int", nullable: true),
                    PersonalityType = table.Column<int>(type: "int", nullable: true),
                    ZodiakSign = table.Column<int>(type: "int", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendRequests_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FriendRequests_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserImages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_ReceiverId",
                table: "FriendRequests",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_SenderId",
                table: "FriendRequests",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_UserId",
                table: "UserImages",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
