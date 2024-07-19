using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfApp.View
{
    public class MainViewModel 
    {

        public MainViewModel() { }


        public void saveFileToPdf()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF (*.pdf)|*.pdf";

            save.FileName = "Bill.pdf";

            bool ErrorMessage = false;
        }
    }
}
