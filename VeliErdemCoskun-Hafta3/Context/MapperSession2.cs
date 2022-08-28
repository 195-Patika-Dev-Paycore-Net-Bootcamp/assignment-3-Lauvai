using NHibernate;
using System.Linq;
using Vehicle.Context;
using Vehicle.Model;

namespace Vehicle.Context
{
    public class MapperSession2: IMapperSession
    {
        private readonly ISession session;
        private ITransaction transaction;

        public MapperSession2(ISession session)
        {
            this.session = session;
        }

        public IQueryable<VehicleModel> Vehicles => session.Query<VehicleModel>();


        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }

        public void Save(VehicleModel entity)
        {
            session.Save(entity);
        }
        public void Update(VehicleModel entity)
        {
            session.Update(entity);
        }
        public void Delete(VehicleModel entity)
        {
            session.Delete(entity);
        }
    }
}
