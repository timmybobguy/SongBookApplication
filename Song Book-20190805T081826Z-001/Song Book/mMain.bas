Attribute VB_Name = "mMain"
Option Explicit

Public Type XML_VALUES_ARRAY
    Value() As Variant
End Type

Public Type XML_DATA
    tags() As String
    Stats() As XML_VALUES_ARRAY
End Type

Public xmlData As XML_DATA
Public song_count As Long

Public Function WriteTag(ByVal tagName As String, val As String) As String
    WriteTag = "<" & tagName & ">" & val & "</" & tagName & ">"
End Function

Public Function readXMLtoString(ByVal fname As String, ByRef success As Boolean) As String
    Dim f As Long
    
    If Dir(fname) = "" Then
        success = False
        readXMLtoString = ""
        Exit Function
    End If
    If FileLen(fname) = 0 Then
        success = False
        readXMLtoString = ""
        Exit Function
    End If
    
    f = FreeFile
    Open fname For Input As f
    success = True
    readXMLtoString = Input(LOF(f), f)
    Close f
End Function



Public Function GetTagData(ByVal searchStr As String, ByVal tagStr As String, ByRef startPos As Long, ByRef success As Boolean, Optional ByRef KeyStr As String = "") As String
    Dim startPosition As Long, keyValIdx As Long
    Dim p1 As Long, p2 As Long, p3 As Long
    Dim l As Long, l1 As Long, l2 As Long
    
On Error Resume Next
    startPosition = startPos
    If KeyStr <> "" Then
        ' find the key witin tag string...
        p1 = InStr(startPosition, searchStr, "<" & tagStr) - 1
        If p1 < 1 Then
            success = False
            Exit Function
        End If
        p3 = InStr(p1, searchStr, ">")
        keyValIdx = InStr(startPosition, searchStr, KeyStr)
        If keyValIdx > p3 Then
            ' the key is missing
            Debug.Print "key : " & KeyStr & " - is missing from tag : " & tagStr & "!"
            success = False
            Exit Function
        End If
        keyValIdx = keyValIdx + Len(KeyStr) + 2 ' should put us just past the first value quotation mark...
        p3 = InStr(keyValIdx, searchStr, """")
        KeyStr = Mid(searchStr, keyValIdx, p3 - keyValIdx)
    Else
        p1 = InStr(startPosition, searchStr, "<" & tagStr & ">") - 1
        If p1 < 1 Then
            success = False
            Exit Function
        End If
    End If
    p2 = InStr(startPosition, searchStr, "</" & tagStr & ">")
    l1 = Len(tagStr) ' + 3
    l2 = l1 + 1
    p1 = p1 + l1 + 3 ' 1
    ' modifiy passed in index variable ...
    startPos = p2 + l1 + 3
   ' p2 = p2 + 1
    l = p2 - p1 '- 1
    If l < 1 Then
        success = False
        Exit Function
    End If
    success = True
    GetTagData = Mid(searchStr, p1, l)
End Function

Public Function LoadXmlTagDef(ByVal fname As String) As String()
    Dim f As Long, arr() As String, n As Integer, s As String
    
    f = FreeFile
    Open fname For Input As f
        Do While Not EOF(f)
            Line Input #f, s
            n = n + 1
            ReDim Preserve arr(1 To n)
            arr(n) = s
        Loop
    Close f
    LoadXmlTagDef = arr
End Function

Public Function LoadXMLSongsFile(ByVal fname As String, ByVal tagFname As String) As Boolean
    Dim fl As String, success As Boolean, hd As String, ss As String, s As String, idx As Long, i As Integer
    Dim vArr As Variant
    
    fl = readXMLtoString(fname, success)
    If Not success Then
        LoadXMLSongsFile = False
        Exit Function
    End If
    idx = 1
    ' get the array of tags for these statistics...
    xmlData.tags = LoadXmlTagDef(tagFname)
    ' now we loop through all meshblock tags getting all the stats into the xmlData() array...
    Do
        s = GetTagData(fl, "Songs", idx, success)
        If Not success Then Exit Do
        song_count = song_count + 1
        ReDim Preserve xmlData.Stats(1 To song_count)
        ReDim xmlData.Stats(song_count).Value(1 To UBound(xmlData.tags))
        For i = 1 To UBound(xmlData.tags)
            ss = GetTagData(s, xmlData.tags(i), 1, success)
            If success Then
                xmlData.Stats(song_count).Value(i) = ss 'Debug.Assert Err.Number <> 0: Stop
            End If
        Next i 'Debug.Assert Err.Number <> 0: Stop
    Loop
    LoadXMLSongsFile = True
End Function

