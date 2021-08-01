using System.Collections.Generic;

namespace DIO_Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        List<Serie> listaSerie = new List<Serie>();
        public void Atualizar(int Id, Serie entidade)
        {
            listaSerie[Id] = entidade;
        }

        public void Deletar(int Id)
        {
            listaSerie[Id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);;
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int Id)
        {
           return listaSerie[Id];
        }
    }
}