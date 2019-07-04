using System;
using System.IO;

namespace Data_Inserter
{
    class Program
    {
        static void Main(string[] args)
        {
            AddEntries();
            Console.WriteLine("Done");
        }

        private static void AddEntries()
        {
            using (var dbContext = new WebshopContext())
            {
                /// Categories ///
                using(var streamReader = new StreamReader(UserData.CategoryPath))
                {
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var data = line.Split(new[] { ',' });
                        var CategoryData = new Category()
                        {
                            Id = int.Parse(data[0]),
                            CategoryName = data[1] 
                        };
                        dbContext.Categories.Add(CategoryData);
                    }
                }

                /// Types ///
                using(var streamReader = System.IO.File.OpenText(UserData.TypePath))
                {
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var data = line.Split(new[] { ',' });
                        var TypeData = new _Type()
                        {
                            Id = int.Parse(data[0]),
                            _TypeName = data[1] 
                        };
                        dbContext.Types.Add(TypeData);
                    }
                }

                /// CategoryTypes ///
                using(var streamReader = System.IO.File.OpenText(UserData.CategoryTypePath))
                {
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var data = line.Split(new[] { ',' });
                        var CategoryTypeData = new Category_Type()
                        {
                            CategoryId = int.Parse(data[0]),
                            _TypeId = int.Parse(data[1])
                        };
                        //dbContext.CategoryType.Add(CategoryTypeData);
                    }
                }

                /// Brands ///
                using(var streamReader = System.IO.File.OpenText(UserData.BrandPath))
                {
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var data = line.Split(new[] { ',' });
                        var BrandData = new Brand()
                        {
                            Id = int.Parse(data[0]),
                            BrandName = data[1] 
                        };
                        dbContext.Brands.Add(BrandData);
                    }
                }

                /// Collections ///
                using(var streamReader = System.IO.File.OpenText(UserData.CollectionPath))
                {
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var data = line.Split(new[] { ',' });
                        var CollectionData = new Collection()
                        {
                            Id = int.Parse(data[0]),
                            BrandId = int.Parse(data[1]),
                            CollectionName = data[2]
                        };
                        dbContext.Collections.Add(CollectionData);
                    }
                }

                /// Stock ///
                using(var streamReader = System.IO.File.OpenText(UserData.StockPath))
                {
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var data = line.Split(new[] { ',' });
                        var StockData = new Stock()
                        {
                            Id = int.Parse(data[0]),
                            ProductQuantity = int.Parse(data[1])
                        };
                        dbContext.Stock.Add(StockData);
                    }
                }

                /// Products ///
                using(var streamReader = System.IO.File.OpenText(UserData.ProductPath))
                {
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var data = line.Split(new[] { ',' });
                        for(int i = 0; i < data.Length; i++)
                        {
                            if (data[i].Contains("(KOMMA)")) data[i] = data[i].Replace("(KOMMA)", ",");
                            if (data[i].Contains("(ENTER)")) data[i] = data[i].Replace("(ENTER)", "<br/>");
                        }
                        var ProductData = new Product()
                        {
                            Id = int.Parse(data[0]),
                            ProductNumber = data[1],
                            ProductName = data[2],
                            ProductEAN  = data[3],
                            ProductInfo = data[4],
                            ProductDescription = data[5],
                            ProductSpecification = data[6],
                            ProductPrice = double.Parse(data[7]),
                            ProductColor = data[8],
                            _TypeId = int.Parse(data[9]),
                            CategoryId = int.Parse(data[10]),
                            CollectionId = int.Parse(data[11]),
                            BrandId  = int.Parse(data[12]),
                            StockId = int.Parse(data[13])
                        };
                        dbContext.Products.Add(ProductData);
                    }
                }

                /// Product Images ///
                using(var streamReader = System.IO.File.OpenText(UserData.ProductImagePath))
                {
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var data = line.Split(new[] { ',' });
                        var ImageData = new ProductImage()
                        {
                            Id = int.Parse(data[0]),
                            ProductId = int.Parse(data[1]),
                            ImageURL = data[2]                         
                        };
                        dbContext.ProductImages.Add(ImageData);
                    }
                }

                /// description ///
                using(var streamReader = new StreamReader(UserData.OrderDescription))
                {
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var data = line.Split(new[] { ',' });
                        var OrderDescriptionData = new OrderStatus()
                        {
                            Id = int.Parse(data[0]),
                            OrderDescription = data[1] 
                        };
                        dbContext.OrderStatus.Add(OrderDescriptionData);
                    }
                }

                dbContext.SaveChanges();
            }
        }
    }
 }
