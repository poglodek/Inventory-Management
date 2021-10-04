﻿using System;
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
using Inventory_Management.ViewModel;

namespace Inventory_Management.View
{
    /// <summary>
    /// Interaction logic for MyData.xaml
    /// </summary>
    public partial class MyData : UserControl
    {
        public MyData()
        {
            InitializeComponent();
            DataContext = new MyDataViewModel();
        }
    }
}
