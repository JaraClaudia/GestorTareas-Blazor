# Changelog

Todos los cambios importantes de este proyecto se documentan en este archivo.

El formato sigue [Keep a Changelog](https://keepachangelog.com/es-ES/1.1.0/) y el proyecto usa [Versionado Semántico](https://semver.org/lang/es/).

## [Sin publicar]

### Agregado
- Pendiente: filtro de tareas por prioridad.
- Pendiente: modo oscuro con persistencia en localStorage.
- Pendiente: workflow de CI/CD con GitHub Actions y despliegue en Azure.

## [0.2.0] - 2026-11-13

### Agregado
- `README.md` con descripción, stack, arquitectura (diagrama Mermaid), instalación y captura de pantalla.
- Historias de usuario del proyecto en `docs/historias-de-usuario.md`.
- Comentarios de documentación XML en todos los métodos de `ITareaService`.
- Flujo de trabajo con Git Flow (`main`, `develop`, `feature/*`), Pull Requests y Conventional Commits.

### Cambiado
- Las historias de usuario pasaron de un `.txt` en la raíz a `docs/` en formato Markdown.

## [0.1.0] - 2026-11-07

### Agregado
- Aplicación Blazor Web App (.NET 8) con interactividad Server.
- Componentes reutilizables: `TareaItem`, `AlertError`, `Paginacion`, `FormularioTarea`, `Cargando` y `BadgePrioridad`.
- Páginas de listado, detalle y edición de tareas con routing por parámetros.
- Formularios con `EditForm` y validación: Data Annotations, `IValidatableObject` y el atributo propio `FechaFutura`.
- Interfaz con HTML5 semántico, Bootstrap 5 y CSS Isolation.
- JS Interop para confirmar la eliminación de una tarea.
- Persistencia con Entity Framework Core 8 y SQL Server (LocalDB): entidades `TareaEntity` y `Categoria` con relación uno-a-muchos.
- Migración inicial y datos de ejemplo (5 categorías y 10 tareas), aplicados al iniciar la aplicación.
- Servicio de datos `TareaService` con `IDbContextFactory`, paginación, búsqueda por título y estadísticas.
- Manejo de errores de base de datos con registro en el log y mensajes visibles en la interfaz.

[Sin publicar]: https://github.com/JaraClaudia/GestorTareas-Blazor/compare/v0.2.0...develop
[0.2.0]: https://github.com/JaraClaudia/GestorTareas-Blazor/compare/v0.1.0...v0.2.0
[0.1.0]: https://github.com/JaraClaudia/GestorTareas-Blazor/releases/tag/v0.1.0
