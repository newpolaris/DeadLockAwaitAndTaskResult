using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // The get accessor for this property ensures that 
            // the asynchronous operation is complete before returning. 
            // Once the result of the computation is available, it
            // is stored and will be returned immediately on later 
            // calls to Result.
            var htmlString = GetStringAsync(); 
            MessageBox.Show(htmlString.Result); // DEAD LOCK HERE!
        }
    }
}
