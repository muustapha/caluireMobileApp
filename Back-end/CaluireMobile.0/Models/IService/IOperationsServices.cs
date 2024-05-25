using CaluireMobile._0.Models.Datas;

namespace CaluireMobile._0.Models.IService
{
    public interface IOperationsServices
    {
        public void AddOperation(Operation operation);
        public void DeleteOperation(int id);
        public IEnumerable<Operation> GetAllOperations();
        public Operation GetOperationById(int id);
        public void UpdateOperation(int id, Operation operation);
    }
}
