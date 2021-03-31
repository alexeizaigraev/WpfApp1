using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class SiteNew : PapaSome
    {
        private static List<string> natasha = MkNatasha();

        public static int MainSite()
        {
            string outFileName = Path.Combine(dataOutPath, "OutSite.csv");
            string outFileNamePhp = Path.Combine(dataOutPath, "page-departments.php");

            Dictionary<string, string> regimes = FileToDict(4);
            var access = FileToArr(dataInPath + "access.csv");
            if (exitStatus) goto LabelExit;

            string header = "Найменування відокремленного підрозділу та ПНФП;Адреса;Дата та номер рішення про створення;ЄДРПОУ;Режим роботи;Платежі приймаються в Платіжній системі;Платежі виплачуються  в Платіжній системі\n";
            string outTextClear = header;
            string outTextPhp = "";

            foreach (string[] accessLine in access)
            {
                try
                {
                    //if (accessLine[0].IndexOf("2(Веб-сайт-ПТКС)") > -1) { continue; }

                    string dep = "";
                    if (accessLine[0].IndexOf("№") > -1) { dep = accessLine[0].Split('№')[1]; }
                    else { dep = accessLine[0]; }

                    string regime = "Не працює";
                    if ((dep.Length > 2) && (natasha.IndexOf(dep) > -1))
                    {
                        try
                        {
                            string agSign = dep.Substring(0, 3);
                            regime = regimes[agSign];
                        }
                        catch { }
                    }

                    if (dep == "1") regime = "ПН-ПТ 09:00-18:00";

                    string edr = "";
                    if ("" != accessLine[1]) edr = accessLine[1];

                    string linePhp;
                    string line;

                    if (edr != "")
                    {
                        linePhp = String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>ВПС ЕЛЕКТРУМ</td><td>ВПС FLASHPAY, ВПС ЕЛЕКТРУМ</td></tr>", "Відділення №" + accessLine[0], accessLine[2], accessLine[3], edr, regime);
                        line = String.Format("{0};{1};{2};{3};{4};ВПС ЕЛЕКТРУМ;ВПС FLASHPAY, ВПС ЕЛЕКТРУМ", "Відділення №" + accessLine[0], accessLine[2], accessLine[3], edr, regime);
                    }
                    else
                    {
                        linePhp = String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>ВПС ЕЛЕКТРУМ</td><td>ВПС FLASHPAY, ВПС ЕЛЕКТРУМ</td></tr>", "ПНФП Відділення №" + accessLine[0], accessLine[2], accessLine[3], edr, regime);
                        line = String.Format("{0};{1};{2};{3};{4};ВПС ЕЛЕКТРУМ;ВПС FLASHPAY, ВПС ЕЛЕКТРУМ", "ПНФП Відділення №" + accessLine[0], accessLine[2], accessLine[3], edr, regime);
                    }

                    outTextPhp += linePhp + "\n";
                    outTextClear += line + "\n";
                }
                catch
                {

                }

            }

            var siteOld = FileToText(dataOutPath + "OutSite.csv");
            if (siteOld == outTextClear) { infoSmall = " No change ! \n" + infoSmall; }

            TextToFile(outFileName, outTextClear);
            if (exitStatus) goto LabelExit;

            string textPhp = outTextPhp;
            string text1 = FileToText("Config/SiteText1.txt");
            if (exitStatus) goto LabelExit;
            string text2 = FileToText("Config/SiteText2.txt");
            if (exitStatus) goto LabelExit;
            string fullTextPhp = text1 + textPhp + text2;
            TextToFile(outFileNamePhp, fullTextPhp);
            if (exitStatus) goto LabelExit;

            TextToFile(outFileName, outTextClear);
            if (exitStatus) goto LabelExit;

            return 0;

        LabelExit:
            return 1;
        }


    }
}
