-- Drop the database if it exists
IF EXISTS (SELECT * FROM sys.databases WHERE name = N'EyeConic')
    DROP DATABASE EyeConic;

-- Create the database
CREATE DATABASE EyeConic;

USE EYECONIC;

CREATE TABLE users(
    id int identity(1,1) primary key not null,
    firstName nvarchar(100) not null,
	lastName nvarchar(100) not null,
    username nvarchar(100) not null,
    email nvarchar(100) not null,
    password nvarchar(100) not null,
	address NVARCHAR(255) not null,
	city nvarchar(100) not null,
	state nvarchar(100) not null,
	country nvarchar(100) not null,
	postal_code nvarchar(6) not null
);

CREATE TABLE admin(
    id int identity(1,1) primary key not null,
    username nvarchar(100) not null,
    password nvarchar(100) not null,
);

-- Creating Categories table
CREATE TABLE categories(
    id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    name VARCHAR(100) NOT NULL,
    description VARCHAR(100) NOT NULL,
    isDeleted BIT NOT NULL DEFAULT 0 -- Added IsDeleted column
);

-- Creating SubCategories table
CREATE TABLE subcategories(
    id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    categoryId INT NOT NULL,
    name VARCHAR(100) NOT NULL,
    description VARCHAR(100) NOT NULL,
    isDeleted BIT NOT NULL DEFAULT 0 -- Added IsDeleted column
    FOREIGN KEY (categoryId) REFERENCES categories(id)
);

-- Creating Products table
CREATE TABLE products (
    id INT IDENTITY(1,1) PRIMARY KEY,
    categoryId INT,
    subCategoryId INT,
    name NVARCHAR(100) NOT NULL,
    description NVARCHAR(100) NOT NULL,
    price DECIMAL(10,2) NOT NULL,
    frameSize NVARCHAR(20), 
    frameWidth NVARCHAR(20),
    frameDimensions NVARCHAR(20),
    frameColor NVARCHAR(50),
    isDeleted BIT NOT NULL DEFAULT 0 -- Added IsDeleted column
    CONSTRAINT FK_Products_Category FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    CONSTRAINT FK_Products_SubCategory FOREIGN KEY (SubCategoryId) REFERENCES SubCategories(Id)
);

-- Creating Image table
CREATE TABLE image (
    imageId INT IDENTITY(1,1) PRIMARY KEY,
    productId INT,
    imageName NVARCHAR(255),
    isDeleted BIT NOT NULL DEFAULT 0, -- Added IsDeleted column
    CONSTRAINT FK_Image_Product FOREIGN KEY (productId) REFERENCES products(id)
);

CREATE TABLE cart(
	id INT IDENTITY(1,1) PRIMARY KEY,
	userId INT,
	productId INT,
	quantity INT,
	totalPrice DECIMAL(10,2),
	CONSTRAINT FK_Cart_User FOREIGN KEY(userId) REFERENCES users(id),
	CONSTRAINT FK_Cart_Product FOREIGN KEY(productId) REFERENCES products(id)
);

CREATE TABLE bill(
	id INT IDENTITY(1,1) PRIMARY KEY,
	firstName varchar(100),
	lastName varchar(100),
	email varchar(100),
	address varchar(100),
	state varchar(100),
	city varchar(100),
	postalCode INT,
	country varchar(100),
	userId INT,
	total INT,
	CONSTRAINT FK_Bill_User FOREIGN KEY(userId) REFERENCES users(id)
);

CREATE TABLE orders(
	id INT IDENTITY(1,1) PRIMARY KEY,
	name varchar(100) not null,
	price decimal(10,2) not null,
	quantity int,
	total decimal(10,2) not null,

	billId INT,
	cartId INT,
	CONSTRAINT FK_bill_Id FOREIGN KEY(billId) REFERENCES bill(id),
	CONSTRAINT FK_cart_Id FOREIGN KEY(cartId) REFERENCES bill(id)
);
