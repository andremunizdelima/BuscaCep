using System.Threading.Tasks;

using Domain.Entities;

namespace Application.Interface
{
    public interface ICepService
    {
        Task<Cep> ConsultarEndereco(string cep);
    }
}
