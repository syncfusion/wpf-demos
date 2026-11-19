Option Explicit

Function GetHostAliases(strHostFile,strIP)

Const fileRead = 1

Dim objFSO , objFlagFile 
Dim strLine, arrHostEnteries , strHostAliases, i

Dim Seps(2)

strHostAliases = ""

Seps(0) = " "
Seps(1) = vbTab 

Set objFSO = CreateObject("Scripting.FileSystemObject")
If objFSO.FileExists( strHostFile ) Then
    Set objFlagFile = objFSO.OpenTextFile(strHostFile ,fileRead)
    Do While Not objFlagFile.AtEndOfStream
           strLine = UCase(Trim(objFlagFile.ReadLine))
           If strLine <> "" AND Left(strLine,1) <> "#" Then
               If InStr(strLine, "#") > 0 Then
                   strLine = Left(strLine,InStr(strLine, "#") - 1)
               End If
               arrHostEnteries = Tokenize( strLine , Seps )
               If( UBound( arrHostEnteries ) > 0 ) Then
                   If arrHostEnteries(0) = UCase(Trim(strIP)) Then
                       For i = (LBound( arrHostEnteries ) + 1) _
                         To (UBound( arrHostEnteries ) - 1)
                           strHostAliases = _
                             strHostAliases & arrHostEnteries(i) & " "
                       Next 
                   End If 
               End If
             End If
      Loop
      objFlagFile.Close
End If
    GetHostAliases = Tokenize( Trim(strHostAliases) , Seps )
End Function

Sub DelHostEntry(strHostFile,strIP)

 Const fileRead = 1
 Const fileWrite = 2
 Const fileAppend = 8
 Const SPACES = 20

 Dim objFSO , objFlagFile
 Dim strLine, strNewHostFile , strNewHostLine, arrHostEnteries, i
 Dim nNameLen
 Dim nAddSpaces

 Dim Seps(2)

 Seps(0) = " "
 Seps(1) = vbTab 
 
 strNewHostFile = ""
 strNewHostLine = ""

 Set objFSO = CreateObject("Scripting.FileSystemObject")
 If objFSO.FileExists( strHostFile ) Then
    Set objFlagFile = objFSO.OpenTextFile(strHostFile ,fileRead)
    Do While Not objFlagFile.AtEndOfStream
           strLine = UCase(Trim(objFlagFile.ReadLine))
           If strLine <> "" AND Left(strLine,1) <> "#" Then
                 arrHostEnteries = Tokenize( strLine , Seps )
                 If UBound( arrHostEnteries ) > 0 Then
                   If UBound( arrHostEnteries ) = 1 OR arrHostEnteries(0) = _
                      UCase(Trim(strIP)) Then ' Check for Aliases _
                      and remove it not correct
                       strNewHostLine = ""
                   Else
                       nNameLen = Len(arrHostEnteries(0))
                       nAddSpaces = SPACES - nNameLen
                       strNewHostLine = arrHostEnteries(0) & Space(nAddSpaces)
                       For i = (LBound( arrHostEnteries ) + 1) _
                                To (UBound( arrHostEnteries ) - 1)
                           strNewHostLine = strNewHostLine & " " & arrHostEnteries(i)
                       Next 
                   End If
               End If 

               If strNewHostLine <> "" Then
                   strNewHostFile = strNewHostFile & strNewHostLine & vbCRLF
            End If
            
        Else ' Comments and Blank Lines Added Here
               strNewHostLine = strLine
               strNewHostFile = strNewHostFile & strNewHostLine & vbCRLF
        End If
        strNewHostLine = ""
      Loop
      objFlagFile.Close
 End If

 Set objFlagFile = objFSO.OpenTextFile(strHostFile ,fileWrite)
 objFlagFile.Write strNewHostFile
 objFlagFile.Close
 
End Sub

