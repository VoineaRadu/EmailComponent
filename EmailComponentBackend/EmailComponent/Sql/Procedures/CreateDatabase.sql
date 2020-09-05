Create procedure CreateDatabase @db_name nvarchar(255)
AS

declare @file_name_data nvarchar(255),
		@file_name_log nvarchar(255),
		@query nvarchar(MAX);

SET @file_name_data = '''' + 'E:\\' + @db_name + 'Data.mdf' + ''''; 
SET @file_name_log = '''' + 'E:\\' + @db_name + 'Log.mdf' + ''''; 

/* Because of ALTER */
SET @query = 'IF(db_id(''' + @db_name + ''') IS NULL)'+
 +' CREATE DATABASE '+ @db_name + ' ON PRIMARY (NAME = ' + @db_name + '_Data, FILENAME = ' + @file_name_data + ' , SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) 
								 LOG ON (NAME = MyDatabase_Log,  FILENAME = ' + @file_name_log + ', SIZE = 1MB, MAXSIZE = 5MB,  FILEGROWTH = 10%)'

EXEC(@query) 