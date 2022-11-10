namespace VottingAPI.Data.Base
{
    public class AuditableEntity : EntityBase, IAuditableEntity, ISoftDelete
    {
        public int CreatedBy { get ; set ; }
        public DateTime? CreatedOn { get ; set ; }
        public int LastModified { get ; set ; }
        public DateTime? LastModifiedOn { get ; set ; }
        public DateTime? DeletedOn { get ; set ; }
        public int? DeletedBy { get ; set ; }
        public bool? IsDeleted { get ; set ; }
    }
}