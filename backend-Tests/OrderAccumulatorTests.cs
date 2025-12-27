public class OrderAccumulatorTests
{


    public OrderAccumulatorTests ()
    {
        Storage.Exposicoes.Clear();
        Storage.Exposicoes["PETR4"] = 0;

    }



    [Fact]
    public void Verifica_Compra_Sucesso()
    {
        var order = new OrderRequest
        {
            Ativo = "PETR4",
            Lado = "C",
            Quantidade = 100,
            Preco = 1000
        };
    

    var response = OrderAccumulator.Processar(order);

    Assert.True(response.Sucesso);
    Assert.Equal(100000, response.Exposicao_atual);

    }


[Fact]

public void Verifica_Venda_Sucesso()
{

    Storage.Exposicoes["PETR4"] = 200000;
    
    var order = new OrderRequest()
    {
        Ativo = "PETR4",
        Lado = "V",
        Quantidade = 50,
        Preco = 1000
    };

    var response = OrderAccumulator.Processar(order);

    Assert.Equal(150000, response.Exposicao_atual);
    Assert.True(response.Sucesso);

}

[Fact]

public void Retornar_Erro_Limite_Exposicao()
    {

        Storage.Exposicoes["PETR4"] = 900000;
        
        var order = new OrderRequest
        {
            Ativo = "PETR4",
            Lado = "C",
            Quantidade = 50,
            Preco =  10000, 

        };

        var response = OrderAccumulator.Processar(order);


        Assert.False(response.Sucesso);
        Assert.Equal(900000, response.Exposicao_atual);
        Assert.Contains("exposição", response.Msg_Erro.ToLower());


    }

}
