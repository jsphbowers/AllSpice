CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    recipe(
        id INT NOT NULL PRIMARY KEY COMMENT 'primary key',
        title VARCHAR(255) NOT NULL,
        instructions VARCHAR(255) NOT NULL,
        img VARCHAR(500) NOT NULL,
        category VARCHAR(255) NOT NULL,
        creatorId VARCHAR(255) NOT NULL -- TODO might need to come back and enter in creator info
    );

CREATE TABLE
    ingredient(
        id INT NOT NULL PRIMARY KEY COMMENT 'primary key',
        name VARCHAR(255) NOT NULL,
        quantity VARCHAR(255) NOT NULL,
        recipeId TINYINT NOT NULL
    );

CREATE TABLE
    favorite(
        id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
        accountId VARCHAR(255) NOT NULL,
        recipeId INT NOT NULL
    )