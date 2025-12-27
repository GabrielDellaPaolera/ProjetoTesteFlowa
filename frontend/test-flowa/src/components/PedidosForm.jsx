import { useState } from "react";
import { enviarPedido } from "../services/OrderGenerator";

function PedidosForm(){

    const [ativo, setAtivo] = useState("PETR4");
    const [lado,setLado] = useState("C");
    const [quantidade, setQuantidade] = useState("");
    const [preco, setPreco] = useState("");
    const [resultado, setResultado] = useState(null);

    async function handleSubmit(e){
        e.preventDefault();

        const pedido = {
            ativo,
            lado,
            quantidade: Number(quantidade),
            preco: Number(preco)
        };

        const response = await enviarPedido(pedido);
        setResultado(response);
    }


    return ( 
    <div> 
        <h2>Order Generator</h2>

        <form onSubmit = {handleSubmit}>

        <div> 
        <label>Ativo</label>
         <select value={ativo} onChange={e=> setAtivo(e.target.value)}>
            <option value="PETR4">PETR4</option>
            <option value="VALE3">VALE3</option>
            <option value="VIIA4">VIIA4</option>        
         </select>
        </div>

        <div>
            <label>Lado</label>
            <select value ={lado} OnChange ={ e => setLado(e.target.value)}>
            <option value = "C"> Compra</option>
            <option value = "V"> Venda</option>
            </select>
        </div>

        <div>
          <label>Quantidade</label>
          <input
            type="number"
            value={quantidade}
            onChange={e => setQuantidade(e.target.value)}
          />
        </div>

        <div>
          <label>Preço</label>
          <input
            type="number"
            step="0.01"
            value={preco}
            onChange={e => setPreco(e.target.value)}
          />
        </div>

        <button type="submit">Enviar</button>
      </form>

      {resultado && (
        <div>
          <p><strong>Sucesso:</strong> {resultado.sucesso ? "Sim" : "Não"}</p>
          <p><strong>Exposição Atual:</strong> {resultado.exposicao_atual}</p>
          {!resultado.sucesso && (
            <p style={{ color: "red" }}>{resultado.msg_Erro}</p>
          )}
        </div>
      )}
    </div>
  );
}

export default PedidosForm;