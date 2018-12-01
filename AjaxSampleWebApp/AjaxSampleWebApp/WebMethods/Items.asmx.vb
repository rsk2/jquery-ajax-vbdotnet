Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Serialization


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Items
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
       Return "Hello World"
    End Function

    <WebMethod(Description:="Get the next 10 timeline items", EnableSession:=True)> _
    <Script.Services.ScriptMethod(ResponseFormat:=Script.Services.ResponseFormat.Json, XmlSerializeString:=False)>
    Public Function GetNextTenTimelineItems(ByVal request As Dictionary(Of String, String) As String
        Dim response As New Response
        Dim jss As New JavaScriptSerializer()
        'Dim tSearch As New TimelineItemFilter
        'tSearch.MaxRows = 10
        Dim maxIdString As String = "" ', maxItemDateTime As String = ""
        Dim maxId As Integer
        Dim entityTypeId As String = "", entityId As String = ""
        If (request.TryGetValue("EntityId", entityId)) Then
            tSearch.EntityId = Convert.ToInt32(entityId)
        Else
            response = New Response() With {.Status = False, .ErrorMsg = "Nonexistent key 'EntityId'"}
            Return jss.Serialize(response)
        End If
        'If (request.TryGetValue("EntityTypeId", entityTypeId)) Then
        '    tSearch.EntityTypeId = Convert.ToInt32(entityTypeId)
        'Else
        '    response = New Response() With {.Status = False, .ErrorMsg = "Nonexistent key 'EntityTypeId'"}
        '    Return jss.Serialize(response)
        'End If
        'If (request.Data.TryGetValue("MaxItemDateTime", maxItemDateTime)) Then
        '    tSearch.MaxItemDateTime = CDate(maxItemDateTime)
        'Else
        '    response = New Response() With {.Status = False, .ErrorMsg = "Nonexistent key 'MaxItemDateTime'"}
        '    Return jss.Serialize(response)
        'End If
        If (request.TryGetValue("MaxItemId", maxIdString)) Then
            maxId = Convert.ToInt32(maxIdString)
        Else
            response = New Response() With {.Status = False, .ErrorMsg = "Nonexistent key 'ItemId'"}
            Return jss.Serialize(response)
        End If
        Dim tb As New TimelineBusiness(ServiceInterface.GetRequestContextFromWebApplication())
        Dim tItemResults() As TimelineItem = tb.GetTimelineItem(tSearch)
        Return jss.Serialize(tItemResults)
        response = New Response With {.Status = False, .ErrorMsg = "Not logged in."}
        Return jss.Serialize(response)
    End Function

    Public Function GetNextFiveItems() As List(Of String)
        Dim inventory As New List(Of String)(New String() {"Item Created", "Item Attended", "Item Consumed", "Item Released",
                                              "Item Missed", "Item Registered", "Item Deleted", "Item Submitted",
                                               "Item Purchased", "Item Sold"})
        Dim list As New List(Of String())

        Return list
    End Function

End Class




Public Class Request

    Public Property Data As Dictionary(Of String, String)

End Class

Public Class Response

    Public Property Status As Boolean
    Public Property ErrorMsg As String
    Public Property Result As Object

    Public Sub New()
        Status = True
    End Sub


End Class
