'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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
'*      /Filename:      GlobalVariables
'*      /Description:   This file contains the main variables
'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

Imports MySql.Data.MySqlClient
Public Class GlobalVariables
    Public Shared temporaryCharacterInformation As String
    Public Shared sourceCore As String '"arcemu", "trinity", "mangos"
    Public Shared targetCore As String '"arcemu", "trinity", "mangos"
    Public Shared expansion As Integer '1=classic, 2=tbc,...
    Public Shared eventlog As String
    Public Shared eventlog_full As String
    Public Shared effectname_dt As DataTable
    Public Shared GlobalConnection As New MySqlConnection
    Public Shared GlobalConnection_Realm As New MySqlConnection
    Public Shared TargetConnection As New MySqlConnection
    Public Shared TargetConnection_Realm As New MySqlConnection
    Public Shared GlobalConnectionString As String
    Public Shared GlobalConnectionString_Realm As String
    Public Shared TargetConnectionString As String
    Public Shared TargetConnectionString_Realm As String
    Public Shared TargetConnRealmDBname As String
    Public Shared TargetConnCharactersDBname As String
    Public Shared characterGUID As Integer
    Public Shared acctable As DataTable
    Public Shared chartable As DataTable
    Public Shared modifiedAccTable As DataTable
    Public Shared modifiedCharTable As DataTable
    Public Shared con_operator As Integer
    Public Shared trans_charlist As ArrayList
    Public Shared trans_acclist As ArrayList
    'DB table names
    '# Character DB
    Public Shared character_tablename As String
    Public Shared character_homebind_tablename As String
    '# Realm DB
    Public Shared account_tablename As String
    Public Shared accountAccess_tablename As String


    'DB column names
    '# Character DB
    '## Character Table
    Public Shared char_race_columnname As String
    Public Shared char_class_columnname As String
    Public Shared char_gender_columnname As String
    Public Shared char_guid_columnname As String
    Public Shared char_level_columnname As String
    Public Shared char_name_columnname As String
    Public Shared char_accountId_columnname As String
    Public Shared char_xp_columnname As String
    Public Shared char_gold_columnname As String
    Public Shared char_playerBytes_columnname As String
    Public Shared char_playerBytes2_columnname As String
    Public Shared char_playerFlags_columnname As String
    Public Shared char_posX_columnname As String
    Public Shared char_posY_columnname As String
    Public Shared char_posZ_columnname As String
    Public Shared char_map_columnname As String
    Public Shared char_instanceId_columnname As String
    Public Shared char_orientation_columnname As String
    Public Shared char_taximask_columnname As String
    Public Shared char_cinematic_columnname As String
    Public Shared char_totaltime_columnname As String
    Public Shared char_leveltime_columnname As String
    Public Shared char_stableSlots_columnname As String
    Public Shared char_zone_columnname As String
    Public Shared char_arenaPoints_columnname As String
    Public Shared char_totalHonorPoints_columnname As String
    Public Shared char_totalKills_columnname As String
    Public Shared char_chosenTitle_columnname As String
    Public Shared char_watchedFaction_columnname As String
    Public Shared char_extraFlags_columnname
    Public Shared char_health_columnname As String
    Public Shared char_speccount_columnname As String
    Public Shared char_activeSpec_columnname As String
    Public Shared char_exploredZones_columnname As String
    Public Shared char_knownTitles_columnname As String
    Public Shared char_arcemuTalentPoints_columnname As String
    Public Shared char_finishedQuests_columnname As String
    Public Shared char_customFaction_columnname As String
    Public Shared char_bindmapid_columnname As String
    Public Shared char_bindzoneid_columnname As String
    Public Shared char_bindposX_columnname As String
    Public Shared char_bindposY_columnname As String
    Public Shared char_bindposZ_columnname As String
    Public Shared char_arcemuPlayedTime_columnname As String
    Public Shared char_instanceModeMask_columnname As String
    Public Shared char_atlogin_columnname As String
    Public Shared char_knownCurrencies_columnname As String
    Public Shared char_actionBars_columnname As String

    '## Character_homebind Table
    Public Shared homebind_guid_columnname As String
    Public Shared homebind_map_columnname As String
    Public Shared homebind_zone_columnname As String
    Public Shared homebind_posx_columnname As String
    Public Shared homebind_posy_columnname As String
    Public Shared homebind_posz_columnname As String


    '# Realm DB
    '## Account Table
    Public Shared acc_name_columnname As String
    Public Shared acc_id_columnname As String
    Public Shared acc_v_columnname As String
    Public Shared acc_s_columnname As String
    Public Shared acc_sessionkey_columnname As String
    Public Shared acc_passHash_columnname As String
    Public Shared acc_arcemuPass_columnname As String
    Public Shared acc_email_columnname As String
    Public Shared acc_joindate_columnname As String
    Public Shared acc_lastlogin_columnname As String
    Public Shared acc_expansion_columnname As String
    Public Shared acc_arcemuFlags_columnname As String
    Public Shared acc_locale_columnname As String
    Public Shared acc_arcemuGmLevel_columnname As String
    '## Account Access Table
    Public Shared accAcc_gmLevel_columnname As String
    Public Shared accAcc_realmId_columnname As String
    Public Shared accAcc_accid_columnname As String
End Class