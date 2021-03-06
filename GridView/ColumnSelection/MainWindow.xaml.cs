﻿using System;
using System.Linq;
using System.Windows;
using Telerik.Windows.Data;
using System.Collections;
using System.ComponentModel;
using System.Collections.Specialized;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Controls;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.clubsGrid.AddHandler(GridViewHeaderCell.MouseLeftButtonDownEvent, new MouseButtonEventHandler(OnMouseLeftButtonDown), true);
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var clickedElement = e.OriginalSource as FrameworkElement;
            if (clickedElement != null)
            {
                var headerCell = clickedElement.ParentOfType<GridViewHeaderCell>();
                if (headerCell != null)
                {

                    foreach (var item in this.clubsGrid.Items)
                    {
                        var cellInfo = new GridViewCellInfo(item, headerCell.Column, this.clubsGrid);

                        if (!this.clubsGrid.SelectedCells.Contains(cellInfo))
                        {
                            this.clubsGrid.SelectedCells.Add(cellInfo);
                        }
                        else
                        {
                            this.clubsGrid.SelectedCells.Remove(cellInfo);
                        }
                    }

                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var headerCell = (sender as CheckBox).ParentOfType<GridViewHeaderCell>();
            if (headerCell != null)
            {
                foreach (var item in this.clubsGrid2.Items)
                {
                    var cellInfo = new GridViewCellInfo(item, headerCell.Column, this.clubsGrid2);

                    if (!this.clubsGrid2.SelectedCells.Contains(cellInfo))
                    {
                        this.clubsGrid2.SelectedCells.Add(cellInfo);
                    }
                }
            }

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var headerCell = (sender as CheckBox).ParentOfType<GridViewHeaderCell>();
            if (headerCell != null)
            {
                foreach (var item in this.clubsGrid2.Items)
                {
                    var cellInfo = new GridViewCellInfo(item, headerCell.Column, this.clubsGrid2);

                    if (this.clubsGrid2.SelectedCells.Contains(cellInfo))
                    {
                        this.clubsGrid2.SelectedCells.Remove(cellInfo);
                    }
                }
            }
        }
    }
}
