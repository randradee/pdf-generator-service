# PDF Generator Service

Uma API .NET 8 para geração de PDFs a partir de templates HTML em Handlebars, usando Playwright (Chromium headless). A aplicação é desacoplada em camadas com Clean Architecture e utiliza MediatR para orquestração via Commands/Handlers.

---

## Tecnologias utilizadas

- **.NET 8.0**
- **MediatR** (impl. de Command/Handler Pattern)
- **Handlebars\.Net** (renderização de templates HTML)
- **Microsoft.Playwright** (geração de PDF com Chromium headless)
- **Clean Architecture** (camadas: WebApi, Application, Infrastructure)
- **Injeção de Dependência** nativa do ASP\.NET Core
- **CORS pronto para cliente externo**
- **Swagger / Swashbuckle** para documentação interativa

---

## Estrutura do projeto

```
├── PdfGeneratorService.WebApi/         # API, controllers, DI, configs
├── PdfGeneratorService.Application/    # comandos, handlers, interfaces
├── PdfGeneratorService.Infrastructure/ # implementações técnicas
├── PdfGeneratorService.Domain/         # entidades de domínio, regras de negócio, value objects
├── PdfGeneratorService.Tests/          # testes (em breve)
└── README.md
```

---

## Como rodar o projeto

1. **Pré-requisitos**:
    - .NET 8 SDK
    - Node.js (para Playwright)
    - Chromium instalado via Playwright:  
    ```
    playwright install
    ```

    Obs.: Se o comando `playwright` não for reconhecido, instale o pacote globalmente com:

    ```bash
    dotnet tool install --global Microsoft.Playwright.CLI
    ```

2. **Restaurar dependências**:
    ```bash
    dotnet restore
    ```

3. **Rodar a aplicação**:
    ```bash
    dotnet run --project PdfGeneratorService.WebApi
    ```

4. **Acessar documentação Swagger**:  
    [https://localhost:5001/swagger/index.html](https://localhost:5001/swagger/index.html)

---

## Endpoints principais

- `POST /api/pdf/generate`  
  Gera um PDF a partir de um template HTML e dados.

  **Body (JSON):**
  ```json
  {
     "template": "<html>...</html>",
     "data": { "nome": "Teste" }
  }
  ```

  **Resposta:**  
  PDF gerado (application/pdf)

---

##  Fluxo interno (Arquitetura)

1. **Controller** recebe requisição.
2. **Command** é criado e enviado via MediatR.
3. **Handler** processa o comando:
    - Renderiza HTML com Handlebars\.Net.
    - Gera PDF usando Playwright.
4. **Infraestrutura** lida com detalhes técnicos (PDF, templates).
5. **Resposta** retorna o PDF ao cliente.

---

##  Teste rápido com cURL

```bash
curl -X POST http://localhost:5000/api/pdf/generate \
  -H "Content-Type: application/json" \
  -d '{"template":"<html><body>{{nome}}</body></html>","data":{"nome":"Teste"}}' \
  --output resultado.pdf
```

---

## Boas práticas seguidas

- Clean Architecture (separação de responsabilidades)
- Injeção de dependência
- Documentação via Swagger
- CORS habilitado
- Código limpo e comentado

---

## Melhorias futuras

- [ ] Autenticação/JWT (endpoint)
- [ ] Suporte a múltiplos formatos (PNG, JPG)
- [ ] Templates armazenados externamente
- [ ] Logs estruturados
- [ ] Deploy automatizado (CI/CD)

---

##  Licença

Distribuído sob a licença MIT.