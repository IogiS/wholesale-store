using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wholesale_store
{
    class EditStorage
    {

        public TextBox storage_type_text { get; private set; }
        public TextBox id_storage_text { get; private set; }
        public TextBox products_name_text { get; private set; }
        public TextBox counts_product_text { get; private set; }

        public DataGridView productView { get; set; }


        public EditStorage(TextBox storage_type_text, TextBox id_storage_text, TextBox products_name_text, TextBox counts_product_text, DataGridView productView)
        {
            this.storage_type_text = storage_type_text;
            this.id_storage_text = id_storage_text;
            this.products_name_text = products_name_text;
            this.productView = productView;
            this.counts_product_text = counts_product_text;
        }

        public void addProduct()
        {
            try
            {
                using (newStore lcw = new newStore())
                {
                    Storages storages = new Storages { };
                    storages.storage_type = storage_type_text.Text.Trim();
                    storages.name_product = products_name_text.Text.Trim();
                    storages.count_products = int.Parse(counts_product_text.Text);
                    storages.id_storage = int.Parse(id_storage_text.Text);
                    lcw.Storages.Add(storages);
                    lcw.SaveChanges();
                }
                MessageBox.Show("Success", "Add result");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void editProduct(int id_product)
        {
            try
            {
                using (newStore lcw = new newStore())
                {
                    var b = lcw.Storages.Where(p => p.id_storage == id_product).FirstOrDefault();

                    b.storage_type = storage_type_text.Text.Trim();
                    b.name_product = products_name_text.Text.Trim();
                    b.count_products = int.Parse(counts_product_text.Text);
                    b.id_storage = int.Parse(id_storage_text.Text);
                    lcw.SaveChanges();
                }
                MessageBox.Show("Success", "Add result");
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string error = String.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        MessageBox.Show(error);
                    }
                }
            }
        }

        public void deleteProduct(int id_product)
        {
            try
            {
                using (newStore lcw = new newStore())
                {
                    var b = lcw.Storages.Where(p => p.id_storage == id_product).FirstOrDefault();
                    lcw.Storages.Remove(b);
                    lcw.SaveChanges();
                }
                MessageBox.Show("Success", "Add result");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void viewProducts()
        {

            using (newStore lcw = new newStore())
            {
                foreach (Storages products in lcw.Storages)
                {
                    productView.Rows.Add(products.id_storage.ToString(), products.storage_type, products.count_products, products.name_product);


                }
            }

        }

    }
}
