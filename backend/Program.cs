var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/orders" , ProcessarPedido);

app.Run();

OrderResponse ProcessarPedido(OrderRequest order)
{
    var resposta = OrderAccumulator.Processar(order);
    return resposta;

}
