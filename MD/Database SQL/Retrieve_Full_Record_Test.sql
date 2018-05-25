select record.RecordID, groom.Groom_First_Name, groom.Groom_Last_Name, bride.Bride_First_Name,bride.Bride_Last_Name, record.Papers_Recieved_Date,
record.Wedding_Date, record.Papers_Mailed, dispensation_type.Dispensation_Type, record.Additional_Circumstances_Note, dispensation.Dispensation_Category,
catholic_party.Catholic_Party_Category, record.Approved_By, record.Papers_Mailed_Note, parish.Parish, parish.Parish, record.Is_Parish_Outside_Of_Diocese,
record.Officiant_Name, record.Is_Convalidated, record.Has_Been_Annulled
from record, groom, bride, dispensation, dispensation_type, parish, catholic_party
where record.Groom_ID = groom.Groom_ID 
and record.Bride_ID = bride.Bride_ID
and record.Dispensation_Type_Number = Dispensation_Type.Dispensation_Type_Number
and record.Dispensation_ID = dispensation.Dispensation_ID
and record.Catholic_Party_ID = catholic_party.Catholic_Party_ID
and record.Paperwork_Originated = parish.Parish_ID
and record.Parish_Of_Wedding = parish.Parish_ID;