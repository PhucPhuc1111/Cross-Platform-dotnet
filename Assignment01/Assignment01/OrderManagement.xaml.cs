using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for OrderManagement.xaml
    /// </summary>
    public partial class OrderManagement : Window
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMemberRepository memberRepository;
        private readonly IProductRepository productRepository;
        public OrderManagement(IOrderRepository _orderRepository, IMemberRepository _memberRepository, IProductRepository _productRepository)
        {
            InitializeComponent();
            orderRepository = _orderRepository;
            memberRepository = _memberRepository;
            productRepository = _productRepository;
        }

        private void loadOrderList()
        {
            lvOrders.ItemsSource = orderRepository.getOrderList();
        }

        private void btnMember_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MemberManagement member = new MemberManagement(orderRepository, memberRepository, productRepository);
            member.Show();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ProductManagement product = new ProductManagement(orderRepository, memberRepository, productRepository);
            product.Show();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login login = new Login(memberRepository, orderRepository);
            login.Show();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                loadOrderList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load order list");
            }
        }
        private Order getOrderObject()
        {
            Order order = null;
            try
            {
                order = new Order
                {
                    OrderId = String.IsNullOrEmpty(txtOrderId.Text) ? 0 : int.Parse(txtOrderId.Text),
                    MemberId = int.Parse(txtMemberID.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    RequiredDate = DateTime.Parse(txtRequired.Text),
                    ShippedDate = DateTime.Parse(txtShipped.Text),
                    Freight = decimal.Parse(txtFreight.Text)

                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get order");
            }
            return order;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtMemberID.Text) || String.IsNullOrEmpty(txtOrderDate.Text) || String.IsNullOrEmpty(txtRequired.Text) || String.IsNullOrEmpty(txtShipped.Text)
                || String.IsNullOrEmpty(txtFreight.Text))
                MessageBox.Show("Please fill all information");
            else
            {
                try
                {
                    Order order = getOrderObject();
                    order.OrderId = 0;
                    orderRepository.addNew(order);
                    loadOrderList();
                    MessageBox.Show($"{order.Member} inserted succesfully", "Insert Order");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MemberID not exist,please choose another member id", "Insert order");
                }
            }
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = getOrderObject();
                orderRepository.Update(order);
                loadOrderList();
                MessageBox.Show($"{order.Member} update succesfully", "Update Order");
            }
            catch (Exception ex)
            {
                MessageBox.Show("MemberID not exist,please choose another member id", "Update order");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var Result = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                try
                {
                    Order order = getOrderObject();
                    orderRepository.Remove(order);
                    loadOrderList();
                    MessageBox.Show($"{order.Member} delete succesfully", "Delete Order");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete order");
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                lvOrders.ItemsSource =  orderRepository.getOrderListByDate(DateTime.Parse(txtStart.Text),DateTime.Parse(txtEnd.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
