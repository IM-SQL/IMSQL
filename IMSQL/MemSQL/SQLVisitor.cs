using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemSQL
{
    public abstract class SQLVisitor
    {
        private SQLInternalVisitor inner;

        public SQLVisitor()
        {
            inner = new SQLInternalVisitor(this);
        }

        public T Visit<T>(TSqlFragment node, T defaultValue = default(T))
        {
            if (node == null) { return defaultValue; }
            node.Accept(inner);
            return (T)inner.Result;
        }

        public IEnumerable<T> VisitCollection<T>(IEnumerable<TSqlFragment> nodes, T defaultValue = default(T))
        {
            return nodes.Select(n => Visit(n, defaultValue)).ToArray();
        }

        protected virtual object InternalVisit(SchemaObjectName node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(SqlDataTypeReference node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(IntegerLiteral node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(StringLiteral node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(NullLiteral node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(CreateTableStatement node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(TableDefinition node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(ColumnDefinition node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(IdentityOptions node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(DefaultConstraintDefinition node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(NullableConstraintDefinition node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(UniqueConstraintDefinition node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(ForeignKeyConstraintDefinition node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(InsertStatement node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(CreateIndexStatement node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(InsertSpecification node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(ValuesInsertSource node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(RowValue node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(NamedTableReference node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(ColumnReferenceExpression node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(DeleteStatement node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(DeleteSpecification node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(TopRowFilter node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(ParenthesisExpression node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(WhereClause node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(BooleanComparisonExpression node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(BooleanBinaryExpression node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(BooleanNotExpression node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(MultiPartIdentifier node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(UpdateStatement node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(UpdateSpecification node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(AssignmentSetClause node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(SelectStatement node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(QuerySpecification node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(FromClause node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(TSqlScript node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(TSqlBatch node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(SearchedCaseExpression node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(BinaryExpression node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(SelectStarExpression node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(SelectScalarExpression node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(OutputClause node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(QualifiedJoin node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(QueryDerivedTable node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(UnqualifiedJoin node) { throw new NotImplementedException(); }
        protected virtual object InternalVisit(SelectInsertSource node) { throw new NotImplementedException(); }



        class SQLInternalVisitor : TSqlFragmentVisitor
        {
            private SQLVisitor outer;

            public SQLInternalVisitor(SQLVisitor visitor)
            {
                outer = visitor;
            }

            public object Result { get; set; }

            public override void ExplicitVisit(SchemaObjectName node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(SqlDataTypeReference node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(IntegerLiteral node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(NullLiteral node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(StringLiteral node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(CreateTableStatement node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(TableDefinition node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(ColumnDefinition node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(IdentityOptions node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(DefaultConstraintDefinition node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(NullableConstraintDefinition node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(UniqueConstraintDefinition node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(ForeignKeyConstraintDefinition node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(InsertStatement node)
            {
                Result = outer.InternalVisit(node);
            }
            public override void ExplicitVisit(DeleteStatement node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(CreateIndexStatement node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(InsertSpecification node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(ValuesInsertSource node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(RowValue node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(NamedTableReference node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(ColumnReferenceExpression node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(DeleteSpecification node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(TopRowFilter node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(WhereClause node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(ParenthesisExpression node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(BooleanComparisonExpression node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(BooleanBinaryExpression node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(BooleanNotExpression node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(MultiPartIdentifier node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(UpdateStatement node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(UpdateSpecification node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(AssignmentSetClause node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(SelectStatement node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(QuerySpecification node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(FromClause node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(TSqlScript node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(TSqlBatch node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(SearchedCaseExpression node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(BinaryExpression node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(SelectStarExpression node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(SelectScalarExpression node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(OutputClause node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(QualifiedJoin node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(QueryDerivedTable node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(UnqualifiedJoin node)
            {
                Result = outer.InternalVisit(node);
            }
            public override void ExplicitVisit(SelectInsertSource node)
            {
                Result = outer.InternalVisit(node);
            }

            public override void ExplicitVisit(QueryExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AutomaticTuningDropIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AutomaticTuningCreateIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AutomaticTuningForceLastGoodPlanOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AutomaticTuningOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AutomaticTuningDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueryStoreTimeCleanupPolicyOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueryStoreMaxPlansPerQueryOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueryStoreMaxStorageSizeOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueryStoreIntervalLengthOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueryStoreDataFlushIntervalOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueryStoreSizeCleanupPolicyOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueryStoreCapturePolicyOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueryStoreDesiredStateOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueryStoreOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueryStoreDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AutomaticTuningMaintainIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FileStreamDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MaxSizeDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterTableAlterIndexStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableReplicateDistributionPolicy node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableDistributionPolicy node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableDistributionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableDataCompressionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FederationScheme node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(ConstraintDefinition node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ChangeRetentionChangeTrackingOptionDetail node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnStorageOptions node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnEncryptionAlgorithmParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnEncryptionTypeParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnEncryptionKeyNameParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnEncryptionDefinitionParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnEncryptionDefinition node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(AlterTableAlterColumnStatement node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(AutoCleanupChangeTrackingOptionDetail node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ChangeTrackingOptionDetail node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ChangeTrackingDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseModifyNameStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseRemoveFileStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseRemoveFileGroupStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseAddFileGroupStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseAddFileStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseRebuildLogStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseCollateStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseModifyFileStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GenericConfigurationOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OnOffPrimaryConfigurationOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DatabaseConfigurationSetOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DatabaseConfigurationClearOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseScopedConfigurationClearStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseScopedConfigurationSetStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseScopedConfigurationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MaxDopConfigurationOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableRoundRobinDistributionPolicy node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseModifyFileGroupStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseSetStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IdentifierDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LiteralDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ParameterizationDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WitnessDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PartnerDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PageVerifyDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TargetRecoveryTimeDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseTermination node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RecoveryDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DelayedDurabilityDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(HadrAvailabilityGroupDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(HadrDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ContainmentDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AutoCreateStatisticsDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OnOffDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CursorDefaultDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableHashDistributionPolicy node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableIndexType node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CertificateOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateCertificateStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterCertificateStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CertificateStatementBase node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ProviderEncryptionSource node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FileEncryptionSource node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AssemblyEncryptionSource node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateContractStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EncryptionSource node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateRemoteServiceBindingStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UserRemoteServiceBindingOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OnOffRemoteServiceBindingOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RemoteServiceBindingOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RemoteServiceBindingStatementBase node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreatePartitionSchemeStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PartitionParameterType node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterRemoteServiceBindingStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreatePartitionFunctionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ContractMessage node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateCredentialStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IPv4 node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ListenerIPEndpointProtocolOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CompressionEndpointProtocolOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PortsEndpointProtocolOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AuthenticationEndpointProtocolOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LiteralEndpointProtocolOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EndpointProtocolOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CredentialStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EndpointAffinity node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterEndpointStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateEndpointStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateAggregateStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterMessageTypeStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateMessageTypeStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MessageTypeStatementBase node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterCredentialStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterCreateEndpointStatementBase node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FileGroupDefinition node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateAsymmetricKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DbccOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RestoreStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BackupTransactionLogStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BackupDatabaseStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BackupStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RestoreOption node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(CompressionPartitionRange node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DataCompressionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TablePartitionOptionSpecifications node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PartitionSpecifications node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TablePartitionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableNonClusteredIndexType node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableClusteredIndexType node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CheckConstraintDefinition node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DbccNamedLiteral node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ScalarExpressionRestoreOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(StopRestoreOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DbccStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(InsertBulkColumnDefinition node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalTableColumnDefinition node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnDefinitionBase node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OrderBulkInsertOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LiteralBulkInsertOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BulkInsertOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MoveRestoreOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(InsertBulkStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BulkInsertBase node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BackupRestoreFileInfo node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MirrorToClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DeviceInfo node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BackupEncryptionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BackupOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FileStreamRestoreOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BulkInsertStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FileGrowthFileDeclarationOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MaxSizeFileDeclarationOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FileNameFileDeclarationOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SearchPropertyListFullTextIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(StopListFullTextIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ChangeTrackingFullTextIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FullTextIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateFullTextIndexStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FullTextIndexColumn node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LowPriorityLockWaitAbortAfterWaitOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FullTextCatalogAndFileGroup node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LowPriorityLockWaitMaxDurationOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OnlineIndexLowPriorityLockWaitOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OrderIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IgnoreDupKeyIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OnlineIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WaitAtLowPriorityOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MaxDurationOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IndexExpressionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LowPriorityLockWaitOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IndexStateOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EventTypeGroupContainer node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EventGroupContainer node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropMemberAlterRoleAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AddMemberAlterRoleAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RenameAlterRoleAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterRoleAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterRoleStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateRoleStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RoleStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EventTypeContainer node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterApplicationRoleStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ApplicationRoleStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ApplicationRoleOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterMasterKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateMasterKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MasterKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EventNotificationObjectScope node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateEventNotificationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateApplicationRoleStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateServerRoleStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FileGroupOrPartitionScheme node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExecuteAsClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateSynonymStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateTypeUddtStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateTypeUdtStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateTypeStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TryCatchStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EnableDisableTriggerStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueueOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterTableTriggerModificationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterTableDropTableElement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropClusteredConstraintWaitAtLowPriorityLockOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropClusteredConstraintMoveOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropClusteredConstraintValueOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropClusteredConstraintStateOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropClusteredConstraintOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LowPriorityLockWaitTableSwitchOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterTableDropTableElementStatement node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(QueueStateOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueueValueOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateSelectiveXmlIndexStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateXmlIndexStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterIndexStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PartitionSpecifier node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IndexType node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IndexStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SystemTimePeriodDefinition node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueueProcedureOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IndexDefinition node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterQueueStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueueStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateRouteStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterRouteStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RouteStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RouteOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueueExecuteAsOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateQueueStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SoapMethod node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerRoleStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UserLoginOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ReconfigureStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CheckpointStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(KillStatsJobStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(KillQueryNotificationSubscriptionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(KillStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UseStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ThrowStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ShutdownStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RaiseErrorStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropSchemaStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropTriggerStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropRuleStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropDefaultStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropViewStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropFunctionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropProcedureStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RaiseErrorLegacyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropTableStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetUserStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetOnOffStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(NameFileDeclarationOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FileDeclarationOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FileDeclaration node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateDatabaseStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetErrorLevelStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetIdentityInsertStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetTextSizeStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TruncateTableStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetTransactionIsolationLevelStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetFipsFlaggerCommand node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GeneralSetCommand node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetCommand node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetOffsetsStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetRowCountStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetStatisticsStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PredicateSetStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetCommandStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropServerRoleStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropStatisticsStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MoveToDropIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CursorId node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetVariableStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CursorOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CursorDefinition node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DeclareCursorStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ReturnStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UpdateStatisticsStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CursorStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateStatisticsStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OnOffStatisticsOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(StatisticsPartitionRange node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ResampleStatisticsOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(StatisticsOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterUserStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateUserStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UserStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LiteralStatisticsOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FileStreamOnDropIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OpenCursorStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CryptoMechanism node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropIndexClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BackwardsCompatibleDropIndexClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropIndexClauseBase node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropIndexStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropChildObjectsStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropDatabaseStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropObjectsStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CloseCursorStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropUnownedObjectStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FetchCursorStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FetchType node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DeallocateCursorStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CloseMasterKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OpenMasterKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CloseSymmetricKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OpenSymmetricKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableSwitchOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PayloadOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WsdlPayloadOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseEncryptionKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateDatabaseEncryptionKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DatabaseEncryptionKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OnOffAuditTargetOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LiteralAuditTargetOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MaxRolloverFilesAuditTargetOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MaxSizeAuditTargetOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AuditTargetOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(StateAuditOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OnFailureAuditOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AuditGuidAuditOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueueDelayAuditOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AuditOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AuditTarget node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropServerAuditStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropDatabaseEncryptionKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ResourcePoolStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ResourcePoolParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ResourcePoolAffinitySpecification node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropWorkloadGroupStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterWorkloadGroupStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateWorkloadGroupStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WorkloadGroupParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WorkloadGroupImportanceParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WorkloadGroupResourceParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WorkloadGroupStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerAuditStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropExternalResourcePoolStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateExternalResourcePoolStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalResourcePoolAffinitySpecification node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalResourcePoolParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalResourcePoolStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropResourcePoolStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterResourcePoolStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateResourcePoolStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterExternalResourcePoolStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateServerAuditStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ServerAuditStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropServerAuditSpecificationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DataModificationStatement node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(IdentifierSnippet node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TSqlStatementSnippet node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TSqlFragmentSnippet node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DataModificationSpecification node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SchemaObjectNameSnippet node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(StatementListSnippet node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BooleanExpressionSnippet node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ScalarExpressionSnippet node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RestoreMasterKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BackupMasterKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RestoreServiceMasterKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BackupServiceMasterKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SelectStatementSnippet node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BrokerPriorityStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MergeStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MergeActionClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerAuditSpecificationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateServerAuditSpecificationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropDatabaseAuditSpecificationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterDatabaseAuditSpecificationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateDatabaseAuditSpecificationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AuditActionGroupReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DatabaseAuditAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MergeSpecification node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AuditActionSpecification node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AuditSpecificationPart node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AuditSpecificationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateTypeTableStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(InsertMergeAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DeleteMergeAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UpdateMergeAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MergeAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AuditSpecificationDetail node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BrokerPriorityParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateBrokerPriorityStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterBrokerPriorityStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FailoverModeReplicaOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AvailabilityModeReplicaOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LiteralReplicaOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AvailabilityReplicaOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AvailabilityReplica node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterAvailabilityGroupStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateAvailabilityGroupStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PrimaryRoleReplicaOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AvailabilityGroupStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerConfigurationSetSoftNumaStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerConfigurationHadrClusterOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerConfigurationSetHadrClusterStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerConfigurationFailoverClusterPropertyOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerConfigurationSetFailoverClusterPropertyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerConfigurationDiagnosticsLogMaxSizeOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerConfigurationDiagnosticsLogOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerConfigurationSoftNumaOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerConfigurationSetDiagnosticsLogStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SecondaryRoleReplicaOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LiteralAvailabilityGroupOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TemporalClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SelectiveXmlIndexPromotedPath node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WithinGroupClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WindowDelimiter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WindowFrameClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateColumnStoreIndexStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DiskStatementOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AvailabilityGroupOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DiskStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropFederationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterFederationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateFederationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropAvailabilityGroupStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterAvailabilityGroupFailoverOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterAvailabilityGroupFailoverAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterAvailabilityGroupAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UseFederationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BackupRestoreMasterKeyStatementBase node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionSizeOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TargetDeclaration node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EventDeclarationCompareFunctionParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SourceDeclaration node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EventDeclarationSetParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EventDeclaration node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateEventSessionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EventSessionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SessionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EventSessionObjectName node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterCryptographicProviderStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateCryptographicProviderStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropFullTextStopListStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FullTextStopListAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterFullTextStopListStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateFullTextStopListStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropBrokerPriorityStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropCryptographicProviderStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerConfigurationBufferPoolExtensionContainerOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EventRetentionSessionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LiteralSessionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerConfigurationSetBufferPoolExtensionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ProcessAffinityRange node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServerConfigurationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CellsPerObjectSpatialIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GridParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GridsSpatialIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BoundingBoxParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MemoryPartitionSessionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BoundingBoxSpatialIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SpatialIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateSpatialIndexStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterResourceGovernorStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropEventSessionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterEventSessionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OnOffSessionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MaxDispatchLatencySessionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SpatialIndexRegularOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BackupCertificateStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OnOffDialogOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ScalarExpressionDialogOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(HavingClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OutputIntoClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GroupingSetsGroupingSpecification node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GrandTotalGroupingSpecification node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RollupGroupingSpecification node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CubeGroupingSpecification node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IdentityFunctionCall node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CompositeGroupingSpecification node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GroupingSpecification node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GroupByClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExpressionWithSortOrder node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GraphMatchExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GraphMatchPredicate node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExpressionGroupingSpecification node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BooleanIsNullExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(JoinParenthesisTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(JoinTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ChangeTableVersionTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ChangeTableChangesTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DataModificationTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableReferenceWithAliasAndColumns node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableReferenceWithAlias node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SelectSetVariable node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SelectElement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(QueryParenthesisExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OdbcQualifiedJoinTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OrderByClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BooleanTernaryExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BooleanParenthesisExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BooleanExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreationDispositionKeyOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ProviderKeyNameKeyOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IdentityValueKeyOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlgorithmKeyOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(KeySourceKeyOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(KeyOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateSymmetricKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterSymmetricKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SymmetricKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AuthenticationPayloadOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RolePayloadOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CharacterSetPayloadOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SchemaPayloadOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SessionTimeoutPayloadOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LiteralPayloadOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LoginTypePayloadOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EncryptionPayloadOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FullTextCatalogStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OnOffFullTextCatalogOption node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(TableSampleClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UnpivotedTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PivotedTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ComputeFunction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ComputeClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FullTextCatalogOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GlobalFunctionTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ServiceContract node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServiceStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateServiceStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterCreateServiceStatementBase node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterFullTextCatalogStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateFullTextCatalogStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BuiltInFunctionTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EnabledDisabledPayloadOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UnaryExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropQueueStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropMessageTypeStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropEndpointStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropContractStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RevertStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterLoginAddDropCredentialStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterLoginEnableDisableStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropRemoteServiceBindingStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterLoginOptionsStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PasswordAlterPrincipalOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AsymmetricKeyCreateLoginSource node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CertificateCreateLoginSource node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WindowsCreateLoginSource node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IdentifierPrincipalOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LiteralPrincipalOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OnOffPrincipalOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterLoginStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PrincipalOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropRouteStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SignatureStatementBase node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DialogOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BeginDialogStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BeginConversationTimerStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterServiceMasterKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterAsymmetricKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterSchemaStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WaitForSupportedStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropServiceStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SendStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GetConversationGroupStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MoveConversationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EndConversationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExecuteAsStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropEventNotificationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropSignatureStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AddSignatureStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ReceiveStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OffsetClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PasswordCreateLoginSource node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateLoginStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropMasterKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropUserStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropTypeStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropRoleStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropLoginStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropFullTextIndexStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropFullTextCatalogStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropSymmetricKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropApplicationRoleStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropAggregateStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropSynonymStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropPartitionSchemeStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropPartitionFunctionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(VariableMethodCallTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(VariableTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BinaryQueryExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropAssemblyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateLoginSource node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropAsymmetricKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropCredentialStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropSearchPropertyListStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropSearchPropertyListAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AddSearchPropertyListAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SearchPropertyListAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterSearchPropertyListStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateSearchPropertyListStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterColumnAlterFullTextIndexAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropCertificateStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AddAlterFullTextIndexAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetSearchPropertyListAlterFullTextIndexAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetStopListAlterFullTextIndexAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SimpleAlterFullTextIndexAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterFullTextIndexAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterFullTextIndexStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterPartitionSchemeStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterPartitionFunctionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropAlterFullTextIndexAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterTableSwitchStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SizeFileDeclarationOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CompressionDelayIndexOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ForClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OdbcLiteral node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LiteralRange node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(StatementWithCtesAndXmlNamespaces node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ValueExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(VariableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UserDefinedTypePropertyAccess node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OptionValue node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FullTextPredicate node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OnOffOptionValue node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(InPredicate node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LiteralOptionValue node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GlobalVariableExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LikePredicate node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IdentifierOrValueExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExistsPredicate node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IdentifierOrScalarExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SubqueryComparisonPredicate node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(InlineDerivedTable node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(MaxLiteral node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DefaultLiteral node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BrowseForClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IdentifierLiteral node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OptimizeForOptimizerHint node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(ForceSeekTableHint node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PrintStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableHintsOptimizerHint node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UpdateCall node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TSEqualCall node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LiteralOptimizerHint node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PrimaryExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OptimizerHint node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(Literal node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(NextValueForExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UpdateForClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(NumericLiteral node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(JsonForClauseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RealLiteral node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(JsonForClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MoneyLiteral node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(XmlForClauseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BinaryLiteral node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(XmlForClause node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(ReadOnlyForClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExecuteInsertSource node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LiteralTableHint node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SequenceOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropColumnMasterKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DataTypeReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnEncryptionKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateColumnEncryptionKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableValuedFunctionReturnType node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterColumnEncryptionKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FunctionReturnType node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropColumnEncryptionKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WithCtesAndXmlNamespaces node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnEncryptionKeyValue node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnEncryptionKeyValueParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CommonTableExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnMasterKeyNameParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(XmlNamespacesAliasElement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnEncryptionAlgorithmNameParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(XmlNamespacesDefaultElement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(EncryptedValueParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalTableStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(XmlNamespacesElement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalTableOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(XmlNamespaces node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalTableLiteralOrIdentifierOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExecuteAsFunctionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ParameterizedDataTypeReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnMasterKeyPathParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnMasterKeyStoreProviderNameParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IndexTableHint node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DataTypeSequenceOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableHint node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ScalarExpressionSequenceOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SchemaObjectFunctionTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateSequenceStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterSequenceStatement node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(DropSequenceStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DeclareTableVariableStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SecurityPolicyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SequenceStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DeclareTableVariableBody node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SecurityPolicyOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SelectFunctionReturnType node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateSecurityPolicyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterSecurityPolicyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ScalarFunctionReturnType node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropSecurityPolicyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(XmlDataTypeReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateColumnMasterKeyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UserDataTypeReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnMasterKeyParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SecurityPredicateAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UseHintList node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(IfStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LeftFunctionCall node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LabelStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UserDefinedTypeCallTarget node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(MultiPartIdentifierCallTarget node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ChildObjectName node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExpressionCallTarget node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ProcedureParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CallTarget node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TransactionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WhileStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FunctionCall node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AtTimeZoneCall node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UpdateDeleteSpecificationBase node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TryCastCall node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(CastCall node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(TryParseCall node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RightFunctionCall node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GoToStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DeclareVariableStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PartitionFunctionCall node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IdentifierAtomicBlockOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AtomicBlockOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OnOffAtomicBlockOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BeginEndAtomicBlockStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BeginTransactionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BreakStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BeginEndBlockStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ColumnWithSortOrder node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterFunctionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CommitTransactionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OdbcConvertSpecification node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RollbackTransactionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExtractFromExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ContinueStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OdbcFunctionCall node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateDefaultStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ScalarSubquery node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateFunctionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateOrAlterFunctionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ParameterlessCall node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateRuleStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OverClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DeclareVariableElement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SaveTransactionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ParseCall node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateSchemaStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FullTextTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GrantStatement80 node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(IIfCall node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DenyStatement80 node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CoalesceExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RevokeStatement80 node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SecurityElement80 node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(NullIfExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CommandSecurityElement80 node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PrivilegeSecurityElement80 node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SecurityStatementBody80 node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SimpleCaseExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SecurityUserClause80 node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CaseExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SqlCommandIdentifier node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SearchedWhenClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SetClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SimpleWhenClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FunctionCallSetClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WhenClause node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(InsertSource node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(VariableValuePair node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(Privilege80 node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalTableDistributionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SecurityPrincipal node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SecurityTargetObjectName node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TryConvertCall node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WaitForStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ConvertCall node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ReadTextStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SchemaDeclarationItemOpenjson node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(UpdateTextStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(WriteTextStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SchemaDeclarationItem node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TextModificationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AdHocTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LineNoStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SemanticTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OpenQueryTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(GrantStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(BulkOpenRowset node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DenyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(InternalOpenRowset node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RevokeStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OpenRowsetTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterAuthorizationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(Permission node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OpenJsonTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SecurityTargetObject node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OpenXmlTableReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SecurityStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalTableRejectTypeOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SchemaObjectNameOrValueExpression node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LiteralAtomicBlockOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateProcedureStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ResultColumnDefinition node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropExternalDataSourceStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExecuteAsTriggerOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RemoteDataArchiveAlterTableOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AssemblyOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterExternalDataSourceStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(InlineResultSetDefinition node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateOrAlterProcedureStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExecutableProcedureReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterTableSetStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RemoteDataArchiveDatabaseOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TableOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(OnOffAssemblyOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ProcedureReference node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExecuteParameter node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RemoteDataArchiveDatabaseSetting node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalDataSourceLiteralOrIdentifierOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ResultSetDefinition node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterTableFileTableNamespaceStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(PermissionSetAssemblyOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExecutableStringList node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MethodSpecifier node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RemoteDataArchiveDbServerSetting node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalDataSourceOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TriggerObject node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateExternalDataSourceStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterAssemblyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RemoteDataArchiveTableOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalFileFormatStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateExternalFileFormatStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FileTableDirectoryTableOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateTriggerStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FileTableCollateFileNameTableOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateOrAlterTriggerStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropExternalFileFormatStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExecuteContext node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalFileFormatContainerOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FileTableConstraintNameTableOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TriggerStatementBody node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalFileFormatUseDefaultTypeOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FileStreamOnTableOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AssemblyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExecutableEntity node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExecuteSpecification node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterTriggerStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(MemoryOptimizedTableOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalFileFormatLiteralOption node) { throw new NotImplementedException(); }

            public override void ExplicitVisit(CreateAssemblyStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(LockEscalationTableOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalFileFormatOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DurabilityTableOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SchemaObjectResultSetDefinition node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TriggerAction node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterProcedureStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ProcedureReferenceName node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ResultSetsExecuteOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalDataSourceStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(TriggerOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterTableAddTableElementStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ProcedureStatementBodyBase node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RemoteDataArchiveDbFederatedServiceAccountSetting node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AddFileSpec node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateViewStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExecuteAsProcedureOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateXmlSchemaCollectionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExecuteStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FunctionStatementBody node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalTableShardedDistributionPolicy node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateExternalTableStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterTableRebuildStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterXmlSchemaCollectionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(StatementList node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(FunctionOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalTableReplicatedDistributionPolicy node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RetentionPeriodDefinition node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalTableRoundRobinDistributionPolicy node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(CreateOrAlterViewStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropXmlSchemaCollectionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterTableChangeTrackingModificationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterTableConstraintModificationStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(RemoteDataArchiveDbCredentialSetting node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(SystemVersioningTableOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AssemblyName node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ViewStatementBody node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExternalTableDistributionPolicy node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ViewOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ProcedureStatementBody node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterTableAlterPartitionStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ProcedureOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(DropExternalTableStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AdHocDataSource node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterViewStatement node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(ExecuteOption node) { throw new NotImplementedException(); }
            public override void ExplicitVisit(AlterTableStatement node) { throw new NotImplementedException(); }
        }


    }
}
