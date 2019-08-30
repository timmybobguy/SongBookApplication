VERSION 5.00
Begin VB.Form fEdit 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Edit Song"
   ClientHeight    =   7050
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   4725
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7050
   ScaleWidth      =   4725
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton Command2 
      Caption         =   "&Save"
      Height          =   435
      Left            =   2475
      TabIndex        =   6
      Top             =   6480
      Width           =   1005
   End
   Begin VB.CommandButton Command1 
      Caption         =   "&Cancel"
      Height          =   435
      Left            =   3570
      TabIndex        =   5
      Top             =   6480
      Width           =   1005
   End
   Begin VB.ComboBox cmbKey 
      Height          =   315
      ItemData        =   "fEdit.frx":0000
      Left            =   135
      List            =   "fEdit.frx":0037
      Style           =   2  'Dropdown List
      TabIndex        =   4
      Top             =   915
      Width           =   4410
   End
   Begin VB.TextBox Text2 
      Height          =   360
      Left            =   105
      TabIndex        =   1
      Top             =   285
      Width           =   4440
   End
   Begin VB.TextBox Text1 
      Height          =   4875
      Left            =   120
      MultiLine       =   -1  'True
      ScrollBars      =   3  'Both
      TabIndex        =   0
      Top             =   1515
      Width           =   4410
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      Caption         =   "Song number: "
      Height          =   195
      Left            =   120
      TabIndex        =   8
      Top             =   6660
      Width           =   1035
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "Song"
      Height          =   195
      Index           =   2
      Left            =   120
      TabIndex        =   7
      Top             =   1320
      Width           =   375
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "Key"
      Height          =   195
      Index           =   1
      Left            =   135
      TabIndex        =   3
      Top             =   720
      Width           =   270
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "Title"
      Height          =   195
      Index           =   0
      Left            =   105
      TabIndex        =   2
      Top             =   90
      Width           =   300
   End
End
Attribute VB_Name = "fEdit"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim newSongNumber As Long

Private Sub Command1_Click()
    Unload Me
End Sub

Private Sub Command2_Click()
    If bNewSong Then
        SONGS_COUNT = UBound(Songs) + 1
        ReDim Preserve Songs(1 To SONGS_COUNT)
        CURRENT_SONG = SONGS_COUNT
        Songs(CURRENT_SONG).num = newSongNumber
    End If
    Songs(CURRENT_SONG).title = Text2.Text
    Songs(CURRENT_SONG).body = Text1.Text
    Songs(CURRENT_SONG).key = cmbKey.Text
    DB2XML App.Path & "\songs_new.xml"
    Unload Me
End Sub

Private Sub Form_Load()
    Dim i As Integer, n As Long
    
    If Not bNewSong Then
        Text2.Text = Songs(CURRENT_SONG).title
        Text1.Text = Songs(CURRENT_SONG).body
        Label2.Caption = "Song number: " & Songs(CURRENT_SONG).num
    Else
        n = 0
        For i = 1 To UBound(Songs)
            If Songs(i).num > n Then n = Songs(i).num
        Next i
        newSongNumber = n
        Label2.Caption = "Song number: " & newSongNumber
    End If
End Sub
