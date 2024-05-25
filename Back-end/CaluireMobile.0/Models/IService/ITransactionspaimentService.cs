using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.IService
{
    public interface ITransactionspaimentService
    {
        public void AddTransaction(Transactionspaiment transaction);
        public void DeleteTransaction(int id);
        public IEnumerable<Transactionspaiment> GetAllTransactions();
        public Transactionspaiment GetTransactionById(int id);
        public void UpdateTransaction(Transactionspaiment transaction);
    }
}
