using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Service.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    PriceBeforeDiscount = table.Column<double>(type: "float", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Sold = table.Column<int>(type: "int", nullable: true),
                    View = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nike" },
                    { 2, "Adidas" },
                    { 3, "New Balance" },
                    { 4, "Converse" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sport" },
                    { 2, "Running" },
                    { 3, "Walking" },
                    { 4, "Training & Gym" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Description", "Image", "Name", "Price", "PriceBeforeDiscount", "Quantity", "Rating", "Sold", "View" },
                values: new object[,]
                {
                    { 1, 1, 1, "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">The radiance lives on in the Nike Air Force 1 '07, the b-ball icon that puts a fresh spin on what you know best: crisp leather, bold colours and the perfect amount of flash to make you shine.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->White/Black</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->CT2302-100</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>", null, "Nike Air Force 1 '07", 150.0, 200.0, 10, 4.0, 2000, 10000 },
                    { 2, 1, 2, "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">Created for the hardwood but taken to the streets, this '80s basketball icon returns with classic details and throwback hoops flair. The synthetic leather overlays help the Nike Dunk channel vintage style while its padded, low-cut collar lets you take your game anywhere—in comfort.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->Summit White/Baroque Brown/Phantom/Khaki</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->HF4292-100</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Indonesia</li></ul></div>", null, "Nike Dunk Low", 180.0, 230.0, 30, 5.0, 3200, 2800 },
                    { 3, 1, 3, "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">With maximum cushioning to support every mile, the Invincible 3 gives you our highest level of comfort underfoot to help you stay on your feet today, tomorrow and beyond. Engineered to the exact specifications of championship athletes, ultra-responsive and lightweight ZoomX foam helps keep you on the run. It can help propel you down your preferred path and come back for your next run feeling ready and reinvigorated.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->Multi-Colour/Multi-Colour</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->HJ6653-900</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>", null, "Nike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-Colour\r\nNike Invincible 3 Blueprint\r\nMen's Road Running Shoes", 186.0, 220.0, 50, 3.3999999999999999, 1400, 1000 },
                    { 4, 1, 4, "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">Inspired by the original that debuted in 1985, the Air Jordan 1 Low offers a clean, classic look that's familiar yet always fresh. With an iconic design that pairs perfectly with any 'fit, these kicks ensure you'll always be on point.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->White/White/Black</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->553558-132</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>", null, "Air Jordan 1 Low\r\nMen's Shoes", 190.0, null, 100, 2.7000000000000002, 200, 32000 },
                    { 5, 2, 1, "<div class=\"text-content___13aRm\"><h3 class=\"subtitle___9ljbp\">An iconic design with contemporary comfort.</h3><p class=\"gl-vspace\">First released in 1972 to equip athletes for the Summer event, the adidas SL 72 OG shoes have a lightweight build that revolutionised running. Today, the breathable nylon upper, suede overlays and leather accents bring retro-inspired style to your active life. An Ecotex tongue adds texture, and the EVA midsole keeps you comfortable on the go. The classic low-profile cut and rubber outsole deliver the final touches.</p></div>", null, "SL 72 OG Shoes", 150.0, 160.0, 32, 4.2999999999999998, 3352, 4000 },
                    { 6, 2, 2, "<div class=\"text-content___13aRm\"><h3 class=\"subtitle___9ljbp\">Sport-inspired shoes with a retro look, modern comfort and a rich past.</h3><p class=\"gl-vspace\">Long before the adidas Samba shoes took to the streets, they left their mark on the indoor football pitch. Their smooth leather upper, nubuck toe cap and reinforced rubber sole were designed with agility and control in mind. Though times have changed, their essence remains. Today, they carry on the legacy as an iconic street style, ready for whatever your day brings. Moulded into their design is decades of history, keeping the spirit of the Trefoil alive.</p></div>", null, "Samba OG Shoes", 180.0, null, 50, 3.6000000000000001, 2200, 8289 },
                    { 7, 2, 3, "<div class=\"text-content___13aRm\"><h3 class=\"subtitle___9ljbp\">adidas Samba shoes in collaboration with Wales Bonner.</h3><p class=\"gl-vspace\">The Fall/Winter 2024 collection from adidas and Wales Bonner merges tradition with modernity in a celebration of hip hop movement and romanticism. Music and creative vibrancy are threaded into the collection through the textures, shapes and colours across the pieces.\r\n\r\nWith one of adidas' most iconic silhouette as a canvas, the Wales Bonner MN Samba Shoes channel a collegiate aesthetic through different materials and contrasting tones. The split is done with yellow suede on the front half, and a navy croc-embossed pattern towards the back. Everything is detailed with intricate deco-stitching.</p></div>", null, "Wales Bonner MN Samba Shoes", 320.0, 400.0, 10, 4.0, 1500, 10000 },
                    { 8, 2, 4, "<div class=\"text-content___13aRm\"><h3 class=\"subtitle___9ljbp\">Entirely new (but archive-inspired) lifestyle shoes made with Dingyun Zhang.</h3><p class=\"gl-vspace\">The silhouette of the adidas Kouza shoes has clearly been put under Dingyun Zhang's disruptive lens — and what's seen is a progressive blend of both product and art. Taking inspiration from sci-fi, otherworldly creations and a true love of street culture, the Chinese designer brings to life a completely new running-inspired shoe that nods to the adidas archives. The ultra-lightweight, chunky silhouette provides durability and breathability, and features a incredibly comfortable Lightstrike midsole. A mix of materials form the upper, creating a play between textures and layers.</p></div>", null, "Dingyun Zhang Kouza", 230.0, 450.0, 10, 4.0, 2670, 10000 },
                    { 9, 3, 1, "<div class=\"col-12 value content short-description px-0 pb-3\" id=\"collapsible-description-1\">\r\n                    If we only made one running shoe, it would be the Fresh Foam X 1080. The unique combination of reliable comfort and high performance offers versatility that spans from every day to race day. The Fresh Foam X midsole cushioning is built for smooth transitions from landing to push-off, while a soft, premium upper provides support and breathability.<br><br>Updates to the v14 include a new, triple jacquard mesh upper with increased breathability in key areas, an updated outsole for a propulsive feeling, and additional rubber in high wear areas for added durability.\r\n                </div>", null, "Fresh Foam X 1080 v14", 270.0, 320.0, 10, 4.0, 1450, 10000 },
                    { 10, 3, 3, "<div class=\"accordion-content\" part=\"accordion-content\" id=\"accordion-f827a\">\r\n                <div>\r\n                    <slot></slot>\r\n                </div>\r\n            </div>", null, "FuelCell MD500 v9", 120.0, null, 10, 4.0, 220, 10000 },
                    { 11, 3, 3, "<div class=\"col-12 value content short-description px-0 pb-3\" id=\"collapsible-description-1\">\r\n                    Your new favorite training partner. This running shoe features an innovative midsole design with ground contact EVA outsole for a lightweight, propulsive, and fast underfoot feel to take you seamlessly from training to race day.\r\n                </div>", null, "Fresh Foam X Balos", 295.0, 340.0, 10, 4.0, null, 1996 },
                    { 12, 3, 4, "<div class=\"col-12 value content short-description px-0 pb-3\" id=\"collapsible-description-1\">\r\n                    Whatever your preferred running routine looks like, there’s no shoe that handles it quite like the 880. The Fresh Foam X 880v14 is an evolution in everyday reliability, featuring superior underfoot cushioning and a structured, supportive upper.\r\n                </div>", null, "Fresh Foam X 880v14", 195.0, 240.0, 10, 4.0, null, 10000 },
                    { 13, 4, 1, "<div class=\"product attribute description\" id=\"product-description\"> <div class=\"value\"><h2>HIGH FASHION</h2>\r\n<p>Turn every hallway into your own personal runway with extra-high Chucks. Angular lines and crocodile-inspired details bring a luxe look with just enough edge.</p>\r\n<h3>Details</h3>\r\n<ul>\r\n<li>Croc-embossed leather brings a luxe look and feel</li>\r\n<li>OrthoLite cushioning helps provide optimal comfort</li>\r\n<li>Tonal laces and gold eyelets elevate your style</li>\r\n<li>Angular lines and eyelets remix Chuck Taylor DNA</li>\r\n<li>Iconic Chuck Taylor ankle patch and vintage All Star license plate</li>\r\n</ul>\r\n<h3>Chuck 70 Origins</h3>\r\n<p>By 1970, the Chuck had evolved to become the pinnacle of function and utility for sport, and was considered the best basketball sneaker ever. The Chuck 70 is built off of the original 1970s design, with premium materials and an extraordinary attention to detail. A shoe so rooted in tradition that it has its own instant history. That's the Chuck 70. It's not a shoe. It's the shoe.</p></div> <div><a href=\"#\" class=\"back-to-top _hide-for-tablet -scroll -down\">Back to top</a></div> </div>", null, "Unisex Converse Chuck 70 De Luxe Squared Leather High Top Bloodstone", 200.0, 230.0, 6, 4.0, 1996, 18 },
                    { 14, 4, 2, "<div data-content-type=\"text\" data-appearance=\"default\" data-element=\"main\" data-pb-style=\"V6MM40P\"><div>\r\n<h2>FALL FAVOURITE.</h2>\r\n</div>\r\n<p id=\"VW4NQSG\">Just in time for cooler weather, your favourite Chucks get a fresh look for the season. Fall-ready canvas in trending colors help you add standout style to your rotation. On those shorter days, why not add some colour to your look?</p>\r\n<div>\r\n<h3>Details</h3>\r\n<ul>\r\n<li>High top with canvas upper</li>\r\n<li>OrthoLite cushioning for all-day comfort</li>\r\n<li>On-trend colour palette</li>\r\n<li>Durable polyester laces</li>\r\n<li>Fused All Star patch</li>\r\n</ul>\r\n</div>\r\n<div>\r\n<h3>Chuck Taylor All Star Origins</h3>\r\n</div>\r\n<p>Created in 1917 as a non-skid basketball shoe, the All Star was originally promoted for its superior court performance by basketball mastermind Chuck Taylor. But over the decades, something incredible happened: The sneaker, with its timeless silhouette and unmistakable ankle patch, was organically adopted by rebels, artists, musicians, dreamers, thinkers and originals.</p></div>", null, "Unisex Converse Run Star Trainer Low Top Bloodstone", 140.0, 210.0, 10, 4.0, 2000, 10000 },
                    { 15, 4, 3, "<div data-content-type=\"row\" data-appearance=\"contained\" data-element=\"main\"><div data-enable-parallax=\"0\" data-parallax-speed=\"0.5\" data-background-images=\"{}\" data-background-type=\"image\" data-video-loop=\"true\" data-video-play-only-visible=\"true\" data-video-lazy-load=\"true\" data-video-fallback-src=\"\" data-element=\"inner\" data-pb-style=\"624598B54085D\"><div data-content-type=\"text\" data-appearance=\"default\" data-element=\"main\" data-pb-style=\"624598B540868\"><div>\r\n<h2 class=\"pdp-tab__title text-align--sm-center\">EXPRESS YOURSELF WITH COLOUR.</h2>\r\n</div>\r\n<p id=\"VW4NQSG\">The laidback legend is back in fresh colours. Ready for dressing up or down, these classic canvas Chucks are an everyday wardrobe staple. Plus, we’ve softened up the lining, stitching and seams for maximum comfort all day, every day.</p>\r\n<div>\r\n<h3>Details</h3>\r\n<ul>\r\n<li class=\"pdp-tab__list-item\">Canvas high top sneakers.</li>\r\n<li class=\"pdp-tab__list-item\">OrthoLite insole for cushioning.</li>\r\n<li class=\"pdp-tab__list-item\">New hues bring a pop of colour to any outfit.</li>\r\n<li class=\"pdp-tab__list-item\">Classic woven tongue label and license plate.</li>\r\n<li class=\"pdp-tab__list-item\">Iconic Chuck Taylor ankle patch.</li>\r\n</ul>\r\n</div>\r\n<div>\r\n<h3>Chuck Taylor All Star Origins</h3>\r\n</div>\r\n<p>Created in 1917 as a non-skid basketball shoe, the All Star was originally promoted for its superior court performance by basketball mastermind Chuck Taylor. But over the decades, something incredible happened: The sneaker, with its timeless silhouette and unmistakable ankle patch, was organically adopted by rebels, artists, musicians, dreamers, thinkers and originals.</p></div></div></div>", null, "Unisex Converse Chuck Taylor All Star Seasonal Colour High Top Snorkel Blue", 150.0, 230.0, 10, 4.0, 2012, 10000 },
                    { 16, 4, 4, "<div data-content-type=\"text\" data-appearance=\"default\" data-element=\"main\" data-pb-style=\"PLSW2C1\"><div>\r\n<h2>REMASTERED CLASSIC</h2>\r\n</div>\r\n<p>Leather Chucks. They go with your suit and tie just as much as your sweats and tee. They’re durable and easier to clean—so feel free to wear them, like, all the time. And they’re built like the original, so your Chucks collection stays most iconic. Are you obsessed yet?</p>\r\n<div>\r\n<h3>Details</h3>\r\n<ul>\r\n<li>Luxe, full-grain leather upper, with that classic Chucks look</li>\r\n<li>OrthoLite cushioning helps to provide optimal comfort</li>\r\n<li>Iconic All Star tongue label and license plate</li>\r\n<li>Medial eyelets enhance airflow</li>\r\n</ul>\r\n</div>\r\n<div>\r\n<h3>Chuck Taylor All Star Origins</h3>\r\n</div>\r\n<p>Created in 1917 as a non-skid basketball shoe, the All Star was originally promoted for its superior court performance by basketball mastermind Chuck Taylor. But over the decades, something incredible happened: The sneaker, with its timeless silhouette and unmistakable ankle patch, was organically adopted by rebels, artists, musicians, dreamers, thinkers and originals.</p></div>", null, "Unisex Converse Chuck Taylor All Star Leather Low Top White\r\n", 160.0, 230.0, 10, 4.0, 20300, 10000 },
                    { 17, 1, 4, "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">The radiance lives on in the Nike Air Force 1 '07, the b-ball icon that puts a fresh spin on what you know best: crisp leather, bold colours and the perfect amount of flash to make you shine.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->White/Black</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->CT2302-100</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>", null, "Nike Air Max 95", 380.0, 390.0, 10, 4.0, 11212, 10000 },
                    { 18, 1, 3, "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">The radiance lives on in the Nike Air Force 1 '07, the b-ball icon that puts a fresh spin on what you know best: crisp leather, bold colours and the perfect amount of flash to make you shine.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->White/Black</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->CT2302-100</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>", null, "Jumpman MVP", 161.99000000000001, 230.0, 10, 2.6000000000000001, 12012, 2000 },
                    { 19, 4, 4, "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">The radiance lives on in the Nike Air Force 1 '07, the b-ball icon that puts a fresh spin on what you know best: crisp leather, bold colours and the perfect amount of flash to make you shine.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->White/Black</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->CT2302-100</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>", null, "Nike Invincible 3 Blueprint Men's Road Running Shoes", 180.0, 230.0, 10, 2.5, 152012, 6300 },
                    { 20, 1, 2, "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">The radiance lives on in the Nike Air Force 1 '07, the b-ball icon that puts a fresh spin on what you know best: crisp leather, bold colours and the perfect amount of flash to make you shine.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->White/Black</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->CT2302-100</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>", null, "Air Jordan 1 Low", 190.0, 330.0, 10, 4.7999999999999998, 4012, 1000 },
                    { 21, 1, 1, "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">The radiance lives on in the Nike Air Force 1 '07, the b-ball icon that puts a fresh spin on what you know best: crisp leather, bold colours and the perfect amount of flash to make you shine.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->White/Black</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->CT2302-100</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>", null, "Nike V2K Run", 180.0, 250.0, 10, 5.0, 25512, 34000 }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "DateAdded", "Description", "IsMain", "ProductId", "PublicId", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, "admin", "https://localhost:7000/ProductImages/1.png" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, "admin", "https://localhost:7000/ProductImages/2.png" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, "admin", "https://localhost:7000/ProductImages/3.png" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, "admin", "https://localhost:7000/ProductImages/4.png" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, "admin", "https://localhost:7000/ProductImages/5.png" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, "admin", "https://localhost:7000/ProductImages/6.png" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, "admin", "https://localhost:7000/ProductImages/7.png" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, "admin", "https://localhost:7000/ProductImages/8.png" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, "admin", "https://localhost:7000/ProductImages/9.png" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, "admin", "https://localhost:7000/ProductImages/10.png" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, "admin", "https://localhost:7000/ProductImages/11.png" },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, "admin", "https://localhost:7000/ProductImages/12.png" },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, "admin", "https://localhost:7000/ProductImages/13.png" },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, "admin", "https://localhost:7000/ProductImages/14.png" },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, "admin", "https://localhost:7000/ProductImages/15.png" },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, "admin", "https://localhost:7000/ProductImages/16.png" },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, "admin", "https://localhost:7000/ProductImages/1.jpg" },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, "admin", "https://localhost:7000/ProductImages/1.jpg" },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, "admin", "https://localhost:7000/ProductImages/2.jpg" },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, "admin", "https://localhost:7000/ProductImages/3.jpg" },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, "admin", "https://localhost:7000/ProductImages/4.jpg" },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, "admin", "https://localhost:7000/ProductImages/5.jpg" },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 6, "admin", "https://localhost:7000/ProductImages/6.jpg" },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 6, "admin", "https://localhost:7000/ProductImages/7.jpg" },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 6, "admin", "https://localhost:7000/ProductImages/8.jpg" },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 6, "admin", "https://localhost:7000/ProductImages/9.jpg" },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 7, "admin", "https://localhost:7000/ProductImages/10.jpg" },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 7, "admin", "https://localhost:7000/ProductImages/11.jpg" },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 7, "admin", "https://localhost:7000/ProductImages/1.jpg" },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 7, "admin", "https://localhost:7000/ProductImages/12.jpg" },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 8, "admin", "https://localhost:7000/ProductImages/13.jpg" },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 8, "admin", "https://localhost:7000/ProductImages/14.jpg" },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 8, "admin", "https://localhost:7000/ProductImages/15.jpg" },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 8, "admin", "https://localhost:7000/ProductImages/16.jpg" },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 9, "admin", "https://localhost:7000/ProductImages/17.jpg" },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 9, "admin", "https://localhost:7000/ProductImages/18.jpg" },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 9, "admin", "https://localhost:7000/ProductImages/19.jpg" },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 10, "admin", "https://localhost:7000/ProductImages/20.jpg" },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 11, "admin", "https://localhost:7000/ProductImages/21.jpg" },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 12, "admin", "https://localhost:7000/ProductImages/22.jpg" },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 12, "admin", "https://localhost:7000/ProductImages/23.jpg" },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 12, "admin", "https://localhost:7000/ProductImages/24.jpg" },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 12, "admin", "https://localhost:7000/ProductImages/25.jpg" },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 13, "admin", "https://localhost:7000/ProductImages/26.jpg" },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 13, "admin", "https://localhost:7000/ProductImages/27.jpg" },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 13, "admin", "https://localhost:7000/ProductImages/28.jpg" },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 13, "admin", "https://localhost:7000/ProductImages/29.jpg" },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 14, "admin", "https://localhost:7000/ProductImages/30.jpg" },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 14, "admin", "https://localhost:7000/ProductImages/31.jpg" },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 14, "admin", "https://localhost:7000/ProductImages/32.jpg" },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 14, "admin", "https://localhost:7000/ProductImages/33.jpg" },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 14, "admin", "https://localhost:7000/ProductImages/33.jpg" },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 14, "admin", "https://localhost:7000/ProductImages/34.jpg" },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 15, "admin", "https://localhost:7000/ProductImages/35.jpg" },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 15, "admin", "https://localhost:7000/ProductImages/36.jpg" },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 15, "admin", "https://localhost:7000/ProductImages/37.jpg" },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 16, "admin", "https://localhost:7000/ProductImages/38.jpg" },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 16, "admin", "https://localhost:7000/ProductImages/39.jpg" },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 16, "admin", "https://localhost:7000/ProductImages/40.jpg" },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 17, "admin", "https://localhost:7000/ProductImages/39.jpg" },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 17, "admin", "https://localhost:7000/ProductImages/40.jpg" },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 17, "admin", "https://localhost:7000/ProductImages/41.jpg" },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 17, "admin", "https://localhost:7000/ProductImages/42.jpg" },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 17, "admin", "https://localhost:7000/ProductImages/43.jpg" },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 18, "admin", "https://localhost:7000/ProductImages/44.jpg" },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 18, "admin", "https://localhost:7000/ProductImages/45.jpg" },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 19, "admin", "https://localhost:7000/ProductImages/46.jpg" },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 19, "admin", "https://localhost:7000/ProductImages/47.jpg" },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 19, "admin", "https://localhost:7000/ProductImages/48.jpg" },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 19, "admin", "https://localhost:7000/ProductImages/49.jpg" },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 20, "admin", "https://localhost:7000/ProductImages/50.jpg" },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 20, "admin", "https://localhost:7000/ProductImages/51.jpg" },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 20, "admin", "https://localhost:7000/ProductImages/52.jpg" },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 20, "admin", "https://localhost:7000/ProductImages/53.jpg" },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 20, "admin", "https://localhost:7000/ProductImages/54.jpg" },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 21, "admin", "https://localhost:7000/ProductImages/55.jpg" },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 21, "admin", "https://localhost:7000/ProductImages/56.jpg" },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 21, "admin", "https://localhost:7000/ProductImages/57.jpg" },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 21, "admin", "https://localhost:7000/ProductImages/58.jpg" },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 21, "admin", "https://localhost:7000/ProductImages/59.jpg" },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 21, "admin", "https://localhost:7000/ProductImages/60.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ProductId",
                table: "Photos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
