-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`Orders`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Orders` (
  `OrderID` INT NOT NULL,
  `OrderUserID` VARCHAR(45) NULL,
  `OrderDate` VARCHAR(45) NULL,
  `ShipAddr1` VARCHAR(45) NULL,
  `ShipAddr2` VARCHAR(45) NULL,
  `ShipCity` VARCHAR(45) NULL,
  `ShipCounty` VARCHAR(45) NULL,
  `BillAddr1` VARCHAR(45) NULL,
  `BillAddr2` VARCHAR(45) NULL,
  `BillCity` VARCHAR(45) NULL,
  `BillCounty` VARCHAR(45) NULL,
  PRIMARY KEY (`OrderID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Category` (
  `CategoryID` INT NOT NULL,
  `Name` VARCHAR(45) NULL,
  PRIMARY KEY (`CategoryID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Products`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Products` (
  `ProductID` INT NOT NULL,
  `ProductName` VARCHAR(45) NULL,
  `ProductCategory` VARCHAR(45) NULL,
  `ProductPrice` VARCHAR(45) NULL,
  `ProductDescription` VARCHAR(45) NULL,
  `ProductImage` VARCHAR(45) NULL,
  PRIMARY KEY (`ProductID`),
  INDEX `fk_Products_Category1_idx` (`ProductCategory` ASC),
  CONSTRAINT `fk_Products_Category1`
    FOREIGN KEY (`ProductCategory`)
    REFERENCES `mydb`.`Category` (`CategoryID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`ShopCart`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`ShopCart` (
  `CartID` INT NOT NULL,
  `ProductID` VARCHAR(45) NULL,
  PRIMARY KEY (`CartID`),
  INDEX `fk_ShopCart_Products1_idx` (`ProductID` ASC),
  CONSTRAINT `fk_ShopCart_Products1`
    FOREIGN KEY (`ProductID`)
    REFERENCES `mydb`.`Products` (`ProductID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Profile`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Profile` (
  `UserID` INT NOT NULL,
  `WishList` VARCHAR(45) NULL,
  `ShoppingCart` VARCHAR(45) NULL,
  PRIMARY KEY (`UserID`),
  INDEX `fk_Profile_ShopCart1_idx` (`ShoppingCart` ASC),
  CONSTRAINT `fk_Profile_ShopCart1`
    FOREIGN KEY (`ShoppingCart`)
    REFERENCES `mydb`.`ShopCart` (`CartID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`User`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`User` (
  `UserID` VARCHAR(45) NOT NULL,
  `Password` VARCHAR(45) NULL,
  `Email` VARCHAR(45) NULL,
  `FirstName` VARCHAR(45) NULL,
  `LastName` VARCHAR(45) NULL,
  `Address1` VARCHAR(45) NULL,
  `Address2` VARCHAR(45) NULL,
  `City` VARCHAR(45) NULL,
  `County` VARCHAR(45) NULL,
  PRIMARY KEY (`UserID`),
  CONSTRAINT `fk_Accounts_Orders`
    FOREIGN KEY (`UserID`)
    REFERENCES `mydb`.`Orders` (`OrderUserID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Accounts_Profile1`
    FOREIGN KEY (`UserID`)
    REFERENCES `mydb`.`Profile` (`UserID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Admin`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Admin` (
  `AdminID` VARCHAR(45) NOT NULL,
  `Password` VARCHAR(45) NULL,
  `LastName` VARCHAR(45) NULL,
  `FirstName` VARCHAR(45) NULL,
  PRIMARY KEY (`AdminID`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
