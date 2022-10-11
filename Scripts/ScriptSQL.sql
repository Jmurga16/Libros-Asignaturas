-- ----------------------------------------------------------------------                  
-- APLICACIÓN     : LuckyBooks                                
-- NOMBRE         : LibrosLucky.SQL                
-- AUTOR          : Jose Murga                    
-- FECHA CREACIÓN : 12/12/2020                    
-- DESCRIPCION    : Creación Base de Datos y Tablas de LuckyBooks
-- ----------------------------------------------------------------------  
CREATE DATABASE LibrosLucky
GO

USE LibrosLucky
GO

CREATE TABLE TB_Asignatura
(
	id_asig int PRIMARY KEY,
	descripcion varchar(100),
	estado bit
);
GO

CREATE TABLE TB_Libro
(
	Id_libro int IDENTITY(1,1) PRIMARY KEY ,
    descripcion varchar(100),
    asignatura int FOREIGN KEY REFERENCES TB_Asignatura(id_asig) ,
    stock int
);
GO

-- ----------------------------------------------------------------------                  
-- APLICACIÓN     : Libros LuckyBooks                                
-- NOMBRE         : PobladoDatos.SQL                
-- AUTOR          : Jose Murga                    
-- DESCRIPCION    : Poblado de datos 
-- ----------------------------------------------------------------------  

USE [LibrosLucky]
GO

INSERT INTO TB_Asignatura (id_asig,descripcion,estado)
VALUES(201,'Computacion',1)

INSERT INTO TB_Asignatura (id_asig,descripcion,estado)
VALUES(210,'Calculo',1)

INSERT INTO TB_Asignatura (id_asig,descripcion,estado)
VALUES(212,'Matematica',1)

INSERT INTO TB_Asignatura (id_asig,descripcion,estado)
VALUES(310,'Historia Universal',0)

-----------------------------------------------

INSERT INTO TB_Libro (descripcion,asignatura,stock)
VALUES('Fundamentos de Computacion',201,15)

INSERT INTO TB_Libro (descripcion,asignatura,stock)
VALUES('Programacion Orientada a Objetos',201,10)


INSERT INTO TB_Libro (descripcion,asignatura,stock)
VALUES('Java Basico',201,20)

INSERT INTO TB_Libro (descripcion,asignatura,stock)
VALUES('Fundamentos de Calculo',210,1)


INSERT INTO TB_Libro (descripcion,asignatura,stock)
VALUES('Analisis Matematico',210,0)


INSERT INTO TB_Libro (descripcion,asignatura,stock)
VALUES('Matematica',212,12)
GO


-- ----------------------------------------------------------------------  
-- DESCRIPCION    : Procedure Modulo Libros
-- ----------------------------------------------------------------------  

CREATE PROCEDURE [dbo].[USP_MNT_Libros]          
            
@cOpcion VARCHAR(2)= '',   
@nId_libro INT = 0,
@cDescripcion VARCHAR(100)='',
@cAsignatura VARCHAR(100)='',
@nId_asig INT=0,
@bStock INT=1,	--Estado de Disponibilidad
@nStock INT=0	--Cantidad Disponible
                                                                                   
 AS                                              
              
IF @cOpcion = '01'   --INSERTAR(C)                                                                         
BEGIN  
                                                                                                                                                     
	 INSERT INTO TB_Libro (descripcion,asignatura,stock)                                                            
	 VALUES (@cDescripcion,@nId_asig,@nStock);                                                          
                                                                                 
END;                                     


IF @cOpcion = '02'  --CONSULTAR TODO  (R) --Lista de Disponibilidad->Todos                                                       
BEGIN	
	

		SELECT lib.Id_libro, lib.descripcion, asg.descripcion AS 'asignatura',lib.stock
			FROM TB_Libro lib
		INNER JOIN TB_Asignatura asg
		ON lib.asignatura=asg.id_asig --ON asg.estado=1
		
	
END;