Sub DelHostAlias(strHostFile,strHost)

 Const fileRead = 1
 Const fileWrite = 2
 Const fileAppend = 8
 Const SPACES = 20

 Dim objFSO , objFlagFile
 Dim strLine, strNewHostFile , strComment, strNewHostLine, arrHostEnteries, i
 Dim Seps(2)

 Dim nNameLen
 Dim nAddSpaces

 Seps(0) = " "
 Seps(1) = vbTab

 strComment = ""
 strNewHostFile = ""
 strNewHostLine = ""
   
 Set objFSO = CreateObject("Scripting.FileSystemObject")

 If objFSO.FileExists( strHostFile ) Then
    Set objFlagFile = objFSO.OpenTextFile(strHostFile ,fileRead)
    Do While Not objFlagFile.AtEndOfStream
           strLine = UCase(Trim(objFlagFile.ReadLine))
           If strLine <> "" AND Left(strLine,1) <> "#" Then
               If InStr(strLine, "#") > 0 Then
                   strComment = " " & Right( strLine , _
                       Len( strLine ) - InStr(strLine, "#") + 1 )
                   strLine = Left(strLine,InStr(strLine, "#") - 1)
               Else
                   strComment = ""
            End If
                 arrHostEnteries = Tokenize( strLine , Seps )
                 If UBound( arrHostEnteries ) > 0 Then
                     nNameLen = Len(arrHostEnteries(0))
                   nAddSpaces = SPACES - nNameLen
                     strNewHostLine = arrHostEnteries(0) & Space(nAddSpaces)
                   If UBound( arrHostEnteries ) = 1 Then
                       strNewHostLine = ""
                       strComment = ""
                   Else
                       For i = (LBound( arrHostEnteries ) + 1) _
                               To (UBound( arrHostEnteries ) - 1)
                           If arrHostEnteries(i) <> UCase(Trim(strHost)) Then
                               strNewHostLine = strNewHostLine _
                                         & " " & arrHostEnteries(i)
                           ElseIf UBound( arrHostEnteries ) = 2 Then
                               strNewHostLine = ""
                               strComment = ""
                           End If
                          Next 
                      End If
               End If 

               If strNewHostLine <> "" Then
                   strNewHostFile = strNewHostFile & _
                          strNewHostLine & strComment & vbCRLF
            End If

        Else ' Comments and Blank Lines Added Here
               strNewHostLine = strLine
               strNewHostFile = strNewHostFile & strNewHostLine & vbCRLF
        End If
        strNewHostLine = ""
      Loop
      objFlagFile.Close
 End If

 Set objFlagFile = objFSO.OpenTextFile(strHostFile ,fileWrite)
 objFlagFile.Write strNewHostFile
 objFlagFile.Close

End Sub

