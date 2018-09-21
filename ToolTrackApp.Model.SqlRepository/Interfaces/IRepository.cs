using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolTrackApp.Model.SqlRepository.Interfaces
{
    public interface IRepository<TEntity>
    {
        List<TEntity> SelectByFilter(Func<TEntity, bool> filter);
        void AddRange(List<TEntity> listaEntity);
        void Remove(TEntity entity);
        void AddOrAttach(TEntity entity);
        void AddSingle(TEntity entity);
    }
}
