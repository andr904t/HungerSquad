using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CmlLib.Core;
using CmlLib.Core.Auth;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Net;
using KeyAuth;
using Microsoft.VisualBasic;
using System;
using System.Text;
using System.Globalization;
using System.Net.NetworkInformation;


using System;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

using System;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using System.Collections.Generic;

using System.Management;
using System.Management.Instrumentation;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;


namespace HungerSquad
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public Point mouseLocation;
        public Form1()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            InitializeComponent();
            KeyAuthApp.init();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        public static api KeyAuthApp = new api(
            name: "hungersquad", // App name
            ownerid: "jssf7lsfP3", // Account ID
            version: "1.0" // Application version. Used for automatic downloads see video here https://www.youtube.com/watch?v=kW195PLCBKs
            //path: @"Your_Path_Here" // (OPTIONAL) see tutorial here https://www.youtube.com/watch?v=I9rxt821gMk&t=1s
        );



        static void ReadJson(string jsonFileIn)
        {

            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(jsonFileIn));

            if (jsonFile["first_launch"] == false) ;
            {
                bool first_launch = false;
            }

            if (jsonFile["first_launch"] == true) ;
            {
                bool first_launch = true;
            }

            Console.WriteLine($"{jsonFile["first_launch"]}");

        }

        private void WaitNSeconds(int segundos)
        {
            if (segundos < 1) return;
            DateTime _desired = DateTime.Now.AddSeconds(segundos);
            while (DateTime.Now < _desired)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }

        private void mouse_Down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouse_Move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //File.Delete(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/HungerSquad 1.0.jar"));
            //File.Delete(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/LabyMod-3-1.8.9.jar"));
            //File.Delete(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/OptiFine_1.8.9_HD_U_M5.jar"));
            //File.Delete("HungerSquad 1.0.jar");
            //File.Delete("LabyMod-3-1.8.9.jar");
            //File.Delete("OptiFine_1.8.9_HD_U_M5.jar");
            File.Delete(Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//temp_login.json"));

            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void select_version(string version)
        {
            panel10.Hide();
            panel17.Show();
            if (version == "Standard")
            {
                if (KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == "Standard"))
                {
                    label39.Text = "Standard";
                    label17.Text = "HungerSquad Standard 1.0 (Not Available)";
                    label5.Font = new Font(label5.Font, FontStyle.Bold);
                    label3.Font = new Font(label3.Font, FontStyle.Regular);
                    label4.Font = new Font(label4.Font, FontStyle.Regular);

                    label6.Font = new Font(label4.Font, FontStyle.Regular);
                }
                else if (KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == "Developer"))
                {
                    label39.Text = "Standard";
                    label17.Text = "HungerSquad Standard 1.0 (Not Available)";
                    label5.Font = new Font(label5.Font, FontStyle.Bold);
                    label3.Font = new Font(label3.Font, FontStyle.Regular);
                    label4.Font = new Font(label4.Font, FontStyle.Regular);

                    label6.Font = new Font(label4.Font, FontStyle.Regular);
                }
            }


            if (version == "Beta")
            {
                if (KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == "Beta Tester"))
                {
                    label39.Text = "Beta";
                    label17.Text = "HungerSquad Beta 1.3";
                    label5.Font = new Font(label5.Font, FontStyle.Regular);
                    label3.Font = new Font(label3.Font, FontStyle.Bold);
                    label4.Font = new Font(label4.Font, FontStyle.Regular);

                    label6.Font = new Font(label4.Font, FontStyle.Regular);
                }
                else if (KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == "Developer"))
                {
                    label39.Text = "Beta";
                    label17.Text = "HungerSquad Beta 1.3";
                    label5.Font = new Font(label5.Font, FontStyle.Regular);
                    label3.Font = new Font(label3.Font, FontStyle.Bold);
                    label4.Font = new Font(label4.Font, FontStyle.Regular);

                    label6.Font = new Font(label4.Font, FontStyle.Regular);
                }
            }


            if (version == "Developer")
            {
                if (KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == "Developer"))
                {
                    label39.Text = "Developer";
                    label17.Text = "HungerSquad Dev 1.0";
                    label5.Font = new Font(label5.Font, FontStyle.Regular);
                    label3.Font = new Font(label3.Font, FontStyle.Regular);
                    label4.Font = new Font(label4.Font, FontStyle.Bold);

                    label6.Font = new Font(label4.Font, FontStyle.Regular);
                }
            }
        }



                //            HungerSquad Version


        private void panel5_Click(object sender, EventArgs e)
        {
            select_version("Standard");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            select_version("Standard");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            select_version("Standard");
        }


        //            Developer Version


        private void panel4_Click(object sender, EventArgs e)
        {
            select_version("Developer");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            select_version("Developer");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            select_version("Developer");
        }


        //            Beta Tester Version


        private void panel3_Click(object sender, EventArgs e)
        {
            select_version("Beta");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            select_version("Beta");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            select_version("Beta");
        }


        //                                                                                         \\


        private void button4_Click(object sender, EventArgs e)
        {
            //DownloadForge();
            //LaunchMinecraftForge();
            //StartMinecraftAsync();

            ReadJson("C:/Users/veste/OneDrive/Skrivebord/hs_settings.json");

            StartMinecraftAsync();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartObject();
                writer.WritePropertyName("hide_on_start");
                writer.WriteValue("false");
                writer.WritePropertyName("ram_allocated");
                writer.WriteValue("1024");
                writer.WritePropertyName("first_launch");
                writer.WriteValue("false");
                writer.WriteEndObject();
            }

            File.WriteAllText(@"C:/Users/Daniel/Desktop/hs_settings.json", sb.ToString());

        }




        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Silver;
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "License")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Silver;
            }
        }


        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.FromArgb(70, 70, 70);
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.PasswordChar = '\0';
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.FromArgb(70, 70, 70);
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "License";
                textBox3.ForeColor = Color.FromArgb(70, 70, 70);
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

            panel1.Hide();
            panel2.Hide();
            panel6.Hide();
            panel10.Hide();

            label2.Hide();
            pictureBox15.Hide();

            if (Directory.Exists(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/versions/1.8.9-forge1.8.9-11.15.1.2318-1.8.9")))
            {
                button4.Text = "Launch";
            }
            else
            {
                button4.Text = "Install";
            }




            var memory = 0.0;
            using (Process proc = Process.GetCurrentProcess())
            {
                memory = proc.PrivateMemorySize64 / 1024 / 1000;
            }

            siticoneTrackBar1.Maximum = 16;

            load_settings();

            this.Size = new Size(384, 461);

            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

            label9.Text = KeyAuthApp.app_data.numOnlineUsers;
            label10.Text = "v " + KeyAuthApp.app_data.version;

            if (File.Exists(Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//HungerSquad//login.json")))
            {
                long length = new System.IO.FileInfo(Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//HungerSquad//login.json")).Length;

                if (length == 0)
                {
                    MessageBox.Show("Failed to auto-login. Please log in again.");
                    File.Delete(Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//HungerSquad//login.json"));
                    return;
                }

                dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//HungerSquad//login.json")));

                if (jsonFile["username"] != "")
                {
                    if (jsonFile["password"] != "") ;
                    {
                        string username;
                        string password;

                        username = jsonFile["username"];
                        password = jsonFile["password"];

                        WaitNSeconds(1);

                        textBox1.ForeColor = Color.Silver;
                        textBox2.ForeColor = Color.Silver;

                        textBox1.Text = username;
                        textBox2.PasswordChar = '*';
                        textBox2.Text = password;

                        label2.Show();
                        pictureBox15.Show();
                        WaitNSeconds(3);

                        KeyAuthApp.login(username, password);
                        if (KeyAuthApp.response.success)

                        {
                            panel1.Show();
                            panel2.Show();
                            panel6.Show();

                            panel8.Hide();
                            panel9.Hide();

                            label1.Text = KeyAuthApp.user_data.username;
                            label11.Text = KeyAuthApp.user_data.subscriptions[0].subscription;

                            this.Size = new Size(984, 611);

                            this.FormBorderStyle = FormBorderStyle.None;
                            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));


                            if (KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == "Standard"))
                            {
                                label39.Text = "Standard";
                                label5.Font = new Font(label5.Font, FontStyle.Bold);
                                this.pictureBox6.Image = global::HungerSquad.Properties.Resources.HungerSquad_Png_40x;
                                this.pictureBox4.Image = global::HungerSquad.Properties.Resources.BetaLock;
                                this.pictureBox5.Image = global::HungerSquad.Properties.Resources.DevLock;
                            }
                            else if (KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == "Beta Tester"))
                            {
                                label39.Text = "Beta";
                                label17.Text = "HungerSquad Beta 1.3";
                                label3.Font = new Font(label3.Font, FontStyle.Bold);
                                this.pictureBox6.Image = global::HungerSquad.Properties.Resources.HungerSquadLock;
                                this.pictureBox4.Image = global::HungerSquad.Properties.Resources.Beta;
                                this.pictureBox5.Image = global::HungerSquad.Properties.Resources.DevLock;
                            }
                            else if (KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == "Developer"))
                            {
                                label39.Text = "Developer";
                                label17.Text = "HungerSquad Dev 1.0";
                                label4.Font = new Font(label4.Font, FontStyle.Bold);
                                this.pictureBox6.Image = global::HungerSquad.Properties.Resources.HungerSquad_Png_40x;
                                this.pictureBox4.Image = global::HungerSquad.Properties.Resources.Beta;
                                this.pictureBox5.Image = global::HungerSquad.Properties.Resources.DevNew;
                            }

                            label2.Hide();
                            pictureBox15.Hide();

                            MessageBox.Show("Logged In As: " + KeyAuthApp.user_data.username + ".", "Login Success!");
                        }

                        else
                        {
                            label2.Hide();
                            pictureBox15.Hide();

                            MessageBox.Show("Failed to auto-login. Please log in again.");
                            File.Delete(Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//HungerSquad//login.json"));
                        }
                    }
                }
                else
                {
                    label2.Hide();
                    pictureBox15.Hide();

                    MessageBox.Show("Failed to auto-login. Please log in again.");
                    File.Delete(Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//HungerSquad//login.json"));
                }
            }
            else
            {
                if (File.Exists(Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//HungerSquad")))
                {
                    string path = Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//HungerSquad//login.json");
                    FileStream a = File.Create(path);

                    a.Close();
                }
                else
                {
                    string path = Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//HungerSquad");
                    System.IO.Directory.CreateDirectory("HungerSquad");
                    try
                    {
                        Directory.Move(@"HungerSquad", Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//HungerSquad"));
                    }
                    catch (IOException exp)
                    {
                        Console.WriteLine(exp.Message);
                    }
                    string path2 = Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//HungerSquad//login.json");
                    FileStream a = File.Create(path2);

                    a.Close();
                }
            }
        }


        private void pictureBox12_Click(object sender, EventArgs e)
        {
            File.Delete(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/HungerSquad 1.0.jar"));
            File.Delete(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/LabyMod-3-1.8.9.jar"));
            File.Delete(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/OptiFine_1.8.9_HD_U_M5.jar"));
            File.Delete("HungerSquad 1.0.jar");
            File.Delete("LabyMod-3-1.8.9.jar");
            File.Delete("OptiFine_1.8.9_HD_U_M5.jar");
            File.Delete(Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//temp_login.json"));

            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel8_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            textBox1.SelectionLength = 0;
        }
        private void textBox2_MouseMove(object sender, MouseEventArgs e)
        {
            textBox2.SelectionLength = 0;
        }
        private void textBox3_MouseMove(object sender, MouseEventArgs e)
        {
            textBox3.SelectionLength = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string username;
            string password;

            username = textBox1.Text;
            password = textBox2.Text;

            label2.Show();
            pictureBox15.Show();

            WaitNSeconds(3);

            KeyAuthApp.login(username, password);
            if (KeyAuthApp.response.success)

            {
                JObject login = new JObject(
                    new JProperty("username", username),
                    new JProperty("password", password));


                File.Delete(Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//HungerSquad//login.json"));

                string path2 = Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//HungerSquad//login.json");
                FileStream a = File.Create(path2);

                a.Close();

                File.WriteAllText(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/HungerSquad/login.json"), login.ToString());


                panel1.Show();
                panel2.Show();
                panel6.Show();

                panel8.Hide();
                panel9.Hide();

                label1.Text = KeyAuthApp.user_data.username;
                label11.Text = KeyAuthApp.user_data.subscriptions[0].subscription;

                this.Size = new Size(984, 611);

                this.FormBorderStyle = FormBorderStyle.None;
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));


                if (KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == "Standard"))
                {
                    this.pictureBox6.Image = global::HungerSquad.Properties.Resources.HungerSquad_Png_40x;
                    this.pictureBox4.Image = global::HungerSquad.Properties.Resources.BetaLock;
                    this.pictureBox5.Image = global::HungerSquad.Properties.Resources.DevLock;
                }
                else if (KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == "Beta Tester"))
                {
                    this.pictureBox6.Image = global::HungerSquad.Properties.Resources.HungerSquadLock;
                    this.pictureBox4.Image = global::HungerSquad.Properties.Resources.Beta;
                    this.pictureBox5.Image = global::HungerSquad.Properties.Resources.DevLock;
                }
                else if (KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == "Developer"))
                {
                    this.pictureBox6.Image = global::HungerSquad.Properties.Resources.HungerSquad_Png_40x;
                    this.pictureBox4.Image = global::HungerSquad.Properties.Resources.Beta;
                    this.pictureBox5.Image = global::HungerSquad.Properties.Resources.DevNew;
                }

                label2.Hide();
                pictureBox15.Hide();
                MessageBox.Show("Logged In As: " + KeyAuthApp.user_data.username + ".", "Login Success!");
            }
            else
            {
                label2.Hide();
                pictureBox15.Hide();
                MessageBox.Show("Error: " + KeyAuthApp.response.message, "Error");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string username;
            string password;
            string license;

            username = textBox1.Text;
            password = textBox2.Text;
            license = textBox3.Text;

            label2.Show();
            pictureBox15.Show();

            WaitNSeconds(3);

            KeyAuthApp.register(username, password, license);
            if (KeyAuthApp.response.success)

            {
                KeyAuthApp.login(username, password);
                if (KeyAuthApp.response.success)

                {
                    panel1.Show();
                    panel2.Show();
                    panel6.Show();

                    panel8.Hide();
                    panel9.Hide();

                    label1.Text = KeyAuthApp.user_data.username;
                    label11.Text = KeyAuthApp.user_data.subscriptions[0].subscription;

                    this.Size = new Size(984, 611);

                    this.FormBorderStyle = FormBorderStyle.None;
                    this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

                    if (KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == "Standard"))
                    {
                        this.pictureBox6.Image = global::HungerSquad.Properties.Resources.HungerSquad_Png_40x;
                        this.pictureBox4.Image = global::HungerSquad.Properties.Resources.BetaLock;
                        this.pictureBox5.Image = global::HungerSquad.Properties.Resources.DevLock;
                    }
                    else if (KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == "Beta Tester"))
                    {
                        this.pictureBox6.Image = global::HungerSquad.Properties.Resources.HungerSquadLock;
                        this.pictureBox4.Image = global::HungerSquad.Properties.Resources.Beta;
                        this.pictureBox5.Image = global::HungerSquad.Properties.Resources.DevLock;
                    }
                    else if (KeyAuthApp.user_data.subscriptions.Exists(x => x.subscription == "Developer"))
                    {
                        this.pictureBox6.Image = global::HungerSquad.Properties.Resources.HungerSquad_Png_40x;
                        this.pictureBox4.Image = global::HungerSquad.Properties.Resources.Beta;
                        this.pictureBox5.Image = global::HungerSquad.Properties.Resources.DevNew;
                    }

                    label2.Hide();
                    pictureBox15.Hide();
                    MessageBox.Show("Registered As: " + KeyAuthApp.user_data.username, "Registration Success!");
                }
            }
            else
            {
                label2.Hide();
                pictureBox15.Hide();
                MessageBox.Show("Error: " + KeyAuthApp.response.message, "Error");
            }
        }

        private void select_settings()
        {
            label5.Font = new Font(label5.Font, FontStyle.Regular);
            label3.Font = new Font(label3.Font, FontStyle.Regular);
            label4.Font = new Font(label4.Font, FontStyle.Regular);

            label6.Font = new Font(label4.Font, FontStyle.Bold);

            panel10.Show();
            panel17.Hide();

            label29.Text = "v" + KeyAuthApp.app_data.version;

        }


        private void label6_Click(object sender, EventArgs e)
        {
            select_settings();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            select_settings();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            select_settings();
        }



        private void load_settings()
        {
            siticoneTrackBar1.Value = Properties.Settings.Default.ram_allocated;

            label16.Text = siticoneTrackBar1.Value + " GB Allocated";

            if (Properties.Settings.Default.hide_on_start == false)
            {
                button1.BackgroundImage = null;
                button2.BackgroundImage = global::HungerSquad.Properties.Resources.button_bg;
            }
            else
            {
                button1.BackgroundImage = global::HungerSquad.Properties.Resources.button_bg;
                button2.BackgroundImage = null;
            }
        }



        private void siticoneTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label16.Text = siticoneTrackBar1.Value + " GB Allocated";

            Properties.Settings.Default.ram_allocated = siticoneTrackBar1.Value;
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (button1.BackgroundImage != global::HungerSquad.Properties.Resources.button_bg)
            {
                button1.BackgroundImage = global::HungerSquad.Properties.Resources.button_bg;
                button2.BackgroundImage = null;

                Properties.Settings.Default.hide_on_start = true;
                Properties.Settings.Default.Save();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (button2.BackgroundImage != global::HungerSquad.Properties.Resources.button_bg)
            {
                button1.BackgroundImage = null;
                button2.BackgroundImage = global::HungerSquad.Properties.Resources.button_bg;

                Properties.Settings.Default.hide_on_start = false;
                Properties.Settings.Default.Save();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            label1.Focus();
            System.Diagnostics.Process.Start("https://discord.gg/5JxT8t5wEj");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (File.Exists(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/HungerSquad/login.json")))
            {
                File.Delete(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/HungerSquad/login.json"));
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            label1.Focus();
            System.Diagnostics.Process.Start("https://discord.gg/5JxT8t5wEj");
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            label1.Focus();
            System.Diagnostics.Process.Start("https://www.youtube.com/@hungersquad5623");
        }

        static void DownloadForge()
        {
            string forgeUrl = "https://files.minecraftforge.net/maven/net/minecraftforge/forge/1.8.9-11.15.1.2318-1.8.9/forge-1.8.9-11.15.1.2318-1.8.9-installer.jar";
            string forgeFileName = "forge-1.8.9-11.15.1.2318-1.8.9-installer.jar";
            using (WebClient client = new WebClient())
            {
                Console.WriteLine("Downloading Forge...");
                client.DownloadFile(forgeUrl, forgeFileName);
                Console.WriteLine("Forge Downloaded");
            }

            Process process = new Process();
            process.StartInfo.FileName = "forge-1.8.9-11.15.1.2318-1.8.9-installer.jar";
            process.Start();


        }

        public static string genkey()
        {
            string MacAddress = "";

            // Get all network interfaces
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            // Find the primary network interface
            foreach (NetworkInterface ni in interfaces)
            {
                if (ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    // Check if the network interface contains "Hamachi" or "VirtualBox" in its name
                    if (ni.Name.Contains("Hamachi") || ni.Name.Contains("VirtualBox"))
                    {
                        continue; // Skip over the network interface if its name contains "Hamachi" or "VirtualBox"
                    }
                    if (ni.Name.Contains("Npcap"))
                    {
                        continue;
                    }

                    IPInterfaceProperties ipProps = ni.GetIPProperties();
                    if (ipProps.GatewayAddresses.Count > 0)
                    {
                        PhysicalAddress mac = ni.GetPhysicalAddress();
                        MacAddress = mac.ToString();
                        break;
                    }
                }
            }

            // Get the current time rounded up to the nearest 5-minute mark
            DateTime current_time = DateTime.UtcNow;
            DateTime future_time = current_time.AddMinutes(5 - current_time.Minute % 5).AddSeconds(-current_time.Second);

            // Convert the future time to a string
            string future_time_string = ((int)(future_time.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString();

            // Hash the future time string using SHA256
            SHA256 sha256 = SHA256.Create();
            byte[] future_time_hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(future_time_string));

            // Print the hash value
            string id = BitConverter.ToString(future_time_hash).Replace("-", "");

            string encodeid = MacAddress + "-" + id;



            return encodeid.ToString();
        }



        private async Task StartMinecraftAsync()
        {
            File.Delete(Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//temp_login.json"));

            string patha = Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//temp_login.json");
            FileStream a = File.Create(patha);

            a.Close();

            string encodeid = genkey();

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartObject();
                writer.WritePropertyName("key");
                writer.WriteValue(encodeid);
                writer.WriteEndObject();
            }

            File.WriteAllText(Environment.ExpandEnvironmentVariables("%AppData%//.minecraft//temp_login.json"), sb.ToString());


            MSession session = MSession.GetOfflineSession("fafler");

            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);
            var launchOption = new MLaunchOption
            {
                MaximumRamMb = Convert.ToInt32(Properties.Settings.Default.ram_allocated*1024),
                Session = session
            };
            try
            {
                var process = await launcher.CreateProcessAsync("1.8.9-forge1.8.9-11.15.1.2318-1.8.9", launchOption);
                process.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Du har allerede minecraft åben!");
            }
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            label1.Focus();
            button4.Enabled = false;
            if (button4.Text == "Launch")
            {
                label38.Text = "Checking requirements...";
                WaitNSeconds(2);
                if (Directory.Exists(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/versions/1.8.9-forge1.8.9-11.15.1.2318-1.8.9")))
                {
                    if (Directory.Exists(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods")))
                    {
                        string HungersquadUrl = "https://hungersquad.your-cloudstorage.com/s/Hm5iCXrj7gTnKEz/download/HungerSquad-1.0.jar";
                        string HungersquadName = "HungerSquad 1.0.jar";

                        string HungersquadBetaUrl = "https://hungersquad.your-cloudstorage.com/s/PqdgwR7EXgGd32r/download/HungerSquad%201.0.jar";
                        string HungersquadBetaName = "HungerSquad 1.0.jar";

                        string LabymodUrl = "https://hungersquad.your-cloudstorage.com/s/N9b4NZoZQRsrbw2/download/LabyMod-3-1.8.9%20%282%29.jar";
                        string LabymodName = "LabyMod-3-1.8.9.jar";

                        string OptifineUrl = "https://filebin.net/so1wuchg34u0vijl/OptiFine_1.8.9_HD_U_M5.jar";
                        string OptifineName = "OptiFine_1.8.9_HD_U_M5.jar";

                        File.Delete("HungerSquad 1.0.jar");
                        File.Delete("LabyMod-3-1.8.9.jar");
                        File.Delete("OptiFine_1.8.9_HD_U_M5.jar");

                        File.Delete(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/HungerSquad 1.0.jar"));
                        File.Delete(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/LabyMod-3-1.8.9.jar"));
                        File.Delete(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/OptiFine_1.8.9_HD_U_M5.jar"));


                        using (WebClient client = new WebClient())
                        {
                            if (label39.Text == "Developer")
                            {
                                label38.Text = "Downloading HungerSquad...";
                                WaitNSeconds(1);
                                client.DownloadFile(HungersquadUrl, HungersquadName);
                            }

                            if (label39.Text == "Beta")
                            {
                                label38.Text = "Downloading HungerSquad...";
                                WaitNSeconds(1);
                                client.DownloadFile(HungersquadBetaUrl, HungersquadBetaName);
                            }

                            if (checkBox1.Checked)
                            {
                                label38.Text = "Downloading Labymod...";
                                WaitNSeconds(1);
                                client.DownloadFile(LabymodUrl, LabymodName);
                            }

                            if (checkBox2.Checked)
                            {
                                label38.Text = "Downloading Optifine...";
                                WaitNSeconds(1);
                                //client.DownloadFile(OptifineUrl, OptifineName);
                            }

                        }

                        if (File.Exists(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/HungerSquad 1.0.jar")))
                        {
                            File.Delete(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/HungerSquad 1.0.jar"));
                            File.Move("HungerSquad 1.0.jar", Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/HungerSquad 1.0.jar"));
                        }
                        else
                        {
                            File.Move("HungerSquad 1.0.jar", Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/HungerSquad 1.0.jar"));
                        }

                        label38.Text = "Importing HungerSquad...";
                        WaitNSeconds(1);



                        if (checkBox1.Checked)
                        {
                            label38.Text = "Importing Labymod...";
                            if (File.Exists(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/LabyMod-3-1.8.9.jar")))
                            {
                                File.Delete(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/LabyMod-3-1.8.9.jar"));
                                File.Move("LabyMod-3-1.8.9.jar", Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/LabyMod-3-1.8.9.jar"));
                            }
                            else
                            {
                                File.Move("LabyMod-3-1.8.9.jar", Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/LabyMod-3-1.8.9.jar"));
                            }
                            WaitNSeconds(1);
                        }

                        if (checkBox2.Checked)
                        {
                            label38.Text = "Importing Optifine...";
                            if (File.Exists(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/OptiFine_1.8.9_HD_U_M5.jar")))
                            {
                                //File.Delete(Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/OptiFine_1.8.9_HD_U_M5.jar"));
                                //File.Move("OptiFine_1.8.9_HD_U_M5.jar", Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/OptiFine_1.8.9_HD_U_M5.jar"));
                            }
                            else
                            {
                                //File.Move("OptiFine_1.8.9_HD_U_M5.jar", Environment.ExpandEnvironmentVariables(@"%AppData%/.minecraft/mods/OptiFine_1.8.9_HD_U_M5.jar"));
                            }
                            WaitNSeconds(1);
                        }

                        label38.Text = "Starting Minecraft...";

                        Console.WriteLine("");
                        Console.WriteLine(Convert.ToInt32(Properties.Settings.Default.ram_allocated * 1024));
                        Console.WriteLine("");

                        StartMinecraftAsync();

                        WaitNSeconds(8);
                        label38.Text = "";

                        button4.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Error: Could not find mods folder.", "Error");
                        button4.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Error: Could not find forge folder.", "Error");
                    button4.Enabled = true;
                }
            }
            else if (button4.Text == "Install")
            {
                DownloadForge();
                button4.Text = "Launch";
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
