RESTORE DATABASE [dbDatos] FROM  DISK = N'F:\dbDatos_backup_Full.bak' 
	WITH  FILE = 1,  MOVE N'dbDatos' TO N'D:\Proyectos\Bases\dbDatos.mdf',  
	MOVE N'dbDatos_log' TO N'D:\Proyectos\Bases\dbDatos.ldf',  NORECOVERY,  NOUNLOAD,  REPLACE,  STATS = 10
GO

RESTORE DATABASE [dbDatos] FROM  DISK = N'F:\difDatos.bak' WITH  FILE = 1,  MOVE N'dbDatos' TO N'D:\Proyectos\Bases\dbDatos.mdf',  
	MOVE N'dbDatos_log' TO N'D:\Proyectos\Bases\dbDatos.ldf',  NOUNLOAD,  STATS = 10
GO
