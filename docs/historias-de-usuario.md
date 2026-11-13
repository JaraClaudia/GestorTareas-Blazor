# Historias de usuario – Gestor de Tareas

## HU-01 Filtrar tareas por prioridad (estimación: 3)
**Como** usuario del Gestor de Tareas
**quiero** filtrar la lista por prioridad
**para** enfocarme primero en lo más urgente.

Criterios de aceptación:
- Hay un selector: Todas / Alta / Media / Baja
- La lista se actualiza sin recargar la página
- El filtro se combina con la búsqueda y la paginación

## HU-02 Modo oscuro (estimación: 5)
**Como** usuario
**quiero** activar un modo oscuro
**para** usar la app cómodamente de noche.

Criterios de aceptación:
- Hay un botón visible para alternar el modo
- La elección se guarda en localStorage (JS Interop)
- Al recargar, se mantiene el modo elegido

## HU-03 Documentación profesional (estimación: 2)
**Como** docente evaluador
**quiero** un README claro
**para** instalar y entender el proyecto rápido.

Criterios de aceptación:
- Descripción, stack, instalación y capturas
- Diagrama de arquitectura

## HU-04 Estadísticas visibles (estimación: 3)
**Como** usuario
**quiero** ver total, completadas y pendientes
**para** saber cómo voy con mis tareas.

Criterios de aceptación:
- Se muestran en el layout o en la lista
- Salen de una consulta real a la base

## HU-05 Notificar tareas por vencer (estimación: 8)
**Como** usuario
**quiero** una notificación cuando una tarea vence en menos de 24 hs
**para** no olvidarme.

Criterios de aceptación:
- Usa JS Interop con la API de Notification
- Se pide permiso al usuario

## Definition of Done (común)
- Implementada y probada manualmente
- Código en rama feature/ con Pull Request mergeado
- Sin errores en la consola del navegador
- README actualizado si aplica