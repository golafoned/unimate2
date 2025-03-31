using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniMate2.Models.Domain;
using UniMate2.Models.Domain.Enums;

namespace UniMate2.Data;

public class ServerDbContext : IdentityDbContext<User>
{
    public ServerDbContext(DbContextOptions<ServerDbContext> options)
        : base(options)
    {
    }

    public DbSet<FriendRequest> FriendRequests { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<UserImage> UserImages { get; set; }
    public DbSet<Like> Likes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure FriendRequest entity
        modelBuilder.Entity<FriendRequest>()
            .HasOne(fr => fr.Requester)
            .WithMany()
            .HasForeignKey(fr => fr.RequesterId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<FriendRequest>()
            .HasOne(fr => fr.Recipient)
            .WithMany()
            .HasForeignKey(fr => fr.RecipientId)
            .OnDelete(DeleteBehavior.Restrict);

        List<User> users = new List<User>
        {
            new User
            {
                FirstName = "FirstName2",
                LastName = "LastName2",
                BirthDate = new DateTime(2000, 1, 1),
                University = "University1",
                Faculty = "Faculty2",
                Gender = Gender.Quadrobist,
                Orientation = Orientation.Heterosexual,
                IsSmoking = AddictionStatus.No,
                IsDrinking = AddictionStatus.Yes,
                LookingFor = LookingForEnum.Friendship,
                NormalizedUserName = "USER1@EXAMPLE.COM",
                NormalizedEmail = "USER1@EXAMPLE.COM",
            },
            new User
            {
                FirstName = "FirstName2",
                LastName = "LastName2",
                BirthDate = new DateTime(2002, 1, 1),
                University = "University2",
                Faculty = "Faculty2",
                Gender = Gender.Male,
                Orientation = Orientation.Heterosexual,
                IsSmoking = AddictionStatus.No,
                IsDrinking = AddictionStatus.Yes,
                LookingFor = LookingForEnum.Friendship,
                Bio = "Bio2",
                Email = "user2@example.com",
                UserName = "user2@example.com",
                NormalizedUserName = "USER2@EXAMPLE.COM",
                NormalizedEmail = "USER2@EXAMPLE.COM",
            },
            new User
            {
                FirstName = "Alice",
                LastName = "Johnson",
                BirthDate = new DateTime(1995, 5, 15),
                University = "Tech University",
                Faculty = "Engineering",
                Gender = Gender.Female,
                Orientation = Orientation.Bisexual,
                IsSmoking = AddictionStatus.No,
                IsDrinking = AddictionStatus.NotOften,
                LookingFor = LookingForEnum.Relationship,
                Bio = "Loves hiking and outdoor adventures.",
                Email = "alice.johnson@example.com",
                UserName = "alice.johnson@example.com",
                NormalizedUserName = "ALICE.JOHNSON@EXAMPLE.COM",
                NormalizedEmail = "ALICE.JOHNSON@EXAMPLE.COM",
            },
            new User
            {
                FirstName = "Bob",
                LastName = "Smith",
                BirthDate = new DateTime(1988, 8, 22),
                University = "State University",
                Faculty = "Business",
                Gender = Gender.Male,
                Orientation = Orientation.Heterosexual,
                IsSmoking = AddictionStatus.Yes,
                IsDrinking = AddictionStatus.Yes,
                LookingFor = LookingForEnum.Friendship,
                Bio = "Enjoys cooking and traveling.",
                Email = "bob.smith@example.com",
                UserName = "bob.smith@example.com",
                NormalizedUserName = "BOB.SMITH@EXAMPLE.COM",
                NormalizedEmail = "BOB.SMITH@EXAMPLE.COM",
            },
            new User
            {
                FirstName = "Carol",
                LastName = "Davis",
                BirthDate = new DateTime(1992, 3, 30),
                University = "Arts College",
                Faculty = "Design",
                Gender = Gender.Male,
                Orientation = Orientation.Other,
                IsSmoking = AddictionStatus.NotOften,
                IsDrinking = AddictionStatus.No,
                LookingFor = LookingForEnum.NewAcquaintances,
                Bio = "Passionate about graphic design and photography.",
                Email = "carol.davis@example.com",
                UserName = "carol.davis@example.com",
                NormalizedUserName = "CAROL.DAVIS@EXAMPLE.COM",
                NormalizedEmail = "CAROL.DAVIS@EXAMPLE.COM",
            },
            new User
            {
                FirstName = "David",
                LastName = "Miller",
                BirthDate = new DateTime(1990, 7, 19),
                University = "Engineering Institute",
                Faculty = "Mechanical",
                Gender = Gender.Male,
                Orientation = Orientation.Homosexual,
                IsSmoking = AddictionStatus.No,
                IsDrinking = AddictionStatus.Yes,
                LookingFor = LookingForEnum.JustCommunication,
                Bio = "Avid cyclist and technology enthusiast.",
                Email = "david.miller@example.com",
                UserName = "david.miller@example.com",
                NormalizedUserName = "DAVID.MILLER@EXAMPLE.COM",
                NormalizedEmail = "DAVID.MILLER@EXAMPLE.COM",
            },
        };

        var hasher = new PasswordHasher<User>();

        users.ForEach(user =>
        {
            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, "Password123!");
        });

        List<Event> events = new List<Event>
        {
            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Community Meetup",
                Description = "A meetup for community members.",
                StartDate = new DateTime(2023, 10, 15),
                EndDate = new DateTime(2023, 10, 15),
                Location = "City Park",
            },
            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Tech Conference",
                Description = "Annual technology conference.",
                StartDate = new DateTime(2023, 11, 20),
                EndDate = new DateTime(2023, 11, 22),
                Location = "Convention Center",
            },
            new Event
            {
                Id = Guid.NewGuid(),
                Title = "Workshop",
                Description = "Workshop on emerging technologies.",
                StartDate = new DateTime(2023, 12, 10),
                EndDate = new DateTime(2023, 12, 10),
                Location = "Tech Institute",
            },
        };

        modelBuilder.Entity<Event>().HasData(events);
        modelBuilder.Entity<User>().HasData(users);
    }
}
