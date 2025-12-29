var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policy =>
{
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
});


app.MapPost("/orders" , ProcessarPedido);

app.Run();

OrderResponse ProcessarPedido(OrderRequest order)
{
    var resposta = OrderAccumulator.Processar(order);
    return resposta;

}


