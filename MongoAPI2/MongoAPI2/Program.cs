var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DB baðlantý bilgilerini programa aktardýk.
builder.Services.Configure<MongoAPI2.DBSettings>(
    builder.Configuration.GetSection("DemoDatabase"));


//Servis tanýmlamasý yapar, program tekra tekrar yenisini oluþturmaz.
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