Sub AddHostAlias(strHostFile,strHost,strIP)
 Const fileRead = 1
 Const fileWrite = 2
 Const fileAppend = 8
 Const SPACES = 20

 Dim objFSO , objFlagFile
 Dim strLine, strHostEntry, strNewHostFile , strNewHostLine, _
    strComment, bFound, bOmitRemainder, arrHostEnteries, i
 Dim Seps(2)

 Dim nNameLen
 Dim nAddSpaces

 Seps(0) = " "
 Seps(1) = vbTab 

 bFound = False
 bOmitRemainder = False

 strComment = ""
 strNewHostFile = ""
 strNewHostLine = ""

 Set objFSO = CreateObject("Scripting.FileSystemObject")

 If objFSO.FileExists( strHostFile ) Then

  Set objFlagFile = objFSO.OpenTextFile(strHostFile ,fileRead)
  Do While Not objFlagFile.AtEndOfStream
       strLine = UCase(Trim(objFlagFile.ReadLine))
       If strLine <> "" AND Left(strLine,1) <> "#" Then
           If InStr(strLine, "#") > 0 Then
               strComment = " " & Right( strLine , _
                  Len( strLine ) - InStr(strLine, "#") + 1 )
               strLine = Left(strLine,InStr(strLine, "#") - 1)
           Else
               strComment = ""
           End If
           arrHostEnteries = Tokenize( strLine , Seps )
           If UBound( arrHostEnteries ) > 0 Then
               nNameLen = Len(arrHostEnteries(0))
               nAddSpaces = SPACES - nNameLen
                 strNewHostLine = arrHostEnteries(0) & Space(nAddSpaces)
               If arrHostEnteries(0) = UCase(Trim(strIP)) Then
               'Check the entries for certain IP...
                   For i = (LBound( arrHostEnteries ) + 1) _
                            To (UBound( arrHostEnteries ) - 1)
                       If arrHostEnteries(i) = UCase(Trim(strHost)) Then
                           bFound    = True
                           strNewHostLine = strNewHostLine _
                                  & " " & UCase(Trim(strHost))
                       Else
                           strNewHostLine = strNewHostLine _
                                    & " " & arrHostEnteries(i)
                       End If
                   Next

                   If Not bFound Then
                       strNewHostLine = strNewHostLine _
                              & " " & UCase(Trim(strHost))
                       bFound = True
                   End If

               Else 'Check if it exist in different IP ranges and remove them
                   If UBound( arrHostEnteries ) = 1 Then
                       strNewHostLine = ""
                       strComment = ""
                   Else
                       For i = (LBound( arrHostEnteries ) + 1) _
                                To (UBound( arrHostEnteries ) - 1)
                           If arrHostEnteries(i) <> UCase(Trim(strHost)) Then
                               strNewHostLine = strNewHostLine _
                                        & " " & arrHostEnteries(i)
                           ElseIf UBound( arrHostEnteries ) = 2 Then
                               strNewHostLine = ""
                               strComment = ""
                           End If
                          Next 
                      End If
               End If 
           End If 
           If strNewHostLine <> "" Then
               strNewHostFile = strNewHostFile & _
                      strNewHostLine & strComment & vbCRLF
        End If
       Else ' Comments and Blank Lines Added Here
           strNewHostLine = strLine
           strNewHostFile = strNewHostFile & strNewHostLine & vbCRLF
    End If
    strNewHostLine = ""
  Loop
  objFlagFile.Close
  
  If Not bFound Then
      strNewHostLine = UCase(Trim(strIP)) & "       "_
                  & UCase(Trim(strHost)) & vbCRLF
      strNewHostFile = strNewHostFile & strNewHostLine
  End If 

 Else ' File doesn't exist so create it and write
      strNewHostFile = UCase(Trim(strIP)) & _
             "       " & UCase(Trim(strHost)) 
 End If

 Set objFlagFile = objFSO.OpenTextFile(strHostFile ,fileWrite)
objFlagFile.Write strNewHostFile
 objFlagFile.Close
  
End Sub

Function Tokenize(byVal TokenString, byRef TokenSeparators())

    Dim NumWords, a(), i
    NumWords = 0

    Dim NumSeps
    NumSeps = UBound(TokenSeparators)

    Do 
        Dim SepIndex, SepPosition
        SepPosition = 0
        SepIndex    = -1

        for i = 0 to NumSeps-1

            ' Find location of separator in the string
            Dim pos
            pos = InStr(TokenString, TokenSeparators(i))

            ' Is the separator present, and is it closest
            ' to the beginning of the string?
            If pos > 0 and ( (SepPosition = 0) or _
                     (pos < SepPosition) ) Then
                SepPosition = pos
                SepIndex    = i
            End If

        Next

        ' Did we find any separators?
        If SepIndex < 0 Then

            ' None found - so the token is the remaining string
            redim preserve a(NumWords+1)
            a(NumWords) = TokenString

        Else

            ' Found a token - pull out the substring
            Dim substr
            substr = Trim(Left(TokenString, SepPosition-1))

            ' Add the token to the list
            redim preserve a(NumWords+1)
            a(NumWords) = substr

            ' Cutoff the token we just found
            Dim TrimPosition
            TrimPosition = SepPosition+Len(TokenSeparators(SepIndex))
            TokenString = Trim(Mid(TokenString, TrimPosition))

        End If    

        NumWords = NumWords + 1
    loop while (SepIndex >= 0)

    Tokenize = a

End Function