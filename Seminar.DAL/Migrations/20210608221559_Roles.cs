using Microsoft.EntityFrameworkCore.Migrations;

namespace Seminar.DAL.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a197098d-6910-498c-9632-b3739fa6e0af", "85ae7506-0684-41f0-8b0b-a648e336f392", "AppRole", "Admin", "Administrator" },
                    { "d94c9a42-03d4-46c0-811d-cef074c912c8", "b29c93db-0b58-4b2a-b179-13d773dc4105", "AppRole", "Writer", "Writer" },
                    { "e904d01f-c86e-412e-9202-80e975492f59", "c4325860-85ab-457b-a150-c8becff2acb5", "AppRole", "Editor", "Editor" },
                    { "fc06cd40-a86a-4a31-a7f9-9c21eaa50a48", "a4171cbb-60ab-4911-b1cf-c0866ac32e45", "AppRole", "Reviewer", "Reviewer" },
                    { "3c916073-dbca-4f51-820f-e85014fdbc27", "9024554a-3d18-4737-8d70-b4144e687896", "AppRole", "User", "User" },
                    { "ffd3c364-ed31-49ab-96d9-6103139cdf53", "6704ba6e-1d0f-4f66-ad42-0b03e42ad951", "AppRole", "Guest", "Visitor" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c916073-dbca-4f51-820f-e85014fdbc27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a197098d-6910-498c-9632-b3739fa6e0af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d94c9a42-03d4-46c0-811d-cef074c912c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e904d01f-c86e-412e-9202-80e975492f59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc06cd40-a86a-4a31-a7f9-9c21eaa50a48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffd3c364-ed31-49ab-96d9-6103139cdf53");
        }
    }
}
