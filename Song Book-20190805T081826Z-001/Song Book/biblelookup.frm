VERSION 5.00
Begin VB.Form Form1 
   BackColor       =   &H00FFC0C0&
   BorderStyle     =   0  'None
   Caption         =   "Bible Lookup"
   ClientHeight    =   11010
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   15240
   Icon            =   "biblelookup.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   ScaleHeight     =   11010
   ScaleWidth      =   15240
   StartUpPosition =   3  'Windows Default
   WindowState     =   2  'Maximized
   Begin VB.CommandButton Command2 
      Caption         =   "Command2"
      Height          =   495
      Left            =   3315
      TabIndex        =   5
      Top             =   6030
      Visible         =   0   'False
      Width           =   1215
   End
   Begin VB.ListBox List1 
      Height          =   4740
      Left            =   3285
      TabIndex        =   4
      Top             =   1170
      Visible         =   0   'False
      Width           =   4710
   End
   Begin VB.CommandButton Command1 
      Caption         =   "X"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   18
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   480
      Left            =   14655
      TabIndex        =   3
      Top             =   105
      Visible         =   0   'False
      Width           =   510
   End
   Begin VB.TextBox Text1 
      Height          =   390
      Left            =   225
      TabIndex        =   1
      Top             =   10605
      Visible         =   0   'False
      Width           =   3615
   End
   Begin VB.Data Data1 
      Caption         =   "Data1"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   345
      Left            =   345
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   "BibleTable"
      Top             =   4200
      Visible         =   0   'False
      Width           =   2175
   End
   Begin VB.Image Image1 
      Height          =   525
      Left            =   14625
      Top             =   90
      Width           =   570
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   18
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   405
      Left            =   1380
      TabIndex        =   2
      Top             =   960
      Width           =   105
      WordWrap        =   -1  'True
   End
   Begin VB.Label Label2 
      Alignment       =   2  'Center
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   21.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   510
      Left            =   7485
      TabIndex        =   0
      Top             =   270
      Width           =   135
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim books As Variant
Dim Multipage As Boolean
Dim Pages() As String
Dim PageCount As Integer
Dim CurPage As Integer

'Private Sub Command2_Click()
'
'    ' how to fill the list with verses from the query ...
'    Dim i As Integer
'    Dim rstTemp As Recordset
'
'    Set rstTemp = Data1.Database.OpenRecordset( _
'        "SELECT * FROM BibleTable WHERE BookTitle = 'Revelation' AND Chapter = '010' AND (Verse >= '001' AND Verse <= '007')", dbOpenForwardOnly)
'    List1.Clear
'    With rstTemp
'        Do While Not .EOF
'            List1.AddItem .Fields(4)
'            .MoveNext
'        Loop
'    End With
'End Sub

Private Sub Form_KeyPress(KeyAscii As Integer)
    If KeyAscii = vbKeyEscape Then
        Unload Me
    End If
End Sub

Private Sub Form_KeyUp(KeyCode As Integer, Shift As Integer)
    Dim tmpstr As String
    
    If KeyCode = vbKeyF1 Then
        Text1 = ""
        Text1.Visible = True
    ElseIf KeyCode = vbKeyPageDown Then
            ' show next page
        If CurPage < PageCount Then
            CurPage = CurPage + 1
            Label3 = Pages(CurPage)
        End If
    ElseIf KeyCode = vbKeyPageUp Then
        If CurPage > 1 Then
            ' show previous page
            CurPage = CurPage - 1
            Label3 = Pages(CurPage)
            End If
'    ElseIf (Shift And 4) And KeyCode = vbKeyTab Then
    End If
    
End Sub

Private Sub Form_Load()
    books = Array("Genesis", "Exodus", "Leviticus", _
                    "Numbers", "Deuteronomy", "Joshua", "Judges", "Ruth", _
                    "1 Samuel", "2 Samuel", "1 Kings", "2 Kings", "1 Chronicles", _
                    "2 Chronicles", "Ezra", "Nehemiah", "Esther", "Job", _
                    "Psalms", "Proverbs", "Ecclesiastes", "Song of Solomon", _
                    "Isaiah", "Jeremiah", "Lamentations", "Ezekiel", "Daniel", _
                    "Hosea", "Joel", "Amos", "Obadiah", "Jonah", "Micah", _
                    "Nahum", "Habakkuk", "Zephaniah", "Haggai", "Zechariah", _
                    "Malachi", "Matthew", "Mark", "Luke", "John", "Acts", _
                    "Romans", "1 Corinthians", "2 Corinthians", "Galatians", _
                    "Ephesians", "Philipians", "Collosians", "1 Thessalonians", _
                    "2 Thessalonians", "1 Timothy", "2 Timothy", "Philemon", _
                    "Hebrews", "James", "1 Peter", "2 Peter", "1 John", _
                    "2 John", "3 John", "Jude", "Revelation")
    Data1.DatabaseName = App.Path & "\KJV.mdb"
    ScreenWrap = False
End Sub

Private Sub Form_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Command1.Visible = False
End Sub

Private Sub command1_Click()
    WindowState = vbMinimized
    Command1.Visible = False
    Form1.Refresh
End Sub

Private Sub Form_Resize()
    Label3.Width = Screen.Width - (Label3.Left * 2)
End Sub

Private Sub Image1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Command1.Visible = True
End Sub

Private Sub Label2_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Command1.Visible = False
End Sub


