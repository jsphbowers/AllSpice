CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture' createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    ) default charset utf8 COMMENT '';

CREATE TABLE
    recipes(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
        title VARCHAR(255) NOT NULL,
        instructions VARCHAR(255) NOT NULL,
        img VARCHAR(500) NOT NULL,
        category VARCHAR(255) NOT NULL,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) NOT NULL,
        Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

INSERT INTO
    recipes(
        title,
        instructions,
        img,
        category
    ),
values();

CREATE TABLE
    ingredients(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
        name VARCHAR(255) NOT NULL,
        quantity VARCHAR(255) NOT NULL,
        recipeId TINYINT NOT NULL
    ) default charset utf8 COMMENT '';

CREATE TABLE
    favorites(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
        accountId VARCHAR(255) NOT NULL,
        recipeId INT NOT NULL
    ) default charset utf8 COMMENT '';

-- DROP TABLE recipes;

SELECT rec.*, acct.*
FROM recipes rec
    JOIN accounts acct ON rec.creatorId = acct.id;

UPDATE recipes
SET
    title = "A recipe",
    instructions = "Do the thing",
    category = "Savory",
    img = "https://images.unsplash.com/photo-1529694157872-4e0c0f3b238b?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80"
WHERE id = 4;

SELECT ing.*, rec.*
FROM ingredients ing
    JOIN recipes rec ON ing.recipeId = rec.id
WHERE ing.id = LAST_INSERT_ID();