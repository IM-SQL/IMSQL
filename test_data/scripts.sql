SELECT * FROM [Interface] WHERE 1 = 1 ORDER BY [Interface].[Id] ASC
SELECT * FROM [Interface] WHERE [Interface].[Id] = @p0 ORDER BY [Interface].[Id] ASC
SELECT * FROM [ProductionPlan] WHERE 1 = 1 ORDER BY [ProductionPlan].[Id] DESC  OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY
SELECT * FROM [User] WHERE [User].[Id] = @p0 ORDER BY [User].[Id] ASC
Select AccessRuleId from User_AccessRule where UserId = @user
select ClientId from UserClient where UserId = @userId
SELECT * FROM [Client] WHERE [Client].[ExternalId] = @p0 ORDER BY [Client].[Id] ASC
INSERT INTO [ProductionPlan] (UserId , Timestamp , Confirmed , ClientId) OUTPUT INSERTED.Id VALUES (@UserId , @Timestamp , @Confirmed , @ClientId);
SELECT * FROM [Client] WHERE [Client].[Id] = @p0 ORDER BY [Client].[Id] ASC
SELECT * FROM [Client] WHERE [Client].[Enabled] = @p0 ORDER BY [Client].[Id] ASC
select i.* from Interface i inner join InterfaceClient ic on ic.InterfaceId = i.Id where ic.ClientId = @client
SELECT * FROM [LGMessageHeader] WHERE [LGMessageHeader].[Id] = @p0 ORDER BY [LGMessageHeader].[Id] ASC
SELECT * FROM [AppSettings] WHERE [AppSettings].[Id] = @p0 ORDER BY [AppSettings].[Id] ASC
INSERT INTO [Package] (ClientId , InterfaceId , ProcessBeganTime , FilePath , FileCreatedTime , FileSentTime , RecordCount) OUTPUT INSERTED.Id VALUES (@ClientId , @InterfaceId , @ProcessBeganTime , @FilePath , @FileCreatedTime , @FileSentTime , @RecordCount);
UPDATE [Package] SET ClientId = @ClientId , InterfaceId = @InterfaceId , ProcessBeganTime = @ProcessBeganTime , FilePath = @FilePath , FileCreatedTime = @FileCreatedTime , FileSentTime = @FileSentTime , RecordCount = @RecordCount WHERE Id = @Id  ;
INSERT INTO [SendingQueue] (Timestamp , PackageId , EvaluationTime , Active , Manual) OUTPUT INSERTED.Id VALUES (@Timestamp , @PackageId , @EvaluationTime , @Active , @Manual);
SELECT * FROM [ErrorType] WHERE [ErrorType].[Id] = @p0 ORDER BY [ErrorType].[Id] ASC
SELECT COUNT(*) AS Count FROM [Package] WHERE 1 = 1
SELECT * FROM [Package] WHERE [Package].[Id] = @p0 ORDER BY [Package].[Id] ASC
SELECT * FROM [SendingQueue] WHERE [SendingQueue].[Active] = @p0 ORDER BY [SendingQueue].[Id] ASC
UPDATE [SendingQueue] SET Timestamp = @Timestamp , PackageId = @PackageId , EvaluationTime = @EvaluationTime , Active = @Active , Manual = @Manual WHERE Id = @Id  ;
SELECT * FROM [SFTPIntegrationSettings] WHERE [SFTPIntegrationSettings].[ClientId] = @p0 ORDER BY [SFTPIntegrationSettings].[Id] ASC
UPDATE SendingQueue SET Active = 0  WHERE PackageId = @package
SELECT * FROM [Package] WHERE 1 = 1 ORDER BY [Package].[Id] ASC
SELECT * FROM [Error] WHERE [Error].[PackageId] = @p0 ORDER BY [Error].[Id] ASC
SELECT * FROM [Resending] WHERE [Resending].[PackageId] = @p0 ORDER BY [Resending].[Timestamp] DESC  OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY
SELECT * FROM [AppSettings] WHERE 1 = 1 ORDER BY [AppSettings].[Id] ASC
DELETE FROM GIIMEI001
DELETE FROM GISET001
DELETE FROM GR001
DELETE FROM INVSCP001
DELETE FROM INVSTO001
DELETE FROM PLAN001
DELETE FROM PRODOVW001
DELETE FROM GCUV
DELETE FROM GPIN
DELETE FROM Error
DELETE FROM SendingQueue
DELETE FROM Resending
DELETE FROM Package
DELETE FROM ProductionPlanItem
DELETE FROM ProductionPlan
DELETE FROM SFTPIntegrationSettings
DELETE FROM InterfaceClient
DELETE FROM UserClient
DELETE FROM Client
INSERT INTO InterfaceClient (InterfaceId, ClientId)                              VALUES (@interface, @client)
UPDATE AppSettings SET [Value] = @value WHERE Id = @key
SELECT COUNT(*) AS Count FROM [GIIMEI001] WHERE 1 = 1
SELECT COUNT(*) AS Count FROM [GIIMEI001] WHERE [GIIMEI001].[Processed] = @p0
INSERT INTO [GIIMEI001] (AccountID , ReferenceNumber , OEM , PalletNumber , IMEI , Item , UnlockCode , GIDATE , DATE_1 , DATE_2 , ETC_1 , ETC_2 , ETC_3 , ETC_4 , QTY_1 , QTY_2 , Timestamp) OUTPUT INSERTED.Id VALUES (@AccountID , @ReferenceNumber , @OEM , @PalletNumber , @IMEI , @Item , @UnlockCode , @GIDATE , @DATE_1 , @DATE_2 , @ETC_1 , @ETC_2 , @ETC_3 , @ETC_4 , @QTY_1 , @QTY_2 , @Timestamp);
SELECT COUNT(*) AS Count FROM [INVSTO001] WHERE 1 = 1
SELECT COUNT(*) AS Count FROM [INVSTO001] WHERE [INVSTO001].[Processed] = @p0
INSERT INTO [INVSTO001] (AccountID , Item , Type , OnHandDate , OnHandQty , BlkQty , Unit , DATE_1 , DATE_2 , ETC_1 , ETC_2 , ETC_3 , ETC_4 , QTY_1 , QTY_2 , Timestamp) OUTPUT INSERTED.Id VALUES (@AccountID , @Item , @Type , @OnHandDate , @OnHandQty , @BlkQty , @Unit , @DATE_1 , @DATE_2 , @ETC_1 , @ETC_2 , @ETC_3 , @ETC_4 , @QTY_1 , @QTY_2 , @Timestamp);
SELECT COUNT(*) AS Count FROM [GISET001] WHERE 1 = 1
SELECT COUNT(*) AS Count FROM [GISET001] WHERE [GISET001].[Processed] = @p0
INSERT INTO [GISET001] (AccountID , Model , GIDate , GIPlan , GIQty , DATE_1 , DATE_2 , ETC_1 , ETC_2 , ETC_3 , ETC_4 , QTY_1 , QTY_2 , Timestamp) OUTPUT INSERTED.Id VALUES (@AccountID , @Model , @GIDate , @GIPlan , @GIQty , @DATE_1 , @DATE_2 , @ETC_1 , @ETC_2 , @ETC_3 , @ETC_4 , @QTY_1 , @QTY_2 , @Timestamp);
SELECT COUNT(*) AS Count FROM [GR001] WHERE 1 = 1
SELECT COUNT(*) AS Count FROM [GR001] WHERE [GR001].[Processed] = @p0
INSERT INTO [GR001] (AccountID , InvoiceNo , ModeloOrMaterial , GRQty , GRDATE , DATE_1 , DATE_2 , ETC_1 , ETC_2 , ETC_3 , ETC_4 , QTY_1 , QTY_2 , Timestamp) OUTPUT INSERTED.Id VALUES (@AccountID , @InvoiceNo , @ModeloOrMaterial , @GRQty , @GRDATE , @DATE_1 , @DATE_2 , @ETC_1 , @ETC_2 , @ETC_3 , @ETC_4 , @QTY_1 , @QTY_2 , @Timestamp);
SELECT COUNT(*) AS Count FROM [INVSCP001] WHERE 1 = 1
SELECT COUNT(*) AS Count FROM [INVSCP001] WHERE [INVSCP001].[Processed] = @p0
INSERT INTO [INVSCP001] (AccountID , Item , SCPWEEK , Type , ScpQty , Unit , Reason , DATE_1 , DATE_2 , ETC_1 , ETC_2 , ETC_3 , ETC_4 , QTY_1 , QTY_2 , Timestamp) OUTPUT INSERTED.Id VALUES (@AccountID , @Item , @SCPWEEK , @Type , @ScpQty , @Unit , @Reason , @DATE_1 , @DATE_2 , @ETC_1 , @ETC_2 , @ETC_3 , @ETC_4 , @QTY_1 , @QTY_2 , @Timestamp);
SELECT COUNT(*) AS Count FROM [PLAN001] WHERE 1 = 1
SELECT COUNT(*) AS Count FROM [PLAN001] WHERE [PLAN001].[Processed] = @p0
INSERT INTO [PLAN001] (AccountID , PlanWeek , Model , Type , Week01 , Week02 , Week03 , Week04 , Week05 , Week06 , Week07 , Week08 , Week09 , Week10 , Week11 , Week12 , Week13 , Week14 , Week15 , Week16 , Week17 , Week18 , Week19 , Week20 , Week21 , Week22 , Week23 , DATE_1 , DATE_2 , ETC_1 , ETC_2 , ETC_3 , ETC_4 , QTY_1 , QTY_2 , Timestamp , ProductionPlanId) OUTPUT INSERTED.Id VALUES (@AccountID , @PlanWeek , @Model , @Type , @Week01 , @Week02 , @Week03 , @Week04 , @Week05 , @Week06 , @Week07 , @Week08 , @Week09 , @Week10 , @Week11 , @Week12 , @Week13 , @Week14 , @Week15 , @Week16 , @Week17 , @Week18 , @Week19 , @Week20 , @Week21 , @Week22 , @Week23 , @DATE_1 , @DATE_2 , @ETC_1 , @ETC_2 , @ETC_3 , @ETC_4 , @QTY_1 , @QTY_2 , @Timestamp , @ProductionPlanId);
SELECT COUNT(*) AS Count FROM [PRODOVW001] WHERE 1 = 1
SELECT COUNT(*) AS Count FROM [PRODOVW001] WHERE [PRODOVW001].[Processed] = @p0
INSERT INTO [PRODOVW001] (AccountID , LINE , SHIFT , MODEL , REGDATE , PLANQTY , PRODQTY , TOTDEFECT , WORKERNO , WORKTIME , LOSSTIME , BREAKTIME , PO , DATE_1 , DATE_2 , ETC_1 , ETC_2 , ETC_3 , ETC_4 , QTY_1 , QTY_2 , WODate , Timestamp) OUTPUT INSERTED.Id VALUES (@AccountID , @LINE , @SHIFT , @MODEL , @REGDATE , @PLANQTY , @PRODQTY , @TOTDEFECT , @WORKERNO , @WORKTIME , @LOSSTIME , @BREAKTIME , @PO , @DATE_1 , @DATE_2 , @ETC_1 , @ETC_2 , @ETC_3 , @ETC_4 , @QTY_1 , @QTY_2 , @WODate , @Timestamp);
SELECT COUNT(*) AS Count FROM [GPIN] WHERE 1 = 1
SELECT COUNT(*) AS Count FROM [GPIN] WHERE [GPIN].[Processed] = @p0
INSERT INTO [GPIN] (DocumentID , BusinessID , ODM_CODE , IMEI_CODE , MODEL , BUYER_COLOR , MSN_CODE , PRODUCTION_DATE , SW_VERSION , CREATED_BY , CREATION_DATE , LAST_UPDATE_DATE , LAST_UPDATED_BY , TRANSFER_ID , TRANSFER_DATE , INVOICE_ID , PALLET_ID , BOX_ID , TRANSFER_FLAG , ATTRIBUTE1 , ATTRIBUTE2 , ATTRIBUTE3 , ATTRIBUTE4 , ATTRIBUTE5 , ATTRIBUTE6 , ATTRIBUTE7 , ATTRIBUTE8 , ATTRIBUTE9 , ATTRIBUTE10 , ATTRIBUTE11 , ATTRIBUTE12 , ATTRIBUTE13 , ATTRIBUTE14 , ATTRIBUTE15 , ATTRIBUTE16 , ATTRIBUTE17 , ATTRIBUTE18 , ATTRIBUTE19 , ATTRIBUTE20 , ATTRIBUTE21 , ATTRIBUTE22 , ATTRIBUTE23 , ATTRIBUTE24 , ATTRIBUTE25 , ATTRIBUTE26 , ATTRIBUTE27 , ATTRIBUTE28 , ATTRIBUTE29 , ATTRIBUTE30 , ATTRIBUTE31 , ATTRIBUTE32 , ATTRIBUTE33 , ATTRIBUTE34 , ATTRIBUTE35 , ATTRIBUTE36 , ATTRIBUTE37 , ATTRIBUTE38 , ATTRIBUTE39 , ATTRIBUTE40 , ATTRIBUTE41 , ATTRIBUTE42 , ATTRIBUTE43 , ATTRIBUTE44 , ATTRIBUTE45 , ATTRIBUTE46 , ATTRIBUTE47 , ATTRIBUTE48 , ATTRIBUTE49 , ATTRIBUTE50 , ATTRIBUTE51 , ATTRIBUTE52 , ATTRIBUTE53 , ATTRIBUTE54 , ATTRIBUTE55 , Timestamp) OUTPUT INSERTED.Id VALUES (@DocumentID , @BusinessID , @ODM_CODE , @IMEI_CODE , @MODEL , @BUYER_COLOR , @MSN_CODE , @PRODUCTION_DATE , @SW_VERSION , @CREATED_BY , @CREATION_DATE , @LAST_UPDATE_DATE , @LAST_UPDATED_BY , @TRANSFER_ID , @TRANSFER_DATE , @INVOICE_ID , @PALLET_ID , @BOX_ID , @TRANSFER_FLAG , @ATTRIBUTE1 , @ATTRIBUTE2 , @ATTRIBUTE3 , @ATTRIBUTE4 , @ATTRIBUTE5 , @ATTRIBUTE6 , @ATTRIBUTE7 , @ATTRIBUTE8 , @ATTRIBUTE9 , @ATTRIBUTE10 , @ATTRIBUTE11 , @ATTRIBUTE12 , @ATTRIBUTE13 , @ATTRIBUTE14 , @ATTRIBUTE15 , @ATTRIBUTE16 , @ATTRIBUTE17 , @ATTRIBUTE18 , @ATTRIBUTE19 , @ATTRIBUTE20 , @ATTRIBUTE21 , @ATTRIBUTE22 , @ATTRIBUTE23 , @ATTRIBUTE24 , @ATTRIBUTE25 , @ATTRIBUTE26 , @ATTRIBUTE27 , @ATTRIBUTE28 , @ATTRIBUTE29 , @ATTRIBUTE30 , @ATTRIBUTE31 , @ATTRIBUTE32 , @ATTRIBUTE33 , @ATTRIBUTE34 , @ATTRIBUTE35 , @ATTRIBUTE36 , @ATTRIBUTE37 , @ATTRIBUTE38 , @ATTRIBUTE39 , @ATTRIBUTE40 , @ATTRIBUTE41 , @ATTRIBUTE42 , @ATTRIBUTE43 , @ATTRIBUTE44 , @ATTRIBUTE45 , @ATTRIBUTE46 , @ATTRIBUTE47 , @ATTRIBUTE48 , @ATTRIBUTE49 , @ATTRIBUTE50 , @ATTRIBUTE51 , @ATTRIBUTE52 , @ATTRIBUTE53 , @ATTRIBUTE54 , @ATTRIBUTE55 , @Timestamp);
SELECT COUNT(*) AS Count FROM [GCUV] WHERE 1 = 1
SELECT COUNT(*) AS Count FROM [GCUV] WHERE [GCUV].[Processed] = @p0
INSERT INTO [GCUV] (DocumentID , BusinessID , INTERFACE_ID , INTERFACE_SYSTEM , ODM_CODE , IMEI_CODE , BILL_TO_CODE , BILL_TO_NAME , SHIP_CONFIRM_DATE , CREATION_DATE , CREATED_BY , LAST_UPDATE_DATE , LAST_UPDATED_BY , ATTRIBUTE1 , ATTRIBUTE2 , ATTRIBUTE3 , ATTRIBUTE4 , ATTRIBUTE5 , ATTRIBUTE6 , ATTRIBUTE7 , ATTRIBUTE8 , ATTRIBUTE9 , ATTRIBUTE10 , Timestamp) OUTPUT INSERTED.Id VALUES (@DocumentID , @BusinessID , @INTERFACE_ID , @INTERFACE_SYSTEM , @ODM_CODE , @IMEI_CODE , @BILL_TO_CODE , @BILL_TO_NAME , @SHIP_CONFIRM_DATE , @CREATION_DATE , @CREATED_BY , @LAST_UPDATE_DATE , @LAST_UPDATED_BY , @ATTRIBUTE1 , @ATTRIBUTE2 , @ATTRIBUTE3 , @ATTRIBUTE4 , @ATTRIBUTE5 , @ATTRIBUTE6 , @ATTRIBUTE7 , @ATTRIBUTE8 , @ATTRIBUTE9 , @ATTRIBUTE10 , @Timestamp);
UPDATE GIIMEI001 SET PackageId = @package  WHERE Processed = 0 AND AccountID = @account
SELECT * FROM [GIIMEI001] WHERE ([GIIMEI001].[Processed] = @p0 AND [GIIMEI001].[PackageId] = @p1) ORDER BY [GIIMEI001].[Id] ASC  OFFSET 0 ROWS FETCH NEXT 1000 ROWS ONLY
SELECT * FROM [GIIMEI001] WHERE ([GIIMEI001].[Processed] = @p0 AND [GIIMEI001].[PackageId] = @p1) ORDER BY [GIIMEI001].[Id] ASC  OFFSET 1000 ROWS FETCH NEXT 1000 ROWS ONLY
UPDATE GIIMEI001 SET Processed = 1  WHERE PackageId = @package
SELECT * FROM [GIIMEI001] WHERE ([GIIMEI001].[PackageId] = @p0 AND [GIIMEI001].[Processed] = @p1) ORDER BY [GIIMEI001].[Id] ASC
UPDATE INVSTO001 SET PackageId = @package  WHERE Processed = 0 AND AccountID = @account
SELECT * FROM [INVSTO001] WHERE ([INVSTO001].[Processed] = @p0 AND [INVSTO001].[PackageId] = @p1) ORDER BY [INVSTO001].[Id] ASC  OFFSET 0 ROWS FETCH NEXT 1000 ROWS ONLY
SELECT * FROM [INVSTO001] WHERE ([INVSTO001].[Processed] = @p0 AND [INVSTO001].[PackageId] = @p1) ORDER BY [INVSTO001].[Id] ASC  OFFSET 1000 ROWS FETCH NEXT 1000 ROWS ONLY
UPDATE INVSTO001 SET Processed = 1  WHERE PackageId = @package
SELECT * FROM [INVSTO001] WHERE ([INVSTO001].[PackageId] = @p0 AND [INVSTO001].[Processed] = @p1) ORDER BY [INVSTO001].[Id] ASC
UPDATE GISET001 SET PackageId = @package  WHERE Processed = 0 AND AccountID = @account
SELECT * FROM [GISET001] WHERE ([GISET001].[Processed] = @p0 AND [GISET001].[PackageId] = @p1) ORDER BY [GISET001].[Id] ASC  OFFSET 0 ROWS FETCH NEXT 1000 ROWS ONLY
SELECT * FROM [GISET001] WHERE ([GISET001].[Processed] = @p0 AND [GISET001].[PackageId] = @p1) ORDER BY [GISET001].[Id] ASC  OFFSET 1000 ROWS FETCH NEXT 1000 ROWS ONLY
UPDATE GISET001 SET Processed = 1  WHERE PackageId = @package
SELECT * FROM [GISET001] WHERE ([GISET001].[PackageId] = @p0 AND [GISET001].[Processed] = @p1) ORDER BY [GISET001].[Id] ASC
UPDATE GR001 SET PackageId = @package  WHERE Processed = 0 AND AccountID = @account
SELECT * FROM [GR001] WHERE ([GR001].[Processed] = @p0 AND [GR001].[PackageId] = @p1) ORDER BY [GR001].[Id] ASC  OFFSET 0 ROWS FETCH NEXT 1000 ROWS ONLY
SELECT * FROM [GR001] WHERE ([GR001].[Processed] = @p0 AND [GR001].[PackageId] = @p1) ORDER BY [GR001].[Id] ASC  OFFSET 1000 ROWS FETCH NEXT 1000 ROWS ONLY
UPDATE GR001 SET Processed = 1  WHERE PackageId = @package
SELECT * FROM [GR001] WHERE ([GR001].[PackageId] = @p0 AND [GR001].[Processed] = @p1) ORDER BY [GR001].[Id] ASC
UPDATE INVSCP001 SET PackageId = @package  WHERE Processed = 0 AND AccountID = @account
SELECT * FROM [INVSCP001] WHERE ([INVSCP001].[Processed] = @p0 AND [INVSCP001].[PackageId] = @p1) ORDER BY [INVSCP001].[Id] ASC  OFFSET 0 ROWS FETCH NEXT 1000 ROWS ONLY
SELECT * FROM [INVSCP001] WHERE ([INVSCP001].[Processed] = @p0 AND [INVSCP001].[PackageId] = @p1) ORDER BY [INVSCP001].[Id] ASC  OFFSET 1000 ROWS FETCH NEXT 1000 ROWS ONLY
UPDATE INVSCP001 SET Processed = 1  WHERE PackageId = @package
SELECT * FROM [INVSCP001] WHERE ([INVSCP001].[PackageId] = @p0 AND [INVSCP001].[Processed] = @p1) ORDER BY [INVSCP001].[Id] ASC
UPDATE PLAN001 SET PackageId = @package  WHERE Processed = 0 AND AccountID = @account
SELECT * FROM [PLAN001] WHERE ([PLAN001].[Processed] = @p0 AND [PLAN001].[PackageId] = @p1) ORDER BY [PLAN001].[Id] ASC  OFFSET 0 ROWS FETCH NEXT 1000 ROWS ONLY
SELECT * FROM [PLAN001] WHERE ([PLAN001].[Processed] = @p0 AND [PLAN001].[PackageId] = @p1) ORDER BY [PLAN001].[Id] ASC  OFFSET 1000 ROWS FETCH NEXT 1000 ROWS ONLY
UPDATE PLAN001 SET Processed = 1  WHERE PackageId = @package
SELECT * FROM [PLAN001] WHERE ([PLAN001].[PackageId] = @p0 AND [PLAN001].[Processed] = @p1) ORDER BY [PLAN001].[Id] ASC
UPDATE PRODOVW001 SET PackageId = @package  WHERE Processed = 0 AND AccountID = @account
SELECT * FROM [PRODOVW001] WHERE ([PRODOVW001].[Processed] = @p0 AND [PRODOVW001].[PackageId] = @p1) ORDER BY [PRODOVW001].[Id] ASC  OFFSET 0 ROWS FETCH NEXT 1000 ROWS ONLY
SELECT * FROM [PRODOVW001] WHERE ([PRODOVW001].[Processed] = @p0 AND [PRODOVW001].[PackageId] = @p1) ORDER BY [PRODOVW001].[Id] ASC  OFFSET 1000 ROWS FETCH NEXT 1000 ROWS ONLY
UPDATE PRODOVW001 SET Processed = 1  WHERE PackageId = @package
SELECT * FROM [PRODOVW001] WHERE ([PRODOVW001].[PackageId] = @p0 AND [PRODOVW001].[Processed] = @p1) ORDER BY [PRODOVW001].[Id] ASC
UPDATE GPIN SET PackageId = @package  WHERE Processed = 0
SELECT * FROM [GPIN] WHERE ([GPIN].[Processed] = @p0 AND [GPIN].[PackageId] = @p1) ORDER BY [GPIN].[Id] ASC  OFFSET 0 ROWS FETCH NEXT 1000 ROWS ONLY
SELECT * FROM [GPIN] WHERE ([GPIN].[Processed] = @p0 AND [GPIN].[PackageId] = @p1) ORDER BY [GPIN].[Id] ASC  OFFSET 1000 ROWS FETCH NEXT 1000 ROWS ONLY
UPDATE GPIN SET Processed = 1  WHERE PackageId = @package
SELECT * FROM [GPIN] WHERE ([GPIN].[PackageId] = @p0 AND [GPIN].[Processed] = @p1) ORDER BY [GPIN].[Id] ASC
UPDATE GCUV SET PackageId = @package  WHERE Processed = 0
SELECT * FROM [GCUV] WHERE ([GCUV].[Processed] = @p0 AND [GCUV].[PackageId] = @p1) ORDER BY [GCUV].[Id] ASC  OFFSET 0 ROWS FETCH NEXT 1000 ROWS ONLY
SELECT * FROM [GCUV] WHERE ([GCUV].[Processed] = @p0 AND [GCUV].[PackageId] = @p1) ORDER BY [GCUV].[Id] ASC  OFFSET 1000 ROWS FETCH NEXT 1000 ROWS ONLY
UPDATE GCUV SET Processed = 1  WHERE PackageId = @package
SELECT * FROM [GCUV] WHERE ([GCUV].[PackageId] = @p0 AND [GCUV].[Processed] = @p1) ORDER BY [GCUV].[Id] ASC
SELECT id FROM LogComputerInfo  WHERE hash = @hash AND userName = @userName AND     userDomainName = @userDomainName AND machineName = @machineName AND     osVersion = @osVersion AND environmentVersion = @environmentVersion AND     ipAddress = @ipAddress AND macAddress = @macAddress
INSERT INTO Log (level, timestamp, message, computerInfo, entity, exception, query, [user])  VALUES (@level, @timestamp, @message, @computerInfo, @entity, @exception, @query, @user);  SELECT CAST(SCOPE_IDENTITY() as int);
INSERT INTO LogProperty ([log], name, value)  VALUES (@log, @name, @value)
SELECT * FROM [GR001] WHERE ([GR001].[Processed] = @p0 AND [GR001].[PackageId] = @p1) ORDER BY [GR001].[Id] ASC  OFFSET 2000 ROWS FETCH NEXT 1000 ROWS ONLY
SELECT * FROM [GR001] WHERE ([GR001].[Processed] = @p0 AND [GR001].[PackageId] = @p1) ORDER BY [GR001].[Id] ASC  OFFSET 3000 ROWS FETCH NEXT 1000 ROWS ONLY
INSERT INTO LogException (name, message, stackTrace, source, innerException)  VALUES (@name, @message, @stackTrace, @source, @innerException);  SELECT CAST(SCOPE_IDENTITY() as int);
INSERT INTO LogExceptionData (exception, [key], [value])  VALUES (@exception, @key, @value)
SELECT id FROM LogUser  WHERE name = @name AND authenticationType = @type
SELECT COUNT(*) AS Count FROM [PackageView] WHERE [PackageView].[ClientId] = @p0
SELECT * FROM [PackageView] WHERE [PackageView].[ClientId] = @p0 ORDER BY [PackageView].[Id] DESC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [PackageView] WHERE [PackageView].[ClientId] = @p0 ORDER BY [PackageView].[Id] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT COUNT(*) AS Count FROM [PackageView] WHERE ([PackageView].[Id] = @p0 AND [PackageView].[ClientId] = @p1)
SELECT * FROM [PackageView] WHERE ([PackageView].[Id] = @p0 AND [PackageView].[ClientId] = @p1) ORDER BY [PackageView].[Id] DESC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [PackageView] WHERE ([PackageView].[Id] = @p0 AND [PackageView].[ClientId] = @p1) ORDER BY [PackageView].[Id] DESC  OFFSET 0 ROWS FETCH NEXT 100 ROWS ONLY
SELECT * FROM [PackageView] WHERE [PackageView].[ClientId] = @p0 ORDER BY [PackageView].[Id] DESC  OFFSET 0 ROWS FETCH NEXT 100 ROWS ONLY
SELECT COUNT(*) AS Count FROM [PackageView] WHERE ([PackageView].[InterfaceName] LIKE @p0 AND [PackageView].[ClientId] = @p1)
SELECT * FROM [PackageView] WHERE ([PackageView].[InterfaceName] LIKE @p0 AND [PackageView].[ClientId] = @p1) ORDER BY [PackageView].[Id] DESC  OFFSET 0 ROWS FETCH NEXT 100 ROWS ONLY
SELECT COUNT(*) AS Count FROM [PackageView] WHERE (([PackageView].[ProcessBeganTime] > @p0 AND [PackageView].[ProcessBeganTime] < @p1) AND [PackageView].[ClientId] = @p2)
SELECT * FROM [PackageView] WHERE (([PackageView].[ProcessBeganTime] > @p0 AND [PackageView].[ProcessBeganTime] < @p1) AND [PackageView].[ClientId] = @p2) ORDER BY [PackageView].[Id] DESC  OFFSET 0 ROWS FETCH NEXT 100 ROWS ONLY
SELECT COUNT(*) AS Count FROM [PackageView] WHERE ([PackageView].[FilePath] LIKE @p0 AND [PackageView].[ClientId] = @p1)
SELECT * FROM [PackageView] WHERE ([PackageView].[FilePath] LIKE @p0 AND [PackageView].[ClientId] = @p1) ORDER BY [PackageView].[Id] DESC  OFFSET 0 ROWS FETCH NEXT 100 ROWS ONLY
SELECT COUNT(*) AS Count FROM [PackageView] WHERE ((((((([PackageView].[LastResendTime] > @p0 AND [PackageView].[LastResendTime] < @p1) AND [PackageView].[RecordCount] = @p2) AND ([PackageView].[FileSentTime] > @p3 AND [PackageView].[FileSentTime] < @p4)) AND ([PackageView].[FileCreatedTime] > @p5 AND [PackageView].[FileCreatedTime] < @p6)) AND ([PackageView].[ProcessBeganTime] > @p7 AND [PackageView].[ProcessBeganTime] < @p8)) AND [PackageView].[ErrorCount] = @p9) AND [PackageView].[ClientId] = @p10)
SELECT * FROM [PackageView] WHERE ((((((([PackageView].[LastResendTime] > @p0 AND [PackageView].[LastResendTime] < @p1) AND [PackageView].[RecordCount] = @p2) AND ([PackageView].[FileSentTime] > @p3 AND [PackageView].[FileSentTime] < @p4)) AND ([PackageView].[FileCreatedTime] > @p5 AND [PackageView].[FileCreatedTime] < @p6)) AND ([PackageView].[ProcessBeganTime] > @p7 AND [PackageView].[ProcessBeganTime] < @p8)) AND [PackageView].[ErrorCount] = @p9) AND [PackageView].[ClientId] = @p10) ORDER BY [PackageView].[Id] DESC  OFFSET 0 ROWS FETCH NEXT 100 ROWS ONLY
SELECT COUNT(*) AS Count FROM [INVSCP001] WHERE ([INVSCP001].[PackageId] = @p0 AND [INVSCP001].[Processed] = @p1)
SELECT * FROM [INVSCP001] WHERE ([INVSCP001].[PackageId] = @p0 AND [INVSCP001].[Processed] = @p1) ORDER BY [INVSCP001].[Timestamp] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT COUNT(*) AS Count FROM [INVSCP001] WHERE ([INVSCP001].[Item] LIKE @p0 AND ([INVSCP001].[PackageId] = @p1 AND [INVSCP001].[Processed] = @p2))
SELECT * FROM [INVSCP001] WHERE ([INVSCP001].[Item] LIKE @p0 AND ([INVSCP001].[PackageId] = @p1 AND [INVSCP001].[Processed] = @p2)) ORDER BY [INVSCP001].[Timestamp] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [INVSCP001] WHERE ([INVSCP001].[PackageId] = @p0 AND [INVSCP001].[Processed] = @p1) ORDER BY [INVSCP001].[Unit] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT count(*) FROM SendingQueue  WHERE PackageId = @package AND     Active = 1 AND Manual = 1
INSERT INTO [Resending] (UserId , Timestamp , PackageId) OUTPUT INSERTED.Id VALUES (@UserId , @Timestamp , @PackageId);
SELECT COUNT(*) AS Count FROM [GIIMEI001] WHERE ([GIIMEI001].[Processed] = @p0 AND [GIIMEI001].[AccountId] = @p1)
SELECT * FROM [GIIMEI001] WHERE ([GIIMEI001].[Processed] = @p0 AND [GIIMEI001].[AccountId] = @p1) ORDER BY [GIIMEI001].[Timestamp] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT COUNT(*) AS Count FROM [GISET001] WHERE ([GISET001].[Processed] = @p0 AND [GISET001].[AccountId] = @p1)
SELECT * FROM [GISET001] WHERE ([GISET001].[Processed] = @p0 AND [GISET001].[AccountId] = @p1) ORDER BY [GISET001].[Timestamp] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT COUNT(*) AS Count FROM [PRODOVW001] WHERE ([PRODOVW001].[Processed] = @p0 AND [PRODOVW001].[AccountId] = @p1)
SELECT * FROM [PRODOVW001] WHERE ([PRODOVW001].[Processed] = @p0 AND [PRODOVW001].[AccountId] = @p1) ORDER BY [PRODOVW001].[Timestamp] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT COUNT(*) AS Count FROM [PLAN001] WHERE ([PLAN001].[Processed] = @p0 AND [PLAN001].[AccountId] = @p1)
SELECT * FROM [PLAN001] WHERE ([PLAN001].[Processed] = @p0 AND [PLAN001].[AccountId] = @p1) ORDER BY [PLAN001].[Timestamp] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [Product] WHERE ([Product].[SKU] = @p0 AND [Product].[Model] = @p1) ORDER BY [Product].[Id] ASC
INSERT INTO [Product] (SKU , Model) OUTPUT INSERTED.Id VALUES (@SKU , @Model);
INSERT INTO [ProductionPlanItem] (CAA , Line , ProductId , Qty , Fecha , Week , ProductionPlanId) OUTPUT INSERTED.Id VALUES (@CAA , @Line , @ProductId , @Qty , @Fecha , @Week , @ProductionPlanId);
SELECT COUNT(*) AS Count FROM [ProductionPlanView] WHERE [ProductionPlanView].[ProductionPlanId] = @p0
SELECT * FROM [ProductionPlanView] WHERE [ProductionPlanView].[ProductionPlanId] = @p0 ORDER BY [ProductionPlanView].[MARCA] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [ProductionPlanView] WHERE [ProductionPlanView].[ProductionPlanId] = @p0 ORDER BY [ProductionPlanView].[SKU] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [ProductionPlanView] WHERE [ProductionPlanView].[ProductionPlanId] = @p0 ORDER BY [ProductionPlanView].[PI] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [ProductionPlanView] WHERE [ProductionPlanView].[ProductionPlanId] = @p0 ORDER BY [ProductionPlanView].[LINEA] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [ProductionPlanView] WHERE [ProductionPlanView].[ProductionPlanId] = @p0 ORDER BY [ProductionPlanView].[LINEA] ASC  OFFSET 30 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [ProductionPlanView] WHERE [ProductionPlanView].[ProductionPlanId] = @p0 ORDER BY [ProductionPlanView].[LINEA] ASC  OFFSET 40 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [ProductionPlanView] WHERE [ProductionPlanView].[ProductionPlanId] = @p0 ORDER BY [ProductionPlanView].[LINEA] ASC  OFFSET 50 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [ProductionPlanView] WHERE [ProductionPlanView].[ProductionPlanId] = @p0 ORDER BY [ProductionPlanView].[LINEA] ASC  OFFSET 60 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [ProductionPlanView] WHERE [ProductionPlanView].[ProductionPlanId] = @p0 ORDER BY [ProductionPlanView].[LINEA] ASC  OFFSET 70 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [ProductionPlanView] WHERE [ProductionPlanView].[ProductionPlanId] = @p0 ORDER BY [ProductionPlanView].[LINEA] ASC  OFFSET 80 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [ProductionPlanView] WHERE [ProductionPlanView].[ProductionPlanId] = @p0 ORDER BY [ProductionPlanView].[LINEA] ASC  OFFSET 330 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [ProductionPlanView] WHERE [ProductionPlanView].[ProductionPlanId] = @p0 ORDER BY [ProductionPlanView].[MODELO] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT COUNT(*) AS Count FROM [ProductionPlanView] WHERE ([ProductionPlanView].[PI] LIKE @p0 AND [ProductionPlanView].[ProductionPlanId] = @p1)
SELECT * FROM [ProductionPlanView] WHERE ([ProductionPlanView].[PI] LIKE @p0 AND [ProductionPlanView].[ProductionPlanId] = @p1) ORDER BY [ProductionPlanView].[SKU] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [ProductionPlan] WHERE [ProductionPlan].[Id] = @p0 ORDER BY [ProductionPlan].[Id] ASC
SELECT * FROM [ProductionPlanItem] WHERE [ProductionPlanItem].[ProductionPlanId] = @p0 ORDER BY [ProductionPlanItem].[ProductId] ASC, [ProductionPlanItem].[Id] ASC
SELECT * FROM [Product] WHERE [Product].[Id] = @p0 ORDER BY [Product].[Id] ASC
INSERT INTO [PLAN001] (PlanWeek , AccountID , Model , Type , Week01 , Week02 , Week03 , Week04 , Week05 , Week06 , Week07 , Week08 , Week09 , Week10 , Week11 , Week12 , Week13 , Week14 , Week15 , Week16 , Week17 , Week18 , Week19 , Week20 , Week21 , Week22 , Week23 , Timestamp , ETC_2 , QTY_1 , ProductionPlanId) OUTPUT INSERTED.Id VALUES (@PlanWeek , @AccountID , @Model , @Type , @Week01 , @Week02 , @Week03 , @Week04 , @Week05 , @Week06 , @Week07 , @Week08 , @Week09 , @Week10 , @Week11 , @Week12 , @Week13 , @Week14 , @Week15 , @Week16 , @Week17 , @Week18 , @Week19 , @Week20 , @Week21 , @Week22 , @Week23 , @Timestamp , @ETC_2 , @QTY_1 , @ProductionPlanId);
UPDATE [ProductionPlan] SET UserId = @UserId , Timestamp = @Timestamp , Confirmed = @Confirmed , ClientId = @ClientId WHERE Id = @Id  ;
SELECT COUNT(*) AS Count FROM [Client] WHERE 1 = 1
SELECT * FROM [Client] WHERE 1 = 1 ORDER BY [Client].[Id] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT COUNT(*) AS Count FROM [Client] WHERE [Client].[Enabled] LIKE @p0
SELECT * FROM [Client] WHERE [Client].[Enabled] LIKE @p0 ORDER BY [Client].[Id] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [Client] WHERE [Client].[Name] = @p0 ORDER BY [Client].[Id] ASC
SELECT * FROM [Client] WHERE [Client].[InternalId] = @p0 ORDER BY [Client].[Id] ASC
UPDATE [AppSettings] SET Value = @Value , Description = @Description , IsOptional = @IsOptional WHERE Id = @Id  ;
UPDATE [Interface] SET Name = @Name , Description = @Description , FileNameTemplate = @FileNameTemplate , ExecutionTime = @ExecutionTime , ExecutionDayId = @ExecutionDayId WHERE Id = @Id  ;
SELECT * FROM [User] WHERE 1 = 1 ORDER BY [User].[Id] ASC
SELECT COUNT(*) AS Count FROM [UserView] WHERE 1 = 1
SELECT * FROM [UserView] WHERE 1 = 1 ORDER BY [UserView].[Id] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [UserView] WHERE 1 = 1 ORDER BY [UserView].[DisplayName] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [UserView] WHERE 1 = 1 ORDER BY [UserView].[Description] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [Client] WHERE 1 = 1 ORDER BY [Client].[Id] ASC
SELECT * FROM [User] WHERE [User].[DisplayName] = @p0 ORDER BY [User].[Id] ASC
SELECT * FROM [User] WHERE [User].[Email] = @p0 ORDER BY [User].[Id] ASC
SELECT * FROM [LogAudit] WHERE 1 = 1 ORDER BY [LogAudit].[Id] DESC
SELECT COUNT(*) AS Count FROM [LogAudit] WHERE 1 = 1
SELECT * FROM [LogAudit] WHERE 1 = 1 ORDER BY [LogAudit].[id] DESC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [LogAudit] WHERE 1 = 1 ORDER BY [LogAudit].[id] DESC  OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [LogAudit] WHERE 1 = 1 ORDER BY [LogAudit].[timestamp] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
SELECT * FROM [GPIN] WHERE [GPIN].[Processed] = @p0 ORDER BY [GPIN].[Timestamp] ASC  OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY
