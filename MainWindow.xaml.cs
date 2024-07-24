using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp
{
  
    public partial class MainWindow : Window
    {
        private ObservableCollection<ListItem> items;
            
        public MainWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<ListItem>();
            todolist.ItemsSource = items;
        }
        public class ListItem
        {
            public int STT { get; set; }
            public string Content { get; set; }
        }
        

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(todotxb.Text))
            {
                // đánh stt
                int nextSTT = items.Any() ? items.Max(i => i.STT) + 1 : 1;

                // cho dữ liwwju vào danh sách
                items.Add(new ListItem
                {
                    STT = nextSTT,
                    Content = todotxb.Text
                });

                // xóa sau khi nhập
                todotxb.Clear();
            }
            else
            {
                MessageBox.Show("Hãy nhập việc muốn làm !");
            }
        }

        private void delbtn_Click(object sender, RoutedEventArgs e)
        {
            if (todolist.SelectedItem != null)
            {
                var selectedItem = todolist.SelectedItem as ListItem;
                items.Remove(selectedItem);
                UpdateSTT();
            }
            else
            {
                MessageBox.Show("Chọn dòng cần xóa !");
            }

        }
        private void UpdateSTT()
        {
            int stt = 1;
            foreach (var item in items)
            {
                item.STT = stt++;
            }
            todolist.ItemsSource = null;
            todolist.ItemsSource = items;
        }

    }
}
