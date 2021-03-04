using Microsoft.EntityFrameworkCore.Migrations;

namespace SpreadJsDemoApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GangJingAnZhuang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableHeadId = table.Column<int>(type: "int", nullable: false),
                    ZhuJingJianJuSj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZhuJingJianJuSc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZhuJingJianJuPc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KuJingSj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KuJingSc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KuJingPc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuJiaWaiJingSj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuJiaWaiJingSc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuJiaWaiJingPc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GangJingChangDuSj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GangJingChangDuSc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GangJingChangDuPc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GaoChengSj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GaoChengSc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GaoChengPc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouDuSj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouDuSc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouDuPc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GangJingAnZhuang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostionTemp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Row = table.Column<int>(type: "int", nullable: false),
                    Col = table.Column<int>(type: "int", nullable: false),
                    RowCount = table.Column<int>(type: "int", nullable: false),
                    ColCount = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostionTemp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableNamespace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtoNameSpace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableDtoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableDtoDataName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstanceCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShuiNiHunLingTu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableHeadId = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BanHouDuSj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BanHouDuSc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BanHouDuPc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShenDuSj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShenDuSc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GaoChaSj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GaoChaSc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShunZhiDuSj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShunZhiDuSc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XiShu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuanBanLv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShuiNiHunLingTu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableHead",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CBDW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JLDW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignTest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignReview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignRecord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableHead", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GangJingAnZhuang");

            migrationBuilder.DropTable(
                name: "PostionTemp");

            migrationBuilder.DropTable(
                name: "Relation");

            migrationBuilder.DropTable(
                name: "ShuiNiHunLingTu");

            migrationBuilder.DropTable(
                name: "TableHead");
        }
    }
}
