using Container.Model;
using System.Linq;

namespace Container.Context
{
    public interface IMapperSession
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
        void Save(ContainerModel entity);
        void Update(ContainerModel entity);
        void Delete(ContainerModel entity);

        IQueryable<ContainerModel> Containers { get; }
    }
}
