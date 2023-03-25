create database FerreInvent

Create table INVENTORY(
item_id int not null primary key,
item_name varchar(225),
category varchar (225),
bran varchar (225), 
quantity int,
cost decimal
)

create table PRICE(
price decimal,
discount decimal,
ITEMID int FOREIGN KEY references INVENTORY (item_id)
)

create table Users(
id_user int primary key not null,
nombre varchar (150),
position varchar(150),
User_nam varchar (150),
passwordd varchar (150)
)

create table customers (
id_customer int primary key not null,
name_customer varchar(250),
addres varchar (250),
number int,
correo varchar(250)
)

create table sales(
id_sale int primary key not null,
Fecha_sales date, /*M/A/D*/
customer_id int FOREIGN key references customers(id_customer),
id_item int FOREIGN key references INVENTORY(item_id),
quantity int,
totalCost decimal
)

