# 🛒 Loja — CP1 .NET

## 👥 Integrantes do Grupo

| Nome | RM | Sala |
|---|---|---|
| Juliana Da Silva Stigliani | 561171 | 2TDSPJ |
| Leonardo Zerbinatti de Sales | 562992 | 2TDSPJ |
| Luis Guilherme Borges Silva | 566548 | 2TDSPJ |

## 🌐 Domínio Do Projeto escolhido

Este projeto foi desenvolvido com base no domínio de uma **loja online (e-commerce)**.  
O sistema representa o fluxo básico de compras, permitindo o gerenciamento de clientes,
produtos, pedidos, pagamentos, endereços e estoque.

## 🧩 Entidades Modeladas

- **Cliente** — representa o comprador.
  - `id_cliente` (PK), `nome`, `email`, `senha`, `telefone`, `data_cadastro`

- **Endereco** — endereços vinculados ao cliente.
  - `id_endereco` (PK), `rua`, `cidade`, `estado`, `cep`, `clientes_id_cliente` (FK)

- **Pedido** — solicitação de compra.
  - `id_pedidos` (PK), `data_pedido`, `status`, `valor_total`, `clientes_id_cliente` (FK), `pagamentos_id_pagamentos` (FK), `pedidos_id_pedidos`

- **ItemPedido** — resolve o N:N entre Pedido e Produto.
  - `id_itens_pedidos` (PK), `quantidade`, `preco_unitario`, `pedidos_id_pedidos` (FK), `produtos_id_produtos` (FK), `id_categorias` (FK)

- **Produto** — itens disponíveis na loja.
  - `id_produtos` (PK), `nome`, `preco`, `categorias_id_categorias` (FK)

- **Categoria** — classifica os produtos.
  - `id_categorias` (PK), `nome`, `produtos_id_produtos`

- **Estoque** — controla a quantidade disponível de cada produto.
  - `id_estoque` (PK), `quantidade_disponivel`, `data_atualizacao`, `produtos_id_produtos` (FK), `id_categorias` (FK)

- **Pagamento** — informações do pagamento do pedido.
  - `id_pagamentos` (PK), `metodo_pagamento`, `status`, `data_pagamento`, `pedidos_id_pedidos` (FK)

## 🔗 Relacionamentos

| Relacionamento | Cardinalidade | Descrição |
|---|---|---|
| Cliente → Endereco | 1:N | Um cliente pode ter vários endereços |
| Cliente → Pedido | 1:N | Um cliente pode realizar vários pedidos |
| Pedido → Pagamento | 1:1 | Todo pedido possui um único pagamento |
| Pedido → ItemPedido | 1:N | Um pedido contém vários itens |
| Produto → ItemPedido | 1:N | Um produto pode aparecer em vários itens |
| Produto ↔ Pedido | N:N | Resolvido pela entidade ItemPedido |
| Categoria → Produto | 1:N | Uma categoria agrupa vários produtos |
| Produto → Estoque | 1:N | Um produto pode ter vários registros de estoque |

## 🗂️ Estrutura do Projeto

O projeto segue a arquitetura **Clean Architecture**:
```
Loja/
├── Loja.Api            — Web API .NET 10
├── Loja.Application    — Camada de aplicação
├── Loja.Domain         — Entidades e regras de negócio
└── Loja.Infrastructure — Infraestrutura
```
## 📄 Diagrama MER

O diagrama MER está disponível em 

O diagrama MER está disponível em [`/docs/mer.png`](./docs/mer.png)

