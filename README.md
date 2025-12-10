# API de Gerenciamento de Usuários | .NET 10 + EF Core + SQLite

API REST construída com .NET 10, Entity Framework Core e SQLite, com foco em boas práticas, organização, documentação e arquitetura simples. Este projeto faz parte do meu portfólio e demonstra habilidades reais com back-end, integrações e construção de APIs RESTful.

## 🚀 Tecnologias Utilizadas

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- LINQ
- Migrations (EF)

## 📌 Funcionalidades Implementadas

- ✔️ Criar usuários (POST)
- ✔️ Listar todos os usuários (GET)
- ✔️ Buscar usuário por ID (GET /{id})
- ✔️ Listar apenas usuários ativos (GET /ativos)
- ✔️ Atualizar usuário (PUT)
- ✔️ Remover usuário (DELETE)
- ✔️ Validação simples (nome/email obrigatórios)
- ✔️ Seed inicial com dados fixos
- ✔️ Documentação completa via Swagger

## 📁 Estrutura do Projeto

```
ApiUsuarios/
├── Controllers/
│   └── UsuariosController.cs
├── Data/
│   └── AppDbContext.cs
├── Models/
│   └── Usuario.cs
├── usuarios.db (ignorado pelo git)
├── Program.cs
└── README.md
```

## 🧪 Como Executar o Projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/SEU-USUARIO/api-usuarios-dotnet.git
cd api-usuarios-dotnet
```

### 2. Restaurar dependências

```bash
dotnet restore
```

### 3. Criar o banco via migrations

```bash
dotnet ef database update
```

### 4. Rodar o servidor

```bash
dotnet run
```

### 5. Acessar a documentação (Swagger)

Abra no navegador: `https://localhost:7XXX/swagger`

## 🔗 Endpoints Principais

| Verbo  | Endpoint               | Descrição    |
| ------ | ---------------------- | ------------ |
| GET    | `/api/usuarios`        | Lista todos  |
| GET    | `/api/usuarios/{id}`   | Busca por ID |
| GET    | `/api/usuarios/ativos` | Lista ativos |
| POST   | `/api/usuarios`        | Cria usuário |
| PUT    | `/api/usuarios/{id}`   | Atualiza     |
| DELETE | `/api/usuarios/{id}`   | Remove       |

## 🧠 Boas Práticas Utilizadas

- Seed com valores estáticos (evita erros em migrations)
- Tratamento de erros claro (BadRequest, NotFound)
- Controller enxuto e objetivo
- Código limpo e nomeado de forma clara
- Padrão REST
- Separação entre Model, Data e Controller

## 📜 Licença

Este projeto está licenciado sob a Licença MIT. Você pode usar, estudar, modificar e distribuir como quiser.

## 👤 Contato

- **LinkedIn:** https://linkedin.com/in/joserobertoo
- **Email:** euzerobertoo@gmail.com
