-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 23-Jan-2021 às 18:16
-- Versão do servidor: 10.4.13-MariaDB
-- versão do PHP: 7.2.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `webmercado`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(85) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` varchar(85) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(85) DEFAULT NULL,
  `ConcurrencyStamp` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `aspnetroles`
--

INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('226ea878-15ad-4039-9f3c-8374fe4429ba', 'Administrador', 'ADMINISTRADOR', 'd87191a4-3c2c-47c0-a004-a39097c2ccb2'),
('db684739-0198-4325-8b4d-ec21c1660d67', 'Cliente', 'CLIENTE', 'f2ecd002-d089-4502-bd05-f83d0a646b31');

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(85) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(85) NOT NULL,
  `ProviderKey` varchar(85) NOT NULL,
  `ProviderDisplayName` text DEFAULT NULL,
  `UserId` varchar(85) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(85) NOT NULL,
  `RoleId` varchar(85) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
('24be33e6-efd6-4574-b855-58316d258f7a', 'db684739-0198-4325-8b4d-ec21c1660d67'),
('5c1c4412-0114-468f-a9cf-81ee07f2e81e', '226ea878-15ad-4039-9f3c-8374fe4429ba');

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(85) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(85) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(85) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` text DEFAULT NULL,
  `SecurityStamp` text DEFAULT NULL,
  `ConcurrencyStamp` text DEFAULT NULL,
  `PhoneNumber` text DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `Apelido` varchar(20) DEFAULT NULL,
  `DataNascimento` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`, `Nome`, `Apelido`, `DataNascimento`) VALUES
('24be33e6-efd6-4574-b855-58316d258f7a', 'victor@victor.com', 'VICTOR@VICTOR.COM', 'victor@victor.com', 'VICTOR@VICTOR.COM', 0, 'AQAAAAEAACcQAAAAEPqihdgqay7bLS5AS5gKI3H5T3btsxLVat7+DjIT+n26Qa495KvKmDGFD9X12zJVGg==', 'AZOVC4SYE6FOJP5GAKCJZ3NF7IASPFBI', '9ac0ea37-2c68-4de5-a333-05d45e78ab83', NULL, 0, 0, NULL, 1, 0, 'victor', 'victor', '2020-03-12 00:00:00'),
('5c1c4412-0114-468f-a9cf-81ee07f2e81e', 'admin@webmercado.com.br', 'ADMIN@WEBMERCADO.COM.BR', 'admin@webmercado.com.br', 'ADMIN@WEBMERCADO.COM.BR', 1, 'AQAAAAEAACcQAAAAEP3YpjmwofNwGgGuhX0NPszU6Pbikw4cRxHuOi2cbf54gI0fbmPhV97U7bi08Ey8xw==', '25666', '74d381a6-a421-45b7-9c9f-a009168904a8', NULL, 0, 0, NULL, 0, 0, 'Admin', 'Admin', '2020-11-10 20:35:28');

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(85) NOT NULL,
  `LoginProvider` varchar(85) NOT NULL,
  `Name` varchar(85) NOT NULL,
  `Value` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `categoria`
--

CREATE TABLE `categoria` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `categoria`
--

INSERT INTO `categoria` (`Id`, `Nome`) VALUES
(1, 'Açougue'),
(2, 'Bebidas'),
(3, 'Congelados'),
(4, 'Doces'),
(5, 'Domésticos'),
(6, 'Hortifruti');

-- --------------------------------------------------------

--
-- Estrutura da tabela `produto`
--

CREATE TABLE `produto` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(70) NOT NULL,
  `Descricao` varchar(500) DEFAULT NULL,
  `EstoqueAtual` int(11) NOT NULL,
  `EstoqueMinimo` int(11) NOT NULL,
  `ValorCusto` double NOT NULL,
  `ValorVenda` double NOT NULL,
  `DataCadastro` datetime NOT NULL,
  `CategoriaId` int(11) NOT NULL,
  `Imagem` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `produto`
--

INSERT INTO `produto` (`Id`, `Nome`, `Descricao`, `EstoqueAtual`, `EstoqueMinimo`, `ValorCusto`, `ValorVenda`, `DataCadastro`, `CategoriaId`, `Imagem`) VALUES
(1, 'Picanha bovina', 'Picanha bovina 1kg', 25, 5, 25, 50, '2020-12-09 14:22:37', 1, '/img/produtos/f94690e1-54aa-4bb7-a639-2842c3aeb721_5.png'),
(2, 'Costela de cordeiro', 'Costela de cordeiro 1kg', 30, 10, 15, 25, '2020-12-09 14:25:03', 1, '/img/produtos/26017531-a75f-4b8c-bb15-dcf152bf2997_11.png'),
(3, 'Carne Moída', 'Carne moída 500g', 25, 10, 8, 16, '2020-12-09 14:27:00', 1, '/img/produtos/b2dba72c-d28f-43e1-92fe-10aaf6f187ca_12.png'),
(4, 'Carne moída de frango', 'Carne moída de frango 500g', 25, 10, 9, 18, '2020-12-09 14:29:27', 1, '/img/produtos/a1841580-0906-4fa8-a0da-b278a6fc56c3_13.png'),
(5, 'Linguiça suína', 'Linguiça suína 1kg', 40, 10, 11, 22, '2020-12-09 14:30:19', 1, '/img/produtos/5c4f06c7-1897-4426-8969-f561e370b6c8_16.png'),
(6, 'Vinho Tinto Pinot Noir', 'Vinho Tinto Pinot Noir 750ml', 25, 10, 20, 45, '2020-12-09 14:31:54', 2, '/img/produtos/b51e36c2-6b11-42a6-87b8-e41844103496_17.png'),
(7, 'Guaraná Antarctica ', 'Guaraná Antarctica 2l', 40, 10, 3, 8, '2020-12-09 14:32:39', 2, '/img/produtos/36000f0e-df1d-42c7-9220-464adc4c45bb_18.png'),
(8, 'Aguardente 51 ', 'Aguardente 51 Pirassununga 965ml', 15, 5, 5, 12, '2020-12-09 14:33:56', 2, '/img/produtos/6f11cf4f-ddf8-4d2c-b82e-727a5ea9af22_19.png'),
(9, 'Refrigerante Sprite', 'Refrigerante Sprite sabor limão 2l', 40, 15, 4, 8, '2020-12-09 14:34:38', 2, '/img/produtos/30d4a72e-9c5f-4f51-af6f-7bc647d956f8_7.png'),
(10, 'Coca Cola', 'Refrigerante sabor cola 2l', 50, 10, 4, 9, '2020-12-09 14:35:14', 2, '/img/produtos/a3e57277-d413-4049-8fb3-e0f8353c0fba_4.png'),
(11, 'Chocolate Lacta Meio-Amargo', 'Barra de chocolate meio-amargo', 30, 10, 6, 11, '2020-12-09 14:36:45', 4, '/img/produtos/a1b2eda0-5291-4a90-b2c2-0223ec56c0ed_1.png'),
(12, 'Chocolate Io-Iô', 'Chocolate Io-Iô 180g', 25, 10, 3, 7, '2020-12-09 14:56:20', 4, '/img/produtos/99ce66bf-5d35-4a4b-9657-e771c3d80cf5_3.png'),
(13, 'Diamante Negro ', 'Barra de chocolate Nestlé 90g', 25, 5, 5, 11, '2020-12-09 14:57:16', 4, '/img/produtos/0d0095a4-a269-4355-a789-06ca9448611a_6.png'),
(14, 'Caixa de Bombons Lacta', 'Caixa de Bombons Favoritos Lacta 250g', 30, 10, 5, 12, '2020-12-09 15:00:43', 4, '/img/produtos/58af090c-e01d-42b1-89cd-715d72fc6dee_8.png'),
(15, 'Caixa de Chocolates Tortuguita', 'Caixa de Chocolates Tortuguita 18g com 24 unidades', 15, 5, 11, 22, '2020-12-09 15:02:03', 4, '/img/produtos/dab3bcd1-1b86-4981-9ebf-304e9fb67c20_9.png'),
(16, 'Nuggets de Frango Sadia', 'Nuggets de Frango Sadia 300g', 40, 10, 4, 9, '2020-12-09 15:02:52', 3, '/img/produtos/6b443434-8ec4-4ac3-b4f5-fb18853c6e8a_2.png'),
(17, 'Iscas de Frango Empanada Aurora', 'Iscas de Frango Empanada Aurora 300g', 25, 10, 4, 8, '2020-12-09 15:05:00', 3, '/img/produtos/614f4189-ab6d-44e7-90f9-a1c7fa36fd85_10.png'),
(18, 'Hamburguer Bovino Aurora', 'Hamburguer Bovino Aurora 100g 2 unidades', 30, 10, 1, 2, '2020-12-09 15:07:01', 3, '/img/produtos/1eab99f5-0cb8-46b6-8d9e-650ae3f0ca81_14.png'),
(19, 'Leite Condensado Moça', 'Leite Condensado Moça 395g', 50, 10, 4, 9, '2020-12-10 20:33:33', 4, '/img/produtos/b494b7d4-c49e-426e-bbc9-e337c1288329_20.png');

-- --------------------------------------------------------

--
-- Estrutura da tabela `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20201110233528_inicio', '3.1.9');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Índices para tabela `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Índices para tabela `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Índices para tabela `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Índices para tabela `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Índices para tabela `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Índices para tabela `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Índices para tabela `categoria`
--
ALTER TABLE `categoria`
  ADD PRIMARY KEY (`Id`);

--
-- Índices para tabela `produto`
--
ALTER TABLE `produto`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Produto_CategoriaId` (`CategoriaId`);

--
-- Índices para tabela `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `categoria`
--
ALTER TABLE `categoria`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de tabela `produto`
--
ALTER TABLE `produto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `produto`
--
ALTER TABLE `produto`
  ADD CONSTRAINT `FK_Produto_Categoria_CategoriaId` FOREIGN KEY (`CategoriaId`) REFERENCES `categoria` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;