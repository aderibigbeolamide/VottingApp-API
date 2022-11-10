namespace VottingAPI.Data.Base
{
    public interface ISoftDelete
    {
         public DateTime? DeletedOn { get; set; }
         public int? DeletedBy { get; set; }
         public bool? IsDeleted { get; set; }
    }
}