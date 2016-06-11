CREATE DATABASE oneword;
GO
USE oneword;
CREATE TABLE t_users_base
(
	uuid BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	username_ 	VARCHAR(20) NOT NULL UNIQUE,
	password_ VARCHAR(64) NOT NULL,
	mobile_ VARCHAR(11),
	create_time DATETIME NOT NULL DEFAULT GETDATE(),
	create_ip VARCHAR(16) NOT NULL,
	status_ INT NOT NULL DEFAULT 1
);
CREATE TABLE t_users_admin
(
	uaid INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	uuid BIGINT NOT NULL UNIQUE,
	status_ INT NOT NULL DEFAULT 1,
	CONSTRAINT FK_Admin_uuid FOREIGN KEY(uuid) REFERENCES t_users_base(uuid) ON DELETE CASCADE
);
CREATE TABLE t_words_base
(
	wbid BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	uuid BIGINT NOT NULL,
	word_ TEXT NOT NULL,
	create_time DATETIME NOT NULL DEFAULT GETDATE(),
	status_ INT NOT NULL DEFAULT 1,
	CONSTRAINT FK_Words_uuid FOREIGN KEY(uuid) REFERENCES t_users_base(uuid) ON DELETE CASCADE
);
CREATE TABLE t_words_status
(
	wsid BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	wbid BIGINT NOT NULL,
	number_ BIGINT NOT NULL,
	status_ INT NOT NULL DEFAULT 1,
	CONSTRAINT FK_Status_wbid FOREIGN KEY(wbid) REFERENCES t_words_base(wbid) ON DELETE CASCADE
);
CREATE TABLE t_musics_base
(
	mbid BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	title_ varchar(32) not null,
	author_ varchar(32) not null,
	url_ varchar(128) not null,
	picture_ varchar(128) not null,
	status_ int not null default 1
);
create table t_users_attention
(
	id bigint not null primary key identity(1,1),
	uuid_from bigint not null,
	uuid_to bigint not null,
	create_time datetime not null default getdate(),
	status_ int not null default 1,
	constraint FK_Attention_uuid_from foreign key(uuid_from) references t_users_base(uuid) on delete cascade
)
insert into t_users_base(username_,password_,mobile_,create_ip)values
('admin','96E79218965EB72C92A549DD5A330112','13511111111','192.168.1.1');
insert into t_users_admin values(1,1);
insert into t_words_base(uuid,word_)values
