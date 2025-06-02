using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniMate2.Migrations
{
    /// <inheritdoc />
    public partial class Exam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    University = table.Column<string>(type: "TEXT", nullable: true),
                    Faculty = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<int>(type: "INTEGER", nullable: true),
                    Orientation = table.Column<int>(type: "INTEGER", nullable: true),
                    IsSmoking = table.Column<int>(type: "INTEGER", nullable: true),
                    IsDrinking = table.Column<int>(type: "INTEGER", nullable: true),
                    IsBanned = table.Column<bool>(type: "INTEGER", nullable: false),
                    LookingFor = table.Column<int>(type: "INTEGER", nullable: true),
                    PersonalityType = table.Column<int>(type: "INTEGER", nullable: true),
                    ZodiakSign = table.Column<int>(type: "INTEGER", nullable: true),
                    Bio = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "AbuseReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReporterId = table.Column<string>(type: "text", nullable: false),
                    ReportedUserId = table.Column<string>(type: "text", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbuseReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbuseReports_AspNetUsers_ReportedUserId",
                        column: x => x.ReportedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbuseReports_AspNetUsers_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SenderId = table.Column<string>(type: "TEXT", nullable: true),
                    ReceiverId = table.Column<string>(type: "TEXT", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LikerId = table.Column<string>(type: "TEXT", nullable: false),
                    LikedId = table.Column<string>(type: "TEXT", nullable: false),
                    LikedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_LikedId",
                        column: x => x.LikedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_LikerId",
                        column: x => x.LikerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDislikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DislikingUserId = table.Column<string>(type: "TEXT", nullable: false),
                    DislikedUserId = table.Column<string>(type: "TEXT", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    SerialNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserImages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15fbaefc-4e92-4b9c-af3a-d545bd248bd9", "2d59c08a-7a14-4f03-9b99-1620a82a6469", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Faculty", "FirstName", "Gender", "IsBanned", "IsDrinking", "IsSmoking", "LastName", "LockoutEnabled", "LockoutEnd", "LookingFor", "NormalizedEmail", "NormalizedUserName", "Orientation", "PasswordHash", "PersonalityType", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "University", "UserId", "UserName", "ZodiakSign" },
                values: new object[,]
                {
                    { "0037407e-ed16-4bae-8e83-94aa7de52c8c", 0, "Loves hiking and outdoor adventures.", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), "12a8188d-a5fe-4049-981f-38b2c31551a4", "alice.johnson@example.com", false, "Engineering", "Alice", 1, false, 2, 1, "Johnson", false, null, 1, "ALICE.JOHNSON@EXAMPLE.COM", "ALICE.JOHNSON@EXAMPLE.COM", 2, "AQAAAAIAAYagAAAAEEPuc+p3zRBPfv64RXSFHbwzMBqClj1MNaKwwbwgrxPjv02QlKbT8HoHbYdzJPJ/+w==", null, null, false, "bc91dd87-9065-4663-ac36-7992a6e23779", false, "Tech University", null, "alice.johnson@example.com", null },
                    { "079841eb-c617-4034-bdd2-14f111282c41", 0, "Passionate about graphic design and photography.", new DateTime(1992, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), "6f32e25d-7eaf-4913-b7c2-f53a60bf84e8", "carol.davis@example.com", false, "Design", "Carol", 0, false, 1, 2, "Davis", false, null, 3, "CAROL.DAVIS@EXAMPLE.COM", "CAROL.DAVIS@EXAMPLE.COM", 3, "AQAAAAIAAYagAAAAENyIuMmkP3SahLU4uRmpZVCe50E4dhZSTpgZFmDxWKqbdvrIlhRUkyZRQk+3Nurzdg==", null, null, false, "15924624-2c1a-4618-8591-bdc8b6405eff", false, "Arts College", null, "carol.davis@example.com", null },
                    { "172cbcf0-db76-4f4e-8e9c-e814c95c7b42", 0, "Bio2", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "66a74d62-91db-4d2f-bcdb-3446fd08c642", "user2@example.com", false, "Faculty2", "FirstName2", 0, false, 0, 1, "LastName2", false, null, 0, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEBg+hKK7T5m2tupDlyqils3TdV+gGxBQ7SckNxPjSsZONRLbqmaZCqZyV293Sg1KkA==", null, null, false, "71732e41-20bb-4bc1-9f5c-c3d1671ce19b", false, "University2", null, "user2@example.com", null },
                    { "2f4dc10e-2cb5-4727-94df-a4468ba9c3d6", 0, "Bio5", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "b9d3ac8b-aed8-4a9b-84cc-c3d78b775a64", "user1@example.com", false, "Faculty2", "FirstName2", 2, false, 0, 1, "LastName2", false, null, 0, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAEDD0QxEQJP2R89GzFznv4415ae2uIarvf5G5Fo2b2x8TGLq67/mFMSZDx24kP908CQ==", null, null, false, "90192600-5ae5-438d-8f5c-0c954878962f", false, "University1", null, "user1@example.com", null },
                    { "3dbffd3e-9477-4b39-92c8-2b242090b768", 0, "Avid cyclist and technology enthusiast.", new DateTime(1990, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "b4d70ab7-7228-4731-98ad-07dc7a0d4c2d", "david.miller@example.com", false, "Mechanical", "David", 0, false, 0, 1, "Miller", false, null, 2, "DAVID.MILLER@EXAMPLE.COM", "DAVID.MILLER@EXAMPLE.COM", 1, "AQAAAAIAAYagAAAAEL7qdQ52LgKkv+Chqzkg4auk+buNq6ONq8Or05eOqVX+HCywkfp1OBpcTv1YI5rOIQ==", null, null, false, "6dd2f3d8-e5b8-41a9-95ce-dc50a37944ab", false, "Engineering Institute", null, "david.miller@example.com", null },
                    { "7bdc661a-655e-4c54-86e1-8f118272c707", 0, "Enjoys cooking and traveling.", new DateTime(1988, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), "8450e169-1d67-466b-b0bc-914110ec4598", "bob.smith@example.com", false, "Business", "Bob", 0, false, 0, 0, "Smith", false, null, 0, "BOB.SMITH@EXAMPLE.COM", "BOB.SMITH@EXAMPLE.COM", 0, "AQAAAAIAAYagAAAAELizYoQ3iK04l3ts431pZEtlEyDvy0LB2HkjdFD14Lpn6OEWJgX/0kztK5v9bqvGWg==", null, null, false, "24fb37db-b5b9-4550-b65d-e0ee33a3e663", false, "State University", null, "bob.smith@example.com", null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("4b01af09-42d9-4354-89b0-5cba68d0e768"), "Workshop on emerging technologies.", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Tech Institute", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Workshop" },
                    { new Guid("7342b1b0-2a87-4e43-9c91-976a9f7660e2"), "A meetup for community members.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), "City Park", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Community Meetup" },
                    { new Guid("f91c543b-d755-4621-bee0-2440080c1b89"), "Annual technology conference.", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Convention Center", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Tech Conference" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "15fbaefc-4e92-4b9c-af3a-d545bd248bd9", "2f4dc10e-2cb5-4727-94df-a4468ba9c3d6" });

            migrationBuilder.CreateIndex(
                name: "IX_AbuseReports_ReportedUserId",
                table: "AbuseReports",
                column: "ReportedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbuseReports_ReporterId",
                table: "AbuseReports",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_ReceiverId",
                table: "FriendRequests",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_SenderId",
                table: "FriendRequests",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikedId",
                table: "Likes",
                column: "LikedId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikerId",
                table: "Likes",
                column: "LikerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDislikes_DislikedUserId",
                table: "UserDislikes",
                column: "DislikedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDislikes_DislikingUserId",
                table: "UserDislikes",
                column: "DislikingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_UserId",
                table: "UserImages",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbuseReports");

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
                name: "Likes");

            migrationBuilder.DropTable(
                name: "UserDislikes");

            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
