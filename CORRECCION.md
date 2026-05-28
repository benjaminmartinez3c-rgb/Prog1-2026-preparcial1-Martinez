# Corrección — Martinez

> **Aviso importante:** Las soluciones se evalúan exclusivamente con los conceptos vistos en clase. Si se utilizan conceptos que no fueron parte del programa (frameworks externos, técnicas avanzadas no vistas, etc.), esas partes no serán tenidas en cuenta en la corrección.


## Nota general
**No aprobado** — Puntaje: 51/100

| Área | Obtenido | Máximo |
|---|---|---|
| Jerarquía de herencia | 14 | 25 |
| Sobrecarga de métodos | 0 | 25 |
| Lógica de costos | 18 | 20 |
| Validaciones y excepciones | 12 | 15 |
| Tests unitarios | 3 | 10 |
| Estructura de proyecto | 4 | 5 |
| **Total** | **51** | **100** |

## Correcciones de evaluación

### Jerarquía de herencia (14/25)

- `Vehiculo` es correctamente `abstract` y define un método abstracto. Sin embargo, el método se llama `CalcularCosto(int dias)` en lugar del nombre requerido `CalcularCostoAlquiler(int dias)`. Se descuenta parcialmente. (-3 pts)
- `Auto`, `Moto` y `Bici` heredan de `Vehiculo` e implementan `override` correctamente. Se otorgan los 5 pts por cada una (15 pts en total), pero parte del puntaje de la clase base se pierde por el nombre incorrecto del método abstracto.
- Propiedades de `Vehiculo` presentes y correctas (Patente readonly, Marca, Modelo, AnioFabricacion, PrecioBaseDiario).
- `Moto` tiene la propiedad `Categoria` (tipo `CategoriaMoto`) en lugar de `Tipo` (tipo `TipoMoto`). El enum también tiene nombre diferente al requerido. Funcionalidad equivalente pero nombres incorrectos. (-1 pt)
- `Bici` tiene la propiedad `CantCambios` en lugar de `CantidadMarchas`. Nombre incorrecto. (-1 pt)
- `Reserva`: la propiedad `Id` se llama `Numero`, `NombreCliente` se llama `Cliente`, `CantidadDias` se llama `Dias`. El contador auto-incremental estático existe y funciona correctamente. (-2 pts por nombres)
- No existe la clase `AlquilerService` con listas privadas de `Vehiculo` y `Reserva`. Hay una clase `Busqueda` que solo gestiona vehiculos, sin lista de reservas. (-4 pts)

### Sobrecarga de métodos (0/25)

- `Auto` NO implementa dos sobrecargas del método `CalcularCostoAlquiler`. Solo existe `CalcularCosto(int dias)` con una única firma. El seguro se maneja mediante una propiedad booleana `Seguro` en lugar de un parámetro `bool conSeguro` en una segunda sobrecarga. No se cumple la sobrecarga `CalcularCostoAlquiler(int dias, bool conSeguro)`. (0/12)
- No existe la clase `AlquilerService`, por lo tanto no existen las sobrecargas `BuscarVehiculo(string patente)` y `BuscarVehiculo(TipoVehiculo tipo)`. La clase `Busqueda` tiene métodos de nombre diferente (`BuscarPorPatente` y `BuscarPorTipo<T>`) y utiliza genéricos en lugar del enum `TipoVehiculo`. No se cumple el patrón de sobrecarga requerido. (0/13)

### Lógica de costos (18/20)

- Auto ≤ 7 días: `PrecioBaseDiario * dias` — correcto. (4/4)
- Auto > 7 días: `PrecioBaseDiario * dias * 0.85` — correcto. (4/4)
- Auto con seguro: la multiplicación por 1.10 está implementada pero a través de la propiedad `Seguro`, no como parámetro de sobrecarga. La lógica del cálculo es correcta aunque la interfaz difiere. Se otorgan 2 de 4 pts por lógica presente pero acceso incorrecto. (2/4)
- Moto Urbana y Todoterreno: factor 0.60 — correcto. (4/4)
- Moto Deportiva: factor 0.80 — correcto. (2/2)
- Bicicleta: `200m * dias` — correcto. (2/2)

### Validaciones y excepciones (12/15)

- `AnioFabricacion < 1900` o `> DateTime.Now.Year` lanza `ArgumentException` — correcto. (4/4)
- Patente nula o vacía (usa `IsNullOrWhiteSpace`) lanza `ArgumentException` — correcto. (4/4)
- `CantidadDias <= 0` lanza `ArgumentException` en el constructor de `Reserva` — correcto. (4/4)
- `BuscarPorPatente` y `BuscarPorTipo<T>` sin resultados lanzan `Exception` genérica en lugar de `InvalidOperationException`. (0/3)

### Tests unitarios (3/10)

- No existe test de `Auto.CalcularCostoAlquiler(10 días, base=1000)` que verifique resultado = 8500. (0/4)
- No existe test de `Auto.CalcularCostoAlquiler(10 días, true, base=1000)` que verifique resultado = 9350. (0/3)
- Existe test en `VehiculoTests` que verifica que el constructor con año 1800 lanza `ArgumentException` — correcto. (3/3)
- El test `Moto_Deportiva_Factor` en `MotoTests` tiene un valor esperado incorrecto: con base=100 y 2 días, `100 * 2 * 0.8 = 16`, pero el test afirma que el resultado es 1600. El test es incorrecto y fallaría al ejecutarse.

### Estructura de proyecto (4/5)

- Existe archivo de solución `MovilYa.slnx` (formato .slnx, equivalente moderno de .sln). Se acepta como válido. (2/2)
- El proyecto de lógica se llama `Negocio` en lugar de `MovilYaService`. No es una class library con el nombre requerido. (1/2)
- Proyecto `Tests` usa NUnit con referencias correctas al proyecto de negocio. (1/1)

## Observaciones importantes

- El problema central que impide la aprobación es la ausencia total de sobrecarga de métodos (0/25): ni `Auto` implementa las dos sobrecargas de `CalcularCostoAlquiler`, ni existe `AlquilerService` con las dos sobrecargas de `BuscarVehiculo`. Este es el criterio con mayor peso relativo del examen.
- El nombre del método abstracto (`CalcularCosto` en lugar de `CalcularCostoAlquiler`) es inconsistente con la consigna y afecta la evaluación en herencia, sobrecarga y tests.
- La clase `AlquilerService` requerida no existe. La clase `Busqueda` es un reemplazo parcial que no cumple el contrato pedido (falta lista de reservas, nombres de métodos distintos, sin enum `TipoVehiculo`, sin sobrecargas).
- El test `MotoTests.Moto_Deportiva_Factor` tiene un valor esperado erróneo (1600 en lugar de 16); el test fallaría al correrlo.
- La lógica de negocio (cálculo de costos) está bien implementada en general; el alumno entiende las reglas del dominio.
- Las validaciones de constructores son correctas y completas, salvo el tipo de excepción en las búsquedas.
- Recomendación: revisar el concepto de sobrecarga de métodos (mismo nombre, distintas firmas) y el uso de `InvalidOperationException` para casos sin resultados.
