using System.Threading.Tasks;

using Domain.Entities;

namespace Domain.Client
{
    public interface ICepClient { Task<Cep> GetCepClient(string cep); }
}
