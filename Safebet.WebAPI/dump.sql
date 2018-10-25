CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Matches` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Hash` longtext NULL,
    `EventName` longtext NOT NULL,
    `StartDate` datetime(6) NOT NULL,
    `Name` longtext NOT NULL,
    `LastTimePointHash` longtext NULL,
    `Processed` bit NOT NULL,
    `Result` longtext NULL,
    `CreatedDate` datetime(6) NOT NULL,
    `LastModifiedDate` datetime(6) NOT NULL,
    CONSTRAINT `PK_Matches` PRIMARY KEY (`Id`)
);

CREATE TABLE `Predictions` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `HomeOdds` double NOT NULL,
    `DrawOdds` double NOT NULL,
    `AwayOdds` double NOT NULL,
    `FavoriteResult` longtext NOT NULL,
    `HomeOddsGain` double NOT NULL,
    `DrawOddsGain` double NOT NULL,
    `AwayOddsGain` double NOT NULL,
    `H1` double NOT NULL,
    `H2` double NOT NULL,
    `H3` double NOT NULL,
    `H4` double NOT NULL,
    `H5` double NOT NULL,
    `D1` double NOT NULL,
    `D2` double NOT NULL,
    `D3` double NOT NULL,
    `D4` double NOT NULL,
    `D5` double NOT NULL,
    `A1` double NOT NULL,
    `A2` double NOT NULL,
    `A3` double NOT NULL,
    `A4` double NOT NULL,
    `A5` double NOT NULL,
    `HomeDropIndex` double NOT NULL,
    `DrawDropIndex` double NOT NULL,
    `AwayDropIndex` double NOT NULL,
    `HomeMovementIndex` double NOT NULL,
    `DrawMovementIndex` double NOT NULL,
    `AwayMovementIndex` double NOT NULL,
    `CreatedDate` datetime(6) NOT NULL,
    `MatchId` int NULL,
    CONSTRAINT `PK_Predictions` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Predictions_Matches_MatchId` FOREIGN KEY (`MatchId`) REFERENCES `Matches` (`Id`) ON DELETE NO ACTION
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

CREATE INDEX `IX_Predictions_MatchId` ON `Predictions` (`MatchId`);

CREATE INDEX `IX_TimePoints_MatchId` ON `TimePoints` (`MatchId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20181025074447_InitialModel', '2.1.1-rtm-30846');

