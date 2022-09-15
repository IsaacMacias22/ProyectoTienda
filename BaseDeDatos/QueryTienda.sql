CREATE DATABASE tienda2;
USE tienda2;

CREATE TABLE productos(
idProducto INT PRIMARY KEY AUTO_INCREMENT,
nombre VARCHAR(100),
descripcion VARCHAR(100),
precio DOUBLE	 
);

delimiter ;;
DROP PROCEDURE if EXISTS p_insertOrUpdateProducto;
CREATE PROCEDURE p_insertOrUpdateProducto(
IN p_nombre VARCHAR(100),
IN p_descripcion VARCHAR(100),
IN p_precio DOUBLE,
IN p_idProducto INT
)
BEGIN
	DECLARE X INT;
	SELECT COUNT(*) FROM productos WHERE nombre = p_nombre INTO X;
	if X = 0 AND p_idProducto < 0 then
		INSERT INTO productos VALUES(NULL, p_nombre, p_descripcion, p_precio);
	ELSE if X = 0 AND p_idProducto > 0 then
		UPDATE productos SET nombre = p_nombre, descripcion = p_descripcion, precio = p_precio
		WHERE idProducto = p_idProducto;
	ELSE
		UPDATE productos SET descripcion = p_descripcion, precio = p_precio 
		WHERE idProducti = p_idProducto;
	END if;
	END if;
END;;

delimiter ;;
DROP PROCEDURE if EXISTS p_deleteProducto;
CREATE PROCEDURE p_deleteProducto(IN p_idProducto INT)
BEGIN
	DELETE FROM productos WHERE idProducto = p_idProducto;
END;;

delimiter ;;
DROP PROCEDURE if EXISTS p_showProductos;
CREATE PROCEDURE p_showProductos(IN filtro VARCHAR(100))
BEGIN
	SELECT * FROM productos WHERE nombre LIKE filtro
	OR descripcion LIKE filtro OR precio LIKE filtro;
END;;

