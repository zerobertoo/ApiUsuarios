# ApiUsuarios - API RESTful de Gerenciamento de Usuários

## 🎯 Status do Projeto

[![Status: Concluído](https://img.shields.io/badge/Status-Concluído-brightgreen.svg)](https://github.com/zerobertoo/ApiUsuarios)
[![Tecnologia: .NET 10](https://img.shields.io/badge/Tecnologia-.NET%2010-512BD4.svg)](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
[![Licença: MIT](https://img.shields.io/badge/Licença-MIT-blue.svg)](LICENSE.txt)

Este projeto foi desenvolvido como um **item de portfólio** para demonstrar proficiência na criação de APIs RESTful robustas e bem estruturadas utilizando o ecossistema .NET.

## 📝 Descrição

A **ApiUsuarios** é uma API RESTful simples e eficiente para realizar operações CRUD (Create, Read, Update, Delete) em registros de usuários. O foco principal deste projeto é a aplicação de **boas práticas de desenvolvimento de software**, como a separação de responsabilidades e a utilização de padrões de projeto, tornando o código mais limpo, testável e de fácil manutenção.

## 🛠️ Tecnologias Utilizadas

| Categoria | Tecnologia | Versão | Descrição |
| :--- | :--- | :--- | :--- |
| **Framework** | .NET 10 (ASP.NET Core) | 10.0 | Plataforma principal para construção da API. |
| **ORM** | Entity Framework Core | 8.0.6 | Mapeamento Objeto-Relacional. |
| **Banco de Dados** | SQLite | 8.0.6 | Banco de dados leve e embutido para desenvolvimento. |
| **Mapeamento** | AutoMapper | 12.0.1 | Simplifica o mapeamento entre Modelos e DTOs. |
| **Padrões** | Repository e Service Layer | - | Implementação de arquitetura limpa e desacoplada. |
| **Documentação** | Swagger/OpenAPI | 6.6.2 | Documentação interativa dos endpoints da API. |

## 🏗️ Arquitetura e Padrões de Projeto

O projeto foi refatorado para seguir uma arquitetura em camadas, promovendo a **Separação de Responsabilidades (SoC)** e o **Princípio da Responsabilidade Única (SRP)**.

1.  **Controller (Apresentação):** Responsável por receber as requisições HTTP, validar o `ModelState` e retornar as respostas. Delega toda a lógica de negócio para a camada de Serviço.
2.  **Service Layer (Regras de Negócio):** Contém a lógica de negócio da aplicação (ex: validação de e-mail duplicado, regras de ativação/inativação). Utiliza o Repositório para interagir com os dados.
3.  **Repository Pattern (Acesso a Dados):** Abstrai a lógica de acesso ao banco de dados (Entity Framework Core). O Serviço interage com o Repositório através de uma interface (`IUsuarioRepository`), garantindo o desacoplamento.
4.  **DTOs (Data Transfer Objects):** Utilizados para transferir dados entre as camadas e a interface externa (API), garantindo que apenas os dados necessários sejam expostos ou recebidos.

## 🚀 Funcionalidades (Endpoints)

A API expõe os seguintes endpoints para o gerenciamento de usuários:

| Método | Endpoint | Descrição | DTO de Entrada | DTO de Saída |
| :--- | :--- | :--- | :--- | :--- |
| `GET` | `/api/usuarios` | Retorna a lista completa de todos os usuários. | - | `UsuarioDTO[]` |
| `GET` | `/api/usuarios/ativos` | Retorna a lista apenas de usuários ativos. | - | `UsuarioDTO[]` |
| `GET` | `/api/usuarios/{id}` | Retorna um usuário específico pelo ID. | - | `UsuarioDTO` |
| `POST` | `/api/usuarios` | Cria um novo usuário. | `CreateUsuarioDTO` | `UsuarioDTO` |
| `PUT` | `/api/usuarios/{id}` | Atualiza um usuário existente. | `UpdateUsuarioDTO` | `UsuarioDTO` |
| `DELETE` | `/api/usuarios/{id}` | Remove um usuário pelo ID. | - | `200 OK` |

## ⚙️ Como Executar o Projeto

### Pré-requisitos

*   [.NET 10 ](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
*   Um editor de código (Visual Studio Code, Visual Studio, Rider)

### Passos

1.  **Clone o repositório:**
    ```bash
    git clone https://github.com/zerobertoo/ApiUsuarios.git
    cd ApiUsuarios/ApiUsuariosCrud
    ```

2.  **Restaure as dependências:**
    ```bash
    dotnet restore
    ```

3.  **Execute as Migrações (Criação do Banco de Dados):**
    O banco de dados SQLite (`usuarios.db`) será criado na primeira execução. Para garantir que o esquema esteja atualizado:
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

4.  **Execute a Aplicação:**
    ```bash
    dotnet run
    ```

A API estará disponível em `http://localhost:5000` (ou porta configurada no `launchSettings.json`). A documentação interativa do Swagger estará acessível em `http://localhost:5000/swagger`.

## 🌟 Melhorias e Otimizações Aplicadas

As seguintes melhorias foram implementadas para transformar o projeto em um ativo de portfólio de alta qualidade:

*   **Atualização de Framework:** Migração do projeto para o **.NET 10**, a versão LTS mais recente, garantindo performance e suporte.
*   **Implementação de DTOs:** Separação dos modelos de domínio (`Usuario`) dos modelos de transferência de dados (`CreateUsuarioDTO`, `UpdateUsuarioDTO`, `UsuarioDTO`), melhorando a segurança e o controle de dados.
*   **Uso de AutoMapper:** Configuração do AutoMapper para automatizar o mapeamento entre DTOs e Modelos, reduzindo código *boilerplate* e erros manuais.
*   **Padrão de Repositório e Serviço:** Introdução das camadas de Serviço e Repositório, isolando a lógica de negócio e o acesso a dados, o que facilita a manutenção e a escrita de testes unitários.
*   **Injeção de Dependência (DI):** Uso consistente de DI para todas as novas camadas (`IUsuarioService`, `IUsuarioRepository`), promovendo o baixo acoplamento.
*   **Tratamento de Erros:** Melhoria no retorno de erros (ex: "Email já cadastrado", "Usuário não encontrado") com mensagens claras e códigos de status HTTP apropriados.

---

Feito com ❤️ por **zerobertoo**
