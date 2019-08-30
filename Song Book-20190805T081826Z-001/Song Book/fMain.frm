VERSION 5.00
Begin VB.Form fMain 
   Caption         =   "Grace Tabernacle Song Book"
   ClientHeight    =   8130
   ClientLeft      =   225
   ClientTop       =   870
   ClientWidth     =   10335
   LinkTopic       =   "Form1"
   ScaleHeight     =   542
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   689
   StartUpPosition =   3  'Windows Default
   WindowState     =   2  'Maximized
   Begin VB.PictureBox files 
      Height          =   480
      Left            =   10200
      ScaleHeight     =   420
      ScaleWidth      =   1140
      TabIndex        =   5
      Top             =   120
      Width           =   1200
   End
   Begin VB.ListBox List1 
      Height          =   6885
      Left            =   480
      Sorted          =   -1  'True
      TabIndex        =   4
      Top             =   840
      Width           =   3540
   End
   Begin VB.TextBox Text1 
      Height          =   6345
      Left            =   4230
      Locked          =   -1  'True
      MultiLine       =   -1  'True
      ScrollBars      =   3  'Both
      TabIndex        =   3
      Top             =   1395
      Width           =   5610
   End
   Begin VB.PictureBox Picture1 
      BorderStyle     =   0  'None
      Height          =   525
      Left            =   4260
      ScaleHeight     =   525
      ScaleWidth      =   5580
      TabIndex        =   1
      Top             =   840
      Width           =   5580
      Begin VB.Label labSongNumber 
         AutoSize        =   -1  'True
         ForeColor       =   &H00400000&
         Height          =   195
         Left            =   2160
         TabIndex        =   2
         Top             =   105
         Width           =   45
      End
      Begin VB.Image Image1 
         Height          =   480
         Left            =   0
         Picture         =   "fMain.frx":0000
         Top             =   15
         Width           =   480
      End
      Begin VB.Image Image7 
         Height          =   480
         Left            =   975
         Picture         =   "fMain.frx":00CE
         Top             =   0
         Width           =   480
      End
      Begin VB.Image Image6 
         Height          =   480
         Left            =   1455
         Picture         =   "fMain.frx":04F6
         Top             =   0
         Width           =   480
      End
      Begin VB.Image Image3 
         Height          =   480
         Left            =   975
         Picture         =   "fMain.frx":0943
         Top             =   0
         Width           =   480
      End
      Begin VB.Image Image4 
         Height          =   480
         Left            =   1455
         Picture         =   "fMain.frx":0A71
         Top             =   0
         Width           =   480
      End
      Begin VB.Image Image5 
         Height          =   480
         Left            =   495
         Picture         =   "fMain.frx":0BC6
         Top             =   -30
         Width           =   480
      End
      Begin VB.Image Image2 
         Height          =   480
         Left            =   495
         Picture         =   "fMain.frx":1018
         Top             =   -30
         Width           =   480
      End
   End
   Begin VB.PictureBox SSTab1 
      Height          =   8175
      Left            =   240
      ScaleHeight     =   8115
      ScaleWidth      =   9795
      TabIndex        =   0
      Top             =   120
      Width           =   9855
   End
   Begin VB.Menu mnuFile 
      Caption         =   "&File"
      Begin VB.Menu mnuNew 
         Caption         =   "New Song List..."
      End
      Begin VB.Menu mnuLoad 
         Caption         =   "Edit Song List..."
      End
      Begin VB.Menu mnuEdit 
         Caption         =   "Load Song List..."
      End
      Begin VB.Menu mnuFileSep 
         Caption         =   "-"
      End
      Begin VB.Menu mnuExit 
         Caption         =   "E&xit"
      End
   End
End
Attribute VB_Name = "fMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

' TODO - Song list function
' allow input of a list of songs which can then be displayed sequentially by
' keypresses without having to leave the fscreen form.

' TODO - Have a splash screen that is displayed at the end of song and at the
' start of the song list, option to have a different screen for end of song ...

Private Function cleanString(ByVal s As String) As String
    Dim ss As String
    
    ss = s
    
    ss = Replace(ss, "&apos;", "'")
    ss = Replace(ss, ",", "")
    ss = Replace(ss, ";", "")
