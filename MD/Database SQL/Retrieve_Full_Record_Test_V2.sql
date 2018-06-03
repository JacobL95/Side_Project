select 
record.RecordID, 
concat(groom.Groom_First_Name, ' ', groom.Groom_Middle_Int, '. ', groom.Groom_Last_Name) as Groom, 
concat(bride.Bride_First_Name, ' ', bride.Bride_Middle_Int, '. ', bride.Bride_Last_Name) as Bride, 
record.Wedding_Date as `Wedding Date`,
dispensation.Dispensation_Category as `Dispensation Category`,
parish.Parish as `Wedding Parish`,
record.Is_Parish_Outside_Of_Diocese as `Non-KCSJ Arch/Diocese`,
catholic_party.Catholic_Party_Category as `Catholic Party`,
record.Is_Convalidated as Convalidation,
record.Has_Been_Annulled as `Annulments y/n`,
parish.Parish as `Originating Parish`,
record.Officiant_Name as `Officiant Name`,
record.Papers_Recieved_Date as `Papers Received`,
record.Papers_Mailed as `Papers Mailed`,
record.Approved_By as `Approved by`,
record.Additional_Circumstances_Note as `Notes`
from record, groom, bride, dispensation, parish, catholic_party
where record.Groom_ID = groom.Groom_ID 
and record.Bride_ID = bride.Bride_ID
and record.Dispensation_ID = dispensation.Dispensation_ID
and record.Catholic_Party_ID = catholic_party.Catholic_Party_ID
and record.Paperwork_Originated = parish.Parish_ID
and record.Parish_Of_Wedding = parish.Parish_ID;