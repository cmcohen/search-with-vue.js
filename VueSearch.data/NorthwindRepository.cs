using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueSearch.data
{
    public class NorthwindRepository
    {
        private string _connectionString;

        public NorthwindRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Product> SearchProductName(string searchTerm)
        {
            using (var context = new VueSearchDataContext(_connectionString))
            {
                return context.Products.Where(p => p.ProductName.Contains(searchTerm)).ToList();
            }
        }

        public IEnumerable<Product> SearchPrice(decimal price)
        {
            using (var context = new VueSearchDataContext(_connectionString))
            {
                return context.Products.Where(p => p.UnitPrice == price).ToList();
            }
        }
    }
}
