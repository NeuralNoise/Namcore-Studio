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
'*      /Filename:      CharacterSkillsHandler
'*      /Description:   Contains functions for extracting information about the skills of a
'*                      specific character
'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

Imports Namcore_Studio.EventLogging
Imports Namcore_Studio.Basics
Imports Namcore_Studio.GlobalVariables
Imports Namcore_Studio.CommandHandler
Imports Namcore_Studio.Conversions
Public Class CharacterSkillsHandler
    Public Shared Sub GetCharacterSkills(ByVal characterGuid As Integer, ByVal setId As Integer, ByVal accountId As Integer)
        LogAppend("Loading character skills for characterGuid: " & characterGuid & " and setId: " & setId, "CharacterSkillsHandler_GetCharacterSkills", True)
        Select Case sourceCore
            Case "arcemu"
                loadAtArcemu(characterGuid, setId, accountId)
            Case "trinity"
                loadAtTrinity(characterGuid, setId, accountId)
            Case "trinitytbc"
                loadAtTrinityTBC(characterGuid, setId, accountId)
            Case "mangos"
                loadAtMangos(characterGuid, setId, accountId)
            Case Else

        End Select

    End Sub
    Private Shared Sub loadAtArcemu(ByVal charguid As Integer, ByVal tar_setId As Integer, ByVal tar_accountId As Integer)
        LogAppend("Loading character skills @loadAtArcemu", "CharacterSkillsHandler_loadAtArcemu", False)
        Dim tempdt As DataTable = ReturnDataTable("SELECT skills FROM characters WHERE guid='" & charguid.ToString() & "'")
        Dim templist As New List(Of String)
        Try
            Dim lastcount As Integer = tryint(Val(tempdt.Rows.Count.ToString))
            Dim count As Integer = 0
            If Not lastcount = 0 Then
                Do
                    Dim readedcode As String = (tempdt.Rows(count).Item(0)).ToString
                    Dim excounter As Integer = UBound(readedcode.Split(CChar(";")))
                    Dim loopcounter As Integer = 0
                    Dim finalcounter As Integer = tryint(excounter / 3)
                    Dim partscounter As Integer = 0
                    Do
                        Dim parts() As String = readedcode.Split(","c)
                        Dim skill As String = parts(partscounter).ToString
                        partscounter += 1
                        Dim value As String = parts(partscounter).ToString
                        partscounter += 1
                        Dim max As String = parts(partscounter).ToString
                        partscounter += 1
                        templist.Add("<skill>" & skill & "</skill><value>" & value & "</value><max>" & max & "</max>")
                        loopcounter += 1
                    Loop Until loopcounter = finalcounter
                    count += 1
                Loop Until count = lastcount
            Else
                LogAppend("No skills found!", "CharacterSkillsHandler_loadAtArcemu", True)
            End If
        Catch ex As Exception
            LogAppend("Something went wrong while loading character skills! -> skipping -> Exception is: ###START###" & ex.ToString() & "###END###", "CharacterSkillsHandler_loadAtArcemu", True, True)
            Exit Sub
        End Try
        SetTemporaryCharacterInformation("@character_skills", ConvertListToString(templist), tar_setId)
    End Sub
    Private Shared Sub loadAtTrinity(ByVal charguid As Integer, ByVal tar_setId As Integer, ByVal tar_accountId As Integer)
        LogAppend("Loading character skills @loadAtTrinity", "CharacterSkillsHandler_loadAtTrinity", False)
        Dim tempdt As DataTable = ReturnDataTable("SELECT skill, `value`, max FROM character_skills WHERE guid='" & charguid.ToString() & "'")
        Dim templist As New List(Of String)
        Try
            Dim lastcount As Integer = tryint(Val(tempdt.Rows.Count.ToString))
            Dim count As Integer = 0
            If Not lastcount = 0 Then
                Do
                    Dim skill As String = (tempdt.Rows(count).Item(0)).ToString
                    Dim value As String = (tempdt.Rows(count).Item(1)).ToString
                    Dim max As String = (tempdt.Rows(count).Item(2)).ToString
                    templist.Add("<skill>" & skill & "</skill><value>" & value & "</value><max>" & max & "</max>")
                    count += 1
                Loop Until count = lastcount
            Else
                LogAppend("No skills found!", "CharacterSkillsHandler_loadAtTrinity", True)
            End If
        Catch ex As Exception
            LogAppend("Something went wrong while loading character skills! -> skipping -> Exception is: ###START###" & ex.ToString() & "###END###", "CharacterSkillsHandler_loadAtTrinity", True, True)
            Exit Sub
        End Try
        SetTemporaryCharacterInformation("@character_skills", ConvertListToString(templist), tar_setId)
    End Sub
    Private Shared Sub loadAtTrinityTBC(ByVal charguid As Integer, ByVal tar_setId As Integer, ByVal tar_accountId As Integer)

    End Sub
    Private Shared Sub loadAtMangos(ByVal charguid As Integer, ByVal tar_setId As Integer, ByVal tar_accountId As Integer)
        LogAppend("Loading character skills @loadAtMangos", "CharacterSkillsHandler_loadAtMangos", False)
        Dim tempdt As DataTable = ReturnDataTable("SELECT skill, `value`, max FROM character_skills WHERE guid='" & charguid.ToString() & "'")
        Dim templist As New List(Of String)
        Try
            Dim lastcount As Integer = tryint(Val(tempdt.Rows.Count.ToString))
            Dim count As Integer = 0
            If Not lastcount = 0 Then
                Do
                    Dim skill As String = (tempdt.Rows(count).Item(0)).ToString
                    Dim value As String = (tempdt.Rows(count).Item(1)).ToString
                    Dim max As String = (tempdt.Rows(count).Item(2)).ToString
                    templist.Add("<skill>" & skill & "</skill><value>" & value & "</value><max>" & max & "</max>")
                    count += 1
                Loop Until count = lastcount
            Else
                LogAppend("No skills found!", "CharacterSkillsHandler_loadAtMangos", True)
            End If
        Catch ex As Exception
            LogAppend("Something went wrong while loading character skills! -> skipping -> Exception is: ###START###" & ex.ToString() & "###END###", "CharacterSkillsHandler_loadAtMangos", True, True)
            Exit Sub
        End Try
        SetTemporaryCharacterInformation("@character_skills", ConvertListToString(templist), tar_setId)
    End Sub
End Class