using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    class ProductComparer : IComparer<Product>
    {
        public int Compare ( Product productFirst, Product productNext )
        {
            if(String.IsNullOrEmpty(productFirst.Name) || String.IsNullOrEmpty(productNext.Name))
            {
                return 0;
            }

            return productFirst.Name.CompareTo(productNext.Name);
        }
    }
}