'    ss = Replace(ss, Chr(13), "")
'    ss = Replace(ss, Chr(10), vbCrLf)
    cleanString = ss
End Function

Private Sub files_Click()

End Sub

Private Sub Form_Load()
  Dim bSuccess As Boolean
  Dim i As Integer
  Dim msg As String
  
On Error GoTo ErrorMain

  bListMode = False
  If Not LoadXMLSongsFile(App.Path & "\songs.xml", App.Path & "\fields.txt") Then
    MsgBox "An error occured while attempting to load the songs database file!"
    Unload Me
  End If
  XML2DB
  SSTab1.Tab = 0
  Exit Sub
ErrorMain:
    With Err
        msg = "An error occured whilst attempting to start this program:" & vbCrLf & vbCrLf
        msg = msg & "Error Number: " & .Number & vbCrLf
        msg = msg & "Error Description: " & .Description & vbCrLf
        msg = msg & "Error Source: " & .Source & vbCrLf
        MsgBox msg
    End With
    
End Sub

Private Sub Image1_Click()
    'show the new song screen...
    bNewSong = True
    fEdit.Show 1
End Sub

Private Sub Image2_Click()
    'show the edit song screen...
    bNewSong = False
    fEdit.Show 1
End Sub

Private Sub Image3_Click()
    ' delete selected song...
    ' confirm deletion first...
    
End Sub

Private Sub Image4_Click()
    fScreen.Show 1
End Sub

Private Sub Image5_Click()

End Sub

Private Sub List1_Click()
    CURRENT_SONG = List1.ItemData(List1.ListIndex)
    Text1.Text = cleanString(Songs(CURRENT_SONG).body)
    labSongNumber.Caption = Songs(CURRENT_SONG).title & " #" & Songs(CURRENT_SONG).num
    Image7.ZOrder 1
    Image6.ZOrder 1
    Image5.ZOrder 1
End Sub

Private Sub List1_DblClick()
    fScreen.Show 1
End Sub

Private Sub mnuEdit_Click()
'    Dim f As Long, i As Integer, s As String
    
    ' show common dialog and allow selection of a song list file...
'    files.CancelError = True
'On Error GoTo cancelLoad
'    files.InitDir = App.Path
'    files.ShowOpen
'    f = FreeFile
'    Open files.filename For Input As f
'        Line Input #f, s
'        theSongList = Split(s, ",")
'        bListMode = True
'    Close f
'    songListIndex = 0
'    CURRENT_SONG = theSongList(0)
'    fScreen.Show 1
'cancelLoad:
End Sub

Private Sub mnuExit_Click()
    Dim f As Form
    
    For Each f In Forms
        Unload f
    Next f
End Sub

Private Sub mnuLoad_Click()
    ' get the songfile to load
'    files.CancelError = True
'On Error GoTo cancelOpen
'    files.InitDir = App.Path
'    files.ShowOpen
'    fSongList.SongFile = files.filename
'    fSongList.Show 1
'    Exit Sub
'cancelOpen:
End Sub

Private Sub mnuNew_Click()
    fSongList.Show 1
End Sub

Private Sub SSTab1_Click(PreviousTab As Integer)
    Dim i As Integer

On Error GoTo skipTab
    List1.Clear
    If SSTab1.Tab = 26 Then
        ' all tab so list all songs...
        For i = 1 To UBound(Songs)
            List1.AddItem Songs(i).title
            List1.ItemData(List1.NewIndex) = i
        Next i
    Else
        For i = 1 To UBound(Songs)
            If Mid(Songs(i).title, 1, 1) = Chr(Asc("A") + SSTab1.Tab) Then
                List1.AddItem Songs(i).title
                List1.ItemData(List1.NewIndex) = i
            End If
        Next i
    End If
    List1.ListIndex = 0
    Exit Sub
skipTab:
    MsgBox "There are no songs that begin with the letter " & Chr(Asc("A") + SSTab1.Tab)
    'SSTab1.Tab = PreviousTab
End Sub

