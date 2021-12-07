/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Nile.Stores.Sql;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            _gridProducts.AutoGenerateColumns = false;

            _bsProducts.ProductComparer();

            UpdateList();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var dlg = new AboutBox();

            dlg.ShowDialog();
        }

        #region Event Handlers
        
        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            var child = new ProductDetailForm("Product Details");
            
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    //Save product
                    _database.Add(child.Product);
                    UpdateList();
                    return;
                } catch (ArgumentException ex)
                {
                    ErrorMessage(ex.Message, "Invalid Product");
                } catch (InvalidOperationException ex)
                {
                    ErrorMessage(ex.Message, "Unable to currently process.");
                } catch (Exception ex)
                {
                    ErrorMessage(ex.Message, "Error.");
                };

            } while (true);
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("No products available.");
                return;
            };

            EditProduct(product);
        }        

        private void OnProductDelete( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;

            DeleteProduct(product);
        }        
                
        private void OnEditRow( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                EditProduct(item);
        }

        private void OnKeyDownGrid( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);
			
			//Don't continue with key
            e.SuppressKeyPress = true;
        }

        public void ErrorMessage( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Private Members

        private void DeleteProduct ( Product product )
        {

            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                //Delete product
                _database.Remove(product.Id);
                UpdateList();
            } catch (ArgumentException ex)
            {
                ErrorMessage(ex.Message, "No Product to delete.");
            } catch (InvalidOperationException ex)
            {
                ErrorMessage(ex.Message, "Unable to currently process.");
            } catch (Exception ex)
            {
                ErrorMessage(ex.Message, "Error.");
            };
        }

        private void EditProduct ( Product product )
        {
            var child = new ProductDetailForm("Product Details");
            child.Product = product;

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    //Save product
                    _database.Update(child.Product);
                    UpdateList();
                } catch (ArgumentException ex)
                {
                    ErrorMessage(ex.Message, "Invalid Product");
                } catch (InvalidOperationException ex)
                {
                    ErrorMessage(ex.Message, "Unable to currently process.");
                } catch (Exception ex)
                {
                    ErrorMessage(ex.Message, "Error.");
                };

                return;
            } while (true);
        }

        private Product GetSelectedProduct ()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        private void UpdateList ()
        {
            try
            {
                _bsProducts.DataSource = _database.GetAll();
            } catch (ArgumentException ex)
            {
                ErrorMessage(ex.Message, "Invalid Product");
            } catch (InvalidOperationException ex)
            {
                ErrorMessage(ex.Message, "Unable to currently process.");
            } catch (Exception ex)
            {
                ErrorMessage(ex.Message, "Error.");
            };
        }

        private string GetConnectionString ( string name )
                => Program.Configuration.GetConnectionString(name);

        private readonly IProductDatabase _database = new SqlProductDatabase("Data Source=(localdb)\\ProjectsV13;Initial Catalog=NileDatabase;Integrated Security=SSPI;");
        #endregion
    }
}
