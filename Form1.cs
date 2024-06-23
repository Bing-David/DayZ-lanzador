using DayZ_Launcher;
using DayZ_Launcher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;
using SharpCompress.Readers;
using SharpCompress.Archives;
using System.IO.Compression;
using System.Reflection;
using System.Net.Http;

//Launcher by Code & Jhonathan Dayz Evangelion
namespace New_Test_Launcher
{
    public partial class Form1 : Form
    {

        //Tarea Principal. & actualizador

        public Form1()
        {



            InitializeComponent();
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(3000);
            t.Abort();

            string folder = @"config";

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            File.WriteAllText(@"config\Version.ini", Resources.Version);




            //Borra el launcher antiguo

            if (File.Exists("viejo.exe"))
            {
                File.Delete("viejo.exe");
            }

            //Borra el launcher antiguo


            //ACTUALIZADOR
            WebClient webClient = new WebClient();
            try
            {
                //------------------VERSIÓN ACTUAL 1.1.6 , version de desarrollo 1.0.8             modica el paste bin para actualizar.
                if (webClient.DownloadString("https://pastebin.com/raw/Gfy6pRF9").Contains("1.0.8"))
                {
                    MessageBox.Show("Si deseas actualizar presiona aceptar.");

                    //Cambiar el nombre del proceso actual
                    string oldPath = Application.ExecutablePath;
                    string newPath = Path.Combine(Application.StartupPath, "viejo.exe");
                    File.Move(oldPath, newPath);

                    //Descargar archivo desde servidor FTP
                    string ftpFilePath = "ftp://179.33.182.39/LC/launcher.rar";
                    string ftpUser = "ftpusuario";
                    string ftpPass = "3214569870.a";

                    using (WebClient ftpClient = new WebClient())
                    {
                        ftpClient.Credentials = new NetworkCredential(ftpUser, ftpPass);
                        ftpClient.DownloadFile(ftpFilePath, "launcher.rar");
                    }

                    //Mostrar mensaje para extraer manualmente
                    MessageBox.Show("Descarga completada. Extrae manualmente el archivo 'launcher.rar' en la carpeta de instalación del JUEGO.", "Descarga completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Cerrar proceso actual
                    Process.GetCurrentProcess().Kill();
                }
            }
            catch
            {
                //Error...
                MessageBox.Show("Error al descargar archivo");
                Process.GetCurrentProcess().Kill();
            }
            //ACTUALIZADOR

        }



        public void StartForm()
        {
            //Pantalla de carga
            Application.Run(new splash_screen());



        }
        int m, mx, my;
        //ID & Name
        private void Form1_Load(object sender, EventArgs e)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DayZ\stats.DayZ.json";

            if (File.Exists(path))

            {
                string[] linhas = File.ReadAllLines(path);

                string ID = "USER_";

                foreach (string linha in linhas)
                {
                    if (linha.Contains(ID))
                    {
                        string TEST = linha.Replace("USER_", "");
                        string TEST2 = TEST.Replace(":", "");
                        string TEST3 = TEST2.Replace("{", "");
                        string TEST4 = TEST3.Replace("\"", "");
                        string TEST5 = TEST4.TrimEnd();
                        string TEST6 = TEST5.TrimStart();
                        string UID = TEST6.Trim(); 
                        label1.Text = UID;
                    }
                }
            }
            else
            {
                label1.Text = "#00000";
            }

            //nombre- en el launcher
            string nombre = @"config\Nombre.ini";
            if (File.Exists(nombre))
            {
                string[] linhas = File.ReadAllLines(nombre);
                string ID = "Nombre=";

                foreach (string linha in linhas)
                {
                    if (linha.Contains(ID))
                    {
                        string TEST = linha.Replace("Nombre=", "");
                        string TEST2 = TEST.Replace(":", "");
                        string TEST3 = TEST2.Replace("{", "");
                        string TEST4 = TEST3.Replace("\"", "");
                        string TEST5 = TEST4.TrimEnd();
                        string TEST6 = TEST5.TrimStart();
                        string UID = TEST6.Trim();
                        label5.Text = UID;
                    }
                }
            }
            else
            {
                label5.Text = "¿Nombre?";
                //En el caso que no tengas NOMBRE sale Error xd.
            }











            //Borrar archivos




            //archivos namalsk.

            //Cogemos la ruta Herramientas2
            string ruta1 = @"mods\herramientas2\Addons";
            string[] archivos1 = { "Free_Loading_Slideshow.pbo", "Free_Loading_Slideshow.pbo.pantallas.bisign", "Free_Loading_Slideshow.pboR0Lu_Free_Loading_Slideshow.bisign" };

            //Cogemos la ruta Modificaciones
            string ruta2 = @"modificaciones2\Addons";
            string[] archivos2 = { "ModdedMainMenu_v3.pbo", "ModdedMainMenu_v3.pbo.convinada.bisign" };

            //Cogemos la ruta.
            string ruta3 = @"modificaciones\Addons";
            string[] archivos3 = { "ModdedMainMenu_v3.pbo", "ModdedMainMenu_v3.pbo.convinada.bisign" };


            string ruta4 = @"mods2\act1\Addons";
            string[] archivos4 = { "SpawnSelect.pbo", "SpawnSelect.pbo.PattowieSSelection.bisign" };


            string ruta5 = @"mods2\act1\Addons";
            string[] archivos5 = { "CarePackage.pbo", "CarePackage.pbo.DannyDoom.bisign" };


            try
            {
                // Borrar archivos de la ruta 1
                foreach (string archivo in archivos1)
                {
                    string rutaCompleta = Path.Combine(ruta1, archivo);
                    if (File.Exists(rutaCompleta))
                    {
                        File.Delete(rutaCompleta);
                    }
                }

                // Borrar archivos de la ruta 2

                foreach (string archivo in archivos3)
                {
                    string rutaCompleta = Path.Combine(ruta3, archivo);
                    if (File.Exists(rutaCompleta))
                    {
                        File.Delete(rutaCompleta);
                    }
                }


                // Borrar archivos de la ruta 3
                foreach (string archivo in archivos2)
                {
                    string rutaCompleta = Path.Combine(ruta2, archivo);
                    if (File.Exists(rutaCompleta))
                    {
                        File.Delete(rutaCompleta);
                    }
                }




                // Borrar archivos de la ruta 4
                foreach (string archivo in archivos4)
                {
                    string rutaCompleta = Path.Combine(ruta4, archivo);
                    if (File.Exists(rutaCompleta))
                    {
                        File.Delete(rutaCompleta);
                    }
                }


                // Borrar archivos de la ruta 4
                foreach (string archivo in archivos5)
                {
                    string rutaCompleta = Path.Combine(ruta5, archivo);
                    if (File.Exists(rutaCompleta))
                    {
                        File.Delete(rutaCompleta);
                    }
                }



            }

            catch (Exception)
            {
                // Manejar excepciones silenciosamente
            }





            //Borrar carpeta.
            string ruta_folder = @"mods\mapa";

            try
            {
                // Borrar la carpeta y todos sus contenidos
                Directory.Delete(ruta_folder, true);
            }
            catch (Exception)
            {
                // Manejar excepciones silenciosamente
            }

            //Borrar carpeta.

            //archivos namalsk.



       








            //------------PING
            #region //ping

            Ping pingSender = new Ping();
            PingOptions options = new PingOptions(64, true);
            options.DontFragment = true;
            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 2000;
            try
            {

                //Donde esta la direcion se pone el Servidor al que quieres hacer PING
                //-->Puede que no funcione con algunos servidores Porque no permiten ser Pingeados.
                PingReply reply1 = pingSender.Send("179.33.182.39", timeout, buffer, options);
                if (reply1.Status == IPStatus.Success)
                {


                    //Si el Ping es mayor a 150 Mostrara Amarillo
                    //-->Si el ping es mayor a 190 mostrar rojo el icono de ping
                    string strName = (" \n Ping: " + reply1.RoundtripTime.ToString() + "ms");

                    pictureBox8.Image = Resources.PlayGreen;
                    if (reply1.RoundtripTime >= 150)
                    {

                        pictureBox8.Image = Resources.PlayYellow;
                        if (reply1.RoundtripTime >= 190)
                        {

                            pictureBox8.Image = Resources.PlayRed;
                        }

                    }
                }

                //En el caso que no sirva el pingeo a la pagina el icono sera rojo predeterminadamente. 
                else
                {

                    pictureBox8.Image = Resources.PlayRed;

                }

            }
            //Catch Por si hay algun error.(manejo de error).
            catch
            {
                pictureBox8.Image = Resources.PlayRed;


            }

            #endregion //PING
            //------------PING





            #region //VERSION
            try
            {
                string version1 = (@"config\Version.ini");
                if (File.Exists(version1))

                {
                    string number = "V : 1.1.6";
                    if (File.ReadLines(version1).Any(line => line.Contains(number)))
                    {
                        string version = number;
                        label3.Text = version;
                    }
                    else
                    {
                        string error = "ERROR";
                        label3.ForeColor = Color.Red;
                        label3.Text = error;

                    }



                }
                else
                {
                    string error = "ERROR";
                    label3.ForeColor = Color.Red;
                    label3.Text = error;
                }
            }
            catch
            {
                this.Close();
            }
            #endregion


        }
        //ID & Name


