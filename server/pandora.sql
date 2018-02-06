/*
SQLyog Ultimate v11.24 (32 bit)
MySQL - 5.7.17-log : Database - pandora
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`pandora` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `pandora`;

/*Table structure for table `department` */

DROP TABLE IF EXISTS `department`;

CREATE TABLE `department` (
  `did` int(10) NOT NULL,
  `name` varchar(60) DEFAULT NULL,
  `pcode` int(11) DEFAULT NULL,
  PRIMARY KEY (`did`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `message` */

DROP TABLE IF EXISTS `message`;

CREATE TABLE `message` (
  `mid` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '信息ID',
  `title` varchar(60) DEFAULT NULL COMMENT '标题',
  `message` text COMMENT '信息',
  `send_id` int(40) DEFAULT NULL COMMENT '发件人ID',
  `send_name` varchar(10) DEFAULT NULL COMMENT '发件人',
  `receive_id` int(40) DEFAULT NULL COMMENT '接收人ID',
  `send_time` datetime DEFAULT NULL COMMENT '发送时间',
  `read_time` datetime DEFAULT NULL COMMENT '读取时间',
  `flag` tinyint(4) DEFAULT '0' COMMENT '读取标识,0:未读,1:已读',
  PRIMARY KEY (`mid`),
  KEY `receive_id` (`receive_id`,`flag`)
) ENGINE=InnoDB AUTO_INCREMENT=150 DEFAULT CHARSET=utf8;

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `uid` int(11) NOT NULL AUTO_INCREMENT COMMENT '用户ID',
  `username` varchar(10) DEFAULT NULL COMMENT '用户名',
  `name` varchar(10) NOT NULL COMMENT '姓名',
  `email` varchar(60) DEFAULT NULL COMMENT 'EMAIL',
  `password` varchar(32) DEFAULT NULL COMMENT '密码',
  `did` int(11) DEFAULT NULL COMMENT '部门ID',
  `public_key` text COMMENT '用户公钥',
  `security_id` varchar(16) DEFAULT '0' COMMENT '密钥',
  `off_work` tinyint(4) NOT NULL DEFAULT '0' COMMENT '状态:0:异常,1:正常,2:更新中',
  `refresh_time` datetime DEFAULT NULL COMMENT '更新时间',
  PRIMARY KEY (`uid`),
  UNIQUE KEY `name` (`email`),
  KEY `did` (`did`)
) ENGINE=InnoDB AUTO_INCREMENT=65215 DEFAULT CHARSET=utf8;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
