public class OrderRequest
{
    public string Ativo { get; set; } = "";
    public string Lado  { get; set; } = "";
    public int Quantidade  { get; set; } 
    public decimal Preco  { get; set; }
}

public class OrderResponse
{
    public bool Sucesso {get; set; }
    public string Msg_Erro { get; set; } = "";
    public decimal Exposicao_atual  { get; set; } 
}