
using ORMProduct.Controller;
using ORMProducts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace ORMProduct
{
    public partial class Form1 : Form
    {
        ProductController productController = new ProductController();
        ProductTypeController productTypeController = new ProductTypeController();


        public Form1()
        {
            InitializeComponent();
        }


        private void LoadRecord(Product product)
        {
            txtId.Text = product.Id.ToString();
            txtName.Text = product.Name;
            txtDesc.Text = product.Description;
            txtPrice.Text = product.Price.ToString();
            txtSize.Text = product.Size;
            cmbGender.Text = product.Gender;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            {
                int findId = 0;
                if (string.IsNullOrEmpty(txtId.Text) || !txtId.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Въведете Id за търсене!");
                    txtId.BackColor = Color.Red;
                    txtId.Focus();
                    return;
                }
                else
                {
                    findId = int.Parse(txtId.Text);
                }

                //Ако няма намерен запис търсим по Id и визуализираме на екрана
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    Product findProduct = productController.Get(findId);
                    if (findProduct == null)
                    {
                        MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                        txtId.BackColor = Color.Red;
                        txtId.Focus();
                        return;
                    }
                    LoadRecord(findProduct);
                    
                }
                else //Ако има намерен вече запис променяме по полетата
                {
                    Product updateProduct = new Product();

                    updateProduct.Name = txtName.Text;

                    updateProduct.Gender = cmbGender.Text;
                    
                    updateProduct.TypeId = (int)cmbType.SelectedValue;

                    updateProduct.Description = txtDesc.Text;

                    updateProduct.Size = txtSize.Text;

                    productController.Update(findId, updateProduct);

                    MessageBox.Show("Продукта бе обновен");





                }

            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            List<ProductType> productTypes = productTypeController.GetAll();
            cmbType.DataSource = productTypes;
            cmbType.DisplayMember = "Name";
            cmbType.ValueMember = "Id";
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                txtName.Focus();
                return;
            }
            Product newProduct = new Product();

            newProduct.Description = txtDesc.Text;

            newProduct.Name = txtName.Text;

            newProduct.Gender = cmbGender.Text;

            newProduct.Price = double.Parse(txtPrice.Text);

            newProduct.TypeId = (int)cmbType.SelectedValue;

            newProduct.Size = txtSize.Text;

            
            productController.Create(newProduct);

            MessageBox.Show("Записът е успешно добавен!");
        }

       

        private void btnDelete_Click(object sender, EventArgs e)
        {
            {
                int findId = 0;
                if (string.IsNullOrEmpty(txtId.Text) || !txtId.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Въведете Id за търсене!");
                    txtId.BackColor = Color.Red;
                    txtId.Focus();
                    return;
                }
                else
                {
                    findId = int.Parse(txtId.Text);
                }
               var findProduct = productController.Get(findId);
                if (findProduct == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                    txtId.BackColor = Color.Red;
                    txtId.Focus();
                    return;
                }
                

                DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете запис No " +
                findId + " ?",
                 "PROMPT", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    productController.Delete(findId);
                }
            }
        }
    }
}
