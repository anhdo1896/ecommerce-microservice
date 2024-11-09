using Ecommerce.Service.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecommerce.Service.ProductAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Photo> Photos{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Sport"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 2,
                Name = "Running"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 3,
                Name = "Walking"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 4,
                Name = "Training & Gym"
            });

            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Id = 1,
                Name = "Nike"
            });

            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Id = 2,
                Name = "Adidas"
            });

            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Id = 3,
                Name = "New Balance"
            });

            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Id = 4,
                Name = "Converse"
            });


            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Nike Air Force 1 '07",
                Price = 150,
                PriceBeforeDiscount = 200,
                Description = "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">The radiance lives on in the Nike Air Force 1 '07, the b-ball icon that puts a fresh spin on what you know best: crisp leather, bold colours and the perfect amount of flash to make you shine.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->White/Black</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->CT2302-100</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>",
                CategoryId = 1,
                BrandId = 1,
                Rating =  4,
                Quantity =  10,
                View = 10000,
                Sold = 2000
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Nike Dunk Low",
                Price = 180,
                PriceBeforeDiscount = 230,
                Description = "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">Created for the hardwood but taken to the streets, this '80s basketball icon returns with classic details and throwback hoops flair. The synthetic leather overlays help the Nike Dunk channel vintage style while its padded, low-cut collar lets you take your game anywhere—in comfort.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->Summit White/Baroque Brown/Phantom/Khaki</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->HF4292-100</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Indonesia</li></ul></div>",
                CategoryId = 2,
                BrandId = 1,
                Rating = 5,
                Quantity = 30,
                View = 2800,
                Sold = 3200

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Nike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-ColourNike Invincible 3 Blueprint Men's Road Running Shoes - Multi-Colour/Multi-Colour\r\nNike Invincible 3 Blueprint\r\nMen's Road Running Shoes",
                Price = 186,
                PriceBeforeDiscount = 220,
                Description = "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">With maximum cushioning to support every mile, the Invincible 3 gives you our highest level of comfort underfoot to help you stay on your feet today, tomorrow and beyond. Engineered to the exact specifications of championship athletes, ultra-responsive and lightweight ZoomX foam helps keep you on the run. It can help propel you down your preferred path and come back for your next run feeling ready and reinvigorated.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->Multi-Colour/Multi-Colour</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->HJ6653-900</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>",
                CategoryId = 3,
                BrandId = 1,
                Rating = 3.4,
                Quantity = 50,
                View = 1000,
                Sold = 1400

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Air Jordan 1 Low\r\nMen's Shoes",
                Price = 190,
                Description = "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">Inspired by the original that debuted in 1985, the Air Jordan 1 Low offers a clean, classic look that's familiar yet always fresh. With an iconic design that pairs perfectly with any 'fit, these kicks ensure you'll always be on point.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->White/White/Black</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->553558-132</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>",
                CategoryId = 4,
                BrandId = 1,
                Rating = 2.7,
                Quantity = 100,
                View = 32000,
                Sold = 200

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "SL 72 OG Shoes",
                Price = 150,
                PriceBeforeDiscount = 160,
                Description = "<div class=\"text-content___13aRm\"><h3 class=\"subtitle___9ljbp\">An iconic design with contemporary comfort.</h3><p class=\"gl-vspace\">First released in 1972 to equip athletes for the Summer event, the adidas SL 72 OG shoes have a lightweight build that revolutionised running. Today, the breathable nylon upper, suede overlays and leather accents bring retro-inspired style to your active life. An Ecotex tongue adds texture, and the EVA midsole keeps you comfortable on the go. The classic low-profile cut and rubber outsole deliver the final touches.</p></div>",
                CategoryId = 1,
                BrandId = 2,
                Rating = 4.3,
                Quantity = 32,
                View = 4000,
                Sold = 3352

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Samba OG Shoes",
                Price = 180,
                Description = "<div class=\"text-content___13aRm\"><h3 class=\"subtitle___9ljbp\">Sport-inspired shoes with a retro look, modern comfort and a rich past.</h3><p class=\"gl-vspace\">Long before the adidas Samba shoes took to the streets, they left their mark on the indoor football pitch. Their smooth leather upper, nubuck toe cap and reinforced rubber sole were designed with agility and control in mind. Though times have changed, their essence remains. Today, they carry on the legacy as an iconic street style, ready for whatever your day brings. Moulded into their design is decades of history, keeping the spirit of the Trefoil alive.</p></div>",
                CategoryId = 2,
                BrandId = 2,
                Rating = 3.6,
                Quantity = 50,
                View = 8289,
                Sold = 2200

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Wales Bonner MN Samba Shoes",
                Price = 320,
                PriceBeforeDiscount = 400,
                Description = "<div class=\"text-content___13aRm\"><h3 class=\"subtitle___9ljbp\">adidas Samba shoes in collaboration with Wales Bonner.</h3><p class=\"gl-vspace\">The Fall/Winter 2024 collection from adidas and Wales Bonner merges tradition with modernity in a celebration of hip hop movement and romanticism. Music and creative vibrancy are threaded into the collection through the textures, shapes and colours across the pieces.\r\n\r\nWith one of adidas' most iconic silhouette as a canvas, the Wales Bonner MN Samba Shoes channel a collegiate aesthetic through different materials and contrasting tones. The split is done with yellow suede on the front half, and a navy croc-embossed pattern towards the back. Everything is detailed with intricate deco-stitching.</p></div>",
                CategoryId = 3,
                BrandId = 2,
                Rating = 4,
                Quantity = 10,
                View = 10000,
                Sold = 1500

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                Name = "Dingyun Zhang Kouza",
                Price = 230,
                PriceBeforeDiscount = 450,
                Description = "<div class=\"text-content___13aRm\"><h3 class=\"subtitle___9ljbp\">Entirely new (but archive-inspired) lifestyle shoes made with Dingyun Zhang.</h3><p class=\"gl-vspace\">The silhouette of the adidas Kouza shoes has clearly been put under Dingyun Zhang's disruptive lens — and what's seen is a progressive blend of both product and art. Taking inspiration from sci-fi, otherworldly creations and a true love of street culture, the Chinese designer brings to life a completely new running-inspired shoe that nods to the adidas archives. The ultra-lightweight, chunky silhouette provides durability and breathability, and features a incredibly comfortable Lightstrike midsole. A mix of materials form the upper, creating a play between textures and layers.</p></div>",
                CategoryId = 4,
                BrandId = 2,
                Rating = 4,
                Quantity = 10,
                View = 10000,
                Sold = 2670

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 9,
                Name = "Fresh Foam X 1080 v14",
                Price = 270,
                PriceBeforeDiscount = 320,
                Description = "<div class=\"col-12 value content short-description px-0 pb-3\" id=\"collapsible-description-1\">\r\n                    If we only made one running shoe, it would be the Fresh Foam X 1080. The unique combination of reliable comfort and high performance offers versatility that spans from every day to race day. The Fresh Foam X midsole cushioning is built for smooth transitions from landing to push-off, while a soft, premium upper provides support and breathability.<br><br>Updates to the v14 include a new, triple jacquard mesh upper with increased breathability in key areas, an updated outsole for a propulsive feeling, and additional rubber in high wear areas for added durability.\r\n                </div>",
                CategoryId = 1,
                BrandId = 3,
                Rating = 4,
                Quantity = 10,
                View = 10000,
                Sold = 1450

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 10,
                Name = "FuelCell MD500 v9",
                Price = 120,
                Description = "<div class=\"accordion-content\" part=\"accordion-content\" id=\"accordion-f827a\">\r\n                <div>\r\n                    <slot></slot>\r\n                </div>\r\n            </div>",
                CategoryId = 3,
                BrandId = 3,
                Rating = 4,
                Quantity = 10,
                View = 10000,
                Sold = 220

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 11,
                Name = "Fresh Foam X Balos",
                Price = 295,
                PriceBeforeDiscount = 340,
                Description = "<div class=\"col-12 value content short-description px-0 pb-3\" id=\"collapsible-description-1\">\r\n                    Your new favorite training partner. This running shoe features an innovative midsole design with ground contact EVA outsole for a lightweight, propulsive, and fast underfoot feel to take you seamlessly from training to race day.\r\n                </div>",
                CategoryId = 3,
                BrandId = 3,
                Rating = 4,
                Quantity = 10,
                View = 1996
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 12,
                Name = "Fresh Foam X 880v14",
                Price = 195,
                PriceBeforeDiscount = 240,
                Description = "<div class=\"col-12 value content short-description px-0 pb-3\" id=\"collapsible-description-1\">\r\n                    Whatever your preferred running routine looks like, there’s no shoe that handles it quite like the 880. The Fresh Foam X 880v14 is an evolution in everyday reliability, featuring superior underfoot cushioning and a structured, supportive upper.\r\n                </div>",
                CategoryId = 4,
                BrandId = 3,
                Rating = 4,
                Quantity = 10,
                View = 10000
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 13,
                Name = "Unisex Converse Chuck 70 De Luxe Squared Leather High Top Bloodstone",
                Price = 200,
                PriceBeforeDiscount = 230,
                Description = "<div class=\"product attribute description\" id=\"product-description\"> <div class=\"value\"><h2>HIGH FASHION</h2>\r\n<p>Turn every hallway into your own personal runway with extra-high Chucks. Angular lines and crocodile-inspired details bring a luxe look with just enough edge.</p>\r\n<h3>Details</h3>\r\n<ul>\r\n<li>Croc-embossed leather brings a luxe look and feel</li>\r\n<li>OrthoLite cushioning helps provide optimal comfort</li>\r\n<li>Tonal laces and gold eyelets elevate your style</li>\r\n<li>Angular lines and eyelets remix Chuck Taylor DNA</li>\r\n<li>Iconic Chuck Taylor ankle patch and vintage All Star license plate</li>\r\n</ul>\r\n<h3>Chuck 70 Origins</h3>\r\n<p>By 1970, the Chuck had evolved to become the pinnacle of function and utility for sport, and was considered the best basketball sneaker ever. The Chuck 70 is built off of the original 1970s design, with premium materials and an extraordinary attention to detail. A shoe so rooted in tradition that it has its own instant history. That's the Chuck 70. It's not a shoe. It's the shoe.</p></div> <div><a href=\"#\" class=\"back-to-top _hide-for-tablet -scroll -down\">Back to top</a></div> </div>",
                CategoryId = 1,
                BrandId = 4,
                Rating = 4,
                Quantity = 6,
                View = 18,
                Sold= 1996
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 14,
                Name = "Unisex Converse Run Star Trainer Low Top Bloodstone",
                Price = 140,
                PriceBeforeDiscount = 210,
                Description = "<div data-content-type=\"text\" data-appearance=\"default\" data-element=\"main\" data-pb-style=\"V6MM40P\"><div>\r\n<h2>FALL FAVOURITE.</h2>\r\n</div>\r\n<p id=\"VW4NQSG\">Just in time for cooler weather, your favourite Chucks get a fresh look for the season. Fall-ready canvas in trending colors help you add standout style to your rotation. On those shorter days, why not add some colour to your look?</p>\r\n<div>\r\n<h3>Details</h3>\r\n<ul>\r\n<li>High top with canvas upper</li>\r\n<li>OrthoLite cushioning for all-day comfort</li>\r\n<li>On-trend colour palette</li>\r\n<li>Durable polyester laces</li>\r\n<li>Fused All Star patch</li>\r\n</ul>\r\n</div>\r\n<div>\r\n<h3>Chuck Taylor All Star Origins</h3>\r\n</div>\r\n<p>Created in 1917 as a non-skid basketball shoe, the All Star was originally promoted for its superior court performance by basketball mastermind Chuck Taylor. But over the decades, something incredible happened: The sneaker, with its timeless silhouette and unmistakable ankle patch, was organically adopted by rebels, artists, musicians, dreamers, thinkers and originals.</p></div>",
                CategoryId = 2,
                BrandId = 4,
                Rating = 4,
                Quantity = 10,
                View = 10000,
                Sold = 2000

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 15,
                Name = "Unisex Converse Chuck Taylor All Star Seasonal Colour High Top Snorkel Blue",
                Price = 150,
                PriceBeforeDiscount = 230,
                Description = "<div data-content-type=\"row\" data-appearance=\"contained\" data-element=\"main\"><div data-enable-parallax=\"0\" data-parallax-speed=\"0.5\" data-background-images=\"{}\" data-background-type=\"image\" data-video-loop=\"true\" data-video-play-only-visible=\"true\" data-video-lazy-load=\"true\" data-video-fallback-src=\"\" data-element=\"inner\" data-pb-style=\"624598B54085D\"><div data-content-type=\"text\" data-appearance=\"default\" data-element=\"main\" data-pb-style=\"624598B540868\"><div>\r\n<h2 class=\"pdp-tab__title text-align--sm-center\">EXPRESS YOURSELF WITH COLOUR.</h2>\r\n</div>\r\n<p id=\"VW4NQSG\">The laidback legend is back in fresh colours. Ready for dressing up or down, these classic canvas Chucks are an everyday wardrobe staple. Plus, we’ve softened up the lining, stitching and seams for maximum comfort all day, every day.</p>\r\n<div>\r\n<h3>Details</h3>\r\n<ul>\r\n<li class=\"pdp-tab__list-item\">Canvas high top sneakers.</li>\r\n<li class=\"pdp-tab__list-item\">OrthoLite insole for cushioning.</li>\r\n<li class=\"pdp-tab__list-item\">New hues bring a pop of colour to any outfit.</li>\r\n<li class=\"pdp-tab__list-item\">Classic woven tongue label and license plate.</li>\r\n<li class=\"pdp-tab__list-item\">Iconic Chuck Taylor ankle patch.</li>\r\n</ul>\r\n</div>\r\n<div>\r\n<h3>Chuck Taylor All Star Origins</h3>\r\n</div>\r\n<p>Created in 1917 as a non-skid basketball shoe, the All Star was originally promoted for its superior court performance by basketball mastermind Chuck Taylor. But over the decades, something incredible happened: The sneaker, with its timeless silhouette and unmistakable ankle patch, was organically adopted by rebels, artists, musicians, dreamers, thinkers and originals.</p></div></div></div>",
                CategoryId = 3,
                BrandId = 4,
                Rating = 4,
                Quantity = 10,
                View = 10000,
                Sold = 2012

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 16,
                Name = "Unisex Converse Chuck Taylor All Star Leather Low Top White\r\n",
                Price = 160,
                PriceBeforeDiscount = 230,
                Description = "<div data-content-type=\"text\" data-appearance=\"default\" data-element=\"main\" data-pb-style=\"PLSW2C1\"><div>\r\n<h2>REMASTERED CLASSIC</h2>\r\n</div>\r\n<p>Leather Chucks. They go with your suit and tie just as much as your sweats and tee. They’re durable and easier to clean—so feel free to wear them, like, all the time. And they’re built like the original, so your Chucks collection stays most iconic. Are you obsessed yet?</p>\r\n<div>\r\n<h3>Details</h3>\r\n<ul>\r\n<li>Luxe, full-grain leather upper, with that classic Chucks look</li>\r\n<li>OrthoLite cushioning helps to provide optimal comfort</li>\r\n<li>Iconic All Star tongue label and license plate</li>\r\n<li>Medial eyelets enhance airflow</li>\r\n</ul>\r\n</div>\r\n<div>\r\n<h3>Chuck Taylor All Star Origins</h3>\r\n</div>\r\n<p>Created in 1917 as a non-skid basketball shoe, the All Star was originally promoted for its superior court performance by basketball mastermind Chuck Taylor. But over the decades, something incredible happened: The sneaker, with its timeless silhouette and unmistakable ankle patch, was organically adopted by rebels, artists, musicians, dreamers, thinkers and originals.</p></div>",
                CategoryId = 4,
                BrandId = 4,
                Rating = 4,
                Quantity = 10,
                View = 10000,
                Sold = 20300

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 17,
                Name = "Nike Air Max 95",
                Price = 380,
                PriceBeforeDiscount = 390,
                Description = "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">The radiance lives on in the Nike Air Force 1 '07, the b-ball icon that puts a fresh spin on what you know best: crisp leather, bold colours and the perfect amount of flash to make you shine.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->White/Black</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->CT2302-100</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>",
                CategoryId = 4,
                BrandId = 1,
                Rating = 4,
                Quantity = 10,
                View = 10000,
                Sold = 11212

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 18,
                Name = "Jumpman MVP",
                Price = 161.99,
                PriceBeforeDiscount = 230,
                Description = "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">The radiance lives on in the Nike Air Force 1 '07, the b-ball icon that puts a fresh spin on what you know best: crisp leather, bold colours and the perfect amount of flash to make you shine.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->White/Black</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->CT2302-100</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>",
                CategoryId = 3,
                BrandId = 1,
                Rating = 2.6,
                Quantity = 10,
                View = 2000,
                Sold = 12012

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 19,
                Name = "Nike Invincible 3 Blueprint Men's Road Running Shoes",
                Price = 180,
                PriceBeforeDiscount = 230,
                Description = "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">The radiance lives on in the Nike Air Force 1 '07, the b-ball icon that puts a fresh spin on what you know best: crisp leather, bold colours and the perfect amount of flash to make you shine.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->White/Black</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->CT2302-100</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>",
                CategoryId = 4,
                BrandId = 4,
                Rating = 2.5,
                Quantity = 10,
                View = 6300,
                Sold = 152012

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 20,
                Name = "Air Jordan 1 Low",
                Price = 190,
                PriceBeforeDiscount = 330,
                Description = "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">The radiance lives on in the Nike Air Force 1 '07, the b-ball icon that puts a fresh spin on what you know best: crisp leather, bold colours and the perfect amount of flash to make you shine.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->White/Black</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->CT2302-100</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>",
                CategoryId = 2,
                BrandId = 1,
                Rating = 4.8,
                Quantity = 10,
                View = 1000,
                Sold = 4012

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 21,
                Name = "Nike V2K Run",
                Price = 180,
                PriceBeforeDiscount = 250,
                Description = "<div id=\"product-description-container\" data-testid=\"product-description-container\" class=\"pt7-sm\"><p class=\"nds-text css-pxxozx e1yhcai00 text-align-start appearance-body1 color-primary weight-regular\" data-testid=\"product-description\">The radiance lives on in the Nike Air Force 1 '07, the b-ball icon that puts a fresh spin on what you know best: crisp leather, bold colours and the perfect amount of flash to make you shine.</p><br><ul class=\"css-1vql4bw eru6lik0 nds-list\" style=\"text-align:left\"><li data-testid=\"product-description-color-description\">Colour Shown:<!-- --> <!-- -->White/Black</li><li data-testid=\"product-description-style-color\">Style:<!-- --> <!-- -->CT2302-100</li><li data-testid=\"product-description-country-of-origin\">Country/Region of Origin: Vietnam</li></ul></div>",
                CategoryId = 1,
                BrandId = 1,
                Rating = 5,
                Quantity = 10,
                View = 34000,
                Sold = 25512

            });

            var urlImages = "https://localhost:7000/";
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id=1,
                Url = urlImages + "ProductImages/1.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 1,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 2,
                Url = urlImages + "ProductImages/2.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 1,
            });



            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 3,
                Url = urlImages + "ProductImages/3.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 1,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 4,
                Url = urlImages + "ProductImages/4.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 1,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 5,
                Url = urlImages + "ProductImages/5.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 2,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 6,
                Url = urlImages + "ProductImages/6.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 2,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 7,
                Url = urlImages + "ProductImages/7.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 2,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 8,
                Url = urlImages + "ProductImages/8.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 2,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 9,
                Url = urlImages + "ProductImages/9.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 3,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 10,
                Url = urlImages + "ProductImages/10.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 3,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 11,
                Url = urlImages + "ProductImages/11.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 3,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 12,
                Url = urlImages + "ProductImages/12.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 1,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 13,
                Url = urlImages + "ProductImages/13.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 3,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 14,
                Url = urlImages + "ProductImages/14.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 3,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 15,
                Url = urlImages + "ProductImages/15.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 3,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 16,
                Url = urlImages + "ProductImages/16.png",
                IsMain = false,
                PublicId = "admin",
                ProductId = 4,
            });


            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 17,
                Url = urlImages + "ProductImages/1.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 4,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 18,
                Url = urlImages + "ProductImages/1.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 4,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 19,
                Url = urlImages + "ProductImages/2.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 5,
            }); modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 20,
                Url = urlImages + "ProductImages/3.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 5,
            }); modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 21,
                Url = urlImages + "ProductImages/4.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 5,
            }); modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 22,
                Url = urlImages + "ProductImages/5.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 5,
            }); modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 23,
                Url = urlImages + "ProductImages/6.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 6,
            }); modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 24,
                Url = urlImages + "ProductImages/7.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 6,
            }); modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 25,
                Url = urlImages + "ProductImages/8.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 6,
            }); modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 26,
                Url = urlImages + "ProductImages/9.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 6,
            }); modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 27,
                Url = urlImages + "ProductImages/10.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 7,
            }); modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 28,
                Url = urlImages + "ProductImages/11.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 7,
            }); modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 29,
                Url = urlImages + "ProductImages/1.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 7,
            }); modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 30,
                Url = urlImages + "ProductImages/12.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 7,
            }); modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 31,
                Url = urlImages + "ProductImages/13.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 8,
            }); 
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 32,
                Url = urlImages + "ProductImages/14.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 8,
            }); 
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 33,
                Url = urlImages + "ProductImages/15.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 8,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 34,
                Url = urlImages + "ProductImages/16.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 8,
            });


            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 35,
                Url = urlImages + "ProductImages/17.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 9,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 36,
                Url = urlImages + "ProductImages/18.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 9,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 37,
                Url = urlImages + "ProductImages/19.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 9,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 38,
                Url = urlImages + "ProductImages/20.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 10,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 39,
                Url = urlImages + "ProductImages/21.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 11,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 40,
                Url = urlImages + "ProductImages/22.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 12,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 41,
                Url = urlImages + "ProductImages/23.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 12,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 42,
                Url = urlImages + "ProductImages/24.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 12,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 43,
                Url = urlImages + "ProductImages/25.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 12,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 44,
                Url = urlImages + "ProductImages/26.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 13,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 45,
                Url = urlImages + "ProductImages/27.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 13,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 46,
                Url = urlImages + "ProductImages/28.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 13,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 47,
                Url = urlImages + "ProductImages/29.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 13,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 48,
                Url = urlImages + "ProductImages/30.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 14,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 49,
                Url = urlImages + "ProductImages/31.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 14,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 50,
                Url = urlImages + "ProductImages/32.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 14,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 51,
                Url = urlImages + "ProductImages/33.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 14,
            });


            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 52,
                Url = urlImages + "ProductImages/33.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 14,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 53,
                Url = urlImages + "ProductImages/34.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 14,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 54,
                Url = urlImages + "ProductImages/35.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 15,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 55,
                Url = urlImages + "ProductImages/36.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 15,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 56,
                Url = urlImages + "ProductImages/37.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 15,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 57,
                Url = urlImages + "ProductImages/38.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 16,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 58,
                Url = urlImages + "ProductImages/39.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 16,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 59,
                Url = urlImages + "ProductImages/40.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 16,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 60,
                Url = urlImages + "ProductImages/39.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 17,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 61,
                Url = urlImages + "ProductImages/40.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 17,

            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 62,
                Url = urlImages + "ProductImages/41.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 17,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 63,
                Url = urlImages + "ProductImages/42.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 17,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 64,
                Url = urlImages + "ProductImages/43.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 17,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 65,
                Url = urlImages + "ProductImages/44.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 18,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 66,
                Url = urlImages + "ProductImages/45.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 18,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 68,
                Url = urlImages + "ProductImages/46.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 19,
            });
            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 69,
                Url = urlImages + "ProductImages/47.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 19,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 70,
                Url = urlImages + "ProductImages/48.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 19,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 71,
                Url = urlImages + "ProductImages/49.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 19,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 72,
                Url = urlImages + "ProductImages/50.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 20,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 73,
                Url = urlImages + "ProductImages/51.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 20,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 74,
                Url = urlImages + "ProductImages/52.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 20,
            });


            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 75,
                Url = urlImages + "ProductImages/53.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 20,
            });


            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 76,
                Url = urlImages + "ProductImages/54.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 20,
            });


            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 77,
                Url = urlImages + "ProductImages/55.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 21,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 78,
                Url = urlImages + "ProductImages/56.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 21,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 79,
                Url = urlImages + "ProductImages/57.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 21,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 80,
                Url = urlImages + "ProductImages/58.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 21,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 81,
                Url = urlImages + "ProductImages/59.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 21,
            });

            modelBuilder.Entity<Photo>().HasData(new Photo
            {
                Id = 82,
                Url = urlImages + "ProductImages/60.jpg",
                IsMain = false,
                PublicId = "admin",
                ProductId = 21,
            });


        }
    }
}
