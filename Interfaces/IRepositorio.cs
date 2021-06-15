using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dio.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetonaPorId(int id);
        void Inserir(T entidade);
        void Excluir(int id);
        void Alterar(int id, T entidade);
        int proximoId();
    }
}
