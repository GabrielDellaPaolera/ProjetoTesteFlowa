public class OrderRequest
{
    public string Ativo { get; set; } = "";
    public string Lado  { get; set; } = "";
    public double Quantidade  { get; set; } 
    public double Preco  { get; set; }
}

public class OrderResponse
{
    public bool Sucesso {get; set; }
    public string Msg_Erro { get; set; } = "";
    public double Exposicao_atual  { get; set; } 
}