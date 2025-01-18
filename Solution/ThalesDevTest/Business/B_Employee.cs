using DataAccess;
using Entity;

namespace Business
{
    public class B_Employee
    {
        private readonly ApiService _apiService;

        public B_Employee(HttpClient httpClient) {
            httpClient.BaseAddress = new Uri("http://dummy.restapiexample.com/api/v1/employees/");
            _apiService = new ApiService(httpClient);
        }

        private Employee calculateTaxValue(Employee employee) {
            employee.employee_anual_salary = employee.employee_salary * 12;
            return employee;
        }

        public async Task<List<Employee>> GetEmployees() {
            var data = await _apiService.GetData<List<Employee>>("");

            var updatedData = data.Data.Select(employee => {
                return calculateTaxValue(employee);
            }).ToList();

            return updatedData;
        }

        public async Task<Employee> GetEmployeeById(int id) {
            var data = await _apiService.GetData<Employee>($"{id}");
            return calculateTaxValue(data.Data);
        }
    }
}
