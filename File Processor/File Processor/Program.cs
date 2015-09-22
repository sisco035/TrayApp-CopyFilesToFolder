using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace FileProcessorApp
{
    public class SysTrayApp : Form
    {
        [STAThread]
        public static void Main()
        {
            Application.Run(new SysTrayApp());
        }

        public NotifyIcon trayIcon;
        public ContextMenu trayMenu;

        public SyncClaims claims = new SyncClaims();
        public SyncRegistration registration = new SyncRegistration();
        public SyncProgramme programme = new SyncProgramme();
        public SyncProgrammeTiering progTiering = new SyncProgrammeTiering();
        public SyncProduct product = new SyncProduct();
        public SyncProductTiering  prodTiering = new SyncProductTiering();
        public SyncBusinessPartner bp = new SyncBusinessPartner();
        public SyncSearchFunctions searchFunctions = new SyncSearchFunctions();
        public SyncAdminCenter adminCenter = new SyncAdminCenter();
        public SyncAdminAmend adminAmend = new SyncAdminAmend();
        public SyncAdminFunctions adminFunctions = new SyncAdminFunctions();

        public SysTrayApp()
        {
            // Create a simple tray menu with only one item.

            trayMenu = new ContextMenu();

            trayMenu.MenuItems.Add("Sync Claims!",claims.CopyToDropbox);
            trayMenu.MenuItems.Add("Sync Registration!",registration.CopyToDropbox);
            trayMenu.MenuItems.Add("Sync Programme!", programme.CopyToDropbox);
            trayMenu.MenuItems.Add("Sync Programme Tiering!", progTiering.CopyToDropbox);
            trayMenu.MenuItems.Add("Sync Product!", product.CopyToDropbox);
            trayMenu.MenuItems.Add("Sync Product Tiering!", prodTiering.CopyToDropbox);
            trayMenu.MenuItems.Add("Sync Business Partner!", bp.CopyToDropbox);
            trayMenu.MenuItems.Add("Sync Search Functions!", searchFunctions.CopyToDropbox);
            trayMenu.MenuItems.Add("Sync Admin Center!", adminCenter.CopyToDropbox);
            trayMenu.MenuItems.Add("Sync Admin Amend!", adminAmend.CopyToDropbox);
            trayMenu.MenuItems.Add("Sync Admin Functions!", adminFunctions.CopyToDropbox);
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add("Exit", OnExit);


            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            

            trayIcon = new NotifyIcon();
            trayIcon.Text = "MyTrayApp";
            trayIcon.Icon = new Icon(SystemIcons.Asterisk, 40, 40);

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }

       
        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {

            Application.Exit();
        }





        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.
                trayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }




    }
}