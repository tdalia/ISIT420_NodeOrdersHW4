namespace NodeOrders500_HW4.Models
{
    public class EmployeeDTO
    {
        public EmployeeDTO()
        {

        }
        public EmployeeDTO(int id, string name)
        {
            SalesPersonId = id;
            EmployeeFullName = name;
        }

        public int SalesPersonId { get; set; }

        public string EmployeeFullName { get; set; }
    }
}