/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/*
INFO(Richo): This script will populate the enum tables with their reference data.
It uses the MERGE statement in order to modify the table data in a single operation.
It's kind of complex and ugly but, for the moment, this is the best way of specifying
reference data.

For more info:
https://blogs.msdn.microsoft.com/ssdt/2012/02/02/including-data-in-a-sql-server-database-project/
*/

-- ###############################################################
-- Reference Data for LogLevel
-- ###############################################################
MERGE INTO LogLevel AS target 
USING (VALUES 
  (0, 'ALL'), 
  (1, 'DEBUG'), 
  (2, 'INFO'), 
  (3, 'WARN'), 
  (4, 'ERROR'), 
  (5, 'FATAL'), 
  (6, 'OFF') 
) AS source (id, name) 
ON target.id = source.id
-- update matched rows 
WHEN MATCHED THEN 
	UPDATE SET name = source.name 
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT (id, name) 
	VALUES (source.id, source.name) 
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;
	
-- ###############################################################
-- Reference Data for Weekday
-- ###############################################################
MERGE INTO [Weekday] AS target 
USING (VALUES 
  (0, 'ALL'), 
  (1, 'MONDAY'), 
  (2, 'TUESDAY'), 
  (3, 'WEDNESDAY'), 
  (4, 'THURSDAY'), 
  (5, 'FRIDAY'), 
  (6, 'SATURDAY'),
  (7, 'SUNDAY')
) AS source (Id, Name) 
ON target.Id = source.Id
-- update matched rows 
WHEN MATCHED THEN 
	UPDATE SET Name = source.Name 
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT (Id, Name) 
	VALUES (source.Id, source.Name) 
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;

-- ###############################################################
-- Reference Data for Interface
-- ###############################################################
MERGE INTO Interface AS target 
USING (VALUES 
  (1, 'GIIMEI_001', 'Informe de productos defectuosos', '{0}_GIIMEI_{1}.txt', timefromparts(0,0,0,0,0), 0),
  (2, 'INVSTO_001', 'Informe de stock de partes y productos terminados', '{0}_INVSTO_{1}.txt', timefromparts(0,0,0,0,0), 0),
  (3, 'GISET_001', 'Informe de envíos', '{0}_GISET_{1}.txt', timefromparts(0,0,0,0,0), 0),
  (4, 'GR_001', 'Informe de recepción de productos', '{0}_GR_{1}.txt', timefromparts(0,0,0,0,0), 0),
  (5, 'INVSCP_001', 'Informe de scrap de partes y scrap de productos terminados', '{0}_INVSCP_{1}.txt', timefromparts(0,0,0,0,0), 0),
  (6, 'PLAN_001', 'Informe de plan de producción', '{0}_PLAN_{1}.txt', timefromparts(0,0,0,0,0), 1),
  (7, 'PRODOVW_001', 'Informe de producción', '{0}_PRODOVW_{1}.txt', timefromparts(0,0,0,0,0), 0),
  (8, 'GPIN', 'Production information (LG)', '{0}_GPIN_{1}.xml', timefromparts(0,0,0,0,0), 0),
  (9, 'GCUV', 'Delivery information (LG)', '{0}_GCUV_{1}.xml', timefromparts(0,0,0,0,0), 0)
) AS source (Id, Name, [Description], FileNameTemplate, ExecutionTime, ExecutionDayId) 
ON target.Id = source.Id
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT (Id, Name, [Description], FileNameTemplate, ExecutionTime, ExecutionDayId) 
	VALUES (source.Id, source.Name, source.[Description], FileNameTemplate, ExecutionTime, ExecutionDayId) 
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;
	
-- ###############################################################
-- Reference Data for LGMessageHeader
-- ###############################################################
MERGE INTO LGMessageHeader AS target 
USING (VALUES 
  (8, 'B2BI,B2BI,ARIMA_PINUPLOAD_SN,20170912,180354000', 'BRIGHTSTAR', '688298116', 'CXML_ODMPUP'),
  (9, 'B2BI,B2BI,ARSUB_SELLINIMEI_SB,20170912,180354000', 'BRIGHTSTAR', '688298116', 'CXML_SELLINIMEI')
) AS source (Id, [InterfaceId], [SenderId], [ReceiverId], [DocumentType]) 
ON target.Id = source.Id
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT (Id, [InterfaceId], [SenderId], [ReceiverId], [DocumentType]) 
	VALUES (source.Id, source.[InterfaceId], source.[SenderId], source.[ReceiverId], source.[DocumentType]) 
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;

