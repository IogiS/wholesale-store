using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wholesale_store
{
    class EditProvider
    {

        public TextBox nameProvider { get; private set; }
        public TextBox provider_id { get; private set; }
        public TextBox adress_provider_text { get; private set; }
        public DataGridView productView { get; set; }


        public EditProvider(TextBox nameProvider, TextBox adress_provider_text,TextBox provider_id, DataGridView productView)
        {
            this.provider_id = provider_id;
            this.nameProvider = nameProvider;
            this.productView = productView;
            this.adress_provider_text = adress_provider_text;
        }

        public void addProduct()
        {
            try
            {
                using (newStore lcw = new newStore())
                {
                    Providers storages = new Providers { };
                    storages.provider_name = nameProvider.Text;
                    storages.provider_address = adress_provider_text.Text;
                    storages.id_provider = int.Parse(provider_id.Text);
                    lcw.Providers.Add(storages);
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
                    var b = lcw.Providers.Where(p => p.id_provider == id_product).FirstOrDefault();
                    b.provider_name = nameProvider.Text;
                    b.provider_address = adress_provider_text.Text;
                    b.id_provider = int.Parse(provider_id.Text);
                    lcw.SaveChanges();
                }
                MessageBox.Show("Success", "Add result");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void deleteProduct(int id_product)
        {
            try
            {
                using (newStore lcw = new newStore())
                {
                    var b = lcw.Providers.Where(p => p.id_provider == id_product).FirstOrDefault();
                    lcw.Providers.Remove(b);
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
                foreach (Providers products in lcw.Providers)
                {
                    productView.Rows.Add(products.id_provider.ToString(), products.provider_name, products.provider_address);


                }
            }

        }

    }
}