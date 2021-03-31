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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<string> agents = new List<string> { "allo", "Делівері Авто", "Джаст Ін", "Сат" };
            listBox1.ItemsSource = agents;

            List<string> peopleList = new List<string> { "priem", "otpusk", "perevod", "postall" };
            listBoxPeople.ItemsSource = peopleList;

            List<string> someList = new List<string> { "site", "term", "natasha" };
            listBoxSome.ItemsSource = someList;

            List<string> monitorList = new List<string> { "accback", "monitor", "rasklad" };
            listBoxMonitor.ItemsSource = monitorList;

            List<string> accessList = new List<string> { "VsyoZapros", "VsyoZaprosOtbor", "accSite" };
            listBoxAccess.ItemsSource = accessList;

            List<string> kabinetList = new List<string> { "knigi", "rro", "pereezd", "otmena" };
            listBoxKabinet.ItemsSource = kabinetList;
        }

        private void ClearMe()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            //textBox3.Text = "";
            //textBoxAgChoise.Text = "";
            Papa.infoBig = "";
            Papa.infoSmall = "";
        }

        private void buttonListBox1_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            textBox1.Text = listBox1.SelectedItem.ToString();
            Papa.partnerChoised = listBox1.SelectedItem.ToString();

            int x = 0;
            try
            {
                x = HrDep.MainHrDep();
                textBox1.Text = listBox1.SelectedItem.ToString() + " ~ " + Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void buttonPeople_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            string choise = listBoxPeople.SelectedItem.ToString();
            switch (choise)
            {
                case "priem":
                    try
                    {
                        int x = Priem.MainPriem();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "otpusk":
                    try
                    {
                        int x = Otpusk.MainOtpusk();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "perevod":
                    try
                    {
                        int x = Perevod.MainPerevod();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "postall":
                    try
                    {
                        int x = PostAll.MainPostAll();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;
            }
                
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
        }

        private void buttonSome_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            string choise = listBoxSome.SelectedItem.ToString();
            switch (choise)
            {
                case "site":
                    try
                    {
                        int x = SiteNew.MainSite();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "term":
                    try
                    {
                        int x = Term.MainTerm();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "natasha":
                    try
                    {
                        int x = Natasha.MainNatasha();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;
            }

        }

        private void buttonMonitor_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            string choise = listBoxSome.SelectedItem.ToString();
            switch (choise)
            {
                case "accback":
                    try
                    {
                        int x = AccBack.MainAccBack();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "monitor":
                    try
                    {
                        int x = Monitor.MainMonitor();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "rasklad":
                    try
                    {
                        int x = Rasklad.MainRasklad();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;
            }
        }

        private void buttonOtbor_Click(object sender, RoutedEventArgs e)
        {
            Otbor.otborChoise = textBox1.Text;
            ClearMe();
            int x = 0;
            try
            {
                x = Otbor.MainOtbor();
                textBox1.Text = "wait... " + Papa.infoSmall;
                textBox2.Text = "wait... " + Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
            try
            {
                x = Zapros.MainZapros();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = "";
            }
            catch { textBox2.Text = "Error"; }
        }

        private void buttonAccess_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            string choise = listBoxAccess.SelectedItem.ToString();
            switch (choise)
            {
                case "VsyoZapros":
                    try
                    {
                        AccBase.AccGetVsyo();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "VsyoZaprosOtbor":
                    try
                    {
                        AccBase.AccGetVsyoNewBooks();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;


                case "accSite":
                    try
                    {
                        AccBase.AccGetAccess();
                        textBox2.Text = "~ " + Papa.infoSmall + "\t\n";

                        SiteNew.MainSite();
                        textBox1.Text = Papa.infoSmall + "\t\n" + Papa.infoBig;
                        textBox2.Text += "\n" + textBox1.Text;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

            }
        }

        private void buttonKabinet_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            string choise = listBoxKabinet.SelectedItem.ToString();
            switch (choise)
            {
                case "knigi":
                    try
                    {
                        int x = Knigi.MainKnigi();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "rro":
                    try
                    {
                        int x = Rro.MainRro();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "pereezd":
                    try
                    {
                        int x = Pereezd.MainPereezd();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;

                case "otmena":
                    try
                    {
                        int x = Otmena.MainOtmena();
                        textBox1.Text = Papa.infoSmall;
                        textBox2.Text = Papa.infoBig;
                    }
                    catch { textBox2.Text = "Error"; }
                    break;
            }
        }
    }
}
