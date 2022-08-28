using Container.Model;
using NHibernate;
using System.Linq;

namespace Container.Context
{
    public class MapperSession : IMapperSession
    {
        private readonly ISession session;
        private ITransaction transaction;

        public MapperSession(ISession session)
        {
            this.session = session;
        }

        public IQueryable<ContainerModel> Containers => session.Query<ContainerModel>();


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

        public void Save(ContainerModel entity)
        {
            session.Save(entity);
        }
        public void Update(ContainerModel entity)
        {
            session.Update(entity);
        }
        public void Delete(ContainerModel entity)
        {
            session.Delete(entity);
        }
    }
}
