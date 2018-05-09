using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public abstract class SQLTemporalInterpreter : TSqlFragmentVisitor
    {
        public override void ExplicitVisit(AutomaticTuningDropIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AutomaticTuningCreateIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AutomaticTuningForceLastGoodPlanOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AutomaticTuningOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AutomaticTuningDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueryStoreTimeCleanupPolicyOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueryStoreMaxPlansPerQueryOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueryStoreMaxStorageSizeOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueryStoreIntervalLengthOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueryStoreDataFlushIntervalOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueryStoreSizeCleanupPolicyOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueryStoreCapturePolicyOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueryStoreDesiredStateOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueryStoreOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueryStoreDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AutomaticTuningMaintainIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FileStreamDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MaxSizeDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterTableAlterIndexStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableReplicateDistributionPolicy node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableDistributionPolicy node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableDistributionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableDataCompressionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FederationScheme node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateTableStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ConstraintDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ChangeRetentionChangeTrackingOptionDetail node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnStorageOptions node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnEncryptionAlgorithmParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnEncryptionTypeParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnEncryptionKeyNameParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnEncryptionDefinitionParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnEncryptionDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterTableAlterColumnStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IdentityOptions node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AutoCleanupChangeTrackingOptionDetail node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ChangeTrackingOptionDetail node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ChangeTrackingDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseModifyNameStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseRemoveFileStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseRemoveFileGroupStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseAddFileGroupStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseAddFileStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseRebuildLogStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseCollateStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseModifyFileStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GenericConfigurationOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OnOffPrimaryConfigurationOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DatabaseConfigurationSetOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DatabaseConfigurationClearOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseScopedConfigurationClearStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseScopedConfigurationSetStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseScopedConfigurationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MaxDopConfigurationOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableRoundRobinDistributionPolicy node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseModifyFileGroupStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseSetStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IdentifierDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LiteralDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ParameterizationDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WitnessDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PartnerDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PageVerifyDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TargetRecoveryTimeDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseTermination node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RecoveryDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DelayedDurabilityDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(HadrAvailabilityGroupDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(HadrDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ContainmentDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AutoCreateStatisticsDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OnOffDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CursorDefaultDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableHashDistributionPolicy node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableIndexType node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CertificateOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateCertificateStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterCertificateStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CertificateStatementBase node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ProviderEncryptionSource node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FileEncryptionSource node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AssemblyEncryptionSource node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateContractStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EncryptionSource node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateRemoteServiceBindingStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UserRemoteServiceBindingOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OnOffRemoteServiceBindingOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RemoteServiceBindingOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RemoteServiceBindingStatementBase node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreatePartitionSchemeStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PartitionParameterType node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterRemoteServiceBindingStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreatePartitionFunctionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ContractMessage node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateCredentialStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IPv4 node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ListenerIPEndpointProtocolOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CompressionEndpointProtocolOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PortsEndpointProtocolOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AuthenticationEndpointProtocolOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LiteralEndpointProtocolOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EndpointProtocolOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CredentialStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EndpointAffinity node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterEndpointStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateEndpointStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateAggregateStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterMessageTypeStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateMessageTypeStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MessageTypeStatementBase node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterCredentialStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterCreateEndpointStatementBase node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FileGroupDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateAsymmetricKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DbccOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RestoreStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BackupTransactionLogStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BackupDatabaseStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BackupStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UniqueConstraintDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(NullableConstraintDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ForeignKeyConstraintDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RestoreOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DefaultConstraintDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CompressionPartitionRange node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DataCompressionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TablePartitionOptionSpecifications node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PartitionSpecifications node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TablePartitionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableNonClusteredIndexType node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableClusteredIndexType node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CheckConstraintDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DbccNamedLiteral node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ScalarExpressionRestoreOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(StopRestoreOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DbccStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(InsertBulkColumnDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalTableColumnDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnDefinitionBase node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OrderBulkInsertOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LiteralBulkInsertOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BulkInsertOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MoveRestoreOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(InsertBulkStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BulkInsertBase node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BackupRestoreFileInfo node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MirrorToClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DeviceInfo node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BackupEncryptionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BackupOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FileStreamRestoreOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BulkInsertStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FileGrowthFileDeclarationOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MaxSizeFileDeclarationOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FileNameFileDeclarationOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SearchPropertyListFullTextIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(StopListFullTextIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ChangeTrackingFullTextIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FullTextIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateFullTextIndexStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FullTextIndexColumn node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LowPriorityLockWaitAbortAfterWaitOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FullTextCatalogAndFileGroup node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LowPriorityLockWaitMaxDurationOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OnlineIndexLowPriorityLockWaitOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OrderIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IgnoreDupKeyIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OnlineIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WaitAtLowPriorityOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MaxDurationOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IndexExpressionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LowPriorityLockWaitOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IndexStateOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EventTypeGroupContainer node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EventGroupContainer node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropMemberAlterRoleAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AddMemberAlterRoleAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RenameAlterRoleAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterRoleAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterRoleStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateRoleStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RoleStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EventTypeContainer node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterApplicationRoleStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ApplicationRoleStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ApplicationRoleOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterMasterKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateMasterKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MasterKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EventNotificationObjectScope node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateEventNotificationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateApplicationRoleStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateServerRoleStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FileGroupOrPartitionScheme node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExecuteAsClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateSynonymStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateTypeUddtStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateTypeUdtStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateTypeStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TryCatchStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EnableDisableTriggerStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueueOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterTableTriggerModificationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterTableDropTableElement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropClusteredConstraintWaitAtLowPriorityLockOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropClusteredConstraintMoveOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropClusteredConstraintValueOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropClusteredConstraintStateOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropClusteredConstraintOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LowPriorityLockWaitTableSwitchOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterTableDropTableElementStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateIndexStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueueStateOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueueValueOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateSelectiveXmlIndexStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateXmlIndexStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterIndexStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PartitionSpecifier node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IndexType node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IndexStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SystemTimePeriodDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueueProcedureOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IndexDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterQueueStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueueStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateRouteStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterRouteStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RouteStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RouteOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueueExecuteAsOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateQueueStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SoapMethod node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerRoleStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UserLoginOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ReconfigureStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CheckpointStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(KillStatsJobStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(KillQueryNotificationSubscriptionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(KillStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UseStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ThrowStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ShutdownStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RaiseErrorStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropSchemaStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropTriggerStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropRuleStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropDefaultStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropViewStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropFunctionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropProcedureStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RaiseErrorLegacyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropTableStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetUserStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetOnOffStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(NameFileDeclarationOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FileDeclarationOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FileDeclaration node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateDatabaseStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetErrorLevelStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetIdentityInsertStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetTextSizeStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TruncateTableStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetTransactionIsolationLevelStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetFipsFlaggerCommand node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GeneralSetCommand node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetCommand node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetOffsetsStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetRowCountStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetStatisticsStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PredicateSetStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetCommandStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropServerRoleStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropStatisticsStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MoveToDropIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CursorId node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetVariableStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CursorOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CursorDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DeclareCursorStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ReturnStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UpdateStatisticsStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CursorStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateStatisticsStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OnOffStatisticsOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(StatisticsPartitionRange node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ResampleStatisticsOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(StatisticsOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterUserStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateUserStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UserStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LiteralStatisticsOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FileStreamOnDropIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OpenCursorStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CryptoMechanism node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropIndexClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BackwardsCompatibleDropIndexClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropIndexClauseBase node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropIndexStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropChildObjectsStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropDatabaseStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropObjectsStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CloseCursorStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropUnownedObjectStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FetchCursorStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FetchType node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DeallocateCursorStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CloseMasterKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OpenMasterKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CloseSymmetricKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OpenSymmetricKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WhereClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableSwitchOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PayloadOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WsdlPayloadOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseEncryptionKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateDatabaseEncryptionKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DatabaseEncryptionKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OnOffAuditTargetOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LiteralAuditTargetOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MaxRolloverFilesAuditTargetOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MaxSizeAuditTargetOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AuditTargetOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(StateAuditOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OnFailureAuditOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AuditGuidAuditOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueueDelayAuditOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AuditOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AuditTarget node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropServerAuditStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropDatabaseEncryptionKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ResourcePoolStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ResourcePoolParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ResourcePoolAffinitySpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropWorkloadGroupStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterWorkloadGroupStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateWorkloadGroupStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WorkloadGroupParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WorkloadGroupImportanceParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WorkloadGroupResourceParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WorkloadGroupStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerAuditStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropExternalResourcePoolStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateExternalResourcePoolStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalResourcePoolAffinitySpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalResourcePoolParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalResourcePoolStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropResourcePoolStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterResourcePoolStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateResourcePoolStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterExternalResourcePoolStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateServerAuditStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ServerAuditStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropServerAuditSpecificationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DataModificationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TSqlScript node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IdentifierSnippet node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TSqlStatementSnippet node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TSqlFragmentSnippet node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DataModificationSpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SchemaObjectNameSnippet node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(StatementListSnippet node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BooleanExpressionSnippet node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ScalarExpressionSnippet node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RestoreMasterKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BackupMasterKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RestoreServiceMasterKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BackupServiceMasterKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SelectStatementSnippet node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BrokerPriorityStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MergeStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MergeActionClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerAuditSpecificationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateServerAuditSpecificationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropDatabaseAuditSpecificationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterDatabaseAuditSpecificationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateDatabaseAuditSpecificationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AuditActionGroupReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DatabaseAuditAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MergeSpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AuditActionSpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AuditSpecificationPart node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AuditSpecificationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateTypeTableStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(InsertMergeAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DeleteMergeAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UpdateMergeAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MergeAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AuditSpecificationDetail node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BrokerPriorityParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateBrokerPriorityStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterBrokerPriorityStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FailoverModeReplicaOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AvailabilityModeReplicaOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LiteralReplicaOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AvailabilityReplicaOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AvailabilityReplica node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterAvailabilityGroupStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateAvailabilityGroupStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PrimaryRoleReplicaOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AvailabilityGroupStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerConfigurationSetSoftNumaStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerConfigurationHadrClusterOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerConfigurationSetHadrClusterStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerConfigurationFailoverClusterPropertyOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerConfigurationSetFailoverClusterPropertyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerConfigurationDiagnosticsLogMaxSizeOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerConfigurationDiagnosticsLogOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerConfigurationSoftNumaOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerConfigurationSetDiagnosticsLogStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SecondaryRoleReplicaOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LiteralAvailabilityGroupOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TemporalClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SelectiveXmlIndexPromotedPath node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WithinGroupClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WindowDelimiter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WindowFrameClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateColumnStoreIndexStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DiskStatementOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AvailabilityGroupOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DiskStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropFederationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterFederationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateFederationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropAvailabilityGroupStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterAvailabilityGroupFailoverOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterAvailabilityGroupFailoverAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterAvailabilityGroupAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UseFederationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BackupRestoreMasterKeyStatementBase node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionSizeOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TargetDeclaration node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EventDeclarationCompareFunctionParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SourceDeclaration node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EventDeclarationSetParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EventDeclaration node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateEventSessionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EventSessionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SessionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EventSessionObjectName node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterCryptographicProviderStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateCryptographicProviderStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropFullTextStopListStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FullTextStopListAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterFullTextStopListStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateFullTextStopListStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropBrokerPriorityStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropCryptographicProviderStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionContainerOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EventRetentionSessionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LiteralSessionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerConfigurationSetBufferPoolExtensionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ProcessAffinityRange node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServerConfigurationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CellsPerObjectSpatialIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GridParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GridsSpatialIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BoundingBoxParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MemoryPartitionSessionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BoundingBoxSpatialIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SpatialIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateSpatialIndexStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterResourceGovernorStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropEventSessionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterEventSessionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OnOffSessionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MaxDispatchLatencySessionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SpatialIndexRegularOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BackupCertificateStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OnOffDialogOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ScalarExpressionDialogOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(HavingClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OutputIntoClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OutputClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GroupingSetsGroupingSpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GrandTotalGroupingSpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RollupGroupingSpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CubeGroupingSpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IdentityFunctionCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CompositeGroupingSpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GroupingSpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GroupByClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExpressionWithSortOrder node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GraphMatchExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GraphMatchPredicate node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BooleanIsNullExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BooleanBinaryExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExpressionGroupingSpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BooleanComparisonExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(JoinParenthesisTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(JoinTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ChangeTableVersionTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ChangeTableChangesTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DataModificationTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableReferenceWithAliasAndColumns node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableReferenceWithAlias node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SelectSetVariable node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OrderByClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SelectStarExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SelectElement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FromClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QuerySpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueryParenthesisExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueryExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OdbcQualifiedJoinTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QualifiedJoin node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SelectScalarExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BooleanTernaryExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BooleanParenthesisExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BooleanExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreationDispositionKeyOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ProviderKeyNameKeyOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IdentityValueKeyOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlgorithmKeyOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(KeySourceKeyOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(KeyOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateSymmetricKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterSymmetricKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SymmetricKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AuthenticationPayloadOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RolePayloadOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CharacterSetPayloadOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SchemaPayloadOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SessionTimeoutPayloadOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LiteralPayloadOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LoginTypePayloadOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EncryptionPayloadOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BooleanNotExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FullTextCatalogStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OnOffFullTextCatalogOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ScalarExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableSampleClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UnqualifiedJoin node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UnpivotedTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PivotedTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ComputeFunction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ComputeClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FullTextCatalogOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GlobalFunctionTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BinaryExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ServiceContract node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServiceStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateServiceStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterCreateServiceStatementBase node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterFullTextCatalogStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateFullTextCatalogStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BuiltInFunctionTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EnabledDisabledPayloadOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TopRowFilter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UnaryExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropQueueStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropMessageTypeStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropEndpointStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropContractStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RevertStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterLoginAddDropCredentialStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterLoginEnableDisableStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropRemoteServiceBindingStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterLoginOptionsStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PasswordAlterPrincipalOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AsymmetricKeyCreateLoginSource node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CertificateCreateLoginSource node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WindowsCreateLoginSource node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IdentifierPrincipalOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LiteralPrincipalOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OnOffPrincipalOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterLoginStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PrincipalOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropRouteStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SignatureStatementBase node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DialogOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BeginDialogStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BeginConversationTimerStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterServiceMasterKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterAsymmetricKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterSchemaStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WaitForSupportedStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropServiceStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SendStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GetConversationGroupStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MoveConversationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EndConversationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExecuteAsStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropEventNotificationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropSignatureStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AddSignatureStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ReceiveStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OffsetClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PasswordCreateLoginSource node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateLoginStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropMasterKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropUserStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropTypeStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropRoleStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropLoginStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropFullTextIndexStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropFullTextCatalogStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropSymmetricKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropApplicationRoleStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropAggregateStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropSynonymStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropPartitionSchemeStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropPartitionFunctionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(VariableMethodCallTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(VariableTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BinaryQueryExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropAssemblyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateLoginSource node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropAsymmetricKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropCredentialStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropSearchPropertyListStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropSearchPropertyListAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AddSearchPropertyListAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SearchPropertyListAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterSearchPropertyListStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateSearchPropertyListStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterColumnAlterFullTextIndexAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropCertificateStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AddAlterFullTextIndexAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetSearchPropertyListAlterFullTextIndexAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetStopListAlterFullTextIndexAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SimpleAlterFullTextIndexAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterFullTextIndexAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterFullTextIndexStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterPartitionSchemeStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterPartitionFunctionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropAlterFullTextIndexAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterTableSwitchStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SizeFileDeclarationOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CompressionDelayIndexOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ForClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OdbcLiteral node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SelectStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LiteralRange node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(StatementWithCtesAndXmlNamespaces node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ValueExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(VariableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UserDefinedTypePropertyAccess node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OptionValue node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FullTextPredicate node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OnOffOptionValue node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(InPredicate node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LiteralOptionValue node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GlobalVariableExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LikePredicate node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IdentifierOrValueExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExistsPredicate node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IdentifierOrScalarExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SubqueryComparisonPredicate node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ParenthesisExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(InlineDerivedTable node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnReferenceExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(QueryDerivedTable node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MaxLiteral node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DefaultLiteral node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BrowseForClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IdentifierLiteral node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OptimizeForOptimizerHint node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RowValue node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ForceSeekTableHint node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PrintStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableHintsOptimizerHint node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UpdateCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TSEqualCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LiteralOptimizerHint node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PrimaryExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OptimizerHint node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(Literal node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(NextValueForExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UpdateForClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(NumericLiteral node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(JsonForClauseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RealLiteral node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(JsonForClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MoneyLiteral node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(XmlForClauseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BinaryLiteral node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(StringLiteral node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(XmlForClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(NullLiteral node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ReadOnlyForClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IntegerLiteral node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExecuteInsertSource node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LiteralTableHint node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SequenceOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropColumnMasterKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DataTypeReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnEncryptionKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateColumnEncryptionKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableValuedFunctionReturnType node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterColumnEncryptionKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FunctionReturnType node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropColumnEncryptionKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WithCtesAndXmlNamespaces node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnEncryptionKeyValue node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnEncryptionKeyValueParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CommonTableExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnMasterKeyNameParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(XmlNamespacesAliasElement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnEncryptionAlgorithmNameParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(XmlNamespacesDefaultElement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(EncryptedValueParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalTableStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(XmlNamespacesElement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalTableOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(XmlNamespaces node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalTableLiteralOrIdentifierOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExecuteAsFunctionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ParameterizedDataTypeReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnMasterKeyPathParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SqlDataTypeReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnMasterKeyStoreProviderNameParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IndexTableHint node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DataTypeSequenceOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableHint node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ScalarExpressionSequenceOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SchemaObjectFunctionTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateSequenceStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterSequenceStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(NamedTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropSequenceStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DeclareTableVariableStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SecurityPolicyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SequenceStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DeclareTableVariableBody node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SecurityPolicyOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SelectFunctionReturnType node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateSecurityPolicyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterSecurityPolicyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ScalarFunctionReturnType node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropSecurityPolicyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(XmlDataTypeReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateColumnMasterKeyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UserDataTypeReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnMasterKeyParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SecurityPredicateAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SelectInsertSource node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UseHintList node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ValuesInsertSource node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IfStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LeftFunctionCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LabelStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UserDefinedTypeCallTarget node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MultiPartIdentifier node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SchemaObjectName node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MultiPartIdentifierCallTarget node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ChildObjectName node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExpressionCallTarget node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ProcedureParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CallTarget node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TransactionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WhileStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FunctionCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DeleteStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AtTimeZoneCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UpdateDeleteSpecificationBase node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TryCastCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DeleteSpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(InsertStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CastCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(InsertSpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TryParseCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RightFunctionCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GoToStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DeclareVariableStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PartitionFunctionCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IdentifierAtomicBlockOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AtomicBlockOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OnOffAtomicBlockOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BeginEndAtomicBlockStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BeginTransactionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BreakStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BeginEndBlockStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ColumnWithSortOrder node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterFunctionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CommitTransactionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OdbcConvertSpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UpdateStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RollbackTransactionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExtractFromExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ContinueStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OdbcFunctionCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateDefaultStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ScalarSubquery node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateFunctionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateOrAlterFunctionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ParameterlessCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateRuleStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OverClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DeclareVariableElement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SaveTransactionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ParseCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UpdateSpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateSchemaStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FullTextTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GrantStatement80 node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(IIfCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DenyStatement80 node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CoalesceExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RevokeStatement80 node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SecurityElement80 node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(NullIfExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CommandSecurityElement80 node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SearchedCaseExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PrivilegeSecurityElement80 node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SecurityStatementBody80 node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SimpleCaseExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SecurityUserClause80 node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CaseExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SqlCommandIdentifier node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SearchedWhenClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SetClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SimpleWhenClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AssignmentSetClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FunctionCallSetClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WhenClause node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(InsertSource node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(VariableValuePair node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(Privilege80 node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalTableDistributionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SecurityPrincipal node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SecurityTargetObjectName node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TryConvertCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WaitForStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ConvertCall node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ReadTextStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SchemaDeclarationItemOpenjson node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(UpdateTextStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(WriteTextStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SchemaDeclarationItem node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TextModificationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AdHocTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LineNoStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SemanticTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OpenQueryTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(GrantStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(BulkOpenRowset node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DenyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(InternalOpenRowset node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RevokeStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OpenRowsetTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterAuthorizationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(Permission node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OpenJsonTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SecurityTargetObject node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OpenXmlTableReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SecurityStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalTableRejectTypeOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SchemaObjectNameOrValueExpression node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LiteralAtomicBlockOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateProcedureStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ResultColumnDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropExternalDataSourceStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExecuteAsTriggerOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RemoteDataArchiveAlterTableOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AssemblyOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterExternalDataSourceStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(InlineResultSetDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateOrAlterProcedureStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExecutableProcedureReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterTableSetStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RemoteDataArchiveDatabaseOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TableOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(OnOffAssemblyOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ProcedureReference node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExecuteParameter node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RemoteDataArchiveDatabaseSetting node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalDataSourceLiteralOrIdentifierOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ResultSetDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterTableFileTableNamespaceStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(PermissionSetAssemblyOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExecutableStringList node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MethodSpecifier node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RemoteDataArchiveDbServerSetting node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalDataSourceOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TriggerObject node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateExternalDataSourceStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterAssemblyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RemoteDataArchiveTableOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalFileFormatStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateExternalFileFormatStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FileTableDirectoryTableOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateTriggerStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FileTableCollateFileNameTableOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateOrAlterTriggerStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropExternalFileFormatStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExecuteContext node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalFileFormatContainerOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FileTableConstraintNameTableOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TriggerStatementBody node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalFileFormatUseDefaultTypeOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FileStreamOnTableOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AssemblyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExecutableEntity node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExecuteSpecification node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterTriggerStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(MemoryOptimizedTableOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalFileFormatLiteralOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(Identifier node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateAssemblyStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(LockEscalationTableOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalFileFormatOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DurabilityTableOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SchemaObjectResultSetDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TriggerAction node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterProcedureStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ProcedureReferenceName node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ResultSetsExecuteOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalDataSourceStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(TriggerOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterTableAddTableElementStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ProcedureStatementBodyBase node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RemoteDataArchiveDbFederatedServiceAccountSetting node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AddFileSpec node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateViewStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExecuteAsProcedureOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateXmlSchemaCollectionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExecuteStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FunctionStatementBody node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalTableShardedDistributionPolicy node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateExternalTableStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterTableRebuildStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterXmlSchemaCollectionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(StatementList node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(FunctionOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalTableReplicatedDistributionPolicy node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RetentionPeriodDefinition node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalTableRoundRobinDistributionPolicy node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(CreateOrAlterViewStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropXmlSchemaCollectionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterTableChangeTrackingModificationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterTableConstraintModificationStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(RemoteDataArchiveDbCredentialSetting node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(SystemVersioningTableOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AssemblyName node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ViewStatementBody node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExternalTableDistributionPolicy node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ViewOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ProcedureStatementBody node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterTableAlterPartitionStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ProcedureOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(DropExternalTableStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AdHocDataSource node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterViewStatement node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(ExecuteOption node) { node.AcceptChildren(this); this.Visit(node); }
        public override void ExplicitVisit(AlterTableStatement node) { node.AcceptChildren(this); this.Visit(node); }


        public override void Visit(AlterPartitionFunctionStatement node) { throw new NotImplementedException(); }
        public override void Visit(AvailabilityReplica node) { throw new NotImplementedException(); }
        public override void Visit(WindowsCreateLoginSource node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerConfigurationDiagnosticsLogMaxSizeOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterFullTextIndexStatement node) { throw new NotImplementedException(); }
        public override void Visit(OpenQueryTableReference node) { throw new NotImplementedException(); }
        public override void Visit(ProcedureReferenceName node) { throw new NotImplementedException(); }
        public override void Visit(AlterPartitionSchemeStatement node) { throw new NotImplementedException(); }
        public override void Visit(FullTextTableReference node) { throw new NotImplementedException(); }
        public override void Visit(SearchedCaseExpression node) { throw new NotImplementedException(); }
        public override void Visit(DropMasterKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(SchemaDeclarationItemOpenjson node) { throw new NotImplementedException(); }
        public override void Visit(DropSymmetricKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(PasswordAlterPrincipalOption node) { throw new NotImplementedException(); }
        public override void Visit(SimpleCaseExpression node) { throw new NotImplementedException(); }
        public override void Visit(AsymmetricKeyCreateLoginSource node) { throw new NotImplementedException(); }
        public override void Visit(LiteralReplicaOption node) { throw new NotImplementedException(); }
        public override void Visit(AdHocTableReference node) { throw new NotImplementedException(); }
        public override void Visit(ExecutableEntity node) { throw new NotImplementedException(); }
        public override void Visit(SchemaDeclarationItem node) { throw new NotImplementedException(); }
        public override void Visit(AvailabilityReplicaOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerConfigurationDiagnosticsLogOption node) { throw new NotImplementedException(); }
        public override void Visit(DropCertificateStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterViewStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropCredentialStatement node) { throw new NotImplementedException(); }
        public override void Visit(CertificateCreateLoginSource node) { throw new NotImplementedException(); }
        public override void Visit(DropAsymmetricKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(IdentifierPrincipalOption node) { throw new NotImplementedException(); }
        public override void Visit(CreateAvailabilityGroupStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterFullTextIndexAction node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerConfigurationSoftNumaOption node) { throw new NotImplementedException(); }
        public override void Visit(CreateSearchPropertyListStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExecutableStringList node) { throw new NotImplementedException(); }
        public override void Visit(AlterSearchPropertyListStatement node) { throw new NotImplementedException(); }
        public override void Visit(IIfCall node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerConfigurationSetSoftNumaStatement node) { throw new NotImplementedException(); }
        public override void Visit(OpenXmlTableReference node) { throw new NotImplementedException(); }
        public override void Visit(SearchPropertyListAction node) { throw new NotImplementedException(); }
        public override void Visit(CreateLoginSource node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerConfigurationSetHadrClusterStatement node) { throw new NotImplementedException(); }
        public override void Visit(AddSearchPropertyListAction node) { throw new NotImplementedException(); }
        public override void Visit(CreateLoginStatement node) { throw new NotImplementedException(); }
        public override void Visit(SemanticTableReference node) { throw new NotImplementedException(); }
        public override void Visit(DropSearchPropertyListAction node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerConfigurationHadrClusterOption node) { throw new NotImplementedException(); }
        public override void Visit(AdHocDataSource node) { throw new NotImplementedException(); }
        public override void Visit(DropSearchPropertyListStatement node) { throw new NotImplementedException(); }
        public override void Visit(PasswordCreateLoginSource node) { throw new NotImplementedException(); }
        public override void Visit(AlterAvailabilityGroupStatement node) { throw new NotImplementedException(); }
        public override void Visit(OpenJsonTableReference node) { throw new NotImplementedException(); }
        public override void Visit(AlterColumnAlterFullTextIndexAction node) { throw new NotImplementedException(); }
        public override void Visit(BulkOpenRowset node) { throw new NotImplementedException(); }
        public override void Visit(NullIfExpression node) { throw new NotImplementedException(); }
        public override void Visit(SimpleAlterFullTextIndexAction node) { throw new NotImplementedException(); }
        public override void Visit(LiteralPrincipalOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerConfigurationSetFailoverClusterPropertyStatement node) { throw new NotImplementedException(); }
        public override void Visit(SetStopListAlterFullTextIndexAction node) { throw new NotImplementedException(); }
        public override void Visit(InternalOpenRowset node) { throw new NotImplementedException(); }
        public override void Visit(SetSearchPropertyListAlterFullTextIndexAction node) { throw new NotImplementedException(); }
        public override void Visit(ViewOption node) { throw new NotImplementedException(); }
        public override void Visit(OnOffPrincipalOption node) { throw new NotImplementedException(); }
        public override void Visit(ExecutableProcedureReference node) { throw new NotImplementedException(); }
        public override void Visit(AvailabilityGroupStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropAlterFullTextIndexAction node) { throw new NotImplementedException(); }
        public override void Visit(OpenRowsetTableReference node) { throw new NotImplementedException(); }
        public override void Visit(AddAlterFullTextIndexAction node) { throw new NotImplementedException(); }
        public override void Visit(CoalesceExpression node) { throw new NotImplementedException(); }
        public override void Visit(PrincipalOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerConfigurationFailoverClusterPropertyOption node) { throw new NotImplementedException(); }
        public override void Visit(DropUserStatement node) { throw new NotImplementedException(); }
        public override void Visit(CastCall node) { throw new NotImplementedException(); }
        public override void Visit(AvailabilityModeReplicaOption node) { throw new NotImplementedException(); }
        public override void Visit(IdentityFunctionCall node) { throw new NotImplementedException(); }
        public override void Visit(CreateColumnStoreIndexStatement node) { throw new NotImplementedException(); }
        public override void Visit(JoinParenthesisTableReference node) { throw new NotImplementedException(); }
        public override void Visit(OdbcFunctionCall node) { throw new NotImplementedException(); }
        public override void Visit(OrderByClause node) { throw new NotImplementedException(); }
        public override void Visit(DiskStatementOption node) { throw new NotImplementedException(); }
        public override void Visit(JoinTableReference node) { throw new NotImplementedException(); }
        public override void Visit(ScalarSubquery node) { throw new NotImplementedException(); }
        public override void Visit(QualifiedJoin node) { throw new NotImplementedException(); }
        public override void Visit(ResultSetsExecuteOption node) { throw new NotImplementedException(); }
        public override void Visit(OdbcQualifiedJoinTableReference node) { throw new NotImplementedException(); }
        public override void Visit(ExecuteOption node) { throw new NotImplementedException(); }
        public override void Visit(ParameterlessCall node) { throw new NotImplementedException(); }
        public override void Visit(QueryExpression node) { throw new NotImplementedException(); }
        public override void Visit(QueryParenthesisExpression node) { throw new NotImplementedException(); }
        public override void Visit(UseFederationStatement node) { throw new NotImplementedException(); }
        public override void Visit(OverClause node) { throw new NotImplementedException(); }
        public override void Visit(QuerySpecification node) { throw new NotImplementedException(); }
        public override void Visit(ResultSetDefinition node) { throw new NotImplementedException(); }
        public override void Visit(FromClause node) { throw new NotImplementedException(); }
        public override void Visit(PartitionFunctionCall node) { throw new NotImplementedException(); }
        public override void Visit(SelectElement node) { throw new NotImplementedException(); }
        public override void Visit(DropFederationStatement node) { throw new NotImplementedException(); }
        public override void Visit(SelectScalarExpression node) { throw new NotImplementedException(); }
        public override void Visit(DiskStatement node) { throw new NotImplementedException(); }
        public override void Visit(RightFunctionCall node) { throw new NotImplementedException(); }
        public override void Visit(ExtractFromExpression node) { throw new NotImplementedException(); }
        public override void Visit(WindowFrameClause node) { throw new NotImplementedException(); }
        public override void Visit(LiteralAtomicBlockOption node) { throw new NotImplementedException(); }
        public override void Visit(ExpressionWithSortOrder node) { throw new NotImplementedException(); }
        public override void Visit(TSqlFragment fragment) { throw new NotImplementedException(); }
        public override void Visit(GroupByClause node) { throw new NotImplementedException(); }
        public override void Visit(TemporalClause node) { throw new NotImplementedException(); }
        public override void Visit(AtomicBlockOption node) { throw new NotImplementedException(); }
        public override void Visit(GroupingSpecification node) { throw new NotImplementedException(); }
        public override void Visit(StatementList node) { throw new NotImplementedException(); }
        public override void Visit(ExpressionGroupingSpecification node) { throw new NotImplementedException(); }
        public override void Visit(BeginEndAtomicBlockStatement node) { throw new NotImplementedException(); }
        public override void Visit(CompositeGroupingSpecification node) { throw new NotImplementedException(); }
        public override void Visit(HavingClause node) { throw new NotImplementedException(); }
        public override void Visit(SelectiveXmlIndexPromotedPath node) { throw new NotImplementedException(); }
        public override void Visit(BeginEndBlockStatement node) { throw new NotImplementedException(); }
        public override void Visit(WithinGroupClause node) { throw new NotImplementedException(); }
        public override void Visit(RollupGroupingSpecification node) { throw new NotImplementedException(); }
        public override void Visit(GrandTotalGroupingSpecification node) { throw new NotImplementedException(); }
        public override void Visit(ExecuteStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterFunctionStatement node) { throw new NotImplementedException(); }
        public override void Visit(GroupingSetsGroupingSpecification node) { throw new NotImplementedException(); }
        public override void Visit(WindowDelimiter node) { throw new NotImplementedException(); }
        public override void Visit(OutputClause node) { throw new NotImplementedException(); }
        public override void Visit(OdbcConvertSpecification node) { throw new NotImplementedException(); }
        public override void Visit(OutputIntoClause node) { throw new NotImplementedException(); }
        public override void Visit(CubeGroupingSpecification node) { throw new NotImplementedException(); }
        public override void Visit(ConvertCall node) { throw new NotImplementedException(); }
        public override void Visit(SelectStarExpression node) { throw new NotImplementedException(); }
        public override void Visit(SelectSetVariable node) { throw new NotImplementedException(); }
        public override void Visit(LiteralAvailabilityGroupOption node) { throw new NotImplementedException(); }
        public override void Visit(ExecuteSpecification node) { throw new NotImplementedException(); }
        public override void Visit(DropPartitionFunctionStatement node) { throw new NotImplementedException(); }
        public override void Visit(TryCastCall node) { throw new NotImplementedException(); }
        public override void Visit(DropPartitionSchemeStatement node) { throw new NotImplementedException(); }
        public override void Visit(AvailabilityGroupOption node) { throw new NotImplementedException(); }
        public override void Visit(DropSynonymStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterLoginStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropAggregateStatement node) { throw new NotImplementedException(); }
        public override void Visit(SecondaryRoleReplicaOption node) { throw new NotImplementedException(); }
        public override void Visit(DropAssemblyStatement node) { throw new NotImplementedException(); }
        public override void Visit(VariableMethodCallTableReference node) { throw new NotImplementedException(); }
        public override void Visit(ExecuteContext node) { throw new NotImplementedException(); }
        public override void Visit(DropApplicationRoleStatement node) { throw new NotImplementedException(); }
        public override void Visit(PrimaryRoleReplicaOption node) { throw new NotImplementedException(); }
        public override void Visit(DropFullTextCatalogStatement node) { throw new NotImplementedException(); }
        public override void Visit(ParseCall node) { throw new NotImplementedException(); }
        public override void Visit(DropFullTextIndexStatement node) { throw new NotImplementedException(); }
        public override void Visit(FailoverModeReplicaOption node) { throw new NotImplementedException(); }
        public override void Visit(DropLoginStatement node) { throw new NotImplementedException(); }
        public override void Visit(TryConvertCall node) { throw new NotImplementedException(); }
        public override void Visit(DropRoleStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExecuteParameter node) { throw new NotImplementedException(); }
        public override void Visit(DropTypeStatement node) { throw new NotImplementedException(); }
        public override void Visit(TryParseCall node) { throw new NotImplementedException(); }
        public override void Visit(AlterFederationStatement node) { throw new NotImplementedException(); }
        public override void Visit(AtTimeZoneCall node) { throw new NotImplementedException(); }
        public override void Visit(BinaryQueryExpression node) { throw new NotImplementedException(); }
        public override void Visit(InlineResultSetDefinition node) { throw new NotImplementedException(); }
        public override void Visit(LeftFunctionCall node) { throw new NotImplementedException(); }
        public override void Visit(TableReference node) { throw new NotImplementedException(); }
        public override void Visit(CreateFederationStatement node) { throw new NotImplementedException(); }
        public override void Visit(TableReferenceWithAlias node) { throw new NotImplementedException(); }
        public override void Visit(UserDefinedTypeCallTarget node) { throw new NotImplementedException(); }
        public override void Visit(TableReferenceWithAliasAndColumns node) { throw new NotImplementedException(); }
        public override void Visit(DropAvailabilityGroupStatement node) { throw new NotImplementedException(); }
        public override void Visit(DataModificationTableReference node) { throw new NotImplementedException(); }
        public override void Visit(MultiPartIdentifierCallTarget node) { throw new NotImplementedException(); }
        public override void Visit(ResultColumnDefinition node) { throw new NotImplementedException(); }
        public override void Visit(VariableTableReference node) { throw new NotImplementedException(); }
        public override void Visit(ChangeTableChangesTableReference node) { throw new NotImplementedException(); }
        public override void Visit(AlterAvailabilityGroupFailoverOption node) { throw new NotImplementedException(); }
        public override void Visit(ExpressionCallTarget node) { throw new NotImplementedException(); }
        public override void Visit(BooleanTernaryExpression node) { throw new NotImplementedException(); }
        public override void Visit(AlterAvailabilityGroupFailoverAction node) { throw new NotImplementedException(); }
        public override void Visit(TopRowFilter node) { throw new NotImplementedException(); }
        public override void Visit(CallTarget node) { throw new NotImplementedException(); }
        public override void Visit(OffsetClause node) { throw new NotImplementedException(); }
        public override void Visit(SchemaObjectResultSetDefinition node) { throw new NotImplementedException(); }
        public override void Visit(UnaryExpression node) { throw new NotImplementedException(); }
        public override void Visit(FunctionCall node) { throw new NotImplementedException(); }
        public override void Visit(AlterAvailabilityGroupAction node) { throw new NotImplementedException(); }
        public override void Visit(ChangeTableVersionTableReference node) { throw new NotImplementedException(); }
        public override void Visit(CaseExpression node) { throw new NotImplementedException(); }
        public override void Visit(UseHintList node) { throw new NotImplementedException(); }
        public override void Visit(AlterLoginOptionsStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateEventSessionStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerAuditSpecificationStatement node) { throw new NotImplementedException(); }
        public override void Visit(DeclareTableVariableStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropServerAuditSpecificationStatement node) { throw new NotImplementedException(); }
        public override void Visit(ServerAuditStatement node) { throw new NotImplementedException(); }
        public override void Visit(DeclareTableVariableBody node) { throw new NotImplementedException(); }
        public override void Visit(EventSessionStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateServerAuditStatement node) { throw new NotImplementedException(); }
        public override void Visit(ProcedureReference node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerAuditStatement node) { throw new NotImplementedException(); }
        public override void Visit(TableDefinition node) { throw new NotImplementedException(); }
        public override void Visit(CreateServerAuditSpecificationStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropServerAuditStatement node) { throw new NotImplementedException(); }
        public override void Visit(AuditTarget node) { throw new NotImplementedException(); }
        public override void Visit(SelectFunctionReturnType node) { throw new NotImplementedException(); }
        public override void Visit(AuditOption node) { throw new NotImplementedException(); }
        public override void Visit(DropCryptographicProviderStatement node) { throw new NotImplementedException(); }
        public override void Visit(QueueDelayAuditOption node) { throw new NotImplementedException(); }
        public override void Visit(ScalarFunctionReturnType node) { throw new NotImplementedException(); }
        public override void Visit(MethodSpecifier node) { throw new NotImplementedException(); }
        public override void Visit(AuditGuidAuditOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterCryptographicProviderStatement node) { throw new NotImplementedException(); }
        public override void Visit(OnFailureAuditOption node) { throw new NotImplementedException(); }
        public override void Visit(XmlDataTypeReference node) { throw new NotImplementedException(); }
        public override void Visit(EventSessionObjectName node) { throw new NotImplementedException(); }
        public override void Visit(StateAuditOption node) { throw new NotImplementedException(); }
        public override void Visit(CreateOrAlterProcedureStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropDatabaseAuditSpecificationStatement node) { throw new NotImplementedException(); }
        public override void Visit(InlineDerivedTable node) { throw new NotImplementedException(); }
        public override void Visit(DeleteMergeAction node) { throw new NotImplementedException(); }
        public override void Visit(InsertMergeAction node) { throw new NotImplementedException(); }
        public override void Visit(TargetDeclaration node) { throw new NotImplementedException(); }
        public override void Visit(QueryDerivedTable node) { throw new NotImplementedException(); }
        public override void Visit(CreateTypeTableStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterProcedureStatement node) { throw new NotImplementedException(); }
        public override void Visit(AuditSpecificationStatement node) { throw new NotImplementedException(); }
        public override void Visit(LiteralTableHint node) { throw new NotImplementedException(); }
        public override void Visit(AuditSpecificationPart node) { throw new NotImplementedException(); }
        public override void Visit(EventDeclarationCompareFunctionParameter node) { throw new NotImplementedException(); }
        public override void Visit(NamedTableReference node) { throw new NotImplementedException(); }
        public override void Visit(AuditSpecificationDetail node) { throw new NotImplementedException(); }
        public override void Visit(SourceDeclaration node) { throw new NotImplementedException(); }
        public override void Visit(AuditActionSpecification node) { throw new NotImplementedException(); }
        public override void Visit(DatabaseAuditAction node) { throw new NotImplementedException(); }
        public override void Visit(CreateProcedureStatement node) { throw new NotImplementedException(); }
        public override void Visit(TableHint node) { throw new NotImplementedException(); }
        public override void Visit(AuditActionGroupReference node) { throw new NotImplementedException(); }
        public override void Visit(EventDeclarationSetParameter node) { throw new NotImplementedException(); }
        public override void Visit(CreateDatabaseAuditSpecificationStatement node) { throw new NotImplementedException(); }
        public override void Visit(SchemaObjectFunctionTableReference node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseAuditSpecificationStatement node) { throw new NotImplementedException(); }
        public override void Visit(EventDeclaration node) { throw new NotImplementedException(); }
        public override void Visit(IndexTableHint node) { throw new NotImplementedException(); }
        public override void Visit(CreateCryptographicProviderStatement node) { throw new NotImplementedException(); }
        public override void Visit(AuditTargetOption node) { throw new NotImplementedException(); }
        public override void Visit(UserDataTypeReference node) { throw new NotImplementedException(); }
        public override void Visit(CommonTableExpression node) { throw new NotImplementedException(); }
        public override void Visit(ProcedureOption node) { throw new NotImplementedException(); }
        public override void Visit(ExternalResourcePoolStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateBrokerPriorityStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalResourcePoolParameter node) { throw new NotImplementedException(); }
        public override void Visit(XmlNamespacesAliasElement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalResourcePoolAffinitySpecification node) { throw new NotImplementedException(); }
        public override void Visit(BrokerPriorityParameter node) { throw new NotImplementedException(); }
        public override void Visit(CreateExternalResourcePoolStatement node) { throw new NotImplementedException(); }
        public override void Visit(XmlNamespacesDefaultElement node) { throw new NotImplementedException(); }
        public override void Visit(AlterExternalResourcePoolStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropResourcePoolStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExecuteAsProcedureOption node) { throw new NotImplementedException(); }
        public override void Visit(XmlNamespacesElement node) { throw new NotImplementedException(); }
        public override void Visit(BrokerPriorityStatement node) { throw new NotImplementedException(); }
        public override void Visit(WorkloadGroupStatement node) { throw new NotImplementedException(); }
        public override void Visit(WorkloadGroupResourceParameter node) { throw new NotImplementedException(); }
        public override void Visit(DropWorkloadGroupStatement node) { throw new NotImplementedException(); }
        public override void Visit(XmlNamespaces node) { throw new NotImplementedException(); }
        public override void Visit(WorkloadGroupImportanceParameter node) { throw new NotImplementedException(); }
        public override void Visit(FunctionOption node) { throw new NotImplementedException(); }
        public override void Visit(WorkloadGroupParameter node) { throw new NotImplementedException(); }
        public override void Visit(ExecuteAsFunctionOption node) { throw new NotImplementedException(); }
        public override void Visit(CreateWorkloadGroupStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropExternalResourcePoolStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterBrokerPriorityStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterResourcePoolStatement node) { throw new NotImplementedException(); }
        public override void Visit(WithCtesAndXmlNamespaces node) { throw new NotImplementedException(); }
        public override void Visit(MaxSizeAuditTargetOption node) { throw new NotImplementedException(); }
        public override void Visit(ProcedureStatementBody node) { throw new NotImplementedException(); }
        public override void Visit(DropFullTextStopListStatement node) { throw new NotImplementedException(); }
        public override void Visit(MaxRolloverFilesAuditTargetOption node) { throw new NotImplementedException(); }
        public override void Visit(SqlDataTypeReference node) { throw new NotImplementedException(); }
        public override void Visit(LiteralAuditTargetOption node) { throw new NotImplementedException(); }
        public override void Visit(OnOffAuditTargetOption node) { throw new NotImplementedException(); }
        public override void Visit(FullTextStopListAction node) { throw new NotImplementedException(); }
        public override void Visit(ParameterizedDataTypeReference node) { throw new NotImplementedException(); }
        public override void Visit(DatabaseEncryptionKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(ProcedureStatementBodyBase node) { throw new NotImplementedException(); }
        public override void Visit(CreateDatabaseEncryptionKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(DataTypeReference node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseEncryptionKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterFullTextStopListStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropDatabaseEncryptionKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(TableValuedFunctionReturnType node) { throw new NotImplementedException(); }
        public override void Visit(CreateFullTextStopListStatement node) { throw new NotImplementedException(); }
        public override void Visit(ResourcePoolStatement node) { throw new NotImplementedException(); }
        public override void Visit(ResourcePoolParameter node) { throw new NotImplementedException(); }
        public override void Visit(FunctionStatementBody node) { throw new NotImplementedException(); }
        public override void Visit(FunctionReturnType node) { throw new NotImplementedException(); }
        public override void Visit(ResourcePoolAffinitySpecification node) { throw new NotImplementedException(); }
        public override void Visit(DropBrokerPriorityStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateResourcePoolStatement node) { throw new NotImplementedException(); }
        public override void Visit(UpdateMergeAction node) { throw new NotImplementedException(); }
        public override void Visit(SessionOption node) { throw new NotImplementedException(); }
        public override void Visit(Identifier node) { throw new NotImplementedException(); }
        public override void Visit(MergeAction node) { throw new NotImplementedException(); }
        public override void Visit(TriggerObject node) { throw new NotImplementedException(); }
        public override void Visit(ExecuteAsStatement node) { throw new NotImplementedException(); }
        public override void Visit(TableHintsOptimizerHint node) { throw new NotImplementedException(); }
        public override void Visit(EndConversationStatement node) { throw new NotImplementedException(); }
        public override void Visit(CellsPerObjectSpatialIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(MoveConversationStatement node) { throw new NotImplementedException(); }
        public override void Visit(LiteralOptimizerHint node) { throw new NotImplementedException(); }
        public override void Visit(GridParameter node) { throw new NotImplementedException(); }
        public override void Visit(GetConversationGroupStatement node) { throw new NotImplementedException(); }
        public override void Visit(ReceiveStatement node) { throw new NotImplementedException(); }
        public override void Visit(TriggerOption node) { throw new NotImplementedException(); }
        public override void Visit(DropEventNotificationStatement node) { throw new NotImplementedException(); }
        public override void Visit(OptimizerHint node) { throw new NotImplementedException(); }
        public override void Visit(GridsSpatialIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(WaitForSupportedStatement node) { throw new NotImplementedException(); }
        public override void Visit(UpdateForClause node) { throw new NotImplementedException(); }
        public override void Visit(AlterSchemaStatement node) { throw new NotImplementedException(); }
        public override void Visit(BoundingBoxParameter node) { throw new NotImplementedException(); }
        public override void Visit(AlterAsymmetricKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(JsonForClauseOption node) { throw new NotImplementedException(); }
        public override void Visit(ExecuteAsTriggerOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterServiceMasterKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(BoundingBoxSpatialIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(BeginConversationTimerStatement node) { throw new NotImplementedException(); }
        public override void Visit(SendStatement node) { throw new NotImplementedException(); }
        public override void Visit(ForceSeekTableHint node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerConfigurationStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropSignatureStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateViewStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterLoginEnableDisableStatement node) { throw new NotImplementedException(); }
        public override void Visit(SearchedWhenClause node) { throw new NotImplementedException(); }
        public override void Visit(AlterLoginAddDropCredentialStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerConfigurationBufferPoolExtensionSizeOption node) { throw new NotImplementedException(); }
        public override void Visit(RevertStatement node) { throw new NotImplementedException(); }
        public override void Visit(SimpleWhenClause node) { throw new NotImplementedException(); }
        public override void Visit(DropContractStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerConfigurationBufferPoolExtensionContainerOption node) { throw new NotImplementedException(); }
        public override void Visit(DropEndpointStatement node) { throw new NotImplementedException(); }
        public override void Visit(WhenClause node) { throw new NotImplementedException(); }
        public override void Visit(CreateOrAlterViewStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropMessageTypeStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerConfigurationBufferPoolExtensionOption node) { throw new NotImplementedException(); }
        public override void Visit(DropQueueStatement node) { throw new NotImplementedException(); }
        public override void Visit(VariableValuePair node) { throw new NotImplementedException(); }
        public override void Visit(DropRemoteServiceBindingStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerConfigurationSetBufferPoolExtensionStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropRouteStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropServiceStatement node) { throw new NotImplementedException(); }
        public override void Visit(ViewStatementBody node) { throw new NotImplementedException(); }
        public override void Visit(ProcessAffinityRange node) { throw new NotImplementedException(); }
        public override void Visit(SignatureStatementBase node) { throw new NotImplementedException(); }
        public override void Visit(OptimizeForOptimizerHint node) { throw new NotImplementedException(); }
        public override void Visit(AddSignatureStatement node) { throw new NotImplementedException(); }
        public override void Visit(JsonForClause node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerConfigurationSetDiagnosticsLogStatement node) { throw new NotImplementedException(); }
        public override void Visit(BeginDialogStatement node) { throw new NotImplementedException(); }
        public override void Visit(DialogOption node) { throw new NotImplementedException(); }
        public override void Visit(TSqlFragmentSnippet node) { throw new NotImplementedException(); }
        public override void Visit(UserDefinedTypePropertyAccess node) { throw new NotImplementedException(); }
        public override void Visit(CreateOrAlterTriggerStatement node) { throw new NotImplementedException(); }
        public override void Visit(TSqlStatementSnippet node) { throw new NotImplementedException(); }
        public override void Visit(IdentifierSnippet node) { throw new NotImplementedException(); }
        public override void Visit(MaxDispatchLatencySessionOption node) { throw new NotImplementedException(); }
        public override void Visit(FullTextPredicate node) { throw new NotImplementedException(); }
        public override void Visit(TSqlScript node) { throw new NotImplementedException(); }
        public override void Visit(LiteralSessionOption node) { throw new NotImplementedException(); }
        public override void Visit(TSqlBatch node) { throw new NotImplementedException(); }
        public override void Visit(InPredicate node) { throw new NotImplementedException(); }
        public override void Visit(OnOffSessionOption node) { throw new NotImplementedException(); }
        public override void Visit(TSqlStatement node) { throw new NotImplementedException(); }
        public override void Visit(DataModificationStatement node) { throw new NotImplementedException(); }
        public override void Visit(LikePredicate node) { throw new NotImplementedException(); }
        public override void Visit(MemoryPartitionSessionOption node) { throw new NotImplementedException(); }
        public override void Visit(DataModificationSpecification node) { throw new NotImplementedException(); }
        public override void Visit(MergeStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExistsPredicate node) { throw new NotImplementedException(); }
        public override void Visit(MergeSpecification node) { throw new NotImplementedException(); }
        public override void Visit(EventRetentionSessionOption node) { throw new NotImplementedException(); }
        public override void Visit(GraphMatchExpression node) { throw new NotImplementedException(); }
        public override void Visit(MergeActionClause node) { throw new NotImplementedException(); }
        public override void Visit(SubqueryComparisonPredicate node) { throw new NotImplementedException(); }
        public override void Visit(TriggerStatementBody node) { throw new NotImplementedException(); }
        public override void Visit(SchemaObjectNameSnippet node) { throw new NotImplementedException(); }
        public override void Visit(StatementWithCtesAndXmlNamespaces node) { throw new NotImplementedException(); }
        public override void Visit(SelectStatementSnippet node) { throw new NotImplementedException(); }
        public override void Visit(XmlForClauseOption node) { throw new NotImplementedException(); }
        public override void Visit(ScalarExpressionDialogOption node) { throw new NotImplementedException(); }
        public override void Visit(TriggerAction node) { throw new NotImplementedException(); }
        public override void Visit(OnOffDialogOption node) { throw new NotImplementedException(); }
        public override void Visit(XmlForClause node) { throw new NotImplementedException(); }
        public override void Visit(SpatialIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(BackupCertificateStatement node) { throw new NotImplementedException(); }
        public override void Visit(BackupRestoreMasterKeyStatementBase node) { throw new NotImplementedException(); }
        public override void Visit(CreateSpatialIndexStatement node) { throw new NotImplementedException(); }
        public override void Visit(ReadOnlyForClause node) { throw new NotImplementedException(); }
        public override void Visit(BackupServiceMasterKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterTriggerStatement node) { throw new NotImplementedException(); }
        public override void Visit(RestoreServiceMasterKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(BrowseForClause node) { throw new NotImplementedException(); }
        public override void Visit(BackupMasterKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterResourceGovernorStatement node) { throw new NotImplementedException(); }
        public override void Visit(RestoreMasterKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(ForClause node) { throw new NotImplementedException(); }
        public override void Visit(ScalarExpressionSnippet node) { throw new NotImplementedException(); }
        public override void Visit(DropEventSessionStatement node) { throw new NotImplementedException(); }
        public override void Visit(BooleanExpressionSnippet node) { throw new NotImplementedException(); }
        public override void Visit(CreateTriggerStatement node) { throw new NotImplementedException(); }
        public override void Visit(SelectStatement node) { throw new NotImplementedException(); }
        public override void Visit(StatementListSnippet node) { throw new NotImplementedException(); }
        public override void Visit(AlterEventSessionStatement node) { throw new NotImplementedException(); }
        public override void Visit(SpatialIndexRegularOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterWorkloadGroupStatement node) { throw new NotImplementedException(); }
        public override void Visit(PayloadOption node) { throw new NotImplementedException(); }
        public override void Visit(IdentifierAtomicBlockOption node) { throw new NotImplementedException(); }
        public override void Visit(BackwardsCompatibleDropIndexClause node) { throw new NotImplementedException(); }
        public override void Visit(ExternalTableLiteralOrIdentifierOption node) { throw new NotImplementedException(); }
        public override void Visit(DropIndexClause node) { throw new NotImplementedException(); }
        public override void Visit(MoveToDropIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(ExternalTableOption node) { throw new NotImplementedException(); }
        public override void Visit(FileStreamOnDropIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(DropStatisticsStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalTableStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropTableStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropProcedureStatement node) { throw new NotImplementedException(); }
        public override void Visit(EncryptedValueParameter node) { throw new NotImplementedException(); }
        public override void Visit(DropFunctionStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropViewStatement node) { throw new NotImplementedException(); }
        public override void Visit(ColumnEncryptionAlgorithmNameParameter node) { throw new NotImplementedException(); }
        public override void Visit(DropIndexClauseBase node) { throw new NotImplementedException(); }
        public override void Visit(DropDefaultStatement node) { throw new NotImplementedException(); }
        public override void Visit(ColumnMasterKeyNameParameter node) { throw new NotImplementedException(); }
        public override void Visit(DropTriggerStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropSchemaStatement node) { throw new NotImplementedException(); }
        public override void Visit(ColumnEncryptionKeyValueParameter node) { throw new NotImplementedException(); }
        public override void Visit(RaiseErrorLegacyStatement node) { throw new NotImplementedException(); }
        public override void Visit(RaiseErrorStatement node) { throw new NotImplementedException(); }
        public override void Visit(ColumnEncryptionKeyValue node) { throw new NotImplementedException(); }
        public override void Visit(ThrowStatement node) { throw new NotImplementedException(); }
        public override void Visit(UseStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropColumnEncryptionKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(KillStatement node) { throw new NotImplementedException(); }
        public override void Visit(KillQueryNotificationSubscriptionStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterColumnEncryptionKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(KillStatsJobStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropRuleStatement node) { throw new NotImplementedException(); }
        public override void Visit(CheckpointStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalTableDistributionOption node) { throw new NotImplementedException(); }
        public override void Visit(DropChildObjectsStatement node) { throw new NotImplementedException(); }
        public override void Visit(DeclareCursorStatement node) { throw new NotImplementedException(); }
        public override void Visit(CursorDefinition node) { throw new NotImplementedException(); }
        public override void Visit(ExternalDataSourceLiteralOrIdentifierOption node) { throw new NotImplementedException(); }
        public override void Visit(CursorOption node) { throw new NotImplementedException(); }
        public override void Visit(SetVariableStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalDataSourceOption node) { throw new NotImplementedException(); }
        public override void Visit(CursorId node) { throw new NotImplementedException(); }
        public override void Visit(CursorStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalDataSourceStatement node) { throw new NotImplementedException(); }
        public override void Visit(OpenCursorStatement node) { throw new NotImplementedException(); }
        public override void Visit(CloseCursorStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropExternalTableStatement node) { throw new NotImplementedException(); }
        public override void Visit(CryptoMechanism node) { throw new NotImplementedException(); }
        public override void Visit(OpenSymmetricKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropIndexStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateExternalTableStatement node) { throw new NotImplementedException(); }
        public override void Visit(OpenMasterKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalTableShardedDistributionPolicy node) { throw new NotImplementedException(); }
        public override void Visit(CloseMasterKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(DeallocateCursorStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalTableRoundRobinDistributionPolicy node) { throw new NotImplementedException(); }
        public override void Visit(FetchType node) { throw new NotImplementedException(); }
        public override void Visit(FetchCursorStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalTableReplicatedDistributionPolicy node) { throw new NotImplementedException(); }
        public override void Visit(WhereClause node) { throw new NotImplementedException(); }
        public override void Visit(DropUnownedObjectStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalTableDistributionPolicy node) { throw new NotImplementedException(); }
        public override void Visit(DropObjectsStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropDatabaseStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalTableRejectTypeOption node) { throw new NotImplementedException(); }
        public override void Visit(CloseSymmetricKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateExternalDataSourceStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateColumnEncryptionKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(ShutdownStatement node) { throw new NotImplementedException(); }
        public override void Visit(FileGrowthFileDeclarationOption node) { throw new NotImplementedException(); }
        public override void Visit(SecurityPolicyStatement node) { throw new NotImplementedException(); }
        public override void Visit(FileGroupDefinition node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropSequenceStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseScopedConfigurationStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseScopedConfigurationSetStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterSequenceStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseScopedConfigurationClearStatement node) { throw new NotImplementedException(); }
        public override void Visit(DatabaseConfigurationClearOption node) { throw new NotImplementedException(); }
        public override void Visit(CreateSequenceStatement node) { throw new NotImplementedException(); }
        public override void Visit(DatabaseConfigurationSetOption node) { throw new NotImplementedException(); }
        public override void Visit(OnOffPrimaryConfigurationOption node) { throw new NotImplementedException(); }
        public override void Visit(ScalarExpressionSequenceOption node) { throw new NotImplementedException(); }
        public override void Visit(MaxSizeFileDeclarationOption node) { throw new NotImplementedException(); }
        public override void Visit(MaxDopConfigurationOption node) { throw new NotImplementedException(); }
        public override void Visit(DataTypeSequenceOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseCollateStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseRebuildLogStatement node) { throw new NotImplementedException(); }
        public override void Visit(SequenceOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseAddFileStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseAddFileGroupStatement node) { throw new NotImplementedException(); }
        public override void Visit(SequenceStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseRemoveFileGroupStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseRemoveFileStatement node) { throw new NotImplementedException(); }
        public override void Visit(NextValueForExpression node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseModifyNameStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseModifyFileStatement node) { throw new NotImplementedException(); }
        public override void Visit(ColumnReferenceExpression node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseModifyFileGroupStatement node) { throw new NotImplementedException(); }
        public override void Visit(GenericConfigurationOption node) { throw new NotImplementedException(); }
        public override void Visit(ReconfigureStatement node) { throw new NotImplementedException(); }
        public override void Visit(CompressionDelayIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(SecurityPredicateAction node) { throw new NotImplementedException(); }
        public override void Visit(ColumnEncryptionKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(SetUserStatement node) { throw new NotImplementedException(); }
        public override void Visit(TruncateTableStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropColumnMasterKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(SetOnOffStatement node) { throw new NotImplementedException(); }
        public override void Visit(PredicateSetStatement node) { throw new NotImplementedException(); }
        public override void Visit(ColumnMasterKeyPathParameter node) { throw new NotImplementedException(); }
        public override void Visit(SetStatisticsStatement node) { throw new NotImplementedException(); }
        public override void Visit(SetRowCountStatement node) { throw new NotImplementedException(); }
        public override void Visit(ColumnMasterKeyStoreProviderNameParameter node) { throw new NotImplementedException(); }
        public override void Visit(SetOffsetsStatement node) { throw new NotImplementedException(); }
        public override void Visit(SetCommand node) { throw new NotImplementedException(); }
        public override void Visit(ColumnMasterKeyParameter node) { throw new NotImplementedException(); }
        public override void Visit(GeneralSetCommand node) { throw new NotImplementedException(); }
        public override void Visit(SizeFileDeclarationOption node) { throw new NotImplementedException(); }
        public override void Visit(SetFipsFlaggerCommand node) { throw new NotImplementedException(); }
        public override void Visit(SetCommandStatement node) { throw new NotImplementedException(); }
        public override void Visit(SetTransactionIsolationLevelStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropSecurityPolicyStatement node) { throw new NotImplementedException(); }
        public override void Visit(SetTextSizeStatement node) { throw new NotImplementedException(); }
        public override void Visit(SetIdentityInsertStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterSecurityPolicyStatement node) { throw new NotImplementedException(); }
        public override void Visit(SetErrorLevelStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateDatabaseStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateSecurityPolicyStatement node) { throw new NotImplementedException(); }
        public override void Visit(FileDeclaration node) { throw new NotImplementedException(); }
        public override void Visit(FileDeclarationOption node) { throw new NotImplementedException(); }
        public override void Visit(SecurityPolicyOption node) { throw new NotImplementedException(); }
        public override void Visit(NameFileDeclarationOption node) { throw new NotImplementedException(); }
        public override void Visit(FileNameFileDeclarationOption node) { throw new NotImplementedException(); }
        public override void Visit(CreateColumnMasterKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(ReturnStatement node) { throw new NotImplementedException(); }
        public override void Visit(UpdateStatisticsStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterExternalDataSourceStatement node) { throw new NotImplementedException(); }
        public override void Visit(DurabilityTableOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterRouteStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateRouteStatement node) { throw new NotImplementedException(); }
        public override void Visit(MemoryOptimizedTableOption node) { throw new NotImplementedException(); }
        public override void Visit(QueueStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterQueueStatement node) { throw new NotImplementedException(); }
        public override void Visit(FileTableConstraintNameTableOption node) { throw new NotImplementedException(); }
        public override void Visit(CreateQueueStatement node) { throw new NotImplementedException(); }
        public override void Visit(IndexDefinition node) { throw new NotImplementedException(); }
        public override void Visit(FileTableCollateFileNameTableOption node) { throw new NotImplementedException(); }
        public override void Visit(SystemTimePeriodDefinition node) { throw new NotImplementedException(); }
        public override void Visit(IndexStatement node) { throw new NotImplementedException(); }
        public override void Visit(FileTableDirectoryTableOption node) { throw new NotImplementedException(); }
        public override void Visit(IndexType node) { throw new NotImplementedException(); }
        public override void Visit(RouteStatement node) { throw new NotImplementedException(); }
        public override void Visit(PartitionSpecifier node) { throw new NotImplementedException(); }
        public override void Visit(AlterIndexStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateXmlIndexStatement node) { throw new NotImplementedException(); }
        public override void Visit(LockEscalationTableOption node) { throw new NotImplementedException(); }
        public override void Visit(CreateSelectiveXmlIndexStatement node) { throw new NotImplementedException(); }
        public override void Visit(FileGroupOrPartitionScheme node) { throw new NotImplementedException(); }
        public override void Visit(TableOption node) { throw new NotImplementedException(); }
        public override void Visit(CreateIndexStatement node) { throw new NotImplementedException(); }
        public override void Visit(IndexOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterTableSetStatement node) { throw new NotImplementedException(); }
        public override void Visit(IndexStateOption node) { throw new NotImplementedException(); }
        public override void Visit(IndexExpressionOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterTableFileTableNamespaceStatement node) { throw new NotImplementedException(); }
        public override void Visit(MaxDurationOption node) { throw new NotImplementedException(); }
        public override void Visit(WaitAtLowPriorityOption node) { throw new NotImplementedException(); }
        public override void Visit(FileStreamOnTableOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterTableChangeTrackingModificationStatement node) { throw new NotImplementedException(); }
        public override void Visit(RouteOption node) { throw new NotImplementedException(); }
        public override void Visit(QueueExecuteAsOption node) { throw new NotImplementedException(); }
        public override void Visit(LowPriorityLockWaitTableSwitchOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterTableConstraintModificationStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropClusteredConstraintOption node) { throw new NotImplementedException(); }
        public override void Visit(DropClusteredConstraintStateOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterTableAddTableElementStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropClusteredConstraintValueOption node) { throw new NotImplementedException(); }
        public override void Visit(DropClusteredConstraintMoveOption node) { throw new NotImplementedException(); }
        public override void Visit(SystemVersioningTableOption node) { throw new NotImplementedException(); }
        public override void Visit(DropClusteredConstraintWaitAtLowPriorityLockOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterTableDropTableElement node) { throw new NotImplementedException(); }
        public override void Visit(RetentionPeriodDefinition node) { throw new NotImplementedException(); }
        public override void Visit(AlterTableDropTableElementStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterTableTriggerModificationStatement node) { throw new NotImplementedException(); }
        public override void Visit(RemoteDataArchiveDbFederatedServiceAccountSetting node) { throw new NotImplementedException(); }
        public override void Visit(RemoteDataArchiveTableOption node) { throw new NotImplementedException(); }
        public override void Visit(EnableDisableTriggerStatement node) { throw new NotImplementedException(); }
        public override void Visit(RemoteDataArchiveDbCredentialSetting node) { throw new NotImplementedException(); }
        public override void Visit(CreateTypeStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateTypeUdtStatement node) { throw new NotImplementedException(); }
        public override void Visit(RemoteDataArchiveDbServerSetting node) { throw new NotImplementedException(); }
        public override void Visit(CreateTypeUddtStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateSynonymStatement node) { throw new NotImplementedException(); }
        public override void Visit(RemoteDataArchiveDatabaseSetting node) { throw new NotImplementedException(); }
        public override void Visit(ExecuteAsClause node) { throw new NotImplementedException(); }
        public override void Visit(QueueOption node) { throw new NotImplementedException(); }
        public override void Visit(RemoteDataArchiveDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(QueueStateOption node) { throw new NotImplementedException(); }
        public override void Visit(QueueProcedureOption node) { throw new NotImplementedException(); }
        public override void Visit(RemoteDataArchiveAlterTableOption node) { throw new NotImplementedException(); }
        public override void Visit(QueueValueOption node) { throw new NotImplementedException(); }
        public override void Visit(TryCatchStatement node) { throw new NotImplementedException(); }
        public override void Visit(OnlineIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(IgnoreDupKeyIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterTableRebuildStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateAssemblyStatement node) { throw new NotImplementedException(); }
        public override void Visit(RoleStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateRoleStatement node) { throw new NotImplementedException(); }
        public override void Visit(AssemblyStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterRoleStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterRoleAction node) { throw new NotImplementedException(); }
        public override void Visit(DropExternalFileFormatStatement node) { throw new NotImplementedException(); }
        public override void Visit(RenameAlterRoleAction node) { throw new NotImplementedException(); }
        public override void Visit(AddMemberAlterRoleAction node) { throw new NotImplementedException(); }
        public override void Visit(CreateExternalFileFormatStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropMemberAlterRoleAction node) { throw new NotImplementedException(); }
        public override void Visit(CreateServerRoleStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalFileFormatContainerOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterServerRoleStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterApplicationRoleStatement node) { throw new NotImplementedException(); }
        public override void Visit(DropServerRoleStatement node) { throw new NotImplementedException(); }
        public override void Visit(UserLoginOption node) { throw new NotImplementedException(); }
        public override void Visit(UserStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalFileFormatLiteralOption node) { throw new NotImplementedException(); }
        public override void Visit(CreateUserStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterUserStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalFileFormatOption node) { throw new NotImplementedException(); }
        public override void Visit(StatisticsOption node) { throw new NotImplementedException(); }
        public override void Visit(ResampleStatisticsOption node) { throw new NotImplementedException(); }
        public override void Visit(ExternalFileFormatStatement node) { throw new NotImplementedException(); }
        public override void Visit(StatisticsPartitionRange node) { throw new NotImplementedException(); }
        public override void Visit(OnOffStatisticsOption node) { throw new NotImplementedException(); }
        public override void Visit(DropExternalDataSourceStatement node) { throw new NotImplementedException(); }
        public override void Visit(LiteralStatisticsOption node) { throw new NotImplementedException(); }
        public override void Visit(CreateStatisticsStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalFileFormatUseDefaultTypeOption node) { throw new NotImplementedException(); }
        public override void Visit(CreateApplicationRoleStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterAssemblyStatement node) { throw new NotImplementedException(); }
        public override void Visit(ApplicationRoleStatement node) { throw new NotImplementedException(); }
        public override void Visit(OrderIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(OnlineIndexLowPriorityLockWaitOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterTableAlterPartitionStatement node) { throw new NotImplementedException(); }
        public override void Visit(LowPriorityLockWaitOption node) { throw new NotImplementedException(); }
        public override void Visit(LowPriorityLockWaitMaxDurationOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterTableStatement node) { throw new NotImplementedException(); }
        public override void Visit(LowPriorityLockWaitAbortAfterWaitOption node) { throw new NotImplementedException(); }
        public override void Visit(FullTextIndexColumn node) { throw new NotImplementedException(); }
        public override void Visit(AssemblyName node) { throw new NotImplementedException(); }
        public override void Visit(CreateFullTextIndexStatement node) { throw new NotImplementedException(); }
        public override void Visit(FullTextIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(DropXmlSchemaCollectionStatement node) { throw new NotImplementedException(); }
        public override void Visit(ChangeTrackingFullTextIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(StopListFullTextIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterXmlSchemaCollectionStatement node) { throw new NotImplementedException(); }
        public override void Visit(SearchPropertyListFullTextIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(FullTextCatalogAndFileGroup node) { throw new NotImplementedException(); }
        public override void Visit(ApplicationRoleOption node) { throw new NotImplementedException(); }
        public override void Visit(AssemblyOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterMasterKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateMasterKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(OnOffAssemblyOption node) { throw new NotImplementedException(); }
        public override void Visit(MasterKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseTermination node) { throw new NotImplementedException(); }
        public override void Visit(EventNotificationObjectScope node) { throw new NotImplementedException(); }
        public override void Visit(CreateEventNotificationStatement node) { throw new NotImplementedException(); }
        public override void Visit(EventGroupContainer node) { throw new NotImplementedException(); }
        public override void Visit(AddFileSpec node) { throw new NotImplementedException(); }
        public override void Visit(EventTypeContainer node) { throw new NotImplementedException(); }
        public override void Visit(EventTypeGroupContainer node) { throw new NotImplementedException(); }
        public override void Visit(CreateXmlSchemaCollectionStatement node) { throw new NotImplementedException(); }
        public override void Visit(PermissionSetAssemblyOption node) { throw new NotImplementedException(); }
        public override void Visit(ParenthesisExpression node) { throw new NotImplementedException(); }
        public override void Visit(AlterDatabaseSetStatement node) { throw new NotImplementedException(); }
        public override void Visit(DatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(ReadTextStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateContractStatement node) { throw new NotImplementedException(); }
        public override void Visit(ContractMessage node) { throw new NotImplementedException(); }
        public override void Visit(WaitForStatement node) { throw new NotImplementedException(); }
        public override void Visit(CredentialStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateCredentialStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateSchemaStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterCredentialStatement node) { throw new NotImplementedException(); }
        public override void Visit(MessageTypeStatementBase node) { throw new NotImplementedException(); }
        public override void Visit(UpdateSpecification node) { throw new NotImplementedException(); }
        public override void Visit(CreateMessageTypeStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterMessageTypeStatement node) { throw new NotImplementedException(); }
        public override void Visit(UpdateStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateAggregateStatement node) { throw new NotImplementedException(); }
        public override void Visit(CertificateOption node) { throw new NotImplementedException(); }
        public override void Visit(CreateEndpointStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterEndpointStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterCreateEndpointStatementBase node) { throw new NotImplementedException(); }
        public override void Visit(InsertStatement node) { throw new NotImplementedException(); }
        public override void Visit(EndpointAffinity node) { throw new NotImplementedException(); }
        public override void Visit(EndpointProtocolOption node) { throw new NotImplementedException(); }
        public override void Visit(DeleteSpecification node) { throw new NotImplementedException(); }
        public override void Visit(LiteralEndpointProtocolOption node) { throw new NotImplementedException(); }
        public override void Visit(AuthenticationEndpointProtocolOption node) { throw new NotImplementedException(); }
        public override void Visit(UpdateDeleteSpecificationBase node) { throw new NotImplementedException(); }
        public override void Visit(PortsEndpointProtocolOption node) { throw new NotImplementedException(); }
        public override void Visit(CompressionEndpointProtocolOption node) { throw new NotImplementedException(); }
        public override void Visit(DeleteStatement node) { throw new NotImplementedException(); }
        public override void Visit(ListenerIPEndpointProtocolOption node) { throw new NotImplementedException(); }
        public override void Visit(IPv4 node) { throw new NotImplementedException(); }
        public override void Visit(InsertSpecification node) { throw new NotImplementedException(); }
        public override void Visit(WhileStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateCertificateStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterCertificateStatement node) { throw new NotImplementedException(); }
        public override void Visit(ExternalTableColumnDefinition node) { throw new NotImplementedException(); }
        public override void Visit(SecurityTargetObject node) { throw new NotImplementedException(); }
        public override void Visit(InsertBulkColumnDefinition node) { throw new NotImplementedException(); }
        public override void Visit(DbccStatement node) { throw new NotImplementedException(); }
        public override void Visit(Permission node) { throw new NotImplementedException(); }
        public override void Visit(DbccOption node) { throw new NotImplementedException(); }
        public override void Visit(DbccNamedLiteral node) { throw new NotImplementedException(); }
        public override void Visit(AlterAuthorizationStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateAsymmetricKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreatePartitionFunctionStatement node) { throw new NotImplementedException(); }
        public override void Visit(RevokeStatement node) { throw new NotImplementedException(); }
        public override void Visit(PartitionParameterType node) { throw new NotImplementedException(); }
        public override void Visit(CreatePartitionSchemeStatement node) { throw new NotImplementedException(); }
        public override void Visit(DenyStatement node) { throw new NotImplementedException(); }
        public override void Visit(UpdateTextStatement node) { throw new NotImplementedException(); }
        public override void Visit(RemoteServiceBindingStatementBase node) { throw new NotImplementedException(); }
        public override void Visit(GrantStatement node) { throw new NotImplementedException(); }
        public override void Visit(OnOffRemoteServiceBindingOption node) { throw new NotImplementedException(); }
        public override void Visit(UserRemoteServiceBindingOption node) { throw new NotImplementedException(); }
        public override void Visit(SecurityStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateRemoteServiceBindingStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterRemoteServiceBindingStatement node) { throw new NotImplementedException(); }
        public override void Visit(LineNoStatement node) { throw new NotImplementedException(); }
        public override void Visit(EncryptionSource node) { throw new NotImplementedException(); }
        public override void Visit(AssemblyEncryptionSource node) { throw new NotImplementedException(); }
        public override void Visit(TextModificationStatement node) { throw new NotImplementedException(); }
        public override void Visit(FileEncryptionSource node) { throw new NotImplementedException(); }
        public override void Visit(ProviderEncryptionSource node) { throw new NotImplementedException(); }
        public override void Visit(WriteTextStatement node) { throw new NotImplementedException(); }
        public override void Visit(CertificateStatementBase node) { throw new NotImplementedException(); }
        public override void Visit(RemoteServiceBindingOption node) { throw new NotImplementedException(); }
        public override void Visit(SoapMethod node) { throw new NotImplementedException(); }
        public override void Visit(AlterTableSwitchStatement node) { throw new NotImplementedException(); }
        public override void Visit(TransactionStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateFunctionStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterCreateServiceStatementBase node) { throw new NotImplementedException(); }
        public override void Visit(CreateServiceStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateDefaultStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterServiceStatement node) { throw new NotImplementedException(); }
        public override void Visit(ServiceContract node) { throw new NotImplementedException(); }
        public override void Visit(ContinueStatement node) { throw new NotImplementedException(); }
        public override void Visit(BinaryExpression node) { throw new NotImplementedException(); }
        public override void Visit(BuiltInFunctionTableReference node) { throw new NotImplementedException(); }
        public override void Visit(SaveTransactionStatement node) { throw new NotImplementedException(); }
        public override void Visit(GlobalFunctionTableReference node) { throw new NotImplementedException(); }
        public override void Visit(ComputeClause node) { throw new NotImplementedException(); }
        public override void Visit(RollbackTransactionStatement node) { throw new NotImplementedException(); }
        public override void Visit(ComputeFunction node) { throw new NotImplementedException(); }
        public override void Visit(AlterFullTextCatalogStatement node) { throw new NotImplementedException(); }
        public override void Visit(PivotedTableReference node) { throw new NotImplementedException(); }
        public override void Visit(UnpivotedTableReference node) { throw new NotImplementedException(); }
        public override void Visit(UnqualifiedJoin node) { throw new NotImplementedException(); }
        public override void Visit(ColumnWithSortOrder node) { throw new NotImplementedException(); }
        public override void Visit(TableSampleClause node) { throw new NotImplementedException(); }
        public override void Visit(ScalarExpression node) { throw new NotImplementedException(); }
        public override void Visit(BreakStatement node) { throw new NotImplementedException(); }
        public override void Visit(BooleanExpression node) { throw new NotImplementedException(); }
        public override void Visit(BooleanNotExpression node) { throw new NotImplementedException(); }
        public override void Visit(BeginTransactionStatement node) { throw new NotImplementedException(); }
        public override void Visit(BooleanParenthesisExpression node) { throw new NotImplementedException(); }
        public override void Visit(BooleanComparisonExpression node) { throw new NotImplementedException(); }
        public override void Visit(OnOffAtomicBlockOption node) { throw new NotImplementedException(); }
        public override void Visit(BooleanBinaryExpression node) { throw new NotImplementedException(); }
        public override void Visit(BooleanIsNullExpression node) { throw new NotImplementedException(); }
        public override void Visit(CommitTransactionStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateFullTextCatalogStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateOrAlterFunctionStatement node) { throw new NotImplementedException(); }
        public override void Visit(OnOffFullTextCatalogOption node) { throw new NotImplementedException(); }
        public override void Visit(EnabledDisabledPayloadOption node) { throw new NotImplementedException(); }
        public override void Visit(WsdlPayloadOption node) { throw new NotImplementedException(); }
        public override void Visit(ProcedureParameter node) { throw new NotImplementedException(); }
        public override void Visit(LoginTypePayloadOption node) { throw new NotImplementedException(); }
        public override void Visit(LiteralPayloadOption node) { throw new NotImplementedException(); }
        public override void Visit(ChildObjectName node) { throw new NotImplementedException(); }
        public override void Visit(SessionTimeoutPayloadOption node) { throw new NotImplementedException(); }
        public override void Visit(SchemaPayloadOption node) { throw new NotImplementedException(); }
        public override void Visit(SchemaObjectName node) { throw new NotImplementedException(); }
        public override void Visit(CharacterSetPayloadOption node) { throw new NotImplementedException(); }
        public override void Visit(RolePayloadOption node) { throw new NotImplementedException(); }
        public override void Visit(MultiPartIdentifier node) { throw new NotImplementedException(); }
        public override void Visit(AuthenticationPayloadOption node) { throw new NotImplementedException(); }
        public override void Visit(EncryptionPayloadOption node) { throw new NotImplementedException(); }
        public override void Visit(LabelStatement node) { throw new NotImplementedException(); }
        public override void Visit(SymmetricKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(CreateSymmetricKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(FullTextCatalogOption node) { throw new NotImplementedException(); }
        public override void Visit(CreateRuleStatement node) { throw new NotImplementedException(); }
        public override void Visit(FullTextCatalogStatement node) { throw new NotImplementedException(); }
        public override void Visit(AlterSymmetricKeyStatement node) { throw new NotImplementedException(); }
        public override void Visit(DeclareVariableElement node) { throw new NotImplementedException(); }
        public override void Visit(CreationDispositionKeyOption node) { throw new NotImplementedException(); }
        public override void Visit(ColumnDefinitionBase node) { throw new NotImplementedException(); }
        public override void Visit(ProviderKeyNameKeyOption node) { throw new NotImplementedException(); }
        public override void Visit(IdentityValueKeyOption node) { throw new NotImplementedException(); }
        public override void Visit(AlgorithmKeyOption node) { throw new NotImplementedException(); }
        public override void Visit(GoToStatement node) { throw new NotImplementedException(); }
        public override void Visit(KeySourceKeyOption node) { throw new NotImplementedException(); }
        public override void Visit(KeyOption node) { throw new NotImplementedException(); }
        public override void Visit(IfStatement node) { throw new NotImplementedException(); }
        public override void Visit(DeclareVariableStatement node) { throw new NotImplementedException(); }
        public override void Visit(GraphMatchPredicate node) { throw new NotImplementedException(); }
        public override void Visit(SecurityTargetObjectName node) { throw new NotImplementedException(); }
        public override void Visit(LiteralBulkInsertOption node) { throw new NotImplementedException(); }
        public override void Visit(QueryStoreCapturePolicyOption node) { throw new NotImplementedException(); }
        public override void Visit(QueryStoreSizeCleanupPolicyOption node) { throw new NotImplementedException(); }
        public override void Visit(DefaultLiteral node) { throw new NotImplementedException(); }
        public override void Visit(QueryStoreDataFlushIntervalOption node) { throw new NotImplementedException(); }
        public override void Visit(QueryStoreIntervalLengthOption node) { throw new NotImplementedException(); }
        public override void Visit(IdentifierLiteral node) { throw new NotImplementedException(); }
        public override void Visit(QueryStoreMaxStorageSizeOption node) { throw new NotImplementedException(); }
        public override void Visit(QueryStoreMaxPlansPerQueryOption node) { throw new NotImplementedException(); }
        public override void Visit(NullLiteral node) { throw new NotImplementedException(); }
        public override void Visit(QueryStoreTimeCleanupPolicyOption node) { throw new NotImplementedException(); }
        public override void Visit(AutomaticTuningDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(StringLiteral node) { throw new NotImplementedException(); }
        public override void Visit(AutomaticTuningOption node) { throw new NotImplementedException(); }
        public override void Visit(AutomaticTuningForceLastGoodPlanOption node) { throw new NotImplementedException(); }
        public override void Visit(MaxLiteral node) { throw new NotImplementedException(); }
        public override void Visit(BinaryLiteral node) { throw new NotImplementedException(); }
        public override void Visit(AutomaticTuningDropIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(MoneyLiteral node) { throw new NotImplementedException(); }
        public override void Visit(AutomaticTuningMaintainIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(FileStreamDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(RealLiteral node) { throw new NotImplementedException(); }
        public override void Visit(MaxSizeDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(AlterTableAlterIndexStatement node) { throw new NotImplementedException(); }
        public override void Visit(NumericLiteral node) { throw new NotImplementedException(); }
        public override void Visit(AlterTableAlterColumnStatement node) { throw new NotImplementedException(); }
        public override void Visit(ColumnDefinition node) { throw new NotImplementedException(); }
        public override void Visit(IntegerLiteral node) { throw new NotImplementedException(); }
        public override void Visit(ColumnEncryptionDefinition node) { throw new NotImplementedException(); }
        public override void Visit(ColumnEncryptionDefinitionParameter node) { throw new NotImplementedException(); }
        public override void Visit(Literal node) { throw new NotImplementedException(); }
        public override void Visit(AutomaticTuningCreateIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(ColumnEncryptionKeyNameParameter node) { throw new NotImplementedException(); }
        public override void Visit(QueryStoreDesiredStateOption node) { throw new NotImplementedException(); }
        public override void Visit(OdbcLiteral node) { throw new NotImplementedException(); }
        public override void Visit(SchemaObjectNameOrValueExpression node) { throw new NotImplementedException(); }
        public override void Visit(OnOffDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(AutoCreateStatisticsDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(IdentifierOrScalarExpression node) { throw new NotImplementedException(); }
        public override void Visit(ContainmentDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(HadrDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(IdentifierOrValueExpression node) { throw new NotImplementedException(); }
        public override void Visit(HadrAvailabilityGroupDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(DelayedDurabilityDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(GlobalVariableExpression node) { throw new NotImplementedException(); }
        public override void Visit(CursorDefaultDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(RecoveryDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(LiteralOptionValue node) { throw new NotImplementedException(); }
        public override void Visit(TargetRecoveryTimeDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(QueryStoreOption node) { throw new NotImplementedException(); }
        public override void Visit(PageVerifyDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(PartnerDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(WitnessDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(OptionValue node) { throw new NotImplementedException(); }
        public override void Visit(ParameterizationDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(LiteralDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(VariableReference node) { throw new NotImplementedException(); }
        public override void Visit(IdentifierDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(ChangeTrackingDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(ValueExpression node) { throw new NotImplementedException(); }
        public override void Visit(ChangeTrackingOptionDetail node) { throw new NotImplementedException(); }
        public override void Visit(AutoCleanupChangeTrackingOptionDetail node) { throw new NotImplementedException(); }
        public override void Visit(LiteralRange node) { throw new NotImplementedException(); }
        public override void Visit(ChangeRetentionChangeTrackingOptionDetail node) { throw new NotImplementedException(); }
        public override void Visit(QueryStoreDatabaseOption node) { throw new NotImplementedException(); }
        public override void Visit(OnOffOptionValue node) { throw new NotImplementedException(); }
        public override void Visit(ColumnEncryptionTypeParameter node) { throw new NotImplementedException(); }
        public override void Visit(PrimaryExpression node) { throw new NotImplementedException(); }
        public override void Visit(ColumnEncryptionAlgorithmParameter node) { throw new NotImplementedException(); }
        public override void Visit(NullableConstraintDefinition node) { throw new NotImplementedException(); }
        public override void Visit(UniqueConstraintDefinition node) { throw new NotImplementedException(); }
        public override void Visit(SecurityUserClause80 node) { throw new NotImplementedException(); }
        public override void Visit(BackupStatement node) { throw new NotImplementedException(); }
        public override void Visit(BackupDatabaseStatement node) { throw new NotImplementedException(); }
        public override void Visit(Privilege80 node) { throw new NotImplementedException(); }
        public override void Visit(BackupTransactionLogStatement node) { throw new NotImplementedException(); }
        public override void Visit(RestoreStatement node) { throw new NotImplementedException(); }
        public override void Visit(PrivilegeSecurityElement80 node) { throw new NotImplementedException(); }
        public override void Visit(RestoreOption node) { throw new NotImplementedException(); }
        public override void Visit(ScalarExpressionRestoreOption node) { throw new NotImplementedException(); }
        public override void Visit(CommandSecurityElement80 node) { throw new NotImplementedException(); }
        public override void Visit(MoveRestoreOption node) { throw new NotImplementedException(); }
        public override void Visit(StopRestoreOption node) { throw new NotImplementedException(); }
        public override void Visit(SqlCommandIdentifier node) { throw new NotImplementedException(); }
        public override void Visit(SecurityElement80 node) { throw new NotImplementedException(); }
        public override void Visit(BackupOption node) { throw new NotImplementedException(); }
        public override void Visit(RevokeStatement80 node) { throw new NotImplementedException(); }
        public override void Visit(BackupEncryptionOption node) { throw new NotImplementedException(); }
        public override void Visit(DeviceInfo node) { throw new NotImplementedException(); }
        public override void Visit(DenyStatement80 node) { throw new NotImplementedException(); }
        public override void Visit(MirrorToClause node) { throw new NotImplementedException(); }
        public override void Visit(BackupRestoreFileInfo node) { throw new NotImplementedException(); }
        public override void Visit(GrantStatement80 node) { throw new NotImplementedException(); }
        public override void Visit(BulkInsertBase node) { throw new NotImplementedException(); }
        public override void Visit(BulkInsertStatement node) { throw new NotImplementedException(); }
        public override void Visit(SecurityStatementBody80 node) { throw new NotImplementedException(); }
        public override void Visit(InsertBulkStatement node) { throw new NotImplementedException(); }
        public override void Visit(BulkInsertOption node) { throw new NotImplementedException(); }
        public override void Visit(SecurityPrincipal node) { throw new NotImplementedException(); }
        public override void Visit(FileStreamRestoreOption node) { throw new NotImplementedException(); }
        public override void Visit(ForeignKeyConstraintDefinition node) { throw new NotImplementedException(); }
        public override void Visit(DefaultConstraintDefinition node) { throw new NotImplementedException(); }
        public override void Visit(SetClause node) { throw new NotImplementedException(); }
        public override void Visit(IdentityOptions node) { throw new NotImplementedException(); }
        public override void Visit(TSEqualCall node) { throw new NotImplementedException(); }
        public override void Visit(ColumnStorageOptions node) { throw new NotImplementedException(); }
        public override void Visit(ConstraintDefinition node) { throw new NotImplementedException(); }
        public override void Visit(UpdateCall node) { throw new NotImplementedException(); }
        public override void Visit(CreateTableStatement node) { throw new NotImplementedException(); }
        public override void Visit(FederationScheme node) { throw new NotImplementedException(); }
        public override void Visit(PrintStatement node) { throw new NotImplementedException(); }
        public override void Visit(TableDataCompressionOption node) { throw new NotImplementedException(); }
        public override void Visit(TableDistributionOption node) { throw new NotImplementedException(); }
        public override void Visit(RowValue node) { throw new NotImplementedException(); }
        public override void Visit(TableDistributionPolicy node) { throw new NotImplementedException(); }
        public override void Visit(TableReplicateDistributionPolicy node) { throw new NotImplementedException(); }
        public override void Visit(ExecuteInsertSource node) { throw new NotImplementedException(); }
        public override void Visit(TableRoundRobinDistributionPolicy node) { throw new NotImplementedException(); }
        public override void Visit(TableHashDistributionPolicy node) { throw new NotImplementedException(); }
        public override void Visit(SelectInsertSource node) { throw new NotImplementedException(); }
        public override void Visit(CheckConstraintDefinition node) { throw new NotImplementedException(); }
        public override void Visit(CompressionPartitionRange node) { throw new NotImplementedException(); }
        public override void Visit(AssignmentSetClause node) { throw new NotImplementedException(); }
        public override void Visit(DataCompressionOption node) { throw new NotImplementedException(); }
        public override void Visit(TablePartitionOptionSpecifications node) { throw new NotImplementedException(); }
        public override void Visit(FunctionCallSetClause node) { throw new NotImplementedException(); }
        public override void Visit(OrderBulkInsertOption node) { throw new NotImplementedException(); }
        public override void Visit(PartitionSpecifications node) { throw new NotImplementedException(); }
        public override void Visit(InsertSource node) { throw new NotImplementedException(); }
        public override void Visit(TableNonClusteredIndexType node) { throw new NotImplementedException(); }
        public override void Visit(TableClusteredIndexType node) { throw new NotImplementedException(); }
        public override void Visit(ValuesInsertSource node) { throw new NotImplementedException(); }
        public override void Visit(TableIndexType node) { throw new NotImplementedException(); }
        public override void Visit(TableIndexOption node) { throw new NotImplementedException(); }
        public override void Visit(TablePartitionOption node) { throw new NotImplementedException(); }
        public override void Visit(TableSwitchOption node) { throw new NotImplementedException(); }
    }
}