IF @cOpcion = '03'  --CONSULTAR CON FILTROS (R)                                                        
BEGIN	
	IF @bStock=1	--Lista de Disponibilidad->Todos
	BEGIN
		SELECT 
			lib.Id_libro, 
			lib.descripcion, 
			asg.descripcion AS 'asignatura',
			lib.stock
		FROM TB_Libro lib
		INNER JOIN TB_Asignatura asg ON lib.asignatura=asg.id_asig AND asg.estado=1
		WHERE	lib.descripcion LIKE '%' + @cDescripcion + '%'
		AND		asg.descripcion LIKE '%' + @cAsignatura + '%'
	END;

	IF @bStock=2	--Lista de Disponibilidad->En Stock
	BEGIN
		SELECT 
			lib.Id_libro, 
			lib.descripcion, 
			asg.descripcion AS 'asignatura',
			lib.stock
		FROM TB_Libro lib
		INNER JOIN TB_Asignatura asg ON lib.asignatura=asg.id_asig AND asg.estado=1
		WHERE	lib.descripcion LIKE '%' + @cDescripcion + '%'
		AND		asg.descripcion LIKE '%' + @cAsignatura + '%'
		AND		lib.stock > 0
	END;

	IF @bStock=3	--Lista de Disponibilidad->Sin Stock
	BEGIN
		SELECT 
			lib.Id_libro, 
			lib.descripcion, 
			asg.descripcion AS 'asignatura',
			lib.stock
		FROM TB_Libro lib	
		INNER JOIN TB_Asignatura asg ON lib.asignatura=asg.id_asig AND asg.estado=1
		WHERE	lib.descripcion LIKE '%' + @cDescripcion + '%'
		AND		asg.descripcion LIKE '%' + @cAsignatura + '%'
		AND		lib.stock=0
	END;
END

 
IF @cOpcion = '04'  -- EDITAR   (U)                                                        
BEGIN                                         
                                     
     UPDATE TB_Libro                           
     SET descripcion = @cDescripcion,                           
         asignatura   = @nId_asig,       
         stock = @nStock      
                             
     WHERE Id_libro = @nId_libro                           
                                                       
END;                            

                                                           
IF @cOpcion = '05'  -- ELIMINAR (D)                                                          
BEGIN                                                          
                                                             
 --Eliminación Directa(Podría ser lógica agregando un campo booleano)
                                                             
 DELETE FROM TB_Libro WHERE Id_libro = @nId_libro                                  
                                                            
END;                                                        
     
	 
IF @cOpcion = '06'  --CONSULTAR POR ID                                                   
BEGIN	
	

		SELECT *FROM TB_Libro
			WHERE Id_libro=@nId_libro
		
	
END;

GO


-- ----------------------------------------------------------------------  
-- DESCRIPCION    : Procedure Modulo Asignaturas
-- ----------------------------------------------------------------------  

CREATE PROCEDURE [dbo].[USP_MNT_Asignaturas]          
            
@cOpcion VARCHAR(2)= '',   
@nId_asig INT = 0,
@cDescripcion VARCHAR(100)='',
@bEstado BIT=0,
@bStock INT=0,	--Estado de Disponibilidad
@nStock INT=0	--Cantidad Disponible
                                                                                   
 AS                                              
              
IF @cOpcion = '01'   --INSERTAR(C)                                                                         
BEGIN  
                                                                                                                                                     
	 INSERT INTO TB_Asignatura(id_asig,descripcion,estado)                                                            
	 VALUES (@nId_asig,@cDescripcion,@bEstado);                                                          
                                                                                 
END;                                     


IF @cOpcion = '02'  --CONSULTAR TODO (R)                                                        
BEGIN	
	
		SELECT * FROM TB_Asignatura
END;


IF @cOpcion = '03'  --CONSULTAR ACTIVOS O INACTIVOS (R)                                                        
BEGIN	
	
		SELECT * FROM TB_Asignatura
		WHERE estado=@bEstado
END;

 
IF @cOpcion = '04'  -- EDITAR   (U)                                                        
BEGIN
                                     
     UPDATE TB_Asignatura                           
     SET id_asig   = @nId_asig, 
		 descripcion = @cDescripcion,                           
         estado = @bEstado      
     WHERE id_asig = @nId_asig                           
                                                       
END;                            

                                                           
IF @cOpcion = '05'  -- ELIMINAR (D)                                                          
BEGIN                                                          
                                                             
 --Considerando eliminación diferente a Estado(Activo/Inactivo)	                                                        
 --DELETE FROM TB_Asignatura WHERE id_asig = @nId_asig                                  
     
 --Eliminación Lógica
	 UPDATE TB_Asignatura                           
     SET estado = @bEstado      
     WHERE id_asig = @nId_asig     
		 
END;                                                        
                                        	 
IF @cOpcion = '06'  --CONSULTAR POR ID                                                   
BEGIN	
	
	SELECT *FROM TB_Asignatura
		WHERE id_asig=@nId_asig
	
END;

GO
