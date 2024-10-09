using QLGiaiBongDa.Models;
namespace QLGiaiBongDa.Repository
{
    public class LoaiClbRepository : ILoaiClbRepository
    {
        private readonly QlgiaiBongDaContext _context;
        public LoaiClbRepository(QlgiaiBongDaContext context)
        {
            _context = context;
        }
        public Caulacbo Add(Caulacbo loaiclb)
        {
            _context.Caulacbos.Add(loaiclb);
            _context.SaveChanges();
            return loaiclb;
        }
        public Caulacbo Delete(string maloaiclb)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Caulacbo> GetAllLoaiClb()
        {
            return _context.Caulacbos;
        }
        public Caulacbo GetLoaiClb(string maloaiclb)
        {
            return _context.Caulacbos.Find(maloaiclb);
        }
        public Caulacbo Update(Caulacbo loaiclb)
        {
            _context.Update(loaiclb);
            _context.SaveChanges();
            return loaiclb;
        }
    }
}
