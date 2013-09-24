﻿'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
'* Copyright (C) 2013 Namcore Studio <https://github.com/megasus/Namcore-Studio>
'*
'* This program is free software; you can redistribute it and/or modify it
'* under the terms of the GNU General Public License as published by the
'* Free Software Foundation; either version 2 of the License, or (at your
'* option) any later version.
'*
'* This program is distributed in the hope that it will be useful, but WITHOUT
'* ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
'* FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
'* more details.
'*
'* You should have received a copy of the GNU General Public License along
'* with this program. If not, see <http://www.gnu.org/licenses/>.
'*
'* Developed by Alcanmage/megasus
'*
'* //FileInfo//
'*      /Filename:      ReputationParser
'*      /Description:   Contains functions for loading character reputation information from 
'*                      wow armory
'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
Imports System.Net
Imports NCFramework.Framework.Logging
Imports NCFramework.Framework.Functions
Imports NCFramework.Framework.Extension
Imports NCFramework.Framework.Modules

Namespace Framework.Armory.Parser

    Public Class ReputationParser
        Public Sub LoadReputation(ByVal setId As Integer, ByVal apiLink As String)
            Dim client As New WebClient
            client.CheckProxy()
            '// Retrieving character
            Dim player As Character = GetCharacterSetBySetId(setId)
            player.PlayerReputation = New List(Of Reputation)
            Try
                LogAppend("Loading character reputation information", "ReputationParser_loadReputation", True)
                Dim reputationContext As String = client.DownloadString(apiLink & "?fields=reputation")
                If reputationContext Is Nothing Then
                    LogAppend("Failed to load Reputation API", "ReputationParser_loadReputation", False, True)
                    Exit Sub
                Else
                    LogAppend("reputationContext loaded - length is: " & reputationContext.Length.ToString(),
                              "ReputationParser_loadReputation", False)
                End If
                reputationContext = splitString(reputationContext, """reputation"":[", "]")
                If reputationContext.Length > 5 Then '// Not confirmed if properly working TODO
                    Dim exCount As Integer = UBound(Split(reputationContext, ",{"))
                    reputationContext = reputationContext.Replace(",{", "§")
                    Dim parts() As String = reputationContext.Split("§"c)
                    Dim loopcounter As Integer = 0
                    Do
                        Dim rep As New Reputation
                        Try
                            Dim factionId As String = splitString(parts(loopcounter), """id"":", ",")
                            LogAppend("Now adding fation with id: " & factionId, "ReputationParser_loadReputation", False)
                            Dim standing As Integer = TryInt(splitString(parts(loopcounter), """value"":", ","))
                            Dim orgstanding As Integer = TryInt(splitString(parts(loopcounter), """standing"":", ","))
                            rep.status = orgstanding
                            rep.max = TryInt(splitString(parts(loopcounter), """max"":", "}"))
                            rep.value = standing
                            loopcounter += 1
                            If orgstanding > 3 Then standing += 3000
                            If orgstanding > 4 Then standing += 6000
                            If orgstanding > 5 Then standing += 12000
                            If orgstanding > 6 Then standing += 21000
                            LogAppend("Adding reputation (factionID/standing):(" & factionId & "/" & standing.ToString & ")",
                                      "ReputationParser_loadReputation", False)
                            rep.faction = TryInt(factionId)
                            rep.standing = TryInt(standing)
                            rep.name = splitString(parts(loopcounter), """name"":""", """,")
                            rep.flags = 1
                            player.PlayerReputation.Add(rep)
                        Catch ex As Exception
                            loopcounter += 1
                            LogAppend("Something went wrong! -> Exception is: ###START###" & ex.ToString() & "###END###",
                                      "ReputationParser_loadReputation", False, True)
                        End Try
                    Loop Until loopcounter = exCount
                    '// Saving changes to character
                    SetCharacterSet(setId, player)
                End If
            Catch ex As Exception
                LogAppend("Something went wrong! -> Exception is: ###START###" & ex.ToString() & "###END###",
                          "ReputationParser_loadReputation", False, True)
            End Try
        End Sub
    End Class
End Namespace