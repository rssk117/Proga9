using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Пр_9
{
    struct Baggage
    {
        public double TotalWeight;
        public int QuantityThings;
        public Baggage(double _totalWeight, int _quantityThings)
        {
            TotalWeight =_totalWeight;
            QuantityThings = _quantityThings;
        }
    }
}