Private Sub Label3_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Command1.Visible = False
End Sub

Private Sub Text1_KeyPress(KeyAscii As Integer)
    Dim book As String, chapter As String, verse As String
    Dim chaptidx As Integer, verseidx As Integer, lineLimit As Integer
    Dim v As Integer, c As Integer, i As Integer, idx As Integer
    Dim vFrom As Integer, vTo As Integer, vCount As Integer
    Dim rangeIdx As Integer, verseText As String, trimText As String
    Dim strQuery As String, queryResult As String
    
    lineLimit = 15
            
On Error Resume Next
    If KeyAscii = vbKeyReturn Then
        
        PageCount = 1
        CurPage = 1
        Multipage = False
        
        If InStr(Text1, ";") Then
            Text1 = Replace(Text1, ";", ":")
        End If
        
        PageTwo = ""
        
        Text1.Visible = False
        ' now find the verse ....
        If Mid(Text1, 2, 1) = " " Then
            Text1 = Mid(Text1, 1, 2) & UCase(Mid(Text1, 3, 1)) & LCase(Mid(Text1, 4))
        Else
            Text1 = UCase(Mid(Text1, 1, 1)) & LCase(Mid(Text1, 2))
        End If
        book = Mid(Text1, 1, InStrRev(Text1, " ") - 1)
        For Each b In books
           For i = 1 To Len(book)
                If Mid(book, i, 1) <> Mid(b, i, 1) Then
                    Exit For
                End If
                idx = i
           Next i
           If idx = Len(book) Then
                book = b
                Exit For
           End If
        Next b
        
        ' we need to see if there is a range of verses to display or just one ...
''        If InStr(Text1, "..") <> 0 Then
''            verseText = ""
''            verseidx = InStr(1, Text1, ":")
''            vFrom = Val(Mid(Text1, verseidx + 1, rangeIdx - verseidx - 1))
''            verse = Format(vFrom, "000")
''            chaptidx = InStrRev(Text1, " ")
''            chapter = Mid(Text1, chaptidx + 1, verseidx - chaptidx - 1)
''            c = (chapter)
''            chapter = Format(c, "000")
''            With Data1.Recordset
''                .FindFirst ("BookTitle = '" & book & "' And Chapter = '" & chapter & "' And Verse = '" & verse & "'")
''                verseText = verseText & .Fields("TextData")
''                If .NoMatch = False Then
''
''
''                End If
''            End With
''        End If
        
        ' we need to see if there is a range of verses to display or just one ...
        
        If InStr(Text1, "-") <> 0 Then
            
            ' we need to get the range of verses to display
            verseText = ""
            verseidx = InStr(1, Text1, ":")
            rangeIdx = InStr(1, Text1, "-")
            vFrom = Val(Mid(Text1, verseidx + 1, rangeIdx - verseidx - 1))
            vTo = Val(Mid(Text1, rangeIdx + 1))
            vCount = vTo - vFrom + 1
            v = vFrom
            verse = Format(vFrom, "000")
            chaptidx = InStrRev(Text1, " ")
            chapter = Mid(Text1, chaptidx + 1, verseidx - chaptidx - 1)
            c = (chapter)
            chapter = Format(c, "000")
            ReDim Pages(1 To 1)
            If vCount > lineLimit Then
                PageCount = (vCount \ lineLimit) + (IIf(vCount Mod lineLimit = 0, 0, 1))
                ReDim Pages(1 To PageCount)
                Multipage = True
                CurPage = 1
            End If
            
            For i = 1 To vCount
                With Data1.Recordset
                    .FindFirst ("BookTitle = '" & book & "' And Chapter = '" & chapter & "' And Verse = '" & verse & "'")
                    If .NoMatch = False Then
                        verse = Format(vFrom + i, "000")
                        queryResult = "(" & (vFrom + (i - 1)) & ") " & .Fields("TextData")
                        verseText = verseText & vbCrLf & queryResult
                        If i Mod lineLimit = 0 Then
                            CurPage = CurPage + 1
                        End If
                        Pages(CurPage) = Pages(CurPage) & vbCrLf & queryResult
                    End If
                End With
            Next i
            CurPage = 1
            Label3.Visible = False
            Label3 = Pages(CurPage)
            Label3.Visible = True
            Label2 = book & " " & c & ":" & vFrom & "-" & vTo
            Label2.Left = (Screen.Width - Label2.Width) \ 2
            Label3.Left = (Screen.Width - Label3.Width) \ 2
        Else
            chaptidx = InStrRev(Text1, " ")
            verseidx = InStr(chaptidx, Text1, ":")
            chapter = Mid(Text1, chaptidx + 1, verseidx - chaptidx - 1)
            c = (chapter)
            chapter = Format(c, "000")
            verse = Mid(Text1, verseidx + 1)
            v = (verse)
            verse = Format(v, "000")
            Data1.Recordset.FindFirst ("BookTitle = '" & book & "' And Chapter = '" & chapter & "' And Verse = '" & verse & "'")
            Label3 = "(" & v & ") " & Data1.Recordset.Fields("TextData")
            Label2 = book & " " & c & ":" & v
            Label2.Left = (Screen.Width - Label2.Width) \ 2
            Label3.Left = (Screen.Width - Label3.Width) \ 2
        End If
    End If
    Form1.SetFocus
    
On Error GoTo 0
    Label3.Visible = True
End Sub

