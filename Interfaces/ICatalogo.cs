using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface ICatalogo
    {
        Task<IEnumerable<Catalogo>> getAll();
        Task<Catalogo> getOne(string id);
        Task remove(string id);
        Task save(Catalogo catalogo);
    }
}
