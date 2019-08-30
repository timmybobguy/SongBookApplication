Attribute VB_Name = "mDatabase"
Option Explicit

Public Type SONG_DATA
    id As Long
    title As String
    body As String
    num As Integer
    key As String
End Type

Public Songs() As SONG_DATA
Public SONGS_COUNT As Long
Public CURRENT_SONG As Long
Const SPEECHMARK = Chr(34)

Public Sub XML2DB()
    Dim l As Long
    
    ReDim Songs(1 To UBound(xmlData.Stats))
    For l = 1 To UBound(xmlData.Stats)
        With Songs(l)
            .id = xmlData.Stats(l).Value(1)
            .num = xmlData.Stats(l).Value(2)
            .key = xmlData.Stats(l).Value(4)
            .title = Replace(xmlData.Stats(l).Value(3), "&apos;", "'")
            .body = xmlData.Stats(l).Value(5)
        End With
    Next l
End Sub

Function generateDateStamp() As String
    Dim s As String
    s = "generated=" & SPEECHMARK & Format(Now(), "YYYY-MM-DD") & "T" & Format(Now(), "HH:MM:SS") & SPEECHMARK & " xsi:noNamespaceSchemaLocation=" & SPEECHMARK & "Songs.xsd" & SPEECHMARK & " xmlns:xsi= " & SPEECHMARK & "http://www.w3.org/2001/XMLSchema-instance" & SPEECHMARK & " xmlns:od=" & SPEECHMARK & "urn:schemas-microsoft-com:officedata" & SPEECHMARK & ">"
    
    generateDateStamp = s
End Function

Public Sub DB2XML(ByVal fname As String)
    Dim f As Long, l As Long
    
    f = FreeFile
    Open fname For Output As f
    Print #f, "<?xml version=" & Chr(34) & 1# & Chr(34) & "encoding=" & Chr(34) & "UTF - 8" & Chr(34) & "?>" & vbCrLf
    Print "dataroot " & generateDateStamp & vbCrLf
'    Print #f, "<dataroot>" & vbCrLf ' generated="2010-04-22T02:11:56" xsi:noNamespaceSchemaLocation="Songs.xsd" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:od="urn:schemas-microsoft-com:officedata">" & vbCrLf
    For l = 1 To UBound(Songs)
        With Songs(l)
            Print #f, "<Songs>" & vbCrLf
            Print #f, "<SongID>" & l & "</SongID>" & vbCrLf
            Print #f, "<SongNum>" & .num & "</SongNum>" & vbCrLf
            Print #f, "<Title>" & .title & "</Title>" & vbCrLf
            Print #f, "<Key>" & .key & "</Key>" & vbCrLf
            Print #f, "<Body>" & .body & "</Body>" & vbCrLf
            Print #f, "</Songs>" & vbCrLf
        End With
    Next l
    Print #f, "</dataroot>"
    Close f
End Sub
