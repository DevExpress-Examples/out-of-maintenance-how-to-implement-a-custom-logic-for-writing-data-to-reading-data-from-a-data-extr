Imports System
Imports System.Collections.Generic
Imports System.Security.Cryptography
Imports DevExpress.DashboardCommon

Namespace Dashboard_CustomExtractDriver
    Public Class ExtractEncryptionDriver
        Implements ICustomExtractDriver
        Public Function CreateReadSession(ByVal resourceName As String) As  _
            IDriverReadSession Implements ICustomExtractDriver.CreateReadSession
            Return New EncryptionReadSession(FileExtractDriver.Instance.CreateReadSession(resourceName))
        End Function
        Public Function CreateWriteSession(ByVal resourceName As String) As  _
            IDriverWriteSession Implements ICustomExtractDriver.CreateWriteSession
            Return New EncryptionWriteSession(FileExtractDriver.Instance.CreateWriteSession(resourceName))
        End Function
    End Class

    Public Class EncryptionWriteSession
        Implements IDriverWriteSession
        Private writeSession As IDriverWriteSession
        Public Sub New(ByVal writeSession As IDriverWriteSession)
            Me.writeSession = writeSession
        End Sub
        Public Sub Dispose() Implements System.IDisposable.Dispose
            writeSession.Dispose()
        End Sub
        Public Sub SetPage(ByVal pageID As Guid, ByVal data() As Byte) Implements IDriverWriteSession.SetPage
            writeSession.SetPage(pageID, Encrypt(data))
        End Sub
        Private Function Encrypt(ByVal page() As Byte) As Byte()
            Dim entropy() As Byte = {1, 2, 3}
            Dim encryptedPage() As Byte = ProtectedData.Protect(page, entropy, DataProtectionScope.CurrentUser)
            Return encryptedPage
        End Function
    End Class

    Public Class EncryptionReadSession
        Implements IDriverReadSession
        Private readSession As IDriverReadSession
        Public Sub New(ByVal readSession As IDriverReadSession)
            Me.readSession = readSession
        End Sub
        Public Sub Dispose() Implements System.IDisposable.Dispose
            readSession.Dispose()
        End Sub
        Private Function Decrypt(ByVal page() As Byte) As Byte()
            Dim entropy() As Byte = {1, 2, 3}
            Dim decryptedPage() As Byte = ProtectedData.Unprotect(page, entropy, DataProtectionScope.CurrentUser)
            Return decryptedPage
        End Function
        Public Function GetPage(ByVal pageID As Guid) As Byte() Implements IDriverReadSession.GetPage
            Return Decrypt(readSession.GetPage(pageID))
        End Function
        Public Function GetPageIDs() As IEnumerable(Of Guid) Implements IDriverReadSession.GetPageIDs
            Return readSession.GetPageIDs()
        End Function
    End Class
End Namespace