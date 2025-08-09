# ​ Ecommerce Microservices

Arquitetura baseada em microserviços para um e-commerce, com backend em .NET e frontend em Angular, orquestrados via Docker Compose.

##  Tecnologias Utilizadas

- Backend: .NET (C#)
- Frontend: Angular
- Containerização: Docker + Docker Compose
- Desenvolvimento: VS Code Dev Container (`.devcontainer/`)
- Banco de dados: *(a ser definido)*

##  Estrutura do Repositório

- `.devcontainer/` – Configuração para ambiente de desenvolvimento no VS Code
- `backend/` – Backend em .NET (Visual Studio)
- `product-frontend/` – Aplicação frontend em Angular
- `docker-compose.yml` – Composição dos serviços
- `ecommerce-microservices.sln` – Solução .NET

##  Progresso Atual (Roadmap)

- [x] Criação da solução inicial backend (.NET)
- [x] Estrutura inicial do frontend (Angular)
- [ ] Integração backend ↔ frontend
- [ ] Implementação de banco de dados
- [ ] Autenticação e autorização
- [ ] Microserviços adicionais (ex: carrinho, pedidos)
