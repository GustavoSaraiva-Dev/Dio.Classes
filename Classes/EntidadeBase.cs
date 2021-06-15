using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dio.Series.Classes
{
    public abstract class EntidadeBase
    {
        private int Id { get; set; }
        public void setEntidadeId(int Id)
        {
            this.Id = Id;
        }

        public int getEntidadeId()
        {
            return this.Id;
        }
    }

}
