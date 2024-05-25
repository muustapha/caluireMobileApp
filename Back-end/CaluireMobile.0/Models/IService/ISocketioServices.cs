using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.IService
{
    public interface ISocketioServices
    {
        public void AddSocketio(Socketio Socketio);
        public void DeleteSocketio(int id);
        public IEnumerable<Socketio> GetAllSocketio();
        public Socketio GetSocketioById(int id);
        public void UpdateSocketio(Socketio Socketio);
    }
}
