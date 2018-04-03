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

namespace ToDoListApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int selectedItemIndex;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            if (InputBox.Text != String.Empty)
            {
                TodoListBox.Items.Add(InputBox.Text);
                InputBox.Text = String.Empty;
            }
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            TodoListBox.Items.Remove(TodoListBox.SelectedItem);
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (TodoListBox.SelectedItem != null) {
                CreateButton.Click -= CreateButtonClick;
                CreateButton.Click += UpdateButtonClick;
                CreateButton.Content = "Update";
                InputBox.Text = TodoListBox.SelectedItem.ToString();
                selectedItemIndex = TodoListBox.SelectedIndex;
            }
        }

        private void UpdateButtonClick(object sender, RoutedEventArgs e)
        {
            int index = TodoListBox.SelectedIndex;
            if (index == selectedItemIndex)
            {
                TodoListBox.Items.RemoveAt(index);
                TodoListBox.Items.Insert(index, InputBox.Text);
                CreateButton.Click -= UpdateButtonClick;
                CreateButton.Click += CreateButtonClick;
                CreateButton.Content = "Create";
                InputBox.Text = String.Empty;
            }
        }

    }
}
