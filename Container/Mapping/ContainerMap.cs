using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Container.Model;

namespace Container.Mapping
{
    public class ContainerMap : ClassMapping<ContainerModel>
    {
       public ContainerMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.ContainerName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(false);
            });
            Property(b => b.Latitude, x =>
            {
                x.Type(NHibernateUtil.Decimal);
                x.NotNullable(false);
            });
            Property(b => b.Longitude, x =>
            {
                x.Type(NHibernateUtil.Decimal);
                x.NotNullable(false);
            });
            Property(b => b.VehicleId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(false);
            });

            Table("Container");
        }
    }
}
