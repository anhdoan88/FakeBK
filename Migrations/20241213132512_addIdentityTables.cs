using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FakeBK.Migrations
{
    /// <inheritdoc />
    public partial class addIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "class",
            //    columns: table => new
            //    {
            //        id = table.Column<decimal>(type: "numeric", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("class_pkey", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "orgperson",
            //    columns: table => new
            //    {
            //        id = table.Column<decimal>(type: "numeric", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("orgperson_pkey", x => x.id);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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

            //migrationBuilder.CreateTable(
            //    name: "relative",
            //    columns: table => new
            //    {
            //        orgp_id = table.Column<decimal>(type: "numeric", nullable: false),
            //        name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("relative_pkey", x => new { x.orgp_id, x.name });
            //        table.ForeignKey(
            //            name: "relative_orgp_id_fkey",
            //            column: x => x.orgp_id,
            //            principalTable: "orgperson",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.SetNull);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "student",
            //    columns: table => new
            //    {
            //        id = table.Column<decimal>(type: "numeric", nullable: false),
            //        orgp_id = table.Column<decimal>(type: "numeric", nullable: false),
            //        class_id = table.Column<decimal>(type: "numeric", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("student_pkey", x => x.id);
            //        table.ForeignKey(
            //            name: "student_class_id_fkey",
            //            column: x => x.class_id,
            //            principalTable: "class",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.SetNull);
            //        table.ForeignKey(
            //            name: "student_orgp_id_fkey",
            //            column: x => x.orgp_id,
            //            principalTable: "orgperson",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.SetNull);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "course",
            //    columns: table => new
            //    {
            //        id = table.Column<decimal>(type: "numeric", nullable: false),
            //        name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
            //        dept_id = table.Column<decimal>(type: "numeric", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("course_pkey", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "grade",
            //    columns: table => new
            //    {
            //        student_id = table.Column<decimal>(type: "numeric", nullable: false),
            //        course_id = table.Column<decimal>(type: "numeric", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("grade_pkey", x => new { x.student_id, x.course_id });
            //        table.ForeignKey(
            //            name: "grade_course_id_fkey",
            //            column: x => x.course_id,
            //            principalTable: "course",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.SetNull);
            //        table.ForeignKey(
            //            name: "grade_student_id_fkey",
            //            column: x => x.student_id,
            //            principalTable: "student",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.SetNull);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "department",
            //    columns: table => new
            //    {
            //        id = table.Column<decimal>(type: "numeric", nullable: false),
            //        headteach_id = table.Column<decimal>(type: "numeric", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("department_pkey", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "teacher",
            //    columns: table => new
            //    {
            //        id = table.Column<decimal>(type: "numeric", nullable: false),
            //        orgp_id = table.Column<decimal>(type: "numeric", nullable: false),
            //        dept_id = table.Column<decimal>(type: "numeric", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("teacher_pkey", x => x.id);
            //        table.ForeignKey(
            //            name: "teacher_dept_id_fkey",
            //            column: x => x.dept_id,
            //            principalTable: "department",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.SetNull);
            //        table.ForeignKey(
            //            name: "teacher_orgp_id_fkey",
            //            column: x => x.orgp_id,
            //            principalTable: "orgperson",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.SetNull);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "teachclass",
            //    columns: table => new
            //    {
            //        class_id = table.Column<decimal>(type: "numeric", nullable: false),
            //        course_id = table.Column<decimal>(type: "numeric", nullable: false),
            //        teacher_id = table.Column<decimal>(type: "numeric", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("teachclass_pkey", x => new { x.class_id, x.course_id });
            //        table.ForeignKey(
            //            name: "teachclass_class_id_fkey",
            //            column: x => x.class_id,
            //            principalTable: "class",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.SetNull);
            //        table.ForeignKey(
            //            name: "teachclass_course_id_fkey",
            //            column: x => x.course_id,
            //            principalTable: "course",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.SetNull);
            //        table.ForeignKey(
            //            name: "teachclass_teacher_id_fkey",
            //            column: x => x.teacher_id,
            //            principalTable: "teacher",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.SetNull);
            //    });

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_course_dept_id",
            //    table: "course",
            //    column: "dept_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_department_headteach_id",
            //    table: "department",
            //    column: "headteach_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_grade_course_id",
            //    table: "grade",
            //    column: "course_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_student_class_id",
            //    table: "student",
            //    column: "class_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_student_orgp_id",
            //    table: "student",
            //    column: "orgp_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_teachclass_course_id",
            //    table: "teachclass",
            //    column: "course_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_teachclass_teacher_id",
            //    table: "teachclass",
            //    column: "teacher_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_teacher_dept_id",
            //    table: "teacher",
            //    column: "dept_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_teacher_orgp_id",
            //    table: "teacher",
            //    column: "orgp_id");

            //migrationBuilder.AddForeignKey(
            //    name: "course_dept_id_fkey",
            //    table: "course",
            //    column: "dept_id",
            //    principalTable: "department",
            //    principalColumn: "id",
            //    onDelete: ReferentialAction.SetNull);

            //migrationBuilder.AddForeignKey(
            //    name: "fk_head_dept",
            //    table: "department",
            //    column: "headteach_id",
            //    principalTable: "teacher",
            //    principalColumn: "id",
            //    onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "teacher_dept_id_fkey",
            //    table: "teacher");

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

            //migrationBuilder.DropTable(
            //    name: "grade");

            //migrationBuilder.DropTable(
            //    name: "relative");

            //migrationBuilder.DropTable(
            //    name: "teachclass");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "student");

            //migrationBuilder.DropTable(
            //    name: "course");

            //migrationBuilder.DropTable(
            //    name: "class");

            //migrationBuilder.DropTable(
            //    name: "department");

            //migrationBuilder.DropTable(
            //    name: "teacher");

            //migrationBuilder.DropTable(
            //    name: "orgperson");
        }
    }
}