        //Change Name
        private void button2_Click(object sender, EventArgs e)
        {
            steamid_changer newform = new steamid_changer();
            File.WriteAllText(".Chernarus.ini", Resources._Chernarus);
            File.WriteAllText(".Chernarus_two.ini", Resources._Chernarus_two);
            File.WriteAllText(@"config\Nombre.ini", Resources.Nombre);
            newform.ShowDialog();
        }
        //Change Name


        //discord 
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/t9MYtHN6Yy");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/t9MYtHN6Yy");
        }
        //discord 


        //window config
        private void wall_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }
        private void wall_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }
        private void wall_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;

        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }
        private void pictureBox7_Click_2(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;

        }
        private void pictureBox7_Click_4(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //window config



        //config window
        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            nucleos newform = new nucleos();
            newform.ShowDialog();
            return;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            label1.Focus();
        }
        //config window



        //find game.
        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            string juego = @".\";
            Process.Start(juego);
        }
        //find game.



        //Borrar cache & resetear config
        private void pictureBox3_Click_1(object sender, EventArgs e)

        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DayZ";


            string sourceDir = @"%localappdata%\DayZ";
            sourceDir = Environment.ExpandEnvironmentVariables(sourceDir);
            if (MessageBox.Show("Esta acción removerá tus archivos temporales en /AppData/local/DayZ folder, estás seguro?", "Porfavor confirma", MessageBoxButtons.YesNo) == DialogResult.Yes)

                try
                {
                    string[] logs = Directory.GetFiles(sourceDir, "*.rpt");
                    string[] logs1 = Directory.GetFiles(sourceDir, "*.log");

                    foreach (string f in logs)
                    {
                        File.Delete(f);
                    }
                    foreach (string f in logs1)
                    {
                        File.Delete(f);
                    }

                    if (Directory.Exists(path))
                    {
                        Directory.Delete(path, true);
                    }

                    MessageBox.Show("Tus archivos temporales han sido removidos");
                }

                catch (DirectoryNotFoundException dirNotFound)
                {
                    MessageBox.Show(dirNotFound.Message);
                }

            else
            {

            }
        }
        //Borrar cache & resetear config


        //cofig parametros
        private void pictureBox2_Click_2(object sender, EventArgs e)
        {
            nucleos newform = new nucleos();
            newform.ShowDialog();
            return;
        }
        //cofig parametros.


        //ACTUALIZADOR INTEGRADO.
        #region

        /*      private void pictureBox1_Click(object sender, EventArgs e)
              {
                  //Este boton de la tuerquita que instala los componentes.
                  *//* this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                   Process.Start(@"Errores\vcredist\INSTALAR TODO.bat");*/

        /*actualizador frmActualizador = new actualizador();
        frmActualizador.ShowDialog();*//*

*/


        /*    private async void pictureBox1_Click(object sender, EventArgs e)
            {
                // Mostrar el formulario "Actualizador"
                Form3 actualizador = new Form3();
                actualizador.Show();
                actualizador.BringToFront();
                this.WindowState = FormWindowState.Minimized;

                string ftpFolder = "/"; // Ruta del archivo en el servidor FTP
                *//* string localFolder = "C:/Users/Code/Desktop";*//* // Ruta local donde se guardarán los archivos


                string localFolder = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "mods2"); //ruta de la app, guardar en carpeta mods2.
                string ftpUrl = "ftp://179.33.182.39" + ftpFolder;
                string ftpUsername = "ftpusuario";
                string ftpPassword = "3214569870.a";

                try
                {
                    // Comprobar si hay archivos .rar en el servidor FTP
                    FtpWebRequest checkRequest = (FtpWebRequest)WebRequest.Create(ftpUrl);
                    checkRequest.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    checkRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                    using (FtpWebResponse checkResponse = (FtpWebResponse)checkRequest.GetResponse())
                    {
                        Stream checkStream = checkResponse.GetResponseStream();
                        StreamReader checkReader = new StreamReader(checkStream);
                        bool foundRar = false;
                        while (!checkReader.EndOfStream)
                        {
                            string checkLine = checkReader.ReadLine();
                            if (Path.GetExtension(checkLine).ToLower() == ".rar")
                            {
                                foundRar = true;
                                break;
                            }
                        }
                        if (!foundRar)
                        {
                            actualizador.Close();
                            MessageBox.Show("No se encontraron  actualizaciones");
                            return;
                        }
                    }

                    // Descargar archivos .rar desde el servidor FTP
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
                    request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    request.Method = WebRequestMethods.Ftp.ListDirectory;
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        Stream responseStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(responseStream);

                        string line = reader.ReadLine();
                        while (!string.IsNullOrEmpty(line))
                        {
                            string remoteFileUrl = ftpUrl + line;
                            string localFilePath = Path.Combine(localFolder, line);

                            // Descargar solo los archivos .rar
                            if (Path.GetExtension(localFilePath).ToLower() == ".rar")
                            {
                                request = (FtpWebRequest)WebRequest.Create(remoteFileUrl);
                                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                                request.Method = WebRequestMethods.Ftp.DownloadFile;

                                using (FtpWebResponse downloadResponse = (FtpWebResponse)request.GetResponse())
                                {
                                    responseStream = downloadResponse.GetResponseStream();
                                    FileStream fileStream = new FileStream(localFilePath, FileMode.Create);

                                    await responseStream.CopyToAsync(fileStream);

                                    fileStream.Close();
                                    downloadResponse.Close();
                                }

                                // Extraer los archivos del archivo .rar
                                using (var archive = RarArchive.Open(localFilePath))
                                {
                                    foreach (var entry in archive.Entries)
                                    {
                                        if (!entry.IsDirectory)
                                        {
                                            entry.WriteToDirectory(localFolder, new ExtractionOptions()
                                            {
                                                ExtractFullPath = true,
                                                Overwrite = true
                                            });
                                        }
                                    }
                                }

                                // Eliminar el archivo .rar después de la extracción
                                File.Delete(localFilePath);
                            }

                            line = reader.ReadLine();
                        }

                        reader.Close();
                        responseStream.Close();
                        response.Close();
                    }

                    // Cerrar formulario de actualización y mostrar
                    // Cerrar formulario de actualización y mostrar mensaje de éxito
                    actualizador.Close();
                    MessageBox.Show("La actualización ha sido completada.");
                }
                catch (WebException ex)
                {
                    actualizador.Close();
                    MessageBox.Show("Error al descargar los archivos: " + ex.Message);
                }
                catch (Exception ex)
                {
                    actualizador.Close();
                    MessageBox.Show("Error al actualizar: " + ex.Message + "\n" + ex.StackTrace);
                }
                finally
                {
                    // Restaurar la ventana principal a su tamaño original
                    this.WindowState = FormWindowState.Normal;
                }
            }
    */

        #endregion
        //ACTUALIZADOR INTEGRADO.


        //ACTUALIZADOR APARTE.
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("actualizador.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No tienes el'actualizador.exe'. Descargalo del discord {ex.Message}");
            }
        }
        //ACTUALIZADOR APARTE.







        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Inica el Discord y minimiza el Launcher.
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            Process.Start("https://discord.gg/pEhYQkuVmp");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click_1(object sender, EventArgs e)
        {
            WindowState=FormWindowState.Minimized;
        }




        //Botoenes de JUEGO

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {

            if (File.ReadLines(".Chernarus_two.ini").Any((string line) => line.Contains("CHANGEME")))
            {
                MessageBox.Show("Tú apodo no ha sido guardado!");
                new steamid_changer().ShowDialog();
                return;
            }

            if (File.ReadLines(".Chernarus.ini").Any((string line) => line.Contains("CHANGEME")))
            {
                MessageBox.Show("Tú apodo no ha sido guardado!");
                new steamid_changer().ShowDialog();
                return;
           }

         



            Process.Start("juego.cmd");
            new please_wait().Show();
        }

        //Botoenes de JUEGO




        private void pictureBox8_Click_2(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }



        //Paypal
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            Process.Start("https://www.paypal.com/paypalme/jdsanchezgarcia");

        }
        //Paypal



        private void timer1_Tick(object sender, EventArgs e)
        {

        }


        //Botones Jugar

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {

            //TAKISTAN boton de Jugar

            //valning boton de Jugar

            if (File.ReadLines(".Chernarus_two.ini").Any((string line) => line.Contains("CHANGEME")))
            {
                MessageBox.Show("Tú apodo no ha sido guardado!");
                new steamid_changer().ShowDialog();
                return;
            }

            if (File.ReadLines(".Chernarus.ini").Any((string line) => line.Contains("CHANGEME")))
            {
                MessageBox.Show("Tú apodo no ha sido guardado!");
                new steamid_changer().ShowDialog();
                return;
            }

            Process.Start("juego.cmd");
            new please_wait().Show();



        }

        //Botones Jugar



        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            Process.Start("http://evangeliion.ml/version.html");
        }




        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            //sobre escribe el archivo nombre Chernarus_two(pvp) Chernarus(Survival) y añade Uno nuevo.
            steamid_changer newform = new steamid_changer(); //Para luego saltar el dialogo de ingresas nombre.
            File.WriteAllText(@"config\Nombre.ini", Resources.Nombre);
            File.WriteAllText(".Chernarus_two.ini", Resources._Chernarus_two); //livonia
            File.WriteAllText(".Chernarus.ini", Resources._Chernarus); //Tesing
            newform.ShowDialog();
        }



        //close window
        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        //close window

    }
}
