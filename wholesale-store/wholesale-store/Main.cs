using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace wholesale_store
{

    public partial class Main : Form
    {
        EditProduct editProduct;
        EditStorage editStorage;
        EditProvider editProvider;
        EditCustomer editCustomer;

        public Main()
        {
            InitializeComponent();
            editProduct = new EditProduct(mark_product_text,product_unit_text,product_price_text,on_storage_text,id_provider_text,id_storage,id_product, productView);
            editStorage = new EditStorage(storage_type_text,counts_product_text,products_name_text,id_storage_text, StorageView);
            editProvider = new EditProvider(nameProvider,adress_provider_text,provider_id,providersView);
            editCustomer = new EditCustomer(id_customer_text,customer_name_text,customer_adress,customer_age_text,customersView);
            editCustomer.viewProducts();
            editProvider.viewProducts();
            editStorage.viewProducts();
            editProduct.viewProducts();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            editProduct.addProduct();
            resetGridViews(1);
        }


        private void productView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in productView.SelectedRows)
            {
                id_product.Text = row.Cells[0].Value.ToString();
                id_provider_text.Text = row.Cells[1].Value.ToString();
                id_storage.Text = row.Cells[2].Value.ToString();
                mark_product_text.Text = row.Cells[3].Value.ToString();
                product_unit_text.Text = row.Cells[4].Value.ToString();
                product_price_text.Text = row.Cells[5].Value.ToString();
                on_storage_text.Text = row.Cells[6].Value.ToString();



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            editProduct.editProduct(int.Parse(id_product.Text));
            resetGridViews(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            editProduct.deleteProduct(int.Parse(id_product.Text));
            resetGridViews(1);
        }

        private void resetGridViews(int flag)
        {
            if (flag == 1)
            {
                productView.Rows.Clear();
                editProduct.viewProducts();
            }
            else if (flag == 2)
            {
                StorageView.Rows.Clear();
                editStorage.viewProducts();
            }
            else if (flag == 3)
            {
                providersView.Rows.Clear();
                editProvider.viewProducts();
            }
            else if (flag == 4)
            {
                customersView.Rows.Clear();
                editCustomer.viewProducts();
            }
            
        }


        private void DeleteStorage_Click(object sender, EventArgs e)
        {
            editStorage.deleteProduct(int.Parse(id_storage_text.Text));
            resetGridViews(2);
        }
        private void EditStorage_Click(object sender, EventArgs e)
        {
            editStorage.editProduct(int.Parse(id_storage_text.Text));
            resetGridViews(2);
        }

        private void AddStorage_Click(object sender, EventArgs e)
        {
            editStorage.addProduct();
            resetGridViews(2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            editProvider.deleteProduct(int.Parse(provider_id.Text));
            resetGridViews(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            editProvider.editProduct(int.Parse(provider_id.Text));
            resetGridViews(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            editProvider.addProduct();
            resetGridViews(3);
        }

        private void StorageView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in StorageView.SelectedRows)
            {
                id_storage_text.Text = row.Cells[0].Value.ToString();
                storage_type_text.Text = row.Cells[1].Value.ToString();
                counts_product_text.Text = row.Cells[2].Value.ToString();
                products_name_text.Text = row.Cells[3].Value.ToString();

            }
        }

        private void providersView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in providersView.SelectedRows)
            {
                provider_id.Text = row.Cells[0].Value.ToString();
                nameProvider.Text = row.Cells[1].Value.ToString();
                adress_provider_text.Text = row.Cells[2].Value.ToString();

            }
        }

        private void customersView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in customersView.SelectedRows)
            {
                id_customer_text.Text = row.Cells[0].Value.ToString();
                customer_name_text.Text = row.Cells[1].Value.ToString();
                customer_adress.Text = row.Cells[2].Value.ToString();
                customer_age_text.Text = row.Cells[3].Value.ToString();

            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            editCustomer.deleteProduct(int.Parse(id_customer_text.Text));
            resetGridViews(4);
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            editCustomer.editProduct(int.Parse(id_customer_text.Text));
            resetGridViews(4);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            editCustomer.addProduct();
            resetGridViews(4);
        }
    }
}
