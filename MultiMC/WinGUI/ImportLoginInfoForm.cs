using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MultiMC.GUI;
using MultiMC.Tasks;

namespace MultiMC.WinGUI 
{
    public partial class ImportLoginInfoForm : WinFormsDialog, IImportLoginInfoDialog
    {
        

        public ImportLoginInfoForm()
        {
            InitializeComponent();

            FromBox.Items.AddRange(Instance.LoadInstancesNames(AppSettings.Main.InstanceDir));
            ToBox.Items.AddRange(Instance.LoadInstancesNames(AppSettings.Main.InstanceDir));
        }


        private void Ok_clicked(object sender, EventArgs e)
        {
            String tName = ToBox.Text;
            String fName = FromBox.Text;
            LoginCopyTask copyTask = new LoginCopyTask(fName,tName);
            copyTask.Start();
            OnResponse(DialogResponse.OK);
            
        }

        private void Cancel_clicked(object sender, EventArgs e)
        {
            OnResponse(DialogResponse.Cancel);
        }


    }
}
