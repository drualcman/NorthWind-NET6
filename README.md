Caso de uso 1
Historia de usuario: Crear orden de compra.

Como usuario del sistema deseo crear una orden de compra para solicitar productos del almacen.

Caso de uso: Crear orden de compra.

Datos de entrada:
-	Identificador del cliente
-	Direccion de envio:
-	Ciudad de envio
-	Pais de envio
-	Codigo postal de envio
-	Lista de productos incluyendo:
--		Identificadoe del producto
--		Precio
--		Cantidad

Flujo primario:
1. El usuario envia la solicitud "Crear orden de compra" con los datos de entrada.
2. El sistema valida los datos.
3. El sistema registra la accion "inicio de creacion de orden de compra" con fines de auditoria
4. El sistema registra la orden de compra.
5. El sistema registra la accion "Orden de compra <numero de orden> creada." con fines de auditoria.
6. Cuando el numero de productos de la orden de compra sea mayor que 3, el sistema iniciara el proceso de envio de correo de notificacion de "Orden especial creada".
7. El sistema confirma que su solicitud ha sido procesada notificandole el numero de la orden creada.

Flujo alterno: Error de validacion
1. El procesamiento de la solicitud es cancelado.
2. El error es registrado en la bitacora de errores del sistema.
3. El sistema muestra el error al usuario.

Consideraciones:
- NorthWind maneja 4 tipos de transporte de mercancias: maritimo, aereo, ferroviario y terrestre. El tipo predeterminado es terrestre.
- NorthWind maneja 2 formas para especificar descuentos: mediante porcentaje y mediante cantidades absolutas. El descuento predeterminado de una compra es del 10%

Validaciones:
- El identificador del cliene es requerido yu debe ser de 5 caracteres alfanumericos.
- La direccion de envio es requerida y debe ser de una longitud maxima de 60 caracteres alfanumericos.
- La ciudad de envio es requerida y debe tener una longitud minima de 3 y maxima de 15 caracteres alfanumericos.
- El pais de envio es requerido y debe tener una longitud minima de 3 y maxima de 15 caracteres alganumericos.
- El codigo postal es opciones con una longitud maxima de 10 caracteres alfanumericos.
- Debe especificar al menos 1 producto en la orden.
- De cada producto especificado en la orden, sera requerido el identificador del producto, la cantidad y el precio.

Opcionales:
- Validar existencia del producto antes de aceptar la ordern.
- Verificar que el cliente no tenga adeudos para poder aceptar la orden.

Caso de uso 2
Implementar Caso de uso Obtener listado de órdenes de compra
Caso de uso
Historia de usuario: Obtener listado de órdenes de compra
Como usuario del sistema, deseo obtener un listado de las órdenes de compra creadas en una fecha específica para fines de consulta de la información.

Case de uso: Obtener listado de órdenes de compra
Datos de entrada:
 Fecha

Flujo primario
1.	El usuario envía la solicitud “Obtener listado de órdenes de compra” especificando una fecha.
2.	El sistema valida que la fecha sea menor o igual a la fecha actual.
3.	El sistema obtiene el listado de órdenes de compra creadas en la fecha especificada.
4.	El sistema registra la acción “Obtener listado de órdenes de compra” con fines históricos.
5.	El sistema devuelve al usuario el listado de las órdenes de compra.

Flujo alterno: Error de validación.
1.	El procesamiento de la solicitud es cancelado.
2.	El error es registrado en la bitácora de errores del sistema.
3.	El sistema muestra el error al usuario. 