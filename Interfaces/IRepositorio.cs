using System.Collections.Generic;

namespace DIO_Series
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int Id);
        void Insere(T entidade);
        void Deletar(int Id);
        void Atualizar(int Id,T entidade);
        int ProximoId();


    }
}