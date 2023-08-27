namespace Domain.Entity.Base
{
    public class BaseEntity
    {
        public long ID { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
