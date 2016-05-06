using System.Collections.Generic;

namespace ErikEJ.SqlCeToolbox.Helpers
{
    class SqlCeSyntaxProvider
    {
        static List<string> tags;
        static List<char> specials;
        #region ctor
        static SqlCeSyntaxProvider()
        {
            // This is all the reserved words
            string[] strs = {
            "@@IDENTITY",
            "ADD",
            "ALL",
            "ALTER",
            "AND",
            "ANY",
            "AS",
            "ASC",
            "AUTHORIZATION",
            "AVG",
            "BACKUP",
            "BEGIN",
            "BETWEEN",
            "BREAK",
            "BROWSE",
            "BULK",
            "BY",
            "CASCADE",
            "CASE",
            "CHECK",
            "CHECKPOINT",
            "CLOSE",
            "CLUSTERED",
            "COALESCE",
            "COLLATE",
            "COLUMN",
            "COMMIT",
            "COMPUTE",
            "CONSTRAINT",
            "CONTAINS",
            "CONTAINSTABLE",
            "CONTINUE",
            "CONVERT",
            "COUNT",
            "CREATE",
            "CROSS",
            "CURRENT",
            "CURRENT_DATE",
            "CURRENT_TIME",
            "CURRENT_TIMESTAMP",
            "CURRENT_USER",
            "CURSOR",
            "DATABASE",
            "DATABASEPASSWORD",
            "DATEADD",
            "DATEDIFF",
            "DATENAME",
            "DATEPART",
            "DBCC",
            "DEALLOCATE",
            "DECLARE",
            "DEFAULT",
            "DELETE",
            "DENY",
            "DESC",
            "DISK",
            "DISTINCT",
            "DISTRIBUTED",
            "DOUBLE",
            "DROP",
            "DUMP",
            "ELSE",
            "ENCRYPTION",
            "END",
            "ERRLVL",
            "ESCAPE",
            "EXCEPT",
            "EXEC",
            "EXECUTE",
            "EXISTS",
            "EXIT",
            "EXPRESSION",
            "FETCH",
            "FILE",
            "FILLFACTOR",
            "FOR",
            "FOREIGN",
            "FREETEXT",
            "FREETEXTTABLE",
            "FROM",
            "FULL",
            "FUNCTION",
            "GOTO",
            "GRANT",
            "GROUP",
            "HAVING",
            "HOLDLOCK",
            "IDENTITY",
            "IDENTITY_INSERT",
            "IDENTITYCOL",
            "IF",
            "IN",
            "INDEX",
            "INNER",
            "INSERT",
            "INTERSECT",
            "INTO",
            "IS",
            "JOIN",
            "KEY",
            "KILL",
            "LEFT",
            "LIKE",
            "LINENO",
            "LOAD",
            "MAX",
            "MIN",
            "NATIONAL",
            "NOCHECK",
            "NONCLUSTERED",
            "NOT",
            "NULL",
            "NULLIF",
            "OF",
            "OFF",
            "OFFSETS",
            "ON",
            "OPEN",
            "OPENDATASOURCE",
            "OPENQUERY",
            "OPENROWSET",
            "OPENXML",
            "OPTION",
            "OR",
            "ORDER",
            "OUTER",
            "OVER",
            "PERCENT",
            "PLAN",
            "PRECISION",
            "PRIMARY",
            "PRINT",
            "PROC",
            "PROCEDURE",
            "PUBLIC",
            "RAISERROR",
            "READ",
            "READTEXT",
            "RECONFIGURE",
            "REFERENCES",
            "REPLICATION",
            "RESTORE",
            "RESTRICT",
            "RETURN",
            "REVOKE",
            "RIGHT",
            "ROLLBACK",
            "ROWCOUNT",
            "ROWGUIDCOL",
            "RULE",
            "SAVE",
            "SCHEMA",
            "SELECT",
            "SESSION_USER",
            "SET",
            "SETUSER",
            "SHUTDOWN",
            "SOME",
            "STATISTICS",
            "SUM",
            "SYSTEM_USER",
            "TABLE",
            "TEXTSIZE",
            "THEN",
            "TO",
            "TOP",
            "TRAN",
            "TRANSACTION",
            "TRIGGER",
            "TRUNCATE",
            "TSEQUAL",
            "UNION",
            "UNIQUE",
            "UPDATE",
            "UPDATETEXT",
            "USE",
            "USER",
            "VALUES",
            "VARYING",
            "VIEW",
            "WAITFOR",
            "WHEN",
            "WHERE",
            "WHILE",
            "WITH",
            "WRITETEXT",
            
            // Type names
	        "smallint",
	        "int",
	        "real",
	        "float",
	        "money",
	        "bit",
	        "tinyint",
	        "bigint",
	        "uniqueidentifier",
	        "varbinary",
	        "binary",
	        "image",
	        "nvarchar",
	        "nchar",
	        "ntext",
	        "numeric",
	        "datetime",
	        "rowversion",

            // Addtional keywords (from BOL)
            "@@DBTS",
            "@@SHOWPLAN",
            "ABS",
            "ACOS",
            "ASIN",
            "ATAN",
            "ATN2",
            "CEILING",
            "CHARINDEX",
            "CAST",
            "COS",
            "COT",
            "DATALENGTH",
            "DEGREES",
            "EXP",
            "FLOOR",
            "GETDATE",
            "LEN",
            "LOG",
            "LOG10",
            "LOWER",
            "LTRIM",
            "NCHAR",
            "NEWID",
            "PATINDEX",
            "PI",
            "POWER",
            "RADIANS",
            "RAND",
            "REPLACE",
            "REPLICATE",
            "RTRIM",
            "SHOWPLAN",
            "XML",
            "SIGN",
            "SIN",
            "SPACE",
            "SQRT",
            "STR",
            "STUFF",
            "SUBSTRING",
            "TAN",
            "UNICODE",
            "UPPER",
            
            // Hints
            "FORCE",
            "ROWLOCK",
            "PAGLOCK",
            "TABLOCK",
            "DBLOCK",
            "UPDLOCK",
            "XLOCK",
            "HOLDLOCK",
            "NOLOCK",

            // This is also highlighted in SSMS 2008 on Server
            "GO",

            // Version 4 new keywords
            //SELECT * FROM Customers ORDER BY [Customer ID] OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY;
            "NEXT",
            "OFFSET",
            "ONLY",
            "ROWS"    

            };
            tags = new List<string>(strs);

            char[] chrs = {
                '.',
                ',',
                ')',
                '(',
                '[',
                ']',
                '>',
                '<',
                ':',
                ';',
                '\n',
                '\t'
            };
            specials = new List<char>(chrs);
        }
        #endregion
        public static List<char> GetSpecials
        {
            get { return specials; }
        }
        public static List<string> GetTags
        {
            get { return tags; }
        }
        public static bool IsKnownTag(string tag)
        {
            return tags.Exists(delegate(string s) { return s.ToLower().Equals(tag.ToLower()); });
        }
        public static List<string> GetSqlCeProvider(string tag)
        {
            return tags.FindAll(delegate(string s) { return s.ToLower().StartsWith(tag.ToLower()); });
        }
    }
}
