using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frontend
{
    

    public partial class Form1: Form
    {
        int processcount;
        string CLIlocation;
        string filelocation;
        string buffer = "1024";
        bool CorD;//true comp false decomp
        List<Processeslabels> runningProcess = new List<Processeslabels>();

        public Form1()
        {
            InitializeComponent();
            
            processcount = 0;
            start.Enabled = false;
            Compressionbutt.ForeColor = Color.Black;
            CorD = true;
            Decompressionbutt.ForeColor = Color.Gray;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Please select the CLI (backend) first");
            bool foundvalidcli = true;
            while (foundvalidcli)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Executable (*.exe)|*.exe";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetFileName(open.FileName) == "FileCompression.exe")
                    {
                        CLIlocation = open.FileName;
                        foundvalidcli = false;
                        this.Activate();
                    }
                    else
                    {
                        MessageBox.Show("Invalid CLI! Please Try again");
                    }
                }
                else
                {
                    MessageBox.Show("ERROR! You must select CLI");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Compressionbutt.ForeColor = Color.Black;
            CorD = true;
            Decompressionbutt.ForeColor = Color.Gray;
        }

        private void Decompressionbutt_Click(object sender, EventArgs e)
        {
            Decompressionbutt.ForeColor = Color.Black;
            CorD = false;
            Compressionbutt.ForeColor = Color.Gray;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filelocation = openFileDialog1.FileName;
                start.Enabled = true;
            }
            
        }

        private void start_Click(object sender, EventArgs e)
        {
            Label compressionlabel = new Label 
            {
                Text="Compressing...",
                ContextMenuStrip=cancel,
                AutoSize = true,
                Location= new Point(20,50+(processcount*25)),
                Font=new Font("Ink Free",15,FontStyle.Bold)
            };

            Label decompressionlabel = new Label
            {
                Text = "Decompressing...",
                ContextMenuStrip = cancel,
                AutoSize = true,
                Location = new Point(20, 50 + (processcount * 25)),
                Font = new Font("Ink Free", 15, FontStyle.Bold)

            };

            var compressionprocess = new ProcessStartInfo
            {
                FileName = CLIlocation,
                Arguments = $"-b {buffer} -c \"{filelocation}\" \"{filelocation}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            var decompressionprocess = new ProcessStartInfo
            {
                FileName = CLIlocation,
                Arguments = $"-b {buffer} -d \"{filelocation}\" \"{filelocation}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            Process runCLI = new Process();
            Label process = new Label();
            switch (CorD)
            {
                case true:
                    runCLI = new Process 
                    {
                        StartInfo=compressionprocess,
                        EnableRaisingEvents = true
                    };
                    process = compressionlabel;
                    panel1.Controls.Add(process);
                    processcount++;

                    break;

                case false:
                    runCLI = new Process
                    {
                        StartInfo = decompressionprocess,
                        EnableRaisingEvents = true
                    };
                    process = decompressionlabel;
                    panel1.Controls.Add(process);
                    processcount++;

                    break;

            }

            runCLI.Exited += (s, evt) =>
            {
                panel1.Invoke((MethodInvoker)(() => { 
                    process.Text = "Done!";
                    process.ContextMenuStrip = clear;
                }));

            };

            runningProcess.Add(new Processeslabels
            {
                label = process,
                pro= runCLI

            });
            try
            {
                runCLI.Start();
            }
            catch
            {
                MessageBox.Show("Error! Invalid file");

            }
        }

        private void panel2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect= DragDropEffects.None;
            }
        }

        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (file.Length > 0) 
            {
                filelocation = file[0];
                start.Enabled = true;
                
            }

        }

        private void cancelProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cancel.SourceControl is Label label)
            {
                var p = runningProcess.FirstOrDefault(y => y.label == label);
                if (p != null)
                {
                    p.pro.Kill();
                    label.Text = "Cancelled";
                    label.ContextMenuStrip = cancel;
                }
            }
        }

        private void clearProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clear.SourceControl is Label label)
            {
                panel1.Controls.Remove(label);
                var p = runningProcess.FirstOrDefault(y => y.label == label);
                runningProcess.Remove(p);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using(setbuffer setbuffer=new setbuffer())
            {
                if(setbuffer.ShowDialog() == DialogResult.OK)
                {
                    buffer = setbuffer.buffer;
                    
                }
            }
        }
    }

    class Processeslabels
    {
        public Label label { get; set; }
        public Process pro { get; set; }
    }
}
