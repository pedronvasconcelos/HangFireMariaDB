CREATE TABLE `NumberDraws` (                                       
    `Id` CHAR(36) NOT NULL DEFAULT (UUID()),                       
    `Number` BIGINT NOT NULL,                                      
    PRIMARY KEY (`Id`)                                             
);