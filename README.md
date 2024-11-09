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
