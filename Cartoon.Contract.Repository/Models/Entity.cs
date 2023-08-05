using Cartoon.Core.Utils;
using System.ComponentModel.DataAnnotations;

namespace Cartoon.Contract.Repository.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedTime = LastUpdatedTime = CoreHelper.SystemTimeNow;
        }

        [Key]
        public string Id { get; set; }
        public string KeyId { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? DeletedBy { get; set; }

        public DateTimeOffset? CreatedTime { get; set; }

        public DateTimeOffset? LastUpdatedTime { get; set; }

        public DateTimeOffset? DeletedTime { get; set; }
        public string? Code { get; set; }

    }
}
