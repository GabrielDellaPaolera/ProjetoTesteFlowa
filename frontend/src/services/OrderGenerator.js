export async function enviarPedido(pedido){
    const response = await fetch("http://localhost:5000/orders",{
        method:"POST",
        headers:{
            "Content-Type": "application/json"
        },
        body: JSON.stringify(pedido)
    });

    return response.json();
}