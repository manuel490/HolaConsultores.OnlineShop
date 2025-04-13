# HolaConsultores Online Shop

## Estructura del Proyecto

El proyecto está organizado en una arquitectura de capas siguiendo los principios SOLID, inyección de dependencias, clean Architecture etc... :

### Capas del Proyecto

1. **HolaConsultores.OnlineShop.API**
   - Contiene los controllers que manejan las peticiones HTTP, la configuracion de swagger y el manejo de tokens para la autenticación.
   - Controllers:
     - AuthenticationController
     - ProductController
     - ColorController
     - SizeController
     - ProductColorController
     - ProductSizeController
     - UserController

2. **HolaConsultores.OnlineShop.Domain**
   - Contiene la lógica de negocio y las interfaces y los Resources / DTO's de las entidades correspondientes.

3. **HolaConsultores.OnlineShop.Infrastructure**
   - Define las entidades, el contexto con la BBDD, el historico de migraciones y la implementacion de los repositorios.
   Entidades:
     - ProductModel
     - ColorModel
     - SizeModel
     - ProductColorModel
     - ProductSizeModel
     - UserModel

4. **HolaConsultores.OnlineShop.Mappers**
   - Contiene funciones estaticas para los mapeos entre entidades y resources / DTOs.

5. **HolaConsultores.OnlineShop.Services**
   - Implementa la lógica de negocio
   - Actúa como intermediario entre los controllers y los repositories

6. **HolaConsultores.OnlineShop.Test**
   - Contiene las pruebas unitarias y de integración

## Flujo de una Petición

1. El cliente hace una petición HTTP a un endpoint
2. El **Controller** correspondiente recibe la petición
3. El controller llama al **Service** correspondiente
4. El service implementa la lógica de negocio y utiliza el **Repository** para acceder a la base de datos.
5. El repository ejecuta las operaciones de base de datos
6. Los datos retornan por la misma cadena hasta el cliente

## Relaciones entre Modelos

- **Product**: Entidad principal que representa un producto
  - Se relaciona con Color a través de ProductColor
  - Se relaciona con Size a través de ProductSize

- **Color**: Representa los colores disponibles para los productos
  - Relación muchos a muchos con Product a través de ProductColor

- **Size**: Representa las tallas disponibles para los productos
  - Relación muchos a muchos con Product a través de ProductSize

- **ProductColor**: Tabla de unión entre Product y Color

- **ProductSize**: Tabla de unión entre Product y Size

Prueba técnica para HolaConsultores

## Notas:
- La BBDD utilizada se encuentra en los settings del proyecto .API.
- Los endpoints de la API requieren autenticación. para ello se requiere hacer una llamada post al endpoint api/Authentication/Validate e insertar unas credenciales, si son validas devolverá un token.
- Habrá que autenticarse desde el botón Authorize insertando: "Bearer token". (Sustituyendo token por el token devuelto en el punto anterior).
- La autenticación valida contra usuarios registrados en BBDD pero para poder hacer pruebas rápidamente añadí unas credenciales de "admin" en los settings del proyecto API. (Account: admin@admin.com Password: Admin_123).
