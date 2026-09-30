using System;
using System.Collections.Generic;
using System.Windows;

namespace TheCompany
{
    // Class Item bertanggung jawab untuk menyimpan state dan kalkulasi subtotal per item[cite: 2]
    public class Item
    {
        private int id;
        public string title { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double subtotal { get; set; }
        private string type;

        public Item(int id, string title, int quantity, string type, double price)
        {
            this.id = id;
            this.title = title;
            this.quantity = quantity;
            this.type = type;
            this.price = price;
            this.subtotal = quantity * price;
        }

        public string getTitle() { return title; }
        public int getQuantity() { return quantity; }
        public string getType() { return type; }
        public double getPrice() { return price; }

        public double getSubTotal()
        {
            subtotal = price * quantity;
            return subtotal;
        }
    }

    // Class Calculator bertanggung jawab mengatur list item dan kalkulasi total keseluruhan[cite: 2]
    public class Calculator
    {
        private List<Item> listitem;
        private double total = 0;

        public Calculator()
        {
            listitem = new List<Item>();
        }

        public void addItem(Item item)
        {
            listitem.Add(item);
            total += item.getSubTotal();
        }

        public double getTotal()
        {
            return total;
        }

        public List<Item> getListItem()
        {
            return listitem;
        }
    }

    // Logika UI dan event handler pada Window[cite: 3]
    public partial class MainWindow : Window
    {
        private Calculator calculator;

        public MainWindow()
        {
            InitializeComponent();
            calculator = new Calculator();
            listBox.ItemsSource = calculator.getListItem();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string title = itemNameBox.Text;
            int quantity = int.Parse(quantityBox.Text);
            string type = typeBox.Text;
            double price = double.Parse(priceBox.Text);

            Item item = new Item(new Random().Next(), title, quantity, type, price);
            calculator.addItem(item);
            double total = calculator.getTotal();

            totalLabel.Content = string.Format("Rp. {0}", total);
            listBox.Items.Refresh();
        }
    }
}