using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Infa2Semestr.SecondKR.Linq
{
    /// <summary> 
    /// просто на 3 балла, сложный на 5 баллов 
    /// </summary> 
    public class Linq
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Price
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public decimal Sum { get; set; }
            public bool IsActual { get; set; }
        }
        public class Bill
        {
            private decimal money;
            private List<Product> products;
            public decimal Money { get { return money; } }
            public List<Product> Products { get { return products; } }

            public Bill() { }
            public Bill(List<Product> _products, List<Price> prices)
            {
                products = _products;
                var productsId = (from pr in products select pr.Id).ToList();
                var answer = new List<decimal>();
                answer = (from x in prices where (productsId.Contains(x.ProductId) == true && x.IsActual == true) select x.Sum).ToList();
                money = answer.Sum();
            }
            public void GetBill(List<Price> prices)
            {
                Console.WriteLine("Услуги:");
                Console.WriteLine("----------------------");
                foreach (var product in products)
                {
                    string name = product.Name;
                    var price = prices.First(x => x.ProductId == product.Id);
                    name += Convert.ToString(price.Sum);
                }
                Console.WriteLine($"Итого: {money}");
            }

        }

        public class Sale
        {
            public int productId;
            public int Sale1;
            public Sale(int id, int _sale)
            {
                Sale1 = _sale;
                productId = id;
            }

        }

        public static void Run()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Аквариум 10 литров" },
                new Product { Id = 2, Name = "Аквариум 20 литров" },
                new Product { Id = 3, Name = "Аквариум 50 литров" },
                new Product { Id = 4, Name = "Аквариум 100 литров" },
                new Product { Id = 5, Name = "Аквариум 200 литров" },
                new Product { Id = 6, Name = "Фильтр" },
                new Product { Id = 7, Name = "Термометр" }
            };

            var prices = new List<Price>
            {
                new Price { Id = 1, ProductId = 1, Sum = 100, IsActual = false },
                new Price { Id = 2, ProductId = 1, Sum = 123, IsActual = true },
                new Price { Id = 3, ProductId = 2, Sum = 234, IsActual = true },
                new Price { Id = 4, ProductId = 3, Sum = 532, IsActual = true },
                new Price { Id = 5, ProductId = 4, Sum = 234, IsActual = true },
                new Price { Id = 6, ProductId = 5, Sum = 534, IsActual = true },
                new Price { Id = 7, ProductId = 5, Sum = 124, IsActual = false },
                new Price { Id = 8, ProductId = 6, Sum = 153, IsActual = true },
                new Price { Id = 9, ProductId = 7, Sum = 157, IsActual = true }
            };

            var products1 = new List<Product>
            {
                new Product { Id = 1, Name = "Аквариум 10 литров" },
                new Product { Id = 7, Name = "Аквариум 20 литров" },
                new Product { Id = 3, Name = "Аквариум 50 литров" },
            };
            var bill = new Bill(products1, prices);
            bill.GetBill(prices);


            Console.WriteLine("----------------------");
            // 3 
            foreach (var
                product in products)
            {
                var ex3 = (from x in prices where x.ProductId == product.Id select x.Sum).ToList();
                decimal result = ex3.Average();
                Console.WriteLine(result);
            }
            Console.WriteLine("----------------------");
            // 4 
            var ex4 = new List<Sale> {
                new Sale(1, 15),
                new Sale(3, 20)
            };

            var ex5 = (
                from x in ex4
                from y in prices
                where (x.productId == y.ProductId && y.IsActual == true)
                select (products.First(z => z.Id == y.ProductId).Name, y.Sum, y.Sum * (1 - (x.Sale1 / 100)))
            ).ToList();
            foreach (var a1 in ex5)
            {
                Console.Write(a1.Name + " ");
                Console.Write(a1.Sum + " ");
                Console.Write(a1.Item3);
            }
            
            /*Задания              *  
             * 1) создать список счетов (один счет содержит несколько пар цена-количество) 
             * например, один счет - это аквариум на 200 литров, два фильтра и термометр 
             * 2) вывести счет для покупателя с колонками "Наименование услуги, сумма, итого" 
             *  - 1 балл 
             * 3) Вывести среднюю цену для каждого продукта с учетом неактуальных значений 
             * - 1 балл 
             * 4) создать список акций (код продукта, скидка): 
             * аквариум на 200 литров + 2 фильтра - скидка 15% 
             * аквариум 100 литров + 2 фильтра - 10% скидка 
             * любой другой аквариум + фильтр - 5% скидка 
             * 5) создать список перенчень всех названий товаров в группе акции +  
             * цена до скидки + цена с учетом скидки  - 1 балл 
             *  
             * Для тех, кто выбрал вариант посложнее: написать функцию подсчета  
             * суммы покупки (выявлять, есть ли в наборе продуктов акционные комплекты, 
             * при их наличии делать скидку) - это + 2 балла 
             */
        }
    }
}