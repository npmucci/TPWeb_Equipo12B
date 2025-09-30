# 🎟️ TP WebForms - Promoción con Vouchers

## 📌 Descripción del Proyecto
Este proyecto corresponde a la **Actividad N° 4 WebForms (ASP.NET)** de la carrera **Tecnicatura En Programación** de la **UTN - Facultad de Gral. Pacheco**.  
Consiste en una aplicación web para la **gestión de una promoción comercial**, donde los clientes ingresan un **código de voucher** obtenido en una compra para participar en un sorteo de premios.  

El flujo principal es:
1. El cliente ingresa el **código de voucher** en la web.
2. El sistema valida el código contra la base de datos.
   - ✅ Si es válido → continúa con la selección de un premio.
   - ❌ Si es inválido o ya usado → muestra un mensaje de error.
3. El cliente selecciona el **premio** por el que quiere participar.
4. El cliente completa (o confirma) sus **datos personales**.
   - Si el cliente ya existe en la base de datos → se **precargan los datos**.
   - Si no existe → debe registrarse.
5. El sistema valida los datos, guarda la participación y muestra una **pantalla de éxito**.

---

## 🗂️ Estructura del Proyecto

### 📌 Capa Dominio (`Dominio`)
Clases que representan las entidades principales:
- `Articulo.cs`
- `Categoria.cs`
- `Cliente.cs`
- `Imagen.cs`
- `Marca.cs`
- `Voucher.cs`
- `Dominio.csproj`

### 📌 Capa Acceso a Datos (`AccesoDatos`)
Encargada de la conexión con la base de datos y ejecución de consultas:
- `Datos.cs`
- `AccesoDatos.csproj`

### 📌 Capa Negocio (`Negocio`)
Contiene la lógica de negocio de la aplicación:
- `ArticuloNegocio.cs`
- `ClienteNegocio.cs`
- `VoucherNegocio.cs`
- `Negocio.csproj`

### 📌 Capa Presentación - Pantallas (`Promo Web`)
Interfaz web del sistema:
- `Default.aspx` → Página de inicio
- `VoucherPage.aspx` → Ingreso de código promocional
- `PremioPage.aspx` → Selección de premio
- `RegistroPage.aspx` → Registro de datos del cliente
- `ExitoPage.aspx` → Confirmación y éxito de la participación
- `Master.Master` → Plantilla general del sitio
- `Web.config` → Configuración del proyecto

---

## ⚙️ Funcionalidades
✔ Validación de **códigos de voucher**  

✔ Selección de **premio disponible**  

✔ Registro y actualización de **clientes**  

✔ Precarga de datos si el cliente ya existe  

✔ Manejo de **sesiones** para persistir datos temporales 

✔ Mensajes de error claros

✔ Pantalla de **éxito** tras participar correctamente  

---

## 🚀 Tecnologías Utilizadas
- **ASP.NET WebForms (C#)**
- **SQL Server** (procedimientos almacenados, vistas y triggers)
- **ADO.NET** para acceso a datos
- **HTML5 / CSS3 / Bootstrap** para la interfaz
- **Arquitectura en Capas** (Dominio - Negocio - AccesoDatos - UI)

---

## 👥 Integrantes
- **Lucas Berlingeri**
- **Natalia Mucci** 
- **Mateo Maciel** 
