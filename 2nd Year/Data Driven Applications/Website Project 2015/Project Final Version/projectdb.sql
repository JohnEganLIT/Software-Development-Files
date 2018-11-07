-- phpMyAdmin SQL Dump
-- version 4.4.12
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Aug 11, 2015 at 05:44 AM
-- Server version: 5.6.25
-- PHP Version: 5.6.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `projectdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `auctions`
--

CREATE TABLE IF NOT EXISTS `auctions` (
  `id` int(11) NOT NULL,
  `title` varchar(20) NOT NULL,
  `category` varchar(20) NOT NULL,
  `description` varchar(200) NOT NULL,
  `price` int(11) NOT NULL,
  `image` varchar(100) NOT NULL,
  `username` varchar(25) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=52 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `id` int(20) NOT NULL,
  `username` varchar(25) NOT NULL,
  `email` varchar(40) NOT NULL,
  `password` varchar(30) NOT NULL,
  `address1` varchar(30) NOT NULL,
  `address2` varchar(30) NOT NULL,
  `town` varchar(30) NOT NULL,
  `county` varchar(30) NOT NULL,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=MyISAM AUTO_INCREMENT=26 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `email`, `password`, `address1`, `address2`, `town`, `county`, `date`) VALUES
(1, 'Admin', 'admin@gmail.com', '6bA8rypUEbjhs', 'Admins House', 'Admins Road', 'Admins Town', 'Admins County', '2015-08-11 03:10:26'),
(24, 'User', 'user@gmail.com', '6bA8rypUEbjhs', 'User Town', 'User Street', 'User Town', 'User County', '2015-08-11 01:34:42');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `auctions`
--
ALTER TABLE `auctions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `userID` (`username`),
  ADD KEY `userID_2` (`username`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `auctions`
--
ALTER TABLE `auctions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=52;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=26;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