-- ###############################################################
-- Reference Data for IntegrationType
-- ###############################################################
MERGE INTO IntegrationType AS target 
USING (VALUES 
  (1, 'SFTP', 'SSH File Transfer Protocol')
) AS source (Id, Name, [Description]) 
ON target.id = source.id
-- update matched rows 
WHEN MATCHED THEN 
	UPDATE SET 
		Name = source.Name,
		[Description] = source.[Description]
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT (Id, Name, [Description]) 
	VALUES (source.Id, source.Name, source.[Description]) 
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;

-- ###############################################################
-- Reference Data for ErrorType
-- ###############################################################
MERGE INTO ErrorType AS target 
USING (VALUES 
  (1, 'ProcessingError', '[Brightstar.Interchange] El procesamiento del paquete falló', 'Ocurrió un error al procesar el paquete.', 0),
  (2, 'SendingError', '[Brightstar.Interchange] El envío del paquete falló', 'Ocurrió un error al enviar el paquete.', 0),
  (3, 'NoRecordsWarning', '[Brightstar.Interchange] No se encontraron registros', 'No se encontraron registros para procesar.', 1),
  (4, 'NoProductionPlan', '[Brightstar.Interchange] Recordatorio Plan de Producción', 'Los siguientes clientes no tienen el plan de producción actualizado.', 1),
  (5, 'ServiceRestartError', '[Brightstar.Interchange] El servicio no pudo ser reiniciado', 'Ocurrió un error al intentar reiniciar el servicio.', 0)
) AS source (Id, Name, EmailSubject, EmailBody, Warning) 
ON target.id = source.id
-- update matched rows 
WHEN MATCHED THEN 
	UPDATE SET 
		Name = source.Name,
		EmailSubject = source.EmailSubject,
		EmailBody = source.EmailBody,
		Warning = source.Warning
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT (Id, Name, EmailSubject, EmailBody, Warning) 
	VALUES (source.Id, source.Name, source.EmailSubject, source.EmailBody, source.Warning) 
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;

