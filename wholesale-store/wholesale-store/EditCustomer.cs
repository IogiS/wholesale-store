using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wholesale_store
{
    class EditCustomer
    {

        public TextBox id_customer_text { get; private set; }
        public TextBox customer_name_text { get; private set; }
        public TextBox customer_adress { get; private set; }
        public TextBox customer_age_text { get; private set; }
        public DataGridView productView { get; set; }


        public EditCustomer(TextBox id_customer_text, TextBox customer_name_text, TextBox customer_adress, TextBox customer_age_text, DataGridView productView)
        {
            this.id_customer_text = id_customer_text;
            this.customer_name_text = customer_name_text;
            this.productView = productView;
            this.customer_adress = customer_adress;
            this.customer_age_text = customer_age_text;
        }

        public void addProduct()
        {
            try
            {
                using (newStore lcw = new newStore())
                {
                    Customers storages = new Customers { };
                    storages.customer_address = customer_adress.Text;
                    storages.customer_name = customer_name_text.Text;
                    storages.cutomer_age = customer_age_text.Text;
                    storages.id_customer = int.Parse(id_customer_text.Text);
                    lcw.Customers.Add(storages);
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
                    var b = lcw.Customers.Where(p => p.id_customer == id_product).FirstOrDefault();
                    b.customer_address = customer_adress.Text;
                    b.customer_name = customer_name_text.Text;
                    b.cutomer_age = customer_age_text.Text;
                    b.id_customer = int.Parse(id_customer_text.Text);
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
                    var b = lcw.Customers.Where(p => p.id_customer == id_product).FirstOrDefault();
                    lcw.Customers.Remove(b);
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
                foreach (Customers products in lcw.Customers)
                {
                    productView.Rows.Add(products.id_customer.ToString(), products.customer_name, products.customer_address, products.cutomer_age);


                }
            }

        }

    }
}
