Imports System.IO



Module Tools

    Public Function XORCipher(ByVal data As String, ByVal encode As Boolean) As String


        Try
            If encode = True Then
                Return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(data))
            Else
                Return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(data))
            End If
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Sub CopyAndRenameFile(ByVal sourceFilePath As String, ByVal destinationFolderPath As String, ByVal newFileName As String)
        Try
            ' Check if the source file exists
            If File.Exists(sourceFilePath) Then
                ' Create the destination folder if it doesn't exist
                If Not Directory.Exists(destinationFolderPath) Then
                    Directory.CreateDirectory(destinationFolderPath)
                End If

                ' Generate the new file path by combining the destination folder path and the new file name
                Dim newFilePath As String = Path.Combine(destinationFolderPath, newFileName)

                ' Copy the file to the destination folder and rename it
                File.Copy(sourceFilePath, newFilePath)

                ' Optional
                ' You can delete the source file after copying if needed
                ' File.Delete(sourceFilePath)

                ' Optional
                ' Make this a function and return true if it exist
                ' Return True
            Else

            End If
        Catch ex As Exception
            Console.WriteLine("Error occurred: " & ex.Message)
        End Try
    End Sub

    Public Enum LogType
        System
    End Enum

    Public Sub Save_Logs(ByVal Message As String, ByVal Log As LogType, Optional ByVal x As Boolean = False)

    End Sub

End Module

Namespace TimeConversion
    Module unixTimeStamp
        ''' <summary>
        ''' Converts a (Local)DateTime object to a Unix timestamp 
        ''' </summary>
        ''' <param name="dateTime"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function LocalToUnixTimestamp(ByVal dateTime As DateTime) As Long
            Dim unixEpoch As New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            Dim utcDateTime = dateTime.ToUniversalTime()
            Return CLng((utcDateTime - unixEpoch).TotalSeconds)
        End Function

        ''' <summary>
        ''' Converts a Unix timestamp to a (Local)DateTime object
        ''' </summary>
        ''' <param name="unixTimestamp"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function LocalFromUnixTimestamp(ByVal unixTimestamp As Long) As DateTime
            Dim unixEpoch As New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            Dim utcDateTime = unixEpoch.AddSeconds(unixTimestamp)
            Return utcDateTime.ToLocalTime()
        End Function
    End Module
End Namespace

