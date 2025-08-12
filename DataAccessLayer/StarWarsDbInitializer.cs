using DataAccessLayer.Models;
using static DataAccessLayer.Models.Order;

namespace DataAccessLayer
{
    public static class StarWarsDbInitializer
    {
        public static void Initialize(StarWarsDbContext context)
        {
            // Look for any customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
                new Product
                    {
                        ProductId = 1,
                        Name = "C-3PO",
                        Price = 179m,
                        Description = "\"Zeg hallo tegen het meest iconische goudkleurige meesterwerk uit de galaxy!\"\n\n" +
                                        "Exclusieve features:\n" +
                                        "• Met echt metallic finish - 24-karaats goudverf laag-voor-laag aangebracht\n" +
                                        "• Ultra-detailleerd - Elk scharnier en elke kabel exact zoals in de films\n" +
                                        "• Interactieve elementen:\n" +
                                        "  - Verwisselbare armen (inclusief \"rode arm\" variant uit The Force Awakens)\n" +
                                        "  - Oplichtende ogen met 3 lichtmodi\n\n" +

                                        "Bijzonderheden:\n" +
                                        "• Inclusief certificaat van echtheid met Anthony Daniels' handtekening\n" +
                                        "• Originele film-accurate soundboard met 9 catchphrases\n\n" +

                                        "\"Ik ben C-3PO, protocol-droid. Het is een genoegen u te ontmoeten.\"\n\n" +

                                        "Officieel gelicenseerd door Star Wars Unlimited - Een must-have voor elke Star Wars-collection.",
                        ProductImageUrl = "c3po_image.jpg",
                        Stock = 50
                    },
                new Product
                    {
                        ProductId = 2,
                        Name = "Darth Vader",
                        Price = 199m,
                        Description = "\"Ervaar de duistere kracht van de meest iconische Sith Lord aller tijden!\"\n\n" +
                                        "Exclusieve features:\n" +
                                        "• Hypergedetailleerde 1:6 schaal replica (30 cm hoog)\n" +
                                        "• Echt stof cape met binnenkant gevoerd voor dramatische flow\n" +
                                        "• Interactieve elementen:\n" +
                                        "  - Verwisselbare handen (inclusief force-choke en lightsaber grip)\n" +
                                        "  - Oplichtende rode lightsaber met 3 intensiteitsniveaus\n" +
                                        "  - Elektronisch stemgeluid (James Earl Jones' originele lines)\n\n" +

                                        "Bijzonderheden:\n" +
                                        "• Slechts 800 exemplaren wereldwijd\n" +
                                        "• Inclusief certificaat van echtheid met officiële Lucasfilm-hologram\n" +
                                        "• Premium displaystandaard met Death Star-motief\n\n" +

                                        "Officieel gelicenseerd door Star Wars Unlimited - Het ultieme Dark Side-collectorsitem.",
                        ProductImageUrl = "darth_vader.jpg",
                        Stock = 30
                    },
                new Product
                    {
                        ProductId = 3,
                        Name = "Luke Skywalker",
                        Description = "\"May The Force Be With You\" - Beleef Luke Skywalker's iconische reis!\n\n" +
                            "Premium Collector's Edition:\n" +
                            "• Gedetailleerd 1:6 figuur (30 cm) met 28 bewegingspunten\n" +
                            "• Twee verwisselbare gezichten:\n" +
                            "  - Jonge boerenjongen (Tatooine)\n" +
                            "  - Jedi Ridder (Return of the Jedi)\n" +
                            "• Authentieke kostuumdetails:\n" +
                            "  - Trainingsoutfit (Dagobah)\n" +
                            "  - Gevechtsponcho (Endor)\n" +
                            "• Lightsaber met verwisselbaar groen blad\n\n" +

                            "Exclusieve accessoires:\n" +
                            "• Darklighter familie medaillon\n" +
                            "• Trainingsdrone (zwevend)\n" +
                            "• Bespin gevechtsplatform\n" +
                            "• Optionele mechanische hand (Bespin duel versie)\n\n" +

                            "Gelimiteerde oplage:\n" +
                            "• Slechts 1977 exemplaren wereldwijd\n" +
                            "• Genummerd certificaat met echtheidsgarantie\n" +

                            "Officieel gelicenseerd door Star Wars Unlimited | Het ultieme Jedi-collectorsitem",
                        Price = 179m,
                        ProductImageUrl = "luke_skywalker.png",
                        Stock = 20
                    },
                new Product
                    {
                        ProductId = 4,
                        Name = "Palpatine",
                        Price = 179m,
                        Description = "\"Onbeperkte macht!\" - Voeg de Dark Lord of the Sith aan je collectie toe!\n\n" +
                                        "Premium Sith Collectors Edition:\n" +
                                        "• 1:6 schaal ultra-gedetailleerd figuur (32 cm)\n" +
                                        "• Twee iconische looks:\n" +
                                        "  - Senator Sheev Palpatine (vermomming)\n" +
                                        "  - Keizer Palpatine (Sith-robe met kap)\n" +
                                        "• Echt stof kostuum met:\n" +
                                        "  - Gedetailleerde Sith-emblemen\n" +
                                        "  - Zwaar geplooide robe voor dramatisch effect\n\n" +

                                        "Exclusieve Sith-accessoires:\n" +
                                        "• Verwisselbare Force Lightning handen (LED-verlicht)\n" +
                                        "• Sith-scepter met verwijderbaar lightsaber\n" +
                                        "• Death Star troon-standaard\n" +
                                        "• Holocron met Sith-geschiedenis\n\n" +

                                        "Gelimiteerde Sith-editie:\n" +
                                        "• Slechts 66 exemplaren wereldwijd\n" +
                                        "• Zwarte metalen certificaat met Sith-hologram\n" +
                                        "• Inclusief replica 'Darth Plagueis' vertelling audioclip\n\n" +

                                        "\"Wees niet bang... en geef je over aan de Dark Side.\"\n\n" +
                                        "Officieel gelicenseerd door Star Wars Unlimited | Het ultieme Sith-collectorsitem",

                        ProductImageUrl = "palpatine.jpg",
                        Stock = 66
                    },
                new Product
                    {
                        ProductId = 5,
                        Name = "R2-D2",
                        Price = 189m,
                        Description = "\"Bliep-bloep!\" - Welkom de meest trouwe astromech droid in je collectie!\n\n" +

                                        "Premium Astromech Collectors Edition:\n" +
                                        "• 1:4 schaal ultra-gedetailleerde replica (45 cm hoog)\n" +
                                        "• Authentieke filmdetails:\n" +
                                        "  - Meer dan 30 beweegbare onderdelen\n" +
                                        "  - Exacte blauwe/witte kleurstelling\n" +
                                        "  - Werkende luikjes en instrumenten\n\n" +

                                        "High-tech features:\n" +
                                        "• Interactief licht- en geluidssysteem met:\n" +
                                        "  - 15+ originele R2-D2 geluidseffecten\n" +
                                        "  - Oplichtende blauwe dome-sensor\n" +
                                        "• Afstandsbediening via app (iOS/Android)\n" +
                                        "• Oplaadbare batterij (8 uur speeltijd)\n\n" +

                                        "Exclusieve accessoires:\n" +
                                        "• Verwisselbare tools:\n" +
                                        "  - Brandblusser\n" +
                                        "  - Lightsaber-houder\n" +
                                        "  - Periscoop\n" +
                                        "• Death Star vloerdisplay\n" +
                                        "• Mini C-3PO hologram-projectie\n\n" +

                                        "Gelimiteerde editie:\n" +
                                        "• Slechts 1000 exemplaren wereldwijd\n" +
                                        "• Genummerd certificaat met Lucasfilm-hologram\n\n" +

                                        "\"Ik ben R2-D2, astromech droid. Ik ben hier om te helpen!\"\n\n" +
                                        "Officieel gelicenseerd door Star Wars Unlimited | Een must-have voor elke Star Wars-fan!",

                        ProductImageUrl = "r2d2.jpg",
                        Stock = 22
                    },
                new Product
                    {
                        ProductId = 6,
                        Name = "Yoda - Limited Edition",
                        Price = 349m,
                        Description = "\"De Limited Edition Yoda\"\n\n" +

                                        "**Yoda - Jedi Master Limited Edition**\n" +
                                        "• 1:3 schaal hypergedetailleerd figuur (40 cm hoog)\n" +
                                        "• Handgemaakt siliconen hoofd met:\n" +
                                        "  - Echt haar voor baard en wenkbrauwen\n" +
                                        "  - Glanzende ogen met diepe blik\n" +
                                        "• Authentieke Jedi-robe:\n" +
                                        "  - Echt geweven stof\n" +
                                        "  - Verouderde effecten voor filmrealisme\n\n" +

                                        "**Exclusieve Jedi-features:**\n" +
                                        "• Interactieve Force-functies:\n" +
                                        "  - LED-verlichte opgeheven hand (Force-lift effect)\n" +
                                        "  - Geluidseffecten met 12 iconische Yoda-quotes\n" +
                                        "• Verwisselbare accessoires:\n" +
                                        "  - Gimer-stok (lichtgevend)\n" +
                                        "  - Kleine trainingslightsaber\n" +
                                        "  - Dagobah-figuurtje (voor gevechtsscènes)\n\n" +

                                        "**Ultra-exclusieve details:**\n" +
                                        "• Gelimiteerd tot slechts 200 exemplaren wereldwijd\n" +
                                        "• Genummerd certificaat met holografische Jedi-zegel\n" +
                                        "• Inclusief mini-Dagobah diorama als displaystandaard\n\n" +

                                        "**\"Do or do not. There is no try.\"**\n" +
                                        "Officieel gelicenseerd door Lucasfilm | Het ultieme Jedi-collectorsitem",
                        ProductImageUrl = "yoda.jpg",
                        Stock = 5
                    }
            };

