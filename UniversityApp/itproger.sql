-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Mar 03, 2023 at 09:30 PM
-- Server version: 5.7.24
-- PHP Version: 8.0.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `itproger`
--

-- --------------------------------------------------------

--
-- Table structure for table `faculties`
--

CREATE TABLE `faculties` (
  `id` int(3) UNSIGNED NOT NULL,
  `name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `faculties`
--

INSERT INTO `faculties` (`id`, `name`) VALUES
(1, 'Факультет автомобильного транспорта'),
(3, 'Факультет экономики и управления'),
(2, 'Факультет электроники и вычислительной техники');

-- --------------------------------------------------------

--
-- Table structure for table `faculties_groups`
--

CREATE TABLE `faculties_groups` (
  `id` int(6) UNSIGNED NOT NULL,
  `num_faculty` int(3) UNSIGNED NOT NULL,
  `num_group` int(4) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `faculties_groups`
--

INSERT INTO `faculties_groups` (`id`, `num_faculty`, `num_group`) VALUES
(1, 1, 3),
(2, 1, 4),
(3, 2, 1),
(4, 2, 2),
(10, 3, 5),
(7, 3, 6),
(20, 3, 7),
(19, 3, 8);

-- --------------------------------------------------------

--
-- Table structure for table `groups`
--

CREATE TABLE `groups` (
  `id` int(4) UNSIGNED NOT NULL,
  `name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `groups`
--

INSERT INTO `groups` (`id`, `name`) VALUES
(3, 'АП-20'),
(4, 'АПЗ-20'),
(15, 'АУ-22'),
(12, 'АУЗ-22'),
(1, 'ВМ-20'),
(2, 'ВМЗ-20'),
(7, 'Г-20'),
(8, 'ГЗ-20'),
(5, 'ЭУ-20'),
(6, 'ЭУЗ-20');

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `id` int(11) UNSIGNED NOT NULL,
  `student_number` int(8) UNSIGNED NOT NULL COMMENT 'Номер зачетной книжки',
  `name` varchar(100) NOT NULL,
  `surname` varchar(100) NOT NULL,
  `num_faculty` int(3) UNSIGNED NOT NULL,
  `num_group` int(4) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`id`, `student_number`, `name`, `surname`, `num_faculty`, `num_group`) VALUES
(1, 20114115, 'Владимир', 'Андреев', 2, 1),
(3, 20114116, 'Bob', 'Marley', 1, 4),
(6, 20114117, 'Sergey', 'Tyulenev', 2, 2),
(11, 20114118, 'John', 'Connor', 2, 2),
(22, 20114123, 'Vova', 'Avdeev', 1, 4),
(28, 20114125, 'Olga', 'Semiglazova', 1, 4),
(31, 20114135, 'Sergey', 'Tyulenev', 2, 1),
(32, 20114136, 'Ксения', 'Сергеева', 3, 6),
(34, 20114138, 'Sonya', 'Andreeva', 3, 8);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) UNSIGNED NOT NULL,
  `login` varchar(100) NOT NULL,
  `password` varchar(32) NOT NULL,
  `name` varchar(100) NOT NULL,
  `surname` varchar(100) NOT NULL,
  `super_admin` varchar(1) NOT NULL,
  `access_user` varchar(4) NOT NULL,
  `access_student` varchar(4) NOT NULL,
  `access_faculties_groups` varchar(4) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `login`, `password`, `name`, `surname`, `super_admin`, `access_user`, `access_student`, `access_faculties_groups`) VALUES
(1, 'admin', '12345', 'Vladimir', 'Andreev', '1', '1111', '1111', '1111'),
(4, 'sergey_tyulenev', '12345', 'Sergey', 'Tyulenev', '0', '1000', '1000', '1000'),
(16, 'bubba', '12345', 'Bubbus', 'Noobus', '0', '1000', '1000', '1000'),
(8, 'admin1', '12345', 'adm', 'adm', '0', '1000', '0000', '0000'),
(12, 'bob', '12345', 'Bob', 'Marley', '0', '1000', '1001', '0000'),
(14, 'admin123', '12345', 'Vladimir', 'Avdeev', '0', '0100', '1000', '1111'),
(15, 'admin2', '12345A', 'Olga', 'Buzova', '0', '1000', '1100', '1111'),
(17, 'noobba', '12345', 'Noobba', 'Bubba', '0', '1000', '1000', '1000'),
(19, 'admin_f', '12345', 'Foma', 'Fomin', '0', '1111', '1111', '1111');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `faculties`
--
ALTER TABLE `faculties`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD UNIQUE KEY `faculty` (`name`);

--
-- Indexes for table `faculties_groups`
--
ALTER TABLE `faculties_groups`
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `num_faculty` (`num_faculty`,`num_group`),
  ADD KEY `table_id_groups` (`num_group`);

--
-- Indexes for table `groups`
--
ALTER TABLE `groups`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD UNIQUE KEY `group_name` (`name`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD UNIQUE KEY `id` (`id`),
  ADD UNIQUE KEY `student_number` (`student_number`),
  ADD KEY `num_faculty` (`num_faculty`),
  ADD KEY `num_group` (`num_group`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD UNIQUE KEY `id` (`id`),
  ADD UNIQUE KEY `login` (`login`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `faculties`
--
ALTER TABLE `faculties`
  MODIFY `id` int(3) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `faculties_groups`
--
ALTER TABLE `faculties_groups`
  MODIFY `id` int(6) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `groups`
--
ALTER TABLE `groups`
  MODIFY `id` int(4) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `students`
--
ALTER TABLE `students`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `faculties_groups`
--
ALTER TABLE `faculties_groups`
  ADD CONSTRAINT `table_id_faculties` FOREIGN KEY (`num_faculty`) REFERENCES `faculties` (`id`),
  ADD CONSTRAINT `table_id_groups` FOREIGN KEY (`num_group`) REFERENCES `groups` (`id`);

--
-- Constraints for table `students`
--
ALTER TABLE `students`
  ADD CONSTRAINT `id_faculties` FOREIGN KEY (`num_faculty`) REFERENCES `faculties` (`id`),
  ADD CONSTRAINT `id_groups` FOREIGN KEY (`num_group`) REFERENCES `groups` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
