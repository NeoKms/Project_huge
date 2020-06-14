-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Хост: localhost
-- Время создания: Июн 14 2020 г., 17:16
-- Версия сервера: 5.7.24-log
-- Версия PHP: 7.2.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `project_1`
--

-- --------------------------------------------------------

--
-- Структура таблицы `components`
--

CREATE TABLE `components` (
  `ID_item` int(11) NOT NULL,
  `ID_item_comp` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Структура таблицы `com_manufacturing_workers`
--

CREATE TABLE `com_manufacturing_workers` (
  `type_equipment` varchar(20) CHARACTER SET utf8 NOT NULL,
  `ID_factory` int(11) NOT NULL,
  `ID_worker` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Структура таблицы `com_stock_suppliers`
--

CREATE TABLE `com_stock_suppliers` (
  `the_cost` int(11) DEFAULT NULL,
  `time_delivery` int(11) DEFAULT NULL,
  `ID_item` int(11) NOT NULL,
  `ID_supplier` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `com_stock_suppliers`
--

INSERT INTO `com_stock_suppliers` (`the_cost`, `time_delivery`, `ID_item`, `ID_supplier`) VALUES
(1200, 1, 1, 1),
(464, 2, 1, 2),
(6347, 1, 2, 1),
(53, 2, 2, 2),
(324, 1, 3, 1),
(532456, 100, 6, 4),
(876543, 100, 7, 4),
(66466, 100, 8, 4),
(45674, 99, 9, 4),
(3234645, 100, 10, 4),
(256453, 100, 11, 4),
(4563, 30, 12, 1),
(45, 28, 13, 1),
(63456677, 25, 14, 3),
(6866, 26, 15, 1),
(78789, 22, 16, 3),
(789, 120, 17, 4),
(78976, 120, 18, 4),
(6456, 120, 19, 4),
(3456, 120, 20, 4),
(3456, 120, 21, 4),
(345, 120, 22, 4),
(65466, 80, 23, 4),
(786, 80, 24, 4),
(7556736, 80, 25, 4),
(456, 80, 26, 4),
(76689, 80, 27, 4),
(877, 80, 28, 4),
(9876, 40, 29, 4),
(323456, 44, 30, 4),
(7654323, 43, 31, 4),
(34684, 44, 32, 4),
(34569, 49, 33, 4),
(2349876, 49, 34, 4),
(2376, 14, 35, 1),
(348, 13, 36, 3),
(98765, 1, 37, 1),
(345765, 2, 38, 2),
(2345, 1, 39, 1),
(76542345, 3, 40, 3),
(7653456, 2, 41, 2),
(3456, 3, 41, 3),
(1234, 4, 41, 4),
(432, 2, 42, 2),
(765345, 3, 42, 3),
(654, 4, 42, 4),
(76545, 1, 43, 1),
(76, 1, 44, 1),
(8709, 2, 45, 2),
(87876, 3, 46, 3),
(654, 1, 47, 1),
(54, 2, 48, 2),
(65, 3, 49, 3),
(87, 1, 50, 1),
(69, 2, 51, 2),
(8776, 3, 52, 3),
(56, 4, 53, 4),
(545, 4, 54, 4),
(43, 2, 55, 2),
(54334, 2, 56, 2),
(568, 3, 57, 3),
(7654, 1, 58, 1),
(3458, 3, 59, 3),
(76543, 4, 60, 4),
(458, 4, 61, 4),
(7654, 4, 62, 4),
(56, 4, 63, 4),
(7654, 1, 64, 1),
(5687, 1, 64, 2),
(654, 1, 64, 3),
(58, 1, 65, 1),
(763, 1, 65, 2),
(457, 1, 65, 3),
(6534, 1, 66, 1),
(576, 1, 66, 2),
(545, 1, 66, 3),
(687, 1, 67, 1),
(654, 1, 67, 2),
(57, 1, 67, 3),
(55, 2, 68, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `equipment`
--

CREATE TABLE `equipment` (
  `type_equipment` varchar(20) CHARACTER SET utf8 NOT NULL,
  `ID_factory` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Структура таблицы `factories`
--

CREATE TABLE `factories` (
  `ID_factory` int(11) NOT NULL,
  `date_create` datetime DEFAULT NULL,
  `name` varchar(40) CHARACTER SET utf8 DEFAULT NULL,
  `president_name` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `president_secons_name` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `col_workers` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `factories`
--

INSERT INTO `factories` (`ID_factory`, `date_create`, `name`, `president_name`, `president_secons_name`, `col_workers`) VALUES
(0, '2018-12-16 12:45:11', 'Admin', 'Vlad', 'Zhiguslkiy', 0),
(1, '2019-01-15 03:54:39', 'VladZavod', 'Vladislav', 'Zhigulskiy', 68),
(2, '2019-01-15 13:08:26', 'gg', 'g', 'gg', 77),
(3, '0000-00-00 00:00:00', 'empty', 'empty', 'empty', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `login`
--

CREATE TABLE `login` (
  `password` varchar(20) CHARACTER SET utf8 NOT NULL,
  `login` varchar(20) CHARACTER SET utf8 NOT NULL,
  `ID_worker` int(11) NOT NULL,
  `ID_factory` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `login`
--

INSERT INTO `login` (`password`, `login`, `ID_worker`, `ID_factory`) VALUES
('root', 'Admin', 1, 0),
('mnischenko', 'вячеслав', 2, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `logs`
--

CREATE TABLE `logs` (
  `time_when` datetime NOT NULL,
  `ID_worker` int(11) NOT NULL,
  `ID_factory` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `logs`
--

INSERT INTO `logs` (`time_when`, `ID_worker`, `ID_factory`) VALUES
('2018-12-17 22:43:20', 1, 0),
('2018-12-17 23:09:06', 1, 0),
('2018-12-17 23:15:15', 1, 0),
('2018-12-18 12:32:35', 1, 0),
('2018-12-18 12:34:01', 1, 0),
('2018-12-18 12:40:56', 1, 0),
('2018-12-18 12:47:20', 1, 0),
('2018-12-18 15:28:54', 1, 0),
('2018-12-18 15:29:51', 1, 0),
('2018-12-18 15:32:29', 1, 0),
('2018-12-18 15:58:44', 1, 0),
('2018-12-18 15:59:27', 1, 0),
('2018-12-18 17:02:28', 1, 0),
('2018-12-18 17:12:12', 1, 0),
('2018-12-18 17:13:39', 1, 0),
('2018-12-18 17:14:36', 1, 0),
('2018-12-18 17:15:28', 1, 0),
('2018-12-18 17:18:40', 1, 0),
('2018-12-18 17:22:20', 1, 0),
('2018-12-18 17:24:41', 1, 0),
('2018-12-18 17:26:04', 1, 0),
('2018-12-18 18:16:38', 1, 0),
('2018-12-18 18:17:46', 1, 0),
('2018-12-18 18:18:50', 1, 0),
('2018-12-20 17:12:40', 1, 0),
('2018-12-20 18:02:15', 1, 0),
('2019-01-09 00:08:35', 1, 0),
('2019-01-09 00:09:18', 1, 0),
('2019-01-09 00:10:23', 1, 0),
('2019-01-09 00:22:42', 1, 0),
('2019-01-09 00:25:16', 1, 0),
('2019-01-09 00:25:48', 1, 0),
('2019-01-09 00:27:07', 1, 0),
('2019-01-09 00:32:02', 1, 0),
('2019-01-09 00:32:47', 1, 0),
('2019-01-09 00:37:06', 1, 0),
('2019-01-09 00:37:09', 1, 0),
('2019-01-09 00:37:14', 1, 0),
('2019-01-09 00:37:16', 1, 0),
('2019-01-09 00:40:19', 1, 0),
('2019-01-09 00:40:44', 1, 0),
('2019-01-09 00:40:53', 1, 0),
('2019-01-09 00:41:06', 1, 0),
('2019-01-09 00:52:33', 1, 0),
('2019-01-09 00:54:35', 1, 0),
('2019-01-09 00:54:56', 1, 0),
('2019-01-09 00:59:21', 1, 0),
('2019-01-09 00:59:59', 1, 0),
('2019-01-09 01:01:21', 1, 0),
('2019-01-09 01:02:46', 1, 0),
('2019-01-11 11:56:37', 1, 0),
('2019-01-12 22:24:34', 1, 0),
('2019-01-12 22:31:24', 1, 0),
('2019-01-12 22:45:00', 1, 0),
('2019-01-12 22:45:27', 1, 0),
('2019-01-12 22:45:42', 1, 0),
('2019-01-12 22:52:47', 1, 0),
('2019-01-12 22:53:33', 1, 0),
('2019-01-12 22:54:05', 1, 0),
('2019-01-12 22:55:00', 1, 0),
('2019-01-12 22:55:16', 1, 0),
('2019-01-12 22:56:21', 1, 0),
('2019-01-12 22:57:38', 1, 0),
('2019-01-12 22:59:14', 1, 0),
('2019-01-12 23:00:29', 1, 0),
('2019-01-12 23:01:13', 1, 0),
('2019-01-12 23:01:59', 1, 0),
('2019-01-12 23:02:15', 1, 0),
('2019-01-12 23:02:33', 1, 0),
('2019-01-12 23:02:52', 1, 0),
('2019-01-12 23:03:18', 1, 0),
('2019-01-12 23:04:31', 1, 0),
('2019-01-12 23:04:45', 1, 0),
('2019-01-12 23:06:08', 1, 0),
('2019-01-12 23:06:42', 1, 0),
('2019-01-12 23:07:15', 1, 0),
('2019-01-12 23:07:24', 1, 0),
('2019-01-12 23:11:37', 1, 0),
('2019-01-12 23:12:43', 1, 0),
('2019-01-12 23:12:59', 1, 0),
('2019-01-12 23:13:12', 1, 0),
('2019-01-12 23:13:30', 1, 0),
('2019-01-12 23:14:14', 1, 0),
('2019-01-12 23:16:23', 1, 0),
('2019-01-12 23:16:51', 1, 0),
('2019-01-12 23:17:03', 1, 0),
('2019-01-12 23:17:14', 1, 0),
('2019-01-12 23:17:23', 1, 0),
('2019-01-12 23:17:29', 1, 0),
('2019-01-12 23:17:38', 1, 0),
('2019-01-12 23:17:45', 1, 0),
('2019-01-12 23:18:20', 1, 0),
('2019-01-12 23:18:34', 1, 0),
('2019-01-12 23:18:46', 1, 0),
('2019-01-12 23:18:55', 1, 0),
('2019-01-12 23:19:58', 1, 0),
('2019-01-12 23:20:07', 1, 0),
('2019-01-12 23:20:39', 1, 0),
('2019-01-12 23:21:43', 1, 0),
('2019-01-12 23:24:11', 1, 0),
('2019-01-12 23:35:16', 1, 0),
('2019-01-12 23:36:52', 1, 0),
('2019-01-12 23:38:08', 1, 0),
('2019-01-12 23:38:46', 1, 0),
('2019-01-12 23:39:17', 1, 0),
('2019-01-12 23:39:36', 1, 0),
('2019-01-12 23:39:45', 1, 0),
('2019-01-12 23:42:12', 1, 0),
('2019-01-12 23:42:44', 1, 0),
('2019-01-12 23:43:41', 1, 0),
('2019-01-12 23:44:21', 1, 0),
('2019-01-12 23:47:49', 1, 0),
('2019-01-12 23:49:49', 1, 0),
('2019-01-12 23:50:58', 1, 0),
('2019-01-12 23:53:24', 1, 0),
('2019-01-12 23:55:03', 1, 0),
('2019-01-13 12:07:36', 1, 0),
('2019-01-13 12:09:38', 1, 0),
('2019-01-13 12:13:01', 1, 0),
('2019-01-13 12:37:10', 1, 0),
('2019-01-13 12:37:38', 1, 0),
('2019-01-13 12:37:59', 1, 0),
('2019-01-13 12:53:31', 1, 0),
('2019-01-13 12:55:57', 1, 0),
('2019-01-13 12:56:52', 1, 0),
('2019-01-13 12:58:28', 1, 0),
('2019-01-13 13:01:23', 1, 0),
('2019-01-13 13:02:09', 1, 0),
('2019-01-13 13:03:41', 1, 0),
('2019-01-13 13:04:55', 1, 0),
('2019-01-13 13:05:24', 1, 0),
('2019-01-13 13:05:43', 1, 0),
('2019-01-13 13:06:48', 1, 0),
('2019-01-13 13:07:05', 1, 0),
('2019-01-13 13:07:31', 1, 0),
('2019-01-13 13:12:50', 1, 0),
('2019-01-13 13:19:54', 1, 0),
('2019-01-13 13:20:48', 1, 0),
('2019-01-13 13:21:07', 1, 0),
('2019-01-13 13:22:17', 1, 0),
('2019-01-13 13:22:33', 1, 0),
('2019-01-13 13:22:53', 1, 0),
('2019-01-13 13:23:36', 1, 0),
('2019-01-13 13:25:01', 1, 0),
('2019-01-13 13:25:33', 1, 0),
('2019-01-13 13:26:38', 1, 0),
('2019-01-13 13:27:12', 1, 0),
('2019-01-13 13:28:44', 1, 0),
('2019-01-13 13:30:55', 1, 0),
('2019-01-13 13:32:18', 1, 0),
('2019-01-13 13:33:00', 1, 0),
('2019-01-13 13:33:31', 1, 0),
('2019-01-13 13:34:06', 1, 0),
('2019-01-13 13:38:43', 1, 0),
('2019-01-13 13:38:58', 1, 0),
('2019-01-13 13:39:10', 1, 0),
('2019-01-13 13:39:59', 1, 0),
('2019-01-13 13:40:45', 1, 0),
('2019-01-13 13:41:00', 1, 0),
('2019-01-13 13:42:25', 1, 0),
('2019-01-13 13:43:04', 1, 0),
('2019-01-13 13:43:39', 1, 0),
('2019-01-13 13:43:55', 1, 0),
('2019-01-13 13:44:10', 1, 0),
('2019-01-13 13:44:26', 1, 0),
('2019-01-13 13:44:45', 1, 0),
('2019-01-13 13:45:28', 1, 0),
('2019-01-13 13:45:48', 1, 0),
('2019-01-13 13:46:16', 1, 0),
('2019-01-13 13:56:34', 1, 0),
('2019-01-13 14:03:03', 1, 0),
('2019-01-13 14:07:02', 1, 0),
('2019-01-13 14:07:16', 1, 0),
('2019-01-13 14:08:30', 1, 0),
('2019-01-13 14:08:53', 1, 0),
('2019-01-13 14:10:56', 1, 0),
('2019-01-13 14:16:45', 1, 0),
('2019-01-13 14:17:58', 1, 0),
('2019-01-13 15:15:55', 1, 0),
('2019-01-13 15:38:36', 1, 0),
('2019-01-13 15:39:26', 1, 0),
('2019-01-13 15:40:42', 1, 0),
('2019-01-13 15:40:55', 1, 0),
('2019-01-13 15:41:14', 1, 0),
('2019-01-13 15:41:35', 1, 0),
('2019-01-13 15:42:05', 1, 0),
('2019-01-13 15:42:20', 1, 0),
('2019-01-13 15:44:17', 1, 0),
('2019-01-13 15:44:36', 1, 0),
('2019-01-13 15:44:54', 1, 0),
('2019-01-13 15:46:28', 1, 0),
('2019-01-13 15:47:43', 1, 0),
('2019-01-13 15:48:40', 1, 0),
('2019-01-13 15:50:37', 1, 0),
('2019-01-13 15:57:12', 1, 0),
('2019-01-13 15:57:48', 1, 0),
('2019-01-13 16:11:28', 1, 0),
('2019-01-13 16:13:00', 1, 0),
('2019-01-13 16:14:02', 1, 0),
('2019-01-13 22:37:53', 1, 0),
('2019-01-13 22:41:12', 1, 0),
('2019-01-13 22:41:47', 1, 0),
('2019-01-14 12:32:22', 1, 0),
('2019-01-14 13:56:31', 1, 0),
('2019-01-14 14:33:54', 1, 0),
('2019-01-14 14:56:11', 1, 0),
('2019-01-14 15:08:50', 1, 0),
('2019-01-14 15:16:44', 1, 0),
('2019-01-14 15:19:18', 1, 0),
('2019-01-14 15:21:49', 1, 0),
('2019-01-14 15:28:34', 1, 0),
('2019-01-14 15:29:05', 1, 0),
('2019-01-14 15:32:40', 1, 0),
('2019-01-14 15:34:09', 1, 0),
('2019-01-14 15:36:05', 1, 0),
('2019-01-14 15:39:16', 1, 0),
('2019-01-14 15:41:38', 1, 0),
('2019-01-14 15:41:58', 1, 0),
('2019-01-14 15:42:41', 1, 0),
('2019-01-14 15:44:33', 1, 0),
('2019-01-14 17:04:48', 1, 0),
('2019-01-14 17:06:31', 1, 0),
('2019-01-14 17:07:22', 1, 0),
('2019-01-14 17:12:01', 1, 0),
('2019-01-14 17:12:27', 1, 0),
('2019-01-14 17:14:26', 1, 0),
('2019-01-14 17:15:38', 1, 0),
('2019-01-14 17:34:58', 1, 0),
('2019-01-14 17:35:46', 1, 0),
('2019-01-14 17:44:39', 1, 0),
('2019-01-14 20:01:41', 1, 0),
('2019-01-14 20:03:05', 1, 0),
('2019-01-14 20:03:35', 1, 0),
('2019-01-14 20:04:10', 1, 0),
('2019-01-14 20:06:36', 1, 0),
('2019-01-14 20:06:54', 1, 0),
('2019-01-14 20:07:55', 1, 0),
('2019-01-14 20:08:24', 1, 0),
('2019-01-14 20:10:48', 1, 0),
('2019-01-14 20:36:51', 1, 0),
('2019-01-14 21:17:08', 1, 0),
('2019-01-14 21:20:53', 1, 0),
('2019-01-14 21:22:10', 1, 0),
('2019-01-14 21:23:21', 1, 0),
('2019-01-14 21:42:55', 1, 0),
('2019-01-14 22:04:49', 1, 0),
('2019-01-14 22:09:59', 1, 0),
('2019-01-14 22:11:09', 1, 0),
('2019-01-14 22:11:30', 1, 0),
('2019-01-14 22:12:53', 1, 0),
('2019-01-14 22:14:07', 1, 0),
('2019-01-14 22:14:48', 1, 0),
('2019-01-14 22:19:02', 1, 0),
('2019-01-14 22:21:51', 1, 0),
('2019-01-14 22:24:18', 1, 0),
('2019-01-14 22:27:37', 1, 0),
('2019-01-14 22:28:33', 1, 0),
('2019-01-14 22:29:37', 1, 0),
('2019-01-14 22:35:11', 1, 0),
('2019-01-14 22:37:25', 1, 0),
('2019-01-14 22:38:40', 1, 0),
('2019-01-14 22:39:10', 1, 0),
('2019-01-14 22:39:38', 1, 0),
('2019-01-14 22:41:24', 1, 0),
('2019-01-14 22:43:36', 1, 0),
('2019-01-14 22:43:55', 1, 0),
('2019-01-14 22:50:10', 1, 0),
('2019-01-14 22:51:43', 1, 0),
('2019-01-14 22:52:12', 1, 0),
('2019-01-14 22:52:53', 1, 0),
('2019-01-14 22:53:24', 1, 0),
('2019-01-14 22:54:05', 1, 0),
('2019-01-14 22:54:47', 1, 0),
('2019-01-14 22:55:50', 1, 0),
('2019-01-14 22:59:04', 1, 0),
('2019-01-14 22:59:33', 1, 0),
('2019-01-14 23:00:14', 1, 0),
('2019-01-14 23:01:39', 1, 0),
('2019-01-14 23:02:10', 1, 0),
('2019-01-14 23:02:30', 1, 0),
('2019-01-14 23:03:14', 1, 0),
('2019-01-14 23:03:41', 1, 0),
('2019-01-14 23:04:01', 1, 0),
('2019-01-14 23:07:12', 1, 0),
('2019-01-14 23:07:55', 1, 0),
('2019-01-14 23:08:53', 1, 0),
('2019-01-14 23:09:52', 1, 0),
('2019-01-14 23:10:32', 1, 0),
('2019-01-14 23:11:22', 1, 0),
('2019-01-14 23:12:16', 1, 0),
('2019-01-14 23:12:29', 1, 0),
('2019-01-14 23:13:07', 1, 0),
('2019-01-14 23:20:40', 1, 0),
('2019-01-14 23:21:14', 1, 0),
('2019-01-14 23:21:57', 1, 0),
('2019-01-14 23:22:20', 1, 0),
('2019-01-14 23:30:55', 1, 0),
('2019-01-14 23:34:48', 1, 0),
('2019-01-14 23:38:59', 1, 0),
('2019-01-14 23:47:51', 1, 0),
('2019-01-14 23:48:15', 1, 0),
('2019-01-14 23:55:54', 1, 0),
('2019-01-14 23:58:07', 1, 0),
('2019-01-15 00:05:39', 1, 0),
('2019-01-15 00:06:35', 1, 0),
('2019-01-15 00:07:23', 1, 0),
('2019-01-15 00:07:36', 1, 0),
('2019-01-15 00:13:54', 1, 0),
('2019-01-15 01:26:35', 1, 0),
('2019-01-15 01:29:50', 1, 0),
('2019-01-15 01:31:10', 1, 0),
('2019-01-15 01:34:22', 1, 0),
('2019-01-15 01:36:20', 1, 0),
('2019-01-15 01:36:41', 1, 0),
('2019-01-15 01:37:07', 1, 0),
('2019-01-15 01:42:19', 1, 0),
('2019-01-15 01:43:10', 1, 0),
('2019-01-15 01:43:28', 1, 0),
('2019-01-15 01:46:39', 1, 0),
('2019-01-15 01:47:55', 1, 0),
('2019-01-15 01:48:16', 1, 0),
('2019-01-15 01:48:25', 1, 0),
('2019-01-15 01:55:07', 1, 0),
('2019-01-15 02:14:14', 1, 0),
('2019-01-15 02:15:12', 1, 0),
('2019-01-15 02:20:37', 1, 0),
('2019-01-15 02:20:56', 1, 0),
('2019-01-15 02:26:08', 1, 0),
('2019-01-15 02:27:42', 1, 0),
('2019-01-15 03:04:39', 1, 0),
('2019-01-15 03:07:35', 1, 0),
('2019-01-15 03:09:14', 1, 0),
('2019-01-15 03:12:58', 1, 0),
('2019-01-15 03:15:39', 1, 0),
('2019-01-15 03:19:38', 1, 0),
('2019-01-15 03:25:20', 1, 0),
('2019-01-15 03:29:38', 1, 0),
('2019-01-15 03:33:35', 1, 0),
('2019-01-15 03:36:26', 1, 0),
('2019-01-15 03:38:15', 1, 0),
('2019-01-15 03:39:25', 1, 0),
('2019-01-15 03:40:37', 1, 0),
('2019-01-15 03:48:04', 1, 0),
('2019-01-15 03:54:06', 1, 0),
('2019-01-15 04:15:09', 1, 0),
('2019-01-15 04:21:01', 1, 0),
('2019-01-15 04:22:06', 1, 0),
('2019-01-15 04:22:33', 1, 0),
('2019-01-15 04:24:03', 1, 0),
('2019-01-15 04:25:41', 1, 0),
('2019-01-15 04:26:44', 1, 0),
('2019-01-15 04:30:52', 1, 0),
('2019-01-15 04:36:39', 1, 0),
('2019-01-15 04:54:28', 1, 0),
('2019-01-15 04:54:40', 1, 0),
('2019-01-15 04:59:17', 1, 0),
('2019-01-15 05:04:45', 1, 0),
('2019-01-15 05:12:39', 1, 0),
('2019-01-15 05:23:03', 1, 0),
('2019-01-15 05:46:30', 1, 0),
('2019-01-15 05:46:49', 1, 0),
('2019-01-15 05:49:25', 1, 0),
('2019-01-15 13:07:57', 1, 0),
('2019-01-15 13:08:33', 1, 0),
('2019-03-13 20:06:59', 1, 0),
('2019-04-11 23:05:22', 1, 0),
('2019-04-11 23:07:20', 1, 0),
('2019-04-12 23:05:57', 1, 0),
('2019-04-12 23:07:35', 1, 0),
('2019-04-12 23:09:43', 1, 0),
('2019-04-13 00:13:11', 1, 0),
('2019-04-13 02:07:22', 1, 0),
('2019-04-13 02:31:19', 1, 0),
('2019-04-13 02:42:23', 1, 0),
('2019-04-13 19:40:35', 1, 0),
('2019-04-13 21:35:51', 1, 0),
('2019-04-13 21:37:51', 1, 0),
('2019-04-13 21:41:09', 1, 0),
('2019-04-13 21:42:59', 1, 0),
('2019-04-13 22:03:48', 1, 0),
('2019-04-13 22:05:15', 1, 0),
('2019-04-13 22:06:26', 1, 0),
('2019-04-13 22:11:13', 1, 0),
('2019-04-14 02:29:00', 1, 0),
('2019-04-14 02:30:17', 1, 0),
('2019-04-14 02:31:40', 1, 0),
('2019-04-14 02:32:17', 1, 0),
('2019-04-23 23:46:49', 1, 0),
('2019-06-25 03:33:58', 1, 0),
('2019-06-25 03:34:35', 1, 0),
('2019-06-25 03:35:46', 1, 0),
('2019-06-25 03:36:47', 1, 0),
('2019-06-30 23:39:08', 1, 0),
('2019-06-30 23:49:10', 1, 0),
('2019-07-01 00:27:10', 1, 0),
('2019-07-01 02:23:52', 1, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `manufacturing`
--

CREATE TABLE `manufacturing` (
  `time_creating` int(11) DEFAULT NULL,
  `cost_creating` int(11) DEFAULT NULL,
  `ID_item` int(11) NOT NULL,
  `type_equipment` varchar(20) CHARACTER SET utf8 NOT NULL,
  `ID_factory` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Структура таблицы `operations`
--

CREATE TABLE `operations` (
  `num_operation` int(11) NOT NULL,
  `num_comp_operation` int(11) DEFAULT NULL,
  `ID_item` int(11) NOT NULL,
  `equipment` int(11) NOT NULL,
  `time_date` datetime NOT NULL,
  `ID_worker` int(11) NOT NULL,
  `ID_factory` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Структура таблицы `stock_in_factory`
--

CREATE TABLE `stock_in_factory` (
  `ID_item` int(11) NOT NULL,
  `col_item` int(11) DEFAULT NULL,
  `weigth` int(11) DEFAULT NULL,
  `heigth` int(11) DEFAULT NULL,
  `length` int(11) DEFAULT NULL,
  `width` int(11) DEFAULT NULL,
  `ID_factory` int(11) NOT NULL,
  `type_equipment` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=cp1251;

--
-- Дамп данных таблицы `stock_in_factory`
--

INSERT INTO `stock_in_factory` (`ID_item`, `col_item`, `weigth`, `heigth`, `length`, `width`, `ID_factory`, `type_equipment`) VALUES
(1, 0, 2, 1, 1, 1, 0, 'Type 1 steel sheet'),
(2, 0, 0, 0, 0, 0, 0, 'Type 2 steel sheet'),
(3, 0, 0, 0, 0, 0, 0, 'Type 3 steel sheet'),
(4, 0, 0, 0, 0, 0, 0, 'Buckler body'),
(5, 0, 0, 0, 0, 0, 0, 'Tanker hull'),
(6, 0, 0, 0, 0, 0, 0, 'Type 1 case package'),
(7, 0, 0, 0, 0, 0, 0, 'Type 2 case package'),
(8, 0, 0, 0, 0, 0, 0, 'Type 3 case package'),
(9, 0, 0, 0, 0, 0, 0, 'Type 4 case package'),
(10, 0, 0, 0, 0, 0, 0, 'Type 5 case package'),
(11, 0, 0, 0, 0, 0, 0, 'Type 6 case package'),
(12, 0, 0, 0, 0, 0, 0, 'Sheathing type 1'),
(13, 0, 0, 0, 0, 0, 0, 'Sheathing type 2'),
(14, 0, 0, 0, 0, 0, 0, 'Sheathing type 3'),
(15, 0, 0, 0, 0, 0, 0, 'Sheathing type 4'),
(16, 0, 0, 0, 0, 0, 0, 'Sheathing type 5'),
(17, 0, 0, 0, 0, 0, 0, 'Type 1 board kit'),
(18, 0, 0, 0, 0, 0, 0, 'Type 2 board kit'),
(19, 0, 0, 0, 0, 0, 0, 'Type 3 board kit'),
(20, 0, 0, 0, 0, 0, 0, 'Type 4 board kit'),
(21, 0, 0, 0, 0, 0, 0, 'Type 5 board kit'),
(22, 0, 0, 0, 0, 0, 0, 'Type 6 board kit'),
(23, 0, 0, 0, 0, 0, 0, 'Bottom kit type 1'),
(24, 0, 0, 0, 0, 0, 0, 'Bottom kit type 2'),
(25, 0, 0, 0, 0, 0, 0, 'Bottom kit type 3'),
(26, 0, 0, 0, 0, 0, 0, 'Bottom kit type 4'),
(27, 0, 0, 0, 0, 0, 0, 'Bottom kit type 5'),
(28, 0, 0, 0, 0, 0, 0, 'Bottom kit type 6'),
(29, 0, 0, 0, 0, 0, 0, 'Deck Kit Type 1'),
(30, 0, 0, 0, 0, 0, 0, 'Deck Kit Type 2'),
(31, 0, 0, 0, 0, 0, 0, 'Deck Kit Type 3'),
(32, 0, 0, 0, 0, 0, 0, 'Deck Kit Type 4'),
(33, 0, 0, 0, 0, 0, 0, 'Deck Kit Type 5'),
(34, 0, 0, 0, 0, 0, 0, 'Deck Kit Type 6'),
(35, 0, 0, 0, 0, 0, 0, 'Keel type 1'),
(36, 0, 0, 0, 0, 0, 0, 'Keel type 2'),
(37, 0, 0, 0, 0, 0, 0, 'Bulb type 1'),
(38, 0, 0, 0, 0, 0, 0, 'Polubims type 2'),
(39, 0, 0, 0, 0, 0, 0, 'Tie type 1'),
(40, 0, 0, 0, 0, 0, 0, 'Tie type 2'),
(41, 0, 0, 0, 0, 0, 0, 'Flor type 1'),
(42, 0, 0, 0, 0, 0, 0, 'Flor type 2'),
(43, 0, 0, 0, 0, 0, 0, 'Beams longitudinal type 1'),
(44, 0, 0, 0, 0, 0, 0, 'Beams longitudinal type 2'),
(45, 0, 0, 0, 0, 0, 0, 'Stinger Type 1'),
(46, 0, 0, 0, 0, 0, 0, 'Stinger Type 2'),
(47, 0, 0, 0, 0, 0, 0, 'Punching Type 1'),
(48, 0, 0, 0, 0, 0, 0, 'Punching Type 2'),
(49, 0, 0, 0, 0, 0, 0, 'Akhtershteven type 1'),
(50, 0, 0, 0, 0, 0, 0, 'Akhtershteven type 2'),
(51, 0, 0, 0, 0, 0, 0, 'Waterway Type 1'),
(52, 0, 0, 0, 0, 0, 0, 'Waterway Type 2'),
(53, 0, 0, 0, 0, 0, 0, 'Double bottom sheet type 1'),
(54, 0, 0, 0, 0, 0, 0, 'Double bottom sheet type 2'),
(55, 0, 0, 0, 0, 0, 0, 'Beams transverse type 1'),
(56, 0, 0, 0, 0, 0, 0, 'Beams transverse type 2'),
(57, 0, 0, 0, 0, 0, 0, 'Carlings type 1'),
(58, 0, 0, 0, 0, 0, 0, 'Polubims type 1'),
(59, 0, 0, 0, 0, 0, 0, 'Polubims type 2'),
(60, 0, 0, 0, 0, 0, 0, 'Side paneling type 1'),
(61, 0, 0, 0, 0, 0, 0, 'Side paneling type 2'),
(62, 0, 0, 0, 0, 0, 0, 'Side paneling type 3'),
(63, 0, 0, 0, 0, 0, 0, 'Side paneling type 4'),
(64, 0, 0, 0, 0, 0, 0, 'Bolt type 1'),
(65, 0, 0, 0, 0, 0, 0, 'Bolt type 2'),
(66, 0, 0, 0, 0, 0, 0, 'Nut type 1'),
(67, 0, 0, 0, 0, 0, 0, 'Nut type 2'),
(68, 0, 0, 0, 0, 0, 0, 'Nut type 3'),
(69, 20, 0, 0, 0, 0, 1, 'Type 1 steel sheet'),
(70, 20, 0, 0, 0, 0, 1, 'Type 2 steel sheet'),
(71, 20, 0, 0, 0, 0, 1, 'Type 3 steel sheet'),
(72, 20, 0, 0, 0, 0, 1, 'Type 1 case package'),
(73, 20, 0, 0, 0, 0, 1, 'Type 2 case package'),
(74, 20, 0, 0, 0, 0, 1, 'Type 3 case package'),
(75, 20, 0, 0, 0, 0, 1, 'Type 4 case package'),
(76, 20, 0, 0, 0, 0, 1, 'Type 5 case package'),
(77, 20, 0, 0, 0, 0, 1, 'Type 6 case package'),
(78, 20, 0, 0, 0, 0, 1, 'Sheathing type 1'),
(79, 20, 0, 0, 0, 0, 1, 'Sheathing type 2'),
(80, 20, 0, 0, 0, 0, 1, 'Sheathing type 3'),
(81, 20, 0, 0, 0, 0, 1, 'Sheathing type 4'),
(82, 20, 0, 0, 0, 0, 1, 'Sheathing type 5'),
(83, 20, 0, 0, 0, 0, 1, 'Type 1 board kit'),
(84, 20, 0, 0, 0, 0, 1, 'Type 2 board kit'),
(85, 20, 0, 0, 0, 0, 1, 'Type 3 board kit'),
(86, 20, 0, 0, 0, 0, 1, 'Type 4 board kit'),
(87, 20, 0, 0, 0, 0, 1, 'Type 5 board kit'),
(88, 20, 0, 0, 0, 0, 1, 'Type 6 board kit'),
(89, 20, 0, 0, 0, 0, 1, 'Bottom kit type 1'),
(90, 20, 0, 0, 0, 0, 1, 'Bottom kit type 2'),
(91, 20, 0, 0, 0, 0, 1, 'Bottom kit type 3'),
(92, 20, 0, 0, 0, 0, 1, 'Bottom kit type 4'),
(93, 20, 0, 0, 0, 0, 1, 'Bottom kit type 5'),
(94, 20, 0, 0, 0, 0, 1, 'Bottom kit type 6'),
(95, 20, 0, 0, 0, 0, 1, 'Deck Kit Type 1'),
(96, 20, 0, 0, 0, 0, 1, 'Deck Kit Type 2'),
(97, 20, 0, 0, 0, 0, 1, 'Deck Kit Type 3'),
(98, 20, 0, 0, 0, 0, 1, 'Deck Kit Type 4'),
(99, 20, 0, 0, 0, 0, 1, 'Deck Kit Type 5'),
(100, 20, 0, 0, 0, 0, 1, 'Deck Kit Type 6'),
(101, 20, 0, 0, 0, 0, 1, 'Keel type 1'),
(102, 20, 0, 0, 0, 0, 1, 'Keel type 2'),
(103, 20, 0, 0, 0, 0, 1, 'Bulb type 1'),
(104, 20, 0, 0, 0, 0, 1, 'Polubims type 2'),
(105, 20, 0, 0, 0, 0, 1, 'Tie type 1'),
(106, 20, 0, 0, 0, 0, 1, 'Tie type 2'),
(107, 20, 0, 0, 0, 0, 1, 'Flor type 1'),
(108, 20, 0, 0, 0, 0, 1, 'Flor type 2'),
(109, 20, 0, 0, 0, 0, 1, 'Beams longitudinal type 1'),
(110, 20, 0, 0, 0, 0, 1, 'Beams longitudinal type 2'),
(111, 20, 0, 0, 0, 0, 1, 'Stinger Type 1'),
(112, 20, 0, 0, 0, 0, 1, 'Stinger Type 2'),
(113, 20, 0, 0, 0, 0, 1, 'Punching Type 1'),
(114, 20, 0, 0, 0, 0, 1, 'Punching Type 2'),
(115, 20, 0, 0, 0, 0, 1, 'Akhtershteven type 1'),
(116, 20, 0, 0, 0, 0, 1, 'Akhtershteven type 2'),
(117, 20, 0, 0, 0, 0, 1, 'Waterway Type 1'),
(118, 20, 0, 0, 0, 0, 1, 'Waterway Type 2'),
(119, 20, 0, 0, 0, 0, 1, 'Double bottom sheet type 1'),
(120, 20, 0, 0, 0, 0, 1, 'Double bottom sheet type 2'),
(121, 20, 0, 0, 0, 0, 1, 'Beams transverse type 1'),
(122, 20, 0, 0, 0, 0, 1, 'Beams transverse type 2'),
(123, 20, 0, 0, 0, 0, 1, 'Carlings type 1'),
(124, 20, 0, 0, 0, 0, 1, 'Polubims type 1'),
(125, 20, 0, 0, 0, 0, 1, 'Polubims type 2'),
(126, 20, 0, 0, 0, 0, 1, 'Side paneling type 1'),
(127, 20, 0, 0, 0, 0, 1, 'Side paneling type 2'),
(128, 20, 0, 0, 0, 0, 1, 'Side paneling type 3'),
(129, 20, 0, 0, 0, 0, 1, 'Side paneling type 4'),
(130, 20, 0, 0, 0, 0, 1, 'Bolt type 1'),
(131, 20, 0, 0, 0, 0, 1, 'Bolt type 2'),
(132, 20, 0, 0, 0, 0, 1, 'Nut type 1'),
(133, 20, 0, 0, 0, 0, 1, 'Nut type 2'),
(134, 20, 0, 0, 0, 0, 1, 'Nut type 3'),
(135, 20, 0, 0, 0, 0, 2, 'Type 1 steel sheet'),
(136, 20, 0, 0, 0, 0, 2, 'Type 2 steel sheet'),
(137, 20, 0, 0, 0, 0, 2, 'Type 3 steel sheet'),
(138, 20, 0, 0, 0, 0, 2, 'Type 1 case package'),
(139, 20, 0, 0, 0, 0, 2, 'Type 2 case package'),
(140, 20, 0, 0, 0, 0, 2, 'Type 3 case package'),
(141, 20, 0, 0, 0, 0, 2, 'Type 4 case package'),
(142, 20, 0, 0, 0, 0, 2, 'Type 5 case package'),
(143, 20, 0, 0, 0, 0, 2, 'Type 6 case package'),
(144, 20, 0, 0, 0, 0, 2, 'Sheathing type 1'),
(145, 20, 0, 0, 0, 0, 2, 'Sheathing type 2'),
(146, 20, 0, 0, 0, 0, 2, 'Sheathing type 3'),
(147, 20, 0, 0, 0, 0, 2, 'Sheathing type 4'),
(148, 20, 0, 0, 0, 0, 2, 'Sheathing type 5'),
(149, 20, 0, 0, 0, 0, 2, 'Type 1 board kit'),
(150, 20, 0, 0, 0, 0, 2, 'Type 2 board kit'),
(151, 20, 0, 0, 0, 0, 2, 'Type 3 board kit'),
(152, 20, 0, 0, 0, 0, 2, 'Type 4 board kit'),
(153, 20, 0, 0, 0, 0, 2, 'Type 5 board kit'),
(154, 20, 0, 0, 0, 0, 2, 'Type 6 board kit'),
(155, 20, 0, 0, 0, 0, 2, 'Bottom kit type 1'),
(156, 20, 0, 0, 0, 0, 2, 'Bottom kit type 2'),
(157, 20, 0, 0, 0, 0, 2, 'Bottom kit type 3'),
(158, 20, 0, 0, 0, 0, 2, 'Bottom kit type 4'),
(159, 20, 0, 0, 0, 0, 2, 'Bottom kit type 5'),
(160, 20, 0, 0, 0, 0, 2, 'Bottom kit type 6'),
(161, 20, 0, 0, 0, 0, 2, 'Deck Kit Type 1'),
(162, 20, 0, 0, 0, 0, 2, 'Deck Kit Type 2'),
(163, 20, 0, 0, 0, 0, 2, 'Deck Kit Type 3'),
(164, 20, 0, 0, 0, 0, 2, 'Deck Kit Type 4'),
(165, 20, 0, 0, 0, 0, 2, 'Deck Kit Type 5'),
(166, 20, 0, 0, 0, 0, 2, 'Deck Kit Type 6'),
(167, 20, 0, 0, 0, 0, 2, 'Keel type 1'),
(168, 20, 0, 0, 0, 0, 2, 'Keel type 2'),
(169, 20, 0, 0, 0, 0, 2, 'Bulb type 1'),
(170, 20, 0, 0, 0, 0, 2, 'Polubims type 2'),
(171, 20, 0, 0, 0, 0, 2, 'Tie type 1'),
(172, 20, 0, 0, 0, 0, 2, 'Tie type 2'),
(173, 20, 0, 0, 0, 0, 2, 'Flor type 1'),
(174, 20, 0, 0, 0, 0, 2, 'Flor type 2'),
(175, 20, 0, 0, 0, 0, 2, 'Beams longitudinal type 1'),
(176, 20, 0, 0, 0, 0, 2, 'Beams longitudinal type 2'),
(177, 20, 0, 0, 0, 0, 2, 'Stinger Type 1'),
(178, 20, 0, 0, 0, 0, 2, 'Stinger Type 2'),
(179, 20, 0, 0, 0, 0, 2, 'Punching Type 1'),
(180, 20, 0, 0, 0, 0, 2, 'Punching Type 2'),
(181, 20, 0, 0, 0, 0, 2, 'Akhtershteven type 1'),
(182, 20, 0, 0, 0, 0, 2, 'Akhtershteven type 2'),
(183, 20, 0, 0, 0, 0, 2, 'Waterway Type 1'),
(184, 20, 0, 0, 0, 0, 2, 'Waterway Type 2'),
(185, 20, 0, 0, 0, 0, 2, 'Double bottom sheet type 1'),
(186, 20, 0, 0, 0, 0, 2, 'Double bottom sheet type 2'),
(187, 20, 0, 0, 0, 0, 2, 'Beams transverse type 1'),
(188, 20, 0, 0, 0, 0, 2, 'Beams transverse type 2'),
(189, 20, 0, 0, 0, 0, 2, 'Carlings type 1'),
(190, 20, 0, 0, 0, 0, 2, 'Polubims type 1'),
(191, 20, 0, 0, 0, 0, 2, 'Polubims type 2'),
(192, 20, 0, 0, 0, 0, 2, 'Side paneling type 1'),
(193, 20, 0, 0, 0, 0, 2, 'Side paneling type 2'),
(194, 20, 0, 0, 0, 0, 2, 'Side paneling type 3'),
(195, 20, 0, 0, 0, 0, 2, 'Side paneling type 4'),
(196, 20, 0, 0, 0, 0, 2, 'Bolt type 1'),
(197, 20, 0, 0, 0, 0, 2, 'Bolt type 2'),
(198, 20, 0, 0, 0, 0, 2, 'Nut type 1'),
(199, 20, 0, 0, 0, 0, 2, 'Nut type 2'),
(200, 20, 0, 0, 0, 0, 2, 'Nut type 3'),
(201, 0, 0, 0, 0, 0, 1, 'Type 1 steel sheet'),
(202, 0, 0, 0, 0, 0, 1, 'Type 2 steel sheet'),
(203, 0, 0, 0, 0, 0, 1, 'Type 3 steel sheet'),
(204, 0, 0, 0, 0, 0, 1, 'Type 1 case package'),
(205, 0, 0, 0, 0, 0, 1, 'Type 2 case package'),
(206, 0, 0, 0, 0, 0, 1, 'Type 3 case package'),
(207, 0, 0, 0, 0, 0, 1, 'Type 4 case package'),
(208, 0, 0, 0, 0, 0, 1, 'Type 5 case package'),
(209, 0, 0, 0, 0, 0, 1, 'Type 6 case package'),
(210, 0, 0, 0, 0, 0, 1, 'Sheathing type 1'),
(211, 0, 0, 0, 0, 0, 1, 'Sheathing type 2'),
(212, 0, 0, 0, 0, 0, 1, 'Sheathing type 3'),
(213, 0, 0, 0, 0, 0, 1, 'Sheathing type 4'),
(214, 0, 0, 0, 0, 0, 1, 'Sheathing type 5'),
(215, 0, 0, 0, 0, 0, 1, 'Type 1 board kit'),
(216, 0, 0, 0, 0, 0, 1, 'Type 2 board kit'),
(217, 0, 0, 0, 0, 0, 1, 'Type 3 board kit'),
(218, 0, 0, 0, 0, 0, 1, 'Type 4 board kit'),
(219, 0, 0, 0, 0, 0, 1, 'Type 5 board kit'),
(220, 0, 0, 0, 0, 0, 1, 'Type 6 board kit'),
(221, 0, 0, 0, 0, 0, 1, 'Bottom kit type 1'),
(222, 0, 0, 0, 0, 0, 1, 'Bottom kit type 2'),
(223, 0, 0, 0, 0, 0, 1, 'Bottom kit type 3'),
(224, 0, 0, 0, 0, 0, 1, 'Bottom kit type 4'),
(225, 0, 0, 0, 0, 0, 1, 'Bottom kit type 5'),
(226, 0, 0, 0, 0, 0, 1, 'Bottom kit type 6'),
(227, 0, 0, 0, 0, 0, 1, 'Deck Kit Type 1'),
(228, 0, 0, 0, 0, 0, 1, 'Deck Kit Type 2'),
(229, 0, 0, 0, 0, 0, 1, 'Deck Kit Type 3'),
(230, 0, 0, 0, 0, 0, 1, 'Deck Kit Type 4'),
(231, 0, 0, 0, 0, 0, 1, 'Deck Kit Type 5'),
(232, 0, 0, 0, 0, 0, 1, 'Deck Kit Type 6'),
(233, 0, 0, 0, 0, 0, 1, 'Keel type 1'),
(234, 0, 0, 0, 0, 0, 1, 'Keel type 2'),
(235, 0, 0, 0, 0, 0, 1, 'Bulb type 1'),
(236, 0, 0, 0, 0, 0, 1, 'Polubims type 2'),
(237, 0, 0, 0, 0, 0, 1, 'Tie type 1'),
(238, 0, 0, 0, 0, 0, 1, 'Tie type 2'),
(239, 0, 0, 0, 0, 0, 1, 'Flor type 1'),
(240, 0, 0, 0, 0, 0, 1, 'Flor type 2'),
(241, 0, 0, 0, 0, 0, 1, 'Beams longitudinal type 1'),
(242, 0, 0, 0, 0, 0, 1, 'Beams longitudinal type 2'),
(243, 0, 0, 0, 0, 0, 1, 'Stinger Type 1'),
(244, 0, 0, 0, 0, 0, 1, 'Stinger Type 2'),
(245, 0, 0, 0, 0, 0, 1, 'Punching Type 1'),
(246, 0, 0, 0, 0, 0, 1, 'Punching Type 2'),
(247, 0, 0, 0, 0, 0, 1, 'Akhtershteven type 1'),
(248, 0, 0, 0, 0, 0, 1, 'Akhtershteven type 2'),
(249, 0, 0, 0, 0, 0, 1, 'Waterway Type 1'),
(250, 0, 0, 0, 0, 0, 1, 'Waterway Type 2'),
(251, 0, 0, 0, 0, 0, 1, 'Double bottom sheet type 1'),
(252, 0, 0, 0, 0, 0, 1, 'Double bottom sheet type 2'),
(253, 0, 0, 0, 0, 0, 1, 'Beams transverse type 1'),
(254, 0, 0, 0, 0, 0, 1, 'Beams transverse type 2'),
(255, 0, 0, 0, 0, 0, 1, 'Carlings type 1'),
(256, 0, 0, 0, 0, 0, 1, 'Polubims type 1'),
(257, 0, 0, 0, 0, 0, 1, 'Polubims type 2'),
(258, 0, 0, 0, 0, 0, 1, 'Side paneling type 1'),
(259, 0, 0, 0, 0, 0, 1, 'Side paneling type 2'),
(260, 0, 0, 0, 0, 0, 1, 'Side paneling type 3'),
(261, 0, 0, 0, 0, 0, 1, 'Side paneling type 4'),
(262, 0, 0, 0, 0, 0, 1, 'Bolt type 1'),
(263, 0, 0, 0, 0, 0, 1, 'Bolt type 2'),
(264, 0, 0, 0, 0, 0, 1, 'Nut type 1'),
(265, 0, 0, 0, 0, 0, 1, 'Nut type 2'),
(266, 0, 0, 0, 0, 0, 1, 'Nut type 3');

-- --------------------------------------------------------

--
-- Структура таблицы `suppliers`
--

CREATE TABLE `suppliers` (
  `ID_supplier` int(11) NOT NULL,
  `name_supplier` varchar(40) CHARACTER SET utf8mb4 DEFAULT NULL,
  `organization` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  `city` varchar(30) CHARACTER SET utf8 DEFAULT NULL,
  `VAT` varchar(20) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `suppliers`
--

INSERT INTO `suppliers` (`ID_supplier`, `name_supplier`, `organization`, `city`, `VAT`) VALUES
(1, 'ЕКБ прок. завод', 'LLC Ekaterinburg rolling plant', 'Екатеринбург', 'Бывает'),
(2, 'Маг.мех. завод', 'LLC Magadan Mechanical Plant ', 'Магадан', 'Бывает'),
(3, 'Прив. сталелит. завод', 'LLC Volga Steel Plant ', 'Тольятти', 'Бывает'),
(4, 'Амурская верфь', 'JSC Amur shipyards', 'Амурск', 'Бывает');

-- --------------------------------------------------------

--
-- Структура таблицы `suppliers_in_factory`
--

CREATE TABLE `suppliers_in_factory` (
  `ID_factory` int(11) NOT NULL,
  `ID_item` int(11) NOT NULL,
  `ID_supplier` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `suppliers_in_factory`
--

INSERT INTO `suppliers_in_factory` (`ID_factory`, `ID_item`, `ID_supplier`) VALUES
(1, 1, 1),
(1, 2, 1),
(1, 3, 1),
(1, 6, 4),
(1, 7, 4),
(1, 8, 4),
(1, 9, 4),
(1, 10, 4),
(1, 11, 4),
(1, 12, 1),
(1, 13, 1),
(1, 14, 3),
(1, 15, 1),
(1, 16, 3),
(1, 17, 4),
(1, 18, 4),
(1, 19, 4),
(1, 20, 4),
(1, 21, 4),
(1, 22, 4),
(1, 23, 4),
(1, 24, 4),
(1, 25, 4),
(1, 26, 4),
(1, 27, 4),
(1, 28, 4),
(1, 29, 4),
(1, 30, 4),
(1, 31, 4),
(1, 32, 4),
(1, 33, 4),
(1, 34, 4),
(1, 35, 1),
(1, 36, 3),
(1, 37, 1),
(1, 38, 2),
(1, 39, 1),
(1, 40, 3),
(1, 41, 2),
(1, 42, 2),
(1, 43, 1),
(1, 44, 1),
(1, 45, 2),
(1, 46, 3),
(1, 47, 1),
(1, 48, 2),
(1, 49, 3),
(1, 50, 1),
(1, 51, 2),
(1, 52, 3),
(1, 53, 4),
(1, 54, 4),
(1, 55, 2),
(1, 56, 2),
(1, 57, 3),
(1, 58, 1),
(1, 59, 3),
(1, 60, 4),
(1, 61, 4),
(1, 62, 4),
(1, 63, 4),
(1, 64, 1),
(1, 65, 1),
(1, 66, 1),
(1, 67, 1),
(1, 68, 1),
(2, 1, 1),
(2, 2, 1),
(2, 3, 1),
(2, 6, 4),
(2, 7, 4),
(2, 8, 4),
(2, 9, 4),
(2, 10, 4),
(2, 11, 4),
(2, 12, 1),
(2, 13, 1),
(2, 14, 3),
(2, 15, 1),
(2, 16, 3),
(2, 17, 4),
(2, 18, 4),
(2, 19, 4),
(2, 20, 4),
(2, 21, 4),
(2, 22, 4),
(2, 23, 4),
(2, 24, 4),
(2, 25, 4),
(2, 26, 4),
(2, 27, 4),
(2, 28, 4),
(2, 29, 4),
(2, 30, 4),
(2, 31, 4),
(2, 32, 4),
(2, 33, 4),
(2, 34, 4),
(2, 35, 1),
(2, 36, 3),
(2, 37, 1),
(2, 38, 2),
(2, 39, 1),
(2, 40, 3),
(2, 41, 2),
(2, 42, 2),
(2, 43, 1),
(2, 44, 1),
(2, 45, 2),
(2, 46, 3),
(2, 47, 1),
(2, 48, 2),
(2, 49, 3),
(2, 50, 1),
(2, 51, 2),
(2, 52, 3),
(2, 53, 4),
(2, 54, 4),
(2, 55, 2),
(2, 56, 2),
(2, 57, 3),
(2, 58, 1),
(2, 59, 3),
(2, 60, 4),
(2, 61, 4),
(2, 62, 4),
(2, 63, 4),
(2, 64, 1),
(2, 65, 1),
(2, 66, 1),
(2, 67, 1),
(2, 68, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `workers`
--

CREATE TABLE `workers` (
  `ID_worker` int(11) NOT NULL,
  `name` varchar(40) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `second_name` varchar(40) CHARACTER SET utf8 DEFAULT NULL,
  `patronymic` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `address` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `city` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `position` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `hours_work` int(11) DEFAULT NULL,
  `ID_factory` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `workers`
--

INSERT INTO `workers` (`ID_worker`, `name`, `second_name`, `patronymic`, `age`, `address`, `city`, `position`, `hours_work`, `ID_factory`) VALUES
(1, 'Владислав', 'Жигульский', 'Президент', 22, 'ДВФУ', 'Владивосток', 'Президент', 8, 0),
(2, 'Вячеслав', 'Мнищенко', 'Администратор', 21, 'ДВФУ', 'Владивосток', 'Администратор', 8, 1);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `components`
--
ALTER TABLE `components`
  ADD PRIMARY KEY (`ID_item`,`ID_item_comp`),
  ADD UNIQUE KEY `XPKcomponents` (`ID_item`,`ID_item_comp`),
  ADD KEY `XIF1components` (`ID_item`),
  ADD KEY `XIF2components` (`ID_item_comp`);

--
-- Индексы таблицы `com_manufacturing_workers`
--
ALTER TABLE `com_manufacturing_workers`
  ADD PRIMARY KEY (`type_equipment`,`ID_factory`,`ID_worker`),
  ADD UNIQUE KEY `XPKcom_manufacturing_workers` (`type_equipment`,`ID_factory`,`ID_worker`),
  ADD KEY `XIF1com_manufacturing_workers` (`type_equipment`,`ID_factory`),
  ADD KEY `XIF2com_manufacturing_workers` (`ID_worker`,`ID_factory`);

--
-- Индексы таблицы `com_stock_suppliers`
--
ALTER TABLE `com_stock_suppliers`
  ADD PRIMARY KEY (`ID_item`,`ID_supplier`),
  ADD UNIQUE KEY `XPKcom_stock_suppliers` (`ID_item`,`ID_supplier`),
  ADD KEY `XIF2com_stock_suppliers` (`ID_item`),
  ADD KEY `XIF3com_stock_suppliers` (`ID_supplier`);

--
-- Индексы таблицы `equipment`
--
ALTER TABLE `equipment`
  ADD PRIMARY KEY (`type_equipment`,`ID_factory`),
  ADD UNIQUE KEY `XPKequipment` (`type_equipment`,`ID_factory`),
  ADD KEY `XIF1equipment` (`ID_factory`);

--
-- Индексы таблицы `factories`
--
ALTER TABLE `factories`
  ADD PRIMARY KEY (`ID_factory`),
  ADD UNIQUE KEY `XPKfactories` (`ID_factory`);

--
-- Индексы таблицы `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`password`,`login`,`ID_worker`,`ID_factory`),
  ADD UNIQUE KEY `XPKlogin` (`password`,`login`,`ID_worker`,`ID_factory`),
  ADD KEY `XIF1login` (`ID_worker`,`ID_factory`);

--
-- Индексы таблицы `logs`
--
ALTER TABLE `logs`
  ADD PRIMARY KEY (`time_when`,`ID_worker`,`ID_factory`),
  ADD UNIQUE KEY `XPKlogs` (`time_when`,`ID_worker`,`ID_factory`),
  ADD KEY `XIF1logs` (`ID_worker`,`ID_factory`);

--
-- Индексы таблицы `manufacturing`
--
ALTER TABLE `manufacturing`
  ADD PRIMARY KEY (`ID_item`,`type_equipment`,`ID_factory`),
  ADD UNIQUE KEY `XPKmanufacturing` (`ID_item`,`type_equipment`,`ID_factory`),
  ADD KEY `XIF1manufacturing` (`ID_item`),
  ADD KEY `XIF2manufacturing` (`type_equipment`,`ID_factory`);

--
-- Индексы таблицы `operations`
--
ALTER TABLE `operations`
  ADD PRIMARY KEY (`num_operation`,`ID_item`,`equipment`,`time_date`,`ID_worker`,`ID_factory`),
  ADD UNIQUE KEY `XPKoperations` (`num_operation`,`ID_item`,`equipment`,`time_date`,`ID_worker`,`ID_factory`),
  ADD KEY `XIF1operations` (`ID_item`),
  ADD KEY `XIF2operations` (`equipment`),
  ADD KEY `XIF3operations` (`num_comp_operation`,`ID_item`,`equipment`,`time_date`,`ID_worker`,`ID_factory`),
  ADD KEY `XIF4operations` (`ID_worker`,`ID_factory`);

--
-- Индексы таблицы `stock_in_factory`
--
ALTER TABLE `stock_in_factory`
  ADD PRIMARY KEY (`ID_item`),
  ADD UNIQUE KEY `id_UNIQUE` (`ID_item`),
  ADD UNIQUE KEY `XPKstock_in_factory` (`ID_item`),
  ADD KEY `XIF1stock_in_factory` (`ID_factory`),
  ADD KEY `XIF2stock_in_factory` (`type_equipment`,`ID_factory`);

--
-- Индексы таблицы `suppliers`
--
ALTER TABLE `suppliers`
  ADD PRIMARY KEY (`ID_supplier`),
  ADD UNIQUE KEY `XPKsuppliers` (`ID_supplier`);

--
-- Индексы таблицы `suppliers_in_factory`
--
ALTER TABLE `suppliers_in_factory`
  ADD PRIMARY KEY (`ID_factory`,`ID_item`,`ID_supplier`),
  ADD UNIQUE KEY `XPKsuppliers_in_factory` (`ID_factory`,`ID_item`,`ID_supplier`),
  ADD KEY `XIF1suppliers_in_factory` (`ID_factory`),
  ADD KEY `XIF2suppliers_in_factory` (`ID_item`,`ID_supplier`);

--
-- Индексы таблицы `workers`
--
ALTER TABLE `workers`
  ADD PRIMARY KEY (`ID_worker`,`ID_factory`),
  ADD UNIQUE KEY `XPKworkers` (`ID_worker`,`ID_factory`),
  ADD KEY `XIF1workers` (`ID_factory`);

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `components`
--
ALTER TABLE `components`
  ADD CONSTRAINT `components_ibfk_1` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `components_ibfk_10` FOREIGN KEY (`ID_item_comp`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `components_ibfk_2` FOREIGN KEY (`ID_item_comp`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `components_ibfk_3` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `components_ibfk_4` FOREIGN KEY (`ID_item_comp`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `components_ibfk_5` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `components_ibfk_6` FOREIGN KEY (`ID_item_comp`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `components_ibfk_7` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `components_ibfk_8` FOREIGN KEY (`ID_item_comp`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `components_ibfk_9` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`);

--
-- Ограничения внешнего ключа таблицы `com_manufacturing_workers`
--
ALTER TABLE `com_manufacturing_workers`
  ADD CONSTRAINT `com_manufacturing_workers_ibfk_10` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `com_manufacturing_workers_ibfk_2` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `com_manufacturing_workers_ibfk_3` FOREIGN KEY (`type_equipment`,`ID_factory`) REFERENCES `equipment` (`type_equipment`, `ID_factory`),
  ADD CONSTRAINT `com_manufacturing_workers_ibfk_4` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `com_manufacturing_workers_ibfk_5` FOREIGN KEY (`type_equipment`,`ID_factory`) REFERENCES `equipment` (`type_equipment`, `ID_factory`),
  ADD CONSTRAINT `com_manufacturing_workers_ibfk_6` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `com_manufacturing_workers_ibfk_7` FOREIGN KEY (`type_equipment`,`ID_factory`) REFERENCES `equipment` (`type_equipment`, `ID_factory`),
  ADD CONSTRAINT `com_manufacturing_workers_ibfk_8` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `com_manufacturing_workers_ibfk_9` FOREIGN KEY (`type_equipment`,`ID_factory`) REFERENCES `equipment` (`type_equipment`, `ID_factory`);

--
-- Ограничения внешнего ключа таблицы `com_stock_suppliers`
--
ALTER TABLE `com_stock_suppliers`
  ADD CONSTRAINT `com_stock_suppliers_ibfk_11` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `com_stock_suppliers_ibfk_12` FOREIGN KEY (`ID_supplier`) REFERENCES `suppliers` (`ID_supplier`),
  ADD CONSTRAINT `com_stock_suppliers_ibfk_14` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `com_stock_suppliers_ibfk_15` FOREIGN KEY (`ID_supplier`) REFERENCES `suppliers` (`ID_supplier`),
  ADD CONSTRAINT `com_stock_suppliers_ibfk_2` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `com_stock_suppliers_ibfk_3` FOREIGN KEY (`ID_supplier`) REFERENCES `suppliers` (`ID_supplier`),
  ADD CONSTRAINT `com_stock_suppliers_ibfk_5` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `com_stock_suppliers_ibfk_6` FOREIGN KEY (`ID_supplier`) REFERENCES `suppliers` (`ID_supplier`),
  ADD CONSTRAINT `com_stock_suppliers_ibfk_8` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `com_stock_suppliers_ibfk_9` FOREIGN KEY (`ID_supplier`) REFERENCES `suppliers` (`ID_supplier`);

--
-- Ограничения внешнего ключа таблицы `equipment`
--
ALTER TABLE `equipment`
  ADD CONSTRAINT `equipment_ibfk_1` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `equipment_ibfk_2` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `equipment_ibfk_3` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `equipment_ibfk_4` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `equipment_ibfk_5` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`);

--
-- Ограничения внешнего ключа таблицы `login`
--
ALTER TABLE `login`
  ADD CONSTRAINT `login_ibfk_1` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `login_ibfk_2` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `login_ibfk_3` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `login_ibfk_4` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `login_ibfk_5` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`);

--
-- Ограничения внешнего ключа таблицы `logs`
--
ALTER TABLE `logs`
  ADD CONSTRAINT `logs_ibfk_1` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `logs_ibfk_2` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `logs_ibfk_3` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `logs_ibfk_4` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `logs_ibfk_5` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`);

--
-- Ограничения внешнего ключа таблицы `manufacturing`
--
ALTER TABLE `manufacturing`
  ADD CONSTRAINT `manufacturing_ibfk_1` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `manufacturing_ibfk_2` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `manufacturing_ibfk_3` FOREIGN KEY (`type_equipment`,`ID_factory`) REFERENCES `equipment` (`type_equipment`, `ID_factory`),
  ADD CONSTRAINT `manufacturing_ibfk_4` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `manufacturing_ibfk_5` FOREIGN KEY (`type_equipment`,`ID_factory`) REFERENCES `equipment` (`type_equipment`, `ID_factory`),
  ADD CONSTRAINT `manufacturing_ibfk_6` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `manufacturing_ibfk_7` FOREIGN KEY (`type_equipment`,`ID_factory`) REFERENCES `equipment` (`type_equipment`, `ID_factory`),
  ADD CONSTRAINT `manufacturing_ibfk_8` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `manufacturing_ibfk_9` FOREIGN KEY (`type_equipment`,`ID_factory`) REFERENCES `equipment` (`type_equipment`, `ID_factory`);

--
-- Ограничения внешнего ключа таблицы `operations`
--
ALTER TABLE `operations`
  ADD CONSTRAINT `operations_ibfk_1` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `operations_ibfk_10` FOREIGN KEY (`equipment`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `operations_ibfk_11` FOREIGN KEY (`num_comp_operation`,`ID_item`,`equipment`,`time_date`,`ID_worker`,`ID_factory`) REFERENCES `operations` (`num_operation`, `ID_item`, `equipment`, `time_date`, `ID_worker`, `ID_factory`),
  ADD CONSTRAINT `operations_ibfk_12` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `operations_ibfk_13` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `operations_ibfk_14` FOREIGN KEY (`equipment`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `operations_ibfk_15` FOREIGN KEY (`num_comp_operation`,`ID_item`,`equipment`,`time_date`,`ID_worker`,`ID_factory`) REFERENCES `operations` (`num_operation`, `ID_item`, `equipment`, `time_date`, `ID_worker`, `ID_factory`),
  ADD CONSTRAINT `operations_ibfk_16` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `operations_ibfk_17` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `operations_ibfk_18` FOREIGN KEY (`equipment`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `operations_ibfk_19` FOREIGN KEY (`num_comp_operation`,`ID_item`,`equipment`,`time_date`,`ID_worker`,`ID_factory`) REFERENCES `operations` (`num_operation`, `ID_item`, `equipment`, `time_date`, `ID_worker`, `ID_factory`),
  ADD CONSTRAINT `operations_ibfk_2` FOREIGN KEY (`equipment`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `operations_ibfk_20` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `operations_ibfk_3` FOREIGN KEY (`num_comp_operation`,`ID_item`,`equipment`,`time_date`,`ID_worker`,`ID_factory`) REFERENCES `operations` (`num_operation`, `ID_item`, `equipment`, `time_date`, `ID_worker`, `ID_factory`),
  ADD CONSTRAINT `operations_ibfk_4` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `operations_ibfk_5` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `operations_ibfk_6` FOREIGN KEY (`equipment`) REFERENCES `stock_in_factory` (`ID_item`),
  ADD CONSTRAINT `operations_ibfk_7` FOREIGN KEY (`num_comp_operation`,`ID_item`,`equipment`,`time_date`,`ID_worker`,`ID_factory`) REFERENCES `operations` (`num_operation`, `ID_item`, `equipment`, `time_date`, `ID_worker`, `ID_factory`),
  ADD CONSTRAINT `operations_ibfk_8` FOREIGN KEY (`ID_worker`,`ID_factory`) REFERENCES `workers` (`ID_worker`, `ID_factory`),
  ADD CONSTRAINT `operations_ibfk_9` FOREIGN KEY (`ID_item`) REFERENCES `stock_in_factory` (`ID_item`);

--
-- Ограничения внешнего ключа таблицы `stock_in_factory`
--
ALTER TABLE `stock_in_factory`
  ADD CONSTRAINT `stock_in_factory_ibfk_1` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `stock_in_factory_ibfk_2` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `stock_in_factory_ibfk_3` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `stock_in_factory_ibfk_4` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `stock_in_factory_ibfk_5` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`);

--
-- Ограничения внешнего ключа таблицы `suppliers_in_factory`
--
ALTER TABLE `suppliers_in_factory`
  ADD CONSTRAINT `suppliers_in_factory_ibfk_1` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `suppliers_in_factory_ibfk_10` FOREIGN KEY (`ID_item`,`ID_supplier`) REFERENCES `com_stock_suppliers` (`ID_item`, `ID_supplier`),
  ADD CONSTRAINT `suppliers_in_factory_ibfk_2` FOREIGN KEY (`ID_item`,`ID_supplier`) REFERENCES `com_stock_suppliers` (`ID_item`, `ID_supplier`),
  ADD CONSTRAINT `suppliers_in_factory_ibfk_3` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `suppliers_in_factory_ibfk_4` FOREIGN KEY (`ID_item`,`ID_supplier`) REFERENCES `com_stock_suppliers` (`ID_item`, `ID_supplier`),
  ADD CONSTRAINT `suppliers_in_factory_ibfk_5` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `suppliers_in_factory_ibfk_6` FOREIGN KEY (`ID_item`,`ID_supplier`) REFERENCES `com_stock_suppliers` (`ID_item`, `ID_supplier`),
  ADD CONSTRAINT `suppliers_in_factory_ibfk_7` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `suppliers_in_factory_ibfk_8` FOREIGN KEY (`ID_item`,`ID_supplier`) REFERENCES `com_stock_suppliers` (`ID_item`, `ID_supplier`),
  ADD CONSTRAINT `suppliers_in_factory_ibfk_9` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`);

--
-- Ограничения внешнего ключа таблицы `workers`
--
ALTER TABLE `workers`
  ADD CONSTRAINT `workers_ibfk_1` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `workers_ibfk_2` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `workers_ibfk_3` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `workers_ibfk_4` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`),
  ADD CONSTRAINT `workers_ibfk_5` FOREIGN KEY (`ID_factory`) REFERENCES `factories` (`ID_factory`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