            context.Products.AddRange(products);

            var customers = new Customer[]
            {
                new Customer
                {
                    Id = 1,Name = "Jan van Dijk",Address = "Kerkstraat 12, Amsterdam", Email = "yusufisaag12@gmail.com", PhoneNumber = 612345678, Active = true
                },
                new Customer
                {
                    Id = 2, Name = "Lisa de Vries", Address = "Dorpsplein 5, Utrecht", Email = "yusufisaag12@gmail.com", PhoneNumber = 623456789, Active = true
                },
                new Customer
                {
                    Id = 3, Name = "Mohammed Ali", Address = "Beukenlaan 34, Rotterdam", Email = "yusufisaag12@gmail.com", PhoneNumber = 645678901, Active = true
                }
            };
            context.Customers.AddRange(customers);

            var orders = new Order[]
            {
                new Order
                {
                    Customer = customers[0], // Jan van Dijk
                    OrderDate = DateTime.Parse("2023-05-15 08:23:17"),
                    Status = OrderStatus.Received,
                    Products = new List<Product> { products[0], products[2] } // C-3PO + Luke Skywalker

                },
                new Order
                {
                    Customer = customers[2], 
                    OrderDate = DateTime.Parse("2023-05-05 09:45:52"),
                    Status = OrderStatus.Received,
                    Products = new List<Product> { products[5], products[2] } 

                },
                 new Order
                {
                    Customer = customers[1],
                    OrderDate = DateTime.Parse("2023-03-15 11:12:38"),
                    Status = OrderStatus.Received,
                    Products = new List<Product> { products[1], products[4] }

                },
                  new Order
                {
                    Customer = customers[0],
                    OrderDate = DateTime.Parse("2023-12-01 12:30:05"),
                    Status = OrderStatus.Received,
                    Products = new List<Product> { products[3], products[1] }

                },
                new Order
                {
                    Customer = customers[0], // Jan van Dijk
                    OrderDate = DateTime.Parse("2024-03-15 14:18:43"),
                    Status = OrderStatus.Received,
                    Products = new List<Product> { products[4] } // R2-D2
                },
                new Order
                {
                    Customer = customers[1], // Lisa de Vries
                    OrderDate = DateTime.Parse("2024-05-15 16:55:21"),
                    Status = OrderStatus.Received,
                    Products = new List<Product> { products[1], products[3] } // Darth Vader + Palpatine
                },
                new Order
                {
                    Customer = customers[2], // Mohammed Ali
                    OrderDate = DateTime.Parse("2024-07-24 19:07:34"),
                    Status = OrderStatus.Received,
                    Products = new List<Product> { products[5] } // Yoda Limited Edition
                },
                new Order
                {
                    Customer = customers[1], // Lisa de Vries
                    OrderDate = DateTime.Parse("2024-08-15 22:39:56"),
                    Status = OrderStatus.Received,
                    Products = new List<Product> { products[0], products[4], products[5] } // C-3PO + R2-D2 + Yoda
                }
            };
            context.Orders.AddRange(orders);

            context.SaveChanges();

            context.Database.EnsureCreated();
        }
    }
}
