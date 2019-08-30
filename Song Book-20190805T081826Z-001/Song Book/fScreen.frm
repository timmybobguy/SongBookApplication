VERSION 5.00
Begin VB.Form fScreen 
   AutoRedraw      =   -1  'True
   BackColor       =   &H00000000&
   BorderStyle     =   0  'None
   Caption         =   "screen"
   ClientHeight    =   9000
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   12000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   Picture         =   "fScreen.frx":0000
   ScaleHeight     =   600
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   800
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   WindowState     =   2  'Maximized
   Begin VB.Label bodyText 
      AutoSize        =   -1  'True
      BackColor       =   &H00000000&
      BackStyle       =   0  'Transparent
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   26.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   615
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   10455
      WordWrap        =   -1  'True
   End
   Begin VB.Image Image1 
      Height          =   11520
      Left            =   7260
      Picture         =   "fScreen.frx":2E800
      Stretch         =   -1  'True
      Top             =   5175
      Width           =   18435
   End
End
Attribute VB_Name = "fScreen"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub prepareSong()
    'load the current song into THIS_SONG structure...
    Dim l As Long, ll As Long, n As Integer
    Dim ss As String, s As String, v As String
    
    l = 1
    ll = 0
    n = 0
    
    With Songs(CURRENT_SONG)
        ss = filterString(.body)
        song.bHasChorus = IIf(InStr(1, .body, "CHORUS") = 0, False, True)
        song.thisVerse = 1
        song.bInChorus = False
        If song.bHasChorus Then
            Do
                l = InStr(l, ss, vbCrLf & vbCrLf)
                If l = 0 Then
                    n = n + 1
                    ReDim Preserve song.verse(1 To n)
                    song.verse(n) = ss ' filterString(ss)
                    Exit Do
                End If
                v = Mid(ss, 1, l)
                If InStr(1, v, "CHORUS") <> 0 Then
                    song.chorus = Mid(Replace(v, "CHORUS", ""), 3) ' filterString(Replace(v, "CHORUS", ""))
                Else
                    n = n + 1
                    ReDim Preserve song.verse(1 To n)
                    song.verse(n) = v ' filterString(v)
                End If
                ss = Mid(ss, l + 4) '2)
                l = 1
                ''l = l + 4 '2
            Loop
        ElseIf InStr(1, ss, vbCrLf & vbCrLf) <> 0 Then
            ' get the verses...
            Do
                l = InStr(l, ss, vbCrLf & vbCrLf)
                If l = 0 Then
                    n = n + 1
                    ReDim Preserve song.verse(1 To n)
                    song.verse(n) = ss ' filterString(ss)
                    Exit Do
                End If
                v = Mid(ss, 1, l)
                n = n + 1
                ReDim Preserve song.verse(1 To n)
                song.verse(n) = v ' filterString(v)
                ss = Mid(ss, l + 4) '2)
                l = 1 ' l + 4 '2
            Loop
        Else
            ReDim song.verse(1 To 1)
            song.verse(1) = ss ' filterString(ss)
        End If
    End With
End Sub

Private Sub refreshView(ByVal s As String)
    With bodyText
       .Visible = False
        .Caption = s
        fScreen.Refresh
        .Refresh
        
'        .Height = fScreen.Height - (2 * (.Top * Screen.TwipsPerPixelY))
'        .Width = fScreen.Width - (2 * (.Left * Screen.TwipsPerPixelY))
        .Top = (fScreen.ScaleHeight - .Height) \ 2 '((fScreen.ScaleHeight * Screen.TwipsPerPixelY) - .Height) \ 2
        .Left = (fScreen.ScaleWidth - .Width) \ 2 '((fScreen.ScaleWidth * Screen.TwipsPerPixelX) - .Width) \ 2
        .Visible = True
    End With
End Sub

