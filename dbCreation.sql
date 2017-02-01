create database ns_orders;

use ns_orders;

create table users
(
us_user int not null identity(1,1) primary key,
us_login varchar(20),
us_password varchar(20),
us_master bit,
us_enable bit
)

create table orders
(
or_order int not null identity(1165,1) primary key,
or_date date,
or_client_name varchar(200),
or_phone varchar(20),
or_product_description varchar(max),
or_price float,
or_anticipe float,
or_observation varchar(max),
or_state bit,
or_user_owner int foreign key references users(us_user)
); 

create table quotes
(
qu_quote int not null identity(1,1) primary key,
qu_date date,
qu_client_name varchar(200),
qu_phone varchar(20),
qu_detail varchar(max),
qu_price float,
qu_supplier varchar(200),
qu_user_owner int foreign key references users(us_user)
)

----***---Procedures


ALTER procedure [dbo].[sp_orders]
(
@i_accion varchar(2),
@i_order int=null,
@i_date date=null,
@i_client_name varchar(200)=null,
@i_phone varchar(20)=null,
@i_product_description varchar(max)=null,
@i_price float=null,
@i_anticipe float=null,
@i_observation varchar(max)=null,
@i_state bit=null,
@i_user_owner int=null
)
as
begin

	if(@i_accion='S1')
	begin
	select 
		or_order,
		or_date ,
		or_client_name,
		or_phone ,
		or_product_description,
		or_price ,
		or_anticipe ,
		or_observation ,
		or_state,
		or_user_owner,
		(select us_name+' '+us_paterno from users where us_user=or_user_owner) as name 
		
	from orders
	end

	if(@i_accion='S2')
	begin
	select * from orders where or_order=@i_order
	end

	if(@i_accion='I1')
	begin
	insert into orders
	(
		or_date ,
		or_client_name,
		or_phone ,
		or_product_description,
		or_price ,
		or_anticipe ,
		or_observation ,
		or_state,
		or_user_owner 
	)
	values
	(

		@i_date,
		@i_client_name,
		@i_phone,
		@i_product_description,
		@i_price,
		@i_anticipe,
		@i_observation,
		@i_state,
		@i_user_owner	
	)

	end

	if(@i_accion='U1')
	begin
	update orders
	set
		or_date=@i_date,
		or_client_name=@i_client_name,
		or_phone=@i_phone,
		or_product_description=@i_product_description,
		or_price=@i_price,
		or_anticipe=@i_anticipe,
		or_observation=@i_observation,
		or_state=@i_state
		--or_user_owner=@i_user_owner
	where or_order=@i_order
	end

	if(@i_accion='D1')
	begin
	delete orders where or_order=@i_order
	end

	if(@i_accion='F1')
	begin
		if(@i_client_name is null and @i_product_description is null)
		begin
			select * from orders where [or_date] = @i_date
		end
		if(@i_client_name is null and @i_date is null)
		begin
			select * from orders where [or_product_description] like '%' + @i_product_description + '%'
		end

		if(@i_date is null and @i_product_description is null)
		begin
			select * from orders where [or_client_name] like '%' + @i_client_name + '%'
		end


		if(@i_client_name is null and @i_product_description is not null and @i_date is not null)
		begin
			select * from orders where [or_product_description] like '%' + @i_product_description + '%' and or_date like @i_date
		end

		if(@i_client_name is not null and @i_product_description is null and @i_date is not null)
		begin
			select * from orders where [or_client_name] like '%' + @i_client_name + '%' and or_date like @i_date
		end

		if(@i_client_name is not null and @i_product_description is not null and @i_date is null)
		begin
			select * from orders where [or_product_description] like '%' + @i_product_description + '%' and [or_client_name] like '%' + @i_client_name + '%'
		end

		if(@i_client_name is not null and @i_product_description is not null and @i_date is not null)
		begin
			select * from orders where [or_product_description] like '%' + @i_product_description + '%' and [or_client_name] like '%' + @i_client_name + '%' and or_date like @i_date
		end

	end

end

------**************************-------------
create procedure sp_users
(
@i_accion varchar(2),
@i_user int =null,
@i_login varchar(20)=null,
@i_password varchar(20)=null,
@i_master bit=null
)
as
begin

	if(@i_accion='S1')
	begin
	select * from users 
	end

	if(@i_accion='I1')
	begin
	insert into users
	(
		us_login,
		us_password,
		us_master
	)
	values 
	(
		@i_login,
		@i_password,
		@i_master
	)
	end

	if(@i_accion='U1')
	begin
	update users
	set
		us_login=@i_login,
		us_password=@i_password,
		us_master=@i_master
	where us_user=@i_user
	end

end

------********************************----------
------********************************----------
------**********QUOTES****************----------
------********************************----------
------********************************----------


create procedure sp_quotes
(
@i_accion varchar(2),
@i_quote int=null,
@i_date date=null,
@i_client_name varchar(200)=null,
@i_phone varchar(20)=null,
@i_detail varchar(max)=null,
@i_price float=null,
@i_supplier varchar(200)=null,
@i_user_owner int=null
)
as
begin

	if(@i_accion='S1')
	begin
	select 
		qu_quote,
		qu_date ,
		qu_client_name,
		qu_phone ,
		qu_detail,
		qu_price ,
		qu_supplier ,
		qu_user_owner,
		(select us_name+' '+us_paterno from users where us_user=qu_user_owner) as name 
		
	from quotes
	end

	if(@i_accion='S2')
	begin
	select * from quotes where qu_quote=@i_quote
	end

	if(@i_accion='I1')
	begin
	insert into quotes
	(
		qu_date ,
		qu_client_name,
		qu_phone ,
		qu_detail,
		qu_price ,
		qu_supplier ,
		qu_user_owner
	)
	values
	(

		@i_date,
		@i_client_name,
		@i_phone,
		@i_detail,
		@i_price,
		@i_supplier,
		@i_user_owner	
	)

	end

	if(@i_accion='U1')
	begin
	update quotes
	set
		qu_date=@i_date,
		qu_client_name=@i_client_name,
		qu_phone=@i_phone,
		qu_detail=@i_detail,
		qu_price=@i_price,
		qu_supplier=@i_supplier
		--or_user_owner=@i_user_owner
	where qu_quote=@i_quote
	end

	if(@i_accion='D1')
	begin
	delete quotes where qu_quote=@i_quote
	end

end

