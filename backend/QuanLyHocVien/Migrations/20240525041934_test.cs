using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyHocVien.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhoaHoc",
                columns: table => new
                {
                    KhoaHocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoaHoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaHoc", x => x.KhoaHocId);
                });

            migrationBuilder.CreateTable(
                name: "LichHoc",
                columns: table => new
                {
                    LichHocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichHoc", x => x.LichHocId);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    MonHocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.MonHocId);
                });

            migrationBuilder.CreateTable(
                name: "PhanQuyen",
                columns: table => new
                {
                    PhanQuyenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyen", x => x.PhanQuyenId);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    TaiKhoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.TaiKhoanId);
                });

            migrationBuilder.CreateTable(
                name: "KhoaHocLichHoc",
                columns: table => new
                {
                    KhoaHocId = table.Column<int>(type: "int", nullable: false),
                    LichHocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaHocLichHoc", x => new { x.KhoaHocId, x.LichHocId });
                    table.ForeignKey(
                        name: "FK_KhoaHocLichHoc_KhoaHoc_KhoaHocId",
                        column: x => x.KhoaHocId,
                        principalTable: "KhoaHoc",
                        principalColumn: "KhoaHocId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhoaHocLichHoc_LichHoc_LichHocId",
                        column: x => x.LichHocId,
                        principalTable: "LichHoc",
                        principalColumn: "LichHocId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhoaHocMonHoc",
                columns: table => new
                {
                    KhoaHocId = table.Column<int>(type: "int", nullable: false),
                    MonHocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaHocMonHoc", x => new { x.MonHocId, x.KhoaHocId });
                    table.ForeignKey(
                        name: "FK_KhoaHocMonHoc_KhoaHoc_KhoaHocId",
                        column: x => x.KhoaHocId,
                        principalTable: "KhoaHoc",
                        principalColumn: "KhoaHocId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhoaHocMonHoc_MonHoc_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHoc",
                        principalColumn: "MonHocId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoanHocVien",
                columns: table => new
                {
                    TaiKhoanHocVienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanNameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoanHocVien", x => x.TaiKhoanHocVienId);
                    table.ForeignKey(
                        name: "FK_TaiKhoanHocVien_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "TaiKhoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoanLichHoc",
                columns: table => new
                {
                    TaiKhoanId = table.Column<int>(type: "int", nullable: false),
                    LichHocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoanLichHoc", x => new { x.TaiKhoanId, x.LichHocId });
                    table.ForeignKey(
                        name: "FK_TaiKhoanLichHoc_LichHoc_LichHocId",
                        column: x => x.LichHocId,
                        principalTable: "LichHoc",
                        principalColumn: "LichHocId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaiKhoanLichHoc_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "TaiKhoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoanPhanQuyen",
                columns: table => new
                {
                    TaiKhoanId = table.Column<int>(type: "int", nullable: false),
                    PhanQuyenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoanPhanQuyen", x => new { x.TaiKhoanId, x.PhanQuyenId });
                    table.ForeignKey(
                        name: "FK_TaiKhoanPhanQuyen_PhanQuyen_PhanQuyenId",
                        column: x => x.PhanQuyenId,
                        principalTable: "PhanQuyen",
                        principalColumn: "PhanQuyenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaiKhoanPhanQuyen_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "TaiKhoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhoaHocLichHoc_LichHocId",
                table: "KhoaHocLichHoc",
                column: "LichHocId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoaHocMonHoc_KhoaHocId",
                table: "KhoaHocMonHoc",
                column: "KhoaHocId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoanHocVien_TaiKhoanId",
                table: "TaiKhoanHocVien",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoanLichHoc_LichHocId",
                table: "TaiKhoanLichHoc",
                column: "LichHocId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoanPhanQuyen_PhanQuyenId",
                table: "TaiKhoanPhanQuyen",
                column: "PhanQuyenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhoaHocLichHoc");

            migrationBuilder.DropTable(
                name: "KhoaHocMonHoc");

            migrationBuilder.DropTable(
                name: "TaiKhoanHocVien");

            migrationBuilder.DropTable(
                name: "TaiKhoanLichHoc");

            migrationBuilder.DropTable(
                name: "TaiKhoanPhanQuyen");

            migrationBuilder.DropTable(
                name: "KhoaHoc");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "LichHoc");

            migrationBuilder.DropTable(
                name: "PhanQuyen");

            migrationBuilder.DropTable(
                name: "TaiKhoan");
        }
    }
}
