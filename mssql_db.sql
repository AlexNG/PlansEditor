CREATE DATABASE plans

USE plans

CREATE TABLE [plan] (
	id BIGINT identity NOT NULL
	,[priority] INT
	,[name] NVARCHAR(128) NOT NULL
	,descr NVARCHAR(1000) NOT NULL
	)

ALTER TABLE [plan] ADD CONSTRAINT pk_plan PRIMARY KEY (id)

ALTER TABLE [plan] ADD CONSTRAINT ak_plan UNIQUE ([name])

----------------------------------------------------------------------
CREATE TABLE [event] (
	id BIGINT identity NOT NULL
	,plan_id BIGINT NOT NULL
	,[date] DATETIME NOT NULL
	,descr NVARCHAR(1000) NOT NULL
	)

ALTER TABLE [event] ADD CONSTRAINT pk_event PRIMARY KEY (id)

ALTER TABLE [event] ADD CONSTRAINT fk_event_plan FOREIGN KEY (plan_id) REFERENCES [plan] (id)

----------------------------------------------------------------------
CREATE OR ALTER VIEW plan_vm
AS
SELECT p.id	
	,[priority]
	,[name]
	,p.descr
	,COUNT(*) event_count
FROM [plan] p
LEFT JOIN [event] e ON p.id = e.plan_id
GROUP BY p.id
	,p.[priority]
	,p.[name]
	,p.descr
