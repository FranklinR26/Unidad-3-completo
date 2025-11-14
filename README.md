📌 Descripción del Hito

En esta práctica implementamos una IA de Enemigo utilizando una Máquina de Estados Finita (FSM).
La IA puede:

Patrullar entre varios puntos (Waypoints) usando un NavMeshAgent

Detectar al jugador cuando entra en el radio de visión

Cambiar al estado de persecución

Volver automáticamente a patrullar cuando pierde al jugador

Configurar parámetros clave desde el Inspector usando [SerializeField]

También creamos el prefab del enemigo, configuramos su navegación sobre el NavMesh y probamos la transición correcta entre los estados.

📌 Reflexión del Estudio 
1. Sinergia y Fricción

Mayor beneficio:
La ventaja más grande fue la sinergia al dividir roles.
Mientras uno configuraba la escena y los waypoints, otro afinaba la lógica del script y otro probaba las transiciones. Esto permitió avanzar más rápido y detectar errores antes de integrarlos.

Mayor desafío:
El principal reto fue la coordinación al momento de unir los cambios, especialmente en la organización de los Waypoints y ajustes del NavMesh.
Lo resolvimos asignando áreas de responsabilidad claras y revisando el proyecto juntos antes de hacer pruebas finales.
Además, mantener comunicación constante ayudó a evitar duplicación de tareas.
