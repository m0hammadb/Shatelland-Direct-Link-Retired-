using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.StringProcessors;
using System.IO;
namespace Links_of_Shatelland
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string LoginCookie = "";
        private string SplitFileName = "split.txt";
        private string DownloadFileName = "dl.txt";
        private string RenameFileName = "rename.txt";
        private string ConstAddress = "https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_92x30dp.png";
        private string LastDownloadedBytes = "";
        private string GetFolderID()
        {

            return (txtFolderID.Text == "" ? "0" : txtFolderID.Text);
        }

        private string CreateFolder(string fName)
        {
            string ret = "";
            WebClient wb = new WebClient();
            string url = "https://shatelland.com/api/ArchiveFolder/";
            string data = "{\"createDate\":null,\"name\":\"%N%\",\"Name\":\"%N%\",\"ArchiveFolderId\":-1,\"archiveFolderParentId\":null,\"ApplicationId\":1,\"ArchiveFolderParentPath\":null,\"ArchiveFolderTypeId\":1,\"CreatedDateUTC\":\"\",\"EntityState\":0,\"OrderId\":0,\"RecordVersion\":null,\"Slug\":\"\",\"UpdatedDateUTC\":\"\",\"UserId\":0,\"ViewState\":0}";
            data = data.Replace("%N%", fName);

            wb.Headers["Cookie"] = LoginCookie;
            wb.Headers["Content-Type"] = "application/json;charset=utf-8";
            string src = wb.UploadString(url, data);
            ret = src.FindBetween("\"ArchiveFolderId\": ", ",");
            return ret;
        }

        private bool IsFileSplitting(string fileName)
        {
            string[] fContent = File.ReadAllLines(SplitFileName);
            foreach (string f in fContent)
            {
                if (f == fileName)
                {
                    return true;
                }
            }
            return false;
        }

        private void AddToRenameFile(string fileID, string fileName)
        {
            string fContent = "<file><id>%ID%</id><name>%NAME%</name></file>\r\n";
            fContent = fContent.Replace("%ID%", fileID);
            fContent = fContent.Replace("%NAME%", fileName);
            File.AppendAllText(RenameFileName, fContent);
        }
        private void AddToSplitFile(string fileName)
        {
            if (!IsFileSplitting(fileName))
            {
                File.AppendAllText(SplitFileName, fileName + "\r\n");
            }
        }

        private bool IsFileDownloading(string fileName)
        {
            string[] fContent = File.ReadAllLines(DownloadFileName);
            foreach (string f in fContent)
            {
                if (f == fileName)
                {
                    return true;
                }
            }
            return false;
        }

        private void AddToDownloadFile(string fileName)
        {
            if (!IsFileDownloading(fileName))
            {
                File.AppendAllText(DownloadFileName, fileName + "\r\n");
                
            }
        }
        private void RemoveSplitFile(string fileName)
        {
            string fContent = File.ReadAllText(SplitFileName);
            fContent = fContent.Replace(fileName + "\r\n", "");
            File.WriteAllText(SplitFileName, fContent);
        }
        private void GetLinks()
        {
            WebClient wb = new WebClient();
            wb.Headers["Cookie"] = LoginCookie;
            string src = wb.DownloadString("https://shatelland.com/api//Archive/GetUserArchiveContext/" + GetFolderID() + "/0");
            string[] spl = src.FindBetweenArray("\"GUID\": \"", "\"");
            foreach (string s in spl)
            {
                string link = "http://shatelland.com/upload/files/" + s;
                bool done = false;
                string dlLink = "";
                while (!done)
                {
                    try
                    {
                        wb = new WebClient();
                        wb.Headers["Cookie"] = LoginCookie;
                        wb.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:63.0) Gecko/20100101 Firefox/63.0";
                        dlLink = wb.DownloadString(link).FindBetween("<a target=\"_blank\" id=\"downloadFile\" href=\"", "\"");
                        wb.Dispose();
                        done = true;
                    }
                    catch (Exception ex)
                    {
                        System.Threading.Thread.Sleep(500);
                    }
                }
                textBox1.Text += dlLink + "\r\n";

            }
        }

        private int SubmitURL(string url)
        {
            int ret = 0;
            WebClient wb = new WebClient();
            wb.Headers["Cookie"] = LoginCookie;
            wb.Headers["Content-Type"] = "application/json";
            string pData = string.Format("{{\"Url\":\"{0}\",\"ConnectionId\":\"\",\"FolderId\":" + GetFolderID() + "}}", url);
            try
            {
                wb.UploadString("https://dl4.shatelland.com/api/Leech", pData);
                ret = 1;
            }
            catch (Exception ex)
            {
                ret = -1;
            }



            return ret;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoginCookie = "_ga=GA1.2.651577199.1562153878; authv4=9548BAD5641A3C9042A8960F96F743F90FDF7C051C94FBBD85B57CE66F16B868DC189D90CB7E571F50F5CBA62C8A33A635F4E0C44D04C306A74264704BECA7D4A8145B1D6489DB22825DF932F8A55EC59767477FC037AE17717B9A304809950C3A8E3EEA9052514E71386E5E7C4C4CDFE10516B0C829B928840C6D65067E6B8EAEDBEE4B2901DF9D34023BA77BAD65E9DF23842E617D3047534628581E5821E2B317A01F5B0A5B031CF67F48DB456D5820123BB7E0C77D67877A9D5D1D82732F3501C44A0ADCF8B00AD97E203448FAE5C2C748A117AA08ACEBF22B65028D7C794BD55FD569E3D3153F43ECB4CD1D6BBA; analytics_campaign={%22source%22:%22direct%22%2C%22medium%22:null}; analytics_token=88a71f07-379c-7e79-98d2-2e3e385404a2; _gat=1";
            if (!File.Exists(SplitFileName))
            {
                File.WriteAllText(SplitFileName, "");
            }
            if (!File.Exists(DownloadFileName))
            {
                File.WriteAllText(DownloadFileName, "");
            }
            txtFolderName.Text = "Folder" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            txtFolderID.Text = CreateFolder(txtFolderName.Text);
            button4.Enabled = false;

        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetLinks();
        }

        private void CancelDownload()
        {
            string cancelUrl = "https://dl4.shatelland.com/api/LeechManager/currentuser/cancel";
            WebClient wb = new WebClient();
            wb.Headers["Cookie"] = LoginCookie;
            wb.DownloadString(cancelUrl);
        }
        private int GetPercentage(out string bytesDownloaded)
        {
            try
            {
                WebClient wb = new WebClient();
                wb.Headers["Cookie"] = LoginCookie;
                string response = wb.DownloadString("https://dl4.shatelland.com/api/LeechManager/currentuser");
                if (response == "null")
                {
                    bytesDownloaded = "-1";
                    return -1;
                }
                else
                {
                    string strPerc = response.FindBetween("\"Percentage\":", ",");
                    string strByteDownloaded = response.FindBetween("\"Position\":", ",");
                    bytesDownloaded = strByteDownloaded;
                    int perc = 0;
                    if (strPerc.ToLower() != "\"nan\"")
                    {
                        perc = (int)float.Parse(strPerc);
                    }
                    return perc;
                }
            }
            catch(Exception ex)
            {
                bytesDownloaded = "0";
                return 0;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            int uploaded = 0;
            string[] spl = textBox2.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in spl)
            {
                if(!IsFileDownloading(s))
                {
                    AllUrlsToDownload.Add(s);
                    AddToDownloadFile(s);
                    File.AppendAllText("dlList.txt", s + Environment.NewLine);
                }
            }
            textBox2.Text = "";
            timer3.Start();
        }
        List<string> AllCheckIDs = new List<string>();
        private void button3_Click(object sender, EventArgs e)
        {
            string[] spl = txtURL.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string u in spl)
            {
                this.Text = "Submitting " + u;
                string c = UploadParsa(u);
                AllCheckIDs.Add(c);
            }
            tmrChecker.Start();
            //CheckParsa(c);
        }

        private string GenerateCheckID(int count)
        {
            string ret = "";
            string all = "0123456789";
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                ret += all[r.Next(0, all.Length - 1)];
            }
            return ret;
        }

        private string UploadParsa(string url)
        {
            string ret = "";
            string token = txtToken.Text;
            string checkID = GenerateCheckID(9);
            WebClient wb = new WebClient();
            wb.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            wb.Headers["Authorization"] = "Bearer " + token;
            string pData = string.Format("checkid={0}&url={1}&domain=downloaderx.parsaspace.com", checkID, url);
            string src = wb.UploadString("http://api.parsaspace.com/v1/remote/new", pData);
            return checkID;
        }

        private string CheckParsa(string checkID)
        {
            string ret = "";
            WebClient wb = new WebClient();
            string token = txtToken.Text;
            wb.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            wb.Headers["Authorization"] = "Bearer " + token;
            string pData = string.Format("checkid={0}", checkID);
            string src = wb.UploadString("http://api.parsaspace.com/v1/remote/status", pData);
            if (src.Contains("\"Status\":\"Complete\""))
            {
                ret = src.FindBetween("\"FileName\":\"", "\"");
            }
            return ret;
        }

        private List<string> AllURLs = new List<string>();
        private void tmrChecker_Tick(object sender, EventArgs e)
        {
            if (AllCheckIDs.Count == 0)
                tmrChecker.Enabled = false;
            else
            {
                for (int i = 0; i < AllCheckIDs.Count; i++)
                {
                    string cID = AllCheckIDs[i];
                    this.Text = "Checking Parsaspace File : " + cID;
                    string c = CheckParsa(cID);
                    if (c != "")
                    {
                        AllCheckIDs.RemoveAt(i);
                        i--;
                        textBox2.Text += "http://myuploader.parsaspace.com/" + c + Environment.NewLine;
                        AllURLs.Add("http://myuploader.parsaspace.com/" + c);
                        tmrShatel.Start();
                    }
                }
            }
        }

        private void tmrShatel_Tick(object sender, EventArgs e)
        {
            tmrShatel.Interval = 7000;
            if (AllURLs.Count == 0)
                tmrShatel.Stop();
            else
            {
                this.Text = "Checking Shatel...";
                for (int i = 0; i < AllURLs.Count; i++)
                {
                    string c = AllURLs[i];
                    int x = SubmitURL(c);
                    if (x == 1)
                    {
                        this.Text = "Shatel Submitted! :D";
                        AllURLs.RemoveAt(i);
                        i--;
                        textBox2.Text = textBox2.Text.Replace(c + Environment.NewLine, "");
                    }

                    else
                    {
                        this.Text = "Shatel is busy";
                        break;

                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {

            }
        }

        private bool IsFileBig(string fileAddress)
        {
            try
            {
                System.Net.WebClient client = new System.Net.WebClient();
               Stream stream =  client.OpenRead(fileAddress);
                Int64 bytes_total = Convert.ToInt64(client.ResponseHeaders["Content-Length"]);
                stream.Dispose();
                bytes_total /= (1024 * 1024);
                if (bytes_total > 1500)
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                System.Net.WebClient client = new System.Net.WebClient();
                client.OpenRead(fileAddress);
                Int64 bytes_total = Convert.ToInt64(client.ResponseHeaders["Content-Length"]);
                bytes_total /= (1024 * 1024);
                if (bytes_total > 1500)
                    return true;
                else
                    return false;
            }
        }

        private void CheckForSplits()
        {
            WebClient wb = new WebClient();
            wb.Headers["Cookie"] = txtTorrentCookie.Text;
            string src = wb.DownloadString("http://panel.bitso.ir/user/my-files");
            string[] spl = src.FindBetweenArray("href=\"", "</a>");
            foreach (string s in spl)
            {
                if (!s.Contains("</span>") && (s.Contains("/user/my-files?id=")))
                {
                    string link = "";
                    string name = "";
                    string fileID = "";
                    name = s.FindEverthingFrom(">");
                    if (s.Contains("/user/my-files"))
                    {

                        link = "http://panel.bitso.ir" + s.FindEverythingPriorTo("\"");
                        fileID = link.FindEverthingFrom("my-files?id=");
                    }

                    if (name.Contains("-splitted"))
                    {
                        if(IsFileSplitting(name.Replace("-splitted","")))
                        {
                            ProcessTorrentList(link);
                        }
                    }
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ProcessTorrentList("http://panel.bitso.ir/index");
            
        }

        private void DeleteAll(string TAddress)
        {
            WebClient wb = new WebClient();
            int splitCount = 0;
            wb.Headers["Cookie"] = txtTorrentCookie.Text;
            string src = wb.DownloadString(TAddress);
            int errors = 0;
            string[] spl = src.FindBetweenArray("href=\"", "</a>");
            foreach (string s in spl)
            {
                if (!s.Contains("</span>") && (s.Contains("/user/my-files?id=") || s.Contains("bitso.ir/dnl/")))
                {
                    string link = "";
                    string name = "";
                    string fileID = "";
                    name = s.FindEverthingFrom(">");
                    if (s.Contains("/user/my-files"))
                    {

                        link = "http://panel.bitso.ir" + s.FindEverythingPriorTo("\"");
                        fileID = link.FindEverthingFrom("my-files?id=");
                    }
                    else
                    {
                        link = s.FindEverythingPriorTo("\"");
                        fileID = link.FindEverthingFrom("/dnl/");
                       
                    }

                    string delLink = "http://panel.bitso.ir/user/file-delete?id=" + fileID;
                    try
                    {
                        string s2 = wb.DownloadString(delLink);
                    }
                    catch(Exception ex)
                    {
                        errors++;
                        this.Text = "Errors " + errors;
                    }
                   // wb.Dispose();
                    
                }
            }
        }

        private void ProcessTorrentList(string TAddress)
        {
            WebClient wb = new WebClient();
            int splitCount = 0;
            wb.Headers["Cookie"] = txtTorrentCookie.Text;
            string src = wb.DownloadString(TAddress);
            string[] spl = src.FindBetweenArray("href=\"", "</a>");
            foreach (string s in spl)
            {
                if (!s.Contains("</span>") && (s.Contains("/user/my-files?id=") || s.Contains("bitso.ir/dnl/")))
                {
                    string link = "";
                    string name = "";
                    bool split = false;
                    string fileID = "";
                    name = s.FindEverthingFrom(">");
                    if (s.Contains("/user/my-files"))
                    {

                        link = "http://panel.bitso.ir" + s.FindEverythingPriorTo("\"");
                        fileID = link.FindEverthingFrom("my-files?id=");
                        split = true;
                    }
                    else
                    {
                        link = s.FindEverythingPriorTo("\"");
                        fileID = link.FindEverthingFrom("/dnl/");
                        if (IsFileBig(link))
                        {
                            split = true;
                        }
                    }


                    if (split && !(name.Contains("-splitted")))
                    {
                        if (!IsFileSplitting(name))
                        {
                            
                            splitCount++;
                            this.Text = splitCount + " Files went for splitting...";
                            wb.Headers["Content-Type"] = "application/x-www-form-urlencoded";
                         string src2=   wb.UploadString("http://panel.bitso.ir/user/rar?id=" + fileID, "splitSize=1000M&file_id=" + fileID);
                         AddToSplitFile(name);

                        }
                    }
                    else if (!split)
                    {
                        if (!IsFileDownloading(link))
                        {
                            AddToRenameFile(fileID, name);
                            textBox2.Text += link + "\r\n";
                        }
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            CheckForSplits();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //To do
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(txtRenameDirectory.Text);
            string [] fContent = File.ReadAllLines(RenameFileName);
            foreach(string f in files)
            {
                FileInfo fi = new FileInfo(f);
                string fileName = fi.Name;
                string directory = fi.Directory.FullName;
               foreach(string cc in fContent)
               {
                   string id = cc.FindBetween("<id>", "</id>");
                   string name = cc.FindBetween("<name>", "</name>");
                   
                   if(fileName == id)
                   {
                       File.Move(f, directory + "\\" + name.Replace(":",""));
                       break;
                   }
               }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CheckForSplits();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure","Caution",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                DeleteAll("http://panel.bitso.ir/index");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SubmitURL("http://138.201.104.130:8080/1/HM/ccPart1.part161.rar");
        }
        List<string> AllUrlsToDownload = new List<string>();
        string CurrentLink = "";
        int LastPercent = 0;
        int NoProgressCount = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            string bytesDownloaded = "";
            int perc = GetPercentage(out bytesDownloaded);
            if(perc == -1)
            {
                //free
                if (AllUrlsToDownload.Count > 0)
                {
                    LastPercent = 0;
                    SubmitURL(AllUrlsToDownload[0]);
                    CurrentLink = AllUrlsToDownload[0];
                    AllUrlsToDownload.RemoveAt(0);
                }
                else
                {
                    timer3.Stop();
                    this.Text = "Finished";
                }
            }
            else
            {
                if(LastDownloadedBytes != bytesDownloaded)
                {
                    LastDownloadedBytes = bytesDownloaded;
                    NoProgressCount = 0;
                }
                else
                {
                    NoProgressCount++;
                    if(NoProgressCount >= 10)
                    {
                        NoProgressCount = 0;
                        CancelDownload();
                        AllUrlsToDownload.Add(CurrentLink);
                        return;
                    }
                }
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                progressBar1.Value = perc;
                int progress = perc - LastPercent;
                LastPercent = perc;
                long s = long.Parse(bytesDownloaded);
                s = s / (1024 * 1024);
                this.Text = "Remaining Files: " + AllUrlsToDownload.Count + " / Progress: " + progress + "%" + " / Downloaded: " + s + " MB";
            }


        }
    }
}
