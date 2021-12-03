/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            var item = product ?? throw new ArgumentNullException(nameof(product));

            ObjectValidator.Validate(product);

            //Ensure product isn't a duplicate
            var exists = FindProduct(product.Id);
            if (exists != null)
                throw new InvalidOperationException("Product must be unique.");

            //Emulate database by storing copy
            return AddCore(product);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID not valid; must be greater than or equal to zero.");

            return GetCore(id);
        }
        
        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }
        
        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Remove ( int id )
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID not valid; must be greater than or equal to zero.");

            RemoveCore(id);
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( Product product )
        {
            if (product.Id < 0)
                throw new ArgumentOutOfRangeException(nameof(product.Id), "ID not valid; must be greater than or equal to zero.");

            if (product == null)
                throw new ArgumentNullException(nameof(product));

            ObjectValidator.Validate(product);

            //Get existing product
            var existing = GetCore(product.Id);

            //Checks if updated product doesn't match an existing one
            var match = FindProduct(product.Id);
            if (match != null && match.Name != product.Name)
                throw new InvalidOperationException("Product must be different from existing one.");

            return UpdateCore(existing, product);
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );

        protected abstract Product FindProduct( int id );
        #endregion
    }
}
