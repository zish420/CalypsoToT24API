using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalypsoToT24API.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FTTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageCalypso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalypsoEventId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostingId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostingVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T24Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostingLinkedId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedT24Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TradeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TradeVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductFamily = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessingOrg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PostingCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DebitAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Financial = table.Column<bool>(type: "bit", nullable: false),
                    CounterpartyExternalReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SettlementMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpotRate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MaturityDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PrincipalBeneficiaryInternal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrincipalIntermediaryInternal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FTTransactions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FTTransactions");
        }
    }
}