Private Sub Form_KeyPress(KeyAscii As Integer)
    Select Case KeyAscii
        Case Asc("P"), Asc("p")
            ' if we are in song list mode we to to the previous song...
                If songListIndex = 0 Then Exit Sub
                songListIndex = songListIndex - 1
                CURRENT_SONG = theSongList(songListIndex)
                prepareSong
                refreshView song.verse(1)
        Case Asc("N"), Asc("n")
            ' if we are in song list mode we go to the next song...
            If bListMode Then
                If songListIndex = UBound(theSongList) Then Exit Sub
                songListIndex = songListIndex + 1
                CURRENT_SONG = theSongList(songListIndex)
                prepareSong
                refreshView song.verse(1)
            End If
        Case vbKeyEscape: Unload Me
        Case vbKeyReturn, vbKeyLeft, vbKeyDown, vbKeyPageDown: ' Next Screen
            If song.thisVerse <> UBound(song.verse) Then
                If song.bHasChorus Then
                    If song.bInChorus Then
                        song.bInChorus = False
                        song.thisVerse = song.thisVerse + 1
                        refreshView song.verse(song.thisVerse)
                    Else
                        song.bInChorus = True
                        refreshView song.chorus
                    End If
                Else
                    song.thisVerse = song.thisVerse + 1
                    refreshView song.verse(song.thisVerse)
                End If
            Else
                ' song has reached the end so we show a blank screen...
                bodyText.Visible = False
            End If
        Case vbKeyBack, vbKeyRight, vbKeyUp, vbKeyPageUp: ' Previous Screen
            If song.thisVerse <> 1 Then
                If song.bHasChorus Then
                    If song.bInChorus Then
                        song.bInChorus = False
                        song.thisVerse = song.thisVerse - 1
                        refreshView song.verse(song.thisVerse)
                    Else
                        song.bInChorus = True
                        refreshView song.chorus
                    End If
                Else
                    song.thisVerse = song.thisVerse - 1
                    refreshView song.verse(song.thisVerse)
                End If
            End If
    End Select
End Sub

Private Function filterString(ByVal s As String) As String
    Dim ss As String
    
    ss = Replace(s, ",", "")
    ss = Replace(ss, "&apos;", "'")
    ss = Replace(ss, ";", "")
    filterString = ss
End Function

Private Sub Form_KeyUp(KeyCode As Integer, Shift As Integer)
    Select Case KeyCode
        Case vbKeyReturn, vbKeyLeft, vbKeyDown, vbKeyPageDown: ' Next Screen
            If song.thisVerse <> UBound(song.verse) Then
                If song.bHasChorus Then
                    If song.bInChorus Then
                        song.bInChorus = False
                        song.thisVerse = song.thisVerse + 1
                        refreshView song.verse(song.thisVerse)
                    Else
                        song.bInChorus = True
                        refreshView song.chorus
                    End If
                Else
                    song.thisVerse = song.thisVerse + 1
                    refreshView song.verse(song.thisVerse)
                End If
            Else
                ' song has reached the end so we show a blank screen...
                bodyText.Visible = False
            End If
        Case vbKeyBack, vbKeyRight, vbKeyUp, vbKeyPageUp: ' Previous Screen
            If song.thisVerse <> 1 Then
                If song.bHasChorus Then
                    If song.bInChorus Then
                        song.bInChorus = False
                        song.thisVerse = song.thisVerse - 1
                        refreshView song.verse(song.thisVerse)
                    Else
                        song.bInChorus = True
                        refreshView song.chorus
                    End If
                Else
                    song.thisVerse = song.thisVerse - 1
                    refreshView song.verse(song.thisVerse)
                End If
            End If
    End Select
End Sub

Private Sub Form_Load()
    prepareSong
    ' force screen to refresh view as maximized (fullscreen)
    fScreen.Width = Screen.Width
    fScreen.Height = Screen.Height
    fScreen.Refresh
    Image1.Top = 0
    Image1.Left = 0
    Image1.Width = fScreen.ScaleWidth
    Image1.Height = fScreen.ScaleHeight
'    bodyText.Width = Screen.Width
  'now show the first verse
    refreshView song.verse(1)
End Sub
