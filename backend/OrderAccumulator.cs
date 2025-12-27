public static class OrderAccumulator
{
    private const double valorMaximo = 1000000;

 public static OrderResponse Processar(OrderRequest order)
    {
        double exposicaoAtual = Storage.Exposicoes[order.Ativo];
        double impacto = order.Preco * order.Quantidade;

        double novaExposicao = exposicaoAtual;

        if (order.Lado == "C")
        {
        novaExposicao += impacto;
        }

        if (order.Lado == "V")
        {
        novaExposicao -=  impacto;
        }

        if(Math.Abs(novaExposicao) > valorMaximo)
        {
            return new OrderResponse
            {
                Sucesso = false,
                Msg_Erro= "Exposição Atual ultrapassou R$ 1.000.000 ( Um milhão )",
                Exposicao_atual = exposicaoAtual
            };
        
        }
            
            Storage.Exposicoes[order.Ativo] = novaExposicao;

            return new OrderResponse
            {
               Sucesso = true,
               Msg_Erro = "",
               Exposicao_atual = novaExposicao   

            };

    }
}