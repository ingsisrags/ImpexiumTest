using Infrastructure.DataContext;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.Infrastructure.Data
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(new List<Product>
                {
                    new Product {Name = "Wireless Mouse inphic", Description = "Wireless Mouse inphic Large Ergonomic Rechargeable 2.4G Optical PC Laptop Cordless Mice with USB Nano Receiver, for Windows Computer Office, Black", Quantity = 150},
                    new Product {Name = "Manhattan Wired Computer Keyboard ", Description = "Black – Basic Keyboard - with 5ft USB-A Cable, 104-keys, Foldable Stands - Compatible for Windows, PC, Laptop - 3 Year Warranty - 179324", Quantity = 200},
                    new Product {Name = "CHUWI CoreBook X 14''", Description = "Intel i5 Quad Core(Up to 3.8GHz), 512GB SSD, 8GB DDR4 RAM, 2160x1440 Display, Backlit Keyboard, USB-C Dual Wi-Fi, Thin and Light Windows 10 Business Notebook Computer" , Quantity = 20},
                    new Product {Name = "Newest Flagship Acer R13 13.3", Description = "Convertible 2-in-1 Full HD IPS Touchscreen Chromebook - Intel Quad-Core MediaTek MT8173C 2.1GHz, 4GB RAM, 64GB SSD, WLAN, Bluetooth, Webcam, HDMI, USB 3.0, Chrome OS", Quantity = 100},
                    new Product {Name = "X-VOLSPORT", Description = "Massage Gaming Chair with Footrest Reclining High Back Computer Game Chair with Lumbar Support and Headrest, Racing Style Video Gamer Chair Red", Quantity = 100},
                });
                
                await context.SaveChangesAsync();
            }
        }
    }
}