# PDF Generator Service

Uma API .NET 8 para geração de PDFs a partir de templates HTML em Handlebars, usando Playwright (Chromium headless). A aplicação é desacoplada em camadas com Clean Architecture e utiliza MediatR para orquestração via Commands/Handlers.

---

## 📦 Tecnologias utilizadas

- **.NET 8.0**
- **MediatR** (impl. de Command/Handler Pattern)
- **Handlebars.Net** (renderização de templates HTML)
- **Microsoft.Playwright** (geração de PDF com Chromium headless)
- **Clean Architecture** (camadas: WebApi, Application, Infrastructure)
- **Injeção de Dependência** nativa do ASP.NET Core
- **CORS pronto para cliente externo**
- **Swagger / Swashbuckle** para documentação interativa

---

## 🧩 Estrutura do projeto

