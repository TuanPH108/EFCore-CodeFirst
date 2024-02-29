using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Framework_Core.Migrations
{
    /// <inheritdoc />
    public partial class PostgreSample : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Store");

            migrationBuilder.CreateTable(
                name: "product",
                schema: "Store",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    note = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    discount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "Store",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_order",
                schema: "Store",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_order_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "Store",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_order_product",
                schema: "Store",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    note = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    discount = table.Column<double>(type: "double precision", nullable: false),
                    user_order_id = table.Column<string>(type: "text", nullable: false),
                    product_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_order_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_order_product_product_product_id",
                        column: x => x.product_id,
                        principalSchema: "Store",
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_order_product_user_order_user_order_id",
                        column: x => x.user_order_id,
                        principalSchema: "Store",
                        principalTable: "user_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_order_user_id",
                schema: "Store",
                table: "user_order",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_order_product_product_id",
                schema: "Store",
                table: "user_order_product",
                column: "product_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_order_product_user_order_id",
                schema: "Store",
                table: "user_order_product",
                column: "user_order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_order_product",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "product",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "user_order",
                schema: "Store");

            migrationBuilder.DropTable(
                name: "user",
                schema: "Store");
        }
    }
}
