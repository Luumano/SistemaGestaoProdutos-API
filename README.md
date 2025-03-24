# Sistema de Gestão de Pedidos - API REST

## Descrição
Esta é uma API REST desenvolvida para gerenciamento de produto de um e-commerce simples. O sistema permite cadastrar produtos e pagamentos, aplicando conceitos de uma **Pirâmide de Testes** que foi utizada em outro projeto, para garantir a qualidade do código.

## Funcionalidades
- **Gerenciamento de Produtos**
  - Criar, buscar por ID e atualizar estoque de produtos, deletar o produto.
- **Gerenciamento de Pagamentos**
  - Realizar pagamento de pedidos.
    
## Tecnologias Utilizadas
- **.NET 6+**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQLite ou SQL Server**
- **Swagger (OpenAPI)** para documentação da API
- **xUnit, Moq e Coverlet** para testes unitários, de integração e cobertura de código
- **Postman** para testes de API

## Como Executar o Projeto
### 1. Clonar o Repositório
```sh
git clone https://github.com/Luumano/SistemaGestaoProdutos-API.git
cd SistemaGestaoProdutos-API
```

### 2. Executar a API
```sh
 dotnet run --project src/SistemaGestaoPedidos.Api
```
A API estará rodando em `http://localhost:5000` ou `https://localhost:5001`.

## Endpoints Principais

### **Produtos**
- `GET /api/produto` → Lista todos os produtos
- `GET /api/produto/{id}` → Busca um produto pelo ID
- `POST /api/produto` → Cadastra um novo produto
- `PUT /api/produto/{id}` → Atualiza estoque de um produto
- `DELETE /api/produto/{id}` → Deletar Produto

### **Pagamentos**
- `POST /api/pagamento` → Realiza o pagamento de um pedido

## Testes
Para rodar os testes, utilize:
```sh
dotnet test
```

## Coleção de Testes no Postman
Os testes de API podem ser importados no Postman através do arquivo `postman/Sistema E-commerce Simples.postman_collection`.

## Contribuição
1. Fork o repositório
2. Crie uma branch: `git checkout -b feature-minha-melhoria`
3. Commit suas mudanças: `git commit -m 'Minha melhoria'`
4. Push para a branch: `git push origin feature-minha-melhoria`
5. Abra um **Pull Request**
