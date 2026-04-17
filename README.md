# 🛒 Loja — CP2 .NET

## 👥 Integrantes do Grupo

| Nome | RM | Sala |
|------|----|------|
| Juliana Da Silva Stigliani | 561171 | 2TDSPJ |
| Leonardo Zerbinatti de Sales | 562992 | 2TDSPJ |
| Luis Guilherme Borges Silva | 566548 | 2TDSPJ |

## 🌐 Domínio Do Projeto escolhido

Este projeto foi desenvolvido com base no domínio de uma loja online (e-commerce). O sistema representa o fluxo básico de compras, permitindo o gerenciamento de clientes, produtos, pedidos, pagamentos, endereços e estoque.

## 🗄️ SGBD Utilizado

**SQLite** — banco de dados em arquivo, sem necessidade de instalação de servidor.  
O arquivo `loja.db` é gerado automaticamente na pasta `Loja.Api/` ao rodar as migrations.

## ▶️ Como Rodar o Projeto

### Pré-requisitos
- .NET 10 SDK
- Entity Framework Core CLI

### Instalar o EF Core CLI (se necessário)
```bash
dotnet tool install --global dotnet-ef
```

### Restaurar dependências
```bash
dotnet restore
```

### Aplicar as migrations e criar o banco
```bash
dotnet ef database update --project Loja.Infrastructure --startup-project Loja.Api
```

### Rodar a aplicação
```bash
dotnet run --project Loja.Api
```

## 🧩 Entidades Modeladas

- **Cliente** — representa o comprador.
  - `IdCliente` (PK), `Nome`, `Email`, `Senha`, `Telefone`, `DataCadastro`
- **Endereco** — endereços vinculados ao cliente.
  - `IdEndereco` (PK), `Rua`, `Cidade`, `Estado`, `Cep`, `ClienteId` (FK)
- **Pedido** — solicitação de compra.
  - `IdPedido` (PK), `DataPedido`, `Status`, `ValorTotal`, `ClienteId` (FK)
- **ItemPedido** — resolve o N:N entre Pedido e Produto.
  - `IdItemPedido` (PK), `Quantidade`, `PrecoUnitario`, `PedidoId` (FK), `ProdutoId` (FK)
- **Produto** — itens disponíveis na loja.
  - `Id` (PK, Guid), `Nome`, `Preco`, `Ativo`
- **Categoria** — classifica os produtos.
  - `Id` (PK, Guid), `Nome`, `ProdutoId` (FK)
- **Estoque** — controla a quantidade disponível de cada produto.
  - `Id` (PK, Guid), `QuantidadeDisponivel`, `DataAtualizacao`, `ProdutoId` (FK)
- **Pagamento** — informações do pagamento do pedido.
  - `IdPagamento` (PK), `MetodoPagamento`, `Status`, `DataPagamento`, `PedidoId` (FK)

## 🔗 Relacionamentos

| Relacionamento | Cardinalidade | Descrição |
|----------------|---------------|-----------|
| Cliente → Endereco | 1:N | Um cliente pode ter vários endereços |
| Cliente → Pedido | 1:N | Um cliente pode realizar vários pedidos |
| Pedido → Pagamento | 1:1 | Todo pedido possui um único pagamento |
| Pedido → ItemPedido | 1:N | Um pedido contém vários itens |
| Produto → ItemPedido | 1:N | Um produto pode aparecer em vários itens |
| Produto ↔ Pedido | N:N | Resolvido pela entidade ItemPedido |
| Categoria → Produto | N:1 | Uma categoria pertence a um produto |
| Produto → Estoque | 1:N | Um produto pode ter vários registros de estoque |

## 🗂️ Estrutura do Projeto
Loja/
├── Loja.Api            — Web API .NET 10
├── Loja.Application    — Camada de aplicação (interfaces de repositório)
├── Loja.Domain         — Entidades e regras de negócio
└── Loja.Infrastructure — DbContext, Mappings, Migrations e Repositórios

## 📁 Evidências

Os prints do esquema físico gerado estão disponíveis em `[Loja/Loja.Api/docs](https://github.com/justigliani/CP1.net/tree/a4e1f0e71f979e8bc8078429cac66cb73294aa67/Loja/Loja.Api/docs)`
