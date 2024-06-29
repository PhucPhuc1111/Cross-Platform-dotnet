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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MemberManagement.xaml
    /// </summary>
    public partial class MemberManagement : Window
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMemberRepository memberRepository;
        private readonly IProductRepository productRepository;
        public MemberManagement(IOrderRepository _orderRepository, IMemberRepository _memberRepository, IProductRepository _productRepository)
        {
            InitializeComponent();
            orderRepository = _orderRepository;
            memberRepository = _memberRepository;
            productRepository = _productRepository;
        }

        private void loadMemberList()
        {
            lvMembers.ItemsSource = memberRepository.getMemberList();
        }


        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                loadMemberList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }
        private Member getMemberObject()
        {
            Member member = null;
            try
            {
                member = new Member
                {
                    MemberId = String.IsNullOrEmpty(txtMemberId.Text) ? 0 : int.Parse(txtMemberId.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCompany.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text

                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get product");
            }
            return member;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = getMemberObject();
                member.MemberId = 0;
                memberRepository.addNew(member);
                loadMemberList();
                MessageBox.Show($"{member.Email} inserted succesfully", "Insert Member");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert member");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = getMemberObject();
                memberRepository.Update(member);
                loadMemberList();
                MessageBox.Show($"{member.Email} update succesfully", "Update Member");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update member");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var Result = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                try
                {
                    Member member = getMemberObject();
                    memberRepository.Remove(member);
                    loadMemberList();
                    MessageBox.Show($"{member.Email} delete succesfully", "Delete Member");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete member");
                }
            }
        }

        private void btnMember_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ProductManagement product = new ProductManagement(orderRepository, memberRepository, productRepository);
            product.Show();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            OrderManagement order = new OrderManagement(orderRepository, memberRepository, productRepository);
            order.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login login = new Login(productRepository, memberRepository, orderRepository);
            login.Show();
        }
    }
}
