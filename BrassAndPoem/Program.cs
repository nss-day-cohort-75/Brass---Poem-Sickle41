
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

List<Product> products = new List<Product>(){
    new Product() {Name = "Trumpet", Price = 259.99M, ProductTypeId = 1},
    new Product() {Name = "French Horn", Price = 309.99M, ProductTypeId = 1},
    new Product() {Name = "Trombone", Price = 359.99M, ProductTypeId= 1},
    new Product() { Name = "The Raven", Price = 12.99M, ProductTypeId = 2 },
    new Product() { Name = "Ode to a Nightingale", Price = 9.99M, ProductTypeId = 2 }

};


//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 

List<ProductType> productTypes = new List<ProductType>(){
    new ProductType() {Title = "Brass", Id = 1},
    new ProductType() {Title = "Poem", Id = 2}
};


//put your greeting here

string greeting = "Welcome to the Brass and Poem Shop!";

Console.WriteLine(greeting);

//implement your loop here

string choice = null;

while (choice != "5") 
{
    DisplayMenu();
    
    try
    {
        choice = Console.ReadLine();

        if (choice == "5")
        {
            Console.WriteLine("Goodbye!");
        }
        else if (choice == "1")
        {
            DisplayAllProducts(products, productTypes);
        }
        else if (choice == "2")
        {
            DeleteProduct(products, productTypes);
        }
        else if (choice == "3")
        {
            AddProduct(products, productTypes);
        }
        else if (choice == "4")
        {
            UpdateProduct(products, productTypes);
        }
        else
        {
            throw new Exception("Invalid choice. Please enter a number between 1 and 5.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


void DisplayMenu()
{
    Console.WriteLine(@"Choose an option
    1. Display All Products
    2. Delete Product
    3. Add Product
    4. Update Product
    5. Exit");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    int index = 1; // Keep track of numbering
    foreach (Product product in products) 
    {
        var productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
        Console.WriteLine($"{index}. {product.Name} - ${product.Price} - ({productType.Title})");
        index++; // Increment after each product
    }
}


void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);
            Console.Write("Enter the name of the product to delete: ");
            string name = Console.ReadLine();

            var productToRemove = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                Console.WriteLine("Product deleted.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            };
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.Write("Enter the name of the new product: ");
            string name = Console.ReadLine();

            Console.Write("Enter the price of the new product: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Choose a product type: ");
                for (int i = 0; i < productTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
                }

                Console.Write("Enter the product type number: ");
                if (int.TryParse(Console.ReadLine(), out int productTypeId) && productTypeId > 0 && productTypeId <= productTypes.Count)
                {
                    products.Add(new Product { Name = name, Price = price, ProductTypeId = productTypeId });
                    Console.WriteLine("Product added.");
                }
                else
                {
                    Console.WriteLine("Invalid product type.");
                }
            }
            else
            {
                Console.WriteLine("Invalid price.");
            }
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);
            Console.Write("Enter the name of the product to update: ");
            string name = Console.ReadLine();

            var productToUpdate = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (productToUpdate != null)
            {
                Console.Write($"Enter new name for {productToUpdate.Name} (or press Enter to keep unchanged): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    productToUpdate.Name = newName;
                }

                Console.Write($"Enter new price for {productToUpdate.Price} (or press Enter to keep unchanged): ");
                if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
                {
                    productToUpdate.Price = newPrice;
                }

                Console.WriteLine("Choose a new product type: ");
                for (int i = 0; i < productTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
                }

                Console.Write("Enter the product type number: ");
                if (int.TryParse(Console.ReadLine(), out int newProductTypeId) && newProductTypeId > 0 && newProductTypeId <= productTypes.Count)
                {
                    productToUpdate.ProductTypeId = newProductTypeId;
                    Console.WriteLine("Product updated.");
                }
                else
                {
                    Console.WriteLine("Invalid product type.");
                }
            }
}

// don't move or change this!
public partial class Program { }