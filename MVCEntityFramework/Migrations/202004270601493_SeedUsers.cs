namespace MVCEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1ccb0125-6814-43bd-bc0f-29b46c780746', N'admin@vidly.com', 0, N'AK5iSI+NqhLytY8MVGLgc/x34gqxGaivaAiDnO9/n/nx5tsXKrt1KzL7BGvbnmsnWg==', N'5117a909-2de1-40c1-a905-532f7b8c81a7', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7073d6b9-4b60-4300-aca5-25c63d7db513', N'guest@vidly.com', 0, N'AM1ecHcQCNRLRggbusD1TrYXoXfl+4pJ0pJpgHq7UJMJZwwJ2FU7gfY8LSNoOM4f8w==', N'1a9a0357-0500-4026-8630-d311f7407afd', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'00b28227-1bf6-4496-a056-9637f974449e', N'CanManageMovies')
INSERT INTO[dbo].[AspNetUserRoles]([UserId], [RoleId]) VALUES(N'1ccb0125-6814-43bd-bc0f-29b46c780746', N'00b28227-1bf6-4496-a056-9637f974449e')");
        }
        
        public override void Down()
        {
        }
    }
}
