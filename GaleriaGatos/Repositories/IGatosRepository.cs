using GaleriaGatos.Properties.Model;

namespace GaleriaGatos.Repositories
{
    public interface IGatosRepository
    {
        Task<IEnumerable<Gatos>> Get();
        Task<Gatos> Get(int Id);
        Task<Gatos> Create(Gatos gatos);
        Task Update(Gatos gatos);
        Task Delete(int Id);
    }
}
