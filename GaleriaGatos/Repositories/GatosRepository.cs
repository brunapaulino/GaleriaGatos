using GaleriaGatos.Properties.Model;
using Microsoft.EntityFrameworkCore;

namespace GaleriaGatos.Repositories
{
    public class GatosRepository : IGatosRepository
    {
        public readonly GatosContext _context;
 
 //Conexão com o banco de dados
        public GatosRepository(GatosContext context)
        {
            _context = context;
        }
//Criar Registro - Adquirir os dados
        public async Task<Gatos> Create(Gatos gatos)
        {
            _context.Galeriagatos.Add(gatos);
            await _context.SaveChangesAsync();

            return gatos;
        }
//Deletar Id
        public async Task Delete(int id)
        {
            var gatosToDelete = await _context.Galeriagatos.FindAsync(id);
            _context.Galeriagatos.Remove(gatosToDelete);
            await _context.SaveChangesAsync();
        }
//Listar todos os registros do banco
        public async Task<IEnumerable<Gatos>> Get()
        {
            return await _context.Galeriagatos.ToListAsync();
        }

        public async Task<Gatos> Get(int id)
        {
            return await _context.Galeriagatos.FindAsync(id);
        }

        public async Task Update(Gatos gatos)
        {
            _context.Entry(gatos).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}