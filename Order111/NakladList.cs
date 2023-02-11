using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderGen.Domain;

namespace Order111
{
    public partial class OrderGenMain : Form
    {
        //BindingList <Order> _OrderList = new BindingList <Order> ();
        
        List<Order>orderList=new List<Order>();

        public OrderGenMain()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OrderGenMain_Load(object sender, EventArgs e)
        {
            /*
             Contract.Ensures(orderBindingSource.DataSource == _order);
            Contract.Ensures(orderItemBindingSource.DataSource == _order.OrderItems); //Проверка

            //dgvOrder.AutoGenerateColumns = false;

            orderBindingSource.DataSource = _order;
            orderItemBindingSource.DataSource = _order.OrderItems;

            OrderNum.Text = Convert.ToString(_order.Id);
            OrderDate.Value = _order.Created;
            */
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            /*dgvOrder.Rows.Clear();*/
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            /*
            //Contract.Ensures(orderItemBindingSource.Count == 0);
            //orderItemBindingSource.Clear();
            _order.Clear();
            */
        }

        private void dgvOrder_DataMemberChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            /*
            for(int a=0;a<dgvOrder.Rows.Count;a++)
            {
                _order.OrderItems.Add(new OrderItem());
                DataGridViewRow row = dgvOrder.Rows[a];
                _order.OrderItems[a].Specification = Convert.ToString(row.Cells[0].Value); //Разобрать как                                                                                         
                _order.OrderItems[a].Count = Convert.ToDecimal(row.Cells[1].Value);       //сделать запись из DGV
                _order.OrderItems[a].Price = Convert.ToDecimal(row.Cells[2].Value);
                _order.OrderItems[a].nds = Convert.ToInt32(row.Cells[3].Value);
                row.Cells[4].Value = _order.OrderItems[a].Total;
            };
            orderList.Add(_order);
            dgvOrder.Rows.Clear();
                _order.Id++;
            _order.Created = OrderDate.Value;
            OrderSum.Text = Convert.ToString(_order.Total);
            */
        }

        private void orderItemBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            //Contract.Requires(OrderSum.DataBindings.Count > 0);
            // OrderSum.DataBindings[0].ReadValue();
        }

        private void dgvOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            /*
            dgvOrder.Rows.Clear();
            dgvOrder.DataSource =
                orderList[Convert.ToInt32(bindingNavigatorPositionItem.Text)-1].OrderItems;
            */
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            /*
            dgvOrder.Rows.Clear();
            dgvOrder.DataSource =
                orderList[Convert.ToInt32(bindingNavigatorPositionItem.Text) - 1].OrderItems;
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Naklad dlg = new Naklad();
            //dlg.dataGridView1.DataSource = orderList[listBox1.SelectedIndex].OrderItems;
            dlg.textBox1.Text= orderList[listBox1.SelectedIndex].Id.ToString();
            dlg.dateTimePicker1.Value = orderList[listBox1.SelectedIndex].Created;
            dlg.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Contract.Requires(textBox1.Text!=null);
            orderList.Add(new Order());
            orderList[orderList.Count-1].Id= Convert.ToInt32(textBox1.Text);

            BindingList<Order> binding_order = new BindingList<Order>(orderList);
            listBox1.DataSource = binding_order;
            listBox1.DisplayMember = "_id";
        }

        //Ограничение на ввод в ТекстБокс только цифр
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;//Обозначаем как символ нажатую нами клавишу

            if (!Char.IsDigit(number))//Если нажатая клавиша не является десятичным числом
            {
                e.Handled = true;//Тогда не обрабатывать данный символ
                //e.Handled - запрет обработки ставим true
            }
        }
    }
}
