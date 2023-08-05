using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cartoon.Repository.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DienVienLongTieng",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDienVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DienVienLongTieng", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanVat",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tenNhanVat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhimHoatHinh",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenPhim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhaXuatBan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaoDien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamSanXuat = table.Column<int>(type: "int", nullable: false),
                    KeyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhimHoatHinh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DienVienTGLongTieng",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaPhim = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaDienVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienVienId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KeyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DienVienTGLongTieng", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DienVienTGLongTieng_DienVienLongTieng_DienVienId",
                        column: x => x.DienVienId,
                        principalTable: "DienVienLongTieng",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DienVienTGLongTieng_PhimHoatHinh_MaPhim",
                        column: x => x.MaPhim,
                        principalTable: "PhimHoatHinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TapPhim",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenTapPhim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaPhim = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KeyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TapPhim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TapPhim_PhimHoatHinh_MaPhim",
                        column: x => x.MaPhim,
                        principalTable: "PhimHoatHinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVatTrongTapPhim",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tinhTrangNhanVat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trangThaiNhanVat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaNhanVat = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaTapPhim = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KeyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVatTrongTapPhim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanVatTrongTapPhim_NhanVat_MaNhanVat",
                        column: x => x.MaNhanVat,
                        principalTable: "NhanVat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVatTrongTapPhim_TapPhim_MaTapPhim",
                        column: x => x.MaTapPhim,
                        principalTable: "TapPhim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DienVienTGLongTieng_DienVienId",
                table: "DienVienTGLongTieng",
                column: "DienVienId");

            migrationBuilder.CreateIndex(
                name: "IX_DienVienTGLongTieng_MaPhim",
                table: "DienVienTGLongTieng",
                column: "MaPhim");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVatTrongTapPhim_MaNhanVat",
                table: "NhanVatTrongTapPhim",
                column: "MaNhanVat");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVatTrongTapPhim_MaTapPhim",
                table: "NhanVatTrongTapPhim",
                column: "MaTapPhim");

            migrationBuilder.CreateIndex(
                name: "IX_TapPhim_MaPhim",
                table: "TapPhim",
                column: "MaPhim");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DienVienTGLongTieng");

            migrationBuilder.DropTable(
                name: "NhanVatTrongTapPhim");

            migrationBuilder.DropTable(
                name: "DienVienLongTieng");

            migrationBuilder.DropTable(
                name: "NhanVat");

            migrationBuilder.DropTable(
                name: "TapPhim");

            migrationBuilder.DropTable(
                name: "PhimHoatHinh");
        }
    }
}
