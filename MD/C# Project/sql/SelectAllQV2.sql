SELECT      [Record I D] = [Record].[Record_ID],
            [Groom First Name] = [A21].[Groom_First_Name],
			[Groom Middle Int] = [A21].[Groom_Middle_Int],
			[Groom Last Name] = [A21].[Groom_Last_Name],
            [Bride First Name] = [A22].[Bride_First_Name],
			[Bride Middle Int] = [A22].[Bride_Middle_Int],
			[Bride Last Name] = [A22].[Bride_Last_Name],
            [Papers Recieved Date] = [Record].[Papers_Recieved_Date],
            [Wedding Date] = Left([Record].[Wedding_Date], 10),
            [Papers Mailed] = [Record].[Papers_Mailed],
            [Dispensation Type I D] = [A26].[Dispensation_Type_Name],
            [Additional Circumstances Note] = [Record].[Additional_Circumstances_Note],
            [Dispensation I D] = [A28].[Dispensation_Category]     ,[Catholic Party I D] = [A29].[Catholic_Party_Category],
            [Approved By] = [Record].[Approved_By]     ,[Papers Mailed Note] = [Record].[Papers_Mailed_Note],
            [Paperwork Originated Parish I D] = [A32].[ParishName],
            [Parish Of Wedding Parish I D] = [A33].[ParishName],
            [Is Parish Outside Of Diocese] = [Record].[Is_Parish_Outside_Of_Diocese],
            [Officiant Name] = [Record].[Officiant_Name],
            [Is Convalidated] = [Record].[Is_Convalidated],
            [Has Been Annulled] = [Record].[Has_Been_Annulled],
            [Dispensation Link I D] = [RecordToDispensation].[Dispensation_Id],
            [Modified By] = [Record].[ModifiedBy],
            [Bride First Name] = [A22].[Bride_First_Name],
            [Bride Middle Int] = [A22].[Bride_Middle_Int],
            [Bride Last Name] = [A22].[Bride_Last_Name],
            [Groom First Name] = [A21].[Groom_First_Name],[Groom Middle Int] = [A21].[Groom_Middle_Int],[Groom Last Name] = [A21].[Groom_Last_Name] FROM[Record]
            INNER JOIN[Groom] as [A21] ON[Record].[Groom_ID] = [A21].[Groom_ID]
            INNER JOIN[Bride] as [A22] ON[Record].[Bride_ID] = [A22].[Bride_ID]
            INNER JOIN[Dispensation_Type] as [A26] ON[Record].[Dispensation_Type_ID] = [A26].[Dispensation_Type_ID]
            INNER JOIN[Dispensation] as [A28] ON[Record].[Dispensation_ID] = [A28].[Dispensation_ID]
            INNER JOIN[Catholic_Party] as [A29] ON[Record].[Catholic_Party_ID] = [A29].[Catholic_Party_ID]
            INNER JOIN[Parish] as [A32] ON[Record].[Paperwork_Originated_Parish_ID] = [A32].[Parish_ID] INNER JOIN[Parish] as [A33] ON[Record].[Parish_Of_Wedding_Parish_ID] = [A33].[Parish_ID]
            INNER JOIN[RecordToDispensation] ON[Record].[DispensationLink_ID] = [RecordToDispensation].[id] 