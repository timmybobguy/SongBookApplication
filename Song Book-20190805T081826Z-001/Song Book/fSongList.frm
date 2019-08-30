VERSION 5.00
Begin VB.Form fSongList 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Create Song List"
   ClientHeight    =   7650
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   10410
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7650
   ScaleWidth      =   10410
   StartUpPosition =   3  'Windows Default
   Begin VB.PictureBox Picture1 
      BorderStyle     =   0  'None
      Height          =   6375
      Left            =   240
      ScaleHeight     =   6375
      ScaleWidth      =   9735
      TabIndex        =   1
      Top             =   1080
      Width           =   9735
      Begin VB.CommandButton Command3 
         Caption         =   "Add To List"
         Height          =   390
         Left            =   6840
         TabIndex        =   9
         Top             =   3480
         Width           =   2565
      End
      Begin VB.ListBox List1 
         Height          =   5910
         Left            =   0
         Sorted          =   -1  'True
         TabIndex        =   8
         Top             =   0
         Width           =   3540
      End
      Begin VB.TextBox Text1 
         Height          =   3135
         Left            =   3765
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         ScrollBars      =   3  'Both
         TabIndex        =   7
         Top             =   0
         Width           =   5610
      End
      Begin VB.ListBox List2 
         Height          =   2400
         Left            =   3765
         TabIndex        =   6
         Top             =   3525
         Width           =   2850
      End
      Begin VB.CommandButton Command1 
         Caption         =   "&Save List"
         Height          =   345
         Left            =   6840
         TabIndex        =   5
         Top             =   5520
         Width           =   2550
      End
      Begin VB.CommandButton Command2 
         Caption         =   "Remove from List"
         Height          =   390
         Left            =   6840
         TabIndex        =   4
         Top             =   3885
         Width           =   2565
      End
      Begin VB.CommandButton Command4 
         Caption         =   "Move Song Up"
         Height          =   375
         Left            =   6840
         TabIndex        =   3
         Top             =   4290
         Width           =   2565
      End
      Begin VB.CommandButton Command5 
         Caption         =   "Move Song Down"
         Height          =   390
         Left            =   6840
         TabIndex        =   2
         Top             =   4710
         Width           =   2565
      End
      Begin VB.Label Label1 
         AutoSize        =   -1  'True
         Caption         =   "Song List"
         Height          =   195
         Left            =   3840
         TabIndex        =   10
         Top             =   3240
         Width           =   660
      End
   End
   Begin VB.PictureBox SSTab1 
      Height          =   7335
      Left            =   120
      ScaleHeight     =   7275
      ScaleWidth      =   10065
      TabIndex        =   0
      Top             =   240
      Width           =   10125
   End
   Begin VB.PictureBox files 
      Height          =   480
      Left            =   4920
      ScaleHeight     =   420
      ScaleWidth      =   1140
      TabIndex        =   11
      Top             =   3600
      Width           =   1200
   End
End
Attribute VB_Name = "fSongList"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Public SongFile As String
Private songList As Variant

Private Function cleanString(ByVal s As String) As String
    Dim ss As String
    
    ss = s
    
    ss = Replace(ss, "&apos;", "'")
    ss = Replace(ss, ",", "")
    ss = Replace(ss, ";", "")
    cleanString = ss
End Function

Private Sub Command1_Click()
    Dim f As Long, i As Integer
    Dim filename As String
    
    'show commondialog and allow naming of file...
    files.CancelError = True
On Error GoTo CancelSave
    files.DefaultExt = "slf"
    files.Filter = "Song Lisf Files|*.slf"
    files.DialogTitle = "Save Song List As"
    files.InitDir = App.Path
    files.ShowSave
    filename = files.filename
    ' save the song list to a file
    f = FreeFile
    Open filename For Output As f
        For i = 0 To List2.ListCount - 1
           Print #f, List2.ItemData(i) & IIf(i = List2.ListCount - 1, "", ",");
        Next i
CancelSave:
    Close f
End Sub

Private Sub Command2_Click()
    If List2.ListIndex <> -1 Then
        List2.RemoveItem List2.ListIndex
    End If
End Sub


Private Sub Form_Deactivate()
'    List2.Clear
End Sub

Private Sub Form_Initialize()
'    List2.Clear
End Sub

Private Sub Form_Load()
    Dim f As Long, s As String, i As Integer
    
    List1.Clear
    For i = LBound(Songs) To UBound(Songs)
        List1.AddItem Songs(i).title
        List1.ItemData(List1.NewIndex) = i + 1
    Next i
    
    
    List2.Clear
    If SongFile <> "" Then
        ' we need to load the song file into the list...
        f = FreeFile
        Open SongFile For Input As f
            Line Input #f, s
            songList = Split(s, ",")
            For i = 0 To UBound(songList)
                List2.AddItem Songs(songList(i)).title
                List2.ItemData(List2.NewIndex) = CInt(songList(i))
            Next i
        Close f
    End If
End Sub

Private Sub Form_Resize()
'    List2.Clear
End Sub

Private Sub Form_Terminate()
'    List2.Clear
End Sub

Private Sub Form_Unload(Cancel As Integer)
'    List2.Clear
End Sub

Private Sub List1_DblClick()
    List2.AddItem List1.Text
    List2.ItemData(List2.NewIndex) = List1.ItemData(List1.ListIndex)
End Sub

Private Sub List2_GotFocus()
'    Command2.Enabled = True
End Sub

Private Sub List2_LostFocus()
'    Command2.Enabled = False
'    List2.ListIndex = -1
End Sub

Private Sub SSTab1_Click(PreviousTab As Integer)
    Dim i As Integer
    
On Error GoTo skipTab
    With List1
        .Clear
        For i = 1 To UBound(Songs)
            If Mid(Songs(i).title, 1, 1) = Chr(Asc("A") + SSTab1.Tab) Then
                .AddItem Songs(i).title
                .ItemData(.NewIndex) = i
'                If Songs(i).selected Then .selected(.NewIndex) = True
            End If
        Next i
        .ListIndex = 0
    End With
    Exit Sub
skipTab:
    MsgBox "There are no songs that begin with the letter " & Chr(Asc("A") + SSTab1.Tab)
    SSTab1.Tab = PreviousTab
End Sub

Private Sub List1_Click()
    CURRENT_SONG = List1.ItemData(List1.ListIndex)
    Text1.Text = cleanString(Songs(CURRENT_SONG).body)
End Sub


