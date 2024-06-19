# DomraSinForms

## System Design

```mermaid
---
title: Projects dependencies diagram
---
flowchart TB
client["DomraSinForms.Client"]
app["DomraSinForms.Application"]
db["DomraSinForms.Persistence"]
domain["DomraSinForms.Domain"]
server["DomraSinForms.Server"]


server --> app
server --> db
client --> app
app --> domain
app --> db
db --> domain

db -.-> postgres["PostgresSQL"]
db -.-> mssql["SqlServer"]
db -.-> sqlite["☠️ SqLite ☠️"]
```

`DomraSinForms.Domain` is base project that contains only models and abstractions.

`DomraSinForms.Client` - Blazor Server application that use `DomraSinForms.Application` as its own logic provider (except UI logic). It also provides Repositories realization by adding `DomraSinForms.Persistance` to DI container.