-- ###############################################################
-- Reference Data for AppSettings
-- ###############################################################
MERGE INTO AppSettings AS target 
USING (VALUES 
  ('001ProcesarLG', '0', 'IMPORTANTE -> Realiza proceso de importación de LG de información AX - LFCS -> 1:Realiza procesamiento - 0:No realiza procesamiento',0),
  ('002DíasDeRecompilaciónSMS', '30', '',0),
  ('TempFolder', 'C:\Brightstar.Interchange\Temp', 'Carpeta temporal para el procesamiento de paquetes.',0),
  ('BackupFolder', 'C:\Brightstar.Interchange\Backup', 'Carpeta de backup para los paquetes ya procesados.',0),
  ('LogFolder', 'C:\Brightstar.Interchange\Log', 'Carpeta donde almacenar los logs.',0),
  ('CreateEmptyFiles', '1', '1: Se crean archivos sin registros. 0: No se crean archivos sin registros.',0),
  ('FetchPageSize', '1000', 'Tamaño de la página de acceso a la base de datos para el procesamiento.',0),
  ('Retries', '3', 'Cantidad de reintentos',0),
  ('RetryDelay', '15', 'Tiempo entre reintentos (en minutos)', 0),
  ('SenderIntervalSeconds', '1000', 'Tiempo entre ejecuciones del proceso de envío (en milisegundos).',0),
  ('ErrorNotificationEmail', 'rmoran@mvfactory.com', 'Dirección de mail para notificación de errores',0),
  ('WatchdogNotificationEmail', 'rmoran@mvfactory.com', 'Dirección de mail para notificación de errores en el servicio de watchdog',0),
  ('WatchdogMaxRestartAttempts', '3', 'Cantidad de intentos para reiniciar los servicios',0),
  ('WatchdogDelayBetweenRestarts', '60', 'Tiempo entre intentos para reiniciar los servicios (en segundos)',0),
  ('ADURL', '', 'Dirección del servidor de Active Directory a ser utilizado para validar la autenticacion de los usuarios',1),

  -- TODO(Richo): Replace with MVFactory SMTP
  ('SMTPPort', '587', 'Puerto a utilizar para el SMTP',0),
  ('SMTPHost', 'smtp.gmail.com', 'Hostname del SMTP',0),
  ('SMTPUsername', 'rm.20161005@gmail.com', 'Cuenta de usuario del SMTP',1), 
  ('SMTPPassword', 'manejar8pera', 'Contraseña de usuario del SMTP',1),
  ('SMTPFrom', '', 'Remitente de los mensajes', 1),

  ('ProductionPlanReminderTime', '', 'Tiempo en que se enviará el recordatorio de plan de producción (en horas antes de la ejecución de la interfaz PLAN001)', 1),
  ('ProductionPlanReminderEmail', '', 'Dirección de mail para envío de recordatorio de plan de producción', 1),

  ('SamsungMaxRows', '', 'Máximo número de filas para cada archivo a mandar a Samsung. Si el archivo supera el número de filas aquí especificado, entonces previo al envío el mismo se dividirá en archivos más pequeños.', 1),
  ('LGMaxRows', '', 'Máximo número de filas para cada archivo a mandar a LG. Si el archivo supera el número de filas aquí especificado, entonces previo al envío el mismo se dividirá en archivos más pequeños.', 1),
  
  ('SamsungRemoteSendFolder', '', 'Carpeta en el SFTP donde enviar los paquetes procesados de Samsung.',1),
  ('SamsungRemoteReceiveFolder', '', 'Recepción de información de Samsung.',1),
  ('LGRemoteSendFolder', '', 'Carpeta en el SFTP donde enviar los paquetes procesados de LG.',1),
  ('LGRemoteReceiveFolder', '', 'Recepción de información de LG.',1)
) AS source (Id, [Value], [Description],IsOptional) 
ON target.Id = source.Id
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT (Id, [Value], [Description],[IsOptional]) 
	VALUES (source.Id, source.[Value], source.[Description],source.[IsOptional]) 
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;

	
-- ###############################################################
-- Reference Data for AccessRule
-- ###############################################################
MERGE INTO AccessRule AS target 
USING (VALUES 
  (1, 'UserIndex', '', 1, 0),
  (2, 'UserAdd', '', 1, 0),
  (3, 'UserEdit', '', 1, 0),
  (4, 'UserDelete', '', 1, 0),
  (5, 'UserDetails', '', 1, 0),
  (6, 'UserManagement', '', 1, 1),
  (7, 'RoleIndex', '', 1, 0),
  (8, 'RoleAdd', '', 1, 0),
  (9, 'RoleEdit', '', 1, 0),
  (10, 'RoleDelete', '', 1, 0),
  (11, 'RoleDetails', '', 1, 0),
  (12, 'RoleManagement', '', 1, 1),
  (13, 'LogIndex', '', 1, 0),
  (14, 'LogDetails', '', 1, 0),
  (15, 'LogManagement', '', 1, 1),
  (16, 'ConfigurationIndex', '', 1, 0),
  (17, 'ConfigurationEdit', '', 1, 0),
  (18, 'ConfigurationManagement', '', 1, 1),
  (19, 'ClientIndex', '', 1, 0),
  (20, 'ClientAdd', '', 1, 0),
  (21, 'ClientEdit', '', 1, 0),
  (22, 'ClientDelete', '', 1, 0),
  (23, 'ClientDetails', '', 1, 0),
  (24, 'ClientManagement', '', 1, 1),
  (25, 'NewsIndex', '', 1, 0),
  (26, 'NewsResend', '', 1, 0),
  (27, 'NewsManagement', '', 1, 1),
  (28, 'GIMEI001Index', '', 1, 0),
  (29, 'InterfacesManagement', '', 1, 1),
  (30, 'Administrador', '', 1, 1),
  (31, 'NewsDetails', '', 1, 0),
  (32, 'Operador', '', 1, 1),
  (33, 'INVSTO001Index', '', 1, 0),
  (34, 'GISET001Index', '', 1, 0),
  (35, 'GR001Index', '', 1, 0),
  (36, 'INVSCP001Index', '', 1, 0),
  (37, 'PLAN001Index', '', 1, 0),
  (38, 'PRODOVW001Index', '', 1, 0),
  (39, 'PLAN001Upload', '', 1, 0),
  (40, 'ProductionPlanManagement', '', 1, 1),
  (41, 'GPINIndex', '', 1, 0),
  (42, 'GCUVIndex', '', 1, 0),
  (43, 'InterfaceConfig', '', 1, 0)
) AS source (Id, [Name], [Description], [Enabled], [IsRole]) 
ON target.Id = source.Id
-- update matched rows 
WHEN MATCHED THEN 
	UPDATE SET 
		[Name] = source.[Name],
		[Description] = source.[Description],
		[Enabled] = source.[Enabled],
		[IsRole] = source.[IsRole]
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT (Id, [Name], [Description], [Enabled], [IsRole]) 
	VALUES (source.Id, source.[Name], source.[Description], source.[Enabled], source.[IsRole]) 
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;

	
-- ###############################################################
-- Reference Data for Role_AccessRule
-- ###############################################################
MERGE INTO Role_AccessRule AS target 
USING (VALUES 
  -- UserManagement
  (6, 1), -- UserIndex
  (6, 2), -- UserAdd
  (6, 3), -- UserEdit
  (6, 4), -- UserDelete
  (6, 5), -- UserDetails

  -- Administrador
  (30, 6), -- UserManagement
  (30, 12), -- RoleManagement
  (30, 15), -- LogManagement
  (30, 18), -- ConfigurationManagement
  (30, 24), -- ClientManagement
  (30, 27), -- NewsManagement
  (30, 29), -- InterfacesManagement
  (30, 40), -- ProductionPlanManagement
  (30, 43), -- InterfaceConfig

  -- RoleManagement
  (12, 7), -- RoleIndex
  (12, 8), -- RoleAdd
  (12, 9), -- RoleEdit
  (12, 10), -- RoleDelete
  (12, 11), -- RoleDetails

  -- LogManagement
  (15, 13), -- LogIndex
  (15, 14), -- LogDetails

  -- ConfigurationManagement
  (18, 16), -- ConfigurationIndex
  (18, 17), -- ConfigurationEdit

  -- ClientManagement
  (24, 19), -- ClientIndex
  (24, 20), -- ClientAdd
  (24, 21), -- ClientEdit
  (24, 22), -- ClientDelete
  (24, 23), -- ClientDetails

  -- NewsManagement
  (27, 25), -- NewsIndex
  (27, 26), -- NewsResend
  (27, 31), -- NewsDetails

  -- InterfacesManagement
  (29, 28), -- GIIMEI001Index
  (29, 33), -- INVSTO001Index
  (29, 34), -- GISET001Index
  (29, 35), -- GR001Index
  (29, 36), -- INVSCP001Index
  (29, 37), -- PLAN001Index
  (29, 38), -- PRODOVW001Index
  (29, 41), -- GPINIndex
  (29, 42), -- GCUVIndex

  -- Operador
  (32, 27), -- NewsManagement
  (32, 29), -- InterfacesManagement

  -- ProductionPlanManagement
  (40, 32), -- Operador  
  (40, 39)  -- PLAN001Upload
) AS source (RoleId, AccessRuleId) 
ON target.RoleId = source.AccessRuleId and
	target.AccessRuleId = source.AccessRuleId
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT (RoleId, AccessRuleId) 
	VALUES (source.RoleId, source.AccessRuleId) 
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;

-- ###############################################################
-- Reference Data for User, UserBasicCredentials, and User_AccessRule
-- ###############################################################
-- INFO(Richo): Only add admin user if the table is empty
IF (SELECT count(*) FROM [User]) = 0 
BEGIN	
	SET IDENTITY_INSERT [User] ON;
	INSERT INTO [User] (Id, DisplayName, Email, CreatedDate, [Enabled], [Description], [Name])
	VALUES (1, 'admin', 'admin', getutcdate(), 1, 'Administrador', 'admin');
	SET IDENTITY_INSERT [User] OFF;
	
	INSERT [dbo].[UserBasicCredentials] ([Id], [Password], [Salt], [UserId]) 
	VALUES ('admin', N'ᷖ䰀䔃걻遻጑ᚾ䘣窲ヵ꽼⇾裯罙嫱嚱ޞ匕＂੻鿲ѿ匱А赖蒣垚ᜈᕨྦྷ', N'', 1);

	INSERT INTO [User_AccessRule] (UserId, AccessRuleId)
	VALUES (1, 30);
END
