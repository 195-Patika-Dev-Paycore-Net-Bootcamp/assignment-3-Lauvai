using System.ComponentModel.DataAnnotations.Schema;

namespace Container.Model
{
    public class ContainerModel
    {
        public virtual int Id { get; set; }
        public virtual string ContainerName { get; set; }

        [Column(TypeName = "decimal(10, 6)")]
        public virtual decimal Latitude { get; set; }

        [Column(TypeName = "decimal(10, 6)")]
        public virtual decimal Longitude { get; set; }
        public virtual int VehicleId { get; set; }
    }
}
