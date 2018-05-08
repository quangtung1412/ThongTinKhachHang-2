use AGRIBANKHD
DECLARE @TableName VARCHAR(MAX) = 'TD.GIAY_NHAN_NO'
DECLARE @TableSchema VARCHAR(MAX)
DECLARE @result VARCHAR(MAX) = ''

SET @result = @result + 'using System;' + CHAR(13) + CHAR(13)

IF (@TableSchema IS NOT NULL) 
BEGIN
    SET @result = @result + 'namespace ' + @TableSchema  + CHAR(13) + '{' + CHAR(13)
END

SET @result = @result + 'public class ' + @TableName + CHAR(13) + '{' + CHAR(13)

SET @result = @result + '#region Instance Properties' + CHAR(13)

SELECT @result = @result + CHAR(13) 
    --+ '@' + LOWER(ColumnName) + ' = row["' + ColumnName + '"].ToString();'
    --+ 'pirvate string _' + LOWER(ColumnName) + ' = row["'+ ColumnName+ '"].ToString();'
    --+ 'new SqlParameter("@' + LOWER(ColumnName) + '",rtb.'+LOWER(ColumnName)+'),'
    --+ '[' + ColumnName + '],'
    --+ 'this._' + LOWER(ColumnName)+ ' = row["' + ColumnName + '"].ToString();' 
    --+ 'txt' + LOWER(ColumnName) + '.Text = tstc.' + LOWER(ColumnName) + ';'
    --+ 'txt' + LOWER(ColumnName) + '.Text'
	--+ CHAR(13)
	
	+ ' private ' + ColumnType + ' _' + LOWER(ColumnName) + ';' + CHAR(13)
    + ' public ' + ColumnType + ' ' + LOWER(ColumnName) + CHAR(13)
    + CHAR(13)
    + ' { ' + CHAR(13)
    + 'get { return _' + LOWER(ColumnName)+ '; }' + CHAR(13) 
    + 'set { _' + LOWER(ColumnName) + ' = value; }' + CHAR(13) 
    + '} ' + CHAR(13)
    
FROM
(
    SELECT  c.COLUMN_NAME   AS ColumnName
    --, c.DATA_TYPE AS ColumnType
        , CASE c.DATA_TYPE   
            WHEN 'bigint' THEN
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Int64?' ELSE 'Int64' END
            WHEN 'binary' THEN 'Byte[]'
            WHEN 'bit' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Boolean?' ELSE 'Boolean' END            
            WHEN 'char' THEN 'String'
            WHEN 'date' THEN
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'DateTime?' ELSE 'DateTime' END                        
            WHEN 'datetime' THEN
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'DateTime?' ELSE 'DateTime' END                        
            WHEN 'datetime2' THEN  
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'DateTime?' ELSE 'DateTime' END                        
            WHEN 'datetimeoffset' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'DateTimeOffset?' ELSE 'DateTimeOffset' END                                    
            WHEN 'decimal' THEN  
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Decimal?' ELSE 'Decimal' END                                    
            WHEN 'float' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Single?' ELSE 'Single' END                                    
            WHEN 'image' THEN 'Byte[]'
            WHEN 'int' THEN  
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Int32?' ELSE 'Int32' END
            WHEN 'money' THEN
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Decimal?' ELSE 'Decimal' END                                                
            WHEN 'nchar' THEN 'String'
            WHEN 'ntext' THEN 'String'
            WHEN 'numeric' THEN
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Decimal?' ELSE 'Decimal' END                                                            
            WHEN 'nvarchar' THEN 'string'
            WHEN 'real' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Double?' ELSE 'Double' END                                                                        
            WHEN 'smalldatetime' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'DateTime?' ELSE 'DateTime' END                                    
            WHEN 'smallint' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Int16?' ELSE 'Int16'END            
            WHEN 'smallmoney' THEN  
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Decimal?' ELSE 'Decimal' END                                                                        
            WHEN 'text' THEN 'String'
            WHEN 'time' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'TimeSpan?' ELSE 'TimeSpan' END                                                                                    
            WHEN 'timestamp' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'DateTime?' ELSE 'DateTime' END                                    
            WHEN 'tinyint' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Byte?' ELSE 'Byte' END                                                
            WHEN 'uniqueidentifier' THEN 'Guid'
            WHEN 'varbinary' THEN 'Byte[]'
            WHEN 'varchar' THEN 'String'
            ELSE 'Object'
            
        END AS ColumnType
        ,c.ORDINAL_POSITION 
FROM    INFORMATION_SCHEMA.COLUMNS c
WHERE   c.TABLE_NAME = @TableName and ISNULL(@TableSchema, c.TABLE_SCHEMA) = c.TABLE_SCHEMA  
) AS t
ORDER BY t.ORDINAL_POSITION

SET @result = @result + CHAR(13) + '#endregion Instance Properties' + CHAR(13)  

SET @result = @result  + '}' + CHAR(13)

IF (@TableSchema IS NOT NULL) 
BEGIN
    SET @result = @result + CHAR(13) + '}' 
END

--PRINT DATALENGTH(@result)
--PRINT @result
EXECUTE DBO.PrintMax @iInput=@result
