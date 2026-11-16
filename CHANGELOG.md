# Changelog

Todos los cambios importantes de este proyecto se documentan en este archivo.

El formato sigue [Keep a Changelog](https://keepachangelog.com/es-ES/1.1.0/) y el proyecto usa [Versionado Semántico](https://semver.org/lang/es/).

## [Sin publicar]

### Agregado
- Pendiente: filtro de tareas por prioridad.
- Pendiente: modo oscuro con persistencia en localStorage.

## [0.4.0] - 2026-11-15

### Agregado
- Workflow `deploy.yml` de GitHub Actions: despliegue automático al hosting con Web Deploy cada vez que llega código a `main`, con ejecución manual opcional.
- Credenciales de despliegue guardadas como secretos de GitHub, fuera del repositorio.

### Corregido
- El despliegue agrega el puerto 8172 de Web Deploy cuando el servidor del perfil de publicación no lo trae.

### Cambiado
- README: la sección de despliegue describe el flujo automático.

## [0.3.0] - 2026-11-15

### Agregado
- Despliegue de la aplicación en MonsterASP.NET con base de datos SQL Server, accesible por HTTPS.
- Workflow de integración continua con GitHub Actions: restore, build y publish en cada push y Pull Request.
- Configuración por ambiente: `appsettings.Production.json` y User Secrets para desarrollo.
- Endpoint de salud `/health` con un chequeo propio de la conexión a la base de datos.
- Registro de operaciones de escritura con `ILogger` (información, advertencias y errores).
- Componente `EstadisticasEncabezado` que se actualiza solo mediante el State Service y su evento `OnChange`.
- Enlace "Tareas" en el menú y página de inicio propia.

### Cambiado
- `TareaStateService` pasó de guardar una lista de tareas en memoria a compartir las estadísticas entre componentes.
- Los layouts usan HTML5 semántico (`header`, `aside`, `nav`, `main`, `article`, `footer`).
- El menú quedó solo con las secciones de la aplicación.

### Corregido
- La estadística de prioridad alta ahora cuenta solo las tareas pendientes, y baja al completar una.

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

[Sin publicar]: https://github.com/JaraClaudia/GestorTareas-Blazor/compare/v0.4.0...develop
[0.4.0]: https://github.com/JaraClaudia/GestorTareas-Blazor/compare/v0.3.0...v0.4.0
[0.3.0]: https://github.com/JaraClaudia/GestorTareas-Blazor/compare/v0.2.0...v0.3.0
[0.2.0]: https://github.com/JaraClaudia/GestorTareas-Blazor/compare/v0.1.0...v0.2.0
[0.1.0]: https://github.com/JaraClaudia/GestorTareas-Blazor/releases/tag/v0.1.0
