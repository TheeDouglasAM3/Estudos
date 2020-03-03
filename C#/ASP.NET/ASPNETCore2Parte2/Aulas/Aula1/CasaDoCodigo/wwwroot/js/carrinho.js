class Carrinho {

    getData(elemento) {
        var linhaDoItem = $(elemento).parents("[item-id]");
        var itemId = $(linhaDoItem).attr("item-id");
        var novaQuantidade = $(linhaDoItem).find("input").val();
        return {
            Id: itemId,
            Quantidade: novaQuantidade
        };
    }

    incrementarProduto(button) {
        let data = this.getData(button);
        data.Quantidade++;
        this.postQuantidade(data);
    }

    decrementarProduto(button) {
        let data = this.getData(button);
        data.Quantidade--;
        this.postQuantidade(data);
    }

    updateQuantidade(input) {
        let data = this.getData(input);
        this.postQuantidade(data);
    }

    postQuantidade(data) {

        let token = $("[name=__RequestVerificationToken]").val();


        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/pedido/updatequantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(response => {
            let itemPedido = response.itemPedido;
            let carrinhoViewModel = response.carrinhoViewModel;

            let linhaDoItem = $('[item-id=' + itemPedido.id + ']');
            linhaDoItem.find('input').val(itemPedido.quantidade);
            linhaDoItem.find('[subtotal]').html((itemPedido.subtotal).duasCasas());

            $('[numero-itens]').html('Total: ' + carrinhoViewModel.itens.length + ' itens')
            $('[total]').html((carrinhoViewModel.total).duasCasas());

            if (itemPedido.quantidade == 0) {
                linhaDoItem.remove();
            }
        });
    }
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.', ',');
}