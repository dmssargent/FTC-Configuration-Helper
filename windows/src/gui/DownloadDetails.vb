
Public Class DownloadDetails
    <Serializable()> _
    Public Structure saveState
        <Xml.Serialization.XmlAttribute("name")> _
        Public name As String

        <Xml.Serialization.XmlAttribute("url")> _
        Public url As String

        <Xml.Serialization.XmlAttribute("checksum")> _
        Public SHA512 As String

        <Xml.Serialization.XmlAttribute("filename")> _
        Public fileName As String
    End Structure

    ''' <summary>
    ''' Display Name of the download
    ''' </summary>
    ''' <remarks></remarks>
    Private name As String

    ''' <summary>
    ''' URL to get the download
    ''' </summary>
    ''' <remarks></remarks>
    Private url As String

    ''' <summary>
    ''' SHA512 checksum of the download
    ''' </summary>
    ''' <remarks></remarks>
    Private SHA512 As String

    ''' <summary>
    ''' Filename to save the download as
    ''' </summary>
    ''' <remarks></remarks>
    Private fileName As String

    ''' <summary>
    ''' The name to display for the download
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property setupName
        Get
            Return name
        End Get
    End Property

    ''' <summary>
    ''' URL to get the download from
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FetchUrl
        Get
            Return url
        End Get
    End Property

    ''' <summary>
    ''' Provides the checksum for verification
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CheckSum
        Get
            Return SHA512
        End Get
    End Property

    ''' <summary>
    ''' Save the download as this
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property File
        Get
            Return fileName
        End Get
    End Property

    ''' <summary>
    ''' Takes care of New's functions
    ''' </summary>
    ''' <param name="newName">name of the download</param>
    ''' <param name="fetch">URL to get the download from</param>
    ''' <param name="checksum">SHA512 checksum for the file</param>
    ''' <param name="save">filename of the downloaded file</param>
    ''' <remarks>Throws ArgumentExceptions if the arguments are not valid</remarks>
    Private Sub CheckNew(ByVal newName As String, ByVal fetch As String, ByVal checksum As String, ByVal save As String)
        If newName IsNot Nothing Then
            Me.name = newName
        Else
            Throw New ArgumentNullException("newName")
        End If

        If fetch IsNot Nothing Then
            Me.url = fetch
        Else
            Throw New ArgumentNullException("fetch")
        End If

        If checksum IsNot Nothing Then
            Me.SHA512 = checksum
        End If

        If save IsNot Nothing Then
            Me.fileName = save
        Else
            Me.fileName = fetch.Substring(fetch.LastIndexOf("/"), fetch.Length - 1)
            If Me.fileName Is Nothing And Me.fileName.IndexOf(".") <> -1 Then
                Throw New ArgumentException("Save cannot be nothing or the url provided must be able to give a filename", "save")
            End If
        End If
    End Sub

    ''' <summary>
    ''' Build a DownloadDetails object to provide download specifics to the downloader function
    ''' </summary>
    ''' <param name="newName">name of the download</param>
    ''' <param name="fetch">URL to get the download from</param>
    ''' <param name="checksum">SHA512 checksum for the file</param>
    ''' <param name="save">filename of the downloaded file</param>
    ''' <remarks>Throws ArgumentExceptions if the arguments are not valid</remarks>
    Sub New(ByVal newName As String, ByVal fetch As String, ByVal checksum As String, ByVal save As String)
        CheckNew(newName, fetch, checksum, save)
    End Sub

    ''' <summary>
    ''' Build a DownloadDetails object to provide download specifics to the downloader function
    ''' </summary>
    ''' <param name="details">InstallerDetails to use</param>
    ''' <param name="checksum">SHA512 checksum</param>
    ''' <remarks>Throws ArgumentExceptions if the arguments are not valid</remarks>
    Sub New(ByVal details As Installer.InstallerDetails, ByVal checksum As String)
        CheckNew(details.displayName, details.downloadURL, checksum, details.filePath)
    End Sub

    Public Shared Function LoadSaved(ByRef save As saveState) As DownloadDetails
        Return New DownloadDetails(save.name, save.url, save.SHA512, save.fileName)
    End Function

    Public Function BuildSave() As saveState
        Dim save As New saveState
        save.name = Me.name
        save.url = Me.url
        save.SHA512 = Me.CheckSum
        save.fileName = Me.fileName
        Return save
    End Function
End Class
