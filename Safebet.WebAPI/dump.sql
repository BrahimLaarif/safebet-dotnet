CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Predictions` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `MatchId` int NOT NULL,
    `HomeOdds` float NOT NULL,
    `DrawOdds` float NOT NULL,
    `AwayOdds` float NOT NULL,
    `FavoriteResult` longtext NOT NULL,
    `HomeOddsGain` float NOT NULL,
    `DrawOddsGain` float NOT NULL,
    `AwayOddsGain` float NOT NULL,
    `H1` float NOT NULL,
    `H2` float NOT NULL,
    `H3` float NOT NULL,
    `H4` float NOT NULL,
    `H5` float NOT NULL,
    `D1` float NOT NULL,
    `D2` float NOT NULL,
    `D3` float NOT NULL,
    `D4` float NOT NULL,
    `D5` float NOT NULL,
    `A1` float NOT NULL,
    `A2` float NOT NULL,
    `A3` float NOT NULL,
    `A4` float NOT NULL,
    `A5` float NOT NULL,
    `HomeDropIndex` float NOT NULL,
    `DrawDropIndex` float NOT NULL,
    `AwayDropIndex` float NOT NULL,
    `HomeMovementIndex` float NOT NULL,
    `DrawMovementIndex` float NOT NULL,
    `AwayMovementIndex` float NOT NULL,
    `PredictedResult` longtext NOT NULL,
    `PredictedHomeProba` float NOT NULL,
    `PredictedDrawProba` float NOT NULL,
    `PredictedAwayProba` float NOT NULL,
    `PredictedResultProba` float NOT NULL,
    `PredictedResultOdds` float NOT NULL,
    `PredictedResultOddsGain` float NOT NULL,
    `PredictedResultDropIndex` float NOT NULL,
    `PredictedResultMovementIndex` float NOT NULL,
    `AccuratePrediction` int NOT NULL,
    `BalancedOdds` int NOT NULL,
    `HomeAdvantage` int NOT NULL,
    `PredictedResultProbaIsSafe` int NOT NULL,
    `PredictedResultOddsIsSafe` int NOT NULL,
    `PredictedResultGainsAndDropsIsGoingDown` int NOT NULL,
    `OtherResultsGainsAndDropsIsGoingUp` int NOT NULL,
    `PredictedResultGraphIsChaotic` int NOT NULL,
    `PredictedResultGraphIsGoingDown` int NOT NULL,
    `PredictedResultGraphTailIsGoingDown` int NOT NULL,
    `PredictedSafetyLevel` int NOT NULL,
    `PredictedUnsafeProba` float NOT NULL,
    `PredictedSafeProba` float NOT NULL,
    `PredictedSafetyLevelProba` float NOT NULL,
    `Gemstone` longtext NULL,
    `CreationDate` datetime(6) NOT NULL,
    CONSTRAINT `PK_Predictions` PRIMARY KEY (`Id`)
);

CREATE TABLE `Matches` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Hash` longtext NULL,
    `EventName` longtext NOT NULL,
    `StartDate` datetime(6) NOT NULL,
    `Name` longtext NOT NULL,
    `LastTimePointHash` longtext NULL,
    `LastPredictionId` int NULL,
    `Processed` bit NOT NULL,
    `Result` longtext NULL,
    `CreationDate` datetime(6) NOT NULL,
    CONSTRAINT `PK_Matches` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Matches_Predictions_LastPredictionId` FOREIGN KEY (`LastPredictionId`) REFERENCES `Predictions` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `TimePoints` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `MatchId` int NOT NULL,
    `Hash` longtext NULL,
    `HomeOdds` float NOT NULL,
    `DrawOdds` float NOT NULL,
    `AwayOdds` float NOT NULL,
    `CreationDate` datetime(6) NOT NULL,
    CONSTRAINT `PK_TimePoints` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_TimePoints_Matches_MatchId` FOREIGN KEY (`MatchId`) REFERENCES `Matches` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_Matches_LastPredictionId` ON `Matches` (`LastPredictionId`);

CREATE INDEX `IX_Predictions_MatchId` ON `Predictions` (`MatchId`);

CREATE INDEX `IX_TimePoints_MatchId` ON `TimePoints` (`MatchId`);

ALTER TABLE `Predictions` ADD CONSTRAINT `FK_Predictions_Matches_MatchId` FOREIGN KEY (`MatchId`) REFERENCES `Matches` (`Id`) ON DELETE CASCADE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20181112131454_InitialModel', '2.1.1-rtm-30846');

