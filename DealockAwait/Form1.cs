using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace DealockAwait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static async Task<string> GetStringAsync()
        {
            const string page = "http://en.wikipedia.org/";

            using (var client = new HttpClient())
            using (var reponse = await client.GetAsync(page))
            using (var content = reponse.Content)
            {
                return await content.ReadAsStringAsync();
            }
        }

        private void DeadLock_Click(object sender, EventArgs e)
        {
            var htmlString = GetStringAsync();
            MessageBox.Show(htmlString.Result);
        }
    }
}
