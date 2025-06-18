using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbCategorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nmCategoria = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    imUrl = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategorias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nmProduto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dsProduto = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    vlProduto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    imUrl = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    qtEstoque = table.Column<int>(type: "int", nullable: false),
                    dtCadastro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2025, 6, 17, 22, 52, 50, 213, DateTimeKind.Local).AddTicks(5776)),
                    categoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "fk_categorias_categoriasId",
                        column: x => x.categoriaId,
                        principalTable: "tbCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "tbCategorias",
                columns: new[] { "Id", "createdAt", "imUrl", "nmCategoria", "updatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6570), "cosmeticos.jpg", "Cosméticos", null },
                    { 2, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6602), "eletronicos.jpg", "Eletrônicos", null },
                    { 3, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6606), "informatica.jpg", "Informática", null },
                    { 4, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6608), "moveis.jpg", "Móveis", null },
                    { 5, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6611), "eletrodomesticos.jpg", "Eletrodomésticos", null },
                    { 6, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6613), "bebidas.jpg", "Bebidas", null },
                    { 7, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6615), "alimentos.jpg", "Alimentos", null },
                    { 8, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6617), "limpeza.jpg", "Limpeza", null },
                    { 9, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6619), "brinquedos.jpg", "Brinquedos", null },
                    { 10, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6621), "livros.jpg", "Livros", null },
                    { 11, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6624), "papelaria.jpg", "Papelaria", null },
                    { 12, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6626), "ferramentas.jpg", "Ferramentas", null },
                    { 13, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6628), "esportes.jpg", "Esportes", null },
                    { 14, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6630), "moda-masculina.jpg", "Moda Masculina", null },
                    { 15, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6632), "moda-feminina.jpg", "Moda Feminina", null },
                    { 16, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6634), "calcados.jpg", "Calçados", null },
                    { 17, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6636), "acessorios.jpg", "Acessórios", null },
                    { 18, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6638), "jardim.jpg", "Jardim", null },
                    { 19, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6640), "automotivo.jpg", "Automotivo", null },
                    { 20, new DateTime(2025, 6, 17, 22, 52, 50, 212, DateTimeKind.Local).AddTicks(6642), "petshop.jpg", "Pet Shop", null }
                });

            migrationBuilder.InsertData(
                table: "tbProdutos",
                columns: new[] { "Id", "categoriaId", "dsProduto", "imUrl", "nmProduto", "qtEstoque", "vlProduto" },
                values: new object[,]
                {
                    { 1, 1, "Creme de barbear fragrância de menta", "creme-barbear.jpg", "Creme de Barbear", 50, 68.50m },
                    { 2, 1, "Hidratante para pele oleosa 50ml", "hidratante-facial.jpg", "Hidratante Facial", 30, 89.90m },
                    { 3, 1, "Shampoo para controle de caspa 300ml", "shampoo-anticaspa.jpg", "Shampoo Anticaspa", 45, 32.75m },
                    { 4, 1, "Batom matte de longa duração", "batom-matte.jpg", "Batom Matte", 60, 45.00m },
                    { 5, 1, "Máscara para cílios à prova d'água", "mascara-cilios.jpg", "Máscara de Cílios", 35, 39.90m },
                    { 6, 1, "Perfume 100ml fragrância amadeirada", "perfume-masculino.jpg", "Perfume Masculino", 25, 199.90m },
                    { 7, 1, "Desodorante antitranspirante 50ml", "desodorante-rollon.jpg", "Desodorante Roll On", 70, 18.50m },
                    { 8, 1, "Sabonete líquido facial 200ml", "sabonete-liquido.jpg", "Sabonete Líquido", 40, 28.75m },
                    { 9, 1, "Protetor solar facial oil free", "protetor-solar.jpg", "Protetor Solar FPS 50", 55, 79.90m },
                    { 10, 1, "Condicionador para cabelos danificados", "condicionador.jpg", "Condicionador Reparador", 38, 42.50m },
                    { 11, 1, "Esmalte de longa duração", "esmalte-vermelho.jpg", "Esmalte Vermelho", 85, 12.90m },
                    { 12, 1, "Demaquilante para olhos sensíveis", "demaquilante.jpg", "Demaquilante Bifásico", 28, 34.90m },
                    { 13, 1, "Creme hidratante para mãos 75ml", "creme-maos.jpg", "Creme para Mãos", 42, 27.50m },
                    { 14, 1, "Tônico adstringente para pele oleosa", "tonico-facial.jpg", "Tônico Facial", 33, 65.00m },
                    { 15, 1, "Máscara de argila para limpeza profunda", "mascara-facial.jpg", "Máscara Facial", 47, 49.90m },
                    { 16, 1, "Pó compacto matte cor bege médio", "po-compacto.jpg", "Pó Compacto", 29, 58.75m },
                    { 17, 1, "Delineador de precisão à prova d'água", "delineador.jpg", "Delineador Líquido", 51, 36.90m },
                    { 18, 1, "Água micelar 400ml para limpeza facial", "agua-micelar.jpg", "Água Micelar", 36, 72.50m },
                    { 19, 1, "Serum anti-idade com vitamina C", "serum-facial.jpg", "Serum Facial", 22, 115.00m },
                    { 20, 1, "Loção calmante para após o barbear", "pos-barba.jpg", "Loção Pós-Barba", 43, 54.90m },
                    { 21, 2, "Fone sem fio com cancelamento de ruído", "fone-bluetooth.jpg", "Fone Bluetooth", 25, 299.90m },
                    { 22, 2, "Relógio inteligente com monitor cardíaco", "smartwatch.jpg", "Smartwatch", 15, 799.00m },
                    { 23, 2, "Caixa de som à prova d'água 20W", "caixa-som.jpg", "Caixa de Som Portátil", 20, 349.90m },
                    { 24, 2, "Tablet 128GB RAM 4GB", "tablet.jpg", "Tablet 10 Polegadas", 12, 1299.00m },
                    { 25, 2, "Power bank 10000mAh", "powerbank.jpg", "Carregador Portátil", 35, 89.90m },
                    { 26, 2, "Webcam com microfone integrado", "webcam.jpg", "Webcam Full HD", 18, 199.90m },
                    { 27, 2, "Teclado gamer RGB switches azuis", "teclado-mecanico.jpg", "Teclado Mecânico", 14, 279.90m },
                    { 28, 2, "Mouse óptico 1600DPI", "mouse-semfio.jpg", "Mouse Sem Fio", 30, 59.90m },
                    { 29, 2, "Monitor Full HD IPS", "monitor.jpg", "Monitor 24 Polegadas", 8, 899.00m },
                    { 30, 2, "HD externo USB 3.0", "hd-externo.jpg", "HD Externo 1TB", 22, 299.90m },
                    { 31, 2, "Leitor de e-books 6 polegadas", "kindle.jpg", "Kindle 10a Geração", 17, 399.00m },
                    { 32, 2, "Drone com câmera 4K", "drone.jpg", "Drone DJI Mini", 5, 2499.00m },
                    { 33, 2, "Fita de LED 5m controlável por app", "fita-led.jpg", "Fita LED RGB", 28, 79.90m },
                    { 34, 2, "Console retro com 200 jogos", "console-retro.jpg", "Console Portátil", 10, 199.90m },
                    { 35, 2, "Projetor portátil 1080p", "projetor.jpg", "Projetor Mini", 7, 599.00m },
                    { 36, 2, "TV 4K Android TV", "smarttv.jpg", "Smart TV 50 Polegadas", 6, 2399.00m },
                    { 37, 2, "Soundbar com subwoofer sem fio", "soundbar.jpg", "Soundbar 2.1", 9, 499.00m },
                    { 38, 2, "Câmera fotográfica com impressão", "camera-instantanea.jpg", "Câmera Instantânea", 13, 349.90m },
                    { 39, 2, "Roteador dual band 5Ghz", "roteador.jpg", "Roteador Wi-Fi 6", 11, 399.00m },
                    { 40, 2, "Pen drive USB 3.2", "pendrive.jpg", "Pen Drive 128GB", 40, 59.90m },
                    { 41, 3, "Notebook 8GB RAM SSD 256GB", "notebook-i5.jpg", "Notebook i5", 10, 3299.00m },
                    { 42, 3, "Mouse com 6 botões programáveis", "mouse-gamer.jpg", "Mouse Gamer", 30, 159.90m },
                    { 43, 3, "Teclado slim Bluetooth", "teclado-semfio.jpg", "Teclado Sem Fio", 25, 129.90m },
                    { 44, 3, "Monitor gamer 144Hz", "monitor-gamer.jpg", "Monitor 27''", 8, 1599.00m },
                    { 45, 3, "SSD NVMe Leitura 3500MB/s", "ssd.jpg", "SSD 512GB", 18, 299.90m },
                    { 46, 3, "Webcam Full HD com microfone", "webcam-hd.jpg", "Webcam HD", 14, 189.90m },
                    { 47, 3, "Impressora jato de tinta", "impressora.jpg", "Impressora Multifuncional", 9, 499.00m },
                    { 48, 3, "Headset com microfone retrátil", "headset-gamer.jpg", "Headset Gamer", 12, 229.90m },
                    { 49, 3, "Hub USB-C 4 portas", "hub-usb.jpg", "Hub USB", 30, 79.90m },
                    { 50, 3, "Notebook RTX 3050 16GB RAM", "notebook-gamer.jpg", "Notebook Gamer", 5, 6299.00m },
                    { 51, 3, "Mouse pad 90x40cm antiderrapante", "mousepad.jpg", "Mouse Pad Grande", 40, 49.90m },
                    { 52, 3, "Cadeira ergonômica com apoio lombar", "cadeira-gamer.jpg", "Cadeira Gamer", 7, 1299.00m },
                    { 53, 3, "Roteador dual band AC1200", "roteador-wifi.jpg", "Roteador Wi-Fi", 15, 249.90m },
                    { 54, 3, "Pendrive USB 3.0", "pendrive-256gb.jpg", "Pendrive 256GB", 22, 99.90m },
                    { 55, 3, "HD externo USB 3.2", "hd-externo-2tb.jpg", "HD Externo 2TB", 11, 499.90m },
                    { 56, 3, "Cooler com 3 ventoinhas", "cooler-notebook.jpg", "Cooler para Notebook", 19, 89.90m },
                    { 57, 3, "Tablet digitalizador A5", "mesa-digitalizadora.jpg", "Mesa Digitalizadora", 8, 399.00m },
                    { 58, 3, "Fonte universal 65W", "fonte-notebook.jpg", "Fonte Notebook", 13, 119.90m },
                    { 59, 3, "Seletor HDMI 4 portas", "switch-hdmi.jpg", "Switch HDMI", 10, 159.90m },
                    { 60, 3, "Kit sem fio 2.4GHz", "kit-teclado-mouse.jpg", "Kit Teclado e Mouse", 25, 149.90m },
                    { 61, 4, "Sofá retrátil em couro sintético", "sofa-3lugares.jpg", "Sofá 3 Lugares", 5, 1899.00m },
                    { 62, 4, "Cadeira ergonômica com regulagem de altura", "cadeira-escritorio.jpg", "Cadeira de Escritório", 12, 499.90m },
                    { 63, 4, "Mesa de centro em madeira maciça", "mesa-centro.jpg", "Mesa de Centro", 8, 349.90m },
                    { 64, 4, "Estante 5 prateleiras 1,80m", "estante-livros.jpg", "Estante para Livros", 6, 429.00m },
                    { 65, 4, "Cama box com cabeceira estofada", "cama-casal.jpg", "Cama Box Casal", 9, 899.00m },
                    { 66, 4, "Guarda-roupa espelhado grande", "guarda-roupa.jpg", "Guarda-Roupa 6 Portas", 5, 1299.00m },
                    { 67, 4, "Rack moderno para TV até 65''", "rack-tv.jpg", "Rack para TV", 7, 579.90m },
                    { 68, 4, "Banqueta alta com encosto", "banqueta-bar.jpg", "Banqueta de Bar", 15, 229.90m },
                    { 69, 4, "Cômoda em MDF 80cm", "comoda.jpg", "Cômoda 4 Gavetas", 11, 399.00m },
                    { 70, 4, "Poltrona de descanso reclinável", "poltrona.jpg", "Poltrona Reclinável", 4, 699.00m },
                    { 71, 4, "Painel flutuante para TV e objetos", "painel-tv.jpg", "Painel para TV", 8, 429.90m },
                    { 72, 4, "Criado mudo com gaveta", "criado-mudo.jpg", "Criado Mudo", 14, 179.90m },
                    { 73, 4, "Sofá que vira cama de solteiro", "sofa-cama.jpg", "Sofá-cama", 6, 999.00m },
                    { 74, 4, "Espreguiçadeira para jardim", "espreguicadeira.jpg", "Espreguiçadeira", 10, 299.90m },
                    { 75, 4, "Mesa para computador 120cm", "mesa-computador.jpg", "Mesa de Computador", 9, 349.00m },
                    { 76, 4, "Banco estreito para entrada", "banco-corredor.jpg", "Banco de Corredor", 13, 159.90m },
                    { 77, 4, "Aparador de cozinha 2 portas", "aparador.jpg", "Aparador", 7, 279.90m },
                    { 78, 4, "Cadeira de balanço em vime", "cadeira-balanco.jpg", "Cadeira de Balanço", 5, 459.00m },
                    { 79, 4, "Armário suspenso 60cm", "armario-cozinha.jpg", "Armário para Cozinha", 8, 329.90m },
                    { 80, 4, "Mesa e 4 cadeiras para jardim", "conjunto-jardim.jpg", "Conjunto de Jardim", 4, 899.00m },
                    { 81, 5, "Geladeira duplex 375L branca", "geladeira-frostfree.jpg", "Geladeira Frost Free", 7, 2899.00m },
                    { 82, 5, "Fogão inox com forno elétrico", "fogao-5bocas.jpg", "Fogão 5 Bocas", 12, 1599.90m },
                    { 83, 5, "Lavadora 12kg 15 programas", "maquina-lavar.jpg", "Máquina de Lavar", 9, 2199.00m },
                    { 84, 5, "Micro-ondas grill 1100W", "microondas.jpg", "Micro-ondas 32L", 15, 599.90m },
                    { 85, 5, "Lava-louças 8 serviços", "lava-loucas.jpg", "Lava-Louças", 5, 2499.00m },
                    { 86, 5, "Ar condicionado 9000 BTUs", "ar-condicionado.jpg", "Ar Condicionado Split", 8, 1899.00m },
                    { 87, 5, "Purificador com geladeira", "purificador.jpg", "Purificador de Água", 14, 799.90m },
                    { 88, 5, "Cooktop de vidro 220V", "cooktop.jpg", "Cooktop 4 Bocas", 10, 899.00m },
                    { 89, 5, "Ventilador 3 pás 110V", "ventilador-teto.jpg", "Ventilador de Teto", 18, 249.90m },
                    { 90, 5, "Secadora 8kg capacidade", "secadora.jpg", "Secadora de Roupas", 6, 1799.00m },
                    { 91, 5, "Aspirador vertical sem fio", "aspirador.jpg", "Aspirador de Pó", 20, 399.90m },
                    { 92, 5, "Ferro 1800W com base cerâmica", "ferro-vapor.jpg", "Ferro a Vapor", 25, 129.90m },
                    { 93, 5, "Forno 35L com timer digital", "forno-eletrico.jpg", "Forno Elétrico", 11, 349.90m },
                    { 94, 5, "Liquidificador 800W 6 velocidades", "liquidificador.jpg", "Liquidificador", 22, 179.90m },
                    { 95, 5, "Batedeira 500W 5 velocidades", "batedeira.jpg", "Batedeira Planetária", 13, 299.90m },
                    { 96, 5, "Cafeteira 15 xícaras programável", "cafeteira.jpg", "Cafeteira Elétrica", 17, 199.90m },
                    { 97, 5, "Grill dupla face 2000W", "grill.jpg", "Grill Elétrico", 9, 229.90m },
                    { 98, 5, "Processador 500W 3 acessórios", "processador.jpg", "Processador de Alimentos", 12, 279.90m },
                    { 99, 5, "Depurador com filtro HEPA", "depurador.jpg", "Depurador de Ar", 7, 599.00m },
                    { 100, 5, "Robô aspirador inteligente", "robo-aspirador.jpg", "Robô Aspirador", 5, 1299.00m }
                });

            migrationBuilder.CreateIndex(
                name: "ix_categorias_nome",
                table: "tbCategorias",
                column: "nmCategoria");

            migrationBuilder.CreateIndex(
                name: "ix_produtos_categoriaId",
                table: "tbProdutos",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "ix_produtos_descricao",
                table: "tbProdutos",
                column: "dsProduto",
                filter: "[nome] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_produtos_nome",
                table: "tbProdutos",
                column: "nmProduto",
                filter: "[nome] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbProdutos");

            migrationBuilder.DropTable(
                name: "tbCategorias");
        }
    }
}
