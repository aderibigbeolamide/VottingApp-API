namespace VottingAPI.Data.Base
{
    public interface IAuditableEntity
    {
         public int CreatedBy { get; set; }
         public DateTime? CreatedOn { get; set; }
         public int LastModified { get; set; }
         public DateTime? LastModifiedOn { get; set; }
    }
}