using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
//using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class AccBase : Papa
    {
        static string connectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = R:\DRM\Access\db2sharp.accdb";
        static OleDbConnection myConnection;

        static void AccessProcess(string query, string ofName, string header)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            string outText = header;
            //textBox1.Text = "wait...";

            OleDbConnection connection = new OleDbConnection(connectString);
            try
            {
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string myLine = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        try
                        {
                            if (i < reader.FieldCount - 1) myLine += reader[i].ToString() + ";";
                            else myLine += reader[i].ToString();

                        }
                        catch { }
                    }
                    outText += myLine + "\n";
                }
                //File.WriteAllText(ofName, outText);
                TextToFile(ofName, outText);
                connection.Close();
                //textBox1.Text = "~ " + ofName;

            }
            catch
            {
                Sos("connect error", query);
                if (connection.State == ConnectionState.Open) { connection.Close(); }
            }
            finally
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
            }
        }


        public static void AccGetTerms()
        {
            string header = "";
            string query = "SELECT * FROM Терминалы ORDER BY termial; ";
            string ofName = "terminals.csv";
            ofName = System.IO.Path.Combine("R:/DRM/Access/Data/InData", ofName);
            AccessProcess(query, ofName, header);
        }

        public static void AccGetDeps()
        {
            string header = "department;region;district_region;district_city;city_type;city;street;street_type;hous;post_index;partner;status;register;edrpou;address;partner_name;id_terminal;koatu;tax_id\n";
            //string query = "SELECT * FROM Отделения WHERE Отделения.partner <> "+ "intime" + "; ";
            string query = "SELECT * FROM DepsNoIntime ORDER BY Отделения.department";
            string ofName = "departments.csv";
            ofName = System.IO.Path.Combine("R:/DRM/Access/Data/InData", ofName);
            AccessProcess(query, ofName, header);
        }

        public static void AccGetAccess()
        {
            string header = "";
            string query = "SELECT * FROM ACCESS ORDER BY department; ";
            string ofName = "access.csv";
            ofName = System.IO.Path.Combine("R:/DRM/Access/Data/InData", ofName);
            AccessProcess(query, ofName, header);
        }

        public static void AccGetVsyo()
        {
            string header = "Терминалы.department;termial;model;serial_number;date_manufacture;soft;producer;rne_rro;sealing;fiscal_number;oro_serial;oro_number;ticket_serial;ticket_1sheet;ticket_number;sending;books_arhiv;tickets_arhiv;to_rro;owner_rro;Отделения.department;region;district_region;city_type;city;district_city;street_type;street;hous;post_index;partner;status;register;edrpou;address;partner name;id_terminal;koatu;tax_id\n";
            string query = "SELECT * FROM vsyoZapros ORDER BY Терминалы.termial;";
            string ofName = "R:/DRM/Access/Data/InData/vsyo_zapros.csv";
            AccessProcess(query, ofName, header);
        }

        public static void AccGetVsyoNewBooks()
        {
            string header = "Терминалы.department;termial;model;serial_number;date_manufacture;soft;producer;rne_rro;sealing;fiscal_number;oro_serial;oro_number;ticket_serial;ticket_1sheet;ticket_number;sending;books_arhiv;tickets_arhiv;to_rro;owner_rro;Отделения.department;region;district_region;city_type;city;district_city;street_type;street;hous;post_index;partner;status;register;edrpou;address;partner name;id_terminal;koatu;tax_id\n";
            string query = "SELECT * FROM vsyoZaprosVneshOtbor ORDER BY Терминалы.termial;";
            string ofName = "R:/DRM/Access/Data/InData/vsyo_zapros_vnesh_otbor.csv";
            AccessProcess(query, ofName, header);
        }

        public static void AccGetAll()
        {
            AccGetTerms();
            AccGetDeps();
            AccGetAccess();
            AccGetVsyo();
        }
    }
}
