

using System;
using System.Linq;
using System.Windows.Forms;

namespace wholesale_store
{
    public class EditProduct
    {

        public TextBox mark_product_text { get; private set; }
        public TextBox product_unit_text { get; private set; }
        public TextBox product_price_text { get; private set; }
        public TextBox on_storage_text { get; private set; }
        public TextBox id_provider_text { get; private set; }
        public TextBox id_storage { get; private set; }
        public TextBox id_product { get; private set; }
        public DataGridView productView { get; set; }


        public EditProduct(TextBox mark_product_text, TextBox product_unit_text, TextBox product_price_text, TextBox on_storage_text, TextBox id_provider_text, TextBox id_storage, TextBox id_product, DataGridView productView)
        {
            this.mark_product_text = mark_product_text;
            this.product_unit_text = product_unit_text;
            this.product_price_text = product_price_text;
            this.on_storage_text = on_storage_text;
            this.id_provider_text = id_provider_text;
            this.id_storage = id_storage;
            this.id_product = id_product;
            this.productView = productView;
         }

        public void addProduct()
        {
            try { 
            using (newStore lcw = new newStore())
            {
                Products product = new Products { };
                product.id_provider = int.Parse(id_provider_text.Text);
                product.unit_product = product_unit_text.Text;
                product.price_product = product_price_text.Text;
                product.mark_product = mark_product_text.Text;
                product.on_stock = on_storage_text.Text;
                product.id_storage = int.Parse(id_storage.Text);
                product.id_product = int.Parse(id_product.Text);
                lcw.Products.Add(product);
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
                    var b = lcw.Products.Where(p => p.id_product == id_product).FirstOrDefault();

                    b.id_provider = int.Parse(id_provider_text.Text);
                    b.unit_product = product_unit_text.Text;
                    b.price_product = product_price_text.Text;
                    b.mark_product = mark_product_text.Text;
                    b.on_stock = on_storage_text.Text;
                    b.id_storage = int.Parse(id_storage.Text);
                    lcw.SaveChanges();
                }
                MessageBox.Show("Success", "Add result");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void deleteProduct(int id_product)
        {
            try { 
            using (newStore lcw = new newStore())
            {
                var b = lcw.Products.Where(p => p.id_product == id_product).FirstOrDefault();
                lcw.Products.Remove(b);
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
                foreach (Products products in lcw.Products)
                {
                    productView.Rows.Add(products.id_product.ToString(), products.id_provider, products.id_storage, products.mark_product, products.unit_product, products.price_product, products.on_stock);


                }
            }

        }

    }
}
