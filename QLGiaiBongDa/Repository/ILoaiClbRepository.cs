using QLGiaiBongDa.Models;

namespace QLGiaiBongDa.Repository
{
    public interface ILoaiClbRepository
    {
        Caulacbo Add(Caulacbo caulacbo);

        Caulacbo Update(Caulacbo caulacbo);

        Caulacbo Delete(String CaulacboId);

        Caulacbo GetLoaiClb(String CaulacboId);

        IEnumerable<Caulacbo> GetAllLoaiClb();
    }
}
