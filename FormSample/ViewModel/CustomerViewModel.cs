using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSample.ViewModel
{
    using System.Collections.ObjectModel;

    using SQLite.Net;

    class CustomerViewModel : BaseViewModel
    {

        private AgentDatabase db;
        public ObservableCollection<Agent> customerList { get; set; }

        DataService ds = new DataService();

        public CustomerViewModel()
        {
            db = new AgentDatabase();
            customerList = new ObservableCollection<Agent>();
            BindCustomer();
        }

        public async Task DeleteCustomer(int id)
        {
            db.DeleteItem(id);
            //var deletedCustomer = await this.ds.DeleteCustomer(id);
            //var tmp = deletedCustomer;

            this.BindCustomer();
        }

        private async Task BindCustomer()
        {
           //  var customerList = await this.ds.GetCustomers();
            var customerList = db.GetAgents().ToList();

            this.customerList = new ObservableCollection<Agent>(customerList);
        }
    }
}
