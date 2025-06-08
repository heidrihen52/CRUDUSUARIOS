using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDUSUARIOS.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARGO",
                columns: table => new
                {
                    IdCargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CARGO__6C9856253D5D0CB8", x => x.IdCargo);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    ApellidoPaterno = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    ApellidoMaterno = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Correo = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IdCargo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__USUARIO__5B65BF97086E3128", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK__USUARIO__IdCargo__3B75D760",
                        column: x => x.IdCargo,
                        principalTable: "CARGO",
                        principalColumn: "IdCargo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_IdCargo",
                table: "USUARIO",
                column: "IdCargo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "CARGO");
        }
    }
}
