# WebApplicationApi

Uma API RESTful desenvolvida em ASP.NET Core para gerenciamento de pedidos, produtos, clientes e status. Esta API permite criar, listar, editar e excluir pedidos, com funcionalidade para associar produtos a pedidos e clientes.

## Índice
- [Tecnologias](#tecnologias)
- [Instalação](#instalação)
- [Configuração do Banco de Dados](#configuração-do-banco-de-dados)
- [Endpoints](#endpoints)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Contribuição](#contribuição)
- [Licença](#licença)

---

## Tecnologias

Este projeto utiliza as seguintes tecnologias:

- **ASP.NET Core** - Framework para criação de aplicações web
- **Entity Framework Core** - ORM para mapeamento de dados
- **PostgreSQL** - Banco de dados relacional
- **Swagger** - Documentação e testes de endpoints
- **AutoMapper** - Mapeamento de objetos para Data Transfer Objects (DTOs)

---

## Instalação

### Pré-requisitos
- [.NET SDK](https://dotnet.microsoft.com/download) (versão 6.0 ou superior)
- [PostgreSQL](https://www.postgresql.org/download/)

### Passo a Passo

1. Clone este repositório:
   ```bash
   git clone https://github.com/seu-usuario/WebApplicationApi.git
   cd WebApplicationApi

2. Configure a string de conexão do banco de dados no arquivo appsettings.json:
   
 {
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=SeuBancoDeDados;Username=SeuUsuario;Password=SuaSenha"
  }
} 

3. Instale as dependências:
    ```bash
    dotnet restore

4. Crie as migrações e atualize o banco de dados:
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update

5. Inicie o servidor:
      ```bash
      dotnet run

A API estará acessível em https://localhost:5001 ou http://localhost:5000.

---

## Configuração do Banco de Dados

Este projeto utiliza PostgreSQL. Verifique se o banco de dados está configurado corretamente e que a string de conexão em appsettings.json está configurada conforme necessário.

---

## Endpoints
#PedidoController

GET /api/pedido/ListarPedidos - Lista todos os pedidos com os produtos associados.
GET /api/pedido/BuscarPedidoPorId/{idPedido} - Busca um pedido específico pelo ID.
POST /api/pedido/CriarPedido - Cria um novo pedido. Necessário enviar ClienteId, DataPedido, StatusId, e uma lista de ProdutoIds.
PUT /api/pedido/EditarPedido - Edita um pedido existente.
DELETE /api/pedido/ExcluirPedido/{idPedido} - Exclui um pedido pelo ID.

#PEstrutura de Dados
CriarPedidoDto

{
  "clienteId": 1,
  "dataPedido": "2024-11-09T10:00:00Z",
  "statusId": 2,
  "produtoIds": [1, 2, 3]
}

#ResponseModel

A API utiliza um modelo de resposta padronizado, onde cada resposta é envolvida por um ResponseModel, que pode conter os dados e uma mensagem de status.

---

## Estrutura do Projeto

Controllers: Contém os controladores para os endpoints da API.
Models: Contém as classes que representam as entidades do banco de dados.
Dto: Contém os Data Transfer Objects (DTOs) para comunicação entre cliente e servidor.
Service: Contém a lógica de negócios para cada entidade.
Data: Contém o contexto do banco de dados (AppDbContext) e configurações de relacionamentos.
Migrations: Contém as migrações do Entity Framework Core para gerenciamento do banco de dados.

---

## Contribuição

1.Faça um fork do repositório.

2. Crie uma nova branch:
   ´´´bash
      git checkout -b feature/nova-funcionalidade
   
3. Commit as suas alterações:
   ´´´bash
      git commit -m "Adiciona nova funcionalidade"
   
4.Faça push para a branch:
   ´´´bash
      git push origin feature/nova-funcionalidade
      
5.Abra um Pull Request.

---

## Licença

Este projeto é licenciado sob a MIT License.

---

## Contato

Para dúvidas ou sugestões, sinta-se à vontade para entrar em contato.


