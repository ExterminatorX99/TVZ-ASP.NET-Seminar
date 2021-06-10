using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Seminar.DAL.Migrations
{
    public partial class CategoryDoesntHaveArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Category_CategoryID",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Image_HeaderImageID",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Articles_ArticleID",
                table: "Comment");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Articles_HeaderImageID",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

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

            migrationBuilder.DropColumn(
                name: "AccessLevel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "HeaderImageID",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ArticleID",
                table: "Comments",
                newName: "IX_Comments_ArticleID");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Writers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "ID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ff733ed8-c0ec-45a0-9f1a-35f1b9a9cf4c", "a8444ce1-6605-4d4c-97dd-fab391e8b453", "Admin", "Administrator" },
                    { "11447acb-29d5-465b-a429-3efcb0aa6315", "a148b937-b398-43d6-a66e-3666df268e71", "Writer", "Writer" },
                    { "c097a117-64eb-4eee-873d-24be1bccb40f", "c36d2173-4463-43b6-83e3-1a82c0a900f7", "Editor", "Editor" },
                    { "644414f7-d093-43fa-b1bb-b208eef29f5e", "6c5596ca-03bb-4892-87e3-c1ca04faf159", "User", "User" },
                    { "1c390ba1-6c75-445a-b3dd-761633a70a9e", "4816694b-c442-4055-bbc6-58be37e08893", "Guest", "Guest" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ff733ed8-c0ec-45a0-9f1a-35f1b9a9cf4c", 0, "e668bf16-2bde-4f79-bae1-a9c3d3f91892", "kkos1@tvz.hr", true, false, null, "KKOS1@TVZ.HR", "KKOS1@TVZ.HR", "AQAAAAEAACcQAAAAEC8o+n97E/auGboF72xEtq4Q+h3POpHH4+6dSO9MbAqCTPlJlQE3qGsa7pOTKqkMqA==", "091 143 1325", false, "", false, "kkos1@tvz.hr" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ff733ed8-c0ec-45a0-9f1a-35f1b9a9cf4c", "ff733ed8-c0ec-45a0-9f1a-35f1b9a9cf4c" });

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Categories_CategoryID",
                table: "Articles",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_ArticleID",
                table: "Comments",
                column: "ArticleID",
                principalTable: "Articles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Categories_CategoryID",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_ArticleID",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11447acb-29d5-465b-a429-3efcb0aa6315");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c390ba1-6c75-445a-b3dd-761633a70a9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "644414f7-d093-43fa-b1bb-b208eef29f5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c097a117-64eb-4eee-873d-24be1bccb40f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ff733ed8-c0ec-45a0-9f1a-35f1b9a9cf4c", "ff733ed8-c0ec-45a0-9f1a-35f1b9a9cf4c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff733ed8-c0ec-45a0-9f1a-35f1b9a9cf4c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff733ed8-c0ec-45a0-9f1a-35f1b9a9cf4c");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ArticleID",
                table: "Comment",
                newName: "IX_Comment_ArticleID");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Writers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<int>(
                name: "AccessLevel",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HeaderImageID",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ID);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Articles_HeaderImageID",
                table: "Articles",
                column: "HeaderImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Category_CategoryID",
                table: "Articles",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Image_HeaderImageID",
                table: "Articles",
                column: "HeaderImageID",
                principalTable: "Image",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Articles_ArticleID",
                table: "Comment",
                column: "ArticleID",
                principalTable: "Articles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
