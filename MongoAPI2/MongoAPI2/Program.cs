var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DB ba�lant� bilgilerini programa aktard�k.
builder.Services.Configure<MongoAPI2.DBSettings>(
    builder.Configuration.GetSection("DemoDatabase"));


//Servis tan�mlamas� yapar, program tekra tekrar yenisini olu�turmaz.
builder.Services.AddSingleton<MongoAPI2.OrnekService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
