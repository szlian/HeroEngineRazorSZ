# La Forja de les Eines — Anàlisi d'IDEs

## Introducción

Aunque no he trabajado directamente con todos estos entornos de desarrollo en profundidad, he mirado su funcionamiento 

El objetivo es analizar cuál es más adecuado para un proyecto como HeroEngine, que incluye clases, herencia, combate por turnos y una estructura bastante grande en C#.

---

## Visual Studio Community 2022

### Edición de código
Permite moverse rápido entre clases como ACombatant, AHeroes o CRogue gracias a IntelliSense.

Las funciones de refactorización como renombrar métodos, mover clases , navegar entre funciones apretando el Control (Aunque no es intelliSense puro) y poder renombrar el nombre de un variable a todos los variables, funcionan bastante bien y ayudan cuando el proyecto empieza a crecer.

### Generación de ejecutables
Permite compilar fácilmente en modo Debug o Release. También gestiona NuGet de forma automática, lo cual es útil cuando se añaden librerías.

### Git
Tiene integración con Git bastante completa. Se puede hacer commit, ver cambios y resolver conflictos sin salir del IDE.

### Rendimiento
Es un entorno bastante pesado, pero funciona bien en proyectos grandes como este.

### Licencia
Es gratuito con la versión Community, lo que lo hace muy accesible para estudiantes y desarrolladores independientes.

---

## JetBrains Rider

### Edición de código
Rider tiene un análisis de código muy avanzado. Detecta errores y problemas de diseño incluso antes de compilar.

En este proyecto, puede ayudar a detectar errores en herencia o estructuras mal diseñadas.

### Depurador
Es rápido y bastante intuitivo. Permite ver el estado del programa de forma clara y sencilla.

### Git
Tiene una integración con Git muy visual y fácil de usar.

### Rendimiento
Es más ligero que Visual Studio en proyectos grandes.

### Licencia
Es gratuito para estudiantes con licencia educativa.

---

## Visual Studio Code + C# Dev Kit

### Edición de código
Es un editor más simple. Tiene autocompletado básico y sirve bien para editar archivos rápidamente.

No es tan potente como Visual Studio o Rider en proyectos grandes.

### Depurador
Funciona, pero es más básico y con menos herramientas visuales.

### Git
Muy buena integración gracias a sus múltiples tipos de extensiones disponibles para descargar.

### Rendimiento
Es el más ligero de los tres y arranca muy rápido.

### Licencia
Totalmente gratuito y multiplataforma.

---

## Comparación

| Característica | Visual Studio | Rider | VS Code |
|------|------|------|------|
| Autocomplete | Muy bueno | Excelente | Bueno |
| Depurador | Excelente | Muy bueno | Básico |
| Refactorización | Muy buena | Excelente | Limitada |
| Git | Muy bueno | Excelente | Muy bueno |
| Rendimiento | Pesado | Medio | Muy ligero |
| Facilidad de uso | Alta | Media | Media |

---

## Conclusión (subjetiva)

Para el proyecto HeroEngine, el IDE que he utilizado principalmente es Visual Studio Community 2022.

Lo elijo porque es muy completo para proyectos en C#. Me ha ayudado bastante en el sistema de combate por turnos, en la estructura de clases y en el desarrollo general del proyecto. Además, es el que más domino y con el que me siento más cómodo trabajando.

Por lo que he investigado, JetBrains Rider es probablemente el más potente de los tres en cuanto a rendimiento y análisis de código. Es más rápido y detecta mejor los errores, pero tiene la desventaja de que no es el IDE que he usado durante el desarrollo, y además su ecosistema es menos familiar para mí.

Visual Studio Code podría ser una opción interesante para proyectos pequeños o para edición rápida de código, pero en este caso se queda corto para un proyecto grande como HeroEngine. Tampoco lo he utilizado mucho, pero por lo que he usado anteriormente, puedo decir que no está mal, aunque es mucho mejor el Visual Studio

En conclusión, Visual Studio es el más adecuado para este proyecto porque tiene todo lo necesario para desarrollar un motor de juego en C# y es el entorno con el que he trabajado durante todo el desarrollo, luego de ser el que más hemos utilizado en clase y más tiempo hemos dedicado 


