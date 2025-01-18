# ThalesTest

Repository to Upload Thales Developer test artifacts and solution

## ProductController

The `ProductController` is an ASP.NET MVC controller that manages interactions with products. It provides actions to fetch and display products, both in views and in JSON format for use in APIs.

### Requirements

- **ASP.NET Core MVC**
- **ASP.NET Framework V8** [Link](https://dotnet.microsoft.com/es-es/download/dotnet/8.0)
- **Visual Studio 2022 to support Framework V8** [Link](https://visualstudio.microsoft.com/es/vs/community/)
- **C#**

### Controller Actions

The `ProductController` contains actions to interact with the products:

#### 1. **Products**

**Route**: `GET /Product/Products`

This action fetches a list of products and displays them in a view. Products are returned paginated.

##### Query Parameters:

- **page** (optional): The page number to display. Defaults to `1`.
- **pageSize** (optional): The number of products per page. Defaults to `10`.

#### 2. **Products detail by id**

**Route**: `GET /Product/ProductDetail/{id}`

This action fetches details of a specific product using its id and displays them in a view.

##### Query Parameters:

- **id** (required): The unique identifier of the product

#### 3. **CheckProduct**

**Route**: `GET /Product/CheckProduct/{id}`

This action returns a JSON response indicating whether a product exists based on its id.

##### Query Parameters:

- **id** (required): The unique identifier of the product.

#### 4. **GetProducts**

**Route**: `GET /Product/GetProducts`

This action returns all products in a JSON format.

#### 5. **GetProductById**

**Route**: `GET /Product/GetProductById/{id}`

This action returns the details of a specific product in a JSON format.

##### Query Parameters:

- **id** (required): The unique identifier of the product.

### Installation

- Clone this repository to your local machine.

- Ensure all NuGet dependencies are installed.

- Run the application in Visual Studio 22 or configure previous VS to support Framework 8

- _Note:_ Make sure to run the app with http protocol instead of https
