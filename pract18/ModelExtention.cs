using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract18
{
    public class ModelExtention : Accounting_of_medicinesEntities
    {
        public static Accounting_of_medicinesEntities context;

        public static Accounting_of_medicinesEntities GetContent()
        {
            if (context == null)
                context = new Accounting_of_medicinesEntities();
            return context;
        }
    }
}
