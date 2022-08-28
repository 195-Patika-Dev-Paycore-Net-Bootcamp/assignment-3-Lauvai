using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using Vehicle.Model;

namespace Vehicle.Mapping
{
    public class VehicleMap : ClassMapping<VehicleModel>
    {
        public  VehicleMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.VehicleName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(false);
            });
            Property(b => b.VehiclePlate, x =>
            {
                x.Length(14);
                x.Type(NHibernateUtil.String);
                x.NotNullable(false);
            });

            Table("Vehicle");
        }
            
    }
}
