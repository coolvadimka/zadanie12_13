var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUser, User>();
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

public class MyModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
public interface IUser
{
    public MyModel Change(MyModel model);
}
public class User : IUser
{
    public MyModel Change(MyModel model)
    {
        model.Name = model.Name.ToUpper();
        return model;
    }

}
