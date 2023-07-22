﻿using GeneralStoreManagementSystemGUI.DL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralStoreManagementSystemGUI.UI
{
    public partial class SearchViewControl : UserControl
    {
        public string SearchTerm { get => textBoxSearchTerm.Text; }
        public IEnumerable DataSource
        {
            set => dataGridView.DataSource = value;
        }
        public List<string> HeaderTexts
        {
            set
            {
                if (dataGridView.DataSource != null)
                {
                    for (int i = 0; i < value.Count; i++)
                    {
                        dataGridView.Columns[i].HeaderText = value[i];
                    }
                }
            }
        }
        public DataGridViewColumnCollection Columns
        {
            get
            {
                return dataGridView.Columns;
            }
        }
        public SearchViewControl()
        {
            InitializeComponent();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddEvent?.Invoke(this, null);
        }
        public event EventHandler SearchEvent;
        public event EventHandler AddEvent;
        public event EventHandler RemoveEvent;
        public event EventHandler EditEvent;

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchEvent?.Invoke(this, null);
        }

        private void textBoxSearchTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchEvent?.Invoke(this, null);
            }
        }
    }
}
