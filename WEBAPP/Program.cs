using Microsoft.EntityFrameworkCore;
using Plugins.Datastore.InMemory;
using Plugins.DataStore.SQL;
using UseCases.CategoriesUseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.interfaces;
using UseCases.ProductsUseCase;
using UseCases.TransactionsUseCase;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MarketContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MarketManagement"));
});
builder.Services.AddControllersWithViews();
if (builder.Environment.IsEnvironment("QA"))
{
    builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();
    builder.Services.AddSingleton<IProductRepository, ProductsInMemoryRepository>();
    builder.Services.AddSingleton<ITransactionRepository, TransactionInMemoryRepostiory>();
}
else
{
    builder.Services.AddTransient<ICategoryRepository, CategorySqlRepository>();
    builder.Services.AddTransient<IProductRepository, ProductSqlRepository>();
    builder.Services.AddTransient<ITransactionRepository, TransactionSqlRepository>();
}

builder.Services.AddTransient<IViewCategoryUseCase,ViewCategoryUseCase>();
builder.Services.AddTransient<IViewSelectedCategoryUseCase, ViewSelectedCategoryUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();

builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
builder.Services.AddTransient<IViewSelectedProductUseCase, ViewSelectedProductUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IViewProductsByCategoryUseCase, ViewProductsByCategoryUseCase>();
builder.Services.AddTransient<ISellProductUseCase,SellProductUseCase>();

builder.Services.AddTransient<ISearchTransactionUseCase,SearchTransactionUseCase>();
builder.Services.AddTransient<IAddTransactionUseCase, AddTransactionUseCase>();
builder.Services.AddTransient<IViewTransactionByCashierAndDate, ViewTransactionByCashierAndDate>();
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(name: "default",
                       pattern:"{controller=Home}/{action=Index}/{id?}");

app.Run();
