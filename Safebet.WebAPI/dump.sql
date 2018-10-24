CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Matches` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Hash` longtext NULL,
    `Event` longtext NOT NULL,
    `Name` longtext NOT NULL,
    `StartDate` datetime(6) NOT NULL,
    `LastTimePointHash` longtext NULL,
    `Processed` bit NOT NULL,
    `CreatedDate` datetime(6) NOT NULL,
    `LastModifiedDate` datetime(6) NOT NULL,
    CONSTRAINT `PK_Matches` PRIMARY KEY (`Id`)
);

CREATE TABLE `TimePoints` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Hash` longtext NULL,
    `HomeOdds` double NOT NULL,
    `DrawOdds` double NOT NULL,
    `AwayOdds` double NOT NULL,
    `CreatedDate` datetime(6) NOT NULL,
    `MatchId` int NULL,
    CONSTRAINT `PK_TimePoints` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_TimePoints_Matches_MatchId` FOREIGN KEY (`MatchId`) REFERENCES `Matches` (`Id`) ON DELETE NO ACTION
);

CREATE INDEX `IX_TimePoints_MatchId` ON `TimePoints` (`MatchId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20181024014613_InitialModel', '2.1.1-rtm-30846');

