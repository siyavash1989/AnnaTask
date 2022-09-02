using API.Extensions;
using API.Helper;
using API.Middlewares;
using Core.Interfaces;
using Infrastructure.Context.Identity;
using Infrastructure.Context.Store;
using Infrastructure.Context.UserBasket;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(opt=>{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnectionString"));
});
builder.Services.AddDbContext<IdentityContext>(opt=>{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnectionString"));
});
builder.Services.AddDbContext<BasketContext>(opt=>{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("BasketConnectionString"));
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ITokenService, TokenServices>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionMiddleware();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllers();
app.UseEndpoints(endpoints =>{
    endpoints.MapControllers();
});

app.Run();

