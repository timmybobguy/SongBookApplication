Attribute VB_Name = "mSong"
Option Explicit

Public Type THIS_SONG
    verse() As String
    chorus As String
    thisVerse As Integer
    bHasChorus As Boolean
    bInChorus As Boolean
End Type

Public song As THIS_SONG
Public bNewSong As Boolean
