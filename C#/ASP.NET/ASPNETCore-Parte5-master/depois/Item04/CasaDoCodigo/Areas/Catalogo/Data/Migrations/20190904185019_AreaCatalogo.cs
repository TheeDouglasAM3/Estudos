using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CasaDoCodigo.Areas.Catalogo.Data.Migrations
{
    public partial class AreaCatalogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoriaId = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Livros de Programação / Lógica" },
                    { 21, "Livros de Business / Agile" },
                    { 20, "Livros de Business / Gestão" },
                    { 19, "Livros de Business / Marketing Digital" },
                    { 18, "Livros de Business / Startups" },
                    { 17, "Livros de Infraestrutura / Outros" },
                    { 16, "Livros de Infraestrutura / Dados" },
                    { 15, "Livros de Infraestrutura / Redes" },
                    { 14, "Livros de Front-end / Outros" },
                    { 13, "Livros de Front-end / JavaScript" },
                    { 22, "Livros de Business / Outros" },
                    { 12, "Livros de Front-end / HTML e CSS" },
                    { 10, "Livros de Mobile / Multiplataforma" },
                    { 9, "Livros de Mobile / Android" },
                    { 8, "Livros de Mobile / IOS" },
                    { 7, "Livros de Programação / Outros" },
                    { 6, "Livros de Programação / Funcional" },
                    { 5, "Livros de Programação / Games" },
                    { 4, "Livros de Programação / PHP" },
                    { 3, "Livros de Programação / .NET" },
                    { 2, "Livros de Programação / Java" },
                    { 11, "Livros de Mobile / Outros" },
                    { 23, "Livros de Design e UX / Geral" }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "CategoriaId", "Codigo", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, 1, "001", "Lógica de Programação: Crie seus primeiros programas usando Javascript e HTML", 49.90m },
                    { 123, 13, "123", "Dominando JavaScript com jQuery", 49.90m },
                    { 124, 13, "124", "Mean: Full stack JavaScript para aplicações web com MongoDB, Express, Angular e Node", 49.90m },
                    { 125, 13, "125", "Crie aplicações com Angular: O novo framework do Google", 49.90m },
                    { 126, 13, "126", "Cangaceiro JavaScript: Uma aventura no sertão da programação", 49.90m },
                    { 127, 13, "127", "Desenvolva jogos com HTML5 Canvas e JavaScript", 49.90m },
                    { 128, 13, "128", "Coletânea Front-end: Uma antologia da comunidade front-end brasileira", 49.90m },
                    { 129, 13, "129", "ECMAScript 6: Entre de cabeça no futuro do JavaScript", 49.90m },
                    { 130, 13, "130", "Meteor: Criando aplicações web real-time com JavaScript", 49.90m },
                    { 131, 13, "131", "Vue.js: Construa aplicações incríveis", 49.90m },
                    { 122, 12, "122", "Turbine seu CSS: Folhas de estilo inteligentes com Sass", 49.90m },
                    { 132, 13, "132", "Front-end com Vue.js: Da teoria à prática sem complicações", 49.90m },
                    { 134, 13, "134", "jQuery Mobile: Desenvolva interfaces para múltiplos dispositivos", 49.90m },
                    { 135, 13, "135", "Ember.js: Conheça o framework para aplicações web ambiciosas", 49.90m },
                    { 136, 14, "136", "Guia Front-End: O caminho das pedras para ser um dev Front-End", 49.90m },
                    { 137, 14, "137", "Introdução à Web Semântica: A inteligência da informação", 49.90m },
                    { 138, 14, "138", "Progressive Web Apps: Construa aplicações progressivas com React", 49.90m },
                    { 139, 15, "139", "Desconstruindo a Web: As tecnologias por trás de uma requisição", 49.90m },
                    { 140, 16, "140", "Desenvolvimento web com PHP e MySQL", 49.90m },
                    { 141, 16, "141", "MongoDB: Construa novas aplicações com novas tecnologias", 49.90m },
                    { 142, 16, "142", "Big Data: Técnicas e tecnologias para extração de valor dos dados", 49.90m },
                    { 133, 13, "133", "Protractor: Lições sobre testes end-to-end automatizados", 49.90m },
                    { 143, 16, "143", "MySQL: Comece com o principal banco de dados open source do mercado", 49.90m },
                    { 121, 12, "121", "Sass: Aprendendo pré-processadores CSS", 49.90m },
                    { 119, 12, "119", "CSS Eficiente: Técnicas e ferramentas que fazem a diferença nos seus estilos", 49.90m },
                    { 99, 8, "099", "Swift: Programe para iPhone e iPad", 49.90m },
                    { 100, 8, "100", "iOS: Programe para iPhone e iPad", 49.90m },
                    { 101, 8, "101", "Desenvolvimento de Jogos para iOS: Explore sua imaginação com o framework Cocos2D", 49.90m },
                    { 102, 9, "102", "Google Android: crie aplicações para celulares e tablets", 49.90m },
                    { 103, 9, "103", "Desenvolvimento de Jogos para Android: Explore sua imaginação com o framework Cocos2D", 49.90m },
                    { 104, 9, "104", "Jogos Android: Crie um game do zero usando classes nativas", 49.90m },
                    { 105, 9, "105", "Entrega contínua em Android: Como automatizar a distribuição de apps", 49.90m },
                    { 106, 9, "106", "App Inventor: Seus primeiros aplicativos Android", 49.90m },
                    { 107, 10, "107", "Aplicações mobile híbridas com Cordova e PhoneGap", 49.90m },
                    { 120, 12, "120", "Jogos em HTML5: Explore o mobile e física", 49.90m },
                    { 108, 10, "108", "Xamarin Forms: Desenvolvimento de aplicações móveis multiplataforma", 49.90m },
                    { 110, 10, "110", "Cordova avançado e PhoneGap: Um guia detalhado do zero à publicação", 49.90m },
                    { 111, 11, "111", "Criando aplicações para o seu Windows Phone", 49.90m },
                    { 112, 11, "112", "Progressive Web Apps: Construa aplicações progressivas com React", 49.90m },
                    { 113, 11, "113", "Criando aplicações para o seu Windows Phone - Edição Windows Runtime", 49.90m },
                    { 114, 12, "114", "HTML5 e CSS3: Domine a web do futuro", 49.90m },
                    { 115, 12, "115", "Web Design Responsivo: Páginas adaptáveis para todos os dispositivos", 49.90m },
                    { 116, 12, "116", "A Web Mobile: Design Responsivo e além para uma Web adaptada ao mundo mobile", 49.90m },
                    { 117, 12, "117", "Desenvolva jogos com HTML5 Canvas e JavaScript", 49.90m },
                    { 118, 12, "118", "Coletânea Front-end: Uma antologia da comunidade front-end brasileira", 49.90m },
                    { 109, 10, "109", "Ionic Framework: Construa aplicativos para todas as plataformas mobile", 49.90m },
                    { 98, 7, "098", "Programação Funcional e Concorrente em Rust", 49.90m },
                    { 144, 16, "144", "PL/SQL: Domine a linguagem do banco de dados Oracle", 49.90m },
                    { 146, 16, "146", "Machine Learning: Introdução à classificação", 49.90m },
                    { 171, 18, "171", "A jornada do empreendedor: O herói da nossa Era", 49.90m },
                    { 172, 18, "172", "Making it right: Gestão de produtos no mundo das startups", 49.90m },
                    { 173, 19, "173", "SEO Prático: Seu site na primeira página das buscas", 49.90m },
                    { 174, 19, "174", "Marketing de conteúdo: Estratégias para entregar o que seu público quer consumir", 49.90m },
                    { 175, 20, "175", "Gestão de produtos de software: Como aumentar as chances de sucesso do seu software", 49.90m },
                    { 176, 20, "176", "Métricas Ágeis: Obtenha melhores resultados em sua equipe", 49.90m },
                    { 177, 20, "177", "Lean Enterprise: Como empresas de alta performance inovam em escala", 49.90m },
                    { 178, 20, "178", "A jornada do empreendedor: O herói da nossa Era", 49.90m },
                    { 179, 20, "179", "Making it right: Gestão de produtos no mundo das startups", 49.90m },
                    { 170, 18, "170", "Economia do acesso: e os modelos de negócios baseados em compartilhamento, recorrência e assinatura", 49.90m },
                    { 180, 21, "180", "Scrum: Gestão ágil para projetos de sucesso", 49.90m },
                    { 182, 21, "182", "Métricas Ágeis: Obtenha melhores resultados em sua equipe", 49.90m },
                    { 183, 21, "183", "eXtreme Programming: Práticas para o dia a dia no desenvolvimento ágil de software", 49.90m },
                    { 184, 21, "184", "Scrum 360: Um guia completo e prático de agilidade", 49.90m },
                    { 185, 22, "185", "O Programador Apaixonado: Construindo uma carreira notável em desenvolvimento de software", 49.90m },
                    { 186, 22, "186", "O Mantra da Produtividade: Aprimore sua produtividade com técnicas de foco e organização pessoal", 49.90m },
                    { 187, 22, "187", "Learning 3.0: Como os profissionais criativos aprendem", 49.90m },
                    { 188, 22, "188", "Lean Game Development: Desenvolvimento enxuto de jogos", 49.90m },
                    { 189, 23, "189", "Introdução e boas práticas em UX Design", 49.90m },
                    { 190, 23, "190", "Conhecendo o Adobe Photoshop CS6", 49.90m },
                    { 181, 21, "181", "Agile: Desenvolvimento de software com entregas frequentes e foco no valor de negócio", 49.90m },
                    { 145, 16, "145", "SQL: Uma abordagem para bancos de dados Oracle", 49.90m },
                    { 169, 18, "169", "Thoughtworks Antologia Brasil: Histórias de aprendizado e inovação", 49.90m },
                    { 167, 18, "167", "Guia da Startup: Como startups e empresas estabelecidas podem criar produtos de software rentáveis", 49.90m },
                    { 147, 16, "147", "Elasticsearch: Consumindo dados real-time com ELK", 49.90m },
                    { 148, 16, "148", "Business Intelligence: Implementar do jeito certo e a custo zero", 49.90m },
                    { 149, 16, "149", "NoSQL: Como armazenar os dados de uma aplicação moderna", 49.90m },
                    { 150, 16, "150", "Armazenando dados com Redis", 49.90m },
                    { 151, 16, "151", "PostgreSQL: Banco de dados para aplicações web modernas", 49.90m },
                    { 152, 17, "152", "Controlando versões com Git e GitHub", 49.90m },
                    { 153, 17, "153", "DevOps na prática: entrega de software confiável e automatizada", 49.90m },
                    { 154, 17, "154", "Containers com Docker: Do desenvolvimento à produção", 49.90m },
                    { 155, 17, "155", "Caixa de Ferramentas DevOps: Um guia para construção, administração e arquitetura de sistemas modernos", 49.90m },
                    { 168, 18, "168", "Direto ao Ponto: Criando produtos de forma enxuta", 49.90m },
                    { 156, 17, "156", "Jenkins: Automatize tudo sem complicações", 49.90m },
                    { 158, 17, "158", "Segurança em aplicações Web", 49.90m },
                    { 159, 17, "159", "Thoughtworks Antologia Brasil: Histórias de aprendizado e inovação", 49.90m },
                    { 160, 17, "160", "Arduino: Guia para colocar suas ideias em prática", 49.90m },
                    { 161, 17, "161", "Arduino prático: 10 projetos para executar, aprender, modificar e dominar o mundo", 49.90m },
                    { 162, 17, "162", "Azure: Coloque suas plataformas e serviços no cloud", 49.90m },
                    { 163, 17, "163", "Desenvolvimento efetivo na plataforma Microsoft: Como desenvolver e suportar software que funciona", 49.90m },
                    { 164, 17, "164", "Google App Engine: Construindo serviços na nuvem", 49.90m },
                    { 165, 17, "165", "Entrega contínua em Android: Como automatizar a distribuição de apps", 49.90m },
                    { 166, 17, "166", "Windows Server 2012 R2: Estudo dirigido para MCSA prova 70-410", 49.90m },
                    { 157, 17, "157", "Começando com o Linux: Comandos, serviços e administração", 49.90m },
                    { 97, 7, "097", "Rust: Concorrência e alta performance com segurança", 49.90m },
                    { 96, 7, "096", "Octave: Seus primeiros passos na programação científica", 49.90m },
                    { 95, 7, "095", "DSL: Quebre a barreira entre desenvolvimento e negócios", 49.90m },
                    { 26, 2, "026", "Orientação a Objetos: Aprenda seus conceitos e suas aplicabilidades de forma efetiva", 49.90m },
                    { 27, 2, "027", "Componentes Reutilizáveis em Java com Reflexão e Anotações", 49.90m },
                    { 28, 2, "028", "Segurança em aplicações Web", 49.90m },
                    { 29, 2, "029", "Java 9: Interativo, reativo e modularizado", 49.90m },
                    { 30, 2, "030", "Explorando APIs e bibliotecas Java: JDBC, IO, Threads, JavaFX e mais", 49.90m },
                    { 31, 2, "031", "OAuth 2.0: Proteja suas aplicações com o Spring Security OAuth2", 49.90m },
                    { 32, 2, "032", "A lógica do jogo: Recriando clássicos da história dos videogames", 49.90m },
                    { 33, 2, "033", "Play Framework: Java para web sem Servlets e com diversão", 49.90m },
                    { 34, 2, "034", "iReport: Crie relatórios práticos e elegantes", 49.90m },
                    { 25, 2, "025", "Spring Boot: Acelere o desenvolvimento de microsserviços", 49.90m },
                    { 35, 2, "035", "Algoritmos em Java: Busca, ordenação e análise", 49.90m },
                    { 37, 2, "037", "Refatorando com padrões de projeto: Um guia em Java", 49.90m },
                    { 38, 2, "038", "DSL: Quebre a barreira entre desenvolvimento e negócios", 49.90m },
                    { 39, 3, "039", "Desenvolvimento web com ASP.NET MVC", 49.90m },
                    { 40, 3, "040", "Test-Driven Development: Teste e Design no Mundo Real com .NET", 49.90m },
                    { 41, 3, "041", "ASP.NET MVC5: Crie aplicações web na plataforma Microsoft®", 49.90m },
                    { 42, 3, "042", "Orientação a Objetos: Aprenda seus conceitos e suas aplicabilidades de forma efetiva", 49.90m },
                    { 43, 3, "043", "C# e Visual Studio: Desenvolvimento de aplicações desktop", 49.90m },
                    { 44, 3, "044", "Web Services REST com ASP .NET Web API e Windows Azure", 49.90m },
                    { 45, 3, "045", "ASP.NET Core MVC: Aplicações modernas em conjunto com o Entity Framework", 49.90m },
                    { 36, 2, "036", "MundoJ: Segurança com Java", 49.90m },
                    { 46, 3, "046", "Orientação a Objetos em C#: Conceitos e implementações em .NET", 49.90m },
                    { 24, 2, "024", "VRaptor: Desenvolvimento ágil para web com Java", 49.90m },
                    { 22, 2, "022", "CDI: Integre as dependências e contextos do seu código Java", 49.90m },
                    { 2, 1, "002", "Introdução à Computação: Da Lógica aos jogos com Ruby", 49.90m },
                    { 3, 1, "003", "Scratch: Um jeito divertido de aprender programação", 49.90m },
                    { 4, 1, "004", "Introdução à programação em C: Os primeiros passos de um desenvolvedor", 49.90m },
                    { 5, 1, "005", "App Inventor: Seus primeiros aplicativos Android", 49.90m },
                    { 6, 1, "006", "Construct 2: Crie o seu primeiro jogo multiplataforma", 49.90m },
                    { 7, 2, "007", "Aplicações Java para a web com JSF e JPA", 49.90m },
                    { 8, 2, "008", "Java SE 8 Programmer I: O guia para sua certificação Oracle Certified Associate", 49.90m },
                    { 9, 2, "009", "SOA aplicado: Integrando com web services e além", 49.90m },
                    { 10, 2, "010", "Design Patterns com Java: Projeto orientado a objetos guiado por padrões", 49.90m },
                    { 23, 2, "023", "JavaFX: Interfaces com qualidade para aplicações desktop", 49.90m },
                    { 11, 2, "011", "Spring MVC: Domine o principal framework web Java", 49.90m },
                    { 13, 2, "013", "Orientação a Objetos e SOLID para Ninjas: Projetando classes flexíveis", 49.90m },
                    { 14, 2, "014", "Test-Driven Development: Teste e Design no Mundo Real", 49.90m },
                    { 15, 2, "015", "Introdução à Arquitetura e Design de Software: Uma visão sobre a plataforma Java", 49.90m },
                    { 16, 2, "016", "Desbravando Java e Orientação a Objetos: Um guia para o iniciante da linguagem", 49.90m },
                    { 17, 2, "017", "Java 8 Prático: Lambdas, Streams e os novos recursos da linguagem", 49.90m },
                    { 18, 2, "018", "JSF Eficaz: As melhores práticas para o desenvolvedor web Java", 49.90m },
                    { 19, 2, "019", "Testes automatizados de software: Um guia prático", 49.90m },
                    { 20, 2, "020", "Java EE: Aproveite toda a plataforma para construir aplicações", 49.90m },
                    { 21, 2, "021", "JPA Eficaz: As melhores práticas de persistência de dados em Java", 49.90m },
                    { 12, 2, "012", "Vire o jogo com Spring Framework", 49.90m },
                    { 47, 3, "047", "Programação funcional em .NET: Explore um novo universo", 49.90m },
                    { 48, 4, "048", "Desenvolvimento web com PHP e MySQL", 49.90m },
                    { 49, 4, "049", "PHP e Laravel: Crie aplicações web como um verdadeiro artesão", 49.90m },
                    { 75, 7, "075", "Python: Escreva seus primeiros programas", 49.90m },
                    { 76, 7, "076", "Ruby: Aprenda a programar na linguagem mais divertida", 49.90m },
                    { 77, 7, "077", "Construindo APIs REST com Node.js", 49.90m },
                    { 78, 7, "078", "Programando em Go: Crie aplicações com a linguagem do Google", 49.90m },
                    { 79, 7, "079", "OAuth 2.0: Proteja suas aplicações com o Spring Security OAuth2", 49.90m },
                    { 80, 7, "080", "Meteor: Criando aplicações web real-time com JavaScript", 49.90m },
                    { 81, 7, "081", "Cucumber e RSpec: Construa aplicações Ruby com testes e especificações", 49.90m },
                    { 82, 7, "082", "Falando de Grails: Altíssima produtividade no desenvolvimento web", 49.90m },
                    { 83, 7, "083", "Guia do mestre programador: pensando como pirata, evoluindo como jedi", 49.90m },
                    { 74, 7, "074", "Swift: Programe para iPhone e iPad", 49.90m },
                    { 84, 7, "084", "Thoughtworks Antologia Brasil: Histórias de aprendizado e inovação", 49.90m },
                    { 86, 7, "086", "Test Driven Development: Teste e design no mundo real com Ruby", 49.90m },
                    { 87, 7, "087", "Fragmentos de um programador: Artigos e insights da carreira de um profissional", 49.90m },
                    { 88, 7, "088", "Desenvolvimento efetivo na plataforma Microsoft: Como desenvolver e suportar software que funciona", 49.90m },
                    { 89, 7, "089", "Primeiros passos com Node.js", 49.90m },
                    { 90, 7, "090", "RSpec: Crie especificações executáveis em Ruby", 49.90m },
                    { 91, 7, "091", "ABAP: O guia de sobrevivência do profissional moderno", 49.90m },
                    { 92, 7, "092", "Refatorando com padrões de projeto: Um guia em Ruby", 49.90m },
                    { 93, 7, "093", "Microsoft Kinect: Crie aplicações interativas", 49.90m },
                    { 94, 7, "094", "Canivete suíço do desenvolvedor Node", 49.90m },
                    { 85, 7, "085", "Introdução à programação em C: Os primeiros passos de um desenvolvedor", 49.90m },
                    { 73, 7, "073", "Mean: Full stack JavaScript para aplicações web com MongoDB, Express, Angular e Node", 49.90m },
                    { 72, 7, "072", "Ruby on Rails: coloque sua aplicação web nos trilhos", 49.90m },
                    { 71, 7, "071", "REST: Construa API's inteligentes de maneira simples", 49.90m },
                    { 50, 4, "050", "Zend Certified Engineer: Descomplicando a certificação PHP", 49.90m },
                    { 51, 4, "051", "CodeIgniter: Produtividade na criação de aplicações web em PHP", 49.90m },
                    { 52, 4, "052", "Test-Driven Development: Teste e Design no Mundo Real com PHP", 49.90m },
                    { 53, 4, "053", "Do PHP ao Zend Framework: Domine as boas práticas", 49.90m },
                    { 54, 4, "054", "Coleção CodeIgniter + Zend PHP", 49.90m },
                    { 55, 5, "055", "Introdução à Computação: Da Lógica aos jogos com Ruby", 49.90m },
                    { 56, 5, "056", "A lógica do jogo: Recriando clássicos da história dos videogames", 49.90m },
                    { 57, 5, "057", "Desenvolva jogos com HTML5 Canvas e JavaScript", 49.90m },
                    { 58, 5, "058", "Desenvolvimento de Jogos para Android: Explore sua imaginação com o framework Cocos2D", 49.90m },
                    { 59, 5, "059", "Desenvolvimento de Jogos para iOS: Explore sua imaginação com o framework Cocos2D", 49.90m },
                    { 60, 5, "060", "Jogos em HTML5: Explore o mobile e física", 49.90m },
                    { 61, 5, "061", "Jogos Android: Crie um game do zero usando classes nativas", 49.90m },
                    { 62, 5, "062", "Lean Game Development: Desenvolvimento enxuto de jogos", 49.90m },
                    { 63, 5, "063", "Construct 2: Crie o seu primeiro jogo multiplataforma", 49.90m },
                    { 64, 6, "064", "Scala: Como escalar sua produtividade", 49.90m },
                    { 65, 6, "065", "Elixir: Do zero à concorrência", 49.90m },
                    { 66, 6, "066", "Haskell: Uma introdução à programação funcional", 49.90m },
                    { 67, 6, "067", "OCaml: Programação funcional na prática", 49.90m },
                    { 68, 6, "068", "Programação funcional em .NET: Explore um novo universo", 49.90m },
                    { 69, 6, "069", "Programação Funcional e Concorrente em Rust", 49.90m },
                    { 70, 7, "070", "Aplicações web real-time com Node.js", 49.90m },
                    { 191, 23, "191", "Edição e organização de fotos com Adobe Lightroom", 49.90m },
                    { 192, 23, "192", "Vale presente Casa do Código", 49.90m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
