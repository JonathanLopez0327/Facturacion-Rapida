
use RGHgroup

--Administracion de clientes
create table Clientes
(
ID int identity(10001,5),
Cliente nvarchar(100),
RNC_No nvarchar (100) not null,
Direccion nvarchar(100) not null,
Telefono nchar(15),
Fax nchar(15)
);

select * from Clientes;
update Clientes set Cliente = 'klk', RNC_No = '555' Where ID = '10021'
drop table Clientes;
go


--Adminisatracion de cliente en uso
create table Clientes
(
	ID int identity(1001,1),
	Nombre VARCHAR(100),
	RNC_No VARCHAR(100),
	Direccion VARCHAR(100),
	Telefono VARCHAR(100)
	

);


Insert INTO Clientes values('Acromax', '02215', 'Av. Venezuela #78, Los Mina Santo Domingo, Este, Rep. Dom.', '(809) - 596 - 3665', '(809) -558- 999')
SELECT * FROM Clientes
drop table Clientes;
GO


--Inventario de productos
CREATE TABLE Productos
(
ID int identity(10001,5),
Codigo varchar(100) not null,
Descripcion varchar(100) not null,
Existencia int not null,
C_Unidades int not null,
Unidad varchar(50)not null,
Bodega varchar(50)not null,
Lote varchar(50)not null,
Precio_Compra varchar(100),
Vencimiento varchar(50)not null,
Marca varchar(50)not null
);


select * from  Productos;
drop table Productos;

GO
--detalles factura

Create table FacTip
(

ValidaHasta varchar(50),
Fecha varchar(50) ,
OrdenCompra varchar (50) ,
FormaPago varchar (50) 
);

TRUNCATE TABLE FacTip;
select * from FacTip;
DROP TABLE  FacTip;

 
GO


--detalles de clientes sobre la factura
create table CliFac
(
	
	NomCli varchar(100) not null,
	rnc_No varchar (50) not null,
	DireccCli varchar (100) not null,
	Tel char(15) not null
	
);



insert into CliFac values('sdds', 'sdsd', 'dds', 'dsd');


select * from CliFac;
DROP TABLE  CliFac;

go



--detalles de clientes sobre la factura en uso

Create Table CliFac
(
	Numero INT,
	NomCli varchar(100),
	rnc varchar(100),
	Direc varchar(100),
	tel varchar(100),
	Faxx varchar(100)
);


--informacion de factura
create table DEfac
(
	Ret varchar(100),
	CodPro varchar(100) NOT NULL,
	CantidadTomada int NOT NULL,
	PresentFac varchar(100) NOT NULL,
	DescripFac varchar(100) NOT NULL,
	PrecioUFAC varchar(100) NOT NULL,
	SubToFac varchar(100) NOT NULL,
	ITBISFac varchar(100) NOT NULL,
	PrecioT varchar(100) NOT NULL,
);

select * from DEfac order by Ret;

SELECT * FROM DEfac WHERE Ret BETWEEN 'B0000000010' AND 'B0000000020' ORDER BY Ret 



delete from DEfac WHERE SubToFac = 'NULL' 

drop table DEfac;
go

Create table DEfac
(
	Ret varchar (100),
	CodPro varchar(100),
	CantTo int,
	PresFac varchar(100),
	DesFac varchar(100),
	PrecioFac varchar(100),
	SubFac varchar(100),
	ItbisFacc varchar(100),
	PreciFin varchar(100)
);




GO


--destalles


-- generadores de numeros de facturas

create table Comprobante
(	
	Num INT NOT NULL IDENTITY(1500000000,1),
	Cad AS 'B' + right(REPLICATE('0',
	10)+LTRIM(Num), 10),
	Cadena varchar(50),
	
);

SELECT * FROM Comprobante WHERE Cad BETWEEN 'B1500000000' AND 'B1500000002' ORDER BY Num ASC

select * from Comprobante
drop table Comprobante;


go

create table Regimenes
(	
	Num INT NOT NULL IDENTITY(1400000000,1),
	Cad AS 'B' + right(REPLICATE('0',
	10)+LTRIM(Num), 10),
	Cadena varchar(50),
	
);

select * from Regimenes
drop table Regimenes;

go

create table CreditoFi
(	
	Nume INT NOT NULL IDENTITY(100000000,1),
	Cade AS 'B' + right(REPLICATE('0',
	10)+LTRIM(Nume), 10),
	Cadenas varchar(50),
	
);

insert into CreditoFi values('B');

select * from CreditoFi
drop table CreditoFi;

go

create table ConsumidorFi
(	
	Nume INT NOT NULL IDENTITY(200000000,1),
	Cade AS 'B' + right(REPLICATE('0',
	10)+LTRIM(Nume), 10),
	Cadenas varchar(50),
	
);

create table note
(	
	Rets int identity(001,1),
	Cadenas varchar(50),
	
);

insert into note values('b');
select * from note
drop table note
--detalles factura
create table Fac
(
	
	fecha varchar(100),
	VALID varchar(100),
	Orden varchar(100),
	Forma varchar(100),
	TipoFac varchar(100)
);

select * from Fac;
SELECT * FROM Fac WHERE fecha BETWEEN 'domingo, 30 de junio de 2019' AND 'jueves, 4 de julio de 2019' ORDER BY fecha ASC
drop table Fac;



-- generador de fecha 
create table Fecha
(
	fecha varchar(100)
);

select * from Fecha



--Orden de Registros Factura


SELECT * FROM Comprobante WHERE Cad BETWEEN 'B1500000000' AND 'B1500000002' ORDER BY Num ASC

CREATE TABLE Registros
(
	Fecha varchar(100),
	No_Factura VARCHAR(100),
	Codigo VARCHAR(100),
	Descripcion VARCHAR(100),
	Lote VARCHAR(100),
	Presentacion Varchar(100),
	Cantida INT,
	Costo VARCHAR(100),
	Costo_Total VARCHAR(100),--ganancia 0
	Precio VARCHAR(100),
	Precio_Total VARCHAR(100),
	Utilidad VARCHAR(100)


);

SELECT * FROM Registros WHERE No_Factura LIKE '%B%' AND Fecha BETWEEN '20/07/2019' AND '20/07/2019' ORDER BY Fecha ASC 

insert into Registros values('B00000027', 'CAASD', '18/07/2019', 'Crediot fiscal', 'NR  No.83', 'hola', 'dddd7887');
 

SELECT * FROM Registros  ORDER BY FechaFac

delete from Registros where FechaFac = 'jueves, 15 de julio de 2019'

select sum(Utilidad) from Registros

drop Table Registros



