Imports ISA.Utility.Data

Module ConnectionString

    Public Sub SaveLocalDatabaseConfig(ByVal newDbConfig As DatabaseManager.Configuration)
        Dim Ini As New IniFileIO
        Ini.WriteString(localDbSection, "IP", newDbConfig.ipAddress)
        Ini.WriteInteger(localDbSection, "PORT", newDbConfig.port)
        Ini.WriteString(localDbSection, "USERNAME", newDbConfig.username)
        Ini.WriteString(localDbSection, "PASSWORD", newDbConfig.password)
        Ini.WriteString(localDbSection, "DBNAME", newDbConfig.databaseName)
        Ini.WriteString(localDbSection, "DRIVER", newDbConfig.driver)

    End Sub


    Private ReadOnly localDbSection As String = "LOCAL DATABASE"

    Public Function GetLocalDatabaseConfig() As DatabaseManager.Configuration
        Dim Ini As New IniFileIO

        Dim result As New DatabaseManager.Configuration
        Try
            result.ipAddress = Ini.GetString(localDbSection, "IP", "127.0.0.1")
            result.port = Ini.GetInteger(localDbSection, "PORT", 3306)
            result.username = Ini.GetString(localDbSection, "USERNAME", "root")
            result.password = Ini.GetString(localDbSection, "PASSWORD", "1sa]Inc]PMSroot.db")
            result.databaseName = Ini.GetString(localDbSection, "DBNAME", "dbase")
            result.driver = Ini.GetString(localDbSection, "DRIVER", "{MySQL ODBC 8.0 Unicode Driver}")
            result.isOk = True
        Catch ex As Exception

        End Try

        Return result

    End Function


End Module
