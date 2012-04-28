using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace MultiMC.Tasks
{
   public  class LoginCopyTask : Task
    {

       public LoginCopyTask(String src, String dest)
       {
           this.Source = src;
           this.Destination = dest;
          

       }

        protected override void TaskStart()
        {
            OnStart();
            Progress = 0;
            
            try
            {
                int pathLen = Source.Length + 1;
                string destDir = Destination;

                // Create a list of files to copy.
                Status = "Finding files...";
                Progress = 0;
                string[] loginFile = Directory.GetFiles(Path.Combine(AppSettings.Main.InstanceDir, Source),
                    Properties.Resources.LastLoginFileName, SearchOption.AllDirectories);


                Status = string.Format("Copying Login Info...", loginFile.Length);
                Progress = 20;

                for (int i = 0; i < loginFile.Length; i++)
                {
                    Progress = (int)
                        (((float)(i + 20) / (float)(loginFile.Length + 20)) * 100f);

                    string src = loginFile[i];
                    string dest = Path.Combine(AppSettings.Main.InstanceDir, destDir, Properties.Resources.LastLoginFileName);
                    File.Copy(src, dest);
                }
            }
            catch (IOException ex)
            {
                OnErrorMessage("Failed to copy folder.\n" +
                    ex.Message);

                OnComplete(false);
            }
            finally
            {
                OnComplete();
            }
        }

        public string Source
        {
            get;
            set;
        }

        public string Destination
        {
            get;
            set;
        }


    }
}
