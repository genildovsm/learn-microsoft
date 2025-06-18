using apiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace apiCatalogo.Context.Mapping;

/// <summary>
/// Classe de mapeamento
/// </summary>
public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    /// <summary>
    /// Mapeamento dos atributos da entidade Produto
    /// </summary>
    /// <param name="b"></param>
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> b)
    {
        b.ToTable("tbProdutos");

        b.HasKey(x => x.Id);

        b.Property(x => x.Nome)
        .HasColumnName("nmProduto")
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired();

        b.Property(x => x.Descricao)
        .HasColumnName("dsProduto")
        .HasColumnType("varchar")
        .HasMaxLength(255)
        .IsRequired();

        b.Property(x => x.Valor)
        .HasColumnName("vlProduto")
        .HasColumnType("decimal(10,2)")
        .IsRequired();

        b.Property(x => x.ImagemUrl)
        .HasColumnName("imUrl")
        .HasColumnType("varchar")
        .HasMaxLength(255);

        b.Property(x => x.QuantidadeEstoque)
        .HasColumnName("qtEstoque")
        .HasColumnType("int");

        b.Property(x => x.DataCadastro)
        .HasColumnName("dtCadastro")
        .HasColumnType("datetime")
        .HasDefaultValue(DateTime.Now);

        b.Property(x => x.CategoriaId)
        .HasColumnName("categoriaId")
        .HasColumnType("int")
        .IsRequired();

        b.HasIndex(x => x.Nome, "ix_produtos_nome")
        .HasFilter("[nome] IS NOT NULL");

        b.HasIndex(x => x.Descricao, "ix_produtos_descricao")
        .HasFilter("[nome] IS NOT NULL");

        b.HasIndex(x => x.CategoriaId, "ix_produtos_categoriaId");

        #region Foreigh Keys

        b.HasOne(x => x.Categoria)
        .WithMany(x => x.Produtos)
        .HasForeignKey(x => x.CategoriaId)
        .HasConstraintName("fk_categorias_categoriasId");

        #endregion      

        b.HasData(

        #region Cosméticos

            new { Id = 1, Nome = "Creme de Barbear", Descricao = "Creme de barbear fragrância de menta", Valor = 68.50m, ImagemUrl = "creme-barbear.jpg", QuantidadeEstoque = 50, CategoriaId = 1 },
            new { Id = 2, Nome = "Hidratante Facial", Descricao = "Hidratante para pele oleosa 50ml", Valor = 89.90m, ImagemUrl = "hidratante-facial.jpg", QuantidadeEstoque = 30, CategoriaId = 1 },
            new { Id = 3, Nome = "Shampoo Anticaspa", Descricao = "Shampoo para controle de caspa 300ml", Valor = 32.75m, ImagemUrl = "shampoo-anticaspa.jpg", QuantidadeEstoque = 45, CategoriaId = 1 },
            new { Id = 4, Nome = "Batom Matte", Descricao = "Batom matte de longa duração", Valor = 45.00m, ImagemUrl = "batom-matte.jpg", QuantidadeEstoque = 60, CategoriaId = 1 },
            new { Id = 5, Nome = "Máscara de Cílios", Descricao = "Máscara para cílios à prova d'água", Valor = 39.90m, ImagemUrl = "mascara-cilios.jpg", QuantidadeEstoque = 35, CategoriaId = 1 },
            new { Id = 6, Nome = "Perfume Masculino", Descricao = "Perfume 100ml fragrância amadeirada", Valor = 199.90m, ImagemUrl = "perfume-masculino.jpg", QuantidadeEstoque = 25, CategoriaId = 1 },
            new { Id = 7, Nome = "Desodorante Roll On", Descricao = "Desodorante antitranspirante 50ml", Valor = 18.50m, ImagemUrl = "desodorante-rollon.jpg", QuantidadeEstoque = 70, CategoriaId = 1 },
            new { Id = 8, Nome = "Sabonete Líquido", Descricao = "Sabonete líquido facial 200ml", Valor = 28.75m, ImagemUrl = "sabonete-liquido.jpg", QuantidadeEstoque = 40, CategoriaId = 1 },
            new { Id = 9, Nome = "Protetor Solar FPS 50", Descricao = "Protetor solar facial oil free", Valor = 79.90m, ImagemUrl = "protetor-solar.jpg", QuantidadeEstoque = 55, CategoriaId = 1 },
            new { Id = 10, Nome = "Condicionador Reparador", Descricao = "Condicionador para cabelos danificados", Valor = 42.50m, ImagemUrl = "condicionador.jpg", QuantidadeEstoque = 38, CategoriaId = 1 },
            new { Id = 11, Nome = "Esmalte Vermelho", Descricao = "Esmalte de longa duração", Valor = 12.90m, ImagemUrl = "esmalte-vermelho.jpg", QuantidadeEstoque = 85, CategoriaId = 1 },
            new { Id = 12, Nome = "Demaquilante Bifásico", Descricao = "Demaquilante para olhos sensíveis", Valor = 34.90m, ImagemUrl = "demaquilante.jpg", QuantidadeEstoque = 28, CategoriaId = 1 },
            new { Id = 13, Nome = "Creme para Mãos", Descricao = "Creme hidratante para mãos 75ml", Valor = 27.50m, ImagemUrl = "creme-maos.jpg", QuantidadeEstoque = 42, CategoriaId = 1 },
            new { Id = 14, Nome = "Tônico Facial", Descricao = "Tônico adstringente para pele oleosa", Valor = 65.00m, ImagemUrl = "tonico-facial.jpg", QuantidadeEstoque = 33, CategoriaId = 1 },
            new { Id = 15, Nome = "Máscara Facial", Descricao = "Máscara de argila para limpeza profunda", Valor = 49.90m, ImagemUrl = "mascara-facial.jpg", QuantidadeEstoque = 47, CategoriaId = 1 },
            new { Id = 16, Nome = "Pó Compacto", Descricao = "Pó compacto matte cor bege médio", Valor = 58.75m, ImagemUrl = "po-compacto.jpg", QuantidadeEstoque = 29, CategoriaId = 1 },
            new { Id = 17, Nome = "Delineador Líquido", Descricao = "Delineador de precisão à prova d'água", Valor = 36.90m, ImagemUrl = "delineador.jpg", QuantidadeEstoque = 51, CategoriaId = 1 },
            new { Id = 18, Nome = "Água Micelar", Descricao = "Água micelar 400ml para limpeza facial", Valor = 72.50m, ImagemUrl = "agua-micelar.jpg", QuantidadeEstoque = 36, CategoriaId = 1 },
            new { Id = 19, Nome = "Serum Facial", Descricao = "Serum anti-idade com vitamina C", Valor = 115.00m, ImagemUrl = "serum-facial.jpg", QuantidadeEstoque = 22, CategoriaId = 1 },
            new { Id = 20, Nome = "Loção Pós-Barba", Descricao = "Loção calmante para após o barbear", Valor = 54.90m, ImagemUrl = "pos-barba.jpg", QuantidadeEstoque = 43, CategoriaId = 1 },

        #endregion

        #region Eletrônicos

            new { Id = 21, Nome = "Fone Bluetooth", Descricao = "Fone sem fio com cancelamento de ruído", Valor = 299.90m, ImagemUrl = "fone-bluetooth.jpg", QuantidadeEstoque = 25, CategoriaId = 2 },
            new { Id = 22, Nome = "Smartwatch", Descricao = "Relógio inteligente com monitor cardíaco", Valor = 799.00m, ImagemUrl = "smartwatch.jpg", QuantidadeEstoque = 15, CategoriaId = 2 },
            new { Id = 23, Nome = "Caixa de Som Portátil", Descricao = "Caixa de som à prova d'água 20W", Valor = 349.90m, ImagemUrl = "caixa-som.jpg", QuantidadeEstoque = 20, CategoriaId = 2 },
            new { Id = 24, Nome = "Tablet 10 Polegadas", Descricao = "Tablet 128GB RAM 4GB", Valor = 1299.00m, ImagemUrl = "tablet.jpg", QuantidadeEstoque = 12, CategoriaId = 2 },
            new { Id = 25, Nome = "Carregador Portátil", Descricao = "Power bank 10000mAh", Valor = 89.90m, ImagemUrl = "powerbank.jpg", QuantidadeEstoque = 35, CategoriaId = 2 },
            new { Id = 26, Nome = "Webcam Full HD", Descricao = "Webcam com microfone integrado", Valor = 199.90m, ImagemUrl = "webcam.jpg", QuantidadeEstoque = 18, CategoriaId = 2 },
            new { Id = 27, Nome = "Teclado Mecânico", Descricao = "Teclado gamer RGB switches azuis", Valor = 279.90m, ImagemUrl = "teclado-mecanico.jpg", QuantidadeEstoque = 14, CategoriaId = 2 },
            new { Id = 28, Nome = "Mouse Sem Fio", Descricao = "Mouse óptico 1600DPI", Valor = 59.90m, ImagemUrl = "mouse-semfio.jpg", QuantidadeEstoque = 30, CategoriaId = 2 },
            new { Id = 29, Nome = "Monitor 24 Polegadas", Descricao = "Monitor Full HD IPS", Valor = 899.00m, ImagemUrl = "monitor.jpg", QuantidadeEstoque = 8, CategoriaId = 2 },
            new { Id = 30, Nome = "HD Externo 1TB", Descricao = "HD externo USB 3.0", Valor = 299.90m, ImagemUrl = "hd-externo.jpg", QuantidadeEstoque = 22, CategoriaId = 2 },
            new { Id = 31, Nome = "Kindle 10a Geração", Descricao = "Leitor de e-books 6 polegadas", Valor = 399.00m, ImagemUrl = "kindle.jpg", QuantidadeEstoque = 17, CategoriaId = 2 },
            new { Id = 32, Nome = "Drone DJI Mini", Descricao = "Drone com câmera 4K", Valor = 2499.00m, ImagemUrl = "drone.jpg", QuantidadeEstoque = 5, CategoriaId = 2 },
            new { Id = 33, Nome = "Fita LED RGB", Descricao = "Fita de LED 5m controlável por app", Valor = 79.90m, ImagemUrl = "fita-led.jpg", QuantidadeEstoque = 28, CategoriaId = 2 },
            new { Id = 34, Nome = "Console Portátil", Descricao = "Console retro com 200 jogos", Valor = 199.90m, ImagemUrl = "console-retro.jpg", QuantidadeEstoque = 10, CategoriaId = 2 },
            new { Id = 35, Nome = "Projetor Mini", Descricao = "Projetor portátil 1080p", Valor = 599.00m, ImagemUrl = "projetor.jpg", QuantidadeEstoque = 7, CategoriaId = 2 },
            new { Id = 36, Nome = "Smart TV 50 Polegadas", Descricao = "TV 4K Android TV", Valor = 2399.00m, ImagemUrl = "smarttv.jpg", QuantidadeEstoque = 6, CategoriaId = 2 },
            new { Id = 37, Nome = "Soundbar 2.1", Descricao = "Soundbar com subwoofer sem fio", Valor = 499.00m, ImagemUrl = "soundbar.jpg", QuantidadeEstoque = 9, CategoriaId = 2 },
            new { Id = 38, Nome = "Câmera Instantânea", Descricao = "Câmera fotográfica com impressão", Valor = 349.90m, ImagemUrl = "camera-instantanea.jpg", QuantidadeEstoque = 13, CategoriaId = 2 },
            new { Id = 39, Nome = "Roteador Wi-Fi 6", Descricao = "Roteador dual band 5Ghz", Valor = 399.00m, ImagemUrl = "roteador.jpg", QuantidadeEstoque = 11, CategoriaId = 2 },
            new { Id = 40, Nome = "Pen Drive 128GB", Descricao = "Pen drive USB 3.2", Valor = 59.90m, ImagemUrl = "pendrive.jpg", QuantidadeEstoque = 40, CategoriaId = 2 },

        #endregion

        #region Informática

            new { Id = 41, Nome = "Notebook i5", Descricao = "Notebook 8GB RAM SSD 256GB", Valor = 3299.00m, ImagemUrl = "notebook-i5.jpg", QuantidadeEstoque = 10, CategoriaId = 3 },
            new { Id = 42, Nome = "Mouse Gamer", Descricao = "Mouse com 6 botões programáveis", Valor = 159.90m, ImagemUrl = "mouse-gamer.jpg", QuantidadeEstoque = 30, CategoriaId = 3 },
            new { Id = 43, Nome = "Teclado Sem Fio", Descricao = "Teclado slim Bluetooth", Valor = 129.90m, ImagemUrl = "teclado-semfio.jpg", QuantidadeEstoque = 25, CategoriaId = 3 },
            new { Id = 44, Nome = "Monitor 27''", Descricao = "Monitor gamer 144Hz", Valor = 1599.00m, ImagemUrl = "monitor-gamer.jpg", QuantidadeEstoque = 8, CategoriaId = 3 },
            new { Id = 45, Nome = "SSD 512GB", Descricao = "SSD NVMe Leitura 3500MB/s", Valor = 299.90m, ImagemUrl = "ssd.jpg", QuantidadeEstoque = 18, CategoriaId = 3 },
            new { Id = 46, Nome = "Webcam HD", Descricao = "Webcam Full HD com microfone", Valor = 189.90m, ImagemUrl = "webcam-hd.jpg", QuantidadeEstoque = 14, CategoriaId = 3 },
            new { Id = 47, Nome = "Impressora Multifuncional", Descricao = "Impressora jato de tinta", Valor = 499.00m, ImagemUrl = "impressora.jpg", QuantidadeEstoque = 9, CategoriaId = 3 },
            new { Id = 48, Nome = "Headset Gamer", Descricao = "Headset com microfone retrátil", Valor = 229.90m, ImagemUrl = "headset-gamer.jpg", QuantidadeEstoque = 12, CategoriaId = 3 },
            new { Id = 49, Nome = "Hub USB", Descricao = "Hub USB-C 4 portas", Valor = 79.90m, ImagemUrl = "hub-usb.jpg", QuantidadeEstoque = 30, CategoriaId = 3 },
            new { Id = 50, Nome = "Notebook Gamer", Descricao = "Notebook RTX 3050 16GB RAM", Valor = 6299.00m, ImagemUrl = "notebook-gamer.jpg", QuantidadeEstoque = 5, CategoriaId = 3 },
            new { Id = 51, Nome = "Mouse Pad Grande", Descricao = "Mouse pad 90x40cm antiderrapante", Valor = 49.90m, ImagemUrl = "mousepad.jpg", QuantidadeEstoque = 40, CategoriaId = 3 },
            new { Id = 52, Nome = "Cadeira Gamer", Descricao = "Cadeira ergonômica com apoio lombar", Valor = 1299.00m, ImagemUrl = "cadeira-gamer.jpg", QuantidadeEstoque = 7, CategoriaId = 3 },
            new { Id = 53, Nome = "Roteador Wi-Fi", Descricao = "Roteador dual band AC1200", Valor = 249.90m, ImagemUrl = "roteador-wifi.jpg", QuantidadeEstoque = 15, CategoriaId = 3 },
            new { Id = 54, Nome = "Pendrive 256GB", Descricao = "Pendrive USB 3.0", Valor = 99.90m, ImagemUrl = "pendrive-256gb.jpg", QuantidadeEstoque = 22, CategoriaId = 3 },
            new { Id = 55, Nome = "HD Externo 2TB", Descricao = "HD externo USB 3.2", Valor = 499.90m, ImagemUrl = "hd-externo-2tb.jpg", QuantidadeEstoque = 11, CategoriaId = 3 },
            new { Id = 56, Nome = "Cooler para Notebook", Descricao = "Cooler com 3 ventoinhas", Valor = 89.90m, ImagemUrl = "cooler-notebook.jpg", QuantidadeEstoque = 19, CategoriaId = 3 },
            new { Id = 57, Nome = "Mesa Digitalizadora", Descricao = "Tablet digitalizador A5", Valor = 399.00m, ImagemUrl = "mesa-digitalizadora.jpg", QuantidadeEstoque = 8, CategoriaId = 3 },
            new { Id = 58, Nome = "Fonte Notebook", Descricao = "Fonte universal 65W", Valor = 119.90m, ImagemUrl = "fonte-notebook.jpg", QuantidadeEstoque = 13, CategoriaId = 3 },
            new { Id = 59, Nome = "Switch HDMI", Descricao = "Seletor HDMI 4 portas", Valor = 159.90m, ImagemUrl = "switch-hdmi.jpg", QuantidadeEstoque = 10, CategoriaId = 3 },
            new { Id = 60, Nome = "Kit Teclado e Mouse", Descricao = "Kit sem fio 2.4GHz", Valor = 149.90m, ImagemUrl = "kit-teclado-mouse.jpg", QuantidadeEstoque = 25, CategoriaId = 3 },

        #endregion

        #region Móveis

            new { Id = 61, Nome = "Sofá 3 Lugares", Descricao = "Sofá retrátil em couro sintético", Valor = 1899.00m, ImagemUrl = "sofa-3lugares.jpg", QuantidadeEstoque = 5, CategoriaId = 4 },
            new { Id = 62, Nome = "Cadeira de Escritório", Descricao = "Cadeira ergonômica com regulagem de altura", Valor = 499.90m, ImagemUrl = "cadeira-escritorio.jpg", QuantidadeEstoque = 12, CategoriaId = 4 },
            new { Id = 63, Nome = "Mesa de Centro", Descricao = "Mesa de centro em madeira maciça", Valor = 349.90m, ImagemUrl = "mesa-centro.jpg", QuantidadeEstoque = 8, CategoriaId = 4 },
            new { Id = 64, Nome = "Estante para Livros", Descricao = "Estante 5 prateleiras 1,80m", Valor = 429.00m, ImagemUrl = "estante-livros.jpg", QuantidadeEstoque = 6, CategoriaId = 4 },
            new { Id = 65, Nome = "Cama Box Casal", Descricao = "Cama box com cabeceira estofada", Valor = 899.00m, ImagemUrl = "cama-casal.jpg", QuantidadeEstoque = 9, CategoriaId = 4 },
            new { Id = 66, Nome = "Guarda-Roupa 6 Portas", Descricao = "Guarda-roupa espelhado grande", Valor = 1299.00m, ImagemUrl = "guarda-roupa.jpg", QuantidadeEstoque = 5, CategoriaId = 4 },
            new { Id = 67, Nome = "Rack para TV", Descricao = "Rack moderno para TV até 65''", Valor = 579.90m, ImagemUrl = "rack-tv.jpg", QuantidadeEstoque = 7, CategoriaId = 4 },
            new { Id = 68, Nome = "Banqueta de Bar", Descricao = "Banqueta alta com encosto", Valor = 229.90m, ImagemUrl = "banqueta-bar.jpg", QuantidadeEstoque = 15, CategoriaId = 4 },
            new { Id = 69, Nome = "Cômoda 4 Gavetas", Descricao = "Cômoda em MDF 80cm", Valor = 399.00m, ImagemUrl = "comoda.jpg", QuantidadeEstoque = 11, CategoriaId = 4 },
            new { Id = 70, Nome = "Poltrona Reclinável", Descricao = "Poltrona de descanso reclinável", Valor = 699.00m, ImagemUrl = "poltrona.jpg", QuantidadeEstoque = 4, CategoriaId = 4 },
            new { Id = 71, Nome = "Painel para TV", Descricao = "Painel flutuante para TV e objetos", Valor = 429.90m, ImagemUrl = "painel-tv.jpg", QuantidadeEstoque = 8, CategoriaId = 4 },
            new { Id = 72, Nome = "Criado Mudo", Descricao = "Criado mudo com gaveta", Valor = 179.90m, ImagemUrl = "criado-mudo.jpg", QuantidadeEstoque = 14, CategoriaId = 4 },
            new { Id = 73, Nome = "Sofá-cama", Descricao = "Sofá que vira cama de solteiro", Valor = 999.00m, ImagemUrl = "sofa-cama.jpg", QuantidadeEstoque = 6, CategoriaId = 4 },
            new { Id = 74, Nome = "Espreguiçadeira", Descricao = "Espreguiçadeira para jardim", Valor = 299.90m, ImagemUrl = "espreguicadeira.jpg", QuantidadeEstoque = 10, CategoriaId = 4 },
            new { Id = 75, Nome = "Mesa de Computador", Descricao = "Mesa para computador 120cm", Valor = 349.00m, ImagemUrl = "mesa-computador.jpg", QuantidadeEstoque = 9, CategoriaId = 4 },
            new { Id = 76, Nome = "Banco de Corredor", Descricao = "Banco estreito para entrada", Valor = 159.90m, ImagemUrl = "banco-corredor.jpg", QuantidadeEstoque = 13, CategoriaId = 4 },
            new { Id = 77, Nome = "Aparador", Descricao = "Aparador de cozinha 2 portas", Valor = 279.90m, ImagemUrl = "aparador.jpg", QuantidadeEstoque = 7, CategoriaId = 4 },
            new { Id = 78, Nome = "Cadeira de Balanço", Descricao = "Cadeira de balanço em vime", Valor = 459.00m, ImagemUrl = "cadeira-balanco.jpg", QuantidadeEstoque = 5, CategoriaId = 4 },
            new { Id = 79, Nome = "Armário para Cozinha", Descricao = "Armário suspenso 60cm", Valor = 329.90m, ImagemUrl = "armario-cozinha.jpg", QuantidadeEstoque = 8, CategoriaId = 4 },
            new { Id = 80, Nome = "Conjunto de Jardim", Descricao = "Mesa e 4 cadeiras para jardim", Valor = 899.00m, ImagemUrl = "conjunto-jardim.jpg", QuantidadeEstoque = 4, CategoriaId = 4 },

        #endregion

        #region Eletrodomésticos

            new { Id = 81, Nome = "Geladeira Frost Free", Descricao = "Geladeira duplex 375L branca", Valor = 2899.00m, ImagemUrl = "geladeira-frostfree.jpg", QuantidadeEstoque = 7, CategoriaId = 5 },
            new { Id = 82, Nome = "Fogão 5 Bocas", Descricao = "Fogão inox com forno elétrico", Valor = 1599.90m, ImagemUrl = "fogao-5bocas.jpg", QuantidadeEstoque = 12, CategoriaId = 5 },
            new { Id = 83, Nome = "Máquina de Lavar", Descricao = "Lavadora 12kg 15 programas", Valor = 2199.00m, ImagemUrl = "maquina-lavar.jpg", QuantidadeEstoque = 9, CategoriaId = 5 },
            new { Id = 84, Nome = "Micro-ondas 32L", Descricao = "Micro-ondas grill 1100W", Valor = 599.90m, ImagemUrl = "microondas.jpg", QuantidadeEstoque = 15, CategoriaId = 5 },
            new { Id = 85, Nome = "Lava-Louças", Descricao = "Lava-louças 8 serviços", Valor = 2499.00m, ImagemUrl = "lava-loucas.jpg", QuantidadeEstoque = 5, CategoriaId = 5 },
            new { Id = 86, Nome = "Ar Condicionado Split", Descricao = "Ar condicionado 9000 BTUs", Valor = 1899.00m, ImagemUrl = "ar-condicionado.jpg", QuantidadeEstoque = 8, CategoriaId = 5 },
            new { Id = 87, Nome = "Purificador de Água", Descricao = "Purificador com geladeira", Valor = 799.90m, ImagemUrl = "purificador.jpg", QuantidadeEstoque = 14, CategoriaId = 5 },
            new { Id = 88, Nome = "Cooktop 4 Bocas", Descricao = "Cooktop de vidro 220V", Valor = 899.00m, ImagemUrl = "cooktop.jpg", QuantidadeEstoque = 10, CategoriaId = 5 },
            new { Id = 89, Nome = "Ventilador de Teto", Descricao = "Ventilador 3 pás 110V", Valor = 249.90m, ImagemUrl = "ventilador-teto.jpg", QuantidadeEstoque = 18, CategoriaId = 5 },
            new { Id = 90, Nome = "Secadora de Roupas", Descricao = "Secadora 8kg capacidade", Valor = 1799.00m, ImagemUrl = "secadora.jpg", QuantidadeEstoque = 6, CategoriaId = 5 },
            new { Id = 91, Nome = "Aspirador de Pó", Descricao = "Aspirador vertical sem fio", Valor = 399.90m, ImagemUrl = "aspirador.jpg", QuantidadeEstoque = 20, CategoriaId = 5 },
            new { Id = 92, Nome = "Ferro a Vapor", Descricao = "Ferro 1800W com base cerâmica", Valor = 129.90m, ImagemUrl = "ferro-vapor.jpg", QuantidadeEstoque = 25, CategoriaId = 5 },
            new { Id = 93, Nome = "Forno Elétrico", Descricao = "Forno 35L com timer digital", Valor = 349.90m, ImagemUrl = "forno-eletrico.jpg", QuantidadeEstoque = 11, CategoriaId = 5 },
            new { Id = 94, Nome = "Liquidificador", Descricao = "Liquidificador 800W 6 velocidades", Valor = 179.90m, ImagemUrl = "liquidificador.jpg", QuantidadeEstoque = 22, CategoriaId = 5 },
            new { Id = 95, Nome = "Batedeira Planetária", Descricao = "Batedeira 500W 5 velocidades", Valor = 299.90m, ImagemUrl = "batedeira.jpg", QuantidadeEstoque = 13, CategoriaId = 5 },
            new { Id = 96, Nome = "Cafeteira Elétrica", Descricao = "Cafeteira 15 xícaras programável", Valor = 199.90m, ImagemUrl = "cafeteira.jpg", QuantidadeEstoque = 17, CategoriaId = 5 },
            new { Id = 97, Nome = "Grill Elétrico", Descricao = "Grill dupla face 2000W", Valor = 229.90m, ImagemUrl = "grill.jpg", QuantidadeEstoque = 9, CategoriaId = 5 },
            new { Id = 98, Nome = "Processador de Alimentos", Descricao = "Processador 500W 3 acessórios", Valor = 279.90m, ImagemUrl = "processador.jpg", QuantidadeEstoque = 12, CategoriaId = 5 },
            new { Id = 99, Nome = "Depurador de Ar", Descricao = "Depurador com filtro HEPA", Valor = 599.00m, ImagemUrl = "depurador.jpg", QuantidadeEstoque = 7, CategoriaId = 5 },
            new { Id = 100, Nome = "Robô Aspirador", Descricao = "Robô aspirador inteligente", Valor = 1299.00m, ImagemUrl = "robo-aspirador.jpg", QuantidadeEstoque = 5, CategoriaId = 5 }

            #endregion

        );
    }
}
