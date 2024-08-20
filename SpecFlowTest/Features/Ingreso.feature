Feature: Ingreso

# Este escenario es referencia a ejecutar un caso de prueba

@tag1
Scenario: Ingreso de cliente
    Given Llenar los campos de la BDD
    | Cedula    | Apellidos | Nombres | FechaNacimiento | Telefono     | Mail                | Saldo | Estado |
    |1726453617 | Perez     | Juan    | 1990/01/01      | 0987654321   | lasalle@hotmail.com | 100   | 1      |
    When El registro se ingresa en la BDD
    | Cedula    | Apellidos | Nombres | FechaNacimiento | Telefono     | Mail                | Saldo | Estado |
    |1726453617 | Perez     | Juan    | 1990/01/01      | 0987654321   | lasalle@hotmail.com | 100   | 1      |
    Then El resultado se ingresa en la BDD
    | Cedula    | Apellidos | Nombres | FechaNacimiento | Telefono     | Mail                | Saldo | Estado |
    |1726453617 | Perez     | Juan    | 1990/01/01      | 0987654321   | lasalle@hotmail.com | 100   | 1      |

# Otro caso de prueba

# @tag2
# Scenario: Registro de usuarios
#     Given Llenar los campos de la BDD
#     | Cedula    | Apellidos | Nombres | FechaNacimiento | Telefono     | Mail                | Saldo | Estado |
#     |1726453617 | Perez     | Juan    | 1990/01/01      | 0987654321   |
#     When El registro se ingresa en la BDD
#     | Cedula    | Apellidos | Nombres | FechaNacimiento | Telefono     | Mail                | Saldo | Estado |
#     |1726453617 | Perez     | Juan    | 1990/01/01      | 0987654321   |
#     Then El resultado se ingresa en la BDD
#     | Cedula    | Apellidos | Nombres | FechaNacimiento | Telefono     | Mail                | Saldo | Estado |
#     |1726453617 | Perez     | Juan    | 1990/01/01      | 0987654321   |